using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace PlaceHolder
{
    //interfaces that combines both modifing and creating new nodes
    public interface IReturnNodes
    {
        List<List<Node>> ReturnNodes(List<List<Node>> nodeListCollection);
    }

    public interface IReturnNode
    {
        Node ReturnNode(Node tempNode,int ID, int SensorNetworkID);
    }

    //interfaces for creating/updating existing new nodes
    public interface IGetNodes
    {
        List<List<Node>> GetNodes(List<List<Node>> nodeListCollection);
    }

    public interface IGetNode
    {
        Node GetNode(Node tempNode, int ID, int SensorNetworkID);
    }

    //interfaces used to modify existing nodes based on parametrs of their sensor networks
    public interface  IModifyNodes
    {
        List<List<Node>> ModifyNodes(List<List<Node>> nodeListCollection);
    }

    public interface IModifyNode
    {
        Node ModifyNode(Node tempNode, int ID, int SensorNetworkID);
    }

    //interface used to get methodname
    public interface IGetMethodName
    {
        char MethodName { get; }
    }
    
    /// <summary>
    /// Export for Node collections
    /// </summary>
    [Export(typeof(IReturnNodes))]
    public class Plugins: IReturnNodes
    {
        [ImportMany] 
        IEnumerable<Lazy<IGetNodes,IGetMethodName>> getMethods;

        [ImportMany]
        IEnumerable<Lazy<IModifyNodes, IGetMethodName>> modifyMethods;

        public List<List<Node>> ReturnNodes(List<List<Node>> nodeListCollection)
        {
            var settings = new Settings();

            int[] pluginIDs = settings.returnInputPlugins();

            if (pluginIDs.Count() != 0)
            {
                int i = 0;
                foreach (var method in getMethods)
                {
                   // if (pluginIDs[i] == method.Metadata.MethodID)
                        nodeListCollection = method.Value.GetNodes(nodeListCollection);
                   // i++;
                }

                foreach (var method in modifyMethods)
                {
                    // if (pluginIDs[i] == method.Metadata.MethodID)
                    nodeListCollection = method.Value.ModifyNodes(nodeListCollection);
                    // i++;
                }

            }
            else
            {
                foreach (Lazy<IGetNodes, IGetMethodName> method in getMethods)
                {
                    nodeListCollection = method.Value.GetNodes(nodeListCollection);
                }
            }

            return nodeListCollection;
        }
    }

    /// <summary>
    /// Export for Node collections
    /// </summary>
    [Export(typeof(IReturnNode))]
    public class simpleInput : IReturnNode
    {
        [ImportMany]
        IEnumerable<Lazy<IGetNode, IGetMethodName>> simpleGetMethods;

        [ImportMany]
        IEnumerable<Lazy<IModifyNode, IGetMethodName>> simpleModifyMethods;
        
        public Node ReturnNode(Node tempNode, int ID, int sensorNetworkID)
        {
            var settings = new Settings();

            int[] pluginIDs = settings.returnInputPlugins();


                foreach (var method in simpleGetMethods)
                {
                   // if (pluginIDs[i] == method.Metadata.MethodID)
                        tempNode = method.Value.GetNode(tempNode, ID, sensorNetworkID);
                   // i++;
                }

                foreach (var method in simpleModifyMethods)
                {
                    // if (pluginIDs[i] == method.Metadata.MethodID)
                    tempNode = method.Value.ModifyNode(tempNode, ID, sensorNetworkID);
                    // i++;
                }

            

            return tempNode;
        }
    }

    public class ModularIO
    {
        private Settings settings = new Settings();
        
        private CompositionContainer _container;
        private AggregateCatalog catalog = new AggregateCatalog();

        [Import(typeof (IReturnNodes))] public IReturnNodes GetNodesCollection;
        [Import(typeof(IReturnNode))]public IReturnNode GetNode;

        public ModularIO()
        {
            try
            { 
                string pluginPath = settings.ReturnPluginPath();
               catalog.Catalogs.Add(new AssemblyCatalog(typeof (ModularIO).Assembly));

                if (pluginPath != null)
                    catalog.Catalogs.Add(new DirectoryCatalog(pluginPath));

                _container = new CompositionContainer(catalog);
                _container.ComposeParts(this);
            }
            catch (CompositionException exception)
            {
                var log = new Log(exception.ToString(), settings.GetLogPath());
            }
        }
    }
}