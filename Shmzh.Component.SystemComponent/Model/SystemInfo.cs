//-----------------------------------------------------------------------
// <copyright file="SystemInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;

	/// <summary>
	/// ProductInfo 的摘要说明。
	/// </summary>
	public class SystemInfo
    {
        private static SystemInfo instance;
        #region Feild
        private string sysName;
        private string sysVer;
        private DateTime createDate = DateTime.Now;
        private string copyRightBy;
        private string companyAdd;
        private string companyPost;
        private string contactTel;
        private string contactFax;
        private string contacter;
        private string isSecurity;
        #endregion

        #region Ctor
        /// <summary>
		/// 构造函数
		/// </summary>
		public SystemInfo()
		{
			System.Data.DataSet ds = new SystemDA().GetSystemInfo();
			if (ds != null)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					System.Data.DataRow dr = ds.Tables[0].Rows[0];
					this.SysName = dr["SysName"].ToString();
					this.sysVer = dr["SysVer"].ToString();
					this.createDate = DateTime.Parse(dr["CreateDate"].ToString());
					this.copyRightBy = dr["CopyRightBy"].ToString();
					this.companyAdd = dr["CompanyAdd"].ToString();
					this.companyPost = dr["CompanyPost"].ToString();
					this.contactTel = dr["ContactTel"].ToString();
					this.contactFax = dr["ContactFax"].ToString();
					this.contacter = dr["Contacter"].ToString();
					this.isSecurity = dr["IsSecurity"].ToString();
				}
			}
        }
        #endregion

        #region Property
        /// <summary>
		/// 系统名称
		/// </summary>
		public string SysName
        {
            get{return this.sysName;}
            set { sysName = value; }
        }

	    /// <summary>
		/// 系统版本
		/// </summary>
		public string SysVer
		{
			get{return this.sysVer;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateDate
		{
			get{return this.createDate;}
		}
		/// <summary>
		/// 版权
		/// </summary>
		public string CopyRightBy
		{
			get{return this.copyRightBy;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string CompanyAdd
		{
			get{return this.companyAdd;}
		}
		/// <summary>
		/// 邮编
		/// </summary>
		public string CompanyPost
		{
			get{return this.companyPost;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string ContactTel
		{
			get{return this.contactTel;}
		}
		/// <summary>
		/// 传真
		/// </summary>
		public string ContactFax
		{
			get{return this.contactFax;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string Contacter
		{
			get{return this.contacter;}
		}
		/// <summary>
		/// 是否安全
		/// </summary>
		public string IsSecurity
		{
			get{return this.isSecurity;}
        }
        #endregion

        
        /// <summary>
		/// 系统信息的全局访问点.
		/// </summary>
		/// <returns>SystemInfo</returns>
		public static SystemInfo Instance()
		{
			if (instance == null)
				instance = new SystemInfo();

			return instance;
		}
    }
}
