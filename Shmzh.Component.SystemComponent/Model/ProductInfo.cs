// <copyright file="ProductInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ��Ʒ��Ϣ����.
    /// </summary>
    /// <remarks>��Ӧ�����ݿ�PubData����mySystemProducts��ļ�¼.</remarks>
    [Serializable]
    public class ProductInfo
    {
        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public ProductInfo()
        {
            Remark = string.Empty;
            IsValid = "Y";
            ProductName = string.Empty;
        }

        /// <summary>
        /// ��Ʒ��Ϣ�Ĺ��캯��.
        /// </summary>
        /// <param name="productCode">int:	��Ʒ���</param>
        /// <param name="productName">string:��Ʒ����</param>
        public ProductInfo(short productCode, string productName)
            : this(productCode, productName, "Y", string.Empty)
        {
        }
        /// <summary>
        /// ��Ʒ��Ϣ�Ĺ��캯��
        /// </summary>
        /// <param name="productCode">int:��Ʒ���</param>
        /// <param name="productName">string:��Ʒ����</param>
        /// <param name="isValid">string:�Ƿ���Ч</param>
        /// <param name="remark">string:��Ʒ����</param>
        public ProductInfo(short productCode, string productName, string isValid, string remark)
        {
            this.ProductCode = productCode;
            this.ProductName = productName;
            this.IsValid = isValid;
            this.Remark = remark;
        }
        #endregion

        #region ����

        /// <summary>
        /// ��Ʒ���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ProductName { get; set; }

        /// <summary>
        /// �Ƿ���Ч
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        /// <summary>
        /// ע���롣
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string License { get; set; }
        #endregion
    }
}
