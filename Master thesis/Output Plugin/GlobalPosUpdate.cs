using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Agregation;
using PlaceHolder;

namespace Output_Plugin
{
    public class GlobalPosUpdate
    {
        private double _xShift;
        private double _yShift;
        private double _shiftAngle;
        private int _UTMzone;
        private string _hemisphere;
        private Settings _settings = new Settings();

        public GlobalPosUpdate(List<List<Node>> nodeListCollection, List<Node> globalPosList)
        {
            if(globalPosList.Count > 2)
            {
                calculateShift(globalPosList);

                foreach (var node in nodeListCollection[0])
                {
                  UpdateNode(node);   
                }


            }

        }

        public void calculateShift(List<Node> globalPosList)
        {
            double angle;
            double angleSecondary;
            double firstglobalX = 0;
            double firstglobalY = 0;
            double secondglobalX = 0;
            double secondglobalY = 0;
            double shiftAngle = 0;
            GeoUTMConverter converter = new GeoUTMConverter();

            double xValueFirst = 0;
            double yValueFirst = 0;
            double xValueSecond = 0;
            double yValueSecond = 0;

            for (int i = 0; i + 1 < globalPosList.Count; i++)
            {   
                //converting string value of global position in LonLat to two doubles
                if(globalPosList[i].GLobalPositionType == "LonLat")
                {
                    double[] globalPos = ReturnLonLan(globalPosList[i].GlobalPositionValue);
                    
                    converter.ToUTM(globalPos[0], globalPos[1]);

                    firstglobalX = converter.X;
                    firstglobalY = converter.Y;
                    
                }
                if (globalPosList[i+1].GLobalPositionType == "LonLat")
                {
                    double[] globalPos = ReturnLonLan(globalPosList[i+1].GlobalPositionValue);

                    converter.ToUTM(globalPos[0], globalPos[1]);

                    secondglobalX = converter.X;
                    secondglobalY = converter.Y;
                }

                globalPosList[i].XPosSecondary = firstglobalX;
                globalPosList[i].YPosSecondary = firstglobalY;

                int preferedID = 1;
                //string temp = _settings.getAnything("MainNetworkId");
                //Int32.TryParse(temp,out preferedID);

                //we dont know whether position of node in primary Network are in primary or secondary coordinates
                if (preferedID == globalPosList[i].SensorNetworkID)
                {
                    xValueFirst = globalPosList[i].XPos;
                    yValueFirst = globalPosList[i].YPos;
                }
                else
                {
                    xValueFirst = globalPosList[i].XPosSecondary;
                    yValueFirst = globalPosList[i].YPosSecondary;
                }

                if (preferedID == globalPosList[i+1].SensorNetworkID)
                {
                    xValueSecond = globalPosList[i+1].XPos;
                    yValueSecond = globalPosList[i+1].YPos;
                }
                else
                {
                    xValueSecond = globalPosList[i+1].XPosSecondary;
                    yValueSecond = globalPosList[i+1].YPosSecondary;
                }

                //calculating angle between global coordinaes and local coordinates
                 angle = returnAngle(xValueFirst, yValueFirst, xValueSecond,
                                        yValueSecond);

                    angleSecondary = returnAngle(firstglobalX, firstglobalY,
                                                 secondglobalX,
                                                 secondglobalY);

                    shiftAngle += (Math.Abs(angle - angleSecondary));
                
            }
            
            _shiftAngle = Math.Abs(shiftAngle / (globalPosList.Count - 1));
            globalPosList[3].XPosSecondary = secondglobalX;
            globalPosList[3].YPosSecondary = secondglobalY;
            
            //calculating x/y shift between local/global networks
            double[] shiftedCoordinates = calculateShitft2(xValueSecond,
                                                          yValueSecond, _shiftAngle);
            
            _xShift = secondglobalX - shiftedCoordinates[0];
            _yShift = secondglobalY - shiftedCoordinates[1];

            _UTMzone = (int)converter.Zone;
            _hemisphere = converter.Hemi.ToString();

             //setting parameters into web.config for future use
            _settings.setAnything("XShift 1-UTM", _xShift.ToString());
            _settings.setAnything("YShift 1-UTM", _yShift.ToString());
            _settings.setAnything("ShiftAngle 1-UTM", _shiftAngle.ToString());
            _settings.setAnything("UTM ZONE", _yShift.ToString());
            _settings.setAnything("Hemisphere", _hemisphere);

        }

        /// <summary>
        /// Accepting string and returning two doubles with latitude, longitude
        /// </summary>
        /// <param name="globalPos">for example : 49.2323422N;16.5713003E</param>
        /// <returns></returns>
        public double[] ReturnLonLan(string globalPos)
        {
            double[] result = new double[2];
            string temp;

            temp = globalPos.Substring(0, globalPos.IndexOf(";"));

            if (temp.Contains("N")) //if its in northern Hemisphere we leave positive latitude
            {
                temp = temp.Replace("N", "");
                Double.TryParse(temp,  NumberStyles.Any, CultureInfo.InvariantCulture,out result[0]);
            }
            else //otherwise its going to be negative value
            {
                temp = temp.Replace("S", "");
                Double.TryParse(temp,  NumberStyles.Any, CultureInfo.InvariantCulture,out result[0]);
                result[0] *= -1;         
            }

            temp = globalPos.Substring(globalPos.IndexOf(";")+1, globalPos.Length - globalPos.IndexOf(";")-1);

            if (temp.Contains("E")) //if its in northern Hemisphere we leave positive latitude
            {
                temp = temp.Replace("E", "");
                Double.TryParse(temp,  NumberStyles.Any, CultureInfo.InvariantCulture,out result[1]);
            }
            else //otherwise its going to be negative value
            {
                temp = temp.Replace("W", "");
                Double.TryParse(temp, NumberStyles.Any, CultureInfo.InvariantCulture, out result[1]);
                result[1] *= -1;
            }

            return result;
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
        /// Updating node info about global coordinates
        /// </summary>
        /// <param name="editedNode">node to be updated</param>
        public void UpdateNode(Node editedNode)
        {
            double xPos, yPos;
            if (editedNode.SensorNetworkID == 1)
            {
                xPos = editedNode.XPos;
                yPos = editedNode.YPos;
            }
            else
            {
                xPos = editedNode.XPosSecondary;
                yPos = editedNode.YPosSecondary;
            }
            double[] shiftedCoordinates = calculateShitft2(xPos, yPos, _shiftAngle);
                string System = "UTM"; //  _settings.getAnything("GlobalPosSystem");
                if ((System.CompareTo("UTM")) == 0)
                {
                    editedNode.GlobalPositionValue = (shiftedCoordinates[0] + _xShift) + ";" +
                                                     (shiftedCoordinates[1] + _yShift) + ";" + _UTMzone + ";" +
                                                     _hemisphere;
                    editedNode.GLobalPositionType = "UTM";

                }
            
        }

        /// <summary>
        /// Calculating shift in coordinates
        /// </summary>
        /// <param name="x">original XPOS</param>
        /// <param name="y">original YPOS</param>
        /// <param name="angle">shift angle</param>
        /// <returns>Shifted coordinates</returns>
        private double[] calculateShitft(double x, double y, double angle)
        {
            double[] result = new double[2];
            double inputAngle = (Math.PI / 180) * angle;
            result[0] = Math.Cos(inputAngle) * x + Math.Sin(inputAngle) * y; //formula for 2D matrix shifting
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

    }
}
