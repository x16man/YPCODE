#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
    using Shmzh.MM.Common;
	/// <summary>
	/// SBODs 的摘要说明。
	/// </summary>
	public class SBODs:Messages
	{
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region 私有方法
        /// <summary>
        /// 根据单据类型编号获取单据类型实体。
        /// </summary>
        /// <param name="docCode">单据类型编号。</param>
        /// <returns>单据类型实体。</returns>
        private SBODData GetByDocCode(int docCode)
        {
            var obj = new SBODData();
            var parms = new[] {new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = docCode}};
            SqlHelper.FillDataset(ConnectionString.MM,"Sys_DocGetDocByCode",obj,new[]{SBODData.SBOD_TABLE},parms);
            return obj;
        }
		#endregion

		#region 方法
        /// <summary>
        /// 根据单据类型编号获取名称。
        /// </summary>
        /// <param name="docCode">单据类型编号。</param>
        /// <returns>单据类型名称。</returns>
        public string GetDocNameByDocCode(int docCode)
        {
            var oDataRow = this.GetByDocCode(docCode).Tables[SBODData.SBOD_TABLE].Rows[0];
            return oDataRow[SBODData.DOCNAME_FIELD].ToString();            
        }
		/// <summary>
		/// 获取单据的审批级数。
		/// </summary>
		/// <param name="docCode">int:	单据类型。</param>
		/// <returns>int:	审批级数。</returns>
		public int GetAuditLevelByDocCode(int docCode)
		{
            var oDataRow = this.GetByDocCode(docCode).Tables[SBODData.SBOD_TABLE].Rows[0];

			return int.Parse(oDataRow[SBODData.AUDITLEVEL_FIELD].ToString());
		}


		/// <summary>
		/// 得到所有的单据类型
		/// </summary>
		/// <returns>SBODData:	单据类型实体。</returns>
		public SBODData GetAllBillOfDocs()
		{
			var sqlStatement="SELECT * FROM SBOD";

			var ds=new SBODData();
            SqlHelper.FillDataset(ConnectionString.MM,CommandType.Text,sqlStatement,ds,new[]{SBODData.SBOD_TABLE} );
            
			return ds;

		}		
		/// <summary>
		/// 增加用户对于某种单据的可操作部门列表。
		/// </summary>
		/// <param name="userCode">string:	用户。</param>
		/// <param name="roleCode">角色Id</param>
		/// <param name="docCode">int:	单据类型。</param>
		/// <param name="deptCodeList">string:	可操作部门列表。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddUserDocDepts(string userCode,short roleCode,short docCode,string deptCodeList)
		{
		    var parms = new[]
		                    {
		                        new SqlParameter("@UserCode", SqlDbType.NVarChar, 20) {Value = userCode},
                                new SqlParameter("@DocCode", SqlDbType.SmallInt){Value = docCode},
		                        new SqlParameter("@RoleCode", SqlDbType.SmallInt) {Value = roleCode},
                                new SqlParameter("@DeptCodeList",SqlDbType.NVarChar,4000){Value = deptCodeList},
		                    };
		    try
		    {
		        SqlHelper.ExecuteNonQuery(ConnectionString.MM, "Sys_UserDocDeptsInsert", parms);
                this.Message = "Success";
                return true;
		    }
		    catch (Exception ex)
		    {
		        Logger.Error(ex.Message, ex);
                this.Message = "Error,Look log!";
                return false;
		    }
		}

		/// <summary>
		/// 获取用户对于某种单据的可操作部门。
		/// </summary>
		/// <param name="userCode">string:	用户。</param>
		/// <param name="docCode">int:	单据类型。</param>
		/// <returns>DataTable: 数据表。</returns>
		public DataTable GetAllDeptsByUserAndDoc(string userCode,short docCode)
		{
			var sqlStatement=string.Format("SELECT Distinct UserCode,DeptCode,DocCode from SUDD WHERE UserCode='{0}' AND DocCode={1}",userCode, docCode);
		    var ds = SqlHelper.ExecuteDataset(ConnectionString.MM, CommandType.Text, sqlStatement);
			if(ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
		    return null;
		}
        /// <summary>
        /// 根据用户登录名、单据类型、角色获取部门。
        /// </summary>
        /// <param name="userCode">用户登录名</param>
        /// <param name="docCode">单据类型</param>
        /// <param name="roleCode">角色Id</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllDeptsByUserAndDocAndRole(string userCode,short docCode,short roleCode)
        {
            var sqlStatement = string.Format("SELECT UserCode,DeptCode,DocCode from SUDD WHERE UserCode='{0}' AND DocCode={1} And RoleCode = {2}", userCode, docCode,roleCode);
            var ds = SqlHelper.ExecuteDataset(ConnectionString.MM, CommandType.Text, sqlStatement);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        /// <summary>
        /// 根据用户登录名和单据类型来获取用户管辖的部门。
        /// </summary>
        /// <param name="userLoginId">用户登录名</param>
        /// <param name="docCode">单据类型</param>
        /// <returns>部门数据集</returns>
        public DeptData GetQueryDeptsByUserAndDoc(string userLoginId, short docCode)
        {
            var oDeptData = new DeptData();
            var parms = new[]
                            {
                                new SqlParameter("@UserLoginId", SqlDbType.NVarChar, 20) {Value = userLoginId},
                                new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = docCode},
                            };
            SqlHelper.FillDataset(ConnectionString.MM, "Sys_QueryGetDeptByUserAndDoc", oDeptData, new[] { DeptData.Dept_Table }, parms);
			return oDeptData;
        }

        /// <summary>
        /// 根据用户名获取有权管辖的所有部门。
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <returns>部门信息的DataTable</returns>
        public DataTable GetAllDeptsBySuDD(string loginName)
        {
            string sqlStatement = " SELECT DeptCode,DeptCNName from ViewSUDDList WHERE UserCode='" + loginName + "'";
            var ds = SqlHelper.ExecuteDataset(ConnectionString.MM, CommandType.Text, sqlStatement);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
            {
                return null;
            }
        }
		/// <summary>
		/// 获取用户对于某种单据的部门列表。
		/// </summary>
		/// <param name="userLoginId">用户登录名。</param>
		/// <param name="docCode">单据类型。</param>
		/// <returns>DeptData:	部门数据实体。</returns>
		public DeptData GetDeptByUserAndDoc(string userLoginId, short docCode)
		{
			var oDeptData = new DeptData();
		    var parms = new[]
		                    {
		                        new SqlParameter("@UserLoginId", SqlDbType.NVarChar, 20) {Value = userLoginId},
		                        new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = docCode},
		                    };
            SqlHelper.FillDataset(ConnectionString.MM, "Sys_BODGetDeptByUserAndDoc", oDeptData, new[] { DeptData.Dept_Table }, parms);
			return oDeptData;
		}
#endregion
		
	}
}
