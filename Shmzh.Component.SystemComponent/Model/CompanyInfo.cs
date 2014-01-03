// <copyright file="CompanyInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;

    /// <summary>
	/// CompanyInfo ��ժҪ˵����
	/// </summary>
	[SerializableAttribute] 
	public class CompanyInfo
    {
        #region Property
        /// <summary>
		/// ��˾���
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoCode { get; set; }

        /// <summary>
		/// ��˾����
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoName { get; set; }
		/// <summary>
		/// ��˾Ӣ������
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoEnName { get; set; }
		/// <summary>
		/// ��˾���
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoShortName { get; set; }
		/// <summary>
		/// �ϼ���˾���
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentCo { get; set; }
		/// <summary>
		/// �ϼ���˾����
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentCoName { get; set; }
		/// <summary>
		/// ���˴���
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ArtificialPerson{get; set;}
        /// <summary>
		/// �ܾ���
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Mgr { get; set; }
		/// <summary>
		/// ��Ӫ���֤
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string BussinessLicense { get; set; }
		/// <summary>
		/// ��Ӫ��Χ
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string BussinessRange { get; set; }
		/// <summary>
		/// ��˾����
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoArea { get; set; }
		/// <summary>
		/// ��˾��ַ
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CoAddress { get; set; }
        /// <summary>
		/// �Ƿ���Ч
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
		/// <summary>
		/// ����
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
		/// <summary>
		/// �Ƿ���ȱʡ��.
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsDefault { get; set; }

        #endregion

        /// <summary>
		/// ���캯��
		/// </summary>
		public CompanyInfo()
		{
		}
	}
}
