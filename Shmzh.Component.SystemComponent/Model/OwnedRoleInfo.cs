// <copyright file="OwnedRoleInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ��ɫ����ʶ���Ĺ�ϵʵ�塣
    /// </summary>
    /// <remarks>��ҪΪ֪ʶ�����ã�֪ʶ����Ŀ�ͽ�ɫ֮��Ĺ�ϵ��</remarks>
    [Serializable]
    public class OwnedRoleInfo
    {
        #region CTOR
        /// <summary>
        /// ���캯����
        /// </summary>
        public OwnedRoleInfo()
        {
        }
        /// <summary>
        /// ���캯����
        /// </summary>
        /// <param name="roleCode">��ɫ��š�</param>
        /// <param name="checkCode">֪ʶ����ĿID��</param>
        /// <param name="type">֪ʶ����Ŀ���͡�</param>
        public OwnedRoleInfo(short roleCode, string checkCode, string type)
        {
            this.RoleCode = roleCode;
            this.CheckCode = checkCode;
            this.Type = type;
        }
        #endregion

        #region Property
        /// <summary>
        /// ��ɫ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RoleCode { get; set; }
        /// <summary>
        /// ֪ʶ����ĿID(��KMϵͳ������)��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckCode { get; set; }
        /// <summary>
        /// ֪ʶ����Ŀ����(��KMϵͳ������)
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Type { get; set; }
        #endregion
    }
}
