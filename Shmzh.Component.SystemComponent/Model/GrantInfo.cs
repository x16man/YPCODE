// <copyright file="GrantInfo.cs" company="Shmzh Technology">
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
    public class GrantInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public GrantInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// PKID
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long ID { get; set; }
        /// <summary>
        /// ��Ȩ���û�����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Grantor { get; set; }
        /// <summary>
        /// ��Ȩ������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string GrantorName { get; set; }
        /// <summary>
        /// ��Ȩ�������������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string GrantorDept { get; set; }
        /// <summary>
        /// ����Ȩ���û�����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Embracer { get; set; }
        /// <summary>
        /// ����Ȩ��������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmbracerName { get; set; }
        /// <summary>
        /// ����Ȩ�������������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmbracerDept { get; set; }
        /// <summary>
        /// �Ƿ��������ձ���Ȩ�ߡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsLeaf { get; set; }
        /// <summary>
        /// ��Ȩ��¼�Ĵ���ʱ�䡣
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ��Ȩ��¼����Чʱ�䡣
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime EffectTime { get; set; }
        /// <summary>
        /// ��Ȩ��¼��ʧЧʱ�䡣
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime InvalidTime { get; set; }
        /// <summary>
        /// �Ƿ���Ч��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsValid { get; set; }
        /// <summary>
        /// ��Ȩ�˵�¼����Ȩ��¼�Զ�ʧЧ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool LoginIsValid { get; set; }
        /// <summary>
        /// ��Ȩԭ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Reason { get; set; }
        #endregion
    }
}
