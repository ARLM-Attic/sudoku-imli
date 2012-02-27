using System;
using System.Runtime.Serialization;

namespace Sensor_network_2
{
    /// <summary>
    /// A node class simulating movement of node inside sensor network
    /// </summary>
    [DataContract]
    public class Node
    {
        [DataMemberAttribute]
        public int Id { get; private set;}
        [DataMemberAttribute]   
        public double XPos {get; private set;}
        [DataMemberAttribute]
        public double YPos { get; private set;}


        //constructor
        public Node(int identification)
        { 
            Random rand = new Random();
            Id = identification;

            XPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();
            YPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();
        }

        public void ChangePosition()
        { //simulation of node movement inside of the network
            Random rand = new Random();

            if (rand.NextDouble() < 0.5 && XPos < NetworkVariables.NetworkAreaSize - 1)
                XPos = XPos + rand.NextDouble();
            else if (XPos > 1) XPos = XPos - rand.NextDouble();
            else XPos = XPos + rand.NextDouble();

            if (rand.NextDouble() < 0.5 && YPos < NetworkVariables.NetworkAreaSize - 1)
                YPos = YPos + rand.NextDouble();
            else if (YPos > 1) YPos = YPos - rand.NextDouble();
            else YPos = YPos + rand.NextDouble();

        }
    }

    public class NetworkVariables
    {
        public static int NetworkAreaSize = 64; 
        public static int MaxNodeCount = 64;
    }
}
