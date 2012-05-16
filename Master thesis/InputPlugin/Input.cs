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
            try
            {
                WebRequest request = WebRequest.Create(URI);
                request.Method = "GET";

                WebResponse response = request.GetResponse();
                var stream = new StreamReader(response.GetResponseStream());

                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(stream.ReadToEnd());


                //parsing XML response into node objects
                XmlNodeList IDlist = xmlDoc.GetElementsByTagName("ID");
                XmlNodeList SensorIDList = xmlDoc.GetElementsByTagName("SensorNetworkID");
                XmlNodeList XPosList = xmlDoc.GetElementsByTagName("XPos");
                XmlNodeList YPosList = xmlDoc.GetElementsByTagName("YPos");
                XmlNodeList ZPosList = xmlDoc.GetElementsByTagName("ZPos");
                XmlNodeList SecondarySensorIDList = xmlDoc.GetElementsByTagName("SecondarySensorNetworkID");
                XmlNodeList XPosSecondaryList = xmlDoc.GetElementsByTagName("XPosSecondary");
                XmlNodeList YPosSecondaryList = xmlDoc.GetElementsByTagName("YPosSecondary");
                XmlNodeList ZPosSecondaryList = xmlDoc.GetElementsByTagName("ZPosSecondary");
                XmlNodeList gpsPosList = xmlDoc.GetElementsByTagName("GlobalPositionValue");
                XmlNodeList gpsTypeList = xmlDoc.GetElementsByTagName("GlobalPositionType");

                double XPos, YPos, ZPos, XPosSecondary, YPosSecondary, ZPosSecondary;

                string gpsPosition, gpsType;
                int networkID, networkIDSecondary, ID;
                for (int i = 0; i < IDlist.Count; i++)
                {
                    Int32.TryParse(IDlist[i].InnerText, out ID);
                    Int32.TryParse(SensorIDList[i].InnerText, out networkID);
                    Int32.TryParse(SecondarySensorIDList[i].InnerText, out networkIDSecondary);
                    Double.TryParse(XPosList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out XPos);
                    Double.TryParse(YPosList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out YPos);
                    Double.TryParse(ZPosList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out ZPos);
                    Double.TryParse(XPosSecondaryList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out XPosSecondary);
                    Double.TryParse(YPosSecondaryList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out YPosSecondary);
                    Double.TryParse(ZPosSecondaryList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out ZPosSecondary);
                    gpsPosition = gpsPosList[i].InnerText;
                    gpsType = gpsTypeList[i].InnerText;

                    Node newNode = new Node(ID, networkID, XPos, YPos, ZPos, gpsPosition,gpsType, XPosSecondary, YPosSecondary,
                                            ZPosSecondary, networkIDSecondary);
                    _nodeList.Add(newNode);
                }
            }catch(WebException exp)
            {
                var log = new Log(exp.ToString(), settings.GetLogPath());
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

    
    /// <summary>
    /// Class that connecting to selected sensor network, and updates value of one node
    /// </summary>
    [Export(typeof(IGetNode))]
    [ExportMetadata("MethodName", '3')]
    public class UpdateNode : IGetNode
    {
        Settings settings = new Settings();
        public Node GetNode(Node tempNode, int ID, int SensorNetworkID)
        {
            string[] networkPaths = settings.ReturnSensorNetworks();

            foreach (var networkPath in networkPaths)
            {
                if (networkPath.Contains(SensorNetworkID.ToString()))
                {
                   tempNode = nodeUpdate(networkPath, ID,tempNode);
                   break;
                }
            }

            return tempNode;
        }

    private Node nodeUpdate(string networkPath, int id, Node tempNode)
    {
        try
        {
            string URI = networkPath + id.ToString();
            WebRequest request = WebRequest.Create(URI);
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            var stream = new StreamReader(response.GetResponseStream());

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(stream.ReadToEnd());


            //parsing XML response into node objects
            XmlNodeList XPosList = xmlDoc.GetElementsByTagName("XPos");
            XmlNodeList YPosList = xmlDoc.GetElementsByTagName("YPos");
            XmlNodeList ZPosList = xmlDoc.GetElementsByTagName("ZPos");
            XmlNodeList SecondarySensorIDList = xmlDoc.GetElementsByTagName("SecondarySensorNetworkID");
            XmlNodeList XPosSecondaryList = xmlDoc.GetElementsByTagName("XPosSecondary");
            XmlNodeList YPosSecondaryList = xmlDoc.GetElementsByTagName("YPosSecondary");
            XmlNodeList ZPosSecondaryList = xmlDoc.GetElementsByTagName("ZPosSecondary");
            XmlNodeList gpsPosList = xmlDoc.GetElementsByTagName("GlobalPositionValue");
            XmlNodeList gpsTypeList = xmlDoc.GetElementsByTagName("GlobalPositionType");

            double XPos, YPos, ZPos, XPosSecondary, YPosSecondary, ZPosSecondary;

            string gpsPosition, gpsType;
            int networkID, networkIDSecondary, ID;
  
                Int32.TryParse(SecondarySensorIDList[0].InnerText, out networkIDSecondary);
                Double.TryParse(XPosList[0].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out XPos);
                Double.TryParse(YPosList[0].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out YPos);
                Double.TryParse(ZPosList[0].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out ZPos);
                Double.TryParse(XPosSecondaryList[0].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out XPosSecondary);
                Double.TryParse(YPosSecondaryList[0].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out YPosSecondary);
                Double.TryParse(ZPosSecondaryList[0].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out ZPosSecondary);
                gpsPosition = gpsPosList[0].InnerText;
                gpsType = gpsTypeList[0].InnerText;

                tempNode.XPos = XPos;
                tempNode.YPos = YPos;
                tempNode.ZPos = ZPos;
                if (XPosSecondary != 0) tempNode.XPosSecondary = XPosSecondary;
                if (YPosSecondary != 0) tempNode.YPosSecondary = YPosSecondary;
                if (ZPosSecondary != 0) tempNode.ZPosSecondary = ZPosSecondary;
                if (gpsPosition != "") tempNode.GlobalPositionValue = gpsPosition;
                if (gpsType != "") tempNode.GLobalPositionType = gpsType;


            
        }
        catch (WebException exp)
        {
            var log = new Log(exp.ToString(), settings.GetLogPath());
        }
        return tempNode;
    }

    }
}
