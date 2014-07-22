using System;
using System.ComponentModel;

namespace Shmzh.Project.Entity
{
    /// <summary>
    /// 项目实体。
    /// </summary>
    [Serializable]
    public class ProjectInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// 公司项目编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CompNo { get; set; }

        ///<summary>
        ///项目编号
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string PNo { get; set; }

        ///<summary>
        ///项目简称
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string PShortName { get; set; }

        ///<summary>
        ///项目名称
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string PName { get; set; }

        ///<summary>
        ///项目描述
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Description { get; set; }

        ///<summary>
        ///立项原因
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Reason { get; set; }

        ///<summary>
        ///项目内容
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Content { get; set; }

        ///<summary>
        ///项目类型
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public int TypeID { get; set; }

        ///<summary>
        ///优先级
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Precession { get; set; }

        ///<summary>
        ///项目状态
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string State { get; set; }

        ///<summary>
        ///项目经理用户名
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string logname { get; set; }

        ///<summary>
        ///项目经理工号
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpCode { get; set; }

        ///<summary>
        ///项目经理
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Manager { get; set; }

        ///<summary>
        ///项目成员
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string member { get; set; }

        ///<summary>
        ///项目成员工号
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string MEmpCode { get; set; }

        ///<summary>
        ///成员登录名称
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string MLoginName { get; set; }

        ///<summary>
        ///计划开始日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime JStartDate { get; set; }

        ///<summary>
        ///计划结束日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime JFinishdDate { get; set; }

        ///<summary>
        ///计划工期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Jdate { get; set; }

        ///<summary>
        ///实际开始日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime SStartDate { get; set; }

        ///<summary>
        ///实际结束日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime SFinishdDate { get; set; }

        ///<summary>
        ///实际工期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Sdate { get; set; }

        ///<summary>
        ///完成百分比
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal complete { get; set; }

        ///<summary>
        ///计划材料成本
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal JStuff { get; set; }

        ///<summary>
        ///计划人工成本
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal JManpower { get; set; }

        ///<summary>
        ///计划其他成本
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal JOther { get; set; }

        ///<summary>
        ///实际材料成本
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal SStuff { get; set; }

        ///<summary>
        ///实际人工成本
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal SManpower { get; set; }

        ///<summary>
        ///实际其他成本
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal SOther { get; set; }

        ///<summary>
        ///全部投资金额
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal AllPutMoney { get; set; }

        ///<summary>
        ///年投资金额
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal YearPutMoney { get; set; }

        ///<summary>
        ///投产日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime PutDate { get; set; }

        ///<summary>
        ///提交日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime submissionDate { get; set; }

        ///<summary>
        ///提交人
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string submissionMan { get; set; }

        ///<summary>
        ///单位审批日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ComPCheckDate { get; set; }

        ///<summary>
        ///单位负责人
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Comprincipal { get; set; }

        ///<summary>
        ///单位审核内容
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string ComPCheckContent { get; set; }

        ///<summary>
        ///财务科审批日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime FinanceCheckDate { get; set; }

        ///<summary>
        ///财务科
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Finance { get; set; }

        ///<summary>
        ///财务科审核内容
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string FinanceContent { get; set; }

        ///<summary>
        ///物料科审批日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime MaterielCheckDate { get; set; }

        ///<summary>
        ///物料科
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Materiel { get; set; }

        ///<summary>
        ///物料科审核内容
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string MaterielContent { get; set; }

        ///<summary>
        ///生技科审批日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ProduceCheckDate { get; set; }

        ///<summary>
        ///生技科
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Produce { get; set; }

        ///<summary>
        ///生技科审核内容
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string ProduceContent { get; set; }

        ///<summary>
        ///计划部门审批日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime PlanCheckDate { get; set; }

        ///<summary>
        ///计划部门负责人
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string PlanDept { get; set; }

        ///<summary>
        ///计划部门审核内容
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string PlanContent { get; set; }

        ///<summary>
        ///经理审批日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ManagerCheckDate { get; set; }

        ///<summary>
        ///经理
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string ManagerDept { get; set; }

        ///<summary>
        ///经理审核内容
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string ManagerContent { get; set; }

        ///<summary>
        ///主管审批日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ChargeCheckDate { get; set; }

        ///<summary>
        ///主管科室
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string ChargeDept { get; set; }

        ///<summary>
        ///主管审核内容
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string ChargeContent { get; set; }

        ///<summary>
        ///综合计划科审批日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ColligateCheckDate { get; set; }

        ///<summary>
        ///综合计划科
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Colligate { get; set; }

        ///<summary>
        ///综合计划科审核内容
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string ColligateContent { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment { get; set; }

        ///<summary>
        ///备注1
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment1 { get; set; }

        ///<summary>
        ///备注2
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Comment2 { get; set; }

        ///<summary>
        ///填报单位
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string Reportunit { get; set; }

        ///<summary>
        ///填报日期
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ReportDate { get; set; }

        ///<summary>
        ///项目同意列入年
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public int InYear { get; set; }

        ///<summary>
        ///项目同意列入季
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public int InSeason { get; set; }

        ///<summary>
        ///批准投资额金额
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Money { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec2 { get; set; }

        ///<summary>
        ///
        ///<summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec3 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec4 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec5 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec6 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec7 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec8 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec9 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec10 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec11 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec12 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec13 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec14 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec15 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec16 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec17 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec18 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec19 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec20 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec21 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec22 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec23 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec24 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec25 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal dec26 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string FGCZSP { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime FGCZSPDate { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string FGCZSPInfo { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string FZR { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string FZRLogname { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string TBR { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string TBRLogname { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public string FormAttach { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal AfterTommoryPutMoney { get; set; }

        ///<summary>
        ///
        ///</summary>
        [Bindable(BindableSupport.Yes)]
        public decimal TommoryPutMoney { get; set; }


    }
}
