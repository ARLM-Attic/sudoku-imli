using System;
using System.Runtime.Serialization;

namespace PlaceHolder
{
    /// <summary>
    /// A node class used to store node information
    /// </summary>
    [DataContract]
    public class Node
    {
        [DataMemberAttribute]
        public string GlobalPositionValue { get; set; }
        [DataMemberAttribute]
        public string GLobalPositionType { get; set; }
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
        public int SecondarySensorNetworkID { get; set; }
        [DataMemberAttribute]
        public double XPosSecondary { get;  set; }
        [DataMemberAttribute]
        public double YPosSecondary { get;  set; }
        [DataMemberAttribute]
        public double ZPosSecondary { get;  set; }



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
