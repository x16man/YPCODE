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

namespace Shmzh.MM.DataAccess
{
	using System;
    using System.Configuration;
	using System.Data;
    using System.Data.SqlClient;
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;

	#region public class RequestOfStocks
	/// <summary>
	/// �����͵��ݵĹ������ݷ��ʲ㡣
	/// </summary>
	public class RequestOfStocks:Messages,IInItems
    {
private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Property
        /// <summary>
        /// ���ݿ������ַ�����
        /// </summary>
        public string ConnString { get { return ConfigurationManager.AppSettings["ConnectionString"]; } }
        #endregion

        #region ���캯��
        public RequestOfStocks()
		{}
		#endregion ���캯��

		#region ˽�з���
		/// <summary>
		/// ����ϣ��
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(RequestOfStockData oEntry)
		{
			var oHT = new Hashtable();

		    var oRow = oEntry.Tables[RequestOfStockData.PROS_TABLE].Rows[0];
			//����ģʽ�����ֶΡ�
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//������ˮ�š�
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//���ݱ�š�
            oHT.Add("@DocCode",         oRow[InItemData.DOCCODE_FIELD]);					//�������͡�
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//�����������ơ�
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//���������ĵ���š�
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//����״̬��
			oHT.Add("@EntryDate",		oRow[InItemData.ENTRYDATE_FIELD]);					//�Ƶ����ڡ�
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//�Ƶ��˱�š�
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//�Ƶ������ơ�
			oHT.Add("@AuthorLoginID",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//�Ƶ��˵�¼����
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//�Ƶ��˲��š�
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//�Ƶ��˲������ơ�
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);					//�����ܽ�
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);						//��ע��
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//������ϸ����˳��š�
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//���ϱ�š�
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//�������ơ�
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//���Ϲ��
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//���ϵ��ۡ�
			oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);					//����������
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//���ϵ�λ������
			//�������������ֶΡ�
			oHT.Add("@ReqDept",			oRow[RequestOfStockData.REQDEPT_FIELD]);			//���벿�š�
			oHT.Add("@ReqDeptName",		oRow[RequestOfStockData.REQDEPTNAME_FIELD]);		//���벿�����ơ�
			oHT.Add("@Proposer",		oRow[RequestOfStockData.PROPOSER_FIELD]);			//�����ˡ�
			oHT.Add("@ProposerCode",	oRow[RequestOfStockData.PROPOSERCODE_FIELD]);		//�����˱�š�
			oHT.Add("@ReqReasonCode",	oRow[RequestOfStockData.REQREASONCODE_FIELD]);		//�������ɱ�š�
			oHT.Add("@ReqReason",		oRow[RequestOfStockData.REQREASON_FIELD]);			//�������ɡ�
			oHT.Add("@ReqDateList",		oRow[RequestOfStockData.REQDATE_FIELD]);			//Ҫ�󵽻����ڡ�
			return oHT;
		}
		#endregion ˽�з���

		#region IInItems ��Ա
		/// <summary>
		/// �������ӡ�
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
		    var oEntry = (RequestOfStockData)Entry;
			var oSQLServer = new SQLServer();
			var oHT = this.FillHashTable(oEntry);
			
			var ret = oSQLServer.ExecSP("Pur_RequestOfStockInsert",oHT);
			
			if(!ret)
			{
				this.Message="Error,Pur_RequestOfStockInsert,Please look the log file!";
			}
			return ret;
		}

		/// <summary>
		/// �½��������ύ���ݡ�
		/// </summary>
		/// <param name="Entry">object:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
		    var oEntry = (RequestOfStockData)Entry;
			var oSQLServer = new SQLServer();
			var oHT = this.FillHashTable(oEntry);
			
			var ret = oSQLServer.ExecSP("Pur_RequestOfStockInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_RequestOfStockInsertAndPresent,Please look the log file!";
			}
			return ret;
		}
		/// <summary>
		/// �����޸ġ�
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{
		    var oEntry = (RequestOfStockData)Entry;
			var oSQLServer = new SQLServer();
			var oHT = this.FillHashTable(oEntry);
			
			var ret = oSQLServer.ExecSP("Pur_RequestOfStockUpdate",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_RequestOfStockUpdate,Please look the log file!";
			}
			return ret;
		}
		/// <summary>
		/// �޸Ĳ������ύ�ɹ����뵥��
		/// </summary>
		/// <param name="Entry">object:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
		    var oEntry = (RequestOfStockData)Entry;
			var oSQLServer = new SQLServer();
			var oHT = this.FillHashTable(oEntry);
			
			var ret = oSQLServer.ExecSP("Pur_RequestOfStockUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_RequestOfStockUpdateAndPresent,Please look the log file!";
			}
			return ret;
		}
		/// <summary>
		/// ����ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteEntry(int EntryNo)
		{
			var ret = true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}};
		    if((new SQLServer()).ExecSP("Pur_RequestOfStockDelete",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockDelete,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ����״̬���ġ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <param name="EntryState">string:	������״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			var ret = true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}, {"@EntryState", EntryState}};
		    if((new SQLServer()).ExecSP("Pur_RequestOfStockUpdateState",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockUpdateState,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			var ret = true;
			var oHT=new Hashtable();
			var oEntry= (RequestOfStockData)Entry;
		    var oRow = oEntry.Tables[RequestOfStockData.PROS_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

            Logger.Info("exec Pur_RequestOfStockFirstAudit");
			if((new SQLServer()).ExecSP("Pur_RequestOfStockFirstAudit",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockFirstAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			var ret = true;
			var oHT=new Hashtable();
			var oEntry= (RequestOfStockData)Entry;
		    var oRow = oEntry.Tables[RequestOfStockData.PROS_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Pur_RequestOfStockSecondAudit",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockSecondAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			var ret=true;
			var oHT=new Hashtable();
			var oEntry= (RequestOfStockData)Entry;
		    var oRow = oEntry.Tables[RequestOfStockData.PROS_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Pur_RequestOfStockThirdAudit",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockThirdAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
        /// <summary>
        /// ������ˡ�
        /// </summary>
        /// <param name="entryNo">�����깺���š�</param>
        /// <param name="entryState">״̬</param>
        /// <param name="audit4">��˽��</param>
        /// <param name="assessor4">�����</param>
        /// <param name="auditSuggest4">������</param>
        /// <param name="itemCodes">���ϱ�Ŵ���</param>
        /// <param name="loginId">�����˵�¼��</param>
        /// <returns>bool</returns>
        public bool WZAudit(int entryNo, string entryState, string audit4,string assessor4,string auditSuggest4,string itemCodes,string loginId)
        {
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo},
                                new SqlParameter("@EntryState",SqlDbType.Char,1){Value = entryState},
                                new SqlParameter("@Audit4",SqlDbType.Char,1){Value = audit4},
                                new SqlParameter("@Assessor4",SqlDbType.NVarChar,20){Value = assessor4},
                                new SqlParameter("@AuditSuggest4",SqlDbType.NVarChar,50){Value = auditSuggest4},
                                new SqlParameter("@ItemCodes",SqlDbType.NVarChar,4000){Value = itemCodes},
                                new SqlParameter("@UserLoginId",SqlDbType.NVarChar,20){Value = loginId},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnString, "Pur_RequestOfStockWZAudit", parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                this.Message = ex.Message;
                return false;
            }
        }
		/// <summary>
		/// ����������������
		/// </summary>
		/// <param name="TaskIDs">string:	����ID����</param>
		/// <param name="Assessor">string;	�����ˡ�</param>
		/// <param name="UserLoginId">string:	��½����</param>
		/// <param name="EntryState">string:	����״̬��(T/Z)</param>
		/// <param name="Flag">string:	���������(Y/N)</param>
		/// <returns>�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool BatchThirdAudit(string TaskIDs,string Assessor,string UserLoginId,string EntryState,string Flag)
		{
		    var oHT=new Hashtable {{"@Task_IDs", TaskIDs}, {"@Assessor", Assessor}, {"@UserLoginId", UserLoginId}, {"@EntryState", EntryState}, {"@Flag", Flag}};
		    var ret = new SQLServer().ExecSP("WF_BatchThirdAudit", oHT);
		    if (!ret)
			{
				this.Message = "������������";
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����뵥�ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginId">�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo,string newState, string UserLoginId)
		{
			var ret=true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}, {"@EntryState", newState}, {"@UserLoginId", UserLoginId}};

		    if((new SQLServer()).ExecSP("Pur_RequestOfStockPresent",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo,string newState)
		{
			var ret=true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}, {"@EntryState", newState}};

		    if((new SQLServer()).ExecSP("Pur_RequestOfStockCancel",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
        /// <param name="UserLoginID">string:	�����ˡ�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo,string newState,string UserLoginID)
		{
			var ret=true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}, {"@EntryState", newState}, {"@UserLoginID", UserLoginID}};

		    if((new SQLServer()).ExecSP("Pur_RequestOfStockCancel",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ���ݵ�����ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			var oHT = new Hashtable {{"@EntryNo", EntryNo}};
		    oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByEntryNo",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		/// <summary>
		/// ���ݵ��ݱ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			var oHT = new Hashtable {{"@EntryNo", EntryCode}};
		    oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByEntryCode",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		/// <summary>
		/// ��ȡ�����빺����
		/// </summary>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryAll()
		{
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetAll",oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		/// <summary>
		/// ����ָ�����Ƶ����Ż�ȡ�ɹ����뵥��
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			var oHT = new Hashtable {{"@AuthorDept", DeptCode}};
		    oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByDeptCode",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		#endregion

        /// <summary>
        /// ��ȡ��;��š�
        /// </summary>
        /// <param name="entryNo">�ɹ�������</param>
        /// <param name="serialNo">���</param>
        /// <returns>��;��š�</returns>
        public string GetReqReasonCode(int entryNo, int serialNo)
        {
            var sqlStatement = "Select ReqReasonCode From PROS Where EntryNo=@EntryNo";
            var parms = new[]{
                new SqlParameter("@EntryNo",DbType.Int32){Value=entryNo},
            };

            var obj = SqlHelper.ExecuteScalar(this.ConnString, CommandType.Text, sqlStatement, parms);
            return obj == null ? string.Empty : obj.ToString();
        }
		#region ͨ�ò�ѯ
		/// <summary>
		/// �û�Ĭ�ϵĲ�ѯ������
		/// </summary>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			var oHT = new Hashtable {{"@UserLoginId", UserLoginId}};
		    
            oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetAll",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			
            return oRequestOfStockData;
		}

        public object GetEntryByPerson(string EmpCode)
        {
            RequestOfStockData oRequestOfStockData = new RequestOfStockData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);
            oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByPerson", oHT, oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
            return oRequestOfStockData;
        }

		/// <summary>
		/// ���ݲ�ѯ������ȡ�������
		/// </summary>
		/// <param name="Sql_statement"></param>
		/// <returns></returns>
		public RequestOfStockData GetEntryBySQL(string Sql_Statement)
		{
			RequestOfStockData oRequestOfStockData = new RequestOfStockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		public RequestOfStockData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept,string AuthorCode,int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			RequestOfStockData oRequestOfStockData = new RequestOfStockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode", AuthorCode);
			oHT.Add("@AuditResult", AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByDeptAndAuthorAndAuditResult",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		#endregion
	}
	#endregion public class RequestOfStocks
}
