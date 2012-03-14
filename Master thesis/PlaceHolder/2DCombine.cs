using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceHolder
{
    public class TwoDimensionCombine
    {
        private readonly List<Node> _nodeList = new List<Node>(); //list of normal nodes
        private readonly List<Node> _crossNodeList = new List<Node>(); //list of nodes that have location specified in two networks
        private double _rotationAngle; //angle by which are networks rotated to each other
        private double _distanceRatio = 1; //if networks arent using same distance measurement
        private int _primaryNetwork;
        
        public TwoDimensionCombine(List<Node> nodeList, List<Node>crossNodeList)
        {
            _nodeList = nodeList;
            _crossNodeList = crossNodeList;
            if(crossNodeList.Count > 1)
            {
                _primaryNetwork = _crossNodeList[0].SensorNetworkID; //primary network id of first crossnode is going to be primary network
                CalculateNetworkDifferences(); //calculating angle and distance between networks
                AddNodesInfo(); //adding secondary coordinates to all nodes
            }
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
                if (xDifference == 0)
                {
                    if (yDifference > 0) angle = 270;
                    else angle = 90;
                }
            }
            else angle = Math.Pow(Math.Tan(xDifference / yDifference), -1); //else we have co determine it by formula tan alfa = a/b

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

            //in this section we are always computing an angle between two points
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
                if (_crossNodeList[i].SensorNetworkID == _crossNodeList[i + 1].SensorNetworkID)
                {
                    angle += returnAngle(_crossNodeList[i].XPos, _crossNodeList[i].YPos, _crossNodeList[i + 1].XPos,
                                         _crossNodeList[i + 1].YPos);

                    angleSecondary += returnAngle(_crossNodeList[i].XPosSecondary, _crossNodeList[i].YPosSecondary,
                                                  _crossNodeList[i + 1].XPosSecondary,
                                                  _crossNodeList[i + 1].YPosSecondary);
                }
                else if(_crossNodeList[i].SensorNetworkID != _primaryNetwork)
                {

                    angle += returnAngle(_crossNodeList[i].XPosSecondary, _crossNodeList[i].YPosSecondary, _crossNodeList[i + 1].XPos,
                     _crossNodeList[i + 1].YPos);

                    angleSecondary += returnAngle(_crossNodeList[i].XPos, _crossNodeList[i].YPos,
                                                  _crossNodeList[i + 1].XPosSecondary,_crossNodeList[i + 1].YPosSecondary);
                }
                else if(_crossNodeList[i+1].SensorNetworkID != _primaryNetwork)
                {

                    angle += returnAngle(_crossNodeList[i].XPos, _crossNodeList[i].YPos, _crossNodeList[i + 1].XPosSecondary,
                     _crossNodeList[i + 1].YPosSecondary);

                    angleSecondary += returnAngle(_crossNodeList[i].XPosSecondary, _crossNodeList[i].YPosSecondary,
                                                  _crossNodeList[i + 1].XPos,_crossNodeList[i + 1].YPos);
                
                }
                
            }
            //aritmethic mean of all calculated angles
            angle /= (_crossNodeList.Count - 1);
            angleSecondary /= (_crossNodeList.Count - 1);

            _rotationAngle = Math.Abs(angle - angleSecondary);
        }

        /// <summary>
        /// Updates all nodes with coordinates from both networks
        /// </summary>
        private void AddNodesInfo()
        {

            

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

        public Node UpdateNode(Node node)
        {
            if(node.SensorNetworkID != _primaryNetwork)
            {
               // node.


            }


            return node;
        }
    }
}