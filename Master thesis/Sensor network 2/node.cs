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
        public int SensorNetworkID { get;  set; }
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


        Settings values = new Settings();

        //constructors
        public Node(int identification, int networkID)
        {

            Random rand = new Random();
            ID = identification;
            SensorNetworkID = networkID;

            int areaSize = values.GetAreaSize();
            XPos = rand.Next(areaSize) * rand.NextDouble();
            YPos = rand.Next(areaSize) * rand.NextDouble();
            ZPos = rand.Next(areaSize) * rand.NextDouble();

            XPosSecondary = 0;
            YPosSecondary = 0;
            ZPosSecondary = 0;

            gpsPosition = "";
            RoundNumbers(); //rounding up numbers to two digits precision
        }

        public Node(int identification,int networkID, double x, double y,double z)
        {
            Random rand = new Random();
            ID = identification;
            SensorNetworkID = networkID;
            int areaSize = values.GetAreaSize();
            XPos = rand.Next(areaSize) * rand.NextDouble();
            YPos = rand.Next(areaSize) * rand.NextDouble();
            ZPos = rand.Next(areaSize) * rand.NextDouble();

           
            XPosSecondary = x;
            YPosSecondary = y;
            ZPosSecondary = z;

            gpsPosition = "";
            RoundNumbers();
        }

        public Node(int identification,int networkID, double x, double y,double z, string gps)
        {
            Random rand = new Random();
            ID = identification;
            SensorNetworkID = networkID;
            int areaSize = values.GetAreaSize();
            XPos = rand.Next(areaSize) * rand.NextDouble();
            YPos = rand.Next(areaSize) * rand.NextDouble();
            ZPos = rand.Next(areaSize) * rand.NextDouble();

            XPosSecondary = x;
            YPosSecondary = y;
            ZPosSecondary = z;
            RoundNumbers();

            gpsPosition = gps;
        }

        public Node(int identification, int networkID, double x, double y, double z, string gps, double xSecondary, double ysecondary,double zSecondary)
        {
            ID = identification;
            SensorNetworkID = networkID;
            int areaSize = values.GetAreaSize();
            XPos = x;
            YPos = y;
            ZPos = z;

            XPosSecondary = xSecondary;
            YPosSecondary = ysecondary;
            ZPosSecondary = zSecondary;
            RoundNumbers();

            gpsPosition = gps;
        }

        public void ChangePosition()
        { //simulation of node movement inside of the network
            Random rand = new Random();
            int areaSize = values.GetAreaSize();
            if (rand.NextDouble() < 0.5 && XPos < areaSize - 1)
                XPos = XPos + rand.NextDouble();
            else if (XPos > 1) XPos = XPos - rand.NextDouble();
            else XPos = XPos + rand.NextDouble();

            if (rand.NextDouble() < 0.5 && YPos < areaSize - 1)
                YPos = YPos + rand.NextDouble();
            else if (YPos > 1) YPos = YPos - rand.NextDouble();
            else YPos = YPos + rand.NextDouble();

            if (rand.NextDouble() < 0.5 && ZPos < areaSize - 1)
                ZPos = ZPos + rand.NextDouble();
            else if (ZPos > 1) ZPos = ZPos - rand.NextDouble();
            else ZPos = ZPos + rand.NextDouble();

            RoundNumbers();
        }

        public void ChangePosition(double XSecond,double YSecond, double ZSecond)
        {
            
            Random rand = new Random();
            double temp;
            int areaSize = values.GetAreaSize();
            temp = rand.NextDouble();//increment/decrement for xPos

            if (rand.NextDouble() < 0.5 && XPos < areaSize - 1) //deciding whether to increment or decrement xPos
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

            if (rand.NextDouble() < 0.5 && YPos < areaSize - 1)//deciding whether to increment or decrement YPos
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
           
            if (rand.NextDouble() < 0.5 && ZPos < areaSize - 1)//deciding whether to increment or decrement YPos
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

            RoundNumbers();
        }

        /// <summary>
        /// Rounding up double numbers to two digits precision
        /// </summary>
        public void RoundNumbers()
        {
            XPos = Math.Round(XPos, 2);
            YPos = Math.Round(YPos, 2);
            ZPos = Math.Round(ZPos, 2);
            XPosSecondary = Math.Round(XPosSecondary, 2);
            YPosSecondary = Math.Round(YPosSecondary, 2);
            ZPosSecondary = Math.Round(ZPosSecondary, 2);
        }


    }


}
