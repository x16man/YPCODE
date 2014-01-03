// <copyright file="GrantInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 组信息
    /// </summary>
    [Serializable]
    public class GrantInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public GrantInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// PKID
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long ID { get; set; }
        /// <summary>
        /// 授权人用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Grantor { get; set; }
        /// <summary>
        /// 授权人姓名
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string GrantorName { get; set; }
        /// <summary>
        /// 授权人所属部门名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string GrantorDept { get; set; }
        /// <summary>
        /// 被授权人用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Embracer { get; set; }
        /// <summary>
        /// 被授权人姓名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmbracerName { get; set; }
        /// <summary>
        /// 被授权人所属部门名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmbracerDept { get; set; }
        /// <summary>
        /// 是否是是最终被授权者。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 授权记录的创建时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 授权记录的起效时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime EffectTime { get; set; }
        /// <summary>
        /// 授权记录的失效时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime InvalidTime { get; set; }
        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsValid { get; set; }
        /// <summary>
        /// 授权人登录后授权记录自动失效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool LoginIsValid { get; set; }
        /// <summary>
        /// 授权原因。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Reason { get; set; }
        #endregion
    }
}
