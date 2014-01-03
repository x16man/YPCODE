// <copyright file="GroupInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ������Ϣʵ�塣
    /// </summary>
    [Serializable]
    public class OrgTypeInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public OrgTypeInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Level { get; set; }
        /// <summary>
        /// �������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CnName { get; set; }
        /// <summary>
        /// Ӣ�����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EnName { get; set; }
        /// <summary>
        /// �Ƿ���Ч��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        #endregion
    }
}
