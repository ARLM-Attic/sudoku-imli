using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Output_Plugin;
using PlaceHolder;

namespace OutputPlugin
{
    [Export(typeof(IModifyNodes))]
    [ExportMetadata("MethodName", '3')]
    public class Combine : IModifyNodes
    {
        Settings settings = new Settings();
        public List<List<Node>> ModifyNodes(List<List<Node>> nodeListCollection)
        {
            List<Node> globalPosList = new List<Node>();
            UpdateLocalPosition(nodeListCollection, globalPosList);
            UpdateGlobalPosition(nodeListCollection,globalPosList);
                          
            return nodeListCollection;
        }

        public void UpdateGlobalPosition(List<List<Node>> nodeListCollection, List<Node> globalPosList)
        {
            var globalPosUpdate = new GlobalPosUpdate(nodeListCollection, globalPosList);
        }

        public void UpdateLocalPosition(List<List<Node>> nodeListCollection, List<Node> globalPosList)
        {

            List<Node> nodeList1 = new List<Node>();
            List<Node> nodeList2 = new List<Node>();
            List<Node> nodeList3 = new List<Node>();
            List<Node> nodeList4 = new List<Node>();
           


            double xShift;
            double.TryParse(settings.getAnything("XShift 1-2"), out xShift);

            double yShift;
            double.TryParse(settings.getAnything("YShift 1-2"), out yShift);

            double angle;
            double.TryParse(settings.getAnything("ShiftAngle 1-2"), out angle);


            //going through list of input nodes and sorting them by network ID
            foreach (var node in nodeListCollection[0])
            {
                if (node.SensorNetworkID == 2)
                {
                    nodeList1.Add(node);
                }

                if (node.SensorNetworkID == 3)
                {
                    nodeList2.Add(node);
                }

                if ((node.SensorNetworkID == 4 || node.SensorNetworkID == 1) && node.SecondarySensorNetworkID == 0)
                {
                    nodeList3.Add(node);
                }
                if ((node.SensorNetworkID == 4 || node.SensorNetworkID == 1) && node.SecondarySensorNetworkID != 0)
                {
                    nodeList4.Add(node);
                }

                //since we are already in loop, lets pinpoint nodes which have some gps value in them so we can use it in other method
                if(node.GlobalPositionValue != "")
                {
                    globalPosList.Add(node);
                }
            }


            //using this class to add information about nodes
            var Combine = new TwoDimensionCombine(nodeList1, xShift, yShift, angle, 1);

            double.TryParse(settings.getAnything("XShift 1-3"), out xShift);
            double.TryParse(settings.getAnything("YShift 1-3"), out yShift);
            double.TryParse(settings.getAnything("ShiftAngle 1-3"), out angle);

            Combine.ClearCombine(nodeList2, xShift, yShift, angle, 1);

            var mixedCombine = new TwoDimensionCombine(nodeList3, nodeList4, 1,4);

        }

    }
    [Export(typeof(IModifyNode))]
    [ExportMetadata("MethodName", '4')]
    public class NodeUpdate : IModifyNode
    {
        Settings settings = new Settings();

        public Node ModifyNode(Node tempNode, int ID, int SensorNetworkID)
        {
            tempNode = changeCoordinates(tempNode);
            tempNode = changeGlobalCoordinates(tempNode);

            return tempNode;
        }

        private Node changeCoordinates(Node tempNode)
        {
            double XShift = 0;
            double YShift = 0;
            double rotationAngle = 0;

            string key = "ShiftAngle 1-" + tempNode.SensorNetworkID;
            string temp = settings.getAnything(key);

            double.TryParse(temp, out rotationAngle);
            double[] shiftedCoordinates = calculateShitft2(tempNode.XPos, tempNode.YPos, rotationAngle);

            key = key.Replace("ShiftAngle", "XShift");
            temp = settings.getAnything(key);
            double.TryParse(temp, out XShift);

            key = key.Replace("X", "Y");
            temp = settings.getAnything(key);
            double.TryParse(temp, out YShift);

            tempNode.XPosSecondary = shiftedCoordinates[0] + XShift;
            tempNode.YPosSecondary = shiftedCoordinates[1] + YShift;

            return tempNode;
        }

        private Node changeGlobalCoordinates(Node tempNode)
        {
            double XShift = 0;
            double YShift = 0;
            double rotationAngle = 0;

            string key = "ShiftAngle 1-UTM";
            string temp = settings.getAnything(key);
            double[] shiftedCoordinates = new double[2];

            double.TryParse(temp, out rotationAngle);
            if (tempNode.SensorNetworkID == 1)
            {
                shiftedCoordinates = calculateShitft2(tempNode.XPos, tempNode.YPos, rotationAngle);
            }
            else
            {
                shiftedCoordinates = calculateShitft2(tempNode.XPosSecondary, tempNode.YPosSecondary,
                                                               rotationAngle);
            }

            key = key.Replace("ShiftAngle", "XShift");
            temp = settings.getAnything(key);
            double.TryParse(temp, out XShift);

            key = key.Replace("X", "Y");
            temp = settings.getAnything(key);
            double.TryParse(temp, out YShift);

            int UTMZone;
            string Hemisphere;
            key = "UTM ZONE";
            temp = settings.getAnything(key);
            Int32.TryParse(temp, out UTMZone);

            key = "Hemisphere";
            Hemisphere = settings.getAnything(key);


            string System = "UTM";
            if ((System.CompareTo("UTM")) == 0)
            {
                tempNode.GlobalPositionValue = (shiftedCoordinates[0] + XShift) + ";" +
                                                 (shiftedCoordinates[1] + YShift) + ";" + UTMZone + ";" +
                                                 Hemisphere;
                tempNode.GLobalPositionType = "UTM";
            }
            return tempNode;
        }

        private double[] calculateShitft2(double x, double y, double angle)
        {
            double[] result = new double[2];
            double inputAngle = (Math.PI / 180) * angle;
            result[0] = Math.Cos(inputAngle) * x - Math.Sin(inputAngle) * y; //formula for 2D matrix shifting
            result[1] = Math.Sin(inputAngle) * x + Math.Cos(inputAngle) * y;

            return result;
        }

    }
}