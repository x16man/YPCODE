using System.Collections;
using System.Data;
using MZHCommon.Database;
using Shmzh.MM.Common;

namespace Shmzh.MM.DataAccess
{

	#region public class WADJs
	/// <summary>
	/// �����͵��ݵĹ������ݷ��ʲ㡣
	/// </summary>
	public class WADJs:Messages,IInItems
	{
		#region ���캯��
		public WADJs()
		{}
		#endregion ���캯��

		#region ˽�з���
		/// <summary>
		/// ����ϣ��
		/// </summary>
		/// <param name="oEntry">WADJData:	��λ������ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(WADJData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[WADJData.WADJ_TABLE].Rows[0];
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
			oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);						//����������
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//���ϵ�λ������
			//��λ�����������ֶΡ�
			oHT.Add("@StoName",			oRow[WADJData.STONAME_FIELD]);						//�ֿ����ơ�
			oHT.Add("@StoCode",			oRow[WADJData.STOCODE_FIELD]);						//�ֿ��š�
			oHT.Add("@StoManagerCode",	oRow[WADJData.STOMANAGERCODE_FIELD]);				//�ֿ����Ա��š�
			oHT.Add("@StoManager",		oRow[WADJData.STOMANAGER_FIELD]);					//�ֿ����Ա���ơ�
			oHT.Add("@JFKM",			oRow[WADJData.JFKM_FIELD]);							//�跽��Ŀ��
			oHT.Add("@SrcConCodeList",	oRow[WADJData.SRCCONCODE_FIELD]);					
			oHT.Add("@SrcConNameList",	oRow[WADJData.SRCCONNAME_FIELD]);
			oHT.Add("@TgtConCodeList",	oRow[WADJData.TGTCONCODE_FIELD]);
			oHT.Add("@TgtConNameList",	oRow[WADJData.TGTCONNAME_FIELD]);
			oHT.Add("@PKIDList",		oRow[WADJData.PKID_FIELD]);
			
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
			WADJData oEntry = (WADJData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Sto_WADJInsert",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WADJInsert,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// �½��������ύ���ݡ�
		/// </summary>
		/// <param name="Entry">object:	��λ������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WADJData oEntry = (WADJData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Sto_WADJInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WADJInsertAndPresent,Please look the log file!";
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
			WADJData oEntry = (WADJData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Sto_WADJUpdate",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WADJUpdate,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �޸Ĳ������ύ��λ��������
		/// </summary>
		/// <param name="Entry">object:	��λ������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WADJData oEntry = (WADJData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Sto_WADJUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WADJUpdateAndPresent,Please look the log file!";
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
			if((new SQLServer()).ExecSP("Sto_WADJDelete",oHT) == false)
			{
				this.Message="Error,WADJDelete,Please look the log file!";
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
			bool ret = true;
			Hashtable oHT=new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",EntryState);
			if((new SQLServer()).ExecSP("Sto_WADJUpdateState",oHT) == false)
			{
				this.Message="Error,WADJUpdateState,Please look the log file!";
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
			WADJData oEntry= (WADJData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WADJData.WADJ_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Sto_WADJFirstAudit",oHT) == false)
			{
				this.Message="Error,WADJFirstAduit,Please look the log file!";
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
			WADJData oEntry= (WADJData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WADJData.WADJ_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Sto_WADJSecondAudit",oHT) == false)
			{
				this.Message="Error,WADJSecondAduit,Please look the log file!";
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
			WADJData oEntry= (WADJData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WADJData.WADJ_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Sto_WADJThirdAudit",oHT) == false)
			{
				this.Message="Error,WADJThirdAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ��λ�������ύ��
		/// </summary>
		/// <param name="EntryNo">int:	��λ��������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo,string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId",UserLoginId);
			
			if((new SQLServer()).ExecSP("Sto_WADJPresent",oHT) == false)
			{
				this.Message="Error,WADJPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ��λ���������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	��λ��������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo,string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			if((new SQLServer()).ExecSP("Sto_WADJCancel",oHT) == false)
			{
				this.Message="Error,WADJCancel,Please look the log file!";
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
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("Sto_WADJGetByEntryNo",oHT,oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// ���ݵ��ݱ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryCode);
			oSQLServer.ExecSPReturnDS("Sto_WADJGetByEntryCode",oHT,oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// ��ȡ�����빺����
		/// </summary>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryAll()
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Sto_WADJGetAll",oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// ����ָ�����Ƶ����Ż�ȡ��λ��������
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);
			oSQLServer.ExecSPReturnDS("Sto_WADJGetByDeptCode",oHT,oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		#endregion
	
		#region ͨ�ò�ѯ
		/// <summary>
		/// �û�Ĭ�ϵĲ�ѯ������
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>object:	��λ������ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("Sto_WADJGetAll",oHT,oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary> 
		/// ���ݲ�ѯ������ȡ�������
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL �ַ�����</param>
		/// <returns>WADJData:	��λ������ʵ�塣</returns>
		public WADJData GetEntryBySQL(string Sql_Statement)
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		#endregion

		#region ��λ������ר�з���
		/// <summary>
		/// ���ϵ�����ʱ�򣬽��п��ѡ��
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <returns>WADJData:	��λ������ʵ�塣</returns>
		public WADJData GetStockCon(string ItemCode,string StoCode)
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode", ItemCode);
			oHT.Add("@StoCode",StoCode);
			
			oSQLServer.ExecSPReturnDS("Sto_WADJGetStockChoice",oHT,oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// ��ȡ��λ����������������Դ��
		/// </summary>
		/// <returns>WADJData:	��λ����������Դ����ʵ�塣</returns>
		public WADJData GetWADJAll()
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_WADJGetAll",oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// ����PKIDs��ȡ��λ��������
		/// </summary>
		/// <param name="PKIDs">string:	ѡ�е�PKIDs��</param>
		/// <returns>WADJData:	��λ����������Դ����ʵ�塣</returns>
		public WADJData GetWADJByPKIDs(string PKIDs)
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKIDs",PKIDs);
			oSQLServer.ExecSPReturnDS("Sto_WADJGetByPKIDS",oHT,oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		#endregion 

		#region ��λ������ר�з���
		/// <summary>
		/// ������ˮ�Ż�ȡ��λ������ʵ�塣
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns></returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_WADJGetByEntryNoOutMode",oHT,oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// ����ģʽ�¸�����ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_WADJGetByEntryNoInMode",oHT,oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// ����״̬��ȡ��λ��������
		/// </summary>
		/// <returns>object:	��λ������ʵ�塣</returns>
		public object GetEntryByState()
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("Sto_WADJGetByState",oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// ת�ⵥ���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="SerialNoList">string:	���к����Ӵ���</param>
		/// <param name="ItemNumList">string:	��������</param>
		/// <param name="PKIDList">string:	��������</param>
		/// <param name="ItemDrawNumList">string:	������������</param>
		/// <param name="UserCode">string:	�û����š�</param>
		/// <param name="UserName">string:	�û����ơ�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool TransDrawOutStock(int EntryNo, 
								string SerialNoList, 
								string ItemNumList, 
								string PKIDList, 
								string ItemDrawNumList, 
								string UserCode, 
								string UserName, 
								string UserLoginId)
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

			ret = oSQLServer.ExecSP("Sto_WADJTransStockOut",oHT);
			if(ret == false)
			{
				this.Message = WADJData.OUT_FAILED;
			}
			else if(output == -1)
			{
				this.Message = WADJData.ROLL_FAILED;
			}
			else
			{
				this.Message = WADJData.OUT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ��λ���������Ϸ�����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="StoName">string:	�ֿ����ơ�</param>
		/// <param name="SerialNoList">string:	˳��š�</param>
		/// <param name="ItemCodeList">string:	���ϱ�š�</param>
		/// <param name="ConCodeList">string:	��λ��š�</param>
		/// <param name="ConNameList">string:	��λ���ơ�</param>
		/// <param name="UserCode">string:	�û���š�</param>
		/// <param name="UserName">string:	�û����ơ�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool TransDrawInStock( int EntryNo,
									string StoCode,
									string StoName, 
									string SerialNoList,
									string ItemCodeList,
									string ConCodeList,
									string ConNameList,
									string UserCode, 
									string UserName, 
									string UserLoginId)
		{
			bool ret = false;
			
			int output=0;

			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@DocCode", DocType.ADJ);
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

			ret = oSQLServer.ExecSP("Sto_WADJTransStockIn", oHT); //undone
			if(ret == false)
			{
				this.Message = WADJData.ADD_FAILED;
			}
			else if(output == -1)
			{
				this.Message = WADJData.ROLL_FAILED;
			}
			else
			{
				this.Message = WADJData.ADD_SUCCESSED;
			}
			return ret;
		}
		#endregion
	}
	#endregion public class WADJs
}