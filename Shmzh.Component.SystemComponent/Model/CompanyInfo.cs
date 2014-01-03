// <copyright file="CompanyInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;

    /// <summary>
	/// CompanyInfo 的摘要说明。
	/// </summary>
	[SerializableAttribute] 
	public class CompanyInfo
    {
        #region Property
        /// <summary>
		/// 公司编号
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoCode { get; set; }

        /// <summary>
		/// 公司名称
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoName { get; set; }
		/// <summary>
		/// 公司英文名称
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoEnName { get; set; }
		/// <summary>
		/// 公司简称
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoShortName { get; set; }
		/// <summary>
		/// 上级公司编号
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentCo { get; set; }
		/// <summary>
		/// 上级公司名称
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentCoName { get; set; }
		/// <summary>
		/// 法人代表。
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ArtificialPerson{get; set;}
        /// <summary>
		/// 总经理
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Mgr { get; set; }
		/// <summary>
		/// 经营许可证
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string BussinessLicense { get; set; }
		/// <summary>
		/// 经营范围
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string BussinessRange { get; set; }
		/// <summary>
		/// 公司区域
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoArea { get; set; }
		/// <summary>
		/// 公司地址
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoAddress { get; set; }
        /// <summary>
		/// 是否有效
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
		/// <summary>
		/// 描述
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
		/// <summary>
		/// 是否是缺省的.
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsDefault { get; set; }

        #endregion

        /// <summary>
		/// 构造函数
		/// </summary>
		public CompanyInfo()
		{
		}
	}
}
