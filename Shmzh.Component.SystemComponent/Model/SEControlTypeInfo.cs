// <copyright file="SEControlTypeInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ��ѯģ��ؼ�������Ϣ��
    /// </summary>
    [Serializable]
    public class SEControlTypeInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public SEControlTypeInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ��ѯģ��ؼ�����ԭʼID��
        /// </summary>
        public int OldId { get; set; }
        /// <summary>
        /// ��ѯģ��ؼ�����Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// ��ѯģ��ؼ��������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        
        /// <summary>
        /// ��ѯģ��ؼ����͵ı�ע��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
