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
	/// Users 的摘要说明。
	/// </summary>
	public class Users : Messages
	{	
		/// <summary>
		/// 构造函数
		/// </summary>
		public Users()
		{}

		/// <summary>
		/// 根据用户公司编号获取公司的所有用户.
		/// </summary>
		/// <param name="thisCompanyCode">用户的公司编号.</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllUsers(string thisCompanyCode)
		{
			var ds = new EntryUser();
			new UserDA().GetAllUsers(ds,thisCompanyCode);
			return ds;
		}
        /// <summary>
        /// 根据公司编号获取所有的内部用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>EntryUser。</returns>
        public EntryUser GetInnerUsers(string companyCode)
        {
            var ds = new EntryUser();
            new UserDA().GetInnerUsers(ds, companyCode);
            return ds;
        }
        /// <summary>
        /// 根据公司编号获取所有的用户和员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>EntryUser.</returns>
        public EntryUser GetAllUserAndEmp(string companyCode)
        {
            var ds = new EntryUser();
            new UserDA().GetAllUserAndEmp(ds, companyCode);
            return ds;
        }
        /// <summary>
        /// 根据公司编号获取所有内部的用户和员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>EntryUser。</returns>
        public EntryUser GetInnerUserAndEmp(string companyCode)
        {
            var ds = new EntryUser();
            new UserDA().GetInnerUserAndEmp(ds, companyCode);
            return ds;
        }
		/// <summary>
		/// 根据角色获取用户列表.
		/// </summary>
		/// <param name="thisCompanyCode">string:	单位代码.</param>
		/// <param name="roleID">int:	角色ID.</param>
		/// <returns>EntryUser:	用户实体.</returns>
		public EntryUser GetUserByRole(string thisCompanyCode,int roleID)
		{
			var ds = new EntryUser();
			new UserDA().GetUserByRole(ds, thisCompanyCode,roleID);
			return ds;
		}
		/// <summary>
		/// 设置密码.
		/// </summary>
		/// <param name="loginName">用户名.</param>
		/// <param name="pwd">密码</param>
		/// <returns>bool</returns>
		public bool SetPassword(string loginName, string pwd)
		{
			var salt = this.CreateSalt();//随机产生一个附加码。
			pwd = this.CreatePasswordHash(pwd,salt);//thisPassword+thisSalt=>SHA1 hash.
			
			return new UserDA().SetPassword(loginName, pwd, salt);
		}
		/// <summary>
		/// 根据PKID设置密码
		/// </summary>
		/// <param name="pkID">用户的PKID</param>
		/// <param name="thisPassword">密码</param>
		/// <returns>bool</returns>
		public bool SetPasswordByPKID(int pkID, string thisPassword)
		{
			var thisSalt = this.CreateSalt();
			thisPassword = this.CreatePasswordHash(thisPassword,thisSalt);
			
			return new UserDA().SetPasswordByPKID(pkID,thisPassword,thisSalt);
		}
		/// <summary>
		/// 禁用用户
		/// </summary>
		/// <param name="userName">用户名</param>
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
		/// 根据用户PKID禁用用户.
		/// </summary>
		/// <param name="pkid">用户的PKID</param>
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
		/// 启用用户
		/// </summary>
		/// <param name="userCode">用户名</param>
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
		/// 启用用户根据用户的PKID
		/// </summary>
		/// <param name="pkid">用户的PKID</param>
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
		/// 根据用户名和产品代码删除用户角色.
		/// </summary>
		/// <param name="userCode">用户名</param>
		/// <param name="productCode">产品代码</param>
		/// <returns>bool</returns>
		public bool DeleteUserRoles(string userCode, int productCode)
		{
            if (string.IsNullOrEmpty(userCode))
            {
                throw new ArgumentNullException("userCode", "请指定userCode参数。");
            }
			var rda = new UserDA();
			var flag = true;
			if (!rda.DeleteUserRoles(userCode, productCode))
			{
				Message = "删除用户角色失败，请查看Log。";
				flag = false;
			}
			return flag;
		}
		/// <summary>
		/// 删除用户角色
		/// </summary>
		/// <param name="userCode">用户名</param>
		/// <param name="checkCode">知识库中的知识文章的ID或知识目录的ID,其他系统为产品代码.</param>
		/// <param name="type">文章或目录</param>
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
		/// 清除访问权限.
		/// </summary>
		/// <param name="checkCode">CheckCode</param>
		/// <param name="type">类型</param>
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
		/// 得到没有此权限的用户角色信息
		/// </summary>
		/// <param name="rightCode">权限编号</param>
		/// <param name="productcode">产品编号</param>
		/// <returns>DataSet</returns>
		public DataSet GetNoAccessObj(int rightCode,int productcode)
		{
			return new UserDA().GetNoAccessObj(rightCode,productcode);	
		}
		#region "密码部分"
		/// <summary>
		/// 生成密码哈希时需要的附加码,随机产生
		/// </summary>
		/// <returns>附加码</returns>
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
		/// 生成经过哈希处理过的口令
		/// </summary>
		/// <param name="pwd">密码明文</param>
		/// <param name="salt">附加码</param>
		/// <returns>哈希后的口令</returns>
 		public string CreatePasswordHash(string pwd, string salt)
		{
			// Concat the raw password and salt value
			var saltAndPwd = String.Concat(pwd, salt);
			
            // Hash the salted password
			var hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(
				saltAndPwd, "SHA1");//"SHA1":安全哈希算法 1.可选还有md5：消息摘要 5 (MD5)
			return hashedPwd;
		}
		#endregion
		/// <summary>
		/// 改变口令
		/// </summary>
		/// <param name="thisUserName">用户名</param>
		/// <param name="oldPassword">旧口令</param>
		/// <param name="newPassword">新口令</param>
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
		        this.Message = "原来密码有误,请重新输入!";
		    }
		    return ret;
		}
		/// <summary>
		/// 根据用户名判断用户是否存在
		/// </summary>
		/// <param name="loginName">用户名</param>
		/// <returns>是否成功</returns>
		public bool IsExistUser(string loginName)
		{
            var sqlStatement = string.Format("Select Count(*) From mySystemUserInfo Where LoginName='{0}'",loginName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// 根据用户名或姓名、部门名称查询用户。
		/// </summary>
		/// <param name="userName">用户名、姓名、部门名称。</param>
        /// <param name="companyCode">公司编号</param>
		/// <returns>DataSet</returns>
		public DataSet SearchUser(string userName,string companyCode)
		{
			var sqlStatement = string.Format("SELECT * FROM mySystemUserInfo WHERE IsUser = 'Y' And (LoginName like '%{0}%' OR EmpCnname like '%{0}%' OR DeptCnName like '%{0}%') And EmpCo='{1}'",userName, companyCode) ;
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
        /// <summary>
        /// 根据用户名或姓名、部门名称查询人员。
        /// </summary>
        /// <param name="userName">用户名、姓名、部门名称。</param>
        /// <param name="companyCode">公司编号</param>
        /// <returns>DataSet</returns>
        public DataSet SearchEmp(string userName, string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemUserInfo WHERE (LoginName like '%{0}%' OR EmpCnname like '%{0}%' OR DeptCnName like '%{0}%') And EmpCo='{1}'", userName, companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
		/// 根据用户名和PKID判断是否存在该用户名.
		/// </summary>
		/// <param name="loginName">用户名</param>
		/// <param name="pkid">PKID</param>
		/// <returns>bool</returns>
		/// <remarks>是不等于指定PKID</remarks>
		public bool IsExistUser(string loginName,int pkid)
		{
            var sqlStatement = string.Format("Select Count(*) From mySystemUserInfo Where LoginName='{0}' And PKID<>{1}", loginName,pkid);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
	}
}
