using System;
using System.ComponentModel;

namespace Shmzh.Monitor.Entity
{
    [Serializable]
    public class TagMin15Info
    {
        #region Property
        /// <summary>
        /// 时间点。
        /// </summary>
        [Bindable(true)]
        public int I_Cycle_Id { get; set; }
        /// <summary>
        /// 指标Id。
        /// </summary>
        [Bindable(true)]
        public string I_Tag_Id { get; set; }
        /// <summary>
        /// 原始值。
        /// </summary>
        [Bindable(true)]
        public double I_Value_Org { get; set; }
        /// <summary>
        /// 修正值。
        /// </summary>
        [Bindable(true)]
        public double I_Value_Man { get; set; }
        /// <summary>
        /// 最大值。
        /// </summary>
        [Bindable(true)]
        public double Max_Value { get; set; }
        /// <summary>
        /// 最小值。
        /// </summary>
        [Bindable(true)]
        public double Min_Value { get; set; }
        /// <summary>
        /// 开始值。
        /// </summary>
        [Bindable(true)]
        public double Begin_Value { get; set; }
        /// <summary>
        /// 结束值。
        /// </summary>
        [Bindable(true)]
        public double End_Value { get; set; }
        #endregion
        
        #region CTOR
        public TagMin15Info()
        {

        }
        #endregion

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
- Upper_Seconds:{6}
- Lower_Seconds:{7}
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
