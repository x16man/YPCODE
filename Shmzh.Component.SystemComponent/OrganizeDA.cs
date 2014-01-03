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
	/// �������֯���������ݷ�����.
	/// </summary>
	/// <remarks>�����˶��ڹ�˾��Ϣ��������Ϣ��ְλ��Ϣ��Ա�����û�����֯��Ա��ְλ�ȷ���</remarks>
	public class OrganizeDA : Messages
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        /// <summary>
		/// ���캯��
		/// </summary>
		public OrganizeDA()
		{
		}
		#region ��˾��Ϣ
		/// <summary>
		/// ��乫˾��Ϣ��ָ����EntryCompanyInfo������.
		/// </summary>
		/// <param name="ds">EntryCompanyInfo����</param>
		public void GetCompanyInfo(EntryCompanyInfo ds)
		{
			SqlHelper.FillDataset(ConnectionString.PubData,CommandType.StoredProcedure,"mysys_GetCompanyInfo",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE});
		}		
		/// <summary>
		/// ����Ĺ�˾��Ϣ��EntryCompanyInfoʵ����.
		/// </summary>
		/// <param name="ds">EntryCompanyInfo</param>
		public void GetActiveCompanies(EntryCompanyInfo ds)
		{
			SqlHelper.FillDataset(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_GetActiveCompanies",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE});
		}

		/// <summary>
		/// ������˾
		/// </summary>
		/// <param name="entrycompany">��˾��¼ʵ�塣</param>
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
				this.Message = "��ӹ�˾��Ϣʧ�ܣ�";
                Logger.Error(ex.Message);
                ret = false;
			}
			return ret;
		}

		/// <summary>
		/// ���¹�˾��Ϣ
		/// </summary>
		/// <param name="entrycompany">��˾��¼ʵ�塣</param>
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
				this.Message = "���¹�˾ʧ�ܣ�";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �жϹ�˾����Ƿ񾭴���.
		/// </summary>
		/// <param name="companyCode">��˾�ı��</param>
		/// <returns>bool���ͣ����ڷ���true�����򷵻�false��</returns>
		public bool IsExistCoCode(string companyCode)
		{
			string sqlStatement = "SELECT Count(*) FROM mySystemCompanyInfo WHERE CoCode='" + companyCode + "'";
			object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// �жϹ�˾����Ƿ񾭴��ڲ�����Ĭ��.
		/// </summary>
		/// <param name="companyCode">��˾�ı��</param>
		/// <returns>�Ƿ��Ѿ�����</returns>
		public bool IsExistDefaultCoCode(string companyCode)
		{
			string sqlStatement = string.Format("Select Count(*) from mySystemCompanyInfo where CoCode='{0}' AND [IsDefault]='Y'",companyCode);
			object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// ���ȱʡ�ļ���Ĺ�˾��EntryCompanyInfoʵ����.
		/// </summary>
		/// <param name="ds">EntryCompanyInfo</param>
		public void GetDefaultCompany(EntryCompanyInfo ds)
		{
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetDefaultCompany",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE});
		}
        /// <summary>
        /// ���ȱʡ�ļ���Ĺ�˾��Ϣ��
        /// </summary>
        /// <returns>DataSet���ͣ���˾����Ϣ��</returns>
        public DataSet GetDefaultCompany()
        {
             return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_GetDefaultCompany");
        }
		/// <summary>
		/// ����ָ���Ĺ�˾���,���ӹ�˾��Ϣ��䵽EntryCompanyInfoʵ����.
		/// </summary>
		/// <param name="ds">EntryCompanyInfoʵ��.</param>
		/// <param name="thisCompanyCode">�ϼ���˾���</param>
		public void GetSubCompany(EntryCompanyInfo ds,string thisCompanyCode)
		{
			SqlParameter[] arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@ParentCo", SqlDbType.NVarChar,20 ); 
			arParms[0].Value = thisCompanyCode;
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetSubCompany",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE},arParms);
		}
		/// <summary>
		/// ���ݹ�˾��Ż�ȡ��˾��Ϣ.
		/// </summary>
        /// <param name="ds">��˾��Ϣʵ�塣</param>
		/// <param name="companyCode">��˾���.</param>
		public void GetCompanyByCode(EntryCompanyInfo ds,string companyCode)
		{
			SqlParameter[] arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ); 
			arParms[0].Value = companyCode;
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetCompanyByCode",ds,new[] {EntryCompanyInfo.MYSYSTEMCOMPANYINFO_TABLE},arParms);
		}
		/// <summary>
		/// ���ݹ�˾��Ż�ȡ��˾��Ϣ.
		/// </summary>
		/// <param name="companyCode">��˾���.</param>
		/// <returns>DataSet</returns>
		public DataSet GetCompanyByCode(string companyCode)
		{
			SqlParameter[] arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ); 

			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetCompanyByCode",arParms);
		}
		/// <summary>
		/// ���ݹ�˾��ű�Ź�˾��Ϣ
		/// </summary>
        /// <param name="companyCode">��˾���</param>
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
				this.Message = "ɾ����˾ʱ����!";
                ret = false;
			}
			return ret;
		}
		#endregion
	
		#region ����
		/// <summary>
		/// ���ݹ�˾��Ż�ȡ������Ч�Ĳ�����䵽EntryDeptʵ����.
		/// </summary>
		/// <param name="ds">EntryDeptʵ��.</param>
		/// <param name="thisCompanyCode">��˾����</param>
        [Obsolete("�˷��������ϣ�������GetAllDeptsByCompany(EntryDept ds,string companyCode)",false)]
		public void GetDeptsByCompany(EntryDept ds,string thisCompanyCode)
		{
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetALLDeptsByCompany",ds,new[] {EntryDept.MYSYSTEMDEPT_TABLE},arParms);
		}
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ������Ч���ŵ��б�
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>DataSet���ͣ����ŵ����ݼ���</returns>
        public DataSet GetAllAvalibleDeptsByCompany(string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemDept WHERE DeptCo='{0}' AND IsValid='Y'",companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ������Ч�Ĳ����б�
        /// </summary>
        /// <param name="depts">����ʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        public void GetAllAvalibleDeptsByCompany(EntryDept depts, string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemDept WHERE DeptCo='{0}' AND IsValid='Y'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, depts, new[] { EntryDept.MYSYSTEMDEPT_TABLE });
        }
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ���в��ŵ��б�
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllDeptsByCompany(string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemDept WHERE DeptCo='{0}'", companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ���еĲ��š�
        /// </summary>
        /// <param name="depts">����ʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        public void GetAllDeptsByCompany(EntryDept depts, string companyCode)
        {
            var sqlStatement = string.Format("SELECT * FROM mySystemDept WHERE DeptCo='{0}'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, depts, new[] { EntryDept.MYSYSTEMDEPT_TABLE });
        }
		/// <summary>
		/// ���ݹ�˾��Ż�ȡ���в�����䵽EntryDeptʵ����.
		/// </summary>
		/// <param name="ds">EntryDeptʵ��.</param>
		/// <param name="thisCompanyCode">��˾����</param>
        /// <param name="strValid">"All"�򷵻����в��ţ�����ֻ������Ч�Ĳ���</param>
		public void GetDeptsByCompany(EntryDept ds,string thisCompanyCode,string strValid)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    arParms[1] = new SqlParameter("@Valid",SqlDbType.NVarChar,20) {Value = strValid};

		    SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetDeptsByCompany",ds,new[] {EntryDept.MYSYSTEMDEPT_TABLE},arParms);
		}

		/// <summary>
		/// ���ݹ�˾��źͲ��������û�����ȡ������Ϣ,����Ϣ��䵽EntryDeptʵ����.
		/// </summary>
		/// <param name="ds">EntryDeptʵ��.</param>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisDeptManager">�������ܵ��û���</param>
		public void GetDeptsByManager(EntryDept ds, string thisCompanyCode, string thisDeptManager)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    arParms[1] = new SqlParameter("@UserName", SqlDbType.NVarChar,20) {Value = thisDeptManager};

		    SqlHelper.FillDataset(ConnectionString.PubData,  CommandType.StoredProcedure,"mysys_GetDeptsByCompanyAndManager",ds, new[] {EntryDept.MYSYSTEMDEPT_TABLE },arParms); 
		}
		/// <summary>
		/// ���ݹ�˾��ź��ϼ����ű�Ż�ȡ�Ӽ�����,����Ϣ��䵽EntryDeptʵ����.
		/// </summary>
		/// <param name="ds">EntryDeptʵ��</param>
		/// <param name="thisCompanyCode">��˾����</param>
		/// <param name="thisDeptCode">���Ŵ���</param>
		public void GetSubDeptsByParent(EntryDept ds,string thisCompanyCode,string thisDeptCode)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
		    arParms[1] = new SqlParameter("@ParentDept", SqlDbType.NVarChar,20 ) {Value = thisDeptCode};
		    SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetSubDeptsByParent",ds,new[] {EntryDept.MYSYSTEMDEPT_TABLE},arParms);
		}	
		/// <summary>
		/// ���ݹ�˾��źͲ��ű�ź�ָ��Ҫ��������������в�����Ϣ�����.
		/// </summary>
		/// <param name="ds">EntryDept���͵�����ʵ��.</param>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisDeptCode">���ű��.</param>
		public void GetDeptByDeptCode(EntryDept ds,string thisCompanyCode,string thisDeptCode)
		{
			var strSQL = "Select * from mySystemDept Where DeptCode='" + thisDeptCode + "' and DeptCo='" + thisCompanyCode + "'";
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text,strSQL,ds,new[] {EntryDept.MYSYSTEMDEPT_TABLE});
		}

		/// <summary>
		/// ������֯���ͺ� �Ƿ���ʹ����֯���͵�
		/// </summary>
		/// <param name="strTypeID">EntryDept���͵�����ʵ��.</param>
		/// <returns>True Ϊ��ʹ�� falseΪ��ʹ��</returns>
		public bool IsHaveTypeUsing(string strTypeID)
		{
			var strSQL = "Select * from mySystemDept Where TypeID='" + strTypeID + "'";
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,strSQL).Tables[0].Rows.Count > 0;
		}

		/// <summary>
		/// ���Ӳ���
		/// </summary>
		/// <param name="thisEntryDept">EntryDeptʵ�� </param>
		/// <returns>�Ƿ����ӳɹ�</returns>
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
				this.Message = "��Ӳ�����Ϣʧ�ܣ�";
                ret = false;
			}
			return ret;
		}

		/// <summary>
		/// ���²��š�
		/// </summary>
		/// <param name="thisEntryDept">EntryDeptʵ��</param>
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
				this.Message = "��֯���������֯�����Ѿ�����,����������";
                ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �ƶ�����
		/// </summary>
		/// <param name="deptCode">���ű��</param>
		/// <param name="deptCo">��˾���</param>
		/// <param name="targetParentDeptCode">Ŀ�길����</param>
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
				this.Message = "�ƶ�����ʧ�ܣ�";
                ret = false;
			}
			return ret;
		}
		
		/// <summary>
		/// ���ݹ�˾��źͲ��ű��ɾ������.
		/// </summary>
		/// <param name="thisDeptCode">���ű��</param>
		/// <param name="deptCo">��˾���</param>
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
				this.Message = "ɾ������ʱ����!";
                ret = false;
			}
			return ret;
		}
        /// <summary>
        /// ���ϲ��š�
        /// </summary>
        /// <param name="deptCode">���ű�š�</param>
        /// <param name="deptCo">������˾��</param>
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
                this.Message = "ʧЧ����ʱ����!";
                ret = false;
            }
            return ret;
        }
		/// <summary>
		/// �жϲ��ű���Ƿ��Ѿ�����.
		/// </summary>
		/// <param name="deptCode">���Ŵ���</param>
		/// <param name="deptCo">��˾���</param>
		/// <returns>�Ƿ��Ѿ�����</returns>
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
		/// �жϲ��������Ƿ��Ѿ�����.
		/// </summary>
		/// <param name="deptCo">��˾���</param>
		/// <param name="thisDeptName">��������</param>
		/// <returns>bool</returns>
		public bool IsExistDeptName(string deptCo,string thisDeptName)
		{
            var sqlStatement = string.Format("Select Count(*) from mySystemDept where DeptCo='{0}' and DeptCnName='{1}'", deptCo, thisDeptName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }

        #region OrgType
		/// <summary>
		/// ��ȡ��֯����
		/// </summary>
		/// <param name="isValid">�Ƿ���Ч</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgType(string isValid)
		{
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@IsValid", SqlDbType.NVarChar,10) {Value = isValid.ToUpper()};
		    return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetOrgType", arParms);
		}
        /// <summary>
        /// �ж���֯�������͵ı�Ż������Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="orgTypeCodeOrName">��֯�������͵ı�Ż��������ơ�</param>
        /// <returns>bool���ͣ����ڷ���True�����򷵻�False��</returns>
        public bool IsExist(string orgTypeCodeOrName)
        {
            var sqlStatement = string.Format("Select Count(*) From mySystemOrgType Where Code ='{0}' OR CnName='{0}'", orgTypeCodeOrName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
        /// <summary>
        /// ������֯����
        /// </summary>
        /// <param name="code">����</param>
        /// <param name="level">����</param>
        /// <param name="cnname">��������</param>
        /// <param name="enname">Ӣ������</param>
        /// <param name="isvalid">�Ƿ���Ч</param>
        /// <returns>�Ƿ����ӳɹ�</returns> 
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
                Logger.Error(string.Format("������֯����ʱ�����쳣��{0}", ex.Message));
                this.Message = "�����֯����ʱ�����쳣�����ʧ�ܣ�";
                ret = false;
            }
            return ret;
        }
        /// <summary>
        /// ������֯�������͡�
        /// </summary>
        /// <param name="code">����</param>
        /// <param name="level">����</param>
        /// <param name="cnname">��������</param>
        /// <param name="enname">Ӣ������</param>
        /// <param name="isvalid">�Ƿ���Ч</param>
        /// <returns>�Ƿ����ӳɹ�</returns> 
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
                Logger.Error(string.Format("������֯�������͵�ʱ�����쳣��{0}", ex.Message));
                this.Message = "������֯�������͵�ʱ�����쳣������û�гɹ���";
                ret = false;
            }
            return ret;
        }
        /// <summary>
        /// ɾ����֯����
        /// </summary>
        /// <param name="code">����</param>
        /// <returns>�Ƿ����ӳɹ�</returns> 
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
                Logger.Error(string.Format("ɾ����֯��������ʱ�����쳣��{0}", ex.Message));
                this.Message = "ɾ����֯��������ʱ�����쳣��ɾ��ʧ�ܣ�";
                ret = false;
            }
            return ret;
        }
        #endregion
        #endregion

        #region ְλ
        /// <summary>
		/// ������˾��ְλ��䵽EntryDutyʵ��.
		/// </summary>
		/// <param name="ds">EntryDutyʵ��</param>
		/// <param name="thisCompanyCode">��˾���</param>
		public void FillDutiesByCompany(EntryDuty ds,string thisCompanyCode)
		{
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_GetDutiesByCompany", ds, new[] {EntryDuty.MYSYSTEMDUTY_TABLE}, arParms);
		}
        /// <summary>
        /// ���ݹ�˾��Ż�ȡְ����Ϣ��
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllDutiesByCompany(string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemDuty Where DutyCo = '{0}'",companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ���е���Ч��ְλ��Ϣ��
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllAvalibleDutiesByCompany(string companyCode)
        {
            var sqlStatement = string.Format("Select * From mySystemDuty Where DutyCo = '{0}' And IsValid = 'Y'", companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// ����ְλ.
		/// </summary>
		/// <param name="thisEntryDuty">EntryDutyʵ��.</param>
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
				this.Message = "ְλ���ʧ�ܣ�";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����duty
		/// </summary>
		/// <param name="thisEntryDuty">EntryDutyʵ��.</param>
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
                this.Message = "ְλ����ʧ�ܣ�";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ƶ�ְλ.
		/// </summary>
		/// <param name="dutyCode">ְλ���</param>
		/// <param name="dutyCo">��˾���</param>
		/// <param name="targetParentDutyCode">�ϼ�ְλ���</param>
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
		/// ���ݹ�˾��ź�ְλ��Ż�ȡԱ����Ϣ.
		/// </summary>
		/// <param name="dutyCode">ְλ���</param>
		/// <param name="dutyCo">��˾���</param>
		/// <param name="empCnNames">Ա��������</param>
		/// <returns>Ա���û�����.</returns>
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
		/// ���ݹ�˾��ź�ְλ��Ż�ȡְλ��Ϣ,��䵽EntryDutyʵ��.
		/// </summary>
		/// <param name="ds">EntryDutyʵ��</param>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisDutyCode">ְλ���</param>
		public void GetDutyByDutyCode(EntryDuty ds,string thisCompanyCode,string thisDutyCode)
		{
            var sqlStatement = string.Format("SELECT * FROM mySystemDuty WHERE DutyCode='{0}' AND DutyCo='{1}'", thisDutyCode, thisCompanyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryDuty.MYSYSTEMDUTY_TABLE });
		}
		/// <summary>
		/// �ж�ְλ�����Ƿ��Ѿ�����
		/// </summary>
		/// <param name="dutyCode">ְλ���</param>
		/// <param name="dutyCo">��˾���</param>
		/// <returns>bool</returns>
		public bool IsExistDutyCode(string dutyCode,string dutyCo)
		{
            string sqlStatement = string.Format("SELECT Count(*) FROM mySystemDuty WHERE DutyCode='{0}' AND DutyCo='{1}'", dutyCode, dutyCo);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// ���ݹ�˾��ź�ְλ���ɾ��ְλ.
		/// </summary>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisDutyCode">ְλ���</param>
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
		/// �ж�ְλ�����Ƿ��Ѿ�ʹ��
		/// </summary>
		/// <param name="dutyCode">ְλ���</param>
		/// <returns>bool</returns>
		public bool IsUsingDutyCode(string dutyCode)
		{
            var sqlStatement = string.Format("Select Count(*) from mySystemUserInfo where DutyCode='{0}' and EmpCo='[1}'", dutyCode);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// �ж������Ƿ��ظ�
		/// </summary>
		/// <param name="dutyName">ְλ����</param>
		/// <param name="dutyCo">��˾���</param>
		/// <returns>bool</returns>
		public bool IsExistDutyName(string dutyName,string dutyCo)
		{
            string sqlStatement = string.Format("SELECT Count(*) FROM mySystemDuty where DutyCnName='{0}' AND DutyCo='{1}'", dutyName, dutyCo);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
        /// <summary>
        /// ְλ�����Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="dutyCode">ְλ��š�</param>
        /// <param name="dutyName">ְλ���ơ�</param>
        /// <param name="dutyCo">������˾</param>
        /// <returns>bool</returns>
        public bool IsExistDutyName(string dutyCode,string dutyName, string dutyCo)
        {
            string sqlStatement = string.Format("SELECT Count(*) FROM mySystemDuty where DutyCnName='{0}' AND DutyCo='{1}' AND DutyCode<>'{2}'", dutyName, dutyCo,dutyCode);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
		#endregion

		#region Ա�����û�
		/// <summary>
		/// �����û�
		/// </summary>
		/// <param name="thisEntryUser">�û�����</param>
		/// <returns>�ɹ�</returns>
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
		/// �����û�
		/// </summary>
		/// <param name="thisEntryUser">EntryUserʵ��</param>
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
                this.Message = "�����û���Ϣʧ�ܣ�";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����pkidɾ���û�.
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
                this.Message = "ɾ���û�ʧ�ܣ�";
                ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �жϹ�Ա����Ƿ��Ѿ�����
		/// </summary>
		/// <param name="empCode">��Ա����</param>
		/// <returns>�Ƿ��Ѿ�����</returns>
		public bool IsExistEmpCode(string empCode)
		{
            string sqlStatement = string.Format("Select Count(*) FROM mySystemUserInfo WHERE EmpCode='{0}'", empCode);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
        /// <summary>
        /// �жϳ�ȥָ��PKID��¼�⣬�Ƿ����ظ��Ĺ��š�
        /// </summary>
        /// <param name="empCode">���š�</param>
        /// <param name="pkid">�����PKID��</param>
        /// <returns>bool</returns>
        public bool IsExistEmpCode(string empCode, int pkid)
        {
            string sqlStatement = string.Format("Select Count(*) FROM mySystemUserInfo WHERE EmpCode='{0}' And PKID <> {1}", empCode,pkid);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
		/// <summary>
		/// �õ��������еĹ�Ա
		/// </summary>
		/// <param name="ds">�û�ʵ�塣</param>
		[Obsolete("�˷��������ϣ���ʹ��FillAllEmployee(EntryUser ds).",false)]
        public void GetAllEmployee(EntryUser ds)
		{
            /*Select * From mySystemUserInfo*/
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetAllEmployee",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE});
		}
        /// <summary>
        /// ���������Ա��Ϣ��EntryUserʵ���С�
        /// </summary>
        /// <param name="ds">EntryUserʵ�塣</param>
        public void FillAllEmployee(EntryUser ds)
        {
            string sqlStatement = "Select * From mySystemUserInfo";
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// ��ȡ���е���Ա��Ϣ��
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetAllEmployee()
        {
            string sqlStatement = "Select * From mySystemUserInfo";
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// �õ�����״̬�Ĺ�Ա,��䵽EntryUserʵ����.
		/// </summary>
		/// <param name="ds">EntryUserʵ��</param>
		/// <param name="thisState">״̬</param>
		[Obsolete("�˷��������ϣ���ʹ��FillAllEmployeeByState(string companyCode).",false)]
        public void GetAllEmployeeByState(EntryUser ds,string thisState)
		{
            /*SELECT * FROM mySystemUserInfo WHERE EmpState=@EmpState*/
			var arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@EmpState", SqlDbType.NChar,1 ) {Value = thisState};
		    SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetAllEmployeeByState",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
        /// <summary>
        /// ����Ա��״̬��ȡ��Ա�б���䵽EntryUserʵ�塣
        /// </summary>
        /// <param name="ds">EntryUserʵ�塣</param>
        /// <param name="empState">Ա��״̬��</param>
        public void FillAllEmployeeByState(EntryUser ds, string empState)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpState='{0}'",empState);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// ����Ա��״̬��ȡ��Ա�б�
        /// </summary>
        /// <param name="empState">Ա��״̬��</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllEmployeeByState(string empState)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpState='{0}'", empState);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// ���ݹ�˾��Ż�ȡ������Ա�б�
		/// </summary>
		/// <param name="ds">EntryUserʵ��</param>
		/// <param name="companyCode">��˾���</param>
		[Obsolete("�˷��������ϣ���ʹ��FillAllEmployeeByCompany(string companyCode).",false)]
        public void GetAllEmployeeByCompany(EntryUser ds,string companyCode)
		{
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}'",companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
		}
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ������Ա�б�
        /// </summary>
        /// <param name="ds">EntryUserʵ��</param>
        /// <param name="companyCode">��˾���</param>
        public void FillAllEmployeeByCompany(EntryUser ds, string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ������Ա�б�
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAllEmployeeByCompany(string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}'", companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ������ְ��Ա���б�,��䵽EntryUserʵ�塣
        /// </summary>
        /// <param name="ds">EntryUserʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        [Obsolete("�˷������ϣ���ʹ��FillAllAvalibleEmployeeByCompany(EntryUser ds,string companyCode).",false)]
        public void GetAllAvalibleEmployeeByCompany(EntryUser ds, string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And IsLeave='N'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ������ְ��Ա���б�,��䵽EntryUserʵ�塣
        /// </summary>
        /// <param name="ds">EntryUserʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        public void FillAllAvalibleEmployeeByCompany(EntryUser ds, string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And IsLeave='N'", companyCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
		/// �õ�����״̬������ĳ����˾�Ĺ�Ա
		/// </summary>
		/// <param name="ds">EntryUserʵ��</param>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisState">״̬</param>
		public void GetAllEmployeeByCompanyAndState(EntryUser ds,string thisCompanyCode,string thisState)
		{
			var arParms = new SqlParameter[2];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
            arParms[1] = new SqlParameter("@EmpState", SqlDbType.NChar,1 ) {Value = thisState};
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetAllEmployeeByCompanyAndState",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
        /// <summary>
        /// ���ݹ�˾��ź�Ա��״̬��ȡ��Ա�б���䵽EntryUserʵ�塣
        /// </summary>
        /// <param name="ds">EntryUserʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        /// <param name="empState">Ա��״̬��</param>
        public void FillAllEmployeeByCompanyAndState(EntryUser ds, string companyCode, string empState)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And EmpState='{1}'",companyCode,empState);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// ���ݹ�˾��ź�Ա��װ�᰸��ȡ���е���Ա�б�
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <param name="empState">Ա��״̬��</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllEmployeeByCompanyAndState(string companyCode, string empState)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And EmpState='{1}'", companyCode, empState);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
		/// ���ݹ�˾��š����ű�ź�Ա��״̬��ȡ������Ա��Ϣ��䵽EntryUserʵ����.
		/// </summary>
		/// <param name="ds">EntryUserʵ��.</param>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisDeptCode">���ű��</param>
		/// <param name="thisState">Ա��״̬</param>
		[Obsolete("�˷��������ϣ���ʹ��FillAllEmployeeByCompanyAndDeptAndState��EntryUser ds,string companyCode,string deptCode,string empState).",false)]
        public void GetAllEmployeeByCompanyAndDeptAndState(EntryUser ds,string thisCompanyCode,string thisDeptCode,string thisState)
		{
			var arParms = new SqlParameter[3];
			arParms[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar,20 ) {Value = thisCompanyCode};
            arParms[1] = new SqlParameter("@DeptCode", SqlDbType.NVarChar,20 ) {Value = thisDeptCode};
            arParms[2] = new SqlParameter("@EmpState", SqlDbType.NVarChar,20 ) {Value = thisState};
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetAllEmployeeByCompanyAndDeptAndState",ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE},arParms);
		}
        /// <summary>
        /// ���ݹ�˾��š����ű�ź�Ա��״̬��ȡ������Ա��Ϣ��䵽EntryUserʵ����.
        /// </summary>
        /// <param name="ds">EntryUserʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        /// <param name="deptCode">���ű�š�</param>
        /// <param name="empState">Ա��״̬��</param>
        public void FillAllEmployeeByCompanyAndDeptAndState(EntryUser ds, string companyCode, string deptCode, string empState)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo = '{0}' And EmpDept='{1}' And EmpState='{2}'",companyCode,deptCode,empState);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
		/// ���ݹ�˾��ź͹��Ż�ȡԱ����Ϣ��EntryUserʵ��.
		/// </summary>
		/// <param name="ds">EntryUserʵ��</param>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisEmpCode">Ա������</param>
		[Obsolete("�˷��������ϣ���ʹ��FillEmployeeByCompanyAndEmpCode(EntryUser ds,string companyCode,string empCode).",false)]
        public void GetEmployeeByCoAndEmpCode(EntryUser ds,string thisCompanyCode,string thisEmpCode)
		{
			string strSQL = "Select * from mySystemUserInfo WHERE EmpCo='" + thisCompanyCode + "' and EmpCode='" + thisEmpCode + "'";
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text,strSQL,ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE});
		}
        /// <summary>
        /// ���ݹ�˾��ź͹��Ż�ȡԱ����Ϣ��EntryUserʵ��.
        /// </summary>
        /// <param name="ds">EntryUserʵ��</param>
        /// <param name="companyCode">��˾���</param>
        /// <param name="empCode">Ա������</param>
        public void FillEmployeeByCompanyAndEmpCode(EntryUser ds, string companyCode, string empCode)
        {
            var sqlStatement = string.Format("Select * FROM mySystemUserInfo WHERE EmpCo='{0}' And  EmpCode='{1}'", companyCode, empCode);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// ���ݹ�˾��ź�Ա�����Ż�ȡ��Ա��Ϣ��
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <param name="empCode">Ա�����š�</param>
        /// <returns>DataSet��</returns>
        public DataSet GetEmployeeByCompanyAndEmpCode(string companyCode, string empCode)
        {
            string sqlStatement = string.Format("Select * from mySystemUserInfo WHERE EmpCo='{0}' And  EmpCode='{1}'", companyCode, empCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// ���ݹ�˾��ź͵�¼����ȡԱ����Ϣ��EntryUserʵ��.
        /// </summary>
        /// <param name="ds">EntryUserʵ�塣</param>
        /// <param name="companyCode">��˾��š�</param>
        /// <param name="loginName">��¼����</param>
        public void FillemployeeByCompanyAndLoginName(EntryUser ds, string companyCode, string loginName)
        {
            var sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo='{0}' And LoginName='{1}'", companyCode, loginName);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// ���ݹ�˾��ź͵�¼����ȡ��Ա��Ϣ��
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <param name="loginName">��¼����</param>
        /// <returns>DataSet��</returns>
        public DataSet GetEmployeeByCompanyAndLoginName(string companyCode, string loginName)
        {
            string sqlStatement = string.Format("Select * from mySystemUserInfo WHERE EmpCo='{0}' And  LoginName='{1}'", companyCode, loginName);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
		/// ���ݹ�˾��źͲ��ű�ŵõ����е�Ա��(������������)��
		/// </summary>
		/// <param name="companyCode">��˾���</param>
		/// <param name="deptCode">���ű��</param>
        /// <param name="withChildDept">�Ƿ�����Ӳ��š�</param>
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
        /// ���ݹ�˾��Ż�ȡ�����û��б�
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllUserByCompany(string companyCode)
        {
            string sqlStatement = string.Format("Select * From mySystemUserInfo Where EmpCo = '{0}' And IsUser = 'Y'",companyCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
        /// ���ݹ�˾��źͲ��ű�ŵõ����е��û�(������������)��
		/// </summary>
		/// <param name="companyCode">��˾���</param>
		/// <param name="deptCode">���ű��</param>
        /// <param name="withChildDept">�Ƿ�����Ӳ��š�</param>
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
		/// �õ����е��û����ݲ��ű��
		/// </summary>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisDeptCode">���ű��</param>
        /// <param name="bstate">Ա��״̬��</param>
        /// <param name="strUserName">�û�����</param>
		/// <returns>DataSet</returns>
		[Obsolete("�˷��������ϡ�",true)]
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
		/// ����PKID��ȡԱ����Ϣ������䵽EntryUserʵ����.
		/// </summary>
		/// <param name="ds">EntryUserʵ��</param>
		/// <param name="pkid">PKID</param>
		[Obsolete("�˷��������ϣ���ʹ��FillEmployeeByPKID(EntryUser ds, int pkid).",false)]
        public void GetEmployeeByPKID(EntryUser ds,int pkid)
		{
			var sqlStatement = string.Format("Select * from mySystemUserInfo WHERE PKID={0}", pkid) ;
			SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text,sqlStatement,ds,new[] {EntryUser.MYSYSTEMUSERINFO_TABLE});
		}
        /// <summary>
        /// ����PKID��ȡԱ����Ϣ������䵽EntryUserʵ����.
        /// </summary>
        /// <param name="ds">EntryUserʵ��</param>
        /// <param name="pkid">PKID</param>
        public void FillEmployeeByPKID(EntryUser ds, int pkid)
        {
            string sqlStatement = string.Format("SELECT * FROM mySystemUserInfo WHERE PKID={0}", pkid);
            SqlHelper.FillDataset(ConnectionString.PubData, CommandType.Text, sqlStatement, ds, new[] { EntryUser.MYSYSTEMUSERINFO_TABLE });
        }
        /// <summary>
        /// ����PKID��ȡԱ����Ϣ������䵽EntryUserʵ����.
        /// </summary>
        /// <param name="pkid">PKID</param>
        /// <returns>DataSet</returns>
        public DataSet GetEmployeeByPKID(int pkid)
        {
            string sqlStatement = string.Format("SELECT * FROM mySystemUserInfo WHERE PKID={0}", pkid);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
		/// ����Ա��Ϊ�û�
		/// </summary>
		/// <param name="pkid">����</param>
		/// <param name="userCode">�û���</param>
		/// <param name="password">����</param>
		/// <param name="salt">������</param>
		/// <param name="state">״̬</param>
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
                this.Message = "�����û�ʧ�ܣ�";
                return false;
			}
		}
		/// <summary>
		/// �����û�
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
                this.Message = "�����û�ʧ�ܣ�";
                return false;
			}
		}
		/// <summary>
		/// �����û�
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
                this.Message = "�����û�ʧ�ܣ�";
                return false;
			}
		}
        /// <summary>
        /// ��ȡ���е�Ա��״̬��
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetAllUserState()
        {
            string sqlStatement = "Select Code,Description,IsValid From mySystemEmpState";
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// �õ�������Ч��Ա��״̬
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetAllAvalibleUserState()
		{
			string sqlStatement = "SELECT Code,Description,IsValid FROM mySystemEmpState WHERE IsValid='Y'";
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
		/// <summary>
		/// �ƶ�Ա�����ڵĲ���
		/// </summary>
		/// <param name="pkids">�û�PKID��</param>
		/// <param name="companyCode">��˾���</param>
		/// <param name="targetDeptCode">Ŀ�겿�ű��</param>
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
                this.Message = "ת��Ա��ʧ�ܣ�";
                ret = false;
			}
			return ret;
		}

		#endregion

		#region ��֯��Ա
		/// <summary>
		/// ������֯�û��б�
		/// </summary>
		/// <param name="corpCode">��˾���</param>
		/// <param name="orgCode">��֯���</param>
		/// <param name="userList">�û��б�</param>
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
		/// �õ���֯�û�
		/// </summary>
		/// <param name="corpCode">��˾���</param>
		/// <param name="orgCode">��֯���</param>
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

		#region ��֯��ְλ����Ա

		/// <summary>
		/// ������֯��ְλ����Ա����
		/// </summary>
		/// <param name="orgCo">��˾���</param>
		/// <param name="orgCode">��֯���</param>
		/// <param name="dutyList">ְλ�����б�</param>
		/// <param name="userList">�û����б�</param>
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
		/// ���ݹ�˾��ź���֯����û�ְλ��Ϣ.
		/// </summary>
		/// <param name="corpCode">��˾���</param>
		/// <param name="orgCode">��֯����</param>
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
