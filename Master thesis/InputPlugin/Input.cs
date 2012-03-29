using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.ComponentModel.Composition;
using System.Xml;
using PlaceHolder;

namespace InputPlugin
{

    [Export(typeof(IGetNodes))]
    [ExportMetadata("MethodName", '2')]
    public class SensorNetworkRetreive : IGetNodes
    {
        Settings settings = new Settings();
        public List<List<Node>> GetNodes(List<List<Node>> nodeListCollection)
        {
            string[] networkPaths = settings.ReturnSensorNetworks();

            foreach (var uri in networkPaths)
            {
                List<Node> tempCollection = HttpGetNodeCollection(uri);
                AddNodes(ref nodeListCollection, tempCollection);
            }

            return nodeListCollection;
        }

        public List<Node> HttpGetNodeCollection(string URI)
        {
            var _nodeList = new List<Node>();

            WebRequest request = WebRequest.Create(URI);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            var stream = new StreamReader(response.GetResponseStream());

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(stream.ReadToEnd());


            //parsing XML response into node objects
            XmlNodeList IDlist = xmlDoc.GetElementsByTagName("ID");
            XmlNodeList SecondarySensorIDList = xmlDoc.GetElementsByTagName("SecondarySensorNetworkID");
            XmlNodeList SensorIDList = xmlDoc.GetElementsByTagName("SensorNetworkID");
            XmlNodeList XPosList = xmlDoc.GetElementsByTagName("XPos");
            XmlNodeList YPosList = xmlDoc.GetElementsByTagName("YPos");
            XmlNodeList ZPosList = xmlDoc.GetElementsByTagName("ZPos");
            XmlNodeList XPosSecondaryList = xmlDoc.GetElementsByTagName("XPosSecondary");
            XmlNodeList YPosSecondaryList = xmlDoc.GetElementsByTagName("YPosSecondary");
            XmlNodeList ZPosSecondaryList = xmlDoc.GetElementsByTagName("ZPosSecondary");
            XmlNodeList gpsPosList = xmlDoc.GetElementsByTagName("gpsPosition");

            double XPos, YPos, ZPos, XPosSecondary, YPosSecondary, ZPosSecondary;

            string gpsPosition;
            int networkID, networkIDSecondary, ID;
            for (int i = 0; i < IDlist.Count; i++)
            {
                Int32.TryParse(IDlist[i].InnerText, out ID);
                Int32.TryParse(SensorIDList[i].InnerText, out networkID);
                Int32.TryParse(SecondarySensorIDList[i].InnerText, out networkIDSecondary);
                Double.TryParse(XPosList[i].InnerText, out XPos);
                Double.TryParse(YPosList[i].InnerText, out YPos);
                Double.TryParse(ZPosList[i].InnerText, out ZPos);
                Double.TryParse(XPosSecondaryList[i].InnerText, out XPosSecondary);
                Double.TryParse(YPosSecondaryList[i].InnerText, out YPosSecondary);
                Double.TryParse(ZPosSecondaryList[i].InnerText, out ZPosSecondary);
                gpsPosition = gpsPosList[i].InnerText;
                Node newNode = new Node(ID, networkID, XPos, YPos, ZPos, gpsPosition, XPosSecondary, YPosSecondary,
                                        ZPosSecondary, networkIDSecondary);
                _nodeList.Add(newNode);
            }

            return _nodeList;
        }

        public void AddNodes(ref List<List<Node>> nodeListCollection, List<Node> nodeList)
    {
            foreach (var node in nodeList)
            {
                nodeListCollection[0].Add(node);
            }
        
    }

    }
}
