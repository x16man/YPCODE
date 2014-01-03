// <copyright file="GroupCatInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// �������Ϣ
    /// </summary>
    [Serializable]
    public class GroupCatInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public GroupCatInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// �����Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Id { get; set; }

        /// <summary>
        /// ��������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// �����������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short SerialNo { get; set; }


        #endregion
    }
}
