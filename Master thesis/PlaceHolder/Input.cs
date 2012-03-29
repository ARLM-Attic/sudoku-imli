using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace PlaceHolder
{

    public interface IReturnNodes
    {
        List<List<Node>> ReturnNodes(List<List<Node>> nodeListCollection);
    }

    public interface IGetNodes
    {
        List<List<Node>> GetNodes(List<List<Node>> nodeListCollection);
    }

    public interface  IModifyNodes
    {
        List<List<Node>> ModifyNodes(List<List<Node>> nodeListCollection);
    }

    public interface IGetMethodName
    {
        char MethodName { get; }
    }

    [Export(typeof(IGetNodes))]
    [ExportMetadata("MethodName",'1')]
    class HttpRetreive : IGetNodes
    {
        public List<List<Node>> GetNodes(List<List<Node>> nodeListCollection)
        {
            var node = new Node(1, 1, 1, 1, 1);
            nodeListCollection[0].Add(node);

            return nodeListCollection;
        }
    }

    [Export(typeof(IReturnNodes))]
    public class Input: IReturnNodes
    {
        [ImportMany] 
        IEnumerable<Lazy<IGetNodes,IGetMethodName>> methods;

        public List<List<Node>> ReturnNodes(List<List<Node>> nodeListCollection)
        {
            var settings = new Settings();

            int[] pluginIDs = settings.returnInputPlugins();

            if (pluginIDs.Count() != 0)
            {
                int i = 0;
                foreach (var method in methods)
                {
                   // if (pluginIDs[i] == method.Metadata.MethodID)
                        nodeListCollection = method.Value.GetNodes(nodeListCollection);
                   // i++;
                }
            }
            else
            {
                foreach (Lazy<IGetNodes,IGetMethodName> method in methods)
                {
                    nodeListCollection = method.Value.GetNodes(nodeListCollection);
                }
            }

            return nodeListCollection;
        }
    }

    public class ModularIO
    {
        private Settings settings = new Settings();
        
        private CompositionContainer _container;
        private AggregateCatalog catalog = new AggregateCatalog();

        [Import(typeof (IReturnNodes))] public IReturnNodes GetNodesCollection;

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