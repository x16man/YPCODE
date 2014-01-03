// <copyright file="RoleRightInfo.cs" company="Shmzh Technology">
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
    public class RoleRightInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��.
        /// </summary>
        public RoleRightInfo()
        { }
        /// <summary>
        /// ��ɫȨ�޹��캯����
        /// </summary>
        /// <param name="roleCode">��ɫ��š�</param>
        /// <param name="rightCode">Ȩ�ޱ�š�</param>
        public RoleRightInfo(short roleCode, short rightCode)
        {
            this.RoleCode = roleCode;
            this.RightCode = rightCode;
        }
        #endregion

        #region Property
        /// <summary>
        /// �û���¼����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RoleCode { get; set; }

        /// <summary>
        /// ��ɫ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RightCode { get; set; }
        #endregion
    }
}
