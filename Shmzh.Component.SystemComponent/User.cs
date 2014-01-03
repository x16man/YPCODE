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
	/// User�û���ժҪ˵����
	/// </summary>
	[Serializable]
	public class User
	{
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	    
        /// <summary>
        /// ����Ȩ�ޱ���ж��û��Ƿ�ӵ��Ȩ�޵�SQl��䡣
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
        /// ����Ȩ�ޱ�ź�֪ʶ����ĿID���������ж��û��Ƿ��֪ʶ����Ŀӵ��Ȩ�޵�SQL��䡣
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
        /// �ж�֪ʶ����Ŀ�Ƿ��ǲ��ܹ��Ƶ�SQL��䡣
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
	    /// �û�������Ϣ
	    /// </summary>
	    public UserInfo thisUserInfo { get; set; }
        /// <summary>
        /// �û���Ϣʵ��.
        /// </summary>
        public UserInfo Information { get; set; }

	    /// <summary>
	    /// �û�ӵ�еĽ�ɫ��Ϣ.
	    /// �����û���ɫ�����ɫ�Լ���Ȩ����ӵ�е����ɫ���û���ɫ��
	    /// </summary>
	    public ListBase<OwnedRoleInfo> OwenedRoles { get; set; }

        /// <summary>
        /// �û���ӵ�е��û��顣
        /// </summary>
        public ListBase<GroupUserInfo> GroupUsers { get; set; }
        /// <summary>
        /// ���ʿ����б�.Access Control List.
        /// </summary>
        protected ListBase<OwnedRoleInfo> ACL { get; set; }

	   /// <summary>
	    /// ��ɫȨ��.
	    /// </summary>
	    protected ListBase<RoleRightInfo> RoleRights { get; set; }

	    /// <summary>
	    /// �Ƿ��¼�ɹ�
	    /// </summary>
	    public bool LoginSuccess { get; private set; }

	    /// <summary>
		/// Ա�������Ĺ�˾.
		/// </summary>
		public string Company
		{
			get
			{
			    return this.thisUserInfo.EmpCo;
			}
		}
        /// <summary>
        /// �û��ĵ�¼����
        /// </summary>
	    public string LoginName
	    {
            get { return this.thisUserInfo.LoginName; }
	    }
        /// <summary>
        /// �û�������
        /// </summary>
	    public string EmpName
	    {
            get { return thisUserInfo.EmpName; }
	    }
        /// <summary>
        /// ���š�
        /// </summary>
	    public string EmpCode
	    {
            get { return thisUserInfo.EmpCode; }
	    }
        /// <summary>
        /// �Ա�
        /// </summary>
	    public string Gender
	    {
            get { return thisUserInfo.Gender; }
	    }
        /// <summary>
        /// ���ű�š�
        /// </summary>
	    public string DeptCode
	    {
            get { return thisUserInfo.DeptCode; }
	    }
        /// <summary>
        /// �������ơ�
        /// </summary>
	    public string DeptName
	    {
            get { return thisUserInfo.DeptName; }
	    }
        /// <summary>
        /// ��������.
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
		/// �û�ʵ��
		/// </summary>
		/// <param name="loginName">�û���</param>
		/// <param name="pwd">����</param>
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
		/// �����û��������û�ʵ��.
		/// </summary>
		/// <param name="loginName">�û���.</param>
		/// <remarks>�����ڼ��ɵ�¼�Ļ���,SSO��¼��,ֱ�����û����������û�ʵ��.
		/// ����SSO������ϵͳֻҪ��֤�û�����ͬ�Ϳ�����.
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
		/// �û����캯��.
		/// </summary>
		public User()
		{
		    this.thisUserInfo = new UserInfo();
		}

	    #endregion

        #region public methods
		/// <summary>
		/// �Ƿ���Ȩ��
		/// </summary>
		/// <param name="rightCode">Ȩ�ޱ��</param>
		/// <returns>bool</returns>
		public virtual bool HasRight(int rightCode)
		{
            if(this.LoginName.ToUpper() == "ADMINISTRATOR")
                return true;

		    var roles = this.OwenedRoles;
            var roleRights = this.RoleRights.FindAll(o => o.RightCode == (short)rightCode);//��ָ��Ȩ������صĽ�ɫ.
            //���������������Ľ�ɫ���ص�,���ʾ��Ȩ��.
            foreach (var obj in roleRights)
            {
                if (roles.Exists(o => o.RoleCode == obj.RoleCode))
                    return true;
            }
            return false;
		}
		
		/// <summary>
		/// �Ƿ�ӵ��Ȩ��
		/// </summary>
		/// <param name="rightCode">Ȩ�ޱ��</param>
		/// <param name="docCode">�ĵ����</param>
		/// <returns>bool</returns>
		public virtual bool HasRight(int rightCode,string docCode)
		{
		    return HasRight(rightCode, docCode, "A");
		}
		
		/// <summary>
        /// �Ƿ�ӵ��Ȩ��(����֪ʶ����)
		/// </summary>
		/// <param name="rightCode">Ȩ�޴���</param>
		/// <param name="checkCode">�ڵ��</param>
		/// <param name="type">���ͣ�Ŀ¼�����£�</param>
		/// <returns>bool</returns>
		public virtual bool HasRight(int rightCode,string checkCode,string type)
		{
			if (this.thisUserInfo.LoginName.ToLower() == "administrator")
				return true;

		    var roles = this.OwenedRoles.FindAll(o => o.CheckCode == checkCode && o.Type == type);//��ָ��֪ʶ����Ŀ��صĸ��û��Ľ�ɫ.
		    var roleRights = this.RoleRights.FindAll(o => o.RightCode == (short)rightCode);//��ָ��Ȩ������صĽ�ɫ.
            //���������������Ľ�ɫ���ص�,���ʾ��Ȩ��.
            foreach(var obj in roleRights)
            {
                if(roles.Exists(o=>o.RoleCode == obj.RoleCode))
                    return true;
            }
		    return false;
		}

        /// <summary>
        /// �ж�֪ʶ����Ŀ�Ƿ��ǲ��ܹ��Ƶġ�
        /// </summary>
        /// <param name="checkCode">���»�Ŀ¼��ID��</param>
        /// <param name="type">����(���»�Ŀ¼);</param>
        /// <returns>bool</returns>
        public bool IsUnManaged(string checkCode, string type)
        {
            return this.ACL == null || !this.ACL.Exists(o => o.CheckCode == checkCode && o.Type == type);
        }

	    /// <summary>
        /// �ı����
        /// </summary>
        /// <param name="loginName">�û���</param>
        /// <param name="oldPassword">�ɿ���</param>
        /// <param name="newPassword">�¿���</param>
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
        /// ��λ���롣
        /// </summary>
        /// <param name="userInfo">�û�����</param>
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
        /// ��ȡ����Ȩ�����ж��Ƿ�ӵ��Ȩ�޵�SQL���Ĳ������顣
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
        /// ��ȡ����Ȩ�����ж��Ƿ�ӵ��Ȩ�޵�SQL���Ĳ������顣
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
        /// ����ԭʼ����͸�����Կ�����й�ϣ.
        /// </summary>
        /// <param name="pwd">string:����</param>
        /// <param name="salt">string:������</param>
        /// <returns>������ϣ���Ŀ���.</returns>
        private static string CreatePasswordHash(string pwd, string salt)
        {
            var saltAndPwd = String.Concat(pwd, salt);
            var hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(
                saltAndPwd, "SHA1");//"SHA1":��ȫ��ϣ�㷨 1.��ѡ����md5����ϢժҪ 5 (MD5)
            return hashedPwd;
        }
        
        #endregion
	}
}
