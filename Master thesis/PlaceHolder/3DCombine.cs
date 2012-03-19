using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceHolder
{
    public class _3DCombine
    {
        private readonly List<Node> _nodeList = new List<Node>(); //list of normal nodes
        private readonly List<Node> _crossNodeList = new List<Node>(); //list of nodes that have location specified in two networks

        private double _alfaRotation; //angle by which are networks rotated to each other on x axis
        private double _betaRotation; //angle by which are networks rotated to each other on y axis
        private double _gamaRotation; //angle by which are networks rotated to each other on z axis

        private double _distanceRatio = 1; //if networks arent using same distance measurement - obsolete atm

        private int _primaryNetwork; //id of network that we decide is primary
        private int _secondaryNetwork;

        private double _xShift; //x distance between networks
        private double _yShift; //y distance between networks
        private double _zShift; //z distance between networks

        /// <summary>
        /// First Constructor, used when crossnodes are available
        /// </summary>
        /// <param name="nodeList">list of nodes with coordinates in only one network</param>
        /// <param name="crossNodeList">list of nodes with coordinates in both networks</param>
        public _3DCombine(List<Node> nodeList, List<Node>crossNodeList)
        {
            _nodeList = nodeList;
            _crossNodeList = crossNodeList;
            if(crossNodeList.Count > 1)
            {
                _primaryNetwork = _crossNodeList[0].SensorNetworkID; //primary network id of first crossnode is going to be primary network
                _secondaryNetwork = _crossNodeList[0].SecondarySensorNetworkID; // setting secondary network id
                CalculateNetworkDifferences(); //calculating angle and distance between networks
                //AddNodesInfo(); //adding secondary coordinates to all nodes
            }
        }


        //second constructor in case we dont have cross nodes, but we have settigns in ServiceSettings.conf
        public _3DCombine(List<Node> nodeList)
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
            _zShift = coordinateShift[2];
            _alfaRotation = set.returnShiftAngle();

            AddNodesInfo();
        }

        public void test()
        {
            double angle = returnAngle(_crossNodeList[0].XPos, _crossNodeList[0].YPos, _crossNodeList[1].XPos,
                                       _crossNodeList[1].YPos);
            double angleSecond = returnAngle(_crossNodeList[0].XPosSecondary, _crossNodeList[0].YPosSecondary, _crossNodeList[1].XPosSecondary,
                                       _crossNodeList[1].YPosSecondary);


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
                if (x1 > x2 && y2 > y1) angle = 90;
                else if (x1 > x2 && y1 > y2) angle = 180;
                else if (y1 > y2 && x2 > x1) angle = 270;

                radians = Math.Atan(xDifference / yDifference); //else we have to determine it by formula tan alfa = a/b
                angle += radians * (180 / Math.PI);
            }

            return angle;
        }

        /////////REWRITE BELOW////////
        ///                 /////
        ///                 /////
        /// <summary>
        /// Calculating angle and distance between networks
        /// </summary>
        private void CalculateNetworkDifferences()
        {
          double[] rotationAngles = new double[3];
          double angle;
          double angleSecondary;
            

            //in this section we are computing an angles between two networks
            for (int i = 0; i + 1 < _crossNodeList.Count; i++) 
            {
                if (_crossNodeList[i].SensorNetworkID != _primaryNetwork && _crossNodeList[i + 1].SensorNetworkID == _primaryNetwork) //first node doesnt have same primary network id
                {
                    Node firstNode = new Node(_crossNodeList[i].ID, _crossNodeList[i].SecondarySensorNetworkID,
                                              _crossNodeList[i].XPosSecondary, _crossNodeList[i].YPosSecondary,
                                              _crossNodeList[i].ZPosSecondary,
                                              _crossNodeList[i].gpsPosition, _crossNodeList[i].XPos,
                                              _crossNodeList[i].YPos, _crossNodeList[i].ZPos,
                                              _crossNodeList[i].SensorNetworkID);
                    Node secondNode = new Node(_crossNodeList[i+1]);

                    rotationAngles = ReturnRotationAngles(firstNode, secondNode);
                }
                else if (_crossNodeList[i + 1].SensorNetworkID != _primaryNetwork && _crossNodeList[i].SensorNetworkID == _primaryNetwork) //second node doesnt have same primary network id
                {
                    Node firstNode = new Node(_crossNodeList[i]);

                    Node secondNode = new Node(_crossNodeList[i+1].ID, _crossNodeList[i].SecondarySensorNetworkID,
                                               _crossNodeList[i+1].XPosSecondary, _crossNodeList[i].YPosSecondary,
                                               _crossNodeList[i+1].ZPosSecondary,
                                               _crossNodeList[i+1].gpsPosition, _crossNodeList[i].XPos,
                                               _crossNodeList[i+1].YPos, _crossNodeList[i].ZPos,
                                               _crossNodeList[i+1].SensorNetworkID);
                    rotationAngles = ReturnRotationAngles(firstNode, secondNode);
                }
                else
                {
                    Node firstNode = new Node(_crossNodeList[i]);
                    Node secondNode = new Node(_crossNodeList[i+1]);

                    rotationAngles = ReturnRotationAngles(firstNode, secondNode);
                }

                _betaRotation += rotationAngles[0]; //rotation around z axis
                _gamaRotation += rotationAngles[1]; //rotation around y axis
                _alfaRotation += rotationAngles[2]; //rotation around x axis

            }

            //aritmethic mean of all calculated angles ;note - they all should be same
            _alfaRotation = Math.Abs(_alfaRotation/(_crossNodeList.Count-1));
            _betaRotation = Math.Abs(_betaRotation / (_crossNodeList.Count - 1));
            _gamaRotation = Math.Abs(_gamaRotation / (_crossNodeList.Count - 1));
            
            ////REWRITE/////
            /// 
            /// 
            
            //calculating x/y shift between networks
           double[] shiftedCoordinates = calculateShitft(_crossNodeList[0].XPosSecondary,
                                                          _crossNodeList[0].YPosSecondary,_crossNodeList[0].ZPosSecondary, _alfaRotation,_betaRotation,_gamaRotation);

            //_xShift = _crossNodeList[0].XPos + shiftedCoordinates[0];
            //_yShift = _crossNodeList[0].YPos + shiftedCoordinates[1];
               
        }

        /// <summary>
        /// A function that takes primary/secondary coordinates of given nodes, 
        /// and calculates a rotation of one cartesian system to another
        /// </summary>
        /// <param name="firstNode"></param>
        /// <param name="secondNode"></param>
        /// <returns>Returns rotation of cartesian coordinate system around every axis</returns>
        private double[] ReturnRotationAngles(Node firstNode, Node secondNode)
        {
            var rotationAngles = new double[3];

            //calculating alfa rotation
            double angle = returnAngle(firstNode.XPos, firstNode.YPos, secondNode.XPos,
                                       secondNode.YPos);

            double angleSecondary = returnAngle(firstNode.XPosSecondary, firstNode.YPosSecondary,
                                                secondNode.XPosSecondary,
                                                secondNode.YPosSecondary);

            rotationAngles[0] = (Math.Abs(angle - angleSecondary));

            //calculating beta rotation
            angle = returnAngle(firstNode.XPos, firstNode.ZPos, secondNode.XPos,
                                secondNode.ZPos);

            angleSecondary = returnAngle(firstNode.XPosSecondary, firstNode.ZPosSecondary,
                                         secondNode.XPosSecondary,
                                         secondNode.ZPosSecondary);

            rotationAngles[1] = (Math.Abs(angle - angleSecondary));

            //calculating gama rotation
            angle = returnAngle(firstNode.YPos, firstNode.ZPos, secondNode.YPos,
                                secondNode.ZPos);

            angleSecondary = returnAngle(firstNode.YPosSecondary, firstNode.ZPosSecondary,
                                         secondNode.YPosSecondary,
                                         secondNode.ZPosSecondary);

            rotationAngles[2] = (Math.Abs(angle - angleSecondary));


            return rotationAngles;

        }


        ///<summary>
        /// Calculating shift in coordinates
        /// </summary>
        /// <param name="x">original XPOS</param>
        /// <param name="y">original YPOS</param>
        /// <param name="z">original ZPOS</param>
        /// <param name="alfa">alfa shift angle - shift angle around x axis</param>
        /// <param name="beta">beta shift angle - shift angle around y axis</param>
        /// <param name="gama">gama shift angle - shift angle around z axis</param>
        /// <returns>Shifted coordinates</returns>
        private double[] calculateShitft(double x, double y, double z,double alfa, double beta, double gama)
        {
            double[] result = new double[3];
            double[] rotationMatrix = new double[9];
            double[] inputMatrix = new double[3];



            double inputAlfa = (Math.PI/180)*alfa;
            double inputBeta = (Math.PI/180)*beta;
            double inputGama = (Math.PI/180)*gama;

            rotationMatrix[0] = Math.Cos(inputBeta)*Math.Cos(inputGama);
            rotationMatrix[1] = -Math.Cos(inputBeta)*Math.Sin(inputGama);
            rotationMatrix[2] = -Math.Sin(inputGama);
            rotationMatrix[3] = Math.Cos(inputAlfa)*Math.Sin(inputGama) -
                        Math.Sin(inputAlfa)*Math.Cos(inputBeta)*Math.Cos(inputGama);
            rotationMatrix[4] = Math.Cos(inputAlfa)*Math.Sin(inputGama) +
                        Math.Sin(inputAlfa)*Math.Cos(inputBeta)*Math.Sin(inputGama);
            rotationMatrix[5] = -Math.Sin(inputAlfa)*Math.Cos(inputBeta);
            rotationMatrix[6] = Math.Cos(inputAlfa)*Math.Sin(inputBeta)*Math.Cos(inputGama) +
                        Math.Sin(inputAlfa)*Math.Sin(inputGama);
            rotationMatrix[7] = Math.Sin(inputAlfa)*Math.Cos(inputGama) - Math.Cos(inputAlfa)*
                        Math.Sin(inputBeta)*Math.Sin(inputGama);
            rotationMatrix[8] = Math.Cos(inputAlfa)*Math.Cos(inputBeta);

            inputMatrix[0] = x;
            inputMatrix[1] = y;
            inputMatrix[2] = z;
            for(int i = 0; i < 9; i++)
            {
                 result[i/3] += rotationMatrix[i] * inputMatrix[i%3];
            }

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
                double[] shiftedCoordinates = calculateShitft(editedNode.XPos, editedNode.YPos,editedNode.ZPos, _alfaRotation,_betaRotation,_gamaRotation);
                editedNode.XPosSecondary = _xShift - shiftedCoordinates[0];
                editedNode.YPosSecondary = _yShift - shiftedCoordinates[1];
                editedNode.SecondarySensorNetworkID = _primaryNetwork;
            }
            else
            {
                double[] shiftedCoordinates = calculateShitft2(_xShift - editedNode.XPos, _yShift -editedNode.YPos, _alfaRotation);
                editedNode.XPosSecondary = shiftedCoordinates[0];
                editedNode.YPosSecondary = shiftedCoordinates[1];
                editedNode.SecondarySensorNetworkID = _secondaryNetwork;
            }


            return editedNode;
        }
    }

    
}