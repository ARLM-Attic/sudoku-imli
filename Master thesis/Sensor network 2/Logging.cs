using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SensorNetwork
{
    public class Log
    {
        public Log(string log,string path)
        {     
            StreamWriter sr = File.AppendText(path);
            string info = DateTime.Now +" : "+ log;
            sr.WriteLine(info,0,info.Count());
            sr.Close();
        }

    }
}