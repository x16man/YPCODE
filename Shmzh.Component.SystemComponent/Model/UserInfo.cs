//-----------------------------------------------------------------------
// <copyright file="UserInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
	/// <summary>
	/// �û���Ϣ��ʵ��.
	/// </summary>
	[Serializable]
	public class UserInfo 
	{
		/// <summary>
		/// UserInfo�Ĺ��캯��.
		/// </summary>
		public UserInfo()
		{
		}

		#region ����

	    /// <summary>
	    /// ����ID
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int PKID { get; set; }

	    /// <summary>
	    /// �û�����
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpCode { get; set; }
        /// <summary>
        /// ��˾����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpCo { get; set; }
        /// <summary>
        /// ���Ŵ���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptCode { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptName { get; set; }
	    /// <summary>
	    /// �û�����
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpName { get; set; }
        /// <summary>
        /// Ӣ�����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpEnName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Gender { get; set; }
        /// <summary>
        /// ����.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// ��¼��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string LoginName { get; set; }
        /// <summary>
        /// ����1��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Password1 { get; set; }
        /// <summary>
        /// ����2.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Password2 { get; set; }
        /// <summary>
        /// �����롣
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AppandCode { get; set; }
        /// <summary>
        /// ״̬.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpState { get; set; }
        /// <summary>
        /// ְ���š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyCode { get; set; }
	    /// <summary>
	    /// ְ����������
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyName { get; set; }
	    /// <summary>
	    /// ְ��Ӣ������.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyEnName { get; set; }
        /// <summary>
	    /// ���֤.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IDCard { get; set; }
        /// <summary>
	    /// �칫�绰.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OfficeCall { get; set; }
	    /// <summary>
	    /// �칫�绰�ֻ�����
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OfficeSubCall { get; set; }
        /// <summary>
        /// �����绰��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Tel
	    {
	        get
	        {
	            return string.IsNullOrEmpty(OfficeSubCall) ? OfficeCall : string.Format("{0}-{1}", OfficeCall, OfficeSubCall);
	        }
	    }
	    /// <summary>
	    /// �ֻ�����
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Mobile { get; set; }
        /// <summary>
	    /// �칫����
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OfficeFax { get; set; }
	    /// <summary>
	    /// ����.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EMail { get; set; }
        /// <summary>
        /// �Ƿ����û���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsUser { get; set; }
	    /// <summary>
	    /// �û�״̬.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserState { get; set; }
	    /// <summary>
	    /// �Ƿ���Ա��.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsEmp { get; set; }
        /// <summary>
        /// �������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// �������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime InDate { get; set; }
        /// <summary>
        /// �Ƿ���ְ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsLeave { get; set; }
        /// <summary>
        /// ��ְ���ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime LeaveDate { get; set; }
        /// <summary>
        ///  ˳��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int SerialNo { get; set; }
	    /// <summary>
		/// ��˾ȱʡΪYPWATER.
		/// </summary>
		[Obsolete("�������Ѿ���ʱ,������ʹ��!", true)] 
		public string Company
		{
			get {return "YPWATER";}
		}
        /// <summary>
        /// UICulture.
        /// </summary>
        public string UICulture { get; set; }

        /// <summary>
        /// ���ܹ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string SuperHrid { get; set; }
		#endregion
        /// <summary>
        /// ���ơ�
        /// </summary>
        /// <param name="userInfo">Ŀ���û�ʵ�塣</param>
        public void CopyTo(UserInfo userInfo)
        {
            userInfo.PKID = this.PKID;
            userInfo.EmpCode = this.EmpCode;
            userInfo.EmpCo = this.EmpCo;
            userInfo.DeptCode = this.DeptCode;
            userInfo.DeptName = this.DeptName;
            userInfo.EmpName = this.EmpName;
            userInfo.Gender = this.Gender;
            userInfo.BirthDay = this.BirthDay;
            userInfo.LoginName = this.LoginName;
            userInfo.Password1 = this.Password1;
            userInfo.Password2 = this.Password2;
            userInfo.AppandCode = this.AppandCode;
            userInfo.EmpState = this.EmpState;
            userInfo.DutyCode = this.DutyCode;
            userInfo.DutyName = this.DutyName;
            userInfo.DutyEnName = this.DutyEnName;
            userInfo.IDCard = this.IDCard;
            userInfo.OfficeCall = this.OfficeCall;
            userInfo.OfficeSubCall = this.OfficeSubCall;
            userInfo.Mobile = this.Mobile;
            userInfo.OfficeFax = this.OfficeFax;
            userInfo.EMail = this.EMail;
            userInfo.IsUser = this.IsUser;
            userInfo.UserState = this.UserState;
            userInfo.IsEmp = this.IsEmp;
            userInfo.CreateDate = this.CreateDate;
            userInfo.InDate = this.InDate;
            userInfo.IsLeave = this.IsLeave;
            userInfo.LeaveDate = this.LeaveDate;
            userInfo.UICulture = this.UICulture;
            userInfo.SuperHrid = this.SuperHrid;
        }

	    /// <summary>
        /// �ж����������Ƿ���ȡ�
        /// </summary>
        /// <param name="obj">�Ƚϵ�Ŀ�����</param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            return obj is UserInfo && this.PKID.Equals((obj as UserInfo).PKID);
        }
        /// <summary>
        /// ��ȡhash���롣
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.PKID.GetHashCode();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}{1}- PKID: {2}{1}- EmpCode: {3}{1}- EmpName: {4}{1}- LoginName: {5}{1}",
                                 this.GetType(),
                                 System.Environment.NewLine,
                                 this.PKID,
                                 this.EmpCode,
                                 this.EmpName,
                                 this.LoginName);
        }

	}
}
