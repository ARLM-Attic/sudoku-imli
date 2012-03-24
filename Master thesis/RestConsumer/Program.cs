using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SensorNetwork;

namespace RestConsumer
{
    class Program
    {
        private static List<SensorNetwork.Node> _nodeList1 = new List<Node>();
        private static List<SensorNetwork.Node> _nodeList2 = new List<Node>();
        static void Main(string[] args)
        {
            /*
            int firstNodesCount = 10;
            int secondNodesCount = 10;

            Console.WriteLine("Enter url of first service");
            firstService = Console.ReadLine();

            Console.WriteLine("Enter url of second service");
            secondService = Console.ReadLine();

            Console.WriteLine("Enter number of nodes in first service");
            firstNodesCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of nodes in second service");
            secondNodesCount = Int32.Parse(Console.ReadLine());
            */
            getNodes();
            
        }

        private static void getNodes()
        {
            RestConsume consume = new RestConsume();
            _nodeList1 = consume.httpGetNodeCollection("http://localhost/SensorNetwork/SensorNetwork/");

            _nodeList2 = consume.httpGetNodeCollection("http://localhost/SensorNetwork2/SensorNetwork/");

            foreach(var node in _nodeList1)
            {
                Console.WriteLine(node.ID + node.XPos + node.gpsPosition);
            }
            Console.Read();
        }
    }

    
}
