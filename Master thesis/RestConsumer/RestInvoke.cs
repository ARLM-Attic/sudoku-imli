using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace RestConsumer
{
    class RestInvoke
    {
        public string httpGet(string URI)
        {
            string respond = "" ;

            WebRequest request = WebRequest.Create(URI);

            request.Method = "GET";
            //request.ContentType = "application/xml";
            //request.ContentLength = 0;
            WebResponse response = request.GetResponse();
            
             StreamReader stream = new StreamReader(response.GetResponseStream());
             
                    
                   // Console.WriteLine(stream.ReadToEnd());
             XmlDocument xmlDoc = new XmlDocument();
             xmlDoc.LoadXml(stream.ReadToEnd());
             //Console.WriteLine(xmlDoc.FirstChild);
             XmlNode nod = xmlDoc.FirstChild;
             Console.WriteLine(nod.OuterXml);
                    string test = stream.ReadToEnd();

                    
                    //XmlDocument = new XmlDocument(test);
                    
            

                    Console.Read();
                
            
          /*  StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Close();
            StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
            respond = responseReader.ReadToEnd();
            */

            return respond;
        }


    }
}
