using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;

namespace RestConsumer
{
    class Program
    {
        private static string firstService;
        private static string secondService;
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
            InitalizeRestService(0, 0);
            
        }

        private static void InitalizeRestService(int firstNodesCount, int secondNodesCount)
        {
            RestConsume initalize = new RestConsume();
            List<SensorNetwork.Node> nodeList1 = new List<SensorNetwork.Node>();
            nodeList1 = initalize.httpGetCollection("http://localhost/SensorNetwork/SensorNetwork/");

            foreach(var node in nodeList1)
            {
                Console.WriteLine(node.ID + node.XPos + node.gpsPosition);
            }
            Console.Read();
        }
    }

    
}
