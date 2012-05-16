using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;

namespace Visualization
{
    public partial class Visualize : Form
    {
        public Visualize()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _nodeList = new List<Point>();
            HttpGetNodeCollection(URL.Text,_nodeList);

            foreach (var point in _nodeList)
            {
                DrawPoint(point);
            }

        }

        public List<Point> HttpGetNodeCollection(string URI, List<Point> _nodeList)
        {
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
                    Double.TryParse(XPosList[i].InnerText,NumberStyles.Any, CultureInfo.InvariantCulture,out XPos);
                    Double.TryParse(YPosList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out YPos);
                    Double.TryParse(ZPosList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out ZPos);
                    Double.TryParse(XPosSecondaryList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out XPosSecondary);
                    Double.TryParse(YPosSecondaryList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out YPosSecondary);
                    Double.TryParse(ZPosSecondaryList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out ZPosSecondary);

                    Point newNode = new Point(ID, networkID,networkIDSecondary, XPos, YPos,XPosSecondary, YPosSecondary);
                    _nodeList.Add(newNode);
                }
            }
            catch(Exception exp)
            {
            }

            return _nodeList;
        }
        public void DrawPoint(Point p)
        {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle((int)p.X*10, (int)p.Y*10, 10, 10);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            
            graphics.FillEllipse(Brushes.Blue,(int)p.X*10,(int)p.Y*10,10,10);


        }
    }





    public class Point
    {
        public double X;
        public double Y;
        public double Xsec;
        public double Ysec;
        public int ID;
        public int NetworkID;
        public int NetworkIDsec;

        public Point(int id, int networkId, int networkIdSec, double Xpos, double Ypos, double XposSecondary, double YposSecondary)
        {
            ID = id;
            NetworkID = networkId;
            NetworkIDsec = networkIdSec;
            X = Xpos+10;
            Y = Ypos+10;
            Xsec = XposSecondary;
            Ysec = YposSecondary;
           
        }
    }
}
