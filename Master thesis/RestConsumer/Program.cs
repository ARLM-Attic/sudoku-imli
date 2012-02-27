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
            RestInvoke initalize = new RestInvoke();

            Console.WriteLine(initalize.httpGet("http://localhost/SensorNetwork/SensorNetwork/"));


        }
    }

    
}
