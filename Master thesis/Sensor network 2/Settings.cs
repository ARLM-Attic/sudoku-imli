using System;

namespace SensorNetwork
{
        /// <summary>
        /// Class for retreiving information from ServiceSettings.config file
        /// </summary>
    public class Settings
    {

        public int GetAreaSize()
        {
            int areaSize;
            Int32.TryParse(System.Configuration.ConfigurationManager.AppSettings.Get("NetworkAreaSize"), out areaSize);
            return areaSize;
        }

        public int GetMaxNodeCount()
        {
            int nodeCount;
            Int32.TryParse(System.Configuration.ConfigurationManager.AppSettings.Get("NetworkMaxNodeCount"), out nodeCount);
            return nodeCount;
        }

        public int GetInitialNodeCount()
        {
            int nodeCount;
            Int32.TryParse(System.Configuration.ConfigurationManager.AppSettings.Get("InitialNodeCount"), out nodeCount);
            return nodeCount;
        }

        public int GetNetworkID()
        {
            int networkID;
            Int32.TryParse(System.Configuration.ConfigurationManager.AppSettings.Get("NetworkID"), out networkID);
            return networkID;
        }

        public string GetLogPath()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("LogPath");
        }

        public int GetCrossNetworkNodeCount()
        {
            int crossNodes;
            Int32.TryParse(System.Configuration.ConfigurationManager.AppSettings.Get("CrossNetworkNodes"), out crossNodes);
            return crossNodes;
        }
    }
    
}