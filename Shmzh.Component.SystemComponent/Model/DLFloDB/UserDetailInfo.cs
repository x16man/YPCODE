using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 工作流中用户的详细信息实体.
    /// </summary>
    public class UserDetailInfo
    {
        #region property
        /// <summary>
        /// 用户Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int UserId { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string HRID { get; set; }

        /// <summary>
        /// 登陆名
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserDspName { get; set; }

        /// <summary>
        /// 职位名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string JobTitle { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int OrgID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OrgName { get; set; }

        #endregion


    }
}
