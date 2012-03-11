using System;
using System.Collections.Generic;
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
    }
    
}