using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.Monitor.Entity
{
    [Serializable]
    public class TagSecondInfo
    {
        #region Property
        /// <summary>
        /// 时间Id。
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
        public double I_Value_0 { get; set; }
        /// <summary>
        /// 修正值。
        /// </summary>
        [Bindable(true)]
        public double I_Value_1 { get; set; }
        #endregion
        public TagSecondInfo (){}

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                 @"{4}:
- I_Cycle_Id: {0}
- I_Tag_Id: {1}
- I_Value_0: {2}
- I_Value_1:{3}
",
                                 this.I_Cycle_Id,
                                 this.I_Tag_Id,
                                 this.I_Value_0,
                                 this.I_Value_1,
                                 this.GetType());
        }
    }
}
