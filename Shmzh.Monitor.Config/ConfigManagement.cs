using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Reflection;
using System.IO;
using Shmzh.Monitor.Gadget;
using System.Drawing;

namespace Shmzh.Monitor.Config
{
    /// <summary>
    /// 监控窗体配置管理类。
    /// </summary>
    public class ConfigManagement
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 从指定的配置文件中获取配置信息，生成一个监控配置信息实体对象。
        /// </summary>
        /// <param name="configFilePath">监控配置文件路径。</param>
        /// <returns>监控配置信息实体对象。</returns>
        public static MonitorConfig Load(string configFilePath)
        {
            var xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\" + configFilePath);
            var doc = new XmlDocument();
            try
            {
                Trace.WriteLine(xmlPath);
                doc.Load(xmlPath);
            }
            catch
            {
                Logger.Error("找不到 XML 文件：" + xmlPath);
                return null;
            }
            var config = new MonitorConfig();
            #region BasePoint

            var nodeList = doc.DocumentElement.SelectNodes("BasePoint/Item");
            if (nodeList != null && nodeList.Count > 0)
            {
                LoadBasePoint(nodeList, config);
            }
            #endregion
            #region BackGroundInfo
            var sw = new Stopwatch();
            sw.Start();
            //BackGroundInfo.
            nodeList = doc.DocumentElement.SelectNodes("BackGround/Item");
            if (nodeList != null && nodeList.Count > 0)
            {
                var node = nodeList[0];
                var backInfo = new BackGroundInfo {BackColor = GetColor(node.Attributes.GetNamedItem("Color").Value), Src = node.Attributes.GetNamedItem("Src").Value, IsTiled = Convert.ToBoolean(node.Attributes.GetNamedItem("IsTiled").Value)};
                config.FormBackGround = backInfo;
            }
            sw.Stop();
            Trace.WriteLine(string.Format("BackGround/Item Spend {0}ms",sw.ElapsedMilliseconds));
            #endregion

            #region ClockInfo
            //ClockInfo
            var tempNode = doc.DocumentElement.SelectSingleNode("Clock");
            if (tempNode != null) LoadClock(tempNode, config);
            #endregion

            #region ImageInfo
            sw.Reset();
            sw.Start();
            //ImageInfo
            nodeList = doc.DocumentElement.SelectNodes("Image/Item");
            if (nodeList != null) LoadImage(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("Image/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            #region TagImageInfo
            sw.Reset();
            sw.Start();
            //TagImageInfo
            nodeList = doc.DocumentElement.SelectNodes("TagImage/Item");
            if (nodeList != null && nodeList.Count> 0) 
                LoadTagImage(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("TagImage/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            #region LineInfo
            sw.Reset();
            sw.Start();
            //LineInfo
            nodeList = doc.DocumentElement.SelectNodes("Line/Item");
            if (nodeList != null && nodeList.Count > 0) 
                LoadLine(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("Line/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            #region TextInfo
            sw.Reset();
            sw.Start();
            //TextInfo
            nodeList = doc.DocumentElement.SelectNodes("Text/Item");
            if (nodeList != null && nodeList.Count> 0) 
                LoadText(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("Text/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            #region TagInfo
            sw.Reset();
            sw.Start();
            //TagInfo
            nodeList = doc.DocumentElement.SelectNodes("Tag/Item");
            if (nodeList != null) LoadTag(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("Tag/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            #region DeviceInfo
            sw.Reset();
            sw.Start();
            //DeviceInfo
            nodeList = doc.DocumentElement.SelectNodes("Device/Item");
            if (nodeList != null) LoadDevice(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("Device/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            #region PieInfo
            sw.Reset();
            sw.Start();
            //PieInfo
            nodeList = doc.DocumentElement.SelectNodes("Pie/Item");
            if (nodeList != null) LoadPie(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("Pie/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            #region PoolInfo
            sw.Reset();
            sw.Start();
            //PoolInfo
            nodeList = doc.DocumentElement.SelectNodes("Pool/Item");
            if (nodeList != null) LoadPool(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("Pool/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            #region LitePoolInfo
            sw.Reset();
            sw.Start();
            //LitePoolInfo
            nodeList = doc.DocumentElement.SelectNodes("LitePool/Item");
            if (nodeList != null) LoadLitePool(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("LitePool/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            #region GaugeInfo
            sw.Reset();
            sw.Start();
            //GaugeInfo
            nodeList = doc.DocumentElement.SelectNodes("Gauge/Item");
            if(nodeList != null) LoadGauge(nodeList, config);
            sw.Stop();
            Trace.WriteLine(string.Format("Gauge/Item Spend {0}ms on {1} item",sw.ElapsedMilliseconds,nodeList==null?0:nodeList.Count));
            #endregion

            return config;
        }

        private static void LoadClock(XmlNode tempNode, MonitorConfig config)
        {
            Boolean isVisible = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("Visible").Value);
            if (!isVisible) return;
            ClockInfo clockInfo = new ClockInfo();
            clockInfo.X = Convert.ToInt32(tempNode.Attributes.GetNamedItem("X").Value);
            clockInfo.Y = Convert.ToInt32(tempNode.Attributes.GetNamedItem("Y").Value);
            clockInfo.StringFormat = tempNode.Attributes.GetNamedItem("StringFormat").Value;
            clockInfo.TimeFormat = tempNode.Attributes.GetNamedItem("TimeFormat").Value;
            clockInfo.FontFamily = tempNode.Attributes.GetNamedItem("Font").Value;
            clockInfo.FontSize = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FontSize").Value);
            clockInfo.IsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
            clockInfo.IsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
            clockInfo.ForeColor = GetColor(tempNode.Attributes.GetNamedItem("Color").Value);
            clockInfo.IsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
            clockInfo.BackColor = GetColor(tempNode.Attributes.GetNamedItem("BackColor").Value);
            config.Clock = clockInfo;
        }

        private static void LoadImage(XmlNodeList nodeList, MonitorConfig config)
        {
            ImageInfo imgInfo;
            foreach (XmlNode node in nodeList)
            {
                imgInfo = new ImageInfo();

                imgInfo.Src = node.Attributes.GetNamedItem("Src").Value;
                imgInfo.HoverSrc = node.Attributes.GetNamedItem("HoverSrc").Value;
                imgInfo.TriggerEvent = node.Attributes.GetNamedItem("TriggerEvent").Value;
                imgInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                imgInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                imgInfo.Width = Convert.ToInt32(node.Attributes.GetNamedItem("Width").Value);
                imgInfo.Height = Convert.ToInt32(node.Attributes.GetNamedItem("Height").Value);
                var tempNode = node.Attributes.GetNamedItem("BorderColor");
                imgInfo.BorderColor = tempNode == null ? Color.Transparent : GetColor(tempNode.Value);
                tempNode = node.Attributes.GetNamedItem("BorderWidth");
                imgInfo.BorderWidth = tempNode == null ? 0 : Convert.ToInt32(tempNode.Value);
                tempNode = node.Attributes.GetNamedItem("IsHoverEffect");
                imgInfo.IsHoverEffect = tempNode == null ? false : Convert.ToBoolean(tempNode.Value);
                if (imgInfo.IsHoverEffect)
                {
                    config.HoverList.Add(imgInfo);
                }

                if (!String.IsNullOrEmpty(imgInfo.TriggerEvent))
                {
                    ITriggerEvent triggerEvent = imgInfo;
                    triggerEvent.Tag = imgInfo;
                    AddTriggerEvent(triggerEvent, config);
                }
                config.ImageList.Add(imgInfo);
            }
        }

        private static void LoadBasePoint(XmlNodeList nodeList, MonitorConfig config)
        {
            foreach (XmlNode node in nodeList)
            {
                var basePointInfo = new BasePointInfo();
                basePointInfo.Name = node.Attributes.GetNamedItem("Name").Value;
                basePointInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                basePointInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                config.BasePointList.Add(basePointInfo);
            }
        }
        private static void LoadTagImage(XmlNodeList nodeList, MonitorConfig config)
        {
            foreach (XmlNode node in nodeList)
            {
                var tagImageInfo = new TagImageInfo();

                tagImageInfo.SrcExp = node.Attributes.GetNamedItem("Src").Value;
                tagImageInfo.HoverSrc = node.Attributes.GetNamedItem("HoverSrc").Value;
                tagImageInfo.TriggerEvent = node.Attributes.GetNamedItem("TriggerEvent").Value;
                tagImageInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                tagImageInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                tagImageInfo.Width = Convert.ToInt32(node.Attributes.GetNamedItem("Width").Value);
                tagImageInfo.Height = Convert.ToInt32(node.Attributes.GetNamedItem("Height").Value);
                var tempNode = node.Attributes.GetNamedItem("BorderColor");
                tagImageInfo.BorderColorExp = tempNode == null ? "" : tempNode.Value;
                tempNode = node.Attributes.GetNamedItem("BorderWidth");
                tagImageInfo.BorderWidth = tempNode == null ? 0 : Convert.ToInt32(tempNode.Value);
                tempNode = node.Attributes.GetNamedItem("IsHoverEffect");
                tagImageInfo.IsHoverEffect = tempNode == null ? false : Convert.ToBoolean(tempNode.Value);
                tagImageInfo.TagId = node.Attributes.GetNamedItem("TagId").Value;
                tagImageInfo.DataType = node.Attributes.GetNamedItem("DataType").Value;
                if (tagImageInfo.IsHoverEffect)
                {
                    config.HoverList.Add(tagImageInfo);
                }

                if (!String.IsNullOrEmpty(tagImageInfo.TriggerEvent))
                {
                    ITriggerEvent triggerEvent = tagImageInfo;
                    triggerEvent.Tag = tagImageInfo;
                    AddTriggerEvent(triggerEvent, config);
                }
                config.TagImageList.Add(tagImageInfo);
            }
        }

        private static void LoadLine(XmlNodeList nodeList, MonitorConfig config)
        {
            LineInfo lineInfo;
            XmlNode tempNode;
            foreach (XmlNode node in nodeList)
            {
                lineInfo = new LineInfo();

                lineInfo.StartArrow = Convert.ToBoolean(node.Attributes.GetNamedItem("StartArrow").Value);
                lineInfo.EndArrow = Convert.ToBoolean(node.Attributes.GetNamedItem("EndArrow").Value);
                lineInfo.ColorExp = node.Attributes.GetNamedItem("Color").Value;
                lineInfo.WidthExp = node.Attributes.GetNamedItem("Width").Value;
                lineInfo.LineStyleExp = node.Attributes.GetNamedItem("LineStyle").Value;
                lineInfo.TagId = node.Attributes.GetNamedItem("TagId").Value;
                lineInfo.DataType = node.Attributes.GetNamedItem("DataType").Value;
                tempNode = node.Attributes.GetNamedItem("ArrowFactor");
                if (tempNode != null && tempNode.Value.Length > 0) lineInfo.ArrowFactor = Convert.ToSingle(tempNode.Value);

                XmlNode pathNode = node.SelectSingleNode("Points");
                if(pathNode.ChildNodes.Count > 0)
                {
                    tempNode = pathNode.FirstChild;
                    List<Point> ptList = new List<Point>(); 
                    while(tempNode != null)
                    {
                        if (tempNode.Name == "Point")
                        {
                            ptList.Add(new Point(Convert.ToInt32(tempNode.Attributes.GetNamedItem("X").Value), Convert.ToInt32(tempNode.Attributes.GetNamedItem("Y").Value)));
                        }
                        else if (tempNode.Name == "Arc")
                        {
                            if(ptList.Count > 1)
                            {
                                lineInfo.GP.AddLines(ptList.ToArray());
                                ptList.Clear();
                            }
                            lineInfo.GP.AddArc(Convert.ToSingle(tempNode.Attributes.GetNamedItem("X").Value), Convert.ToSingle(tempNode.Attributes.GetNamedItem("Y").Value),
                                Convert.ToSingle(tempNode.Attributes.GetNamedItem("Width").Value),Convert.ToSingle(tempNode.Attributes.GetNamedItem("Height").Value),
                                Convert.ToSingle(tempNode.Attributes.GetNamedItem("StartAngle").Value), Convert.ToSingle(tempNode.Attributes.GetNamedItem("SweepAngle").Value));
                        }
                        tempNode = tempNode.NextSibling;
                    }
                    if (ptList.Count > 1)
                    {
                        lineInfo.GP.AddLines(ptList.ToArray());
                        ptList.Clear();
                    }
                }
                config.LineList.Add(lineInfo);
            }
        }

        private static void LoadText(XmlNodeList nodeList, MonitorConfig config)
        {
            LoadText(nodeList, config, null);
        }

        private static void LoadText(XmlNodeList nodeList, MonitorConfig config, HoverInfo parentNode)
        {
            foreach (XmlNode node in nodeList)
            {
                var textInfo = new TextInfo();
                if (parentNode != null)
                {
                    textInfo.ParentNode = parentNode;
                    parentNode.ChildNodes.Add(textInfo);
                }

                var text = node.Attributes.GetNamedItem("Text").Value;
                if (node.Attributes.GetNamedItem("BasePointName") != null)
                {
                    var basePointName = node.Attributes["BasePointName"].Value;
                    var basePoint =
                        config.BasePointList.Find(o => o.Name.Equals(basePointName, StringComparison.OrdinalIgnoreCase));
                    if(basePoint != null)
                        textInfo.BasePoint = basePoint;
                }
                textInfo.Text = String.Join("\n", text.Split(new[] { "\\n" }, StringSplitOptions.None));
                textInfo.FontFamily = node.Attributes.GetNamedItem("Font").Value;
                textInfo.FontSize = Convert.ToSingle(node.Attributes.GetNamedItem("FontSize").Value);
                textInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                textInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                textInfo.Width = Convert.ToInt32(node.Attributes.GetNamedItem("Width").Value);
                textInfo.Height = Convert.ToInt32(node.Attributes.GetNamedItem("Height").Value);
                textInfo.Align = GetAlignByName(node.Attributes.GetNamedItem("Align").Value);
                textInfo.TriggerEvent = node.Attributes.GetNamedItem("TriggerEvent").Value;
                textInfo.IsVertical = Convert.ToBoolean(node.Attributes.GetNamedItem("IsVertical").Value);

                var tempNode = node.SelectSingleNode("ItemStyle");
                textInfo.NormalIsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                textInfo.NormalIsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                textInfo.NormalColor = GetColor(tempNode.Attributes.GetNamedItem("Color").Value);
                textInfo.NormalIsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                textInfo.NormalBackColor = GetColor(tempNode.Attributes.GetNamedItem("BackColor").Value);

                tempNode = node.SelectSingleNode("SelectedStyle");
                textInfo.SelectedIsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                textInfo.SelectedIsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                textInfo.SelectedColor = GetColor(tempNode.Attributes.GetNamedItem("Color").Value);
                textInfo.SelectedIsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                textInfo.SelectedBackColor = GetColor(tempNode.Attributes.GetNamedItem("BackColor").Value);

                tempNode = node.SelectSingleNode("BorderStyle");
                textInfo.BorderColor = GetColor(tempNode.Attributes.GetNamedItem("Color").Value);
                textInfo.LeftWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("LeftWidth").Value);
                textInfo.RightWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("RightWidth").Value);
                textInfo.TopWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("TopWidth").Value);
                textInfo.BottomWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("BottomWidth").Value);

                textInfo.IsHoverEffect = Convert.ToBoolean(node.Attributes.GetNamedItem("IsHoverEffect").Value);
                if (textInfo.IsHoverEffect)
                {
                    config.HoverList.Add(textInfo);
                }
                if (!String.IsNullOrEmpty(textInfo.TriggerEvent))
                {
                    ITriggerEvent triggerEvent = textInfo;
                    triggerEvent.Tag = textInfo;
                    AddTriggerEvent(triggerEvent, config);
                }
                config.TextList.Add(textInfo);
            }
        }

        private static void LoadTag(XmlNodeList nodeList, MonitorConfig config)
        {
            LoadTag(nodeList, config, null);
        }

        private static void LoadTag(XmlNodeList nodeList, MonitorConfig config, HoverInfo parentNode)
        {
            TagInfo tagInfo;
            XmlNode tempNode;
            foreach (XmlNode node in nodeList)
            {
                tagInfo = new TagInfo();
                if (parentNode != null)
                {
                    tagInfo.ParentNode = parentNode;
                    parentNode.ChildNodes.Add(tagInfo);
                }
                if (node.Attributes.GetNamedItem("BasePointName") != null)
                {
                    var basePointName = node.Attributes.GetNamedItem("BasePointName").Value;
                    var basePoint =
                        config.BasePointList.Find(o => o.Name.Equals(basePointName, StringComparison.OrdinalIgnoreCase));
                    if (basePoint != null)
                        tagInfo.BasePoint = basePoint;
                }
                tempNode = node.Attributes.GetNamedItem("MonitorObj");
                if (tempNode != null) tagInfo.MonitorObj = tempNode.Value;
                tempNode = node.Attributes.GetNamedItem("TagName");
                if (tempNode != null) tagInfo.TagName = tempNode.Value;
                tagInfo.FontFamily = node.Attributes.GetNamedItem("Font").Value;
                tagInfo.FontSize = Convert.ToSingle(node.Attributes.GetNamedItem("FontSize").Value);
                tagInfo.DataType = node.Attributes.GetNamedItem("DataType").Value;
                tagInfo.TagId = node.Attributes.GetNamedItem("TagId").Value;
               
                var text = node.Attributes.GetNamedItem("StringFormat").Value;
                tagInfo.StringFormat = String.Join("\n", text.Split(new[] { "\\n" }, StringSplitOptions.None));
                tagInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                tagInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                tagInfo.Width = Convert.ToInt32(node.Attributes.GetNamedItem("Width").Value);
                tagInfo.Height = Convert.ToInt32(node.Attributes.GetNamedItem("Height").Value);
                tagInfo.Align = GetAlignByName(node.Attributes.GetNamedItem("Align").Value);
                tagInfo.TriggerEvent = node.Attributes.GetNamedItem("TriggerEvent").Value;

                tempNode = node.SelectSingleNode("ItemStyle");
                tagInfo.NormalIsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                tagInfo.NormalIsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                tagInfo.NormalColorExp = tempNode.Attributes.GetNamedItem("Color").Value;
                tagInfo.NormalIsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                tagInfo.NormalBackColor = GetColor(tempNode.Attributes.GetNamedItem("BackColor").Value);

                tempNode = node.SelectSingleNode("SelectedStyle");
                tagInfo.SelectedIsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                tagInfo.SelectedIsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                tagInfo.SelectedColorExp = tempNode.Attributes.GetNamedItem("Color").Value;
                tagInfo.SelectedIsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                tagInfo.SelectedBackColor = GetColor(tempNode.Attributes.GetNamedItem("BackColor").Value);

                tempNode = node.SelectSingleNode("BorderStyle");
                tagInfo.BorderColorExp = tempNode.Attributes.GetNamedItem("Color").Value;
                tagInfo.LeftWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("LeftWidth").Value);
                tagInfo.RightWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("RightWidth").Value);
                tagInfo.TopWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("TopWidth").Value);
                tagInfo.BottomWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("BottomWidth").Value);

                tagInfo.IsHoverEffect = Convert.ToBoolean(node.Attributes.GetNamedItem("IsHoverEffect").Value);
                if (tagInfo.IsHoverEffect)
                {
                    config.HoverList.Add(tagInfo);
                }
                if (!String.IsNullOrEmpty(tagInfo.TriggerEvent))
                {
                    ITriggerEvent triggerEvent = tagInfo;
                    triggerEvent.Tag = tagInfo;
                    AddTriggerEvent(triggerEvent, config);
                }
                config.TagList.Add(tagInfo);
            }
        }

        private static void LoadDevice(XmlNodeList nodeList, MonitorConfig config)
        {
            DeviceInfo devInfo;
            XmlNode tempNode;
            foreach (XmlNode node in nodeList)
            {
                devInfo = new DeviceInfo();

                devInfo.RunSrc = node.Attributes.GetNamedItem("RunSrc").Value;
                devInfo.StopSrc = node.Attributes.GetNamedItem("StopSrc").Value;
                devInfo.MalfunctionSrc = node.Attributes.GetNamedItem("MalfunctionSrc").Value;
                devInfo.RepairSrc = node.Attributes.GetNamedItem("RepairSrc").Value;
                var text = node.Attributes.GetNamedItem("Text").Value;
                devInfo.Text = String.Join("\n", text.Split(new[] { "\\n" }, StringSplitOptions.None));
                devInfo.FontFamily = node.Attributes.GetNamedItem("Font").Value;
                devInfo.FontSize = Convert.ToSingle(node.Attributes.GetNamedItem("FontSize").Value);
                devInfo.DataType = node.Attributes.GetNamedItem("DataType").Value;
                devInfo.DevCode = node.Attributes.GetNamedItem("DevCode").Value;
                devInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                devInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                devInfo.Width = Convert.ToInt32(node.Attributes.GetNamedItem("Width").Value);
                devInfo.Height = Convert.ToInt32(node.Attributes.GetNamedItem("Height").Value);
                devInfo.TriggerEvent = node.Attributes.GetNamedItem("TriggerEvent").Value;
                devInfo.PaddingTop = Convert.ToInt32(node.Attributes.GetNamedItem("PaddingTop").Value);
                devInfo.PaddingLeft = Convert.ToInt32(node.Attributes.GetNamedItem("PaddingLeft").Value);
                tempNode = node.Attributes.GetNamedItem("IsVertical");
                devInfo.IsVertical = (tempNode == null ? false : Convert.ToBoolean(tempNode.Value));

                tempNode = node.SelectSingleNode("ItemStyle");
                devInfo.NormalIsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                devInfo.NormalIsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                devInfo.NormalColor = GetColor(tempNode.Attributes.GetNamedItem("Color").Value);
                devInfo.NormalIsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);

                tempNode = node.SelectSingleNode("SelectedStyle");
                devInfo.SelectedIsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                devInfo.SelectedIsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                devInfo.SelectedColor = GetColor(tempNode.Attributes.GetNamedItem("Color").Value);
                devInfo.SelectedIsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);

                devInfo.IsHoverEffect = Convert.ToBoolean(node.Attributes.GetNamedItem("IsHoverEffect").Value);
                if (devInfo.IsHoverEffect)
                {
                    config.HoverList.Add(devInfo);
                }
                if (!String.IsNullOrEmpty(devInfo.TriggerEvent))
                {
                    ITriggerEvent triggerEvent = devInfo;
                    triggerEvent.Tag = devInfo;
                    AddTriggerEvent(triggerEvent, config);
                }
                config.DeviceList.Add(devInfo);

                //TextInfo
                nodeList = node.SelectNodes("Text/Item");
                if (nodeList != null) LoadText(nodeList, config, devInfo);

                //TagInfo
                nodeList = node.SelectNodes("Tag/Item");
                if (nodeList != null) LoadTag(nodeList, config, devInfo);
            }
        }

        private static void LoadPie(XmlNodeList nodeList, MonitorConfig config)
        {
            PieInfo pieInfo;
            XmlNode tempNode;
            foreach (XmlNode node in nodeList)
            {
                pieInfo = new PieInfo();
                pieInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                pieInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                pieInfo.Width = Convert.ToInt32(node.Attributes.GetNamedItem("Width").Value);
                pieInfo.Height = Convert.ToInt32(node.Attributes.GetNamedItem("Height").Value);
                
                tempNode = node.SelectSingleNode("Border");
                if (tempNode != null)
                {
                    pieInfo.Border.Color = GetColor(tempNode.Attributes.GetNamedItem("Color").Value);
                    pieInfo.Border.Visible = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("Visible").Value);
                    pieInfo.Border.Width = Convert.ToSingle(tempNode.Attributes.GetNamedItem("Width").Value);
                }

                tempNode = node.SelectSingleNode("Title");
                pieInfo.Title.Visible = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("Visible").Value);
                if (pieInfo.Title.Visible)
                {
                    pieInfo.Title.FontFamily = tempNode.Attributes.GetNamedItem("Font").Value;
                    pieInfo.Title.FontSize = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FontSize").Value);
                    pieInfo.Title.ForeColor = GetColor(tempNode.Attributes.GetNamedItem("ForeColor").Value);
                    pieInfo.Title.IsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                    pieInfo.Title.IsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                    pieInfo.Title.IsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);

                    var text = tempNode.InnerText;
                    pieInfo.Title.Text = String.Join("\n", text.Split(new[] { "\\n" }, StringSplitOptions.None));
                }

                tempNode = node.SelectSingleNode("Legend");
                pieInfo.Legend.Visible = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("Visible").Value);
                if (pieInfo.Legend.Visible)
                {
                    pieInfo.Legend.FontFamily = tempNode.Attributes.GetNamedItem("Font").Value;
                    pieInfo.Legend.X = Convert.ToSingle(tempNode.Attributes.GetNamedItem("X").Value);
                    pieInfo.Legend.Y = Convert.ToSingle(tempNode.Attributes.GetNamedItem("Y").Value);
                    pieInfo.Legend.FontSize = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FontSize").Value);
                    pieInfo.Legend.ForeColor = GetColor(tempNode.Attributes.GetNamedItem("ForeColor").Value);
                    pieInfo.Legend.IsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                    pieInfo.Legend.IsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                    pieInfo.Legend.IsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                    pieInfo.Legend.IsHStack = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsHStack").Value);
                    pieInfo.Legend.AlignH = tempNode.Attributes.GetNamedItem("AlignH").Value;
                    pieInfo.Legend.AlignV = tempNode.Attributes.GetNamedItem("AlignV").Value;
                }

                XmlNodeList tempNodeList = node.SelectNodes("Tag");
                if (tempNodeList != null)
                {
                    foreach (XmlNode tempNode2 in tempNodeList)
                    {
                        pieInfo.ItemList.Add(new PieInfo.ItemInfo
                                                 {
                                                    ForeColor = GetColor(tempNode2.Attributes.GetNamedItem("ForeColor").Value),
                                                    FontFamily = tempNode2.Attributes.GetNamedItem("Font").Value,
                                                    FontSize = Convert.ToSingle(tempNode2.Attributes.GetNamedItem("FontSize").Value),
                                                    IsItalic = Convert.ToBoolean(tempNode2.Attributes.GetNamedItem("IsItalic").Value),
                                                    IsBold = Convert.ToBoolean(tempNode2.Attributes.GetNamedItem("IsBold").Value),
                                                    IsUnderLine = Convert.ToBoolean(tempNode2.Attributes.GetNamedItem("IsUnderLine").Value),

                                                    Label = tempNode2.InnerText,
                                                    TagId = tempNode2.Attributes.GetNamedItem("TagId").Value,
                                                    DataType = tempNode2.Attributes.GetNamedItem("DataType").Value,
                                                    Color1 = GetColor(tempNode2.Attributes.GetNamedItem("Color1").Value),
                                                    Color2 = GetColor(tempNode2.Attributes.GetNamedItem("Color2").Value),                            
                                                    FillAngle = Convert.ToSingle(tempNode2.Attributes.GetNamedItem("FillAngle").Value),
                                                    Displacement = Convert.ToSingle(tempNode2.Attributes.GetNamedItem("Displacement").Value),
                                                    LabelType = tempNode2.Attributes.GetNamedItem("LabelType").Value
                        });
                    }
                }

                tempNode = node.SelectSingleNode("PaneFill");
                pieInfo.PaneFillInfo.FillAngle = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FillAngle").Value);
                tempNodeList = tempNode.SelectNodes("Color");
                if (tempNodeList != null)
                {
                    Color[] colors = new Color[tempNodeList.Count];
                    for (int i = 0; i < tempNodeList.Count; i++)
                    {
                        colors[i] = GetColor(tempNodeList[i].InnerText);
                    }
                    pieInfo.PaneFillInfo.Colors = colors;
                }

                tempNode = node.SelectSingleNode("ChartFill");
                pieInfo.ChartFillInfo.FillAngle = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FillAngle").Value);
                tempNodeList = tempNode.SelectNodes("Color");
                if (tempNodeList != null)
                {
                    Color[] colors = new Color[tempNodeList.Count];
                    for (int i = 0; i < tempNodeList.Count; i++)
                    {
                        colors[i] = GetColor(tempNodeList[i].InnerText);
                    }
                    pieInfo.ChartFillInfo.Colors = colors;
                }

                config.PieList.Add(pieInfo);
            }
        }

        private static void LoadPool(XmlNodeList nodeList, MonitorConfig config)
        {
            PoolInfo poolInfo;
            XmlNode tempNode;
            foreach (XmlNode node in nodeList)
            {
                poolInfo = new PoolInfo();

                tempNode = node.Attributes.GetNamedItem("MonitorObj");
                if (tempNode != null) poolInfo.MonitorObj = tempNode.Value;
                poolInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                poolInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                poolInfo.Width = Convert.ToInt32(node.Attributes.GetNamedItem("Width").Value);
                poolInfo.Height = Convert.ToInt32(node.Attributes.GetNamedItem("Height").Value);
                poolInfo.FontFamily = node.Attributes.GetNamedItem("Font").Value;
                poolInfo.UnitExp = node.Attributes.GetNamedItem("Unit").Value;
                poolInfo.PieceScaleExp = node.Attributes.GetNamedItem("PieceScale").Value;
                poolInfo.DataType = node.Attributes.GetNamedItem("DataType").Value;
                poolInfo.TagId = node.Attributes.GetNamedItem("TagId").Value;
                poolInfo.MaxScaleExp = node.Attributes.GetNamedItem("MaxScale").Value;
                poolInfo.TriggerEvent = node.Attributes.GetNamedItem("TriggerEvent").Value;

                tempNode = node.SelectSingleNode("PoolStyle");
                poolInfo.PoolStyle.BorderWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("BorderWidth").Value);
                poolInfo.PoolStyle.BorderColor = GetColor(tempNode.Attributes.GetNamedItem("BorderColor").Value);
                poolInfo.PoolStyle.FillColor1 = GetColor(tempNode.Attributes.GetNamedItem("FillColor1").Value);
                poolInfo.PoolStyle.FillColor2 = GetColor(tempNode.Attributes.GetNamedItem("FillColor2").Value);
                poolInfo.PoolStyle.BackColor = GetColor(tempNode.Attributes.GetNamedItem("BackColor").Value);
                XmlNode tempNode2 = tempNode.Attributes.GetNamedItem("FillImage");
                if (tempNode2 != null) poolInfo.PoolStyle.FillImageSrc = tempNode2.Value;

                tempNode = node.SelectSingleNode("ValueStyle");
                poolInfo.ValueStyle.FontSize = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FontSize").Value);
                poolInfo.ValueStyle.IsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                poolInfo.ValueStyle.IsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                poolInfo.ValueStyle.ForeColorExp = tempNode.Attributes.GetNamedItem("Color").Value;
                poolInfo.ValueStyle.IsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                poolInfo.ValueStyle.BackColorExp = tempNode.Attributes.GetNamedItem("BackColor").Value;
                poolInfo.ValueStyle.LineColorExp = tempNode.Attributes.GetNamedItem("LineColor").Value;
                poolInfo.ValueStyle.LineWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("LineWidth").Value);
                poolInfo.ValueStyle.DecimalDigitsExp = tempNode.Attributes.GetNamedItem("DecimalDigits").Value;
                XmlNode afNode = tempNode.Attributes.GetNamedItem("ArrowFactor");
                if (afNode != null && afNode.Value.Length > 0) poolInfo.ValueStyle.ArrowFactor = Convert.ToSingle(afNode.Value);

                tempNode = node.SelectSingleNode("ScaleStyle");
                poolInfo.ScaleStyle.FontSize = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FontSize").Value);
                poolInfo.ScaleStyle.IsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                poolInfo.ScaleStyle.IsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                poolInfo.ScaleStyle.ForeColorExp = tempNode.Attributes.GetNamedItem("Color").Value;
                poolInfo.ScaleStyle.IsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                poolInfo.ScaleStyle.BackColorExp = tempNode.Attributes.GetNamedItem("BackColor").Value;
                poolInfo.ScaleStyle.LineColorExp = tempNode.Attributes.GetNamedItem("LineColor").Value;
                poolInfo.ScaleStyle.LineWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("LineWidth").Value);
                poolInfo.ScaleStyle.DecimalDigitsExp = tempNode.Attributes.GetNamedItem("DecimalDigits").Value;

                tempNode = node.SelectSingleNode("LabelStyle");
                poolInfo.LabelStyle.FontSize = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FontSize").Value);
                poolInfo.LabelStyle.Align = GetAlignByName(tempNode.Attributes.GetNamedItem("Align").Value);
                poolInfo.LabelStyle.IsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                poolInfo.LabelStyle.IsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                poolInfo.LabelStyle.ForeColorExp = tempNode.Attributes.GetNamedItem("Color").Value;
                poolInfo.LabelStyle.IsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                poolInfo.LabelStyle.BackColorExp = tempNode.Attributes.GetNamedItem("BackColor").Value;
                poolInfo.LabelStyle.LineColorExp = tempNode.Attributes.GetNamedItem("LineColor").Value;
                poolInfo.LabelStyle.LineWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("LineWidth").Value);
                poolInfo.LabelStyle.DecimalDigitsExp = tempNode.Attributes.GetNamedItem("DecimalDigits").Value;
                afNode = tempNode.Attributes.GetNamedItem("ArrowFactor");
                if (afNode != null && afNode.Value.Length > 0) poolInfo.LabelStyle.ArrowFactor = Convert.ToSingle(afNode.Value);

                XmlNodeList nodeList2 = tempNode.SelectNodes("Label");
                if (nodeList2 != null)
                {
                    foreach (XmlNode xmlNode in nodeList2)
                    {
                        PoolInfo.LabelItem item = new PoolInfo.LabelItem(poolInfo);
                        item.LabelValueExp = xmlNode.Attributes.GetNamedItem("Value").Value;
                        item.LabelName = xmlNode.Attributes.GetNamedItem("LabelName").Value;
                        poolInfo.LabelList.Add(item);
                    }
                }

                if (!String.IsNullOrEmpty(poolInfo.TriggerEvent))
                {
                    ITriggerEvent triggerEvent = poolInfo;
                    triggerEvent.Tag = poolInfo;
                    AddTriggerEvent(triggerEvent, config);
                }

                config.PoolList.Add(poolInfo);
            }
        }

        private static void LoadLitePool(XmlNodeList nodeList, MonitorConfig config)
        {
            LitePoolInfo litePoolInfo;
            XmlNode tempNode;
            foreach (XmlNode node in nodeList)
            {
                var sw = new Stopwatch();
                //sw.Start();
                litePoolInfo = new LitePoolInfo();
                //sw.Stop();
                //Trace.WriteLine(string.Format("new LitePoolInfo Spend {0}ms",sw.ElapsedMilliseconds));
                //sw.Reset();
                //sw.Start();
                //TODO: new LitePoolInfo() 花费的时间过长问题解决.
                litePoolInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                litePoolInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                litePoolInfo.Width = Convert.ToInt32(node.Attributes.GetNamedItem("Width").Value);
                litePoolInfo.Height = Convert.ToInt32(node.Attributes.GetNamedItem("Height").Value);
                litePoolInfo.FontFamily = node.Attributes.GetNamedItem("Font").Value;
                litePoolInfo.UnitExp = node.Attributes.GetNamedItem("Unit").Value;
                litePoolInfo.DataType = node.Attributes.GetNamedItem("DataType").Value;
                litePoolInfo.TagId = node.Attributes.GetNamedItem("TagId").Value;
                litePoolInfo.TriggerEvent = node.Attributes.GetNamedItem("TriggerEvent").Value;
                //sw.Stop();
                //Trace.WriteLine(string.Format("step 1 spend {0}ms", sw.ElapsedMilliseconds));
                //sw.Reset();
                //sw.Start();
                tempNode = node.Attributes.GetNamedItem("MonitorObj");
                if (tempNode != null) litePoolInfo.MonitorObj = tempNode.Value;
                //sw.Stop();
                //Trace.WriteLine(string.Format("MonitorObj spend {0}ms", sw.ElapsedMilliseconds));
                //sw.Reset();
                //sw.Start();
                tempNode = node.SelectSingleNode("PoolStyle");
                if (tempNode != null)
                {
                    litePoolInfo.PoolStyle.BorderWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("BorderWidth").Value);
                    litePoolInfo.PoolStyle.BorderColor = GetColor(tempNode.Attributes.GetNamedItem("BorderColor").Value);
                }
                //sw.Stop();
                //Trace.WriteLine(string.Format("PoolStyle spend {0}ms", sw.ElapsedMilliseconds));
                //sw.Reset();
                //sw.Start();
                tempNode = node.SelectSingleNode("ValueStyle");

                if (tempNode != null)
                {
                    litePoolInfo.ValueStyle.FontSize = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FontSize").Value);
                    litePoolInfo.ValueStyle.IsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                    litePoolInfo.ValueStyle.IsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                    litePoolInfo.ValueStyle.ForeColorExp = tempNode.Attributes.GetNamedItem("Color").Value;
                    litePoolInfo.ValueStyle.IsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                    litePoolInfo.ValueStyle.BackColorExp = tempNode.Attributes.GetNamedItem("BackColor").Value;
                    litePoolInfo.ValueStyle.LineColorExp = tempNode.Attributes.GetNamedItem("LineColor").Value;
                    litePoolInfo.ValueStyle.LineWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("LineWidth").Value);
                    litePoolInfo.ValueStyle.DecimalDigitsExp = tempNode.Attributes.GetNamedItem("DecimalDigits").Value;
                    litePoolInfo.ValueStyle.Align = tempNode.Attributes.GetNamedItem("Align").Value.ToLower();
                    var afNode = tempNode.Attributes.GetNamedItem("ArrowFactor");
                    if (afNode != null && afNode.Value.Length > 0) 
                        litePoolInfo.ValueStyle.ArrowFactor = Convert.ToSingle(afNode.Value);
                }
                //sw.Stop();
                //Trace.WriteLine(string.Format("ValueStyle spend {0}ms", sw.ElapsedMilliseconds));
                //sw.Reset();
                //sw.Start();
                tempNode = node.SelectSingleNode("LabelStyle");
                if (tempNode != null)
                {
                    litePoolInfo.LabelStyle.FontSize = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FontSize").Value);
                    litePoolInfo.LabelStyle.Align = GetAlignByName(tempNode.Attributes.GetNamedItem("Align").Value);
                    litePoolInfo.LabelStyle.IsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                    litePoolInfo.LabelStyle.IsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);
                    litePoolInfo.LabelStyle.ForeColorExp = tempNode.Attributes.GetNamedItem("Color").Value;
                    litePoolInfo.LabelStyle.IsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                    litePoolInfo.LabelStyle.BackColorExp = tempNode.Attributes.GetNamedItem("BackColor").Value;
                    litePoolInfo.LabelStyle.LineColorExp = tempNode.Attributes.GetNamedItem("LineColor").Value;
                    litePoolInfo.LabelStyle.LineWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("LineWidth").Value);
                    litePoolInfo.LabelStyle.DecimalDigitsExp = tempNode.Attributes.GetNamedItem("DecimalDigits").Value;
                    litePoolInfo.LabelStyle.Visible = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("Visible").Value); 
                }
                //sw.Stop();
                //Trace.WriteLine(string.Format("LabelStyle spend {0}ms",sw.ElapsedMilliseconds));
                //sw.Reset();

                sw.Start();
                var nodeList2 = tempNode.SelectNodes("Label");
                sw.Stop();
                Trace.WriteLine(string.Format("Labels SelectNodes Spend {0}ms",sw.ElapsedMilliseconds));
                sw.Reset();
                if (nodeList2 != null)
                {
                    foreach (XmlNode xmlNode in nodeList2)
                    {
                        //sw.Start();
                        var item = new LitePoolInfo.LabelItem(litePoolInfo);
                        //sw.Stop();
                        //Trace.WriteLine(string.Format("new LabelItem spend {0}ms",sw.ElapsedMilliseconds));
                        //sw.Reset();
                        //sw.Start();
                        item.FillColorExp = xmlNode.Attributes.GetNamedItem("FillColor").Value;
                        //sw.Stop();
                        Trace.WriteLine(string.Format("Label FillColor Spend {0}ms",sw.ElapsedMilliseconds));
                        //sw.Reset();
                        //sw.Start();
                        item.LabelValueExp = xmlNode.Attributes.GetNamedItem("Value").Value;
                        //sw.Stop();
                        //Trace.WriteLine(string.Format("Label Value Spend {0}ms",sw.ElapsedMilliseconds));
                        //sw.Reset();
                        //sw.Start();
                        item.LabelName = xmlNode.Attributes.GetNamedItem("LabelName").Value;
                        //sw.Stop();
                        //Trace.WriteLine(string.Format("Label LabelName Attributes spend {0}ms", sw.ElapsedMilliseconds));
                        //sw.Reset();
                        //sw.Start();
                        litePoolInfo.LabelList.Add(item);
                        //sw.Stop();
                        //Trace.WriteLine(string.Format("LabelList.AddItem spend {0}ms",sw.ElapsedMilliseconds));
                        //sw.Reset();
                    }
                }
                //sw.Stop();
                //Trace.WriteLine(string.Format("Label spend {0}ms",sw.ElapsedMilliseconds));

                if (!String.IsNullOrEmpty(litePoolInfo.TriggerEvent))
                {
                    ITriggerEvent triggerEvent = litePoolInfo;
                    triggerEvent.Tag = litePoolInfo;
                    AddTriggerEvent(triggerEvent, config);
                }
                config.LitePoolList.Add(litePoolInfo);
                //sw.Stop();
                //Trace.WriteLine(string.Format("new LitePool spend {0}ms",sw.ElapsedMilliseconds));
            }
        }

        private static void LoadGauge(XmlNodeList nodeList, MonitorConfig config)
        {
            GaugeInfo gaugeInfo;
            XmlNode tempNode;

            foreach (XmlNode node in nodeList)
            {
                gaugeInfo = new GaugeInfo();

                gaugeInfo.X = Convert.ToInt32(node.Attributes.GetNamedItem("X").Value);
                gaugeInfo.Y = Convert.ToInt32(node.Attributes.GetNamedItem("Y").Value);
                gaugeInfo.Width = Convert.ToInt32(node.Attributes.GetNamedItem("Width").Value);
                gaugeInfo.Height = Convert.ToInt32(node.Attributes.GetNamedItem("Height").Value);
                gaugeInfo.TagId = node.Attributes.GetNamedItem("TagId").Value;
                gaugeInfo.DataType = node.Attributes.GetNamedItem("DataType").Value;
                tempNode = node.Attributes.GetNamedItem("Center");
                if (tempNode != null)
                {
                    String[] temp = tempNode.Value.Split(',');
                    gaugeInfo.Center = new Point(Int32.Parse(temp[0]), Int32.Parse(temp[1]));
                }
                gaugeInfo.BackColor = GetColor(node.Attributes.GetNamedItem("BackColor").Value);
                gaugeInfo.MinValue = Convert.ToSingle(node.Attributes.GetNamedItem("MinValue").Value);
                gaugeInfo.MaxValue = Convert.ToSingle(node.Attributes.GetNamedItem("MaxValue").Value);

                tempNode = node.SelectSingleNode("BaseArc");
                gaugeInfo.BaseArcColor = GetColor(tempNode.Attributes.GetNamedItem("BaseArcColor").Value);
                gaugeInfo.BaseArcRadius = Convert.ToInt32(tempNode.Attributes.GetNamedItem("BaseArcRadius").Value);
                gaugeInfo.BaseArcStart = Convert.ToInt32(tempNode.Attributes.GetNamedItem("BaseArcStart").Value);
                gaugeInfo.BaseArcSweep = Convert.ToInt32(tempNode.Attributes.GetNamedItem("BaseArcSweep").Value);
                gaugeInfo.BaseArcWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("BaseArcWidth").Value);

                tempNode = node.SelectSingleNode("ScaleLinesMajor");
                gaugeInfo.ScaleLinesMajorColor = GetColor(tempNode.Attributes.GetNamedItem("ScaleLinesMajorColor").Value);
                gaugeInfo.ScaleLinesMajorInnerRadius = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesMajorInnerRadius").Value);
                gaugeInfo.ScaleLinesMajorOuterRadius = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesMajorOuterRadius").Value);
                gaugeInfo.ScaleLinesMajorStepValue = Convert.ToSingle(tempNode.Attributes.GetNamedItem("ScaleLinesMajorStepValue").Value);
                gaugeInfo.ScaleLinesMajorWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesMajorWidth").Value);

                tempNode = node.SelectSingleNode("ScaleLinesInter");
                gaugeInfo.ScaleLinesInterColor = GetColor(tempNode.Attributes.GetNamedItem("ScaleLinesInterColor").Value);
                gaugeInfo.ScaleLinesInterInnerRadius = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesInterInnerRadius").Value);
                gaugeInfo.ScaleLinesInterOuterRadius = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesInterOuterRadius").Value);
                gaugeInfo.ScaleLinesInterWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesInterWidth").Value);

                tempNode = node.SelectSingleNode("ScaleLinesMinor");
                gaugeInfo.ScaleLinesMinorColor = GetColor(tempNode.Attributes.GetNamedItem("ScaleLinesMinorColor").Value);
                gaugeInfo.ScaleLinesMinorInnerRadius = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesMinorInnerRadius").Value);
                gaugeInfo.ScaleLinesMinorOuterRadius = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesMinorOuterRadius").Value);
                gaugeInfo.ScaleLinesMinorNumOf = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesMinorNumOf").Value);
                gaugeInfo.ScaleLinesMinorWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleLinesMinorWidth").Value);

                tempNode = node.SelectSingleNode("ScaleNumbers");
                gaugeInfo.ScaleNumbersColor = GetColor(tempNode.Attributes.GetNamedItem("ScaleNumbersColor").Value);
                gaugeInfo.ScaleNumbersFormat = tempNode.Attributes.GetNamedItem("ScaleNumbersFormat").Value;
                gaugeInfo.ScaleNumbersRadius = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleNumbersRadius").Value);
                gaugeInfo.ScaleNumbersRotation = Convert.ToInt32(tempNode.Attributes.GetNamedItem("ScaleNumbersRotation").Value);
                if (tempNode.Attributes.GetNamedItem("Font") != null) 
                    gaugeInfo.FontFamily = tempNode.Attributes.GetNamedItem("Font").Value;
                if (tempNode.Attributes.GetNamedItem("FontSize") != null) 
                    gaugeInfo.FontSize = Convert.ToSingle(tempNode.Attributes.GetNamedItem("FontSize").Value);
                if (tempNode.Attributes.GetNamedItem("IsBold") != null)
                    gaugeInfo.IsBold = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsBold").Value);
                if (tempNode.Attributes.GetNamedItem("IsItalic") != null)
                    gaugeInfo.IsItalic = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsItalic").Value);
                if (tempNode.Attributes.GetNamedItem("IsUnderLine") != null)
                    gaugeInfo.IsUnderLine = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("IsUnderLine").Value);

                tempNode = node.SelectSingleNode("Needle");
                try
                {
                    gaugeInfo.NeedleColor1 = (Shmzh.Windows.Forms.AGauge.NeedleColorEnum)Enum.Parse(
                        typeof(Shmzh.Windows.Forms.AGauge.NeedleColorEnum), tempNode.Attributes.GetNamedItem("NeedleColor1").Value);
                }
                catch
                {
                    gaugeInfo.NeedleColor1 = Shmzh.Windows.Forms.AGauge.NeedleColorEnum.Gray;
                }
                gaugeInfo.NeedleColor2 = GetColor(tempNode.Attributes.GetNamedItem("NeedleColor2").Value);
                gaugeInfo.NeedleType = Convert.ToInt32(tempNode.Attributes.GetNamedItem("NeedleType").Value);
                gaugeInfo.NeedleRadius = Convert.ToInt32(tempNode.Attributes.GetNamedItem("NeedleRadius").Value);
                gaugeInfo.NeedleWidth = Convert.ToInt32(tempNode.Attributes.GetNamedItem("NeedleWidth").Value);

                XmlNodeList tempNodeList = node.SelectNodes("Ranges/Range");
                if(tempNodeList != null)
                {
                    Boolean[] rangesEnabled = {false, false, false, false, false};
                    Single[] rangesStartValue = {0F, 0F, 0F, 0F, 0F};
                    Single[] rangesEndValue = { 0F, 0F, 0F, 0F, 0F };
                    Int32[] rangesInnerRadius = { 70, 70, 70, 70, 70 };
                    Int32[] rangesOuterRadius = { 80, 80, 80, 80, 80 };
                    Color[] rangesColor = { Color.LightGreen, Color.Red, Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.Control) };
                    Int32 count = Math.Min(5, tempNodeList.Count);
                    for (int i = 0; i < count; i++)
                    {
                        tempNode = tempNodeList[i];
                        rangesEnabled[i] = Convert.ToBoolean(tempNode.Attributes.GetNamedItem("Enabled").Value);
                        rangesColor[i] = GetColor(tempNode.Attributes.GetNamedItem("Color").Value);
                        rangesStartValue[i] = Convert.ToSingle(tempNode.Attributes.GetNamedItem("StartValue").Value);
                        rangesEndValue[i] = Convert.ToSingle(tempNode.Attributes.GetNamedItem("EndValue").Value);
                        rangesInnerRadius[i] = Convert.ToInt32(tempNode.Attributes.GetNamedItem("InnerRadius").Value);
                        rangesOuterRadius[i] = Convert.ToInt32(tempNode.Attributes.GetNamedItem("OuterRadius").Value);
                    }
                    gaugeInfo.RangesEnabled = rangesEnabled;
                    gaugeInfo.RangesColor = rangesColor;
                    gaugeInfo.RangesStartValue = rangesStartValue;
                    gaugeInfo.RangesEndValue = rangesEndValue;
                    gaugeInfo.RangesInnerRadius = rangesInnerRadius;
                    gaugeInfo.RangesOuterRadius = rangesOuterRadius;
                }
                config.GaugeList.Add(gaugeInfo);
            }
        }

        private static void AddTriggerEvent(ITriggerEvent triggerEvent, MonitorConfig config)
        {
            String[] tempArray = triggerEvent.TriggerEvent.Split(':');
            triggerEvent.TriggerEvent = tempArray[1];
            String strEvent = tempArray[0].ToLower();
            if (strEvent.Equals("leftclick"))
            {
                config.LeftClickList.Add(triggerEvent);
            }
            else if (strEvent.Equals("rightclick"))
            {
                config.RightClickList.Add(triggerEvent);
            }
            else if (strEvent.Equals("doubleclick"))
            {
                config.DoubleClickList.Add(triggerEvent);
            }
        }

        private static Color GetColor(String colorString)
        {
            return Shmzh.Components.Util.StringUtil.StringToColor(colorString, Color.Transparent);
        }

        private static TextAlign GetAlignByName(String align)
        {
            try
            {
                return (TextAlign)Enum.Parse(typeof(TextAlign), align, true);
            }
            catch (Exception)
            {
                return TextAlign.Left;
            }
        }
    }
}
