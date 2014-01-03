//-----------------------------------------------------------------------
// <copyright file="OrganizeDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

	/// <summary>
	/// 针对于组织机构的数据访问类.
	/// </summary>
	/// <remarks>包括了对于公司信息、部门信息、职位信息、员工与用户、组织人员、职位等方面</remarks>
	public class OrganizeDA : Messages
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        /// <summary>
		/// 构造函数
		/// </summary>
		public OrganizeDA()
		{
		}
		#region 公司信息
		/// <summary>
		/// 填充公司信息到指定的EntryCompanyInfo对象中.
		/// </summary>
		/// <param name="ds">EntryCompanyInfo对象</param>
		public void GetCompanyInfo(EntryCompanyInfo ds)
		{
			SqlHelper.FillDataset(ConnectionString.PubData,CommandType.StoredProcedure,"mysys_GetCompanyInfo",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE});
		}		
		/// <summary>
		/// 填充活动的公司信息到EntryCompanyInfo实体中.
		/// </summary>
		/// <param name="ds">EntryCompanyInfo</param>
		public void GetActiveCompanies(EntryCompanyInfo ds)
		{
			SqlHelper.FillDataset(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_GetActiveCompanies",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE});
		}

		/// <summary>
		/// 新增公司
		/// </summary>
		/// <param name="entrycompany">公司记录实体。</param>
		/// <returns>bool</returns>
		public bool AddCompany(EntryCompanyInfo entrycompany)
		{
			bool ret = true;
			try
			{
				var arParms = new SqlParameter[15];

				arParms[0] = new SqlParameter("@CoCode", SqlDbType.NVarChar,20 )
				                 {
				                     Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COCODE_FIELD]
				                 };

			    arParms[1] = new SqlParameter("@CoCnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COCNNAME_FIELD]
			                     };

			    arParms[2] = new SqlParameter("@CoShortName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COENNAME_FIELD]
			                     };

			    arParms[3] = new SqlParameter("@CoEnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COSHORTNAME_FIELD]
			                     };

			    arParms[4] = new SqlParameter("@ParentCo", SqlDbType.NVarChar,50 )
			                     {
			                         Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.PARENTCO_FIELD]
			                     };

			    arParms[5] = new SqlParameter("@ParentCoName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.PARENTCONAME_FIELD]
			                     };

			    arParms[6] = new SqlParameter("@ArtificialPerson", SqlDbType.NVarChar,50 )
			                     {
			                         Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.ARTIFICIALPERSON_FIELD]
			                     };

			    arParms[7] = new SqlParameter("@Mgr", SqlDbType.NVarChar,50 )
			                     {
			                         Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.MGR_FIELD]
			                     };

			    arParms[8] = new SqlParameter("@BussinessLicense", SqlDbType.NVarChar,50 )
			                     {
			                         Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.BUSINESSLICENSE_FIELD]
			                     };

			    arParms[9] = new SqlParameter("@BussinessRange", SqlDbType.NVarChar,50 )
			                     {
			                         Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.BUSINESSRANGE_FIELD]
			                     };

			    arParms[10] = new SqlParameter("@IsValid", SqlDbType.Char,1 )
			                      {
			                          Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.ISVALID_FILED]
			                      };

			    arParms[11] = new SqlParameter("@CoArea", SqlDbType.NVarChar,50 )
			                      {
			                          Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COAREA_FIELD]
			                      };

			    arParms[12] = new SqlParameter("@CoAddress", SqlDbType.NVarChar,50 )
			                      {
			                          Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COADDRESS_FIELD]
			                      };

			    arParms[13] = new SqlParameter("@Remark", SqlDbType.NVarChar,50 )
			                      {
			                          Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.REMARK_FIELD]
			                      };

			    arParms[14] = new SqlParameter("@IsDefault", SqlDbType.VarChar,1 )
			                      {
			                          Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.ISDEFAULT_FIELD]
			                      };

			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_AddCompany",arParms);
			}
			catch (Exception ex)
			{
				this.Message = "添加公司信息失败！";
                Logger.Error(ex.Message);
                ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 更新公司信息
		/// </summary>
		/// <param name="entrycompany">公司记录实体。</param>
		/// <returns>bool</returns>
		public bool UpdateCompany(EntryCompanyInfo entrycompany)
		{
			var ret = true;
			try
			{
				var arParms = new SqlParameter[15];

				arParms[0] = new SqlParameter("@CoCode", SqlDbType.NVarChar,20 ); 
				arParms[0].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COCODE_FIELD];

				arParms[1] = new SqlParameter("@CoCnName", SqlDbType.NVarChar,50 ); 
				arParms[1].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COCNNAME_FIELD];

				arParms[2] = new SqlParameter("@CoShortName", SqlDbType.NVarChar,50 ); 
				arParms[2].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COSHORTNAME_FIELD];

				arParms[3] = new SqlParameter("@CoEnName", SqlDbType.NVarChar,50 ); 
				arParms[3].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COENNAME_FIELD];

				arParms[4] = new SqlParameter("@ParentCo", SqlDbType.NVarChar,50 ); 
				arParms[4].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.PARENTCO_FIELD];

				arParms[5] = new SqlParameter("@ParentCoName", SqlDbType.NVarChar,50 ); 
				arParms[5].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.PARENTCONAME_FIELD];

				arParms[6] = new SqlParameter("@ArtificialPerson", SqlDbType.NVarChar,50 ); 
				arParms[6].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.ARTIFICIALPERSON_FIELD];

				arParms[7] = new SqlParameter("@Mgr", SqlDbType.NVarChar,50 ); 
				arParms[7].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.MGR_FIELD];

				arParms[8] = new SqlParameter("@BussinessLicense", SqlDbType.NVarChar,50 ); 
				arParms[8].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.BUSINESSLICENSE_FIELD];

				arParms[9] = new SqlParameter("@BussinessRange", SqlDbType.NVarChar,50 ); 
				arParms[9].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.BUSINESSRANGE_FIELD];

				arParms[10] = new SqlParameter("@IsValid", SqlDbType.Char,1 ); 
				arParms[10].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.ISVALID_FILED];

				arParms[11] = new SqlParameter("@CoArea", SqlDbType.NVarChar,50 ); 
				arParms[11].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COAREA_FIELD];

				arParms[12] = new SqlParameter("@CoAddress", SqlDbType.NVarChar,50 ); 
				arParms[12].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.COADDRESS_FIELD];

				arParms[13] = new SqlParameter("@Remark", SqlDbType.NVarChar,50 ); 
				arParms[13].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.REMARK_FIELD];

				arParms[14] = new SqlParameter("@IsDefault", SqlDbType.VarChar,1 ); 
				arParms[14].Value = entrycompany.Tables[0].Rows[0][EntryCompanyInfo.ISDEFAULT_FIELD];

				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_UpdateCompany",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				this.Message = "更新公司失败！";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 判断公司编号是否经存在.
		/// </summary>
		/// <param name="companyCode">公司的编号</param>
		/// <returns>bool类型：存在返回true，否则返回false。</returns>
		public bool IsExistCoCode(string companyCode)
		{
			string sqlStatement = "SELECT Count(*) FROM mySystemCompanyInfo WHERE CoCode='" + companyCode + "'";
			object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// 判断公司编号是否经存在并且是默认.
		/// </summary>
		/// <param name="companyCode">公司的编号</param>
		/// <returns>是否已经存在</returns>
		public bool IsExistDefaultCoCode(string companyCode)
		{
			string sqlStatement = string.Format("Select Count(*) from mySystemCompanyInfo where CoCode='{0}' AND [IsDefault]='Y'",companyCode);
			object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// 填充缺省的激活的公司到EntryCompanyInfo实体中.
		/// </summary>
		/// <param name="ds">EntryCompanyInfo</param>
		public void GetDefaultCompany(EntryCompanyInfo ds)
		{
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetDefaultCompany",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE});
		}
        /// <summary>
        /// 填充缺省的激活的公司信息。
        /// </summary>
        /// <returns>DataSet类型：公司的信息。</returns>
        public DataSet GetDefaultCompany()
        {
             return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_GetDefaultCompany");
        }
		/// <summary>
		/// 根据指定的公司编号,将子公司信息填充到EntryCompanyInfo实体中.
		/// </summary>
		/// <param name="ds">EntryCompanyInfo实体.</param>
		/// <param name="thisCompanyCode">上级公司编号</param>
		public void GetSubCompany(EntryCompanyInfo ds,string thisCompanyCode)
		{
			SqlParameter[] arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@ParentCo", SqlDbType.NVarChar,20 ); 
			arParms[0].Value = thisCompanyCode;
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetSubCompany",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE},arParms);
		}
		/// <summary>
		/// 根据公司编号获取公司信息.
		/// </summary>
        /// <param name="ds">公司信息实体。</param>
		/// <param name="companyCode">公司编号.</param>
		public void GetCompanyByCode(EntryCompanyInfo ds,string companyCode)
		{
			SqlParameter[] arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ); 
			arParms[0].Value = companyCode;
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetCompanyByCode",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE},arParms);
		}
		/// <summary>
		/// 根据公司编号获取公司信息.
		/// </summary>
		/// <param name="companyCode">公司编号.</param>
		/// <returns>DataSet</returns>
		public DataSet GetCompanyByCode(string companyCode)
		{
			SqlParameter[] arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ); 

			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetCompanyByCode",arParms);
		}
		/// <summary>
		/// 根据公司编号编号公司信息
		/// </summary>
        /// <param name="companyCode">公司编号</param>
		/// <returns>bool</returns>
		public bool DeleteCompany(string companyCode)
		{
			bool ret = true;
			try
			{
				SqlParameter[] arParms = new SqlParameter[1];
				arParms[0] = new SqlParameter("@CoCode", SqlDbType.NVarChar,50 );
                arParms[0].Value = companyCode;
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_DeleteCompany",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				this.Message = "删除公司时出错!";
                ret = false;
			}
			return ret;
		}
		#endregion
	
		#region 部门
		/// <summary>
		/// 根据公司编号获取所有有效的部门填充到EntryDept实体中.
		/// </summary>
		/// <param name="ds">EntryDept实体.</param>
		/// <param name="thisCompanyCode">公司代码</param>
        [Obsolete("此方法以作废！代替以GetAllDeptsByCompany(EntryDept ds,string companyCode)",false)]
		public void GetDeptsByCompany(EntryDept ds,string thisCompanyCode)
		{
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetALLDeptsByCompany",ds,new[] {EntryDept.MYSYSTEMDEPT_TABLE},arParms);
		}
        /// <summary>
        /// 根据公司编号获取所有有效部门的列表。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>DataSet类型：部门的数据集。</returns>
        public DataSet GetAllAvalibleDeptsByCompany(string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemDept WHERE DeptCo='{0}' AND IsValid='Y'",companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 根据公司编号获取所有有效的部门列表。
        /// </summary>
        /// <param name="depts">部门实体。</param>
        /// <param name="companyCode">公司编号。</param>
        public void GetAllAvalibleDeptsByCompany(EntryDept depts, string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemDept WHERE DeptCo='{0}' AND IsValid='Y'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, depts, new[] { EntryDept.MYSYSTEMDEPT_TABLE });
        }
        /// <summary>
        /// 根据公司编号获取所有部门的列表。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllDeptsByCompany(string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemDept WHERE DeptCo='{0}'", companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 根据公司编号获取所有的部门。
        /// </summary>
        /// <param name="depts">部门实体。</param>
        /// <param name="companyCode">公司编号。</param>
        public void GetAllDeptsByCompany(EntryDept depts, string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemDept WHERE DeptCo='{0}'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, depts, new[] { EntryDept.MYSYSTEMDEPT_TABLE });
        }
		/// <summary>
		/// 根据公司编号获取所有部门填充到EntryDept实体中.
		/// </summary>
		/// <param name="ds">EntryDept实体.</param>
		/// <param name="thisCompanyCode">公司代码</param>
        /// <param name="strValid">"All"则返回所有部门，否则只返回有效的部门</param>
		public void GetDeptsByCompany(EntryDept ds,string thisCompanyCode,string strValid)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    arParms[1] = new SqlParameter("@Valid",SqlDbType.NVarChar,20) {Value = strValid};

		    SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetDeptsByCompany",ds,new[] {EntryDept.MYSYSTEMDEPT_TABLE},arParms);
		}

		/// <summary>
		/// 根据公司编号和部门主管用户名获取部门信息,将信息填充到EntryDept实体中.
		/// </summary>
		/// <param name="ds">EntryDept实体.</param>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisDeptManager">部门主管的用户名</param>
		public void GetDeptsByManager(EntryDept ds, string thisCompanyCode, string thisDeptManager)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    arParms[1] = new SqlParameter("@UserName", SqlDbType.NVarChar,20) {Value = thisDeptManager};

		    SqlHelper.FillDataset(ConnectionString.PubData,  CommandType.StoredProcedure,"mysys_GetDeptsByCompanyAndManager",ds, new[] {EntryDept.MYSYSTEMDEPT_TABLE },arParms); 
		}
		/// <summary>
		/// 根据公司编号和上级部门编号获取子级部门,将信息填充到EntryDept实体中.
		/// </summary>
		/// <param name="ds">EntryDept实体</param>
		/// <param name="thisCompanyCode">公司代码</param>
		/// <param name="thisDeptCode">部门代码</param>
		public void GetSubDeptsByParent(EntryDept ds,string thisCompanyCode,string thisDeptCode)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    arParms[1] = new SqlParameter("@ParentDept", SqlDbType.NVarChar,20 ) {Value = thisDeptCode};
		    SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetSubDeptsByParent",ds,new[] {EntryDept.MYSYSTEMDEPT_TABLE},arParms);
		}	
		/// <summary>
		/// 根据公司编号和部门编号和指定要填充的数据载体进行部门信息的填充.
		/// </summary>
		/// <param name="ds">EntryDept类型的数据实体.</param>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisDeptCode">部门编号.</param>
		public void GetDeptByDeptCode(EntryDept ds,string thisCompanyCode,string thisDeptCode)
		{
			var strSQL = "Select * from mySystemDept Where DeptCode='" + thisDeptCode + "' and DeptCo='" + thisCompanyCode + "'";
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text,strSQL,ds,new[] {EntryDept.MYSYSTEMDEPT_TABLE});
		}

		/// <summary>
		/// 根据组织类型号 是否有使用组织类型的
		/// </summary>
		/// <param name="strTypeID">EntryDept类型的数据实体.</param>
		/// <returns>True 为有使用 false为无使用</returns>
		public bool IsHaveTypeUsing(string strTypeID)
		{
			var strSQL = "Select * from mySystemDept Where TypeID='" + strTypeID + "'";
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,strSQL).Tables[0].Rows.Count > 0;
		}

		/// <summary>
		/// 增加部门
		/// </summary>
		/// <param name="thisEntryDept">EntryDept实体 </param>
		/// <returns>是否增加成功</returns>
		public bool AddDept(EntryDept thisEntryDept)
		{
			var ret = true;
			try
			{
				var arParms = new SqlParameter[15];
				arParms[0] = new SqlParameter("@DeptCode", SqlDbType.NVarChar,20 )
				                 {
				                     Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTCODE_FIELD]
				                 };
			    arParms[1] = new SqlParameter("@DeptCo", SqlDbType.NVarChar,20 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTCO_FIELD]
			                     };
			    arParms[2] = new SqlParameter("@DeptCnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTCNNAME_FIELD]
			                     };
			    arParms[3] = new SqlParameter("@DeptEnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTENNAME_FIELD]
			                     };
			    arParms[4] = new SqlParameter("@ParentDept", SqlDbType.NVarChar,20 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.PARENTDEPT_FIELD]
			                     };
			    arParms[5] = new SqlParameter("@ParentDeptName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.PARENTDEPTNAME_FIELD]
			                     };
			    arParms[6] = new SqlParameter("@DeptMgr", SqlDbType.NVarChar,20 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTMGR_FIELD]
			                     };
			    arParms[7] = new SqlParameter("@IsValid", SqlDbType.NChar,1 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.ISVALID_FIELD]
			                     };
			    arParms[8] = new SqlParameter("@Remark", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.REMARK_FIELD]
			                     };
			    arParms[9] = new SqlParameter("@Serial", SqlDbType.SmallInt)
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.SERIAL_FIELD]
			                     };
			    arParms[10] = new SqlParameter("@TypeID", SqlDbType.NVarChar,20 )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.TYPEID_FIELD]
			                      };
			    arParms[11] = new SqlParameter("@TypeName", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.TYPENAME_FIELD]
			                      };
			    arParms[12] = new SqlParameter("@DeptMgrName", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTMGRNAME_FIELD]
			                      };
			    arParms[13] = new SqlParameter("@CostCenter", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.COSTCENTER_FIELD]
			                      };
			    arParms[14] = new SqlParameter("@ShowInOtherSys", SqlDbType.Int )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.SHOWINOTHERSYS_FIELD]
			                      };
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_AddDepartment",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				this.Message = "添加部门信息失败！";
                ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 更新部门。
		/// </summary>
		/// <param name="thisEntryDept">EntryDept实体</param>
		/// <returns>bool</returns>
		public bool UpdateDept(EntryDept thisEntryDept)
		{
			bool ret = true;
			try
			{
				var arParms = new SqlParameter[15];
				arParms[0] = new SqlParameter("@DeptCode", SqlDbType.NVarChar,20 )
				                 {
				                     Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTCODE_FIELD]
				                 };
			    arParms[1] = new SqlParameter("@DeptCo", SqlDbType.NVarChar,20 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTCO_FIELD]
			                     };
			    arParms[2] = new SqlParameter("@DeptCnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTCNNAME_FIELD]
			                     };
			    arParms[3] = new SqlParameter("@DeptEnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTENNAME_FIELD]
			                     };
			    arParms[4] = new SqlParameter("@ParentDeptCode", SqlDbType.NVarChar,20 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.PARENTDEPT_FIELD]
			                     };
			    arParms[5] = new SqlParameter("@ParentDeptName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.PARENTDEPTNAME_FIELD]
			                     };
			    arParms[6] = new SqlParameter("@DeptMgr", SqlDbType.NVarChar,20 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTMGR_FIELD]
			                     };
			    arParms[7] = new SqlParameter("@IsValid", SqlDbType.NChar,1 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.ISVALID_FIELD]
			                     };
			    arParms[8] = new SqlParameter("@Remark", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.REMARK_FIELD]
			                     };
			    arParms[9] = new SqlParameter("@Serial", SqlDbType.SmallInt)
			                     {
			                         Value = thisEntryDept.Tables[0].Rows[0][EntryDept.SERIAL_FIELD]
			                     };
			    arParms[10] = new SqlParameter("@TypeID", SqlDbType.NVarChar,20 )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.TYPEID_FIELD]
			                      };
			    arParms[11] = new SqlParameter("@TypeName", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.TYPENAME_FIELD]
			                      };
			    arParms[12] = new SqlParameter("@DeptMgrName", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.DEPTMGRNAME_FIELD]
			                      };
			    arParms[13] = new SqlParameter("@CostCenter", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.COSTCENTER_FIELD]
			                      };
			    arParms[14] = new SqlParameter("@ShowInOtherSys", SqlDbType.Int )
			                      {
			                          Value = thisEntryDept.Tables[0].Rows[0][EntryDept.SHOWINOTHERSYS_FIELD]
			                      };
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_UpdateDepartment",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				this.Message = "组织代码或者组织描述已经存在,请重新命名";
                ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 移动部门
		/// </summary>
		/// <param name="deptCode">部门编号</param>
		/// <param name="deptCo">公司编号</param>
		/// <param name="targetParentDeptCode">目标父部门</param>
		/// <returns>bool</returns>
		public bool MoveDept(string deptCode,string deptCo,string targetParentDeptCode)
		{
			bool ret = true;
			try
			{
				var arParms = new SqlParameter[3];
				arParms[0] = new SqlParameter("@DeptCode", SqlDbType.NVarChar,20 ) {Value = deptCode};
			    arParms[1] = new SqlParameter("@DeptCo", SqlDbType.NVarChar,20 ) {Value = deptCo};
			    arParms[2] = new SqlParameter("@TargetParentDeptCode", SqlDbType.NVarChar,20 ) {Value = targetParentDeptCode};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_MoveDepartment",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				this.Message = "移动部门失败！";
                ret = false;
			}
			return ret;
		}
		
		/// <summary>
		/// 根据公司编号和部门编号删除部门.
		/// </summary>
		/// <param name="thisDeptCode">部门编号</param>
		/// <param name="deptCo">公司编号</param>
		/// <returns>bool</returns>
		public bool DeleteDept(string thisDeptCode,string deptCo)
		{
			var ret = true;
			try
			{
				var arParms = new SqlParameter[2];
				arParms[0] = new SqlParameter("@DeptCode", SqlDbType.NVarChar,20 ) {Value = thisDeptCode};
			    arParms[1] = new SqlParameter("@DeptCo", SqlDbType.NVarChar,20 ) {Value = deptCo};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_DeleteOrg",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				this.Message = "删除部门时出错!";
                ret = false;
			}
			return ret;
		}
        /// <summary>
        /// 作废部门。
        /// </summary>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="deptCo">所属公司。</param>
        /// <returns>bool</returns>
        public bool DisableDept(string deptCode, string deptCo)
        {
            var ret = true;
            try
            {
                var arParms = new SqlParameter[2];
                arParms[0] = new SqlParameter("@DeptCode", SqlDbType.NVarChar, 20) { Value = deptCode };
                arParms[1] = new SqlParameter("@DeptCo", SqlDbType.NVarChar, 20) { Value = deptCo };
                var sqlStatement = "Update mySystemDept Set IsValid = 'N' Where DeptCode = @DeptCode And DeptCo = @DeptCo";
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement, arParms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                this.Message = "失效部门时出错!";
                ret = false;
            }
            return ret;
        }
		/// <summary>
		/// 判断部门编号是否已经存在.
		/// </summary>
		/// <param name="deptCode">部门代码</param>
		/// <param name="deptCo">公司编号</param>
		/// <returns>是否已经存在</returns>
		public bool IsExistDeptCode(string deptCode,string deptCo)
		{
			var sqlStatement = string.Format("Select Count(*) from mySystemDept where DeptCode='{0}' and DeptCo='{1}'", deptCode,deptCo);
            Logger.Info(sqlStatement);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            Logger.Info(oRet.ToString());
            bool ret = int.Parse(oRet.ToString()) == 0 ? false : true;
            Logger.Info(ret);
		    return ret;
		}
		/// <summary>
		/// 判断部门名称是否已经存在.
		/// </summary>
		/// <param name="deptCo">公司编号</param>
		/// <param name="thisDeptName">部门名称</param>
		/// <returns>bool</returns>
		public bool IsExistDeptName(string deptCo,string thisDeptName)
		{
            var sqlStatement = string.Format("Select Count(*) from mySystemDept where DeptCo='{0}' and DeptCnName='{1}'", deptCo, thisDeptName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }

        #region OrgType
		/// <summary>
		/// 获取组织类型
		/// </summary>
		/// <param name="isValid">是否有效</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgType(string isValid)
		{
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@IsValid", SqlDbType.NVarChar,10) {Value = isValid.ToUpper()};
		    return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetOrgType", arParms);
		}
        /// <summary>
        /// 判断组织机构类型的编号或名称是否已经存在。
        /// </summary>
        /// <param name="orgTypeCodeOrName">组织机构类型的编号或中文名称。</param>
        /// <returns>bool类型：存在返回True，否则返回False。</returns>
        public bool IsExist(string orgTypeCodeOrName)
        {
            var sqlStatement = string.Format("Select Count(*) From mySystemOrgType Where Code ='{0}' OR CnName='{0}'", orgTypeCodeOrName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
        /// <summary>
        /// 增加组织类型
        /// </summary>
        /// <param name="code">编码</param>
        /// <param name="level">级别</param>
        /// <param name="cnname">中文描述</param>
        /// <param name="enname">英文描述</param>
        /// <param name="isvalid">是否有效</param>
        /// <returns>是否增加成功</returns> 
        public bool AddOrgType(string code, int level, string cnname, string enname, string isvalid)
        {
            var ret = true;
            try
            {
                var sqlStatement = string.Format("Insert Into mySystemOrgType(Code,Level,CnName,EnName,IsValid) Values ('{0}',{1},'{2}','{3}','{4}')",code,level,cnname,enname,isvalid);
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("增加组织类型时发生异常：{0}", ex.Message));
                this.Message = "添加组织类型时发生异常，添加失败！";
                ret = false;
            }
            return ret;
        }
        /// <summary>
        /// 更改组织机构类型。
        /// </summary>
        /// <param name="code">编码</param>
        /// <param name="level">级别</param>
        /// <param name="cnname">中文描述</param>
        /// <param name="enname">英文描述</param>
        /// <param name="isvalid">是否有效</param>
        /// <returns>是否增加成功</returns> 
        public bool UpdateOrgType(string code, int level, string cnname, string enname, string isvalid)
        {
            var ret = true;
            try
            {
                var arParms = new SqlParameter[5];
                arParms[0] = new SqlParameter("@Code", SqlDbType.NVarChar, 20) {Value = code};
                arParms[1] = new SqlParameter("@Level", SqlDbType.SmallInt) {Value = level};
                arParms[2] = new SqlParameter("@CnName", SqlDbType.NVarChar, 50) {Value = cnname};
                arParms[3] = new SqlParameter("@EnName", SqlDbType.NVarChar, 50) {Value = enname};
                arParms[4] = new SqlParameter("@IsValid", SqlDbType.NChar, 1) {Value = isvalid};
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_UpdateOrgType", arParms);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("更新组织机构类型的时候发生异常：{0}", ex.Message));
                this.Message = "更新组织机构类型的时候发生异常，更新没有成功！";
                ret = false;
            }
            return ret;
        }
        /// <summary>
        /// 删除组织类型
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns>是否增加成功</returns> 
        public bool DeleteOrgType(string code)
        {
            var ret = true;
            try
            {
                var arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@TypeCode", SqlDbType.NVarChar, 20) {Value = code};
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_deleteOrgType", arParms);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("删除组织机构类型时发生异常：{0}", ex.Message));
                this.Message = "删除组织机构类型时发生异常，删除失败！";
                ret = false;
            }
            return ret;
        }
        #endregion
        #endregion

        #region 职位
        /// <summary>
		/// 检索公司的职位填充到EntryDuty实体.
		/// </summary>
		/// <param name="ds">EntryDuty实体</param>
		/// <param name="thisCompanyCode">公司编号</param>
		public void FillDutiesByCompany(EntryDuty ds,string thisCompanyCode)
		{
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_GetDutiesByCompany", ds, new[] {EntryDuty.MYSYSTEMDUTY_TABLE}, arParms);
		}
        /// <summary>
        /// 根据公司编号获取职务信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllDutiesByCompany(string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemDuty Where DutyCo = '{0}'",companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 根据公司编号获取所有的有效的职位信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllAvalibleDutiesByCompany(string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemDuty Where DutyCo = '{0}' And IsValid = 'Y'", companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// 增加职位.
		/// </summary>
		/// <param name="thisEntryDuty">EntryDuty实体.</param>
		/// <returns>bool</returns>
		public bool AddDuty(EntryDuty thisEntryDuty)
		{
			var ret = true;
			try
			{
                var oRow = thisEntryDuty.Tables[0].Rows[0];
				var dutyCo = oRow[EntryDuty.DUTYCO_FIELD].ToString();
                var dutyCode = oRow[EntryDuty.DUTYCODE_FIELD].ToString();
                var parentDutyCode = oRow[EntryDuty.PARENTDUTYCODE_FIELD].ToString();
                var dutyCnName = oRow[EntryDuty.DUTYCNNAME_FIELD].ToString();
                var dutyEnName = oRow[EntryDuty.DUTYENNAME_FIELD].ToString();
                var isValid = oRow[EntryDuty.ISVALID_FIELD].ToString();
                var remark = oRow[EntryDuty.REMARK_FIELD].ToString();
                var dutyLevel = short.Parse(oRow[EntryDuty.DUTYLEVEL_FIELD].ToString());
                string sqlStatement = string.Format("Insert Into mySystemDuty (DutyCo,DutyCode,ParentDutyCode,DutyCnName,DutyEnName,IsValid,DutyLevel,Remark) Values ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}')",
                    dutyCo, dutyCode, parentDutyCode, dutyCnName, dutyEnName, isValid, dutyLevel, remark);
                
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				this.Message = "职位添加失败！";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 更新duty
		/// </summary>
		/// <param name="thisEntryDuty">EntryDuty实体.</param>
		/// <returns>bool</returns>
		public bool UpdateDuty(EntryDuty thisEntryDuty)
		{
			bool ret = true;
			try
			{
                string dutyCo, dutyCode, parentDutyCode, dutyCnName, dutyEnName, isValid, remark;
                short dutyLevel;
                DataRow oRow = thisEntryDuty.Tables[0].Rows[0];
                dutyCo = oRow[EntryDuty.DUTYCO_FIELD].ToString();
                dutyCode = oRow[EntryDuty.DUTYCODE_FIELD].ToString();
                parentDutyCode = oRow[EntryDuty.PARENTDUTYCODE_FIELD].ToString();
                dutyCnName = oRow[EntryDuty.DUTYCNNAME_FIELD].ToString();
                dutyEnName = oRow[EntryDuty.DUTYENNAME_FIELD].ToString();
                isValid = oRow[EntryDuty.ISVALID_FIELD].ToString();
                remark = oRow[EntryDuty.REMARK_FIELD].ToString();
                dutyLevel = short.Parse(oRow[EntryDuty.DUTYLEVEL_FIELD].ToString());
                
                string sqlStatement = string.Format("Update mySystemDuty Set DutyCo = '{0}',DutyCode='{1}',ParentDutyCode='{2}',DutyCnName='{3}',DutyEnName='{4}',IsValid='{5}',DutyLevel={6},Remark='{7}' Where dutyCo='{0}' And dutyCode='{1}'",
                    dutyCo, dutyCode, parentDutyCode, dutyCnName, dutyEnName, isValid, dutyLevel, remark);
                
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement);				
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                this.Message = "职位更新失败！";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 移动职位.
		/// </summary>
		/// <param name="dutyCode">职位编号</param>
		/// <param name="dutyCo">公司编号</param>
		/// <param name="targetParentDutyCode">上级职位编号</param>
		/// <returns>bool</returns>
		public bool MoveDuty(string dutyCode,string dutyCo,string targetParentDutyCode)
		{
			bool ret = true;
			try
			{
				SqlParameter[] arParms = new SqlParameter[3];
				arParms[0] = new SqlParameter("@DutyCode", SqlDbType.NVarChar,20 ); 
				arParms[0].Value = dutyCode;
				arParms[1] = new SqlParameter("@DutyCo", SqlDbType.NVarChar,20 ); 
				arParms[1].Value = dutyCo;
				arParms[2] = new SqlParameter("@targetParentDutyCode", SqlDbType.NVarChar,20 ); 
				arParms[2].Value = targetParentDutyCode;
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_MoveDuty",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                this.Message = "Please look log file";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据公司编号和职位编号获取员工信息.
		/// </summary>
		/// <param name="dutyCode">职位编号</param>
		/// <param name="dutyCo">公司编号</param>
		/// <param name="empCnNames">员工姓名串</param>
		/// <returns>员工用户名串.</returns>
		public string GetDutyUsers(string dutyCode,string dutyCo,out string empCnNames)
		{
			string ids = string.Empty;
			empCnNames = string.Empty;
			string strSQL = "Select E.EmpCnName,D.LoginName from mySystemUserDuty as D,mySystemUserInfo as E where E.LoginName=D.LoginName and D.DutyCode='" + dutyCode + "' and D.DutyCo='" + dutyCo  + "'";
			DataSet ds = SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,strSQL);
			if (ds != null)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					for (int i = 0;i < ds.Tables[0].Rows.Count;i++)
					{
						if (ids == string.Empty)
						{
							ids = ds.Tables[0].Rows[i]["LoginName"].ToString();
							empCnNames = ds.Tables[0].Rows[i]["EmpCnName"].ToString();
						}
						else
						{
                            ids += "," + ds.Tables[0].Rows[i]["LoginName"];
							empCnNames += "," + ds.Tables[0].Rows[i]["EmpCnName"];
						}
					}
				}
			}
			return ids;
		}
		/// <summary>
		/// 根据公司编号和职位编号获取职位信息,填充到EntryDuty实体.
		/// </summary>
		/// <param name="ds">EntryDuty实体</param>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisDutyCode">职位编号</param>
		public void GetDutyByDutyCode(EntryDuty ds,string thisCompanyCode,string thisDutyCode)
		{
            var sqlStatement = string.Format("SELECT * FROM mySystemDuty WHERE DutyCode='{0}' AND DutyCo='{1}'", thisDutyCode, thisCompanyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryDuty.MYSYSTEMDUTY_TABLE });
		}
		/// <summary>
		/// 判断职位代码是否已经存在
		/// </summary>
		/// <param name="dutyCode">职位编号</param>
		/// <param name="dutyCo">公司编号</param>
		/// <returns>bool</returns>
		public bool IsExistDutyCode(string dutyCode,string dutyCo)
		{
            string sqlStatement = string.Format("SELECT Count(*) FROM mySystemDuty WHERE DutyCode='{0}' AND DutyCo='{1}'", dutyCode, dutyCo);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// 根据公司编号和职位编号删除职位.
		/// </summary>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisDutyCode">职位编号</param>
		/// <returns>bool</returns>
		public bool DeleteDuty(string thisCompanyCode, string thisDutyCode)
		{			
			bool ret = true;
			try
			{
				var arParms = new SqlParameter[2];
				arParms[0] = new SqlParameter("@DutyCode", SqlDbType.NVarChar,20 ) {Value = thisDutyCode};
			    arParms[1] = new SqlParameter("@DutyCo", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_DeleteDuty",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                this.Message = "Please look log file";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 判断职位代码是否已经使用
		/// </summary>
		/// <param name="dutyCode">职位编号</param>
		/// <returns>bool</returns>
		public bool IsUsingDutyCode(string dutyCode)
		{
            var sqlStatement = string.Format("Select Count(*) from mySystemUserInfo where DutyCode='{0}' and EmpCo='[1}'", dutyCode);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// 判断名称是否重复
		/// </summary>
		/// <param name="dutyName">职位名称</param>
		/// <param name="dutyCo">公司编号</param>
		/// <returns>bool</returns>
		public bool IsExistDutyName(string dutyName,string dutyCo)
		{
            string sqlStatement = string.Format("SELECT Count(*) FROM mySystemDuty where DutyCnName='{0}' AND DutyCo='{1}'", dutyName, dutyCo);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
        /// <summary>
        /// 职位名称是否已经存在。
        /// </summary>
        /// <param name="dutyCode">职位编号。</param>
        /// <param name="dutyName">职位名称。</param>
        /// <param name="dutyCo">所属公司</param>
        /// <returns>bool</returns>
        public bool IsExistDutyName(string dutyCode,string dutyName, string dutyCo)
        {
            string sqlStatement = string.Format("SELECT Count(*) FROM mySystemDuty where DutyCnName='{0}' AND DutyCo='{1}' AND DutyCode<>'{2}'", dutyName, dutyCo,dutyCode);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
		#endregion

		#region 员工与用户
		/// <summary>
		/// 增加用户
		/// </summary>
		/// <param name="thisEntryUser">用户对象</param>
		/// <returns>成功</returns>
		public bool AddEmployee(EntryUser thisEntryUser)
		{
			bool ret = true;
			try
			{
				var arParms = new SqlParameter[29];
			    var oRow = thisEntryUser.Tables[0].Rows[0];
				arParms[0] = new SqlParameter("@EmpCode", SqlDbType.NVarChar,20 )
				                 {
				                     Value = oRow[EntryUser.EMPCODE_FIELD]
				                 };
			    arParms[1] = new SqlParameter("@EmpCo", SqlDbType.NVarChar,20 )
			                     {
			                         Value = oRow[EntryUser.EMPCO_FIELD]
			                     };
			    arParms[2] = new SqlParameter("@EmpDept", SqlDbType.NVarChar,20 )
			                     {
			                         Value = oRow[EntryUser.EMPDEPT_FIELD]
			                     };
			    arParms[3] = new SqlParameter("@DeptCnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = oRow[EntryUser.DEPTCNNAME_FIELD]
			                     };
			    arParms[4] = new SqlParameter("@DeptEnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = oRow[EntryUser.DEPTENNAME_FIELD]
			                     };
			    arParms[5] = new SqlParameter("@EmpCnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = oRow[EntryUser.EMPCNNAME_FIELD]
			                     };
			    arParms[6] = new SqlParameter("@EmpEnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = oRow[EntryUser.EMPENNAME_FIELD]
			                     };
			    arParms[7] = new SqlParameter("@Gender", SqlDbType.NChar,1 )
			                     {
			                         Value = oRow[EntryUser.GENDER_FIELD]
			                     };
			    arParms[8] = new SqlParameter("@Birthday", SqlDbType.SmallDateTime)
			                     {
			                         Value = oRow[EntryUser.BIRTHDAY_FIELD]
			                     };
			    arParms[9] = new SqlParameter("@LoginName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.LOGINNAME_FIELD]
			                     };
			    
				var pass1 = oRow[EntryUser.PASSWORD1_FIELD].ToString();
			    var salt = new Users().CreateSalt();
				pass1 = new Users().CreatePasswordHash(pass1,salt);
                arParms[10] = new SqlParameter("@Pwd1", SqlDbType.NVarChar, 255) {Value = pass1};

			    arParms[11] = new SqlParameter("@AppandCode", SqlDbType.NVarChar,255 ) {Value = salt};

			    arParms[12] = new SqlParameter("@EmpState", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.EMPSTATE_FIELD]
			                      };

			    arParms[13] = new SqlParameter("@DutyCode", SqlDbType.NVarChar,20 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.DUTYCODE_FIELD]
			                      };

			    arParms[14] = new SqlParameter("@DutyCnName", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.DUTYCNNAME_FIELD]
			                      };

			    arParms[15] = new SqlParameter("@DutyEnName", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.DUTYENNAME_FIELD]
			                      };

			    arParms[16] = new SqlParameter("@IDCard", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.IDCARD_FIELD]
			                      };

			    arParms[17] = new SqlParameter("@OfficeCall", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.OFFICECALL_FIELD]
			                      };

			    arParms[18] = new SqlParameter("@OfficeSubCall", SqlDbType.NVarChar,20 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.OFFICESUBCALL_FIELD]
			                      };

			    arParms[19] = new SqlParameter("@Mobile", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.MOBILE_FIELD]
			                      };

			    arParms[20] = new SqlParameter("@OfficeFax", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.OFFICEFAX_FIELD]
			                      };

			    arParms[21] = new SqlParameter("@Email", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.EMAIL_FIELD]
			                      };

			    arParms[22] = new SqlParameter("@IsUser", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.ISUSER_FIELD]
			                      };

			    arParms[23] = new SqlParameter("@UserState", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.USERSTATE_FIELD]
			                      };

			    arParms[24] = new SqlParameter("@IsEmp", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.ISEMP_FIELD]
			                      };

			    arParms[25] = new SqlParameter("@Pwd2", SqlDbType.NVarChar,255 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.PASSWORD1_FIELD]
			                      };

			    arParms[26] = new SqlParameter("@InDate", SqlDbType.SmallDateTime )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.INDATE_FIELD]
			                      };

			    arParms[27] = new SqlParameter("@IsLeave", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.ISLEAVE_FIELD]
			                      };

			    arParms[28] = new SqlParameter("@LeaveDate", SqlDbType.SmallDateTime )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.LEAVEDATE_FIELD]
			                      };

			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_AddEmployee",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                this.Message = "Please look log file";
                ret = false;
			}
			return ret;
		} // End AddEmployee
		/// <summary>
		/// 更改用户
		/// </summary>
		/// <param name="thisEntryUser">EntryUser实体</param>
		/// <returns>bool</returns>
		public bool UpdateEmployee(EntryUser thisEntryUser)
		{
			bool ret = true;
			try
			{
				var arParms = new SqlParameter[30];
			
				arParms[0] = new SqlParameter("@EmpCode", SqlDbType.NVarChar,20 )
				                 {
				                     Value = thisEntryUser.Tables[0].Rows[0][EntryUser.EMPCODE_FIELD]
				                 };

			    arParms[1] = new SqlParameter("@EmpCo", SqlDbType.NVarChar,20 )
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.EMPCO_FIELD]
			                     };

			    arParms[2] = new SqlParameter("@EmpDept", SqlDbType.NVarChar,20 )
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.EMPDEPT_FIELD]
			                     };

			    arParms[3] = new SqlParameter("@DeptCnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.DEPTCNNAME_FIELD]
			                     };

			    arParms[4] = new SqlParameter("@DeptEnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.DEPTENNAME_FIELD]
			                     };

			    arParms[5] = new SqlParameter("@EmpCnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.EMPCNNAME_FIELD]
			                     };

			    arParms[6] = new SqlParameter("@EmpEnName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.EMPENNAME_FIELD]
			                     };

			    arParms[7] = new SqlParameter("@Gender", SqlDbType.NChar,1 )
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.GENDER_FIELD]
			                     };

			    arParms[8] = new SqlParameter("@Birthday", SqlDbType.SmallDateTime)
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.BIRTHDAY_FIELD]
			                     };

			    arParms[9] = new SqlParameter("@LoginName", SqlDbType.NVarChar,50 )
			                     {
			                         Value = thisEntryUser.Tables[0].Rows[0][EntryUser.LOGINNAME_FIELD]
			                     };

			    arParms[10] = new SqlParameter("@Pwd1", SqlDbType.NVarChar,255 )
				                  {
				                      Value = thisEntryUser.Tables[0].Rows[0][EntryUser.PASSWORD1_FIELD]
				                  };

			    arParms[11] = new SqlParameter("@AppandCode", SqlDbType.NVarChar,255 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.APPANDCODE_FIELD]
			                      };

			    arParms[12] = new SqlParameter("@EmpState", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.EMPSTATE_FIELD]
			                      };

			    arParms[13] = new SqlParameter("@DutyCode", SqlDbType.NVarChar,20 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.DUTYCODE_FIELD]
			                      };

			    arParms[14] = new SqlParameter("@DutyCnName", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.DUTYCNNAME_FIELD]
			                      };

			    arParms[15] = new SqlParameter("@DutyEnName", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.DUTYENNAME_FIELD]
			                      };

			    arParms[16] = new SqlParameter("@IDCard", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.IDCARD_FIELD]
			                      };

			    arParms[17] = new SqlParameter("@OfficeCall", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.OFFICECALL_FIELD]
			                      };

			    arParms[18] = new SqlParameter("@OfficeSubCall", SqlDbType.NVarChar,20 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.OFFICESUBCALL_FIELD]
			                      };

			    arParms[19] = new SqlParameter("@Mobile", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.MOBILE_FIELD]
			                      };

			    arParms[20] = new SqlParameter("@OfficeFax", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.OFFICEFAX_FIELD]
			                      };

			    arParms[21] = new SqlParameter("@Email", SqlDbType.NVarChar,50 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.EMAIL_FIELD]
			                      };

			    arParms[22] = new SqlParameter("@IsUser", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.ISUSER_FIELD]
			                      };

			    arParms[23] = new SqlParameter("@UserState", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.USERSTATE_FIELD]
			                      };

			    arParms[24] = new SqlParameter("@IsEmp", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.ISEMP_FIELD]
			                      };

			    arParms[25] = new SqlParameter("@PKID", SqlDbType.Int )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.PKID_FIELD]
			                      };

			    arParms[26] = new SqlParameter("@Pwd2", SqlDbType.NVarChar,255 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.PASSWORD1_FIELD]
			                      };

			    arParms[27] = new SqlParameter("@InDate", SqlDbType.SmallDateTime )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.INDATE_FIELD]
			                      };

			    arParms[28] = new SqlParameter("@IsLeave", SqlDbType.NChar,1 )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.ISLEAVE_FIELD]
			                      };

			    arParms[29] = new SqlParameter("@LeaveDate", SqlDbType.SmallDateTime )
			                      {
			                          Value = thisEntryUser.Tables[0].Rows[0][EntryUser.LEAVEDATE_FIELD]
			                      };

			    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_UpdateEmployee",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                this.Message = "更新用户信息失败！";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据pkid删除用户.
		/// </summary>
		/// <param name="pkid">PKID</param>
		/// <returns>bool</returns>
		public bool DeleteEmployee(int pkid)
		{
			bool ret = true;
			try
			{
				SqlParameter[] arParms = new SqlParameter[1];
				arParms[0] = new SqlParameter("@PkID", SqlDbType.Int ); 
				arParms[0].Value = pkid;
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_DeleteEmployee", arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                this.Message = "删除用户失败！";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 判断雇员编号是否已经存在
		/// </summary>
		/// <param name="empCode">雇员代码</param>
		/// <returns>是否已经存在</returns>
		public bool IsExistEmpCode(string empCode)
		{
            string sqlStatement = string.Format("Select Count(*) FROM mySystemUserInfo WHERE EmpCode='{0}'", empCode);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
        /// <summary>
        /// 判断除去指定PKID记录外，是否还有重复的工号。
        /// </summary>
        /// <param name="empCode">工号。</param>
        /// <param name="pkid">除外的PKID。</param>
        /// <returns>bool</returns>
        public bool IsExistEmpCode(string empCode, int pkid)
        {
            string sqlStatement = string.Format("Select Count(*) FROM mySystemUserInfo WHERE EmpCode='{0}' And PKID <> {1}", empCode,pkid);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
		/// <summary>
		/// 得到集团所有的雇员
		/// </summary>
		/// <param name="ds">用户实体。</param>
		[Obsolete("此方法已作废，请使用FillAllEmployee(EntryUser ds).",false)]
        public void GetAllEmployee(EntryUser ds)
		{
            /*Select * From mySystemUserInfo*/
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetAllEmployee",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE});
		}
        /// <summary>
        /// 填充所有人员信息到EntryUser实体中。
        /// </summary>
        /// <param name="ds">EntryUser实体。</param>
        public void FillAllEmployee(EntryUser ds)
        {
            string sqlStatement = "Select * From mySystemUserInfo";
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// 获取所有的人员信息。
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetAllEmployee()
        {
            string sqlStatement = "Select * From mySystemUserInfo";
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// 得到满足状态的雇员,填充到EntryUser实体中.
		/// </summary>
		/// <param name="ds">EntryUser实体</param>
		/// <param name="thisState">状态</param>
		[Obsolete("此方法已作废，请使用FillAllEmployeeByState(string companyCode).",false)]
        public void GetAllEmployeeByState(EntryUser ds,string thisState)
		{
            /*SELECT * FROM mySystemUserInfo WHERE EmpState=@EmpState*/
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@EmpState", SqlDbType.NChar,1 ) {Value = thisState};
		    SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetAllEmployeeByState",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
        /// <summary>
        /// 根据员工状态获取人员列表，填充到EntryUser实体。
        /// </summary>
        /// <param name="ds">EntryUser实体。</param>
        /// <param name="empState">员工状态。</param>
        public void FillAllEmployeeByState(EntryUser ds, string empState)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpState='{0}'",empState);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// 根据员工状态获取人员列表。
        /// </summary>
        /// <param name="empState">员工状态。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllEmployeeByState(string empState)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpState='{0}'", empState);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// 根据公司编号获取所有人员列表。
		/// </summary>
		/// <param name="ds">EntryUser实体</param>
		/// <param name="companyCode">公司编号</param>
		[Obsolete("此方法已作废，请使用FillAllEmployeeByCompany(string companyCode).",false)]
        public void GetAllEmployeeByCompany(EntryUser ds,string companyCode)
		{
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}'",companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
		}
        /// <summary>
        /// 根据公司编号获取所有人员列表。
        /// </summary>
        /// <param name="ds">EntryUser实体</param>
        /// <param name="companyCode">公司编号</param>
        public void FillAllEmployeeByCompany(EntryUser ds, string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// 根据公司编号获取所有人员列表。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAllEmployeeByCompany(string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}'", companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 根据公司编号获取所有在职人员的列表,填充到EntryUser实体。
        /// </summary>
        /// <param name="ds">EntryUser实体。</param>
        /// <param name="companyCode">公司编号。</param>
        [Obsolete("此方已作废，请使用FillAllAvalibleEmployeeByCompany(EntryUser ds,string companyCode).",false)]
        public void GetAllAvalibleEmployeeByCompany(EntryUser ds, string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And IsLeave='N'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// 根据公司编号获取所有在职人员的列表,填充到EntryUser实体。
        /// </summary>
        /// <param name="ds">EntryUser实体。</param>
        /// <param name="companyCode">公司编号。</param>
        public void FillAllAvalibleEmployeeByCompany(EntryUser ds, string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And IsLeave='N'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
		/// 得到满足状态条件的某个公司的雇员
		/// </summary>
		/// <param name="ds">EntryUser实体</param>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisState">状态</param>
		public void GetAllEmployeeByCompanyAndState(EntryUser ds,string thisCompanyCode,string thisState)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
            arParms[1] = new SqlParameter("@EmpState", SqlDbType.NChar,1 ) {Value = thisState};
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetAllEmployeeByCompanyAndState",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
        /// <summary>
        /// 根据公司编号和员工状态获取人员列表，填充到EntryUser实体。
        /// </summary>
        /// <param name="ds">EntryUser实体。</param>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="empState">员工状态。</param>
        public void FillAllEmployeeByCompanyAndState(EntryUser ds, string companyCode, string empState)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And EmpState='{1}'",companyCode,empState);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// 根据公司编号和员工装提案获取所有的人员列表。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="empState">员工状态。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllEmployeeByCompanyAndState(string companyCode, string empState)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And EmpState='{1}'", companyCode, empState);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
		/// 根据公司编号、部门编号和员工状态获取所有人员信息填充到EntryUser实体中.
		/// </summary>
		/// <param name="ds">EntryUser实体.</param>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisDeptCode">部门编号</param>
		/// <param name="thisState">员工状态</param>
		[Obsolete("此方法已作废，请使用FillAllEmployeeByCompanyAndDeptAndState（EntryUser ds,string companyCode,string deptCode,string empState).",false)]
        public void GetAllEmployeeByCompanyAndDeptAndState(EntryUser ds,string thisCompanyCode,string thisDeptCode,string thisState)
		{
			var arParms = new SqlParameter[3];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
            arParms[1] = new SqlParameter("@DeptCode", SqlDbType.NVarChar,20 ) {Value = thisDeptCode};
            arParms[2] = new SqlParameter("@EmpState", SqlDbType.NVarChar,20 ) {Value = thisState};
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetAllEmployeeByCompanyAndDeptAndState",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
        /// <summary>
        /// 根据公司编号、部门编号和员工状态获取所有人员信息填充到EntryUser实体中.
        /// </summary>
        /// <param name="ds">EntryUser实体。</param>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="empState">员工状态。</param>
        public void FillAllEmployeeByCompanyAndDeptAndState(EntryUser ds, string companyCode, string deptCode, string empState)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo = '{0}' And EmpDept='{1}' And EmpState='{2}'",companyCode,deptCode,empState);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
		/// 根据公司编号和工号获取员工信息到EntryUser实体.
		/// </summary>
		/// <param name="ds">EntryUser实体</param>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisEmpCode">员工工号</param>
		[Obsolete("此方法已作废，请使用FillEmployeeByCompanyAndEmpCode(EntryUser ds,string companyCode,string empCode).",false)]
        public void GetEmployeeByCoAndEmpCode(EntryUser ds,string thisCompanyCode,string thisEmpCode)
		{
			string strSQL = "Select * from mySystemUserInfo WHERE EmpCo='" + thisCompanyCode + "' and EmpCode='" + thisEmpCode + "'";
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text,strSQL,ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE});
		}
        /// <summary>
        /// 根据公司编号和工号获取员工信息到EntryUser实体.
        /// </summary>
        /// <param name="ds">EntryUser实体</param>
        /// <param name="companyCode">公司编号</param>
        /// <param name="empCode">员工工号</param>
        public void FillEmployeeByCompanyAndEmpCode(EntryUser ds, string companyCode, string empCode)
        {
            var sqlStatement = string.Format("Select * FROM mySystemUserInfo WHERE EmpCo='{0}' And  EmpCode='{1}'", companyCode, empCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// 根据公司编号和员工工号获取人员信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="empCode">员工工号。</param>
        /// <returns>DataSet。</returns>
        public DataSet GetEmployeeByCompanyAndEmpCode(string companyCode, string empCode)
        {
            string sqlStatement = string.Format("Select * from mySystemUserInfo WHERE EmpCo='{0}' And  EmpCode='{1}'", companyCode, empCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 根据公司编号和登录名获取员工信息到EntryUser实体.
        /// </summary>
        /// <param name="ds">EntryUser实体。</param>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="loginName">登录名。</param>
        public void FillemployeeByCompanyAndLoginName(EntryUser ds, string companyCode, string loginName)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And LoginName='{1}'", companyCode, loginName);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// 根据公司编号和登录名获取人员信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>DataSet。</returns>
        public DataSet GetEmployeeByCompanyAndLoginName(string companyCode, string loginName)
        {
            string sqlStatement = string.Format("Select * from mySystemUserInfo WHERE EmpCo='{0}' And  LoginName='{1}'", companyCode, loginName);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
		/// 根据公司编号和部门编号得到所有的员工(包括下属部门)。
		/// </summary>
		/// <param name="companyCode">公司编号</param>
		/// <param name="deptCode">部门编号</param>
        /// <param name="withChildDept">是否包括子部门。</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllEmployeeByCompanyAndDept(string companyCode,string deptCode,bool withChildDept)
		{
            string sqlStatement;
            if (withChildDept)
                sqlStatement = string.Format(@"SELECT    A.* 
                                              FROM      mySystemUserinfo as A,fun_GetAllSubDeptsByParentDept('{1}','{0}') AS B 
                                              Where     A.EmpDept=B.DeptCode And 
                                                        A.EmpCo=B.DeptCo 
                                              UNION
                                              SELECT    A.* 
                                              FROM      mySystemUserinfo as A 
                                              WHERE     A.EmpCo='{0}' And 
                                                        A.EmpDept='{1}'", companyCode, deptCode);
            else
                sqlStatement = string.Format("Select * from mySystemUserInfo Where EmpCo = '{0}' And EmpDept='{1}'",companyCode,deptCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
        /// <summary>
        /// 根据公司编号获取所有用户列表。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllUserByCompany(string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo = '{0}' And IsUser = 'Y'",companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
        /// 根据公司编号和部门编号得到所有的用户(包括下属部门)。
		/// </summary>
		/// <param name="companyCode">公司编号</param>
		/// <param name="deptCode">部门编号</param>
        /// <param name="withChildDept">是否包括子部门。</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllUserByCompanyAndDept(string companyCode, string deptCode,bool withChildDept)
		{
            string sqlStatement;
            if (withChildDept)
                sqlStatement = string.Format(@"SELECT    A.* 
                                                  FROM      mySystemUserinfo as A,fun_GetAllSubDeptsByParentDept('{1}','{0}') AS B 
                                                  Where     A.EmpDept=B.DeptCode And 
                                                            A.EmpCo=B.DeptCo And
                                                            A.IsUser='Y'
                                                  UNION
                                                  SELECT    A.* 
                                                  FROM      mySystemUserinfo as A 
                                                  WHERE     A.EmpCo='{0}' And 
                                                            A.EmpDept='{1}' And
                                                            A.IsUser = 'Y'", companyCode, deptCode);
            else
                sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo = '{0}' And EmpDept = '{1}' And IsUser='Y'", companyCode, deptCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData,  CommandType.Text, sqlStatement);
		}
		/// <summary>
		/// 得到所有的用户根据部门编号
		/// </summary>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisDeptCode">部门编号</param>
        /// <param name="bstate">员工状态。</param>
        /// <param name="strUserName">用户名。</param>
		/// <returns>DataSet</returns>
		[Obsolete("此方法已作废。",true)]
        public DataSet GetAllUserByCompanyAndDept(string thisCompanyCode, string thisDeptCode,bool bstate,string strUserName)
		{
			bool biswhere = false;
			string commandText = "SELECT A.* FROM mysystemuserinfo as A,(Select * from fun_GetAllSubDeptsByParentDept('" + thisDeptCode + "','" + thisCompanyCode + "')) as B Where  A.EmpDept=B.DeptCode And A.EmpCo=B.DeptCo union select A.* FROM mysystemuserinfo as A where A.EmpCo='" + thisCompanyCode + "' and A.EmpDept='" + thisDeptCode + "'UNION\tSELECT A.* FROM mysystemuserinfo AS A Where LoginName = (Select DeptMgr From mysystemDept Where DeptCo = '" + thisCompanyCode + "' AND DeptCode = '" + thisDeptCode + "')";
			if (!bstate || strUserName.Length > 0)
			{
				commandText = "select * from (" + commandText + ") a where ";
				if (!bstate)
				{
					commandText += " a.[IsUser]='Y' and  a.[UserState]='A'";
					biswhere = true;
				}
				if (strUserName.Length > 0)
				{
                    if (biswhere)
                        commandText += string.Format(" AND a.[empcnname] like '%{0}%'", strUserName.Replace("'", "''"));
                    else
                        commandText += string.Format(" a.[empcnname] like '%{0}%'", strUserName.Replace("'", "''"));
				}
			}
			return SqlHelper.ExecuteDataset(ConnectionString.PubData,  CommandType.Text, commandText);
		}
		/// <summary>
		/// 根据PKID获取员工信息并且填充到EntryUser实体中.
		/// </summary>
		/// <param name="ds">EntryUser实体</param>
		/// <param name="pkid">PKID</param>
		[Obsolete("此方法已作废，请使用FillEmployeeByPKID(EntryUser ds, int pkid).",false)]
        public void GetEmployeeByPKID(EntryUser ds,int pkid)
		{
			var sqlStatement = string.Format("Select * from mySystemUserInfo WHERE PKID={0}", pkid) ;
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text,sqlStatement,ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE});
		}
        /// <summary>
        /// 根据PKID获取员工信息并且填充到EntryUser实体中.
        /// </summary>
        /// <param name="ds">EntryUser实体</param>
        /// <param name="pkid">PKID</param>
        public void FillEmployeeByPKID(EntryUser ds, int pkid)
        {
            string sqlStatement = string.Format("SELECT * FROM mySystemUserInfo WHERE PKID={0}", pkid);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// 根据PKID获取员工信息并且填充到EntryUser实体中.
        /// </summary>
        /// <param name="pkid">PKID</param>
        /// <returns>DataSet</returns>
        public DataSet GetEmployeeByPKID(int pkid)
        {
            string sqlStatement = string.Format("SELECT * FROM mySystemUserInfo WHERE PKID={0}", pkid);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
		/// 设置员工为用户
		/// </summary>
		/// <param name="pkid">主键</param>
		/// <param name="userCode">用户名</param>
		/// <param name="password">密码</param>
		/// <param name="salt">附加码</param>
		/// <param name="state">状态</param>
		/// <returns>bool</returns>
		public bool EnableEmployeeIsUser(int pkid,string userCode,string password,string salt,string state)
		{
			try
			{
				string sqlStatement = string.Format(@"UPDATE mySystemUserInfo 
                                                      SET   LoginName='{1}'
                                                    ,       Password1='{2}'
                                                    ,       AppandCode='{3}'
                                                    ,       IsUser='Y'
                                                    ,       UserState='{4}' 
                                                    WHERE   PKID={0}",pkid,userCode,password,salt,state);
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData,CommandType.Text,sqlStatement);
                return true;
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                this.Message = "启用用户失败！";
                return false;
			}
		}
		/// <summary>
		/// 启用用户
		/// </summary>
		/// <param name="pkid">PKID</param>
		/// <returns>bool</returns>
		public bool EnableEmployeeIsUser(int pkid)
		{
			try
			{
                string sqlStatement = string.Format("UPDATE mySystemUserInfo SET IsUser='Y' where PKID={0}", pkid);
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text,sqlStatement);
                return true;
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                this.Message = "启用用户失败！";
                return false;
			}
		}
		/// <summary>
		/// 禁用用户
		/// </summary>
		/// <param name="pkid">PKID</param>
		/// <returns>bool</returns>
		public bool DisableEmployeeIsUser(int pkid)
		{
			try
			{
                string sqlStatement = string.Format("UPDATE mySystemUserInfo SET IsUser='N' WHERE PKID={0}", pkid);
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement);
                return true;
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message);
                this.Message = "禁用用户失败！";
                return false;
			}
		}
        /// <summary>
        /// 获取所有的员工状态。
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetAllUserState()
        {
            string sqlStatement = "Select Code,Description,IsValid From mySystemEmpState";
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// 得到所有有效的员工状态
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetAllAvalibleUserState()
		{
			string sqlStatement = "SELECT Code,Description,IsValid FROM mySystemEmpState WHERE IsValid='Y'";
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
		/// <summary>
		/// 移动员工所在的部门
		/// </summary>
		/// <param name="pkids">用户PKID串</param>
		/// <param name="companyCode">公司编号</param>
		/// <param name="targetDeptCode">目标部门编号</param>
		/// <returns>bool</returns>
		public bool MoveEmployees(string pkids,string companyCode,string targetDeptCode)
		{
			bool ret = true;
			try
			{
				SqlParameter[] arParms = new SqlParameter[3];
				arParms[0] = new SqlParameter("@employeeCodes", SqlDbType.NVarChar,4000 ); 
				arParms[0].Value = pkids;
				arParms[1] = new SqlParameter("@employeeCompanyCode", SqlDbType.NVarChar,20 ); 
				arParms[1].Value = companyCode;
				arParms[2] = new SqlParameter("@targetDeptCode", SqlDbType.NVarChar,20 ); 
				arParms[2].Value = targetDeptCode;
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_MoveEmployees", arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                this.Message = "转移员工失败！";
                ret = false;
			}
			return ret;
		}

		#endregion

		#region 组织人员
		/// <summary>
		/// 更新组织用户列表
		/// </summary>
		/// <param name="corpCode">公司编号</param>
		/// <param name="orgCode">组织编号</param>
		/// <param name="userList">用户列表</param>
		/// <returns>bool</returns>
		public bool UpdateOrgUser(string corpCode,string orgCode,string userList)
		{
			bool ret = true;
			try
			{
				SqlParameter[] arParms = new SqlParameter[3];
			
				arParms[0] = new SqlParameter("@Corp", SqlDbType.NVarChar,20 ); 
				arParms[0].Value = corpCode;

				arParms[1] = new SqlParameter("@OrgID", SqlDbType.NVarChar,20 ); 
				arParms[1].Value = orgCode;

				arParms[2] = new SqlParameter("@UserList", SqlDbType.NVarChar,4000 ); 
				arParms[2].Value = userList;

				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_UpdateOrgUser", arParms);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message);
                this.Message = "Please look log file";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 得到组织用户
		/// </summary>
		/// <param name="corpCode">公司编号</param>
		/// <param name="orgCode">组织编号</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgUsers(string corpCode,string orgCode)
		{
			DataSet ds = null;
			try
			{
				SqlParameter[] arParms = new SqlParameter[2];
			
				arParms[0] = new SqlParameter("@CorpCode", SqlDbType.NVarChar,20 ); 
				arParms[0].Value = corpCode;

				arParms[1] = new SqlParameter("@OrgCode", SqlDbType.NVarChar,20 ); 
				arParms[1].Value = orgCode;

				ds = SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_GetOrgUsers", arParms);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message);
				this.Message = "Please look log file";
			}

			return ds;
		}
		#endregion

		#region 组织、职位、人员

		/// <summary>
		/// 更新组织、职位、人员关联
		/// </summary>
		/// <param name="orgCo">公司编号</param>
		/// <param name="orgCode">组织编号</param>
		/// <param name="dutyList">职位代码列表</param>
		/// <param name="userList">用户名列表</param>
		/// <returns>bool</returns>
		public bool UpdateOrgDutysUsers(string orgCo,string orgCode,string dutyList,string userList)
		{
			bool ret = true;
			try
			{
				SqlParameter[] arParms = new SqlParameter[4];
				arParms[0] = new SqlParameter("@DutyCodes", SqlDbType.NVarChar,1000 ); 
				arParms[0].Value = dutyList;
				arParms[1] = new SqlParameter("@DutyCo", SqlDbType.NVarChar,20 ); 
				arParms[1].Value = orgCo;
				arParms[2] = new SqlParameter("@UserIDs", SqlDbType.NVarChar,1000 ); 
				arParms[2].Value = userList;
				arParms[3] = new SqlParameter("@OrgCode", SqlDbType.NVarChar,20 ); 
				arParms[3].Value = orgCode;
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_UpdateDutyUsers", arParms);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message);
                this.Message = "Please look log file";
                ret = false;
			}
			return ret;
		}	
		/// <summary>
		/// 根据公司编号和组织编号用户职位信息.
		/// </summary>
		/// <param name="corpCode">公司编号</param>
		/// <param name="orgCode">组织代码</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgUsersDutys(string corpCode,string orgCode)
		{
			DataSet ds = null;
			try
			{
				SqlParameter[] arParms = new SqlParameter[2];
				arParms[0] = new SqlParameter("@CorpCode", SqlDbType.NVarChar,20 ); 
				arParms[0].Value = corpCode;
				arParms[1] = new SqlParameter("@OrgCode", SqlDbType.NVarChar,20 ); 
				arParms[1].Value = orgCode;
				ds = SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_GetOrgUsersAndLeaderShips",arParms);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message);
				this.Message = "Please look log file";
			}

			return ds;
		}
		#endregion
	}
}
