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
	/// 用户信息的实体.
	/// </summary>
	[Serializable]
	public class UserInfo 
	{
		/// <summary>
		/// UserInfo的构造函数.
		/// </summary>
		public UserInfo()
		{
		}

		#region 属性

	    /// <summary>
	    /// 主键ID
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int PKID { get; set; }

	    /// <summary>
	    /// 用户工号
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpCode { get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpCo { get; set; }
        /// <summary>
        /// 部门代码
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptCode { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptName { get; set; }
	    /// <summary>
	    /// 用户姓名
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpName { get; set; }
        /// <summary>
        /// 英文名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpEnName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Gender { get; set; }
        /// <summary>
        /// 生日.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string LoginName { get; set; }
        /// <summary>
        /// 密码1。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Password1 { get; set; }
        /// <summary>
        /// 密码2.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Password2 { get; set; }
        /// <summary>
        /// 附加码。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AppandCode { get; set; }
        /// <summary>
        /// 状态.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EmpState { get; set; }
        /// <summary>
        /// 职务编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyCode { get; set; }
	    /// <summary>
	    /// 职务中文名称
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyName { get; set; }
	    /// <summary>
	    /// 职务英文名称.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DutyEnName { get; set; }
        /// <summary>
	    /// 身份证.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IDCard { get; set; }
        /// <summary>
	    /// 办公电话.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OfficeCall { get; set; }
	    /// <summary>
	    /// 办公电话分机号码
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OfficeSubCall { get; set; }
        /// <summary>
        /// 完整电话。
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
	    /// 手机号码
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Mobile { get; set; }
        /// <summary>
	    /// 办公传真
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OfficeFax { get; set; }
	    /// <summary>
	    /// 电邮.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EMail { get; set; }
        /// <summary>
        /// 是否是用户。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsUser { get; set; }
	    /// <summary>
	    /// 用户状态.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserState { get; set; }
	    /// <summary>
	    /// 是否是员工.
	    /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsEmp { get; set; }
        /// <summary>
        /// 创建日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 进厂日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime InDate { get; set; }
        /// <summary>
        /// 是否离职。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsLeave { get; set; }
        /// <summary>
        /// 离职日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime LeaveDate { get; set; }
        /// <summary>
        ///  顺序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int SerialNo { get; set; }
	    /// <summary>
		/// 公司缺省为YPWATER.
		/// </summary>
		[Obsolete("该属性已经过时,请勿再使用!", true)] 
		public string Company
		{
			get {return "YPWATER";}
		}
        /// <summary>
        /// UICulture.
        /// </summary>
        public string UICulture { get; set; }

        /// <summary>
        /// 主管工号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string SuperHrid { get; set; }
		#endregion
        /// <summary>
        /// 复制。
        /// </summary>
        /// <param name="userInfo">目标用户实体。</param>
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
        /// 判断两个对象是否相等。
        /// </summary>
        /// <param name="obj">比较的目标对象。</param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            return obj is UserInfo && this.PKID.Equals((obj as UserInfo).PKID);
        }
        /// <summary>
        /// 获取hash代码。
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
