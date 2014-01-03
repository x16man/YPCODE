using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.Components.SystemComponent.Model
{
    /// <summary>
    /// 工作流用户分类。
    /// </summary>
    [Serializable]
    public class TB_UserCatInfo
    {
        #region property
        /// <summary>
        /// 用户分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int UserCatId { get; set; }
        /// <summary>
        /// 用户分类类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserCatType
        {
            get { return "LC"; }
        }
        /// <summary>
        /// 用户分类名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserCatName { get; set; }
        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool UserCatEnable { get; set; }
        #endregion
    }
}
