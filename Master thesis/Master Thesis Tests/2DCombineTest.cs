using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaceHolder;

namespace Master_Thesis_Tests
{
    [TestClass]
    public class _2DCombineTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Node> crossNodeList = new List<Node>();
            List<Node> nodeList = new List<Node>();

            Node node1 = new Node(0, 1, 4, 4, 0, "", 1, 1, 0, 2);
            Node node2 = new Node(1, 1, 4, 6, 0, "", 3, 1, 0, 2);
            Node node3 = new Node(2, 1, 2, 5, 0, "", 2, 3, 0, 2);

            crossNodeList.Add(node1);
            crossNodeList.Add(node2);
            crossNodeList.Add(node3);

            TwoDimensionCombine Combine = new TwoDimensionCombine(nodeList, crossNodeList);
        }
    }
}
