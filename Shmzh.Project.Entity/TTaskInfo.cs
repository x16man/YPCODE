using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TTaskInfo
    {
        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int PID { get; set; }

        ///<summary>
        ///项目编号
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string PNo { get; set; }

        ///<summary>
        ///前置任务
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string ParTask { get; set; }

        ///<summary>
        ///任务编号
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string WBS { get; set; }

        ///<summary>
        ///任务名称
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string name { get; set; }

        ///<summary>
        ///优先级别
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Distinction { get; set; }

        ///<summary>
        ///计划开始日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime StartDate { get; set; }

        ///<summary>
        ///计划完成日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime FinishedDate { get; set; }

        ///<summary>
        ///计划工期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal StartTimeLimit { get; set; }

        ///<summary>
        ///实际开始日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ActStartDate { get; set; }

        ///<summary>
        ///实际完成日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ActFinishedDate { get; set; }

        ///<summary>
        ///实际工期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal ActTimeLimit { get; set; }

        ///<summary>
        ///完成%
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Pctcomp { get; set; }

        ///<summary>
        ///负责人
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Author { get; set; }

        ///<summary>
        ///登录名称
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string LoginName { get; set; }

        ///<summary>
        ///任务类型
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string TaskType { get; set; }

        ///<summary>
        ///状态
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string TaskState { get; set; }

        ///<summary>
        ///标识
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int TaskFlg { get; set; }

        ///<summary>
        ///备注
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment { get; set; }

        ///<summary>
        ///备注1
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment1 { get; set; }

        ///<summary>
        ///备注1
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment2 { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string FloginName { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Fname { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string SloginName { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Sname { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string TaskGuid { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string AduitGuid { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string AuditEmpCode { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string AuditEmpName { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime AuditDate { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckEmpCode { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckEmpName { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ChecktDate { get; set; }


    }
}
