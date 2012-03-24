using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PlaceHolder
{
    public class Log
    {
        public Log(string log,string path)
        {
            if (path != null)
            {
                StreamWriter sr = File.AppendText(path);
                string info = DateTime.Now + " : " + log;
                sr.WriteLine(info, 0, info.Count());
                sr.Close();
            }
        }

    }
}