// <copyright file="GroupUserInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// �û�����Ϣ��
    /// </summary>
    [Serializable]
    public class GroupUserInfo
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public GroupUserInfo()
        { }

        #region Property
        /// <summary>
        /// ����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short GroupCode { get; set; }

        /// <summary>
        /// �û�id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserCode { get; set; }
        #endregion
    }
}
