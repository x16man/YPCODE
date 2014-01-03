using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.Security;

namespace Shmzh.Components.SystemComponent
{
	/// <summary>
	/// UserDA 的摘要说明。
	/// </summary>
	public class RoleDA
	{
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// 构造函数
		/// </summary>
		public RoleDA()
		{
		}

		/// <summary>
		/// 增加角色
		/// </summary>
		/// <param name="roleCode">角色编号</param>
		/// <param name="roleName">角色名称</param>
		/// <param name="isValid">是否有效</param>
		/// <param name="remark">备注</param>
		/// <param name="productCode">所属产品</param>
		/// <returns>是否增加成功</returns>
		public bool AddRole(int roleCode,string roleName,string isValid,string remark,int productCode)
		{
			var ret=true;

			try
			{
				var arParms = new SqlParameter[5];
				arParms[0] = new SqlParameter("@RoleCode", SqlDbType.SmallInt ) {Value = roleCode};
			    arParms[1] = new SqlParameter("@RoleName", SqlDbType.NVarChar,50) {Value = roleName};
			    arParms[2] = new SqlParameter("@IsValid", SqlDbType.NChar,1 ) {Value = isValid};
			    arParms[3] = new SqlParameter("@Remark", SqlDbType.NVarChar,50) {Value = remark};
			    arParms[4] = new SqlParameter("@ProductCode", SqlDbType.SmallInt ) {Value = productCode};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData  ,CommandType.StoredProcedure,"mysys_AddRole",arParms);

			}
			catch(Exception ex)
			{
                Logger.Error(ex.Message);
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 增加角色
		/// </summary>
		/// <param name="roleName">角色名称</param>
		/// <param name="isValid">是否有效</param>
		/// <param name="remark">角色描述</param>
		/// <param name="productCode">产品编号</param>
		/// <returns>bool</returns>
		public bool AddRole(string roleName,bool isValid,string remark,int productCode)
		{
			var ret=true;

			try
			{
				var strValid="N";
				if(isValid) strValid="Y";

				var arParms = new SqlParameter[4];
				arParms[0] = new SqlParameter("@RoleName", SqlDbType.NVarChar,50) {Value = roleName};
			    arParms[1] = new SqlParameter("@IsValid", SqlDbType.NChar,1 ) {Value = strValid};
			    arParms[2] = new SqlParameter("@Remark", SqlDbType.NVarChar,50) {Value = remark};
			    arParms[3] = new SqlParameter("@ProductCode", SqlDbType.SmallInt ) {Value = productCode};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData  ,CommandType.StoredProcedure,"mysys_AddRole_km",arParms);

			}
			catch(Exception ex)
			{
                Logger.Error(ex.Message);
				ret=false;
			}

			return ret;
		}

		/// <summary>
		/// 给用户绑定角色
		/// </summary>
		/// <param name="userName">用户名</param>
		/// <param name="rolelist">角色编号串</param>
		/// <returns>bool</returns>
		public bool AddRole(string userName,string rolelist)
		{
			var ret=true;

			try
			{
				var arParms = new SqlParameter[2];
				arParms[0] = new SqlParameter("@UserCode", SqlDbType.NVarChar,20 ) {Value = userName};
			    arParms[1] = new SqlParameter("@RoleCodeList", SqlDbType.NVarChar,4000 ) {Value = rolelist};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData  ,CommandType.StoredProcedure,"mysys_AddUserRoles",arParms);
			}
			catch(Exception ex)
			{
                Logger.Error(ex.Message);
				ret=false;
			}
			return ret;
		}
		
		
		/// <summary>
		/// 更改角色
		/// </summary>
		/// <param name="roleCode">角色编号</param>
		/// <param name="roleName">角色名称</param>
		/// <param name="isValid">是否有效</param>
		/// <param name="remark">备注</param>
		/// <param name="productCode">所属产品</param>
		/// <returns>是否增加成功</returns>
		public bool UpdateRole(int roleCode,string roleName,string isValid,string remark,int productCode)
		{
			var ret=true;
			try
			{
				var strSQL="UPDATE mySystemRoles SET RoleName='" + roleName + "',IsValid='" +  isValid + "',Remark='" + remark + "' where RoleCode=" + roleCode + " and ProductCode=" + productCode;
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData  ,CommandType.Text,strSQL);
			}
			catch(Exception ex)
			{
                Logger.Error(ex.Message);
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 删除角色
		/// </summary>
		/// <param name="roleCode">角色编号</param>
		/// <param name="productCode">产品编号</param>
		/// <returns>bool</returns>
		public bool DeleteRole(int roleCode,int productCode)
		{
			var ret=true;
			try
			{
				var arParms = new SqlParameter[2];
				arParms[0] = new SqlParameter("@RoleCode", SqlDbType.SmallInt) {Value = roleCode};
			    arParms[1] = new SqlParameter("@ProductCode", SqlDbType.SmallInt) {Value = productCode};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData  ,CommandType.StoredProcedure,"mysys_DeleteRole",arParms);
			}
			catch(Exception ex)
			{
                Logger.Error(ex.Message);
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 获取所有角色.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetAllRoles()
		{
			var strSQL="SELECT * FROM mySystemRoles";
			return SqlHelper.ExecuteDataset(ConnectionString.PubData  ,CommandType.Text,strSQL);
		}
		/// <summary>
		/// 得到产品的说有角色
		/// </summary>
		/// <param name="productcode"></param>
		/// <returns></returns>
		public DataSet GetAllRoles(int productcode)
		{
            var sqlStatement = "Select * From mySystemRoles Where ProductCode = @ProductCode";
            var parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@ProductCode", SqlDbType.SmallInt) { Value = productcode };
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
        /// <summary>
        /// 根据产品编号获取所有有效的角色。
        /// </summary>
        /// <param name="productcode">产品编号。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllAvalibleRoles(int productcode)
        {
            var sqlStatement = "Select * From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y'";
            var parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@ProductCode", SqlDbType.SmallInt) { Value = productcode };
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 判断是否已经存在该角色.
        /// </summary>
        /// <param name="roleCode">角色编号</param>
        /// <param name="productCode">产品编号</param>
        /// <returns>bool</returns>
        public bool IsExistRole(int roleCode, int productCode)
        {
            var ret = false;
            var strSQL = "SELECT * FROM mySystemRoles where RoleCode=" + roleCode + " and ProductCode=" + productCode;
            var ds = SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, strSQL);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret = true;
                }
            }
            return ret;
        }	

		/// <summary>
		/// 得到所有的角色权限
		/// </summary>
		public DataSet GetAllRoleRights()
		{
			return SqlHelper.ExecuteDataset(ConnectionString.PubData  ,CommandType.StoredProcedure,"mysys_GetAllRoleRights");
		}
		
		/// <summary>
		/// 增加用户角色.
		/// </summary>
		/// <param name="userCodeList">用户名串</param>
		/// <param name="roleCodeList">角色编号串</param>
		/// <param name="ProductCode">产品编号</param>
		/// <returns>bool</returns>
		public bool AddUserRole(string userCodeList, string roleCodeList, int ProductCode)
		{
			var flag = true;
			try
			{
				var commandParameters = new SqlParameter[4];
				commandParameters[0] = new SqlParameter("@UserCodeList", SqlDbType.NVarChar, 0xfa0) {Value = userCodeList};
			    commandParameters[1] = new SqlParameter("@RoleCodeList", SqlDbType.NVarChar, 0xfa0) {Value = roleCodeList};
			    commandParameters[2] = new SqlParameter("@ProductCode", SqlDbType.Int) {Value = ProductCode};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData  , CommandType.StoredProcedure, "mysys_AddUsersRoles", commandParameters);
			}
			catch(Exception ex)
			{
                Logger.Error(ex.Message);
				flag = false;
			}
			return flag;
		}
		/// <summary>
		/// 增加用户角色
		/// </summary>
		/// <param name="userCodeList">用户名串</param>
		/// <param name="roleCodeList">角色编号串</param>
		/// <param name="checkCode">checkCode</param>
		/// <param name="type">type</param>
		/// <returns>bool</returns>
		public bool AddUserRole(string userCodeList,string roleCodeList,string checkCode,string type)
		{
			var ret=true;

			try
			{
				var arParms = new SqlParameter[4];
				arParms[0] = new SqlParameter("@UserCodeList", SqlDbType.NVarChar,4000 ) {Value = userCodeList};
			    arParms[1] = new SqlParameter("@RoleCodeList", SqlDbType.NVarChar,4000 ) {Value = roleCodeList};
			    arParms[2] = new SqlParameter("@CheckCode", SqlDbType.NVarChar,50 ) {Value = checkCode};
			    arParms[3] = new SqlParameter("@Type", SqlDbType.NChar,1 ) {Value = type};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData  ,CommandType.StoredProcedure,"mysys_AddUsersRolesByCheckCode",arParms);
			}
			catch(Exception ex)
			{
                Logger.Error(ex.Message);
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 根据产品编号获取用户角色.
		/// </summary>
		/// <param name="ProductCode">产品编号</param>
		/// <returns>DataSet</returns>
		public DataSet GetUsersRolesByProduct(int ProductCode)
		{
			var sqlStatement = string.Format(@"SELECT A.UserCode ,C.EmpCnName as EmpName,A.RoleCode,B.RoleName,A.CheckCode,A.Type 
                                                 FROM   mySystemUserRoles A,
                                                        mySystemRoles B,
                                                        mySystemUserInfo C 
                                                 WHERE  B.ProductCode = {0} And 
                                                        A.RoleCode=B.RoleCode AND  
                                                        A.UserCode=C.LoginName", ProductCode);

            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
        /// <summary>
        /// 根据产品编号和角色编号获取用户角色列表。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>DataSet</returns>
        public DataSet GetUsersRolesByProductAndRole(int productCode, string roleCode)
        {
            var sqlStatement = string.Format(@"SELECT A.UserCode ,C.EmpCnName as EmpName,A.RoleCode,B.RoleName,A.CheckCode,A.Type 
                                                 FROM   mySystemUserRoles A,
                                                        mySystemRoles B,
                                                        mySystemUserInfo C 
                                                 WHERE  B.ProductCode = {0} AND 
                                                        A.RoleCode = B.RoleCode AND  
                                                        A.RoleCode = '{1}' AND
                                                        A.UserCode = C.LoginName", productCode, roleCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 根据产品编号和登录名或姓名获取所有的用户角色列表。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">登录名或姓名</param>
        /// <returns>DataSet</returns>
        public DataSet GetUsersRolesByProductAndName(int productCode, string name)
        {
            var sqlStatement = string.Format(@"SELECT A.UserCode ,C.EmpCnName as EmpName,A.RoleCode,B.RoleName,A.CheckCode,A.Type 
                                                 FROM   mySystemUserRoles A,
                                                        mySystemRoles B,
                                                        mySystemUserInfo C 
                                                 WHERE  B.ProductCode = {0} AND 
                                                        A.RoleCode = B.RoleCode AND  
                                                        A.UserCode = C.LoginName AND
                                                        (C.LoginName Like '%{1}%' OR C.EmpCnName Like '%{1}%')", productCode, name);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		///	根据checkCode和Type获取
		/// </summary>
		/// <param name="checkCode">checkCode</param>
		/// <param name="type">type</param>
		/// <returns>DataSet</returns>
		/// <remarks>知识库用</remarks>
		public DataSet GetUsersRoles(string checkCode,string type)
		{
			var strSQL=string.Format(@"  SELECT  A.UserCode ,C.EmpCnName as EmpName,A.RoleCode,B.RoleName,A.CheckCode,A.Type 
                                            FROM    mySystemUserRoles A,
                                                    mySystemRoles B,
                                                    mySystemUserInfo C 
                                            WHERE   A.CheckCode='{0}' AND 
                                                    A.Type='{1}' And 
                                                    A.RoleCode=B.RoleCode AND 
                                                    A.UserCode=C.LoginName", checkCode,type);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData  ,CommandType.Text,strSQL);
		}
		/// <summary>
		/// 根据产品编号获取用户角色.
		/// </summary>
		/// <param name="productCode">产品编号</param>
		/// <returns>DataTable</returns>
		public DataTable GetLoginNameByProduct(int productCode)
		{
		    var commandText = string.Format(@"SELECT distinct A.UserCode  
                                                 FROM   mySystemUserRoles A, mySystemRoles B 
                                                 WHERE  B.ProductCode = {0} And 
                                                        A.RoleCode = B.RoleCode", productCode);
			var ds = SqlHelper.ExecuteDataset(ConnectionString.PubData  , CommandType.Text, commandText);
			if (ds != null)
			{
				return ds.Tables[0];
			}
			return null;
		}
        /// <summary>
        /// 根据产品编号和角色编号，获取用户登录名列表。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>DataTable</returns>
        public DataTable GetLoginNameByProductAndRole(int productCode,string roleCode)
        {
            var sqlStatement = string.Format(@"SELECT distinct A.UserCode  
                                                 FROM   mySystemUserRoles A, mySystemRoles B 
                                                 WHERE  B.ProductCode = {0} And
                                                        A.RoleCode = '{1}' And 
                                                        A.RoleCode = B.RoleCode", productCode,roleCode);
            var ds = SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return ds == null ? null : ds.Tables[0];
        }
        /// <summary>
        /// 根据产品编号和登录名或姓名获取登录名列表。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">登录名或姓名。</param>
        /// <returns>DataTable</returns>
        public DataTable GetLoginNameByProductAndName(int productCode, string name)
        {
            var sqlStatement = string.Format(@"  Select  Distinct A.UserCode
                                                    From    mySystemUserRoles A,mySystemRoles B,mySystemUserInfo C
                                                    Where   B.ProductCode = {0} And
                                                            A.RoleCode = B.RoleCode And
                                                            A.UserCode = C.LoginName And
                                                            (C.LoginName like '%{1}%' OR C.EmpCnName like '%{1}%') ",productCode,name);
            var ds = SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return ds == null ? null : ds.Tables[0];
        }
		/// <summary>
		/// 根据checkCode和type获取用户角色
		/// </summary>
		/// <param name="checkCode">checkCode</param>
		/// <param name="type">type</param>
		/// <returns>DataTable</returns>
		public DataTable GetUsersRoleList(string checkCode,string type)
		{
		    var strSQL="SELECT distinct UserCode FROM mySystemUserRoles WHERE CheckCode='" + checkCode + "' AND Type='" + type + "'";
			var ds = SqlHelper.ExecuteDataset(ConnectionString.PubData  ,CommandType.Text,strSQL);
			return ds!=null ? ds.Tables[0] : null;
		}
		/// <summary>
		/// 根据角色编号和产品编号获取角色信息
		/// </summary>
		/// <returns></returns>
		public DataSet GetRoleByRoleCode(int roleCode,int productCode)
		{
			var strSQL=string.Format("SELECT * FROM mySystemRoles where RoleCode={0} And ProductCode={1}", roleCode,productCode);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text,strSQL);
		}
	}
}
