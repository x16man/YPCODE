// <copyright file="ProductInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 产品信息对象.
    /// </summary>
    /// <remarks>对应于数据库PubData库中mySystemProducts表的记录.</remarks>
    [Serializable]
    public class ProductInfo
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProductInfo()
        {
            Remark = string.Empty;
            IsValid = "Y";
            ProductName = string.Empty;
        }

        /// <summary>
        /// 产品信息的构造函数.
        /// </summary>
        /// <param name="productCode">int:	产品编号</param>
        /// <param name="productName">string:产品名称</param>
        public ProductInfo(short productCode, string productName)
            : this(productCode, productName, "Y", string.Empty)
        {
        }
        /// <summary>
        /// 产品信息的构造函数
        /// </summary>
        /// <param name="productCode">int:产品编号</param>
        /// <param name="productName">string:产品名称</param>
        /// <param name="isValid">string:是否有效</param>
        /// <param name="remark">string:产品描述</param>
        public ProductInfo(short productCode, string productName, string isValid, string remark)
        {
            this.ProductCode = productCode;
            this.ProductName = productName;
            this.IsValid = isValid;
            this.Remark = remark;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 产品编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ProductName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        /// <summary>
        /// 注册码。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string License { get; set; }
        #endregion
    }
}
