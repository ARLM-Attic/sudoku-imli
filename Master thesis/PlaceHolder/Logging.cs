using System;
using System.IO;
using System.Linq;

namespace Agregation
{
    /// <summary>
    /// Class used to create logs in selected path
    /// </summary>
    public class Log
    {
        public Log(string log,string path)
        {
            if (path != null)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                
                    StreamWriter sr = File.AppendText(path+"/log");
                    string info = DateTime.Now + " : " + log;
                    sr.WriteLine(info, 0, info.Count());
                    sr.Close();       
            }
        }

    }
}