//-----------------------------------------------------------------------
// <copyright file="UserDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Security;
    using Shmzh.Components.SystemComponent.DALFactory;
    
    /// <summary>
	/// UserDA 的摘要说明。
	/// </summary>
	public class UserDA
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        #region 构造函数
        /// <summary>
		/// 构造函数
		/// </summary>
		public UserDA()
		{
		}

		#endregion

		#region 方法
		/// <summary>
		/// 提供用户名和密码进行登录.
		/// </summary>
		/// <param name="thisUserName">用户名.</param>
		/// <param name="thisPassword">密码.</param>
		/// <returns>bool</returns>
		public bool UserLogin(string thisUserName,string thisPassword)
		{
			var ret=true;
			
			var objUser=new EntryUser();
			
			try
			{
				var arParms = new SqlParameter[2];
				arParms[0] = new SqlParameter("@LoginName", SqlDbType.NVarChar,50 ) {Value = thisUserName};
			    SqlHelper.FillDataset(ConnectionString.PubData  , CommandType.StoredProcedure,
					"mysys_UserLogin",objUser,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
			}
			catch (Exception ex)
			{
			    Logger.Error(ex.Message);
			}
			finally
			{
				if (objUser.Tables[EntryUser.MYSYSTEMUSERINFO_TABLE].Rows.Count>0)
				{
					DataRow dr=objUser.Tables[EntryUser.MYSYSTEMUSERINFO_TABLE].Rows[0];
					//加密
					if (SystemInfo.Instance().IsSecurity=="Y")
					{
                        if (dr[EntryUser.PASSWORD1_FIELD].ToString() != CreatePasswordHash(thisPassword, dr[EntryUser.APPANDCODE_FIELD].ToString()))
                        {
                            Logger.Info("密码不匹配！");
                            ret = false;
                        }
                        else
                        {
                            Logger.Info("密码匹配！");
                        }
					}
					else
					{
						if(dr[EntryUser.PASSWORD2_FIELD].ToString()!=thisPassword)
						{
							ret=false;
						}
					}
				}
				else
				{
					ret=false;
				}

			}
			return ret;
		}
		
		/// <summary>
		/// 提供用户名和密码以及用户对象进行登录.
		/// </summary>
		/// <param name="thisUserName">用户名.</param>
		/// <param name="thisPassword">密码</param>
		/// <param name="thisUserInfo">用户对象</param>
		/// <returns>bool</returns>
		public bool UserLogin(string thisUserName,string thisPassword,ref UserInfo thisUserInfo)
		{
			var ret=true;
			try
			{
			    thisUserInfo = DataProvider.CreateUserProvider().GetByLoginName(thisUserName);
			}
			catch (Exception ex)
			{
			    Logger.Error(ex.Message);
			}
			finally
			{
				if (thisUserInfo != null)
				{
					//加密
					if (SystemInfo.Instance().IsSecurity=="Y")
					{
						if (thisUserInfo.Password1 != CreatePasswordHash(thisPassword,thisUserInfo.AppandCode))
						{
							ret=false;
						}
					}
					else
					{
						if(thisUserInfo.Password2 != thisPassword)
						{
							ret=false;
						}
					}
				}
				else
				{
					ret=false;
				}
			}
			return ret;
		}

		/// <summary>
		/// 提供用户名和用户对象进行登录.
		/// </summary>
		/// <param name="thisUserName">用户名.</param>
		/// <param name="thisUserInfo">用户对象.</param>
		/// <returns>bool</returns>
		public bool UserLogin(string thisUserName, ref UserInfo thisUserInfo)
		{
			var ret=true;
			try
			{
                thisUserInfo = DataProvider.CreateUserProvider().GetByLoginName(thisUserName);
                //UserInfo obj = DataProvider.CreateUserProvider().GetByLoginName(thisUserName);
                //thisUserInfo.LoginName = obj.LoginName;
                //thisUserInfo.EmpName = obj.EmpName;                
			}
			catch(Exception e)
			{
                Logger.Error(e.Message);
            }
			finally
			{
				if (thisUserInfo == null)
				{
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 得到所有的用户
		/// </summary>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="ds"></param>
		public void GetAllUsers(EntryUser ds,string thisCompanyCode)
		{
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    SqlHelper.FillDataset(ConnectionString.PubData ,CommandType.StoredProcedure,
					"mysys_GetAllUsers",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
        /// <summary>
        /// 获取所有的内部用户。
        /// 即IsUser和IsEmp属性都为Y。
        /// </summary>
        /// <param name="ds">用户实体。</param>
        /// <param name="companyCode">公司编号。</param>
        public void GetInnerUsers(EntryUser ds, string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where IsUser='Y' And IsEmp='Y' And EmpCo = '{0}'",companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE }); 
        }
        /// <summary>
        /// 获取所有的用户和员工。
        /// </summary>
        /// <param name="ds">用户实体。</param>
        /// <param name="companyCode">公司编号。</param>
        public void GetAllUserAndEmp(EntryUser ds, string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}'",companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE }); 
        }
        /// <summary>
        /// 获取所有的内部员工和用户。
        /// </summary>
        /// <param name="ds">用户实体。</param>
        /// <param name="companyCode">公司编号。</param>
        public void GetInnerUserAndEmp(EntryUser ds, string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And IsEmp='Y'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE }); 
        }
		/// <summary>
		/// 根据角色获取用户清单。
		/// </summary>
		/// <param name="ds">EntryUser:	用户实体。</param>
		/// <param name="thisCompanyCode">string:	单位信息.</param>
		/// <param name="RoleID">int:	角色ID.</param>
		public void GetUserByRole(EntryUser ds,string thisCompanyCode,int RoleID)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20) {Value = thisCompanyCode};
		    arParms[1] = new SqlParameter("@RoleID", SqlDbType.SmallInt) {Value = RoleID};

		    SqlHelper.FillDataset(ConnectionString.PubData , CommandType.StoredProcedure,"mysys_GetUserByRole",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
		/// <summary>
		/// 根据手机号获取人员信息.
		/// </summary>
		/// <param name="mobileNumber"></param>
		/// <returns></returns>
		public DataSet GetUserByMobileNumber(string mobileNumber)
		{
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@MobileNumber", SqlDbType.NVarChar,50) {Value = mobileNumber};

		    return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.StoredProcedure,"mysys_GetUserByMobile",arParms);
		}
        /// <summary>
        /// 根据用户名获取用户信息。
        /// </summary>
        /// <param name="loginName">用户名（登录名）</param>
        /// <returns>DataSet</returns>
        public DataSet GetUserByLoginName(string loginName)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where LoginName = '{0}'", loginName);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 根据公司编号和员工工号获取用户信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="empCode">工号。</param>
        /// <returns>DataSet。</returns>
        public DataSet GetUserByEmpCode(string companyCode, string empCode)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo = '{0}' And EmpCode = '{1}'",
                                             companyCode, empCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }

        /// <summary>
		/// 根据公司和指定的权限码获取用户。
		/// </summary>
		/// <param name="thisCompanyCode">公司代码。</param>
		/// <param name="rightCode">权限码。</param>
		/// <returns>返回的是mySystemUserInfo对应的DataSet。</returns>
		/// <example>
		/// <code>
		/// 语言：C#
		/// DataSet ds;
		/// Shmzh.Components.SystemComponent.UserDA myUserDataAccess = new Shmzh.Components.SystemComponent.UserDA myUserDataAccess();
		/// ds = myUserDataAccess.GetUserByCompanyAndRightCode("YPWATER",int.Parse(this.txtRightCode.Text));
		/// </code>
		/// </example>
		public DataSet GetUserByCompanyAndRightCode(string thisCompanyCode, int rightCode)
		{
		    var sqlStatement = string.Format(@"Select * From mySystemUserInfo 
										   Where LoginName in (Select UserCode From mySystemUserRoles 
                                                               where  RoleCode in (Select RoleCode From mySystemRoleRights 
                                                                                   Where RightCode = {1}
                                                                                  )
                                                               )
											And EmpCo = '{0}'",thisCompanyCode,rightCode).Replace("\r\n",string.Empty).Replace("\t",string.Empty);
		    return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,sqlStatement);
		}

        /// <summary>
		/// 根据用户名进行密码设定.
		/// </summary>
		/// <param name="loginName">用户名</param>
		/// <param name="pwd">密码</param>
		/// <param name="salt">附加码</param>
		/// <returns>bool</returns>
		public bool SetPassword(string loginName,string pwd,string salt)
		{
			var ret=true;
			try
			{
				var arParms = new SqlParameter[3];
				arParms[0] = new SqlParameter("@UserName", SqlDbType.NVarChar,50 ) {Value = loginName};
			    arParms[1] = new SqlParameter("@Password", SqlDbType.NVarChar,255 ) {Value = pwd};
			    arParms[2] = new SqlParameter("@Salt", SqlDbType.NVarChar,255 ) {Value = salt};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_SetPassword",arParms);//更新到Password1.
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
			    ret= false;
			}
			return ret;
		}
		/// <summary>
		/// 根据PKID进行密码设定.
		/// </summary>
		/// <param name="pkID">ID</param>
		/// <param name="thisPassword">密码</param>
		/// <param name="thisSalt">附加码</param>
		/// <returns>bool</returns>
		public bool SetPasswordByPKID(int pkID,string thisPassword,string thisSalt)
		{
			var ret = true;
			try
			{
				var strSQL = string.Format(@"Update mySystemUserInfo 
											Set	Password1='{0}'
												,	AppandCode='{1}' 
											Where PKID={2}",thisPassword,thisSalt,pkID).Replace("/r/n",string.Empty);
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
			    ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 根据用户名得到用户所有的角色
		/// </summary>
		/// <returns></returns>
		public DataSet GetUserRoles(string thisUserCode)
		{
			try
			{
			    var strSQL=string.Format(@"	SELECT	B.ROLECODE,B.ROLENAME,B.PRODUCTCODE,A.CheckCode,A.Type 
											FROM	mySystemUserRoles A,mySystemRoles B 
											WHERE	A.UserCode='{0}' AND 
													A.RoleCode=B.RoleCode AND 
													B.ISVALID='{1}'",thisUserCode,"Y").Replace("/r/n",string.Empty);

			    return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch (Exception ex)
			{
			    Logger.Error(ex.Message);
			    return null;
			}
		}
		/// <summary>
		/// 根据用户名和产品编号获取用户角色.
		/// </summary>
		/// <param name="thisUserCode">string:用户名</param>
		/// <param name="ProductCode">int:产品编号</param>
		/// <returns>DataSet</returns>
		public DataSet GetUserRoles(string thisUserCode, int ProductCode)
		{
			try
			{
				var commandText = string.Format(@"Select B.RoleCode, B.RoleName,B.ProductCode, A.CheckCode, A.Type 
													From  mySystemUserRoles A, mySystemRoles B
													Where	A.UserCode = '{0}' And 
															A.RoleCode = B.RoleCode And
															B.IsValid = 'Y' And
															B.ProductCode = {1}", thisUserCode, ProductCode).Replace("/r/n",string.Empty);
				return SqlHelper.ExecuteDataset(ConnectionString.PubData , CommandType.Text, commandText);
			}
			catch (Exception ex)
			{
			    Logger.Error(ex.Message);
			    return null;
			}
			
		}

 		/// <summary>
		/// 根据用户名,CheckCode,Type获取用户角色.
		/// </summary>
		/// <param name="thisUserCode">用户名.</param>
		/// <param name="checkCode">CheckCode</param>
		/// <param name="type">类型,A,B,C三种.</param>
		/// <returns>DataSet</returns>
		public DataSet GetUserRoles(string thisUserCode,string checkCode,string type)
		{
			try
			{
				var strSQL="SELECT B.ROLECODE,B.ROLENAME,B.PRODUCTCODE,A.CheckCode,A.Type FROM mySystemUserRoles A,mySystemRoles B WHERE A.UserCode='" + thisUserCode + "' And CheckCode='" + checkCode + "' And Type='" + type+ "' AND A.RoleCode=B.RoleCode AND B.ISVALID='Y'";
				return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch (Exception ex)
			{
			    Logger.Error(ex.Message);
			    return null;
            }
		}
		/// <summary>
		/// 根据用户名获取所有的用户角色.
		/// </summary>
		/// <param name="thisUserCode">用户名.</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllUserRoles(string thisUserCode)
		{
	        try
	        {
	            var arParms = new SqlParameter[1];
	            arParms[0] = new SqlParameter("@UserCode", SqlDbType.NVarChar,20 ) {Value = thisUserCode};
	            return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_GetAllUserRoles",arParms);
	        }
	        catch (Exception ex)
	        {
	            Logger.Error(ex.Message);
	            return null;
	        }
		}

        /// <summary>
		/// 得到用户所有的组
		/// </summary>
		/// <param name="thisUserCode"></param>
		/// <returns></returns>
		public DataSet GetAllUserGroups(string thisUserCode)
		{
			try
			{
				var arParms = new SqlParameter[1];
				arParms[0] = new SqlParameter("@UserCode", SqlDbType.NVarChar,20 ) {Value = thisUserCode};
			    return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_GetAllUserGroups",arParms);
			}
			catch (Exception ex)
			{
			    Logger.Error(ex.Message);
			    return null;
			}
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
		
		/// <summary>
		/// 得到所有用户角色列表。
		/// </summary>
		/// <returns></returns>
		public DataSet GetASL()
		{
			try
			{
				var strSQL = "SELECT RoleCode,CheckCode,Type FROM mySystemUserRoles union SELECT RoleCode,CheckCode,Type FROM mySystemGroupRoles";
				return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch (Exception ex)
			{
			    Logger.Error(ex.Message);
			    return null;
			}
		}

		/// <summary>
		/// 禁用用户.
		/// </summary>
		/// <param name="userCode">用户名.</param>
		/// <param name="state">状态</param>
		/// <returns>bool</returns>
		public bool DisableUser(string userCode,string state)
		{
			bool ret=true;
			try
			{
				string strSQL="UPDATE mySystemUserInfo SET UserState='" + state + "' where LoginName='" + userCode + "'";
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch
			{
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 根据用户PKID设置用户状态.
		/// </summary>
		/// <param name="pkid"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public bool SetUserState(int pkid,string state)
		{
			bool ret=true;

			try
			{
				string strSQL="UPDATE mySystemUserInfo SET UserState='" + state + "' where PKID=" + pkid;
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch
			{
				ret=false;
				//
			}
			return ret;
		}
		/// <summary>
		/// 根据用户名和产品编号删除用户的角色.
		/// </summary>
		/// <param name="UserCode">string:用户名</param>
		/// <param name="ProductCode">int:产品编号</param>
		/// <returns>bool</returns>
		public bool DeleteUserRoles(string UserCode, int ProductCode)
		{
			bool flag = true;
			try
			{
				string commandText = string.Format("Delete\tFrom mySystemUserRoles \r\n\t\t\t\t\t\t\t\t\t\t\t\tWhere\tUserCode = '{0}' And\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tRoleCode in (Select RoleCode From mySystemRoles Where ProductCode = {1})", UserCode, ProductCode);
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData , CommandType.Text, commandText);
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

 		/// <summary>
		/// 删除用户角色
		/// </summary>
		/// <param name="userCode">用户名</param>
		/// <param name="checkCode">对象id(知识库用)</param>
		/// <param name="type">对象类型(知识库用)</param>
		/// <returns>bool</returns>
		public bool DeleteUserRoles(string userCode,string checkCode,string type)
		{
			bool ret=true;

			try
			{
				string strSQL="delete from mySystemUserRoles where UserCode='" + userCode + "' and CheckCode='" + checkCode + "' and  Type='" + type + "'";
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch
			{
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 清除所有满足CheckCode 和Type的记录
		/// </summary>
		/// <param name="checkCode">CheckCode</param>
		/// <param name="type">Type</param>
		/// <returns>boll</returns>
		public bool ClearAccess(string checkCode,string type)
		{
			bool ret=true;

			try
			{
				string strSQL="delete from mySystemUserRoles where CheckCode='" + checkCode + "' and  Type='" + type + "'";
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData  ,CommandType.Text,strSQL);
			}
			catch
			{
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 获取没有设置任何访问权限的对象.
		/// </summary>
		/// <param name="rightCode">权限代码</param>
		/// <param name="productcode">产品代码</param>
		/// <returns>DataSet</returns>
		public DataSet GetNoAccessObj(int rightCode,int productcode)
		{
			try
			{
				var strSQL="select distinct A.CheckCode,A.Type from V_RoleCheckCodeType A where not exists(select CheckCode,Type from (select A.CheckCode,A.Type from V_RoleCheckCodeType A,mySystemRoleRights B Where A.RoleCode=B.RoleCode And B.RightCode=" + rightCode + ") as B where A.checkcode = B.checkcode and  A.Type = B.Type)";
				return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch (Exception ex)
			{
			    Logger.Error(ex.Message);
			    return null;
			}
		}
		#endregion

	}
}
