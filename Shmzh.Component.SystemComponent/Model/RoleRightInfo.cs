// <copyright file="RoleRightInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 用户角色信息。
    /// </summary>
    [Serializable]
    public class RoleRightInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数.
        /// </summary>
        public RoleRightInfo()
        { }
        /// <summary>
        /// 角色权限构造函数。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <param name="rightCode">权限编号。</param>
        public RoleRightInfo(short roleCode, short rightCode)
        {
            this.RoleCode = roleCode;
            this.RightCode = rightCode;
        }
        #endregion

        #region Property
        /// <summary>
        /// 用户登录名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RoleCode { get; set; }

        /// <summary>
        /// 角色编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RightCode { get; set; }
        #endregion
    }
}
