namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
	using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;

	#region public class WTRFs
	/// <summary>
	/// �����͵��ݵĹ������ݷ��ʲ㡣
	/// </summary>
	public class WTRFs:Messages,IInItems
	{
		#region ���캯��
		public WTRFs()
		{}
		#endregion ���캯��

		#region ˽�з���
		/// <summary>
		/// ����ϣ��
		/// </summary>
		/// <param name="oEntry">WTRFData:	ת�ⵥʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(WTRFData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[WTRFData.WTRF_TABLE].Rows[0];
			//����ģʽ�����ֶΡ�
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//������ˮ�š�
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//���ݱ�š�
			oHT.Add("@DocCode",			oRow[InItemData.DOCCODE_FIELD]);					//�������͡�
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//�����������ơ�
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//���������ĵ���š�
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//����״̬��
			oHT.Add("@EntryDate",		oRow[InItemData.ENTRYDATE_FIELD]);					//�Ƶ����ڡ�
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//�Ƶ��˱�š�
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//�Ƶ������ơ�
			oHT.Add("@AuthorLoginID",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//�Ƶ��˵�¼����
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//�Ƶ��˲��š�
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//�Ƶ��˲������ơ�
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);					//���ݺϼƽ�
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);						//��ע��
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//������ϸ����˳��š�
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//���ϱ�š�
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//�������ơ�
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//���Ϲ��
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//���ϵ��ۡ�

			oHT.Add("@PlanNumList",		oRow[WTRFData.PLANNUM_FIELD]);					//Ӧת������

			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//���ϵ�λ������
			//�������������ֶΡ�
			oHT.Add("@TgtStoName",			oRow[WTRFData.TGTSTONAME_FIELD]);				//ת��ֿ����ơ�
			oHT.Add("@TgtStoCode",		oRow[WTRFData.TGTSTOCODE_FIELD]);					//ת��ֿ��š�
			oHT.Add("@SrcStoCode",		oRow[WTRFData.SRCSTOCODE_FIELD]);					//�����ֿ��š�
			oHT.Add("@SrcStoName",	oRow[WTRFData.SRCSTONAME_FIELD]);						//�����ֿ����ơ�
			oHT.Add("@TransferDate",	oRow[WTRFData.TRANSFERDATE_FIELD]);					//ת�����ڡ�
			oHT.Add("@SrcStoManagerCode",		oRow[WTRFData.SRCSTOMANAGERCODE_FIELD]);	//�����ֿ����Ա��š�
			oHT.Add("@SrcStoManager",		oRow[WTRFData.SRCSTOMANAGER_FIELD]);			//�����ֿ����Ա���ơ�
			oHT.Add("@TgtStoManagerCode",	oRow[WTRFData.TGTSTOMANAGERCODE_FIELD]);		//ת��ֿ����Ա��š�
			oHT.Add("@TgtStoManager",		oRow[WTRFData.TGTSTOMANAGER_FIELD]);			//ת��ֿ����Ա���ơ�
//			oHT.Add("@PlanNum",		oRow[WTRFData.PLANNUM_FIELD]);							//Ӧת������
//			oHT.Add("@ItemNum",	oRow[WTRFData.ITEMNUM_FIELD]);								//ʵת������
			oHT.Add("@JFKM",		oRow[WTRFData.JFKM_FIELD]);									//�跽��Ŀ��
			
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
			bool ret = true;
			WTRFData oEntry = (WTRFData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WTRFInsert",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WTRFInsert,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// �½��������ύ���ݡ�
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WTRFData oEntry = (WTRFData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WTRFInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WTRFInsertAndPresent,Please look the log file!";
				ret=false;
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
			bool ret = true;
			WTRFData oEntry = (WTRFData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WTRFUpdate",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WTRFUpdate,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �޸Ĳ������ύת�ⵥ��
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WTRFData oEntry = (WTRFData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WTRFUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WTRFUpdateAndPresent,Please look the log file!";
				ret=false;
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
			bool ret = true;
			Hashtable oHT=new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			if((new SQLServer()).ExecSP("WTRFDelete",oHT) == false)
			{
				this.Message="Error,WTRFDelete,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ����״̬���ġ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	������״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret = true;
			Hashtable oHT=new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",EntryState);
			if((new SQLServer()).ExecSP("WTRFUpdateState",oHT) == false)
			{
				this.Message="Error,WTRFUpdateState,Please look the log file!";
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
			bool ret = true;
			Hashtable oHT=new Hashtable();
			WTRFData oEntry= (WTRFData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTRFData.WTRF_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WTRFFirstAudit",oHT) == false)
			{
				this.Message="Error,WTRFFirstAduit,Please look the log file!";
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
			bool ret = true;
			Hashtable oHT=new Hashtable();
			WTRFData oEntry= (WTRFData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTRFData.WTRF_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WTRFSecondAudit",oHT) == false)
			{
				this.Message="Error,WTRFSecondAduit,Please look the log file!";
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
			bool ret=true;
			Hashtable oHT=new Hashtable();
			WTRFData oEntry= (WTRFData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTRFData.WTRF_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WTRFThirdAudit",oHT) == false)
			{
				this.Message="Error,WTRFThirdAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ת�ⵥ�ύ��
		/// </summary>
		/// <param name="EntryNo">int:	ת�ⵥ��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo,string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId",UserLoginId);
			
			if((new SQLServer()).ExecSP("WTRFPresent",oHT) == false)
			{
				this.Message="Error,WTRFPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ת�ⵥ���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	ת�ⵥ��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo,string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			if((new SQLServer()).ExecSP("WTRFCancel",oHT) == false)
			{
				this.Message="Error,WTRFCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo,string newState, string UserLoginID)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID",UserLoginID);
			
			if((new SQLServer()).ExecSP("WTRFCancel",oHT) == false)
			{
				this.Message="Error,WTRFCancel,Please look the log file!";
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
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("WTRFGetByEntryNo",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// ���ݵ��ݱ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryCode);
			oSQLServer.ExecSPReturnDS("WTRFGetByEntryCode",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// ��ȡ�����빺����
		/// </summary>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryAll()
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("WTRFGetAll",oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// ����ָ�����Ƶ����Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);
			oSQLServer.ExecSPReturnDS("WTRFGetByDeptCode",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		#endregion
	
		#region ͨ�ò�ѯ
		/// <summary>
		/// �û�Ĭ�ϵĲ�ѯ������
		/// </summary>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("WTRFGetAll",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// ���ݲ�ѯ������ȡ�������
		/// </summary>
		/// <param name="Sql_statement"></param>
		/// <returns></returns>
		public WTRFData GetEntryBySQL(string Sql_Statement)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		#endregion

		#region ת�ⵥר�з���
		/// <summary>
		/// ��ȡת�ⵥ����������Դ��
		/// </summary>
		/// <returns>WTRFData:	ת�ⵥ����Դ����ʵ�塣</returns>
		public WTRFData GetWTRFAll()
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("WTRFGetAll",oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@EntryNo",		EntryNo);
			oHT.Add("@EntryState",	newState);
			oHT.Add("@UserLoginId", UserLoginId);
			ret = oSQLServer.ExecSP("OrderAffirm",oHT);
			if(ret == false)
			{
				this.Message = WTRFData.AFFIRM_FAILED;
			}
			else
			{
				this.Message = WTRFData.ADD_SUCCESSED;
			}
			return ret;

		}
		public WTRFData GetWTRFByPKIDs(string PKIDs)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKIDs",PKIDs);
			oSQLServer.ExecSPReturnDS("WTRFGetByPKIDS",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		#endregion 

		#region ת��ר�з���
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("WTRFGetByEntryNoOutMode",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}

		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("WTRFGetByEntryNoInMode",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// ����״̬��ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>object:	ת�ⵥʵ�塣</returns>
		public object GetEntryByState()
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("WTRFGetByState",oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		public bool TransDrawOutStock(int EntryNo, string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			int output=0;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@SerialNoList", SerialNoList);
			oHT.Add("@ItemNumList", ItemNumList);
			oHT.Add("@PKIDList", PKIDList);
			oHT.Add("@ItemDrawNumList", ItemDrawNumList);
			oHT.Add("@UserCode",UserCode);
			oHT.Add("@UserName",UserName);
			oHT.Add("@UserLoginId",UserLoginId);
			oHT.Add("@EntryState",DocStatus.Drawed);
			oHT.Add("@OutPut",output);

			ret = oSQLServer.ExecSP("WTRFTransStockOut",oHT);
			if(ret == false)
			{
				this.Message = WTRFData.OUT_FAILED;
			}
			else if(output == -1)
			{
				this.Message = WTRFData.ROLL_FAILED;
			}
			else
			{
				this.Message = WTRFData.OUT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ת�ⵥ���Ϸ�����
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool TransDrawInStock( int EntryNo,string StoCode,string StoName, string SerialNoList,string ItemCodeList,string ConCodeList,string ConNameList,string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			
			int output=0;

			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@DocCode", DocType.TRF);
			oHT.Add("@StoCode", StoCode);
			oHT.Add("@StoName", StoName);
			oHT.Add("@SerialNoList",SerialNoList);
			oHT.Add("@ItemCodeList",ItemCodeList);
			oHT.Add("@ConCodeList",ConCodeList);
			oHT.Add("@ConNameList",ConNameList);
			oHT.Add("@UserCode",UserCode);
			oHT.Add("@UserName",UserName);
			oHT.Add("@UserLoginId",UserLoginId);
			oHT.Add("@EntryState",DocStatus.Received);
			oHT.Add("@OutPut",output);

		ret = oSQLServer.ExecSP("WTRFTransStockIn", oHT); //undone
			if(ret == false)
			{
				this.Message = WTRFData.ADD_FAILED;
			}
			else if(output == -1)
			{
				this.Message = WTRFData.ROLL_FAILED;
			}
			else
			{
				this.Message = WTRFData.ADD_SUCCESSED;
			}
			return ret;
		}
		#endregion
	}
	#endregion public class WTRFs
}