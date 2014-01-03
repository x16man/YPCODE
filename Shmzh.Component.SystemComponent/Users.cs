//-----------------------------------------------------------------------
// <copyright file="Users.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Shmzh.Components.SystemComponent.Enum;

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Security.Cryptography;
    using System.Web.Security;
    /// <summary>
	/// Users ��ժҪ˵����
	/// </summary>
	public class Users : Messages
	{	
		/// <summary>
		/// ���캯��
		/// </summary>
		public Users()
		{}

		/// <summary>
		/// �����û���˾��Ż�ȡ��˾�������û�.
		/// </summary>
		/// <param name="thisCompanyCode">�û��Ĺ�˾���.</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllUsers(string thisCompanyCode)
		{
			var ds = new EntryUser();
			new UserDA().GetAllUsers(ds,thisCompanyCode);
			return ds;
		}
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ���е��ڲ��û���
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>EntryUser��</returns>
        public EntryUser GetInnerUsers(string companyCode)
        {
            var ds = new EntryUser();
            new UserDA().GetInnerUsers(ds, companyCode);
            return ds;
        }
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ���е��û���Ա����
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>EntryUser.</returns>
        public EntryUser GetAllUserAndEmp(string companyCode)
        {
            var ds = new EntryUser();
            new UserDA().GetAllUserAndEmp(ds, companyCode);
            return ds;
        }
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ�����ڲ����û���Ա����
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>EntryUser��</returns>
        public EntryUser GetInnerUserAndEmp(string companyCode)
        {
            var ds = new EntryUser();
            new UserDA().GetInnerUserAndEmp(ds, companyCode);
            return ds;
        }
		/// <summary>
		/// ���ݽ�ɫ��ȡ�û��б�.
		/// </summary>
		/// <param name="thisCompanyCode">string:	��λ����.</param>
		/// <param name="roleID">int:	��ɫID.</param>
		/// <returns>EntryUser:	�û�ʵ��.</returns>
		public EntryUser GetUserByRole(string thisCompanyCode,int roleID)
		{
			var ds = new EntryUser();
			new UserDA().GetUserByRole(ds, thisCompanyCode,roleID);
			return ds;
		}
		/// <summary>
		/// ��������.
		/// </summary>
		/// <param name="loginName">�û���.</param>
		/// <param name="pwd">����</param>
		/// <returns>bool</returns>
		public bool SetPassword(string loginName, string pwd)
		{
			var salt = this.CreateSalt();//�������һ�������롣
			pwd = this.CreatePasswordHash(pwd,salt);//thisPassword+thisSalt=>SHA1 hash.
			
			return new UserDA().SetPassword(loginName, pwd, salt);
		}
		/// <summary>
		/// ����PKID��������
		/// </summary>
		/// <param name="pkID">�û���PKID</param>
		/// <param name="thisPassword">����</param>
		/// <returns>bool</returns>
		public bool SetPasswordByPKID(int pkID, string thisPassword)
		{
			var thisSalt = this.CreateSalt();
			thisPassword = this.CreatePasswordHash(thisPassword,thisSalt);
			
			return new UserDA().SetPasswordByPKID(pkID,thisPassword,thisSalt);
		}
		/// <summary>
		/// �����û�
		/// </summary>
		/// <param name="userName">�û���</param>
		/// <returns>bool</returns>
		public bool DisableUser(string userName)
		{
			var obj = new UserDA();
			bool ret = true;

			if (!obj.DisableUser(userName,UserStateEnum.UNACTIVED))
			{
				this.Message = "Please look log";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �����û�PKID�����û�.
		/// </summary>
		/// <param name="pkid">�û���PKID</param>
		/// <returns>bool</returns>
		public bool DisableUserByPKID(int pkid)
		{
			var obj = new UserDA();
			var ret = true;

			if (!obj.SetUserState(pkid,UserStateEnum.UNACTIVED))
			{
				this.Message = "Please look log";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �����û�
		/// </summary>
		/// <param name="userCode">�û���</param>
		/// <returns>bool</returns>
		public bool EnableUser(string userCode)
		{
			var obj = new UserDA();
			bool ret = true;

			if (!obj.DisableUser(userCode,UserStateEnum.ACTIVED))
			{
				this.Message = "Please look log";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �����û������û���PKID
		/// </summary>
		/// <param name="pkid">�û���PKID</param>
		/// <returns>bool</returns>
		public bool EnableUserByPKID(int pkid)
		{
			var obj = new UserDA();
			var ret = true;

			if (!obj.SetUserState(pkid,UserStateEnum.ACTIVED))
			{
				this.Message = "Please look log";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �����û����Ͳ�Ʒ����ɾ���û���ɫ.
		/// </summary>
		/// <param name="userCode">�û���</param>
		/// <param name="productCode">��Ʒ����</param>
		/// <returns>bool</returns>
		public bool DeleteUserRoles(string userCode, int productCode)
		{
            if (string.IsNullOrEmpty(userCode))
            {
                throw new ArgumentNullException("userCode", "��ָ��userCode������");
            }
			var rda = new UserDA();
			var flag = true;
			if (!rda.DeleteUserRoles(userCode, productCode))
			{
				Message = "ɾ���û���ɫʧ�ܣ���鿴Log��";
				flag = false;
			}
			return flag;
		}
		/// <summary>
		/// ɾ���û���ɫ
		/// </summary>
		/// <param name="userCode">�û���</param>
		/// <param name="checkCode">֪ʶ���е�֪ʶ���µ�ID��֪ʶĿ¼��ID,����ϵͳΪ��Ʒ����.</param>
		/// <param name="type">���»�Ŀ¼</param>
		/// <returns>bool</returns>
		public bool DeleteUserRoles(string userCode,string checkCode,string type)
		{
			var obj = new UserDA();

		    if (obj.DeleteUserRoles(userCode, checkCode, type))
		    {
		        return true;
		    }
		    this.Message = "Please look log";
		    return false;
		}
		/// <summary>
		/// �������Ȩ��.
		/// </summary>
		/// <param name="checkCode">CheckCode</param>
		/// <param name="type">����</param>
		/// <returns>bool</returns>
		public bool ClearAccess(string checkCode,string type)
		{
			var obj = new UserDA();
			var ret = true;

			if (!obj.ClearAccess(checkCode,type))
			{
				this.Message = "Please look log";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �õ�û�д�Ȩ�޵��û���ɫ��Ϣ
		/// </summary>
		/// <param name="rightCode">Ȩ�ޱ��</param>
		/// <param name="productcode">��Ʒ���</param>
		/// <returns>DataSet</returns>
		public DataSet GetNoAccessObj(int rightCode,int productcode)
		{
			return new UserDA().GetNoAccessObj(rightCode,productcode);	
		}
		#region "���벿��"
		/// <summary>
		/// ���������ϣʱ��Ҫ�ĸ�����,�������
		/// </summary>
		/// <returns>������</returns>
		public string CreateSalt()
		{
			// Generate a cryptographic random number using the cryptographic
			// service provider
			var rng = new RNGCryptoServiceProvider();
			var buff = new byte[128];
			rng.GetBytes(buff);
			
            // Return a Base64 string representation of the random number
			return Convert.ToBase64String(buff);
		}

		/// <summary>
		/// ���ɾ�����ϣ������Ŀ���
		/// </summary>
		/// <param name="pwd">��������</param>
		/// <param name="salt">������</param>
		/// <returns>��ϣ��Ŀ���</returns>
 		public string CreatePasswordHash(string pwd, string salt)
		{
			// Concat the raw password and salt value
			var saltAndPwd = String.Concat(pwd, salt);
			
            // Hash the salted password
			var hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(
				saltAndPwd, "SHA1");//"SHA1":��ȫ��ϣ�㷨 1.��ѡ����md5����ϢժҪ 5 (MD5)
			return hashedPwd;
		}
		#endregion
		/// <summary>
		/// �ı����
		/// </summary>
		/// <param name="thisUserName">�û���</param>
		/// <param name="oldPassword">�ɿ���</param>
		/// <param name="newPassword">�¿���</param>
		/// <returns>bool</returns>
		public bool ChangePassword(string thisUserName, string oldPassword, string newPassword)
		{
			bool ret;

		    if (new UserDA().UserLogin(thisUserName, oldPassword))
		    {
		        ret = this.SetPassword(thisUserName, newPassword);
		    }
		    else
		    {
		        ret = false;
		        this.Message = "ԭ����������,����������!";
		    }
		    return ret;
		}
		/// <summary>
		/// �����û����ж��û��Ƿ����
		/// </summary>
		/// <param name="loginName">�û���</param>
		/// <returns>�Ƿ�ɹ�</returns>
		public bool IsExistUser(string loginName)
		{
            var sqlStatement = string.Format("Select Count(*) From mySystemUserInfo Where LoginName='{0}'",loginName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// �����û������������������Ʋ�ѯ�û���
		/// </summary>
		/// <param name="userName">�û������������������ơ�</param>
        /// <param name="companyCode">��˾���</param>
		/// <returns>DataSet</returns>
		public DataSet SearchUser(string userName,string companyCode)
		{
			var sqlStatement = string.Format("SELECT * FROM mySystemUserInfo WHERE IsUser = 'Y' And (LoginName like '%{0}%' OR EmpCnname like '%{0}%' OR DeptCnName like '%{0}%') And EmpCo='{1}'",userName, companyCode) ;
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
        /// <summary>
        /// �����û������������������Ʋ�ѯ��Ա��
        /// </summary>
        /// <param name="userName">�û������������������ơ�</param>
        /// <param name="companyCode">��˾���</param>
        /// <returns>DataSet</returns>
        public DataSet SearchEmp(string userName, string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemUserInfo WHERE (LoginName like '%{0}%' OR EmpCnname like '%{0}%' OR DeptCnName like '%{0}%') And EmpCo='{1}'", userName, companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
		/// �����û�����PKID�ж��Ƿ���ڸ��û���.
		/// </summary>
		/// <param name="loginName">�û���</param>
		/// <param name="pkid">PKID</param>
		/// <returns>bool</returns>
		/// <remarks>�ǲ�����ָ��PKID</remarks>
		public bool IsExistUser(string loginName,int pkid)
		{
            var sqlStatement = string.Format("Select Count(*) From mySystemUserInfo Where LoginName='{0}' And PKID<>{1}", loginName,pkid);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
	}
}
