// <copyright file="MenuTypeInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// �˵�����ʵ�塣
    /// </summary>
    [Serializable]
    public class MenuTypeInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public MenuTypeInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// �˵�����ID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ID { get; set; }

        /// <summary>
        /// �˵���������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// �Ƿ��ǿ��ʹ�õ����͡�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsUsedByFrameWork { get; set; }
        /// <summary>
        /// �˵����͵�˵����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
