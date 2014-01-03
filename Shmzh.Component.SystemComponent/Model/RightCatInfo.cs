// <copyright file="RightCatInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// Ȩ�޷�����Ϣ
    /// </summary>
    [Serializable]
    public class RightCatInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public RightCatInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// Ȩ�޷����š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }

        /// <summary>
        /// Ȩ�޷������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// Ȩ�޷���������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Desc { get; set; }
        /// <summary>
        /// Ȩ�޷���������Ʒ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }
        /// <summary>
        /// Ȩ�޷����Ƿ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        #endregion
    }
}
