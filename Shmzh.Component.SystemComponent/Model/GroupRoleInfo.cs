// <copyright file="GroupRoleInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ���ɫ��Ϣ��
    /// </summary>
    [Serializable]
    public class GroupRoleInfo
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public GroupRoleInfo()
        { }
        /// <summary>
        /// ����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int GroupCode { get; set; }

        /// <summary>
        /// ��ɫ���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int RoleCode { get; set; }

        /// <summary>
        /// checkcode
        /// </summary>
        /// <remarks>֪ʶ������</remarks>
        [Bindable(BindableSupport.Yes)]
        public string CheckCode { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        /// /// <remarks>֪ʶ������</remarks>
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
