// <copyright file="GroupInfo.cs" company="Shmzh Technology">
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
    public class UserRoleInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserRoleInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 用户登录名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserName { get; set; }

        /// <summary>
        /// 角色编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RoleCode { get; set; }

        /// <summary>
        /// 文章或目录的ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckCode { get; set; }
        
        /// <summary>
        /// 类型（文章或类型）。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Type { get; set; } 
        #endregion

        public override bool Equals(object obj)
        {
            if(obj is UserRoleInfo)
            {
                var userRoleInfo = obj as UserRoleInfo;
                return this.UserName.Equals(userRoleInfo.UserName)
                       && this.RoleCode.Equals(userRoleInfo.RoleCode)
                       && this.CheckCode.Equals(userRoleInfo.CheckCode)
                       && this.Type.Equals(userRoleInfo.Type);
            }
            else
            {
                return false;
            }
        }
    }
}
