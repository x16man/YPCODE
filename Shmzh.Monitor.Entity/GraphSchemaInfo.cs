using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 图表信息实体。
    /// </summary>
    [Serializable]
    public class GraphSchemaInfo : ICloneable
    {
        #region Field
        private List<GraphSchemaItemInfo> itemList;
        private List<FloatingBlockInfo> floatingBlockInfos;
        private List<GraphSchemaTabInfo> graphSchemaTabInfos;
        #endregion

        #region Property
        /// <summary>
        /// 方案Id。
        /// </summary>
        [Bindable(true)]
        public int SchemaId { get; set; }

        /// <summary>
        /// 方案名称。
        /// </summary>
        [Bindable(true)]
        public string Name { get; set; }
        
        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(true)]
        public Boolean IsValid { get; set; }
       
        /// <summary>
        /// 布局。
        /// </summary>
        [Bindable(true)]
        public String Layout { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(true)]
        public string Remark { get; set; }

        /// <summary>
        /// 数据类型。
        /// </summary>
        public String DataType { get; set; }

        /// <summary>
        /// 侧边栏的宽度。
        /// </summary>
        [Bindable(true)]
        public Int32 TabWidth { get; set; }
        
        /// <summary>
        /// 方案项列表。
        /// </summary>
        public List<GraphSchemaItemInfo> ItemList
        {
            get { return itemList ?? (itemList = new List<GraphSchemaItemInfo>()); }
            set { itemList = value; }
        }

        /// <summary>
        /// 曲线方案的浮动窗口对象集合.
        /// </summary>
        public List<FloatingBlockInfo> FloatingBlockInfos
        {
            get { return floatingBlockInfos ?? (floatingBlockInfos = new List<FloatingBlockInfo>()); }
            set { this.floatingBlockInfos = value;}
        }
        /// <summary>
        /// 图表信息实体.
        /// </summary>
        public List<GraphSchemaTabInfo> GraphSchemaTabInfos
        {
            get { return graphSchemaTabInfos ?? (graphSchemaTabInfos = new List<GraphSchemaTabInfo>()); }
            set { this.graphSchemaTabInfos = value;}
        }
        /// <summary>
        /// 标题。
        /// </summary>
        [Bindable(true)]
        public String Title { get; set; }
        /// <summary>
        /// 标题是否可见.
        /// </summary>
        public Boolean TitleVisible { get; set; }
        /// <summary>
        /// 标题字体大小.
        /// </summary>
        public float TitleFontSize { get; set; }
        /// <summary>
        /// 标题字体.
        /// </summary>
        public String TitleFontFamily { get; set; }
        /// <summary>
        /// 图例是否可见.
        /// </summary>
        public Boolean LegendVisible { get; set; }
        /// <summary>
        /// 图例字体大小.
        /// </summary>
        public float LegendFontSize { get; set; }
        /// <summary>
        /// 图例字体.
        /// </summary>
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
        /// "ALL" 或者 "左 上 右 下"，单精度浮点型。
        /// </summary>
        public String Margin { get; set; }
        /// <summary>
        /// 各个图之间的间距。
        /// </summary>
        public float InnerPaneGap { get; set; }
        /// <summary>
        /// 创建人或最后修改人的登录名。
        /// </summary>
        public String ReferLoginName { get; set; }
        /// <summary>
        /// 创建或最后修改时间。
        /// </summary>
        public DateTime ReferOpTime { get; set; }
        #endregion

        #region CTOR
        public GraphSchemaInfo()
        {
            this.Title = "";       
            this.TitleFontFamily = "宋体";
            this.TitleFontSize = 14F;
            this.TitleVisible = false;

            this.LegendVisible = false;
            this.LegendFontSize = 12F;
            this.LegendFontFamily = "Arial";
            this.LegendIsShowSymbols = false;
            this.LegendIsHStack = true;
            this.LegendPosition = "Top";

            this.Margin = "0";
            this.InnerPaneGap = 0F;
        }
        #endregion

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                @"{6}:
- SchemaId: {0}
- Name: {1}
- IsValid: {2}
- Layout: {3}
- Remark:{4}
- DataType:{5}
",
                this.SchemaId,
                this.Name,
                this.IsValid,
                this.Layout,
                this.Remark,
                this.DataType,
                this.GetType());
        }

        /// <summary>
        /// 创建作为当前实例副本的新对象。(深层复制)
        /// </summary>
        /// <returns>作为此实例副本的新对象。</returns>
        public Object Clone()
        {
            object obj = null;
            //返回一个内存副本
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                obj = formatter.Deserialize(stream);
            }
            return obj;
        }
    }

}
