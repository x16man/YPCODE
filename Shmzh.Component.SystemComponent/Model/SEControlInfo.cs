// <copyright file="SEControlInfo.cs" company="Shmzh Technology">
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
    public class SEControlInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public SEControlInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ��ѯģ��ؼ�Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }
        /// <summary>
        /// ��ѯģ��ID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ModuleId { get; set; }
        /// <summary>
        /// ��ѯģ��ؼ���ǩ���ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string LabelName { get; set; }
        /// <summary>
        /// ��ѯģ��ؼ�����ID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ControlTypeId { get; set; }
        /// <summary>
        /// ��ѯ�ؼ���������ID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int DataTypeId { get; set; }
        /// <summary>
        /// ��ʾ���ֶΡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DataTextField { get; set; }
        /// <summary>
        /// ֵ���ֶΡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DataValueField { get; set; }
        /// <summary>
        /// ���ݰ󶨷�����װ�伯��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Assembly { get; set; }
        /// <summary>
        /// װ�伯�������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ObjType { get; set; }
        /// <summary>
        /// ���ݰ󶨷�����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Method { get; set; }
        /// <summary>
        /// ����ͼ���ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TableName { get; set; }
        /// <summary>
        /// �ֶ����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string FieldName { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Operator { get; set; }
        /// <summary>
        /// �Ƿ���Ч��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsValid { get; set; }
        /// <summary>
        /// ˳��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int SerialNo { get; set; }
        /// <summary>
        /// ��ѯģ��ؼ����͵ı�ע��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
