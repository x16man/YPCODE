//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Security;
    using Shmzh.Components.SystemComponent.DALFactory;

	/// <summary>
	/// User用户的摘要说明。
	/// </summary>
	[Serializable]
	public class User
	{
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	    
        /// <summary>
        /// 根据权限编号判断用户是否拥有权限的SQl语句。
        /// </summary>
        private const string SQL_HASRIGHT_BY_RIGHTCODE = @"
SELECT  COUNT(*)
FROM    dbo.mySystemRoleRights
WHERE   RightCode = @RightCode AND
        RoleCode IN ( SELECT    DISTINCT RoleCode
                      FROM      dbo.ViewUsersRoles a
                      WHERE     UserCode IN ( SELECT @UserName As UserName
                                              UNION
                                              SELECT Grantor AS UserName 
                                              FROM dbo.fun_GetAllGrantorsByEmbracer(@UserName)
                                              WHERE EffectTime<=getDate()
                                            ) AND
                                EXISTS ( SELECT *
                                         FROM   mysystemroles b
                                         WHERE  a.RoleCode = b.RoleCode AND
                                                b.IsValid = 'Y' ) )";
        /// <summary>
        /// 根据权限编号和知识库项目ID和类型来判断用户是否对知识库项目拥有权限的SQL语句。
        /// </summary>
        private const string SQL_HASRIGHT_BY_RIGHTCODE_CHECKCODE_TYPE = @"
SELECT  COUNT(*)
FROM    dbo.mySystemRoleRights
WHERE   RightCode = @RightCode AND
        RoleCode IN ( SELECT    DISTINCT RoleCode
                      FROM      dbo.ViewUsersRoles a
                      WHERE     CheckCode = @CheckCode And
                                Type = @Type And
                                UserCode IN ( SELECT @UserName As UserName
                                              UNION
                                              SELECT Grantor AS UserName 
                                              FROM dbo.fun_GetAllGrantorsByEmbracer(@UserName)
                                              WHERE EffectTime<=getDate()
                                            ) AND
                                EXISTS ( SELECT *
                                         FROM   mysystemroles b
                                         WHERE  a.RoleCode = b.RoleCode AND
                                                b.IsValid = 'Y' ) )";
        /// <summary>
        /// 判断知识库条目是否是不受管制的SQL语句。
        /// </summary>
        private const string SQL_ISUNMANAGED_BY_CHECKCODE_TYPE = @"
SELECT  COUNT(*)
FROM    dbo.ViewUsersRoles a
WHERE   CheckCode = @CheckCode AND
        [Type] = @Type AND
        EXISTS ( SELECT *
                 FROM   dbo.mySystemRoles b
                 WHERE  a.RoleCode = b.RoleCode AND
                        b.IsValid = 'Y' )
";
	    #endregion

        #region property

	    /// <summary>
	    /// 用户基本信息
	    /// </summary>
	    public UserInfo thisUserInfo { get; set; }
        /// <summary>
        /// 用户信息实体.
        /// </summary>
        public UserInfo Information { get; set; }

	    /// <summary>
	    /// 用户拥有的角色信息.
	    /// 包括用户角色，组角色以及授权人所拥有的组角色、用户角色。
	    /// </summary>
	    public ListBase<OwnedRoleInfo> OwenedRoles { get; set; }

        /// <summary>
        /// 用户所拥有的用户组。
        /// </summary>
        public ListBase<GroupUserInfo> GroupUsers { get; set; }
        /// <summary>
        /// 访问控制列表.Access Control List.
        /// </summary>
        protected ListBase<OwnedRoleInfo> ACL { get; set; }

	   /// <summary>
	    /// 角色权限.
	    /// </summary>
	    protected ListBase<RoleRightInfo> RoleRights { get; set; }

	    /// <summary>
	    /// 是否登录成功
	    /// </summary>
	    public bool LoginSuccess { get; private set; }

	    /// <summary>
		/// 员工所属的公司.
		/// </summary>
		public string Company
		{
			get
			{
			    return this.thisUserInfo.EmpCo;
			}
		}
        /// <summary>
        /// 用户的登录名。
        /// </summary>
	    public string LoginName
	    {
            get { return this.thisUserInfo.LoginName; }
	    }
        /// <summary>
        /// 用户姓名。
        /// </summary>
	    public string EmpName
	    {
            get { return thisUserInfo.EmpName; }
	    }
        /// <summary>
        /// 工号。
        /// </summary>
	    public string EmpCode
	    {
            get { return thisUserInfo.EmpCode; }
	    }
        /// <summary>
        /// 性别。
        /// </summary>
	    public string Gender
	    {
            get { return thisUserInfo.Gender; }
	    }
        /// <summary>
        /// 部门编号。
        /// </summary>
	    public string DeptCode
	    {
            get { return thisUserInfo.DeptCode; }
	    }
        /// <summary>
        /// 部门名称。
        /// </summary>
	    public string DeptName
	    {
            get { return thisUserInfo.DeptName; }
	    }
        /// <summary>
        /// 界面语言.
        /// </summary>
	    public string UICulture
	    {
            get
            {
                if(string.IsNullOrEmpty(this.thisUserInfo.UICulture))
                {
                    return "zh-CN";
                }
                else
                {
                    return this.thisUserInfo.UICulture;
                }
            }
	    }
	    #endregion

        #region constranctor
		/// <summary>
		/// 用户实例
		/// </summary>
		/// <param name="loginName">用户名</param>
		/// <param name="pwd">密码</param>
		public User(string loginName,string pwd)
		{
		    this.thisUserInfo = DataProvider.UserProvider.GetByLoginName(loginName);
            if(this.thisUserInfo == null)
            {
                this.LoginSuccess = false;
            }
            else
            {
                if(this.thisUserInfo.IsUser=="Y" && this.thisUserInfo.UserState=="A")
                {
                    var hashedPwd = CreatePasswordHash(pwd, this.thisUserInfo.AppandCode);
                    this.LoginSuccess = hashedPwd == this.thisUserInfo.Password1;
                }
                else
                {
                    this.LoginSuccess = false;
                }
            }
            if (this.LoginSuccess )//&& ConfigurationManager.AppSettings["SystemDAL"] == "Shmzh.Components.SystemComponent.SQLServerDAL")
            {
                var productCode = short.Parse(System.Configuration.ConfigurationManager.AppSettings["ProductId"]);
                this.ACL = DataProvider.OwnedRoleProvider.GetAllByProductCode(productCode) as ListBase<OwnedRoleInfo>;
                this.OwenedRoles = DataProvider.OwnedRoleProvider.GetByUserName(this.LoginName) as ListBase<OwnedRoleInfo>;
                this.GroupUsers = DataProvider.GroupUserProvider.GetByUserCode(this.LoginName) as ListBase<GroupUserInfo>;
                this.RoleRights = DataProvider.RoleRightProvider.GetAllAvalible() as ListBase<RoleRightInfo>;
            }
		}

		/// <summary>
		/// 根据用户名构造用户实例.
		/// </summary>
		/// <param name="loginName">用户名.</param>
		/// <remarks>适用于集成登录的环境,SSO登录后,直接以用户名来创建用户实例.
		/// 这样SSO和其他系统只要保证用户名相同就可以了.
		/// </remarks>
		public User(string loginName)
		{
		    this.thisUserInfo = DataProvider.UserProvider.GetByLoginName(loginName);
            if (this.thisUserInfo == null)
                this.LoginSuccess = false;
            else
            {
                if(thisUserInfo.IsUser =="Y" && thisUserInfo.UserState =="A")
                    this.LoginSuccess = true;
                else
                {
                    this.LoginSuccess = false;
                }
            }
            if(this.LoginSuccess)
            {
                if (ConfigurationManager.AppSettings["ASLProductId"] != null)
                {
                    short productCode = short.Parse(ConfigurationManager.AppSettings["ASLProductId"]);
                    this.ACL = DataProvider.OwnedRoleProvider.GetAllByProductCode(productCode) as ListBase<OwnedRoleInfo>;
                }
                this.OwenedRoles = DataProvider.OwnedRoleProvider.GetByUserName(this.LoginName) as ListBase<OwnedRoleInfo>;
                this.GroupUsers = DataProvider.GroupUserProvider.GetByUserCode(this.LoginName) as ListBase<GroupUserInfo>;
                this.RoleRights = DataProvider.RoleRightProvider.GetAllAvalible() as ListBase<RoleRightInfo>;
            }
		}

	    /// <summary>
		/// 用户构造函数.
		/// </summary>
		public User()
		{
		    this.thisUserInfo = new UserInfo();
		}

	    #endregion

        #region public methods
		/// <summary>
		/// 是否有权限
		/// </summary>
		/// <param name="rightCode">权限编号</param>
		/// <returns>bool</returns>
		public virtual bool HasRight(int rightCode)
		{
            if(this.LoginName.ToUpper() == "ADMINISTRATOR")
                return true;

		    var roles = this.OwenedRoles;
            var roleRights = this.RoleRights.FindAll(o => o.RightCode == (short)rightCode);//和指定权限码相关的角色.
            //如果以上两个对象的角色有重叠,则表示有权限.
            foreach (var obj in roleRights)
            {
                if (roles.Exists(o => o.RoleCode == obj.RoleCode))
                    return true;
            }
            return false;
		}
		
		/// <summary>
		/// 是否拥有权限
		/// </summary>
		/// <param name="rightCode">权限编号</param>
		/// <param name="docCode">文档编号</param>
		/// <returns>bool</returns>
		public virtual bool HasRight(int rightCode,string docCode)
		{
		    return HasRight(rightCode, docCode, "A");
		}
		
		/// <summary>
        /// 是否拥有权限(适用知识管理)
		/// </summary>
		/// <param name="rightCode">权限代码</param>
		/// <param name="checkCode">节点号</param>
		/// <param name="type">类型（目录、文章）</param>
		/// <returns>bool</returns>
		public virtual bool HasRight(int rightCode,string checkCode,string type)
		{
			if (this.thisUserInfo.LoginName.ToLower() == "administrator")
				return true;

		    var roles = this.OwenedRoles.FindAll(o => o.CheckCode == checkCode && o.Type == type);//和指定知识库条目相关的该用户的角色.
		    var roleRights = this.RoleRights.FindAll(o => o.RightCode == (short)rightCode);//和指定权限码相关的角色.
            //如果以上两个对象的角色有重叠,则表示有权限.
            foreach(var obj in roleRights)
            {
                if(roles.Exists(o=>o.RoleCode == obj.RoleCode))
                    return true;
            }
		    return false;
		}

        /// <summary>
        /// 判断知识库项目是否是不受管制的。
        /// </summary>
        /// <param name="checkCode">文章或目录的ID。</param>
        /// <param name="type">类型(文章或目录);</param>
        /// <returns>bool</returns>
        public bool IsUnManaged(string checkCode, string type)
        {
            return this.ACL == null || !this.ACL.Exists(o => o.CheckCode == checkCode && o.Type == type);
        }

	    /// <summary>
        /// 改变口令
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="oldPassword">旧口令</param>
        /// <param name="newPassword">新口令</param>
        /// <returns>bool</returns>
        public static bool ChangePassword(string loginName, string oldPassword, string newPassword)
        {
            var obj = DataProvider.UserProvider.GetByLoginName(loginName);
            if (obj != null)
            {
                var oldHashedPwd = CreatePasswordHash(oldPassword, obj.AppandCode);
                if (oldHashedPwd == obj.Password1)
                {
                    var newHashedPwd = CreatePasswordHash(newPassword, obj.AppandCode);
                    obj.Password1 = newHashedPwd;
                    return DataProvider.UserProvider.Update(obj);
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 复位密码。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <returns>bool</returns>
        public static bool ResetPassword(UserInfo userInfo)
        {
            var defaultPwd = ConfigurationManager.AppSettings["DefaultPassword"];
            var newHashedPwd = CreatePasswordHash(defaultPwd, userInfo.AppandCode);
            userInfo.Password1 = newHashedPwd;
            return DataProvider.UserProvider.Update(userInfo);
        }
        #endregion

        #region private functions
        /// <summary>
        /// 获取根据权限码判断是否拥有权限的SQL语句的参数数组。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Get_HasRight_By_RightCode_Parameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_HASRIGHT_BY_RIGHTCODE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@RightCode",SqlDbType.SmallInt),
                                new SqlParameter("@UserName", SqlDbType.NVarChar,20),
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_HASRIGHT_BY_RIGHTCODE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 获取根据权限码判断是否拥有权限的SQL语句的参数数组。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] Get_HasRight_By_RightCode_CheckCode_Type_Parameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_HASRIGHT_BY_RIGHTCODE_CHECKCODE_TYPE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@RightCode",SqlDbType.SmallInt),
                                new SqlParameter("@CheckCode", SqlDbType.NVarChar,50),
                                new SqlParameter("@Type", SqlDbType.NChar,1),
                                new SqlParameter("@UserName", SqlDbType.NVarChar,20), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_HASRIGHT_BY_RIGHTCODE_CHECKCODE_TYPE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 根据原始口令和附加码对口令进行哈希.
        /// </summary>
        /// <param name="pwd">string:口令</param>
        /// <param name="salt">string:附加码</param>
        /// <returns>经过哈希过的口令.</returns>
        private static string CreatePasswordHash(string pwd, string salt)
        {
            var saltAndPwd = String.Concat(pwd, salt);
            var hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(
                saltAndPwd, "SHA1");//"SHA1":安全哈希算法 1.可选还有md5：消息摘要 5 (MD5)
            return hashedPwd;
        }
        
        #endregion
	}
}
