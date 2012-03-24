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

    public interface IGetMethodID
    {
        int MethodID { get; }
    }

    [Export(typeof(IGetNodes))]
    [ExportMetadata("MethodID",'1')]
    class HttpRetreive : IGetNodes
    {
        public List<List<Node>> GetNodes(List<List<Node>> nodeListCollection)
        {
            var node = new Node(0, 1, 1, 1, 1);
            nodeListCollection[0].Add(node);

            return nodeListCollection;
        }
    }

    [Export(typeof(IReturnNodes))]
    public class Input: IReturnNodes
    {
        [ImportMany] 
        IEnumerable<Lazy<IGetNodes,IGetMethodID>> methods;

        public List<List<Node>> ReturnNodes(List<List<Node>> nodeListCollection)
        {
            var settings = new Settings();

            int[] pluginIDs = settings.returnInputPlugins();

            if (pluginIDs.Count() != 0)
            {
                int i = 0;
                foreach (var method in methods)
                {
                    if (pluginIDs[i] == method.Metadata.MethodID)
                        nodeListCollection = method.Value.GetNodes(nodeListCollection);
                    i++;
                }
            }
            else
            {
                foreach (Lazy<IGetNodes,IGetMethodID> method in methods)
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

        private List<List<Node>> _nodeListCollection;
        
        private CompositionContainer _container;

        [Import(typeof (IReturnNodes))] public IReturnNodes GetNodesCollection;

        public ModularIO(List<List<Node>> nodeListCollection)
        {
            try
            {
                
                string pluginPath = settings.ReturnPluginPath();
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(typeof (Combine).Assembly));

                if (pluginPath != null)
                    catalog.Catalogs.Add(new DirectoryCatalog(settings.ReturnPluginPath()));

                _container = new CompositionContainer(catalog);
                _container.ComposeParts(this);

                _nodeListCollection = GetNodesCollection.ReturnNodes(nodeListCollection);
            }
            catch (CompositionException exception)
            {
                var log = new Log(exception.ToString(), settings.GetLogPath());
            }
        }

        public List<List<Node>> ReturnCollection()
        {
            return _nodeListCollection;
        }

    }
}