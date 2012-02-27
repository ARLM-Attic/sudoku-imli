using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sensor_network_1
{   ///class storing information about one gps coordinate.
    public class gpsNode
    {
        private double XPos;
        private double YPos;
        new Exception constructFailure = new Exception("Failed to construct class");
        public double ID { get; private set; }
        /// <summary>
        /// constructor for class using two double values
        /// X = WEST -X = EAST Y = NORTH Y = -SOUTH
        /// </summary>
        /// <param name="X">min value: -90 max value 90</param>
        /// <param name="Y">min value -180 max value 180</param>
        public gpsNode(double X, double Y,int identification)
        {
            ID = identification;
            if ((X) > -90 && (X) < 90 && (Y) > -180 && (Y) < 180)
            {
                XPos = X;
                YPos = Y;
            }
            else throw constructFailure;
        }
        /// <summary>
        /// Constructor for class using string values
        /// Both Strings must be in for example in 36.54566E format.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public gpsNode(string X, string Y,int identification)
        {
            ID = identification;
            try
            {
                if (X.Contains("N"))
                {
                    X.Replace("N", "");
                    XPos = Double.Parse(X);
                }
                else if (X.Contains("S"))
                {
                    X.Replace("S", "");
                    XPos = Double.Parse(X);
                    XPos *= -1;
                }

                if (Y.Contains("W"))
                {
                    Y.Replace("W", "");
                    YPos = Double.Parse(Y);
                }
                else if (Y.Contains("E"))
                {
                    Y.Replace("E", "");
                    YPos = Double.Parse(Y);
                    YPos *= -1;
                }
            }
            catch (Exception exp) //in case of wrong coordinates we set default ones.
            {
                throw constructFailure;
            }

        }

        /// <summary>
        /// default contructor 
        /// 49.2262092N, 16.5965508E FIT VUTBR gps location
        /// </summary>
        public gpsNode(int identification)
        {
            ID = identification;
            XPos = 49.2262092;
            YPos = -16.5965508;
        }

        /// <summary>
        /// Moving coordinates by given doubles.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void changeCoordinates(double X, double Y)
        {
            //checking if new values will still be valid after position change
            if ((XPos + X) > -90 && (XPos + X) < 90 && (YPos + Y) > -180 && (YPos + Y) < 180)
            {
                XPos += X;
                YPos += Y;
            }
        }

        public string[] returnCoordinates()
        {
            string[] coordinates = new string[2];

            if (XPos < 0) coordinates[0] = XPos.ToString() + "S";
            if (XPos > 0) coordinates[0] = XPos.ToString() + "N";

            if (YPos < 0) coordinates[1] = YPos.ToString() + "E";
            if (YPos > 0) coordinates[1] = YPos.ToString() + "W";


            return coordinates;
        }
    }
}