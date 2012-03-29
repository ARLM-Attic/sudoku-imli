using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PlaceHolder
{
        /// <summary>
        /// Class for retreiving information from ServiceSettings.config file
        /// </summary>
    public class Settings
    {
        public string GetLogPath()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("LogPath");
        }

        public bool AreCrossNodesAvailable()
        {
            if (ConfigurationManager.AppSettings.Get("CrossNodesAvailable").Contains("YES"))
            {
                return true;
            }
            else return false;
        }

        public double[] returnCoordinateShift()
        {
            
            double[] coordinateShift = new double[3];

            Double.TryParse(ConfigurationManager.AppSettings.Get("XShift"),out coordinateShift[0]);
            Double.TryParse(ConfigurationManager.AppSettings.Get("YShift"), out coordinateShift[1]);
            Double.TryParse(ConfigurationManager.AppSettings.Get("ZShift"), out coordinateShift[2]);

            return coordinateShift;
        }

        public double returnShiftAngle()
        {
            double angle;
            Double.TryParse(ConfigurationManager.AppSettings.Get("ShiftAngle"), out angle);

            return angle;
        }

        public int[] returnInputPlugins()
        {
            var plugins = new int[2];

            plugins[0] = 1;

            return plugins;
        }

        public string ReturnPluginPath()
        {
            return ConfigurationManager.AppSettings.Get("Plugin Path");
        }

        public string[] ReturnSensorNetworks()
        {
            string temp = ConfigurationManager.AppSettings.Get("Sensor Networks");

            return temp.Split(';');
        }
    }
    
}