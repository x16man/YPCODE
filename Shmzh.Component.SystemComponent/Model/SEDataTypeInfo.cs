// <copyright file="SEDataTypeInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ��ѯģ������������Ϣ��
    /// </summary>
    [Serializable]
    public class SEDataTypeInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public SEDataTypeInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ��ѯģ��ԭʼID��
        /// </summary>
        public int OldId { get; set; }
        /// <summary>
        /// ��ѯģ��Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// ��ѯģ�������������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        
        /// <summary>
        /// ��ѯģ���������͵ı�ע��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
