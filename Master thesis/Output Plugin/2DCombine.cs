﻿using System;
using System.Collections.Generic;
using Agregation;

namespace PlaceHolder
{
    public class TwoDimensionCombine
    {
        private  List<Node> _nodeList = new List<Node>(); //list of normal nodes
        private readonly List<Node> _crossNodeList = new List<Node>(); //list of nodes that have location specified in two networks
        private double _rotationAngle; //angle by which are networks rotated to each other
        private double _distanceRatio = 1; //if networks arent using same distance measurement
        private int _primaryNetwork; //id of network that we decide is primary
        private int _secondaryNetwork;
        private double _xShift; //x distance between networks
        private double _yShift; //y distance between networks
        private Settings _settigns = new Settings();
        /// <summary>
        /// First Constructor, used when crossnodes are available
        /// </summary>
        /// <param name="nodeList">list of nodes with coordinates in only one network</param>
        /// <param name="crossNodeList">list of nodes with coordinates in both networks</param>
        public TwoDimensionCombine(List<Node> nodeList, List<Node>crossNodeList, int primaryNetworkID, int secondaryNetworkID)
        {
            _nodeList = nodeList;
            _crossNodeList = crossNodeList;
            _primaryNetwork = primaryNetworkID;
            _secondaryNetwork = secondaryNetworkID;
            if(crossNodeList.Count > 1)
            {
                CalculateNetworkDifferences(); //calculating angle and distance between networks
                AddNodesInfo(); //adding secondary coordinates to all nodes
            }
        }

        //second constructor in case we dont have cross nodes, but we have settigns in ServiceSettings.conf
        public TwoDimensionCombine(List<Node> nodeList)
        {
             var set = new Settings();
            _nodeList = nodeList;

            //setting primary and secondary network ID
            _primaryNetwork = _nodeList[0].SensorNetworkID;
            foreach (var node in nodeList)
            {
                if (node.SensorNetworkID != _primaryNetwork)
                {
                    _secondaryNetwork = node.SensorNetworkID;
                    break;
                }
            }
            //retreiving information from ServiceSettings.conf file
            double[] coordinateShift = set.returnCoordinateShift();
            _xShift = coordinateShift[0];
            _yShift = coordinateShift[1];
            _rotationAngle = set.returnShiftAngle();

            AddNodesInfo();
        }

        /// <summary>
        /// Same as above, but this time we are passing network shifts directly to contructor
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="xShift"></param>
        /// <param name="yShift"></param>
        /// <param name="shiftAngle"></param>
        public TwoDimensionCombine(List<Node> nodeList, double xShift, double yShift, double shiftAngle, int sensorNetworkID)
        {
            _primaryNetwork = sensorNetworkID;
            _nodeList = nodeList;
            _xShift = xShift;
            _yShift = yShift;
            _rotationAngle = shiftAngle;

            AddNodesInfo();
        }

        public void ClearCombine(List<Node> nodeList, double xShift, double yShift, double shiftAngle, int sensorNetworkID)
        {
            _primaryNetwork = sensorNetworkID;

            _nodeList.Clear();
            _nodeList = nodeList;
            _xShift = xShift;
            _yShift = yShift;
            _rotationAngle = shiftAngle;

            AddNodesInfo();
            
        }

        /// <summary>
        /// Calculating angle between two points
        /// </summary>
        /// <param name="x1">x Position of first point</param>
        /// <param name="y1">y Position of first point</param>
        /// <param name="x2">x Position of second point</param>
        /// <param name="y2">y Position of second point</param>
        /// <returns></returns>
        private double returnAngle(double x1, double y1, double x2, double y2)
        {
            double xDifference;
            double yDifference;

            double angle = 0;
            double radians;

            xDifference = x1 - x2;
            yDifference = y1 - y2;
            //in case we only go straight up/down/left/right, in that case we set angle directly
            if (yDifference == 0 || xDifference == 0)
            {
                if (yDifference == 0)
                {
                    if (xDifference > 0) angle = 180;
                    else angle = 0;
                }
                else
                {
                    if (yDifference > 0) angle = 270;
                    else angle = 90;
                }
            }
            else
            {
                //preset angle by determining in which quadrant we are computing angle
                if (x1 > x2 && y2 > y1)
                {
                    angle = 90;
                    radians = Math.Atan(xDifference / yDifference); //else we have to determine it by formula tan alfa = a/b
                    angle += radians * (180 / Math.PI);

                }
                else if (x1 > x2 && y1 > y2)
                {
                    angle = 180;

                    radians = Math.Atan(yDifference / xDifference); //else we have to determine it by formula tan alfa = a/b
                    angle += radians * (180 / Math.PI);
                }
                else if (y1 > y2 && x2 > x1)
                {
                    angle = 270;
                    radians = Math.Atan(xDifference / yDifference); //else we have to determine it by formula tan alfa = a/b
                    angle += radians * (180 / Math.PI);
                }
                else
                {
                    radians = Math.Atan(yDifference / xDifference); //else we have to determine it by formula tan alfa = a/b
                    angle += radians * (180 / Math.PI);
                }

            }

            return angle;
        }

        /// <summary>
        /// Calculating angle and distance between networks
        /// </summary>
        private void CalculateNetworkDifferences()
        {
            double xDifference; //
            double yDifference;
            double xDifferenceSecondary;
            double yDifferenceSecondary;
            double pointDistance;
            double pointDistanceSecondary;

            double angle = 0;
            double angleSecondary = 0;

            //in this section we are computing an angle between two networks
            for(int i = 0; i + 1  < _crossNodeList.Count; i++)
            {
                //getting x and y difference between points x1,x2 and y1,y2
                //xDifference = (_crossNodeList[i].XPos - _crossNodeList[i + 1].XPos);
                //yDifference = (_crossNodeList[i].YPos - _crossNodeList[i+i].YPos);
               // pointDistance = Math.Pow(xDifference + yDifference, 2);

                //xDifferenceSecondary = (_crossNodeList[i].XPosSecondary - _crossNodeList[i + 1].XPosSecondary);
                //yDifferenceSecondary = (_crossNodeList[i].YPosSecondary - _crossNodeList[i+i].YPosSecondary);
                //pointDistanceSecondary = Math.Pow(xDifference + yDifference, 2);

                //checking if both consequent nodes have same primary network id, if not we switch their XPOS/YPOS for XPOSSECONDARY etc.
                if (_crossNodeList[i].SensorNetworkID == _crossNodeList[i+1].SensorNetworkID) //in this case both consequent nodes have same primary network id
                {
                    angle = returnAngle(_crossNodeList[i].XPos, _crossNodeList[i].YPos, _crossNodeList[i + 1].XPos,
                                         _crossNodeList[i + 1].YPos);

                    angleSecondary = returnAngle(_crossNodeList[i].XPosSecondary, _crossNodeList[i].YPosSecondary,
                                                  _crossNodeList[i + 1].XPosSecondary,
                                                  _crossNodeList[i + 1].YPosSecondary);

                    _rotationAngle +=(Math.Abs(angle - angleSecondary));
                }
                else if(_crossNodeList[i].SensorNetworkID != _primaryNetwork && _crossNodeList[i+1].SensorNetworkID == _primaryNetwork) //first node doesnt have same primary network id
                {
                    angle = returnAngle(_crossNodeList[i].XPosSecondary, _crossNodeList[i].YPosSecondary, _crossNodeList[i + 1].XPos,
                     _crossNodeList[i + 1].YPos);

                    angleSecondary = returnAngle(_crossNodeList[i].XPos, _crossNodeList[i].YPos,
                                                  _crossNodeList[i + 1].XPosSecondary,_crossNodeList[i + 1].YPosSecondary);
                    _rotationAngle = (Math.Abs(angle - angleSecondary));
                }
                else if (_crossNodeList[i + 1].SensorNetworkID != _primaryNetwork && _crossNodeList[i].SensorNetworkID == _primaryNetwork) //second node doesnt have same primary network id
                {

                    angle = returnAngle(_crossNodeList[i].XPos, _crossNodeList[i].YPos, _crossNodeList[i + 1].XPosSecondary,
                     _crossNodeList[i + 1].YPosSecondary);

                    angleSecondary = returnAngle(_crossNodeList[i].XPosSecondary, _crossNodeList[i].YPosSecondary,
                                                  _crossNodeList[i + 1].XPos, _crossNodeList[i + 1].YPos);

                    _rotationAngle += (Math.Abs(angle - angleSecondary));

                }

                

            }
            
            //aritmethic mean of all calculated angles ;note - they all should be same
            _rotationAngle = Math.Abs(_rotationAngle/(_crossNodeList.Count-1));
            

            //calculating x/y shift between networks
            double[] shiftedCoordinates = calculateShitft2(_crossNodeList[0].XPosSecondary,
                                                          _crossNodeList[0].YPosSecondary, _rotationAngle);

            _xShift = _crossNodeList[0].XPos - shiftedCoordinates[0];
            _yShift = _crossNodeList[0].YPos - shiftedCoordinates[1];
            
            if(_crossNodeList[0].SensorNetworkID == 4)
            {

                _settigns.setAnything("XShift 1-4", _xShift.ToString());
                _settigns.setAnything("YShift 1-4", _yShift.ToString());
                _settigns.setAnything("ShiftAngle 1-4", _rotationAngle.ToString());
            }
        }
        /// <summary>
        /// Calculating shift in coordinates
        /// </summary>
        /// <param name="x">original XPOS</param>
        /// <param name="y">original YPOS</param>
        /// <param name="angle">shift angle</param>
        /// <returns>Shifted coordinates</returns>
        private double[] calculateShitft(double x, double y,double angle)
        {
            double[] result = new double[2];
            double inputAngle = (Math.PI / 180) * angle;
            result[0] = Math.Cos(inputAngle) * x + Math.Sin(inputAngle) * y ; //formula for 2D matrix shifting
            result[1] = -Math.Sin(inputAngle) * x + Math.Cos(inputAngle) * y;

            return result;
        }

        /// <summary>
        /// Calculating shift in coordinates
        /// </summary>
        /// <param name="x">original XPOS</param>
        /// <param name="y">original YPOS</param>
        /// <param name="angle">shift angle</param>
        /// <returns>Shifted coordinates</returns>
        private double[] calculateShitft2(double x, double y, double angle)
        {
            double[] result = new double[2];
            double inputAngle = (Math.PI / 180) * angle;
            result[0] = Math.Cos(inputAngle) * x - Math.Sin(inputAngle) * y; //formula for 2D matrix shifting
            result[1] = Math.Sin(inputAngle) * x + Math.Cos(inputAngle) * y;

            return result;
        }

        /// <summary>
        /// Updates all nodes with coordinates from both networks
        /// </summary>
        private void AddNodesInfo()
        {
            foreach (var node in _nodeList)
            {
                UpdateNode(node);
            }
        }

        /// <summary>
        /// return updated nodes
        /// </summary>
        /// <returns></returns>
        public List<Node> ReturnNodes()
        {
            List<Node> result = new List<Node>(); //list of normal nodes

            return result;
        }

        /// <summary>
        /// Updating node info about secondary coordinates
        /// </summary>
        /// <param name="editedNode">node to be updated</param>
        /// <returns>updated node</returns>
        public Node UpdateNode(Node editedNode)
        {
            if(editedNode.SensorNetworkID != _primaryNetwork)
            {
                double[] shiftedCoordinates = calculateShitft2(editedNode.XPos, editedNode.YPos, _rotationAngle);
                editedNode.XPosSecondary = shiftedCoordinates[0] + _xShift;
                editedNode.YPosSecondary = shiftedCoordinates[1] + _yShift;
                editedNode.SecondarySensorNetworkID = _primaryNetwork;
            }
           
            /*else
            {
                double[] shiftedCoordinates = calculateShitft(_xShift - editedNode.XPos, _yShift -editedNode.YPos, _rotationAngle);
                editedNode.XPosSecondary = shiftedCoordinates[0] - _xShift;
                editedNode.YPosSecondary = shiftedCoordinates[1] - _yShift;
                editedNode.SecondarySensorNetworkID = _secondaryNetwork;
            }
            */

            return editedNode;
        }
    }
}