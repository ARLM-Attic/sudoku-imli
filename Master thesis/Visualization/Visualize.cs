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
        public int Magnify = 6; //Magnifing results
        public int Xoffset = 500;//800;
        public int Yoffset = 300;//500;
        public string IDs;
        public string X;
        public string Y;
        public string xSec;
        public string ySec;
        public string networkID;
        public string gps;
        public int Additive = 1;
        public static System.Drawing.Graphics graphics;

        public Visualize()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            var _nodeList = new List<Point>();
            HttpGetNodeCollection(URL.Text, _nodeList);
            var corners1 = new List<Point>();
            var corners2 = new List<Point>();
            var corners3 = new List<Point>();
            var corners4 = new List<Point>();

            foreach (var point in _nodeList)
            {
                if (point.ID < 0 && point.NetworkID == 1) corners1.Add(point);
                else if (point.ID < 0 && point.NetworkID == 2) corners2.Add(point);
                else if (point.ID < 0 && point.NetworkID == 3) corners3.Add(point);
                else if (point.ID < 0 && point.NetworkID == 4) corners4.Add(point);

                else DrawPoint(point);
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt", true);

            file.WriteLine(IDs);
            file.WriteLine(networkID);
            file.WriteLine(X);
            file.WriteLine(Y);
            file.WriteLine(xSec);
            file.WriteLine(ySec);
            file.WriteLine(gps);
            file.Close();

            if(corners1.Count >0)
            DrawSquare(corners1);
            
            if(corners2.Count > 0)
            DrawSquare(corners2);

            if(corners3.Count > 0)
            DrawSquare(corners3);

            if(corners4.Count > 0)
            DrawSquare(corners4);


        }

        public void DrawPoint(Point p)
        {
            int x, y;
            IDs += p.ID + ";";
            X += p.X + ";";
            Y += p.Y + ";";
            xSec += p.Xsec+";";
            ySec += p.Ysec + ";";
            networkID += p.NetworkID + ";";
            gps += p.gps + ";";

            if (p.NetworkID == 1)
            {
                x = (int)Math.Round(p.X);
                y = (int)Math.Round(p.Y);
            }
            else
            {
                x = (int)Math.Round(p.Xsec);
                y = (int)Math.Round(p.Ysec);
            }
            /*
            x = (int)p.X;
            y = (int)p.Y;
            */
            x = x * Magnify + Xoffset;
            x -= Magnify/4;
            y = y * Magnify + Yoffset;
            y -= Magnify/4;

            Rectangle rectangle = new System.Drawing.Rectangle(x, y, Magnify / 2, Magnify / 2);

            if (p.NetworkID == 1)
            {
                graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
                graphics.FillEllipse(Brushes.Black, x, y, Magnify / 2, Magnify / 2);
                graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            }
            else if (p.NetworkID == 2)
            {
                graphics.DrawEllipse(System.Drawing.Pens.Blue, rectangle);
                graphics.FillEllipse(Brushes.Blue, x, y, Magnify / 2, Magnify / 2);
                graphics.DrawEllipse(System.Drawing.Pens.Blue, rectangle);
            }
            else if (p.NetworkID == 3)
            {
                graphics.DrawEllipse(System.Drawing.Pens.Red, rectangle);
                graphics.FillEllipse(Brushes.Red, x, y, Magnify / 2, Magnify / 2);
                graphics.DrawEllipse(System.Drawing.Pens.Red, rectangle);
            }
            else if (p.NetworkID == 4)
            {
                graphics.DrawEllipse(System.Drawing.Pens.Green, rectangle);
                graphics.FillEllipse(Brushes.Green, x, y, Magnify / 2, Magnify / 2);
                graphics.DrawEllipse(System.Drawing.Pens.Green, rectangle);
            }


            Font drawFont = new Font("Arial", Magnify+5);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            string temp = Math.Round(p.X,0) + ";"+Math.Round(p.Y,0);
            graphics.DrawString(temp, drawFont, drawBrush, x + 10, y - 2);
            graphics.DrawString("X      Y", drawFont, drawBrush, 100, 100);

        }


        public void DrawSquare(List<Point> corners)
        {
            int size = 0;
            int[] firstCorner = new int[2];
            int[] secondCorner = new int[2];
            int[] thirdCorner = new int[2];
            int[] fourthCorner = new int[2];
            int x, y, xsec, ysec;
            xsec = 0;
            ysec = 0;
            foreach (var corner in corners)
            {
                if (corner.NetworkID == 1)
                {
                    x = (int)Math.Round(corner.X);
                    y = (int)Math.Round(corner.Y);
                    xsec = (int)Math.Round(corner.X);
                    ysec = (int)Math.Round(corner.Y);
                }
                else
                {
                    x = (int)Math.Round(corner.Xsec);
                    y = (int)Math.Round(corner.Ysec);
                    xsec = (int)Math.Round(corner.X);
                    ysec = (int)Math.Round(corner.Y);
                }

                if (corner.X == 0 && corner.Y  == 0)
                {
                    firstCorner[0] = x * Magnify + Xoffset;
                    firstCorner[1] = y * Magnify + Yoffset;
                }
                if (corner.X == 0 && corner.Y  > 0)
                {
                    secondCorner[0] = x * Magnify + Xoffset;
                    secondCorner[1] = y * Magnify + Yoffset;
                }
                if (corner.X > 0 && corner.Y  == 0)
                {
                    thirdCorner[0] = x * Magnify + Xoffset;
                    thirdCorner[1] = y * Magnify + Yoffset;
                }
                if (corner.X > 0 && corner.Y  > 0)
                {
                    fourthCorner[0] = x * Magnify + Xoffset;
                    fourthCorner[1] = y * Magnify + Yoffset;
                }


            }
            System.Drawing.Pen pen;
            pen = new System.Drawing.Pen(System.Drawing.Color.Black);
            if (corners.Count > 0)
            {
                if (corners[0].NetworkID == 2)
                    pen = new System.Drawing.Pen(System.Drawing.Color.Blue);
                else if (corners[0].NetworkID == 3)
                    pen = new System.Drawing.Pen(System.Drawing.Color.Red);
                else if (corners[0].NetworkID == 4)
                    pen = new System.Drawing.Pen(System.Drawing.Color.Green);
            }


            graphics.DrawLine(pen, firstCorner[0], firstCorner[1], secondCorner[0], secondCorner[1]);
            graphics.DrawLine(pen, firstCorner[0], firstCorner[1], thirdCorner[0], thirdCorner[1]);
            graphics.DrawLine(pen, secondCorner[0], secondCorner[1], fourthCorner[0], fourthCorner[1]);
            graphics.DrawLine(pen, thirdCorner[0], thirdCorner[1], fourthCorner[0], fourthCorner[1]);

            
            Font drawFont = new Font("Arial", Magnify*2);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            graphics.DrawString("0,0", drawFont, drawBrush, firstCorner[0] + (-3*Magnify), firstCorner[1] + (-3*Magnify));
            string temp = xsec +","+ ysec;
            graphics.DrawString(temp, drawFont, drawBrush, fourthCorner[0] + 2, fourthCorner[1] + 2);



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
                    Double.TryParse(XPosList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out XPos);
                    Double.TryParse(YPosList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out YPos);
                    Double.TryParse(ZPosList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out ZPos);
                    Double.TryParse(XPosSecondaryList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out XPosSecondary);
                    Double.TryParse(YPosSecondaryList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out YPosSecondary);
                    Double.TryParse(ZPosSecondaryList[i].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out ZPosSecondary);
                    gpsPosition = gpsPosList[i].InnerText;

                    Point newNode = new Point(ID, networkID, networkIDSecondary, XPos, YPos, XPosSecondary, YPosSecondary,gpsPosition);
                    _nodeList.Add(newNode);
                }
            }
            catch (Exception exp)
            {
            }

            return _nodeList;
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
        public string gps;

        public Point(int id, int networkId, int networkIdSec, double Xpos, double Ypos, double XposSecondary, double YposSecondary, string gpsPosition)
        {
            ID = id;
            NetworkID = networkId;
            NetworkIDsec = networkIdSec;
            X = Xpos;
            Y = Ypos;
            Xsec = XposSecondary;
            Ysec = YposSecondary;
            gps = gpsPosition;
           
        }
    }
}
