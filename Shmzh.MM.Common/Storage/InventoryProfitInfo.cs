using System;
using System.ComponentModel;
using Shmzh.MM.Common;

namespace Shmzh.MM.Common.Storage
{
    public class InventoryProfitInfo:IForm
    {
        #region Implementation of IForm

        /// <summary>
        /// 单据流水号。
        /// </summary>
        public int EntryNo { get; set; }

        /// <summary>
        /// 单据编号。
        /// </summary>
        public string EntryCode { get; set; }

        /// <summary>
        /// 单据类型编号。
        /// </summary>
        public short DocCode { get; set; }

        /// <summary>
        /// 单据类型名称。
        /// </summary>
        public string DocName { get; set; }

        /// <summary>
        /// 单据文档编号。
        /// </summary>
        public string DocNo { get; set; }

        /// <summary>
        /// 单据日期。
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// 单据状态。
        /// </summary>
        public string EntryState { get; set; }

        /// <summary>
        /// 提交日期。
        /// </summary>
        public DateTime PresentDate { get; set; }

        /// <summary>
        /// 作废日期。
        /// </summary>
        public DateTime CancelDate { get; set; }

        /// <summary>
        /// 单据总金额。
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// 制单人编号。
        /// </summary>
        public string AuthorCode { get; set; }

        /// <summary>
        /// 制单人名称。
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 制单人登录名。
        /// </summary>
        public string AuthorLoginId { get; set; }

        /// <summary>
        /// 制单部门编号。
        /// </summary>
        public string AuthorDept { get; set; }

        /// <summary>
        /// 制单部门名称。
        /// </summary>
        public string AuthorDeptName { get; set; }

        /// <summary>
        /// 一级审批
        /// </summary>
        public string Audit1 { get; set; }

        /// <summary>
        /// 一级审批人。
        /// </summary>
        public string Assessor1 { get; set; }

        /// <summary>
        /// 一级审批日期。
        /// </summary>
        public DateTime AuditDate1 { get; set; }

        /// <summary>
        /// 一级审批意见。
        /// </summary>
        public string AuditSuggest1 { get; set; }

        /// <summary>
        /// 二级审批
        /// </summary>
        public string Audit2 { get; set; }

        /// <summary>
        /// 二级审批人。
        /// </summary>
        public string Assessor2 { get; set; }

        /// <summary>
        /// 二级审批日期。
        /// </summary>
        public DateTime AuditDate2 { get; set; }

        /// <summary>
        /// 二级审批意见。
        /// </summary>
        public string AuditSuggest2 { get; set; }

        /// <summary>
        /// 三级审批
        /// </summary>
        public string Audit3 { get; set; }

        /// <summary>
        /// 三级审批人。
        /// </summary>
        public string Assessor3 { get; set; }

        /// <summary>
        /// 三级审批日期。
        /// </summary>
        public DateTime AuditDate3 { get; set; }

        /// <summary>
        /// 三级审批意见。
        /// </summary>
        public string AuditSuggest3 { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        public string Remark { get; set; }

        #endregion

        #region Property

        /// <summary>
        /// 仓库编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string StoCode { get; set; }

        /// <summary>
        /// 仓库名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string StoName { get; set; }

        /// <summary>
        /// 收料人编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AcceptCode { get; set; }

        /// <summary>
        /// 收料人姓名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AcceptName { get; set; }

        /// <summary>
        /// 收料日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime AcceptDate { get; set; }

        /// <summary>
        /// 红字单据所对应的蓝字单据号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ParentEntryNo { get; set; }
        #endregion
    }
}