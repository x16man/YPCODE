//-----------------------------------------------------------------------
// <copyright file="SystemInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;

	/// <summary>
	/// ProductInfo ��ժҪ˵����
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
		/// ���캯��
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
		/// ϵͳ����
		/// </summary>
		public string SysName
        {
            get{return this.sysName;}
            set { sysName = value; }
        }

	    /// <summary>
		/// ϵͳ�汾
		/// </summary>
		public string SysVer
		{
			get{return this.sysVer;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime CreateDate
		{
			get{return this.createDate;}
		}
		/// <summary>
		/// ��Ȩ
		/// </summary>
		public string CopyRightBy
		{
			get{return this.copyRightBy;}
		}
		/// <summary>
		/// ��ַ
		/// </summary>
		public string CompanyAdd
		{
			get{return this.companyAdd;}
		}
		/// <summary>
		/// �ʱ�
		/// </summary>
		public string CompanyPost
		{
			get{return this.companyPost;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string ContactTel
		{
			get{return this.contactTel;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string ContactFax
		{
			get{return this.contactFax;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string Contacter
		{
			get{return this.contacter;}
		}
		/// <summary>
		/// �Ƿ�ȫ
		/// </summary>
		public string IsSecurity
		{
			get{return this.isSecurity;}
        }
        #endregion

        
        /// <summary>
		/// ϵͳ��Ϣ��ȫ�ַ��ʵ�.
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
