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

            var mixedCombine = new TwoDimensionCombine(nodeList3, nodeList4, 1);

        }

    }
}