using System;
using System.ComponentModel;

namespace Shmzh.MM.Common
{
    /// <summary>
    /// 表单接口。
    /// </summary>
    public interface IForm
    {
        /// <summary>
        /// 单据流水号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        int EntryNo { get; set; }

        /// <summary>
        /// 单据编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string EntryCode { get; set; }

        /// <summary>
        /// 单据类型编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        short DocCode { get; set; }

        /// <summary>
        /// 单据类型名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string DocName { get; set; }

        /// <summary>
        /// 单据文档编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string DocNo { get; set; }

        /// <summary>
        /// 单据日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime EntryDate { get; set; }

        /// <summary>
        /// 单据状态。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string EntryState { get; set; }

        /// <summary>
        /// 提交日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime PresentDate { get; set; }

        /// <summary>
        /// 作废日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime CancelDate { get; set; }

        /// <summary>
        /// 单据总金额。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        decimal SubTotal { get; set; }

        /// <summary>
        /// 制单人编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorCode { get; set; }

        /// <summary>
        /// 制单人名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorName { get; set; }

        /// <summary>
        /// 制单人登录名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorLoginId { get; set; }

        /// <summary>
        /// 制单部门编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorDept { get; set; }

        /// <summary>
        /// 制单部门名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorDeptName { get; set; }

        /// <summary>
        /// 一级审批
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Audit1 { get; set; }

        /// <summary>
        /// 一级审批人。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Assessor1 { get; set; }

        /// <summary>
        /// 一级审批日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime AuditDate1 { get; set; }

        /// <summary>
        /// 一级审批意见。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuditSuggest1 { get; set; }

        /// <summary>
        /// 二级审批
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Audit2 { get; set; }

        /// <summary>
        /// 二级审批人。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Assessor2 { get; set; }

        /// <summary>
        /// 二级审批日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime AuditDate2 { get; set; }

        /// <summary>
        /// 二级审批意见。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuditSuggest2 { get; set; }

        /// <summary>
        /// 三级审批
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Audit3 { get; set; }

        /// <summary>
        /// 三级审批人。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Assessor3 { get; set; }

        /// <summary>
        /// 三级审批日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime AuditDate3 { get; set; }

        /// <summary>
        /// 三级审批意见。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuditSuggest3 { get; set; }
        
        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Remark { get; set; } 
    }
}