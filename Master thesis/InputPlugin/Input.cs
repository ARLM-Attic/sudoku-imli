using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using PlaceHolder;

namespace InputPlugin
{

    [Export(typeof(IGetNodes))]
    [ExportMetadata("MethodID", '2')]
    public class Input : IGetNodes
    {
        public List<List<Node>> GetNodes(List<List<Node>> nodeCollection)
        {
            var node = new Node(2, 1, 1, 1, 1);
            nodeCollection[0].Add(node);

            return nodeCollection;
        }

    }
}
