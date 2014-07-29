using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    /// <summary>
    /// TempTaskInfo.
    /// </summary>
    [Serializable]
    public class TempTaskInfo
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public String Type { get; set; }

        public String Priority { get; set; }

        public String State { get; set; }

        public DateTime PlanStartDate { get; set; }

        public DateTime PlanFinishDate { get; set; }

        public String PlanWorkTimeLimit { get; set; }

        public DateTime RealStartDate { get; set; }

        public DateTime RealFinishDate { get; set; }

        public String RealWorkTimeLimit { get; set; }

        public String CompletePercent { get; set; }

        /// <summary>
        /// 负责人登录名。
        /// </summary>
        public String Principal{ get; set;}

        /// <summary>
        /// 审批人登录名。
        /// </summary>
        public String Examinant { get; set; }

        public String Memo { get; set; }

        /// <summary>
        /// 发布人登录名。
        /// </summary>
        public String Master { get; set; }

        /// <summary>
        /// 发布时间。
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
