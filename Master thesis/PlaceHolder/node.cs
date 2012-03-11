using System;
using System.Runtime.Serialization;

namespace PlaceHolder
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
        public int SecondarySensorNetworkID { get; set; }
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



        public Node(int identification, int networkID, double x, double y, double z)
        {
            ID = identification;
            SensorNetworkID = networkID;
            XPos = x;
            YPos = y;
            ZPos = z;

            RoundNumbers();
        }

        public Node(int identification, int networkID, double x, double y, double z, string gps, double xSecondary, double ysecondary, double zSecondary, int SecondaryNetworkID)
        {
            ID = identification;
            SensorNetworkID = networkID;
            SecondarySensorNetworkID = SecondaryNetworkID;
            XPos = x;
            YPos = y;
            ZPos = z;

            XPosSecondary = xSecondary;
            YPosSecondary = ysecondary;
            ZPosSecondary = zSecondary;
            RoundNumbers();

            gpsPosition = gps;
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
