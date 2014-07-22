using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    [Serializable]
    public class TWorkOrderInfo
    {
        ///<summary>
        ///自动编号
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string AutoSN { get; set; }

        ///<summary>
        ///项目ID
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int PID { get; set; }

        ///<summary>
        ///提交人ID，(东兰数据库中ID)
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int SubmitUserID { get; set; }

        ///<summary>
        ///提交日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime SubmitDate { get; set; }

        ///<summary>
        ///申请人ID
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public int ApplicantID { get; set; }

        ///<summary>
        ///申请部门名称
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string ApplicantDept { get; set; }

        ///<summary>
        ///申请人职务
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string ApplicantJobTitle { get; set; }

        ///<summary>
        ///申请人工号
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string ApplicantHRID { get; set; }

        ///<summary>
        ///申请人姓名
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string ApplicantDspName { get; set; }

        ///<summary>
        ///出工单位
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string PrvCode { get; set; }

        ///<summary>
        ///预计工时
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string PrvName { get; set; }

        ///<summary>
        ///预计工时
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal PlanManHour { get; set; }

        ///<summary>
        ///要求完成日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ReqEndDate { get; set; }

        ///<summary>
        ///申请用工理由
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string ReqReason { get; set; }

        ///<summary>
        ///部门主管
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptMan { get; set; }

        ///<summary>
        ///部门主管审批意见
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptSuggest { get; set; }

        ///<summary>
        ///部门主管审批日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime DeptDate { get; set; }

        ///<summary>
        ///生技科
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string TechMan { get; set; }

        ///<summary>
        ///生技科审批意见
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string TechSuggest { get; set; }

        ///<summary>
        ///生技科审批日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime TechAuditDate { get; set; }

        ///<summary>
        ///施工负责人
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string PrvMan { get; set; }

        ///<summary>
        ///实际完成工时
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal RealManHour { get; set; }

        ///<summary>
        ///施工负责人签字日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime PrvDate { get; set; }

        ///<summary>
        ///主管厂长审批意见
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string GMMan { get; set; }

        ///<summary>
        ///主管厂长
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string GMSuggest { get; set; }

        ///<summary>
        ///主管厂长审批日期
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime GMDate { get; set; }

        ///<summary>
        ///备注
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public string FormAttach { get; set; }


    }
}
