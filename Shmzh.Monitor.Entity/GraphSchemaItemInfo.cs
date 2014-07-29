using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 图表信息实体。
    /// </summary>
    [Serializable]
    public class GraphSchemaItemInfo
    {
        private List<GraphSchemaTagInfo> tagList;

        #region Property

        /// <summary>
        /// 图表Id。
        /// </summary>
        [Bindable(true)]
        public Int32 ItemId { get; set; }

        /// <summary>
        /// 方案Id。
        /// </summary>
        [Bindable(true)]
        public int SchemaId { get; set; }

        /// <summary>
        /// 标题。
        /// </summary>
        [Bindable(true)]
        public String Title { get; set; }

        public Boolean TitleVisible { get; set; }
        public float TitleFontSize { get; set; }
        public String TitleFontFamily { get; set; }

        public Boolean LegendVisible { get; set; }
        public float LegendFontSize { get; set; }
        public String LegendFontFamily { get; set; }
        /// <summary>
        /// 图例中是否显示 Symbols 。 
        /// </summary>
        public Boolean LegendIsShowSymbols { get; set; }
        /// <summary>
        /// 图例是否横向排列。
        /// </summary>
        public Boolean LegendIsHStack { get; set; }
        /// <summary>
        /// 图例相对于Chart的位置。
        /// </summary>
        public String LegendPosition { get; set; }
        
        /// <summary>
        /// X轴名称。
        /// </summary>
        [Bindable(true)]
        public String XAxis { get; set; }

        public Boolean XScaleVisible { get; set; }
        public float XScaleFontSize { get; set; }
        public String XScaleFontFamily { get; set; }

        public Boolean XTitleVisible { get; set; }
        public float XTitleFontSize { get; set; }
        public String XTitleFontFamily { get; set; }

        /// <summary>
        /// Y轴名称。
        /// </summary>
        [Bindable(true)]
        public String YAxis { get; set; }

        public Boolean YScaleVisible { get; set; }
        public float YScaleFontSize { get; set; }
        public String YScaleFontFaminly { get; set; }

        public Boolean YTitleVisible { get; set; }
        public float YTitleFontSize { get; set; }
        public String YTitleFontFamily { get; set; }

        public float MinSpaceL { get; set; }
        public float MinSpaceR { get; set; }

        /// <summary>
        /// 排序号。
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// X轴刻度值格式化字符串。
        /// </summary>
        public String XScaleFormat { get; set; }
        /// <summary>
        /// X轴刻度值格式化字符串。
        /// </summary>
        public String YScaleFormat { get; set; }

        /// <summary>
        /// 方案项指标列表。
        /// </summary>
        public List<GraphSchemaTagInfo> TagList
        {
            get
            {
                if (tagList == null)
                    tagList = new List<GraphSchemaTagInfo>();
                return tagList;
            }
            set { tagList = value; }
        }
        #endregion

        #region CTOR
        public GraphSchemaItemInfo()
        {
            this.Title = "";
            this.XAxis = "";
            this.YAxis = "";

            this.TitleFontFamily = "宋体";
            this.TitleFontSize = 14F;
            this.TitleVisible = true;

            this.LegendVisible = true;
            this.LegendFontSize = 12F;
            this.LegendFontFamily = "Arial";
            this.LegendIsShowSymbols = false;
            this.LegendIsHStack = true;
            this.LegendPosition = "Top";

            this.XScaleVisible = true;
            this.XScaleFontSize = 12F;
            this.XScaleFontFamily = "宋体";

            this.XTitleVisible = true;
            this.XTitleFontSize = 12F;
            this.XTitleFontFamily = "宋体";

            this.YScaleVisible = true;
            this.YScaleFontSize = 12F;
            this.YScaleFontFaminly = "宋体";

            this.YTitleVisible = true;
            this.YTitleFontSize = 12F;
            this.YTitleFontFamily = "宋体";

            this.MinSpaceL = 60;
            this.MinSpaceR = 20;

            this.SerialNumber = 0;
        }
        #endregion

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                @"{5}:
- ItemId: {0}
- SchemaId: {1}
- Title: {2}
- XAxis: {3}
- YAxis:{4}
",
                this.ItemId,
                this.SchemaId,
                this.Title,
                this.XAxis,
                this.YAxis,
                this.GetType());
        }
    }

}
