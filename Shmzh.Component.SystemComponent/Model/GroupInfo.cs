// <copyright file="GroupInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ����Ϣ
    /// </summary>
    [Serializable]
    public class GroupInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public GroupInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short GroupCode { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string GroupName { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short SerialNo { get; set; }
        /// <summary>
        /// �����Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short GroupCatId { get; set; }
        #endregion
    }
}
