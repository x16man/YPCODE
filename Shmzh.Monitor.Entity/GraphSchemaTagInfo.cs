using System;
using System.ComponentModel;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 图表信息实体。
    /// </summary>
    [Serializable]
    public class GraphSchemaTagInfo
    {
        #region Property
        /// <summary>
        /// KeyId.
        /// </summary>
        [Bindable(true)]
        public Int32 KeyId { get; set; }
        /// <summary>
        /// 图表Id。
        /// </summary>
        [Bindable(true)]
        public Int32 ItemId { get; set; }

        /// <summary>
        /// 指标Id。
        /// </summary>
        [Bindable(true)]
        public String TagId { get; set; }
        
        /// <summary>
        /// 指标名。
        /// </summary>
        [Bindable(true)]
        public String TagName { get; set; }
       
        /// <summary>
        /// 图表类型。
        /// </summary>
        [Bindable(true)]
        public String CurveType { get; set; }
        
        /// <summary>
        /// 曲线颜色。
        /// </summary>
        [Bindable(true)]
        public Int32 CurveColor { get; set; }
        
        /// <summary>
        /// 序号。
        /// </summary>
        public Int32 SerialNumber { get; set; }

        /// <summary>
        /// 线宽
        /// </summary>
        public Single LineWidth { get; set; }

        /// <summary>
        /// 节点符号类型。
        /// </summary>
        public String SymbolType { get; set; }

        /// <summary>
        /// 节点符号大小。
        /// </summary>
        public Single SymbolSize { get; set; }

        /// <summary>
        /// 移动平均线周期。
        /// </summary>
        public Int32 MAPeriod { get; set; }

        /// <summary>
        /// 线的类型(0：无线，散点；1：折线；2：平滑曲线。)
        /// </summary>
        public Byte LineType { get; set; }

        /// <summary>
        /// 节点符号颜色。
        /// </summary>
        public int SymbolColor { get; set; }
       
        #endregion

        #region CTOR
        public GraphSchemaTagInfo()
        {
            LineType = (byte)2;
            SymbolSize = 3;
        }
        #endregion

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                @"{9}:
- ItemId: {0}
- TagId: {1}
- TagName: {2}
- CurveType: {3}
- CurveColor:{4}
- KeyId:{5}
-SerialNumber:{6}
-LineType:{7}
-SymbolColor:{8}
",
                this.ItemId,
                this.TagId,
                this.TagName,
                this.CurveType,
                this.CurveColor,
                this.KeyId,
                this.SerialNumber,
                this.LineType,
                this.SymbolColor,
                this.GetType());
        }
    }

}
