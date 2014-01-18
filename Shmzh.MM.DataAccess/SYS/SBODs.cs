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
	/// SBODs ��ժҪ˵����
	/// </summary>
	public class SBODs:Messages
	{
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region ˽�з���
        /// <summary>
        /// ���ݵ������ͱ�Ż�ȡ��������ʵ�塣
        /// </summary>
        /// <param name="docCode">�������ͱ�š�</param>
        /// <returns>��������ʵ�塣</returns>
        private SBODData GetByDocCode(int docCode)
        {
            var obj = new SBODData();
            var parms = new[] {new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = docCode}};
            SqlHelper.FillDataset(ConnectionString.MM,"Sys_DocGetDocByCode",obj,new[]{SBODData.SBOD_TABLE},parms);
            return obj;
        }
		#endregion

		#region ����
        /// <summary>
        /// ���ݵ������ͱ�Ż�ȡ���ơ�
        /// </summary>
        /// <param name="docCode">�������ͱ�š�</param>
        /// <returns>�����������ơ�</returns>
        public string GetDocNameByDocCode(int docCode)
        {
            var oDataRow = this.GetByDocCode(docCode).Tables[SBODData.SBOD_TABLE].Rows[0];
            return oDataRow[SBODData.DOCNAME_FIELD].ToString();            
        }
		/// <summary>
		/// ��ȡ���ݵ�����������
		/// </summary>
		/// <param name="docCode">int:	�������͡�</param>
		/// <returns>int:	����������</returns>
		public int GetAuditLevelByDocCode(int docCode)
		{
            var oDataRow = this.GetByDocCode(docCode).Tables[SBODData.SBOD_TABLE].Rows[0];

			return int.Parse(oDataRow[SBODData.AUDITLEVEL_FIELD].ToString());
		}


		/// <summary>
		/// �õ����еĵ�������
		/// </summary>
		/// <returns>SBODData:	��������ʵ�塣</returns>
		public SBODData GetAllBillOfDocs()
		{
			var sqlStatement="SELECT * FROM SBOD";

			var ds=new SBODData();
            SqlHelper.FillDataset(ConnectionString.MM,CommandType.Text,sqlStatement,ds,new[]{SBODData.SBOD_TABLE} );
            
			return ds;

		}		
		/// <summary>
		/// �����û�����ĳ�ֵ��ݵĿɲ��������б�
		/// </summary>
		/// <param name="userCode">string:	�û���</param>
		/// <param name="roleCode">��ɫId</param>
		/// <param name="docCode">int:	�������͡�</param>
		/// <param name="deptCodeList">string:	�ɲ��������б�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ�û�����ĳ�ֵ��ݵĿɲ������š�
		/// </summary>
		/// <param name="userCode">string:	�û���</param>
		/// <param name="docCode">int:	�������͡�</param>
		/// <returns>DataTable: ���ݱ�</returns>
		public DataTable GetAllDeptsByUserAndDoc(string userCode,short docCode)
		{
			var sqlStatement=string.Format("SELECT Distinct UserCode,DeptCode,DocCode from SUDD WHERE UserCode='{0}' AND DocCode={1}",userCode, docCode);
		    var ds = SqlHelper.ExecuteDataset(ConnectionString.MM, CommandType.Text, sqlStatement);
			if(ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
		    return null;
		}
        /// <summary>
        /// �����û���¼�����������͡���ɫ��ȡ���š�
        /// </summary>
        /// <param name="userCode">�û���¼��</param>
        /// <param name="docCode">��������</param>
        /// <param name="roleCode">��ɫId</param>
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
        /// �����û���¼���͵�����������ȡ�û���Ͻ�Ĳ��š�
        /// </summary>
        /// <param name="userLoginId">�û���¼��</param>
        /// <param name="docCode">��������</param>
        /// <returns>�������ݼ�</returns>
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
        /// �����û�����ȡ��Ȩ��Ͻ�����в��š�
        /// </summary>
        /// <param name="loginName">�û���¼��</param>
        /// <returns>������Ϣ��DataTable</returns>
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
		/// ��ȡ�û�����ĳ�ֵ��ݵĲ����б�
		/// </summary>
		/// <param name="userLoginId">�û���¼����</param>
		/// <param name="docCode">�������͡�</param>
		/// <returns>DeptData:	��������ʵ�塣</returns>
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
