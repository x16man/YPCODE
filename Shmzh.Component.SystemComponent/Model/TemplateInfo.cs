// <copyright file="OnlineStatus.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ģ���¼ʵ�塣
    /// </summary>
    [Serializable]
    public class TemplateInfo
    {
        #region Constructor
        ///<summary>
        /// Ĭ�Ϲ��캯����
        ///</summary>
        public TemplateInfo()
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="id">ģ��ID��</param>
        /// <param name="productCode">��ƷID��</param>
        /// <param name="code">ģ���š�</param>
        /// <param name="name">ģ�����ơ�</param>
        /// <param name="content">ģ�����ݡ�</param>
        /// <param name="remark">ģ�屸ע��</param>
        public TemplateInfo(int id,short productCode, string code, string name, string content, string remark)
        {
            this.ID = id;
            this.ProductCode = productCode;
            this.Code = code;
            this.Name = name;
            this.Content = content;
            this.Remark = remark;
        }
        
        #endregion

        #region Property
        /// <summary>
        /// ģ��ID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ID { get; set; }
        /// <summary>
        /// ��ƷID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }
        /// <summary>
        /// ģ���š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }
        /// <summary>
        /// ģ�����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// IP��ַ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Content { get; set; }

        /// <summary>
        /// ����״̬
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        #endregion
    }
}
