using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 组织机构与人员关系表。
    /// </summary>
    [Serializable]
    public class TB_ORGMEMLKInfo
    {
        /// <summary>
        /// 组织机构与人员关系ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int LnkId { get; set; }

        /// <summary>
        /// 组织机构Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int OrgId { get; set; }

        /// <summary>
        /// 用户Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int UserId { get; set; }
    }
}
