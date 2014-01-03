// <copyright file="DutyInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;

    /// <summary>
	/// DutyInfo实体。
	/// </summary>
	[SerializableAttribute] 
	public class DutyInfo
    {
        #region Property
        /// <summary>
		/// 公司
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyCo { get; set; }
		/// <summary>
		/// 编号
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyCode { get; set; }
		/// <summary>
		/// 上级职位编号
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentDutyCode { get; set; }
		/// <summary>
		/// 职位名称
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyCnName { get; set; }
		/// <summary>
		/// 职位中文名称
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyEnName { get; set; }
		/// <summary>
		/// 是否有效
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        /// <summary>
        /// 职务级别。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short DutyLevel { get; set; }
		/// <summary>
		/// 描述
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion

        /// <summary>
		/// 构造函数
		/// </summary>
		public DutyInfo()
		{
			
		}
	}
}
