// <copyright file="SESchemaInfo.cs" company="Shmzh Technology">
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
    public class SESchemaInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public SESchemaInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ��ѯ����Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// ��ѯģ��ID.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ModuleId { get; set; }
        
        /// <summary>
        /// �û�����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserCode { get; set; }
        
        /// <summary>
        /// ��ѯ�������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string SchemaName { get; set; }
        
        /// <summary>
        /// Where��䲿�֡�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string WhereClause { get; set; }
        
        /// <summary>
        /// ��ѯ����������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// �Ƿ���Ĭ�ϲ�ѯ������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsDefault { get; set; }

        /// <summary>
        /// �������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateTime { get; set; }


        #endregion
    }
}
