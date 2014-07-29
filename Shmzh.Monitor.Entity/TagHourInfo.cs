using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Entity
{
    [Serializable]
    public class TagHourInfo
    {
        #region Property
        /// <summary>
        /// 时间点，值为距离2002年1月1日零点的第几个小时。
        /// </summary>
        public int I_Cycle_Id { get; set; }
        /// <summary>
        /// 指标ID
        /// </summary>
        public string I_Tag_Id { get; set; }
        /// <summary>
        /// 原始值
        /// </summary>
        public double I_Value_Org { get; set; }
        /// <summary>
        /// 修正值
        /// </summary>
        public double I_Value_Man { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public double Max_Value { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public double Min_Value { get; set; }
        /// <summary>
        /// 最大值发生时间
        /// </summary>
        public double Upper_Seconds { get; set; }
        /// <summary>
        /// 最小值发生时间
        /// </summary>
        public double Lower_Seconds { get; set; }
        /// <summary>
        /// 开始值
        /// </summary>
        public double Begin_Value { get; set; }
        /// <summary>
        /// 结束值
        /// </summary>
        public double End_Value { get; set; }
        #endregion

        public TagHourInfo()
        {
        }
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                 @"{10}:
- I_Cycle_Id: {0}
- I_Tag_Id: {1}
- I_Value_Org: {2}
- I_Value_Man:{3}
- Max_Value:{4}
- Min_Value:{5}
- Upper_Seconds:{6}
- Lower_Seconds:{7}
- Begin_Value:{8}
- End_Value: {9}
",
                                 this.I_Cycle_Id,
                                 this.I_Tag_Id,
                                 this.I_Value_Org,
                                 this.I_Value_Man,
                                 this.Max_Value,
                                 this.Min_Value,
                                 this.Upper_Seconds,
                                 this.Lower_Seconds,
                                 this.Begin_Value,
                                 this.End_Value,
                                 this.GetType());
        }
    }
}
