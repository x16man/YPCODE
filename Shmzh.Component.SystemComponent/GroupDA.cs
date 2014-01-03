// <copyright file="GroupDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
	/// <summary>
	/// ���������ݷ��ʲ㡣
	/// </summary>
	public class GroupDA
	{
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// ���캯��
		/// </summary>
		public GroupDA()
		{
		}
		/// <summary>
		/// ��ȡ���з���.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetAllGroups()
		{
			try
			{
				var strSQL = "SELECT * FROM mySystemGroups";
				return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text,strSQL);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
			    return null;
			}
		}
		/// <summary>
		/// ���ӷ���.
		/// </summary>
		/// <param name="groupName">������</param>
		/// <param name="remark">������</param>
		/// <returns>bool</returns>
		public bool AddGroup(string groupName, string remark)
		{
			var ret = true;
			try
			{
				var arParms = new SqlParameter[2];
				arParms[0] = new SqlParameter("@GroupName", SqlDbType.NVarChar,50) {Value = groupName};
			    arParms[1] = new SqlParameter("@Remark", SqlDbType.NVarChar,50) {Value = remark};

			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_AddGroup",arParms);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �������û�.
		/// </summary>
		/// <param name="groupCode">����</param>
		/// <param name="userlist">�û��б�</param>
		/// <returns>bool</returns>
		public bool AddGroupUser(int groupCode,string userlist)
		{
			var ret = true;
			try
			{
				var arParms = new SqlParameter[2];
				arParms[0] = new SqlParameter("@GroupCode", SqlDbType.SmallInt ) {Value = groupCode};
			    arParms[1] = new SqlParameter("@UserCodeList", SqlDbType.NVarChar,4000 ) {Value = userlist};

				SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_AddGroupUsers",arParms);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ɾ������.
		/// </summary>
		/// <param name="groupCode">����</param>
		/// <returns>bool</returns>
		public bool DeleteGroup(int groupCode)
		{
			var ret = true;
			try
			{
				var arParms = new SqlParameter[1];
				arParms[0] = new SqlParameter("@GroupCode", SqlDbType.Int) {Value = groupCode};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_DeleteGroup",arParms);
			}
			catch(Exception ex)
			{
                Logger.Error(ex.Message);
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���·���.
		/// </summary>
		/// <param name="groupCode">����</param>
		/// <param name="groupName">������</param>
		/// <param name="remark">������</param>
		/// <returns>bool</returns>
		public bool UpdateGroup(int groupCode,string groupName,string remark)
		{
			var ret = true;
			
			try
			{
				var strSQL = "Update mySystemGroups set GroupName='" + groupName + "', Remark='" + remark + "' where GroupCode=" + groupCode;
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ��ȡ���е����û�.
		/// </summary>
		/// <param name="ds">EntryUser</param>
		/// <param name="groupCode">����</param>
		public void GetAllGroupUsers(EntryUser ds,int groupCode)
		{
			 var strSQL = "SELECT B.* FROM mySystemGroupUsers A,mySystemUserInfo B WHERE A.GroupCode=" + groupCode + " AND A.UserCode=B.LoginName";

			SqlHelper.FillDataset(ConnectionString.PubData ,CommandType.Text,strSQL,ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE});
		}
		/// <summary>
		/// ���������ж��Ƿ���ڸ���.
		/// </summary>
		/// <param name="groupCode">����.</param>
		/// <returns>bool</returns>
		public bool IsExistGroup(int groupCode)
		{
			DataSet ds = null;
			var ret = false;

			try
			{
				var strSQL = "SELECT * FROM mySystemGroups where GroupCode=" + groupCode;
				ds = SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
			}

			if (ds != null)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					ret = true;
				}
			}
				
			return ret;
		}	//IsExistGroup
		/// <summary>
		/// ��������봮,��ɫ���봮,��Ʒ����������ɫ.
		/// </summary>
		/// <param name="groupCodeList">����봮</param>
		/// <param name="roleCodeList">��ɫ���봮</param>
		/// <param name="productCode">��Ʒ���봮</param>
		/// <returns>bool</returns>
		public bool AddGroupsRoles(string groupCodeList, string roleCodeList, int productCode)
		{
			var flag = true;
			try
			{
				var commandParameters = new SqlParameter[4];
				commandParameters[0] = new SqlParameter("@GroupCodeList", SqlDbType.NVarChar, 0xfa0) {Value = groupCodeList};
			    commandParameters[1] = new SqlParameter("@RoleCodeList", SqlDbType.NVarChar, 0xfa0) {Value = roleCodeList};
			    commandParameters[2] = new SqlParameter("@ProductCode", SqlDbType.Int) {Value = productCode};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData , CommandType.StoredProcedure, "mysys_AddGroupsRoles", commandParameters);
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		/// <summary>
		/// ��������봮,��ɫ���봮,checkCode,type�������ɫ.
		/// </summary>
		/// <param name="groupCodeList">����봮</param>
		/// <param name="roleCodeList">��ɫ���봮</param>
		/// <param name="checkCode">checkcode</param>
		/// <param name="type">type</param>
		/// <returns>bool</returns>
		public bool AddGroupsRoles(string groupCodeList,string roleCodeList,string checkCode,string type)
		{
			var ret = true;

			try
			{
				var arParms = new SqlParameter[4];
				
                // @ProductID Input Parameter 
				arParms[0] = new SqlParameter("@GroupCodeList", SqlDbType.NVarChar,4000 ) {Value = groupCodeList};
			    arParms[1] = new SqlParameter("@RoleCodeList", SqlDbType.NVarChar,4000 ) {Value = roleCodeList};
			    arParms[2] = new SqlParameter("@CheckCode", SqlDbType.NVarChar,50 ) {Value = checkCode};
			    arParms[3] = new SqlParameter("@Type", SqlDbType.NChar,1 ) {Value = type};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_AddGroupsRolesByCheckCode",arParms);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ݲ�Ʒ�����ȡ���ɫ.
		/// </summary>
		/// <param name="productCode">��Ʒ����</param>
		/// <returns>DataSet</returns>
		public DataSet GetGroupsRolesByProduct(int productCode)
		{
			var sqlStatement = string.Format(@"SELECT A.GroupCode,C.GroupName,A.RoleCode,B.RoleName,A.CheckCode,A.Type 
                                                    FROM    mySystemGroupRoles A,
                                                            mySystemRoles B,
                                                            mySystemGroups C 
                                                    WHERE   B.ProductCode = {0} And 
                                                            A.RoleCode=B.RoleCode AND 
                                                            A.GroupCode=C.GroupCode", productCode);

            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
        /// <summary>
        /// ���ݲ�Ʒ��źͽ�ɫ��Ż�ȡ���ɫ�б�
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <param name="roleCode">��ɫ��š�</param>
        /// <returns>DataSet</returns>
        public DataSet GetGroupsRolesByProductAndRole(int productCode, string roleCode)
        {
            var sqlStatement = string.Format(@"SELECT A.GroupCode,C.GroupName,A.RoleCode,B.RoleName,A.CheckCode,A.Type 
                                                    FROM    mySystemGroupRoles A,
                                                            mySystemRoles B,
                                                            mySystemGroups C 
                                                    WHERE   B.ProductCode = {0} And 
                                                            A.RoleCode=B.RoleCode AND 
                                                            A.GroupCode=C.GroupCode AND
                                                            A.RoleCode = '{1}'", productCode, roleCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// ���ݲ�Ʒ��ź�������ȡ���ɫ�б�
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <param name="name">������</param>
        /// <returns>DataSet</returns>
        public DataSet GetGroupsRolesByProductAndName(int productCode, string name)
        {
            var sqlStatement = string.Format(@"SELECT A.GroupCode,C.GroupName,A.RoleCode,B.RoleName,A.CheckCode,A.Type 
                                                    FROM    mySystemGroupRoles A,
                                                            mySystemRoles B,
                                                            mySystemGroups C 
                                                    WHERE   B.ProductCode = {0} And 
                                                            A.RoleCode=B.RoleCode AND 
                                                            A.GroupCode=C.GroupCode AND
                                                            C.GroupName Like '%{1}%'", productCode, name);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// ����checkcode��Type��ȡ���ɫ.
		/// </summary>
		/// <param name="checkCode">checkCode</param>
		/// <param name="type">����</param>
		/// <returns>DataSet</returns>
		public DataSet GetGroupsRoles(string checkCode,string type)
		{
			var sqlStatement = string.Format(@"SELECT    A.GroupCode,C.GroupName,A.RoleCode,B.RoleName,A.CheckCode,A.Type 
                                              FROM      mySystemGroupRoles A,
                                                        mySystemRoles B,
                                                        mySystemGroups C 
                                                WHERE   A.CheckCode='{0}' AND 
                                                        A.Type='{1}' And 
                                                        A.RoleCode=B.RoleCode AND 
                                                        A.GroupCode=C.GroupCode", checkCode, type);

             return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
		/// <summary>
		/// ��ȡ���ɫ�б�.
		/// </summary>
		/// <param name="productCode">��Ʒ���</param>
		/// <returns>DataTable</returns>
		public DataTable GetGroupRoleListByProduct(int productCode)
		{
			var commandText = string.Format(@"SELECT distinct A.GroupCode  
                                                FROM    mySystemGroupRoles A, 
                                                        mySystemRoles B 
                                                WHERE   A.RoleCode = B.RoleCode And 
                                                        B.ProductCode = {0}", productCode);

			var set = SqlHelper.ExecuteDataset(ConnectionString.PubData , CommandType.Text, commandText);
			return set != null ? set.Tables[0] : null;
		}
        /// <summary>
        /// ���ݲ�Ʒ��źͽ�ɫ��Ż�ȡ���ɫ�б�һ�����Ӧһ���ɫƴ�Ӵ���
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <param name="roleCode">��ɫ��š�</param>
        /// <returns>DataTable</returns>
        public DataTable GetGroupRoleListByProductAndRole(int productCode,string roleCode)
        {
            var sqlStatement = string.Format(@"SELECT distinct A.GroupCode  
                                                FROM    mySystemGroupRoles A, 
                                                        mySystemRoles B 
                                                WHERE   A.RoleCode = B.RoleCode And 
                                                        A.RoleCode = '{1}' And
                                                        B.ProductCode = {0}", productCode, roleCode);
            var set = SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return set != null ? set.Tables[0] : null;
        }
        /// <summary>
        /// ���ݲ�Ʒ��ź�������ȡ���ɫ�б�
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <param name="name">������</param>
        /// <returns>DataTable</returns>
        public DataTable GetGroupRoleListByProductAndName(int productCode, string name)
        {
            var sqlStatement = string.Format(@"SELECT distinct A.GroupCode  
                                                FROM    mySystemGroupRoles A, 
                                                        mySystemRoles B ,
                                                        mySystemGroups C
                                                WHERE   A.RoleCode = B.RoleCode And 
                                                        A.GroupCode = C.GroupCode And
                                                        C.GroupName Like '%{1}%' And
                                                        B.ProductCode = {0}", productCode, name);
            var set = SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return set != null ? set.Tables[0] : null;
        }
        /// <summary>
		/// ��ȡ���û���ɫ�б�.
		/// </summary>
		/// <param name="checkCode">checkCode</param>
		/// <param name="type">type</param>
		/// <returns>DataTable</returns>
		/// <remarks>֪ʶ��ʹ��</remarks>
		public DataTable GetGroupRoleList(string checkCode,string type)
		{
			var strSQL = string.Format(@"SELECT  distinct GroupCode 
                                            FROM    mySystemGroupRoles 
                                            WHERE   CheckCode='{0}' AND Type='{1}'",checkCode, type);
            var ds = SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, strSQL);
			return ds != null ? ds.Tables[0] : null;
		}
		/// <summary>
		/// ɾ�����ɫ.
		/// </summary>
		/// <param name="groupCode">����</param>
		/// <returns>bool</returns>
		public bool DeleteGroupRoles(int groupCode)
		{
			var flag = true;
			try
			{
				var commandText = string.Format("\tDelete\tFrom mySystemGroupRoles \r\n\t\t\t\t\t\t\t\t\t\t\t\tWhere\tGroupCode={0}", groupCode);
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData , CommandType.Text, commandText);
			}
			catch (Exception e)
			{
                Logger.Error(e.Message);
			    flag = false;
			}
			return flag;
		}
		/// <summary>
		/// ɾ���û���ɫ
		/// </summary>
		/// <param name="groupCode">�û���</param>
		/// <param name="checkCode">checkcode</param>
		/// <param name="type">����</param>
		/// <returns>bool</returns>
		/// <remarks>֪ʶ��ʹ��</remarks>
		public bool DeleteGroupRoles(int groupCode,string checkCode,string type)
		{
			bool ret = true;

			try
			{
				string strSQL = "delete from mySystemGroupRoles where GroupCode=" + groupCode + " and CheckCode='" + checkCode + "' and  Type='" + type + "'";
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����������checkcode��type�����û���ɫ.
		/// </summary>
		/// <param name="checkCode">checkCode</param>
		/// <param name="type">type</param>
		/// <returns>bool</returns>
		/// <remarks>֪ʶ��ʹ��</remarks>
		public bool ClearAccess(string checkCode,string type)
		{
			bool ret = true;

			try
			{
				string strSQL = "delete from mySystemGroupRoles where CheckCode='" + checkCode + "' and  Type='" + type + "'";
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.Text,strSQL);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ��ȡ����δ���й��������õ�֪ʶ�����
		/// </summary>
		/// <param name="rightCode">Ȩ����</param>
		/// <returns>DataSet</returns>
		/// <remarks>֪ʶ��ʹ��</remarks>
		public DataSet GetNoAccessObj(int rightCode)
		{
			string strSQL = "select distinct A.CheckCode,A.Type from mySystemGroupRoles A where not exists(select CheckCode,Type from (select A.CheckCode,A.Type from mySystemGroupRoles A,mySystemRoleRights B Where A.RoleCode=B.RoleCode And B.RightCode=" + rightCode + ") as B where A.checkcode = B.checkcode and  A.Type = B.Type)";
			return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text,strSQL);
		}
		/// <summary>
		/// ������CODE�õ����еĽ�ɫ
		/// </summary>
		/// <param name="groupCode">����</param>
		/// <returns>DataSet</returns>
		public DataSet GetGroupRoles(int groupCode)
		{
			var strSQL = "SELECT B.ROLECODE,B.ROLENAME,B.PRODUCTCODE,A.CheckCode,A.Type FROM mySystemGroupRoles A,mySystemRoles B WHERE A.GroupCode=" + groupCode + " AND A.RoleCode=B.RoleCode AND B.ISVALID='Y'";
			return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text,strSQL);
		}
		/// <summary>
		/// �������źͲ�Ʒ��Ż�ȡ���е����ɫ.
		/// </summary>
		/// <param name="groupCode">����</param>
		/// <param name="productCode">��Ʒ���</param>
		/// <returns>DataSet</returns>
		public DataSet GetGroupRoles(int groupCode, int productCode)
		{
			var commandText = string.Format("Select\tB.RoleCode, B.RoleName, B.ProductCode, A.CheckCode, A.Type\r\n\t\t\t\t\t\t\t\t\t\t\tFrom\tmySystemGroupRoles A, mySystemRoles B\r\n\t\t\t\t\t\t\t\t\t\t\tWhere\tA.GroupCode = {0} And\r\n\t\t\t\t\t\t\t\t\t\t\t\t\tA.RoleCode = B.RoleCode And\r\n\t\t\t\t\t\t\t\t\t\t\t\t\tB.ProductCode = {1} And\r\n\t\t\t\t\t\t\t\t\t\t\t\t\tB.IsValid = 'Y'", groupCode, productCode);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData , CommandType.Text, commandText);
		}
		/// <summary>
		/// ��������,checkcode,type��ȡ��Ľ�ɫ.
		/// </summary>
		/// <param name="groupCode">����</param>
		/// <param name="checkCode">checkCode</param>
		/// <param name="type">type</param>
		/// <returns>DataSet</returns>
		public DataSet GetGroupRoles(int groupCode,string checkCode,string type)
		{
			var strSQL = "SELECT B.ROLECODE,B.ROLENAME,B.PRODUCTCODE,A.CheckCode,A.Type FROM mySystemGroupRoles A,mySystemRoles B WHERE A.GroupCode=" + groupCode + " And CheckCode='" + checkCode + "' And Type='" + type  + "' AND A.RoleCode=B.RoleCode AND B.ISVALID='Y'";
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, strSQL);
		}
		/// <summary>
		/// �������Ż�ȡ����Ϣʵ��.
		/// </summary>
		/// <param name="groupCode">����</param>
		/// <returns>Dataset</returns>
		public DataSet GetGroupByCode(int groupCode)
		{
			var strSQL = "SELECT * FROM mySystemGroups WHERE GroupCode=" + groupCode;
			return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text,strSQL);
		}
		/// <summary>
		/// ����ָ�������ź��û�������ɾ�����û�.
		/// </summary>
		/// <param name="groupCode">����</param>
		/// <param name="userlist">�û�����</param>
		/// <returns>bool</returns>
		public bool DeleteGroupUser(int groupCode,string userlist)
		{
			var ret = true;
			try
			{
				var arParms = new SqlParameter[2];
				arParms[0] = new SqlParameter("@GroupCode", SqlDbType.SmallInt ) {Value = groupCode};
			    arParms[1] = new SqlParameter("@UserCodeList", SqlDbType.NVarChar,4000 ) {Value = userlist};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_DeleteGroupUsers",arParms);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
	}
}
