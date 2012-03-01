using System;
using System.Runtime.Serialization;

namespace SensorNetwork
{
    /// <summary>
    /// A node class simulating movement of node inside sensor network
    /// </summary>
    [DataContract]
    public class Node
    {
        [DataMemberAttribute]
        public int ID { get;  set;}
        [DataMemberAttribute]
        public int sensorNetworkID { get;  set; }
        [DataMemberAttribute]   
        public double XPos {get;  set;}
        [DataMemberAttribute]
        public double YPos { get;  set;}
        [DataMemberAttribute]
        public double ZPos { get;  set; }
        [DataMemberAttribute]
        public double XPosSecondary { get;  set; }
        [DataMemberAttribute]
        public double YPosSecondary { get;  set; }
        [DataMemberAttribute]
        public double ZPosSecondary { get;  set; }
        [DataMemberAttribute]
        public string gpsPosition { get;  set; }



        //constructors
        public Node(int identification, int networkID)
        { 
            Random rand = new Random();
            ID = identification;
            sensorNetworkID = networkID;

            XPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();
            YPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();
            ZPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();

            XPosSecondary = 0;
            YPosSecondary = 0;
            ZPosSecondary = 0;

            gpsPosition = "";
            roundNumbers(); //rounding up numbers to two digits precision
        }

        public Node(int identification,int networkID, double x, double y,double z)
        {
            Random rand = new Random();
            ID = identification;
            sensorNetworkID = networkID;

            XPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();
            YPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();
            ZPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();

           
            XPosSecondary = x;
            YPosSecondary = y;
            ZPosSecondary = z;

            gpsPosition = "";
            roundNumbers();
        }

        public Node(int identification,int networkID, double x, double y,double z, string gps)
        {
            Random rand = new Random();
            ID = identification;
            sensorNetworkID = networkID;

            XPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();
            YPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();
            ZPos = rand.Next(NetworkVariables.NetworkAreaSize) * rand.NextDouble();

            XPosSecondary = x;
            YPosSecondary = y;
            ZPosSecondary = z;
            roundNumbers();

            gpsPosition = gps;
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

            if (rand.NextDouble() < 0.5 && ZPos < NetworkVariables.NetworkAreaSize - 1)
                ZPos = ZPos + rand.NextDouble();
            else if (ZPos > 1) ZPos = ZPos - rand.NextDouble();
            else ZPos = ZPos + rand.NextDouble();

            roundNumbers();
        }

        public void ChangePosition(double XSecond,double YSecond, double ZSecond)
        {
            //changing position
            Random rand = new Random();
            double temp;

            temp = rand.NextDouble();//increment/decrement for xPos

            if (rand.NextDouble() < 0.5 && XPos < NetworkVariables.NetworkAreaSize - 1) //deciding whether to increment or decrement xPos
                XPos = XPos + rand.NextDouble();
            else if (XPos > 1)
            {
                XPos = XPos - temp;
                XPosSecondary = XSecond - temp;
            }
            else
            {
                XPos = XPos + rand.NextDouble();
                XPosSecondary = XSecond + temp;
            }

            temp = rand.NextDouble(); //increment/decrement for yPos

            if (rand.NextDouble() < 0.5 && YPos < NetworkVariables.NetworkAreaSize - 1)//deciding whether to increment or decrement YPos
                YPos = YPos + rand.NextDouble();
            else if (YPos > 1)
            {
                YPos = YPos - temp;
                YPosSecondary = YSecond - temp;
            }
            else
            {
                YPos = YPos + rand.NextDouble();
                YPosSecondary = YSecond + temp;
            }


            temp = rand.NextDouble(); //increment/decrement for ZPos

            if (rand.NextDouble() < 0.5 && ZPos < NetworkVariables.NetworkAreaSize - 1)//deciding whether to increment or decrement YPos
                ZPos = ZPos + rand.NextDouble();
            else if (ZPos > 1)
            {
                ZPos = ZPos - temp;
                ZPosSecondary = ZSecond - temp;
            }
            else
            {
                ZPos = ZPos + rand.NextDouble();
                ZPosSecondary = ZSecond + temp;
            }

            roundNumbers();
        }

        /// <summary>
        /// Rounding up double numbers to two digits precision
        /// </summary>
        public void roundNumbers()
        {
            XPos = Math.Round(XPos, 2);
            YPos = Math.Round(YPos, 2);
            ZPos = Math.Round(ZPos, 2);
            XPosSecondary = Math.Round(XPosSecondary, 2);
            YPosSecondary = Math.Round(YPosSecondary, 2);
            ZPosSecondary = Math.Round(ZPosSecondary, 2);
        }


    }

    public class NetworkVariables
    {
        public static int NetworkAreaSize = 64; 
        public static int MaxNodeCount = 64;
    }
}
