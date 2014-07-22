using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 图表信息实体。
    /// </summary>
    [Serializable]
    public class FloatingBlockInfo
    {
        private List<FloatingBlockItemInfo> itemList;

        #region Property

        /// <summary>
        /// 方案Id。
        /// </summary>
        [Bindable(true)]
        public int SchemaId { get; set; }
        /// <summary>
        /// 浮动窗体Id.
        /// </summary>
        public int BlockId { get; set; }
        /// <summary>
        /// 填充颜色.
        /// </summary>
        public int FillColor { get; set; }
        /// <summary>
        /// 边框颜色.
        /// </summary>
        public int BorderColor { get; set; }
        /// <summary>
        /// 标签字体大小.
        /// </summary>
        public float LableFontSize { get; set; }
        /// <summary>
        /// 标签字体.
        /// </summary>
        public String LableFontFamily { get; set; }
        /// <summary>
        /// 标签前景色.
        /// </summary>
        public int LableForeColor { get; set; }
        /// <summary>
        /// X坐标.
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Y坐标.
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// 宽度.
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// 高度.
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// 是否自适应大小.
        /// </summary>
        public bool IsAutoSize { get; set; }
        
        /// <summary>
        /// FloatingBlockItem 列表。
        /// </summary>
        public List<FloatingBlockItemInfo> ItemList
        {
            get { return itemList ?? (itemList = new List<FloatingBlockItemInfo>()); }
            set { itemList = value; }
        }

        public bool IsLabelInLine { get; set; }

       
        #endregion

        #region CTOR
        public FloatingBlockInfo()
        {
            this.LableFontFamily = "宋体";
            this.LableFontSize = 12F;
            this.X = this.Y = 0F;
            this.IsLabelInLine = false;
            this.Width = 0f;
            this.Height = 0f;
            this.IsAutoSize = true;
        }
        #endregion

//        public override string ToString()
//        {
//            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
//                @"{6}:
//- SchemaId: {0}
//- Name: {1}
//- IsValid: {2}
//- Layout: {3}
//- Remark:{4}
//- DataType:{5}
//",
//                this.SchemaId,
//                this.Name,
//                this.IsValid,
//                this.Layout,
//                this.Remark,
//                this.DataType,
//                this.GetType());
//        }
    }

}
