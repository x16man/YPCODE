// <copyright file="GroupUserInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 用户组信息类
    /// </summary>
    [Serializable]
    public class GroupUserInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public GroupUserInfo()
        { }

        #region Property
        /// <summary>
        /// 组编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short GroupCode { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserCode { get; set; }
        #endregion
    }
}
