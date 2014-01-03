// <copyright file="GroupInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// �û���ɫ��Ϣ��
    /// </summary>
    [Serializable]
    public class UserRoleInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public UserRoleInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// �û���¼����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserName { get; set; }

        /// <summary>
        /// ��ɫ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RoleCode { get; set; }

        /// <summary>
        /// ���»�Ŀ¼��ID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckCode { get; set; }
        
        /// <summary>
        /// ���ͣ����»����ͣ���
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
