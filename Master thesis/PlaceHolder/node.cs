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
        [DataMember]
        public int ID { get;  set;}
        [DataMember]
        public int SensorNetworkID { get;  set; }
        [DataMember]
        public int SecondarySensorNetworkID { get; set; }
        [DataMember]   
        public double XPos {get;  set;}
        [DataMember]
        public double YPos { get;  set;}
        [DataMember]
        public double ZPos { get;  set; }
        [DataMember]
        public double XPosSecondary { get;  set; }
        [DataMember]
        public double YPosSecondary { get;  set; }
        [DataMember]
        public double ZPosSecondary { get;  set; }
        [DataMember]
        public string GlobalPositionValue { get;  set; }
        [DataMember]
        public string GLobalPositionType { get; set; }


        public Node(Node node)
        {
            ID = node.ID;
            SensorNetworkID = node.SensorNetworkID;
            SecondarySensorNetworkID = node.SecondarySensorNetworkID;
            XPos = node.XPos;
            YPos = node.YPos;
            ZPos = node.ZPos;
            XPosSecondary = node.XPosSecondary;
            YPosSecondary = node.YPosSecondary;
            ZPosSecondary = node.ZPosSecondary;
            GlobalPositionValue = node.GlobalPositionValue;
            //this.node = node;
        }


        public Node(int identification, int networkID, double x, double y, double z)
        {
            ID = identification;
            SensorNetworkID = networkID;
            XPos = x;
            YPos = y;
            ZPos = z;

            RoundNumbers();
        }

        public Node(int identification, int networkID, double x, double y, double z, string globalPosition,string globalPostionType, double xSecondary, double ysecondary, double zSecondary, int SecondaryNetworkID)
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

            GlobalPositionValue = globalPosition;
            GLobalPositionType = globalPostionType;
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
