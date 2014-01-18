using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.MM.Common
{
    public class SBODInfo
    {
        #region Property
        /// <summary>
        /// 单据类型编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short DocCode { get; set; }

        /// <summary>
        /// 单据类型名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DocName { get; set; }

        /// <summary>
        /// 单据编号规则。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CodeRule { get; set; }

        /// <summary>
        /// 单据文档编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DocNo { get; set; }

        /// <summary>
        /// 开始序号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int StartNo { get; set; }

        /// <summary>
        /// 下一序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int NextNo { get; set; }

        /// <summary>
        /// 是否一料一单。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool OneItem { get; set; }

        /// <summary>
        /// 审批级数。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short AuditLevel { get; set; }

        /// <summary>
        /// 一级审批是否有效
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsAudit1 { get; set; }

        /// <summary>
        /// 二级审批是否有效
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsAudit2 { get; set; }

        /// <summary>
        /// 三级审批是否有效
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsAudit3 { get; set; }

        /// <summary>
        /// 四级审批是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsAudit4 { get; set; }

        /// <summary>
        /// 是否出具财务凭证
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsAccount { get; set; }

        /// <summary>
        /// 一级审批名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AuditName1 { get; set; }

        /// <summary>
        /// 二级审批名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AuditName2 { get; set; }

        /// <summary>
        /// 三级审批名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AuditName3 { get; set; }

        /// <summary>
        /// 四级审批名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AuditName4 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
