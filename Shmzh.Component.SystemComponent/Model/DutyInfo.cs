// <copyright file="DutyInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;

    /// <summary>
	/// DutyInfoʵ�塣
	/// </summary>
	[SerializableAttribute] 
	public class DutyInfo
    {
        #region Property
        /// <summary>
		/// ��˾
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyCo { get; set; }
		/// <summary>
		/// ���
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyCode { get; set; }
		/// <summary>
		/// �ϼ�ְλ���
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentDutyCode { get; set; }
		/// <summary>
		/// ְλ����
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyCnName { get; set; }
		/// <summary>
		/// ְλ��������
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyEnName { get; set; }
		/// <summary>
		/// �Ƿ���Ч
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        /// <summary>
        /// ְ�񼶱�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short DutyLevel { get; set; }
		/// <summary>
		/// ����
		/// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion

        /// <summary>
		/// ���캯��
		/// </summary>
		public DutyInfo()
		{
			
		}
	}
}
