using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using Shmzh.Components.Util;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 报表模板实体类。
    /// </summary>
    [Serializable]
    public class SchemaInfo
    {
        #region Property
        /// <summary>
        /// 报表Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Id { get; set; }
        
        /// <summary>
        /// 报表名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 报表大类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Type { get; set; }

        /// <summary>
        /// 报表的XML内容。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Xml { get; set; }

        /// <summary>
        /// 报表的时间周期类型.
        /// </summary>
        /// <remarks>例如：小时报表、日报表、月报表、年报等。</remarks>
        [Bindable(BindableSupport.Yes)]
        public string CycleType { get; set; }

        /// <summary>
        /// 非OWC报表的Url地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Url { get; set; }

        /// <summary>
        /// 报表的描述。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// 报表模板内容是否经过GZip压缩。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsZipped { get; set; }
        #endregion

        /// <summary>
        /// 报表实体的构造函数。
        /// </summary>
        public SchemaInfo()
        {}

        public string ToPureSchemaXml()
        {
            string xml;
            var oXML = new XmlDocument();
            XmlNodeList oNodes;
            XmlNode oDataSchemaNode;
            if (string.IsNullOrEmpty(this.Xml)) return string.Empty;

            xml = this.IsZipped ? StringUtil.UnZip(this.Xml) : this.Xml;

            oXML.LoadXml(xml);
            oDataSchemaNode = oXML.SelectSingleNode("DataSchema");
            return string.Format(@"<?xml version=""1.0""?>{0}", oDataSchemaNode.SelectSingleNode("Report").InnerXml);
        }
        /// <summary>
        /// 获取指标导入定义信息。
        /// </summary>
        /// <returns>指标导入定义信息集合。</returns>
        public List<ImportInfo> GetImportInfo()
        {
            var oXML = new XmlDocument();
            var objs = new List<ImportInfo>();
            if(string.IsNullOrEmpty(this.Xml)) return objs;

            var xml = this.IsZipped ? StringUtil.UnZip(this.Xml) : this.Xml;
            
            oXML.LoadXml(xml);

            var oNodes = oXML.SelectNodes("DataSchema/Retrieve/Item");
            foreach(XmlNode node in oNodes)
            {
                var obj = new ImportInfo();
                foreach (XmlAttribute attr in node.Attributes)
                {
                    switch (attr.Name)
                    {
                        case "DATETYPE":
                            obj.DateType = attr.Value;
                            break;
                        case "TAGRANGE":
                            obj.TagRange = attr.Value;
                            break;
                        case "FILLRANGE":
                            obj.FillRange = attr.Value;
                            break;
                        case "TAGTYPE":
                            obj.TagType = attr.Value;
                            break;
                        case "TAGORIENT":
                            obj.TimeDirection = attr.Value;
                            break;
                    }
                }
                objs.Add(obj);
            }
            return objs;
        }
        /// <summary>
        /// 获取数据导出设置信息。
        /// </summary>
        /// <returns>数据导出设置信息。</returns>
        public List<ExportInfo> GetExportInfo()
        {
            var oXML = new XmlDocument();
            var objs = new List<ExportInfo>();
            if (string.IsNullOrEmpty(this.Xml)) return objs;

            var xml = this.IsZipped ? StringUtil.UnZip(this.Xml) : this.Xml;

            oXML.LoadXml(xml);

            var oNodes = oXML.SelectNodes("DataSchema/Save/Item");
            foreach (XmlNode node in oNodes)
            {
                var obj = new ExportInfo();
                foreach (XmlAttribute attr in node.Attributes)
                {
                    switch (attr.Name)
                    {
                        case "DATETYPE":
                            obj.DateType = attr.Value;
                            break;
                        case "TAGRANGE":
                            obj.TagRange = attr.Value;
                            break;
                        case "SAVERANGE":
                            obj.SaveRange = attr.Value;
                            break;
                        case "TAGTYPE":
                            obj.TagType = attr.Value;
                            break;
                        case "TAGORIENT":
                            obj.TimeDirection = attr.Value;
                            break;
                    }
                }
                objs.Add(obj);
            }
            return objs;
        }
        /// <summary>
        /// 获取打印设置信息。
        /// </summary>
        /// <returns>打印设置信息。</returns>
        public List<PrintInfo> GetPrintInfo()
        {
            var oXML = new XmlDocument();
            var objs = new List<PrintInfo>();
            if(string.IsNullOrEmpty(this.Xml)) return objs;

            var xml = this.IsZipped ? StringUtil.UnZip(this.Xml) : this.Xml;
            
            oXML.LoadXml(xml);

            var oNodes = oXML.SelectNodes("DataSchema/Print/Item");
            foreach (XmlNode node in oNodes)
            {
                var obj = new PrintInfo();
                foreach (XmlAttribute attr in node.Attributes)
                {
                    switch (attr.Name)
                    {
                        case "PagerSize":
                            obj.PageSize = attr.Value;
                            break;
                        case "Orientation":
                            obj.Orientation = attr.Value;
                            break;
                        case "LeftMargin":
                            obj.MarginLeft = attr.Value;
                            break;
                        case "RightMargin":
                            obj.MarginRight = attr.Value;
                            break;
                        case "TopMargin":
                            obj.MarginTop = attr.Value;
                            break;
                        case "BottomMargin":
                            obj.MarginBottom = attr.Value;
                            break;
                        case "HeaderMargin":
                            obj.Header = attr.Value;
                            break;
                        case "FooterMargin":
                            obj.Footer = attr.Value;
                            break;
                    }
                }
                objs.Add(obj);
            }
            return objs;
        }
    }

    /// <summary>
    /// 报表模板定义的指标导入信息。
    /// </summary>
    public class ImportInfo
    {
        #region Property
        /// <summary>
        /// 时间特征
        /// </summary>
        public string DateType { get; set; }

        /// <summary>
        /// 指标范围
        /// </summary>
        public string TagRange { get; set; }

        /// <summary>
        /// 填充范围
        /// </summary>
        public string FillRange { get; set; }

        /// <summary>
        /// 指标值类型。
        /// </summary>
        public string TagType { get; set; }

        /// <summary>
        /// 时间方向。
        /// </summary>
        public string TimeDirection { get; set; }
        #endregion

        #region CTOR
        public ImportInfo()
        {
        }

        #endregion
    }

    /// <summary>
    /// 报表模板的数据导出区域定义信息。
    /// </summary>
    public class ExportInfo
    {
        #region Property
        /// <summary>
        /// 时间特征
        /// </summary>
        public string DateType { get; set; }

        /// <summary>
        /// 指标范围
        /// </summary>
        public string TagRange { get; set; }

        /// <summary>
        /// 填充范围
        /// </summary>
        public string SaveRange { get; set; }

        /// <summary>
        /// 指标值类型。
        /// </summary>
        public string TagType { get; set; }

        /// <summary>
        /// 时间方向。
        /// </summary>
        public string TimeDirection { get; set; }
        #endregion

        #region CTOR
        public ExportInfo()
        {
        }

        #endregion
    }

    /// <summary>
    /// 报表的打印设置信息。
    /// </summary>
    public class PrintInfo
    {
        #region Property
        /// <summary>
        /// 页面大小。
        /// </summary>
        public string PageSize { get; set; }
        /// <summary>
        /// 打印方向。
        /// </summary>
        public string Orientation { get; set; }

        /// <summary>
        /// 页边距-左。
        /// </summary>
        public string MarginLeft { get; set; }

        /// <summary>
        /// 页边距-右。
        /// </summary>
        public string MarginRight { get; set; }

        /// <summary>
        /// 页边距-上。
        /// </summary>
        public string MarginTop { get; set; }

        /// <summary>
        /// 页边距-下。
        /// </summary>
        public string MarginBottom { get; set; }

        /// <summary>
        /// 页眉。
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// 页脚。
        /// </summary>
        public string Footer { get; set; }
        #endregion

        #region CTOR
        public PrintInfo(){}
        #endregion
    }
}
