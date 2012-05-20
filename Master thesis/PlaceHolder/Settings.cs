using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml;

namespace PlaceHolder
{
        /// <summary>
        /// Class for retreiving information from ServiceSettings.config file
        /// </summary>
    public class Settings
    {

        public string getAnything(string keyValue)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(keyValue);
        }
        /// <summary>
        /// Function taken from
        /// http://social.msdn.microsoft.com/Forums/da-DK/csharpgeneral/thread/d68a872e-14bc-414a-82c4-d1035a11b4a8
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="setValue"></param>
        public void setAnything(string keyValue, string setValue)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0] != null)
                        {
                            if (node.Attributes[0].Value.Equals(keyValue))
                            {
                                node.Attributes[1].Value = setValue;
                            }
                        }
                    }
                }
            }

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ConfigurationManager.RefreshSection("appSettings");
        }

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