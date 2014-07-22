using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using log4net;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Config
{
    public struct GraphPaneDefault
    {
        public Color FillColor;
        public Color BorderColor;
        public int BorderWidth;
    }
    public struct ChartDefault
    {
        public Color FillColor;
        public Color BorderColor;
        public int BorderWidth;
    }
    public struct AxisDefault
    {
        public Color BorderColor;
        public int BorderWidth;
        public Color GridColor;
    }
    public struct GuideLineDefault
    {
        public Color Color;
    }
    public class ZedGraphConfig
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ZedGraphConfig.config" );
        private readonly XmlDocument doc = new XmlDocument();

        public GraphPaneDefault GraphPane;
        public ChartDefault Chart;
        public AxisDefault Axis;
        public GuideLineDefault GuideLine;

        public ZedGraphConfig()
        {
            this.GraphPane = new GraphPaneDefault();
            this.Chart = new ChartDefault();
            this.Axis = new AxisDefault();
            this.GuideLine = new GuideLineDefault();


            try
            {
                doc.Load(xmlPath);
                if(doc.DocumentElement != null)
                {
                    XmlNode node;
                    XmlElement element = doc.DocumentElement;
                    //GraphPane
                    node = element.SelectSingleNode("GraphPane/FillColor");
                    this.GraphPane.FillColor = StringUtil.StringToColor(node.Value,Color.Black);
                    
                    node = element.SelectSingleNode("GraphPane/BorderColor");
                    this.GraphPane.BorderColor = StringUtil.StringToColor(node.Value, Color.Black);

                    node = element.SelectSingleNode("GraphPane/BorderWidth");
                    this.GraphPane.BorderWidth = int.Parse(node.Value);

                    //Chart
                    node = element.SelectSingleNode("Chart/FillColor");
                    this.Chart.FillColor = StringUtil.StringToColor(node.Value, Color.Black);

                    node = element.SelectSingleNode("Chart/BorderColor");
                    this.Chart.BorderColor = StringUtil.StringToColor(node.Value, Color.Black);

                    node = element.SelectSingleNode("Chart/BorderWidth");
                    this.Chart.BorderWidth = int.Parse(node.Value);

                    //Axis
                    node = element.SelectSingleNode("Axis/BorderColor");
                    this.Axis.BorderColor = StringUtil.StringToColor(node.Value, Color.Black);

                    node = element.SelectSingleNode("Axis/GridColor");
                    this.Axis.GridColor = StringUtil.StringToColor(node.Value, Color.Black);

                    node = element.SelectSingleNode("Axis/BorderWidth");
                    this.Axis.BorderWidth = int.Parse(node.Value);

                    //GuideLine
                    node = element.SelectSingleNode("GuideLine/Color");
                    this.GuideLine.Color = StringUtil.StringToColor(node.Value, Color.Black);
                    
                }
                
            }
            catch
            {
                Logger.Error("找不到 ZedGraph.Config 文件：" + xmlPath);
            }
        }
    }
}
