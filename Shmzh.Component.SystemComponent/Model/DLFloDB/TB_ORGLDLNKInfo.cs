using System;
using System.ComponentModel;

namespace Shmzh.Components.SystemComponent.Model
{
    [Serializable]
    public class TB_ORGLDLNKInfo
    {
        #region Property
        /// <summary>
        /// Id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int LNKID { get; set; }
        /// <summary>
        /// 组织机构ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int OrgId { get; set; }
        /// <summary>
        /// 领导类型Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int LeadTypeId { get; set; }
        /// <summary>
        /// 用户Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int UserId { get; set; }
        #endregion

        #region CTOR
        public TB_ORGLDLNKInfo(){}
        #endregion
    }
}
