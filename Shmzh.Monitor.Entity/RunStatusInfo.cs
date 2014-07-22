using System;
using System.ComponentModel;

namespace Shmzh.Monitor.Entity
{
    [Serializable]
    public class RunStatusInfo
    {
        #region Property
        /// <summary>
        /// ID.
        /// </summary>
        [Bindable(true)]
        public decimal PKID { get; set; }
        /// <summary>
        /// 设备编号。
        /// </summary>
        [Bindable(true)]
        public string Dev_Code { get; set; }
        /// <summary>
        /// 状态。
        /// </summary>
        [Bindable(true)]
        public int Status { get; set; }
        /// <summary>
        /// 开始时间。
        /// </summary>
        [Bindable(true)]
        public DateTime Begin_Time { get; set; }
        /// <summary>
        /// 结束时间。
        /// </summary>
        [Bindable(true)]
        public DateTime End_Time { get; set; }
        /// <summary>
        /// 操作人。
        /// </summary>
        [Bindable(true)]
        public string Operator { get; set; }
        /// <summary>
        /// 指标Id（基本为空）。
        /// </summary>
        [Bindable(true)]
        public string I_Tag_ID { get; set; }
        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(true)]
        public string Remark { get; set; }
        #endregion

        #region CTOR
        /// <summary>
        /// 设备运行状态信息的构造函数。
        /// </summary>
        public RunStatusInfo()
        {
        }

        #endregion
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                 @"{8}:
- PKID: {0}
- Dev_Code: {1}
- Status: {2}
- Begin_Time: {3}
- End_Time:{4}
- Operator:{5}
- I_Tag_Id:{6}
- Remark:{7}
",
                                 this.PKID,
                                 this.Dev_Code,
                                 this.Status,
                                 this.Begin_Time,
                                 this.End_Time,
                                 this.Operator,
                                 this.I_Tag_ID,
                                 this.Remark,
                                 this.GetType());
        }
    }
}
