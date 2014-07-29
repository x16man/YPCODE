using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Entity
{
    [Serializable]
    public class TagDayInfo
    {
        #region Property
        /// <summary>
        /// 时间点,样式为yyyyMMdd.
        /// </summary>
        public int I_Cycle_Id { get; set; }
        /// <summary>
        /// 指标ID。
        /// </summary>
        public string I_Tag_Id { get; set; }
        /// <summary>
        /// 原始值。
        /// </summary>
        public double I_Value_Org { get; set; }
        /// <summary>
        /// 修正值。
        /// </summary>
        public double I_Value_Man { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public double Max_Value { get; set; }
        /// <summary>
        /// 最小值。
        /// </summary>
        public double Min_Value { get; set; }
        /// <summary>
        /// 开始值
        /// </summary>
        public double Begin_Value { get; set; }
        /// <summary>
        /// 结束值
        /// </summary>
        public double End_Value { get; set; }
        #endregion

        public TagDayInfo()
        {}
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                 @"{8}:
- I_Cycle_Id: {0}
- I_Tag_Id: {1}
- I_Value_Org: {2}
- I_Value_Man:{3}
- Max_Value:{4}
- Min_Value:{5}
- Begin_Value:{6}
- End_Value: {7}
",
                                 this.I_Cycle_Id,
                                 this.I_Tag_Id,
                                 this.I_Value_Org,
                                 this.I_Value_Man,
                                 this.Max_Value,
                                 this.Min_Value,
                                 this.Begin_Value,
                                 this.End_Value,
                                 this.GetType());
        }
    }
}
