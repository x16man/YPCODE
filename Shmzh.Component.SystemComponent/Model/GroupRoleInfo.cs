// <copyright file="GroupRoleInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 组角色信息类
    /// </summary>
    [Serializable]
    public class GroupRoleInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public GroupRoleInfo()
        { }
        /// <summary>
        /// 组编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int GroupCode { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int RoleCode { get; set; }

        /// <summary>
        /// checkcode
        /// </summary>
        /// <remarks>知识管理部分</remarks>
        [Bindable(BindableSupport.Yes)]
        public string CheckCode { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        /// /// <remarks>知识管理部分</remarks>
        [Bindable(BindableSupport.Yes)]
        public string Type { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is GroupRoleInfo)
            {
                var groupRoleInfo = obj as GroupRoleInfo;
                return this.GroupCode.Equals(groupRoleInfo.GroupCode)
                       && this.RoleCode.Equals(groupRoleInfo.RoleCode)
                       && this.CheckCode.Equals(groupRoleInfo.CheckCode)
                       && this.Type.Equals(groupRoleInfo.Type);
            }
            else
            {
                return false;
            }
        }
    }
}
