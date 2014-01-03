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
	/// UserDA ��ժҪ˵����
	/// </summary>
	public class UserDA
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        #region ���캯��
        /// <summary>
		/// ���캯��
		/// </summary>
		public UserDA()
		{
		}

		#endregion

		#region ����
		/// <summary>
		/// �ṩ�û�����������е�¼.
		/// </summary>
		/// <param name="thisUserName">�û���.</param>
		/// <param name="thisPassword">����.</param>
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
					//����
					if (SystemInfo.Instance().IsSecurity=="Y")
					{
                        if (dr[EntryUser.PASSWORD1_FIELD].ToString() != CreatePasswordHash(thisPassword, dr[EntryUser.APPANDCODE_FIELD].ToString()))
                        {
                            Logger.Info("���벻ƥ�䣡");
                            ret = false;
                        }
                        else
                        {
                            Logger.Info("����ƥ�䣡");
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
		/// �ṩ�û����������Լ��û�������е�¼.
		/// </summary>
		/// <param name="thisUserName">�û���.</param>
		/// <param name="thisPassword">����</param>
		/// <param name="thisUserInfo">�û�����</param>
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
					//����
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
		/// �ṩ�û������û�������е�¼.
		/// </summary>
		/// <param name="thisUserName">�û���.</param>
		/// <param name="thisUserInfo">�û�����.</param>
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
		/// �õ����е��û�
		/// </summary>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="ds"></param>
		public void GetAllUsers(EntryUser ds,string thisCompanyCode)
		{
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    SqlHelper.FillDataset(ConnectionString.PubData ,CommandType.StoredProcedure,
					"mysys_GetAllUsers",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
        /// <summary>
        /// ��ȡ���е��ڲ��û���
        /// ��IsUser��IsEmp���Զ�ΪY��
        /// </summary>
        /// <param name="ds">�û�ʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        public void GetInnerUsers(EntryUser ds, string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where IsUser='Y' And IsEmp='Y' And EmpCo = '{0}'",companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE }); 
        }
        /// <summary>
        /// ��ȡ���е��û���Ա����
        /// </summary>
        /// <param name="ds">�û�ʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        public void GetAllUserAndEmp(EntryUser ds, string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}'",companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE }); 
        }
        /// <summary>
        /// ��ȡ���е��ڲ�Ա�����û���
        /// </summary>
        /// <param name="ds">�û�ʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        public void GetInnerUserAndEmp(EntryUser ds, string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And IsEmp='Y'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE }); 
        }
		/// <summary>
		/// ���ݽ�ɫ��ȡ�û��嵥��
		/// </summary>
		/// <param name="ds">EntryUser:	�û�ʵ�塣</param>
		/// <param name="thisCompanyCode">string:	��λ��Ϣ.</param>
		/// <param name="RoleID">int:	��ɫID.</param>
		public void GetUserByRole(EntryUser ds,string thisCompanyCode,int RoleID)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20) {Value = thisCompanyCode};
		    arParms[1] = new SqlParameter("@RoleID", SqlDbType.SmallInt) {Value = RoleID};

		    SqlHelper.FillDataset(ConnectionString.PubData , CommandType.StoredProcedure,"mysys_GetUserByRole",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
		/// <summary>
		/// �����ֻ��Ż�ȡ��Ա��Ϣ.
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
        /// �����û�����ȡ�û���Ϣ��
        /// </summary>
        /// <param name="loginName">�û�������¼����</param>
        /// <returns>DataSet</returns>
        public DataSet GetUserByLoginName(string loginName)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where LoginName = '{0}'", loginName);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// ���ݹ�˾��ź�Ա�����Ż�ȡ�û���Ϣ��
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <param name="empCode">���š�</param>
        /// <returns>DataSet��</returns>
        public DataSet GetUserByEmpCode(string companyCode, string empCode)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo = '{0}' And EmpCode = '{1}'",
                                             companyCode, empCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }

        /// <summary>
		/// ���ݹ�˾��ָ����Ȩ�����ȡ�û���
		/// </summary>
		/// <param name="thisCompanyCode">��˾���롣</param>
		/// <param name="rightCode">Ȩ���롣</param>
		/// <returns>���ص���mySystemUserInfo��Ӧ��DataSet��</returns>
		/// <example>
		/// <code>
		/// ���ԣ�C#
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
		/// �����û������������趨.
		/// </summary>
		/// <param name="loginName">�û���</param>
		/// <param name="pwd">����</param>
		/// <param name="salt">������</param>
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
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_SetPassword",arParms);//���µ�Password1.
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
			    ret= false;
			}
			return ret;
		}
		/// <summary>
		/// ����PKID���������趨.
		/// </summary>
		/// <param name="pkID">ID</param>
		/// <param name="thisPassword">����</param>
		/// <param name="thisSalt">������</param>
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
		/// �����û����õ��û����еĽ�ɫ
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
		/// �����û����Ͳ�Ʒ��Ż�ȡ�û���ɫ.
		/// </summary>
		/// <param name="thisUserCode">string:�û���</param>
		/// <param name="ProductCode">int:��Ʒ���</param>
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
		/// �����û���,CheckCode,Type��ȡ�û���ɫ.
		/// </summary>
		/// <param name="thisUserCode">�û���.</param>
		/// <param name="checkCode">CheckCode</param>
		/// <param name="type">����,A,B,C����.</param>
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
		/// �����û�����ȡ���е��û���ɫ.
		/// </summary>
		/// <param name="thisUserCode">�û���.</param>
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
		/// �õ��û����е���
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
		
		/// <summary>
		/// �õ������û���ɫ�б�
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
		/// �����û�.
		/// </summary>
		/// <param name="userCode">�û���.</param>
		/// <param name="state">״̬</param>
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
		/// �����û�PKID�����û�״̬.
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
		/// �����û����Ͳ�Ʒ���ɾ���û��Ľ�ɫ.
		/// </summary>
		/// <param name="UserCode">string:�û���</param>
		/// <param name="ProductCode">int:��Ʒ���</param>
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
		/// ɾ���û���ɫ
		/// </summary>
		/// <param name="userCode">�û���</param>
		/// <param name="checkCode">����id(֪ʶ����)</param>
		/// <param name="type">��������(֪ʶ����)</param>
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
		/// �����������CheckCode ��Type�ļ�¼
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
		/// ��ȡû�������κη���Ȩ�޵Ķ���.
		/// </summary>
		/// <param name="rightCode">Ȩ�޴���</param>
		/// <param name="productcode">��Ʒ����</param>
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
