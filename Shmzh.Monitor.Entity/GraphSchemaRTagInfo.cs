using System;
using System.ComponentModel;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 图表信息实体。
    /// </summary>
    [Serializable]
    public class GraphSchemaRTagInfo
    {
        #region Property
        /// <summary>
        /// RTagId.
        /// </summary>
        [Bindable(true)]
        public Int32 RTagId { get; set; }

        /// <summary>
        /// Tab Id。
        /// </summary>
        [Bindable(true)]
        public Int32 TabId { get; set; }

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
        /// 序号。
        /// </summary>
        [Bindable(true)]
        public Int32 SerialNumber { get; set; }

        /// <summary>
        /// 单位。
        /// </summary>
        [Bindable(true)]
        public String Unit { get; set; }

        /// <summary>
        /// 数据类型。
        /// </summary>
        [Bindable(true)]
        public String DataType { get; set; }

        /// <summary>
        /// 指标值。
        /// </summary>
        [Bindable(true)]
        public Double TagValue { get; set; }
       
        #endregion

        #region CTOR
        public GraphSchemaRTagInfo()
        {
        }
        #endregion

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                @"{7}:

- TagId: {0}
- TabId:{1}
- TagName: {2}
- RTagId:{3}
- SerialNumber:{4}
- Unit: {5}
- DataType:{6}
",
               
                this.TagId,
                this.TabId,
                this.TagName,
                this.RTagId,
                this.SerialNumber,
                this.Unit,
                this.DataType,
                this.GetType());
        }
    }

}
