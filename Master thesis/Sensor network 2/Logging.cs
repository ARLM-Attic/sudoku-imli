using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SensorNetwork
{
    public class Log
    {
        public Log(string log)
        {
            FileStream file = File.OpenWrite("App_Data/log");
            string info = DateTime.Now.ToString() + log;
            byte[] text = System.Text.Encoding.ASCII.GetBytes(info);
            file.Write(text, 0, text.Count());
        }

    }
}