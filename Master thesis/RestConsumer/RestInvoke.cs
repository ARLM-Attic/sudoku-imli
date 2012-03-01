using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace RestConsumer
{
    class RestConsume
    {
        public List<SensorNetwork.Node> httpGetCollection(string URI)
        {
            var _nodeList = new List<SensorNetwork.Node>();
            
            string respond = "" ;
            WebRequest request = WebRequest.Create(URI);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            var stream = new StreamReader(response.GetResponseStream());
             
             var xmlDoc = new XmlDocument();
             xmlDoc.LoadXml(stream.ReadToEnd());


            //parsing XML response into node objects
            XmlNodeList IDlist = xmlDoc.GetElementsByTagName("ID");
            XmlNodeList SensorIDList = xmlDoc.GetElementsByTagName("sensorNetworkID");
            XmlNodeList XPosList = xmlDoc.GetElementsByTagName("XPos");
            XmlNodeList YPosList = xmlDoc.GetElementsByTagName("YPos");
            XmlNodeList ZPosList = xmlDoc.GetElementsByTagName("ZPos");
            XmlNodeList XPosSecondaryList = xmlDoc.GetElementsByTagName("XPosSecondary");
            XmlNodeList YPosSecondaryList = xmlDoc.GetElementsByTagName("YPosSecondary");
            XmlNodeList ZPosSecondaryList = xmlDoc.GetElementsByTagName("ZPosSecondary");
            XmlNodeList gpsPosList = xmlDoc.GetElementsByTagName("gpsPosition");
            try
            {


                for (int i = 0; i < IDlist.Count; i++)
                {
                    var newNode = new SensorNetwork.Node(Int32.Parse(IDlist[i].InnerText), Int32.Parse(SensorIDList[i].InnerText))
                                      {
                                          XPos = Double.Parse(XPosList[i].InnerText, CultureInfo.InvariantCulture),
                                          YPos = Double.Parse(YPosList[i].InnerText, CultureInfo.InvariantCulture),
                                          ZPos = Double.Parse(ZPosList[i].InnerText, CultureInfo.InvariantCulture),
                                          XPosSecondary = Double.Parse(XPosSecondaryList[i].InnerText, CultureInfo.InvariantCulture),
                                          YPosSecondary = Double.Parse(YPosSecondaryList[i].InnerText, CultureInfo.InvariantCulture),
                                          ZPosSecondary = Double.Parse(ZPosSecondaryList[i].InnerText, CultureInfo.InvariantCulture),
                                          gpsPosition = gpsPosList[i].InnerText
                                      };
                    _nodeList.Add(newNode);
                }
            }
            catch (Exception except)
            {
                Console.WriteLine(except);
            }
            
            return _nodeList;
        }


    }
}
