using System;
using MZHCommon.Database;
using Shmzh.MM.Common;
using System.Data;
using System.Collections;
using MZHCommon.Input;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// Categories ��ժҪ˵����
	/// </summary>
	public class Items:Messages
	{
		/// <summary>
		/// ��������������
		/// </summary>
		/// <param name="oItemData">����������ʵ��</param>
		/// <returns>true or false</returns>
		public bool InsertItem(ItemData oItemData)
		{
			Hashtable oHT=new Hashtable();

			DataRow oRow;

			oRow=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0];

			oHT.Add("@Code",oRow[ItemData.CODE_FIELD]);
            oHT.Add("@NewCode",oRow[ItemData.NEWCODE_FIELD]);
			oHT.Add("@CnName",oRow[ItemData.CNNAME_FIELD]);
			oHT.Add("@EnName",oRow[ItemData.ENNAME_FIELD]);
			oHT.Add("@CatCode",oRow[ItemData.CATCODE_FIELD]);
			oHT.Add("@Special",oRow[ItemData.SPECIAL_FIELD]);
			oHT.Add("@MacCode",oRow[ItemData.MACCODE_FIELD]);
			oHT.Add("@PurMak",oRow[ItemData.PURMAK_FIELD]);
			oHT.Add("@UnitCode",oRow[ItemData.UNITCODE_FIELD]);
			oHT.Add("@State",oRow[ItemData.STATE_FIELD]);
			oHT.Add("@Batch",oRow[ItemData.BATCH_FIELD]);

			oHT.Add("@SerialNo",oRow[ItemData.SERIALNO_FIELD]);
			oHT.Add("@Checked",oRow[ItemData.CHECKED_FIELD]);
			oHT.Add("@ChkRptCode",oRow[ItemData.CHKRPTCODE_FIELD]);
			oHT.Add("@ABC",oRow[ItemData.ABC_FIELD]);
			oHT.Add("@CstPrice",oRow[ItemData.CSTPRICE_FIELD]);
			oHT.Add("@EvaPrice",oRow[ItemData.EVAPRICE_FIELD]);
			oHT.Add("@AccType",oRow[ItemData.ACCTYPE_FIELD]);
			oHT.Add("@UppNum",oRow[ItemData.UPPNUM_FIELD]);
			oHT.Add("@LowNum",oRow[ItemData.LOWNUM_FIELD]);
			oHT.Add("@SafNum",oRow[ItemData.SAFNUM_FIELD]);
			
			oHT.Add("@OrdNum",oRow[ItemData.ORDNUM_FIELD]);
			oHT.Add("@OrdBat",oRow[ItemData.ORDBAT_FIELD]);
			oHT.Add("@DefSto",oRow[ItemData.DEFSTO_FIELD]);
			oHT.Add("@DefCon",oRow[ItemData.DEFCON_FIELD]);
			oHT.Add("@SetEnable",oRow[ItemData.SETENABLE_FIELD]);
			oHT.Add("@EnFrmDate",oRow[ItemData.ENFRMDATE_FIELD]);
			oHT.Add("@EnEndDate",oRow[ItemData.ENENDDATE_FIELD]);
			oHT.Add("@EnRemark",oRow[ItemData.ENREMARK_FIELD]);
			oHT.Add("@SetFreezed",oRow[ItemData.SETFREEZED_FIELD]);
			oHT.Add("@FrFrmDate",oRow[ItemData.FRFRMDATE_FIELD]);

			oHT.Add("@FrEndDate",oRow[ItemData.FRENDDATE_FIELD]);
			oHT.Add("@FrRemark",oRow[ItemData.FRREMARK_FIELD]);
			oHT.Add("@PrvCode",oRow[ItemData.PRVCODE_FIELD]);
			oHT.Add("@Locked",oRow[ItemData.LOCKED_FIELD]);

			return (new SQLServer()).ExecSP("Sto_ItemInsert",oHT);

		}	//End InsertItem


		/// <summary>
		/// �༭����������
		/// </summary>
		/// <param name="oItemData">����������ʵ��</param>
		/// <returns>true or false</returns>
		public bool UpdateItem(ItemData oItemData)
		{
			Hashtable oHT=new Hashtable();

			DataRow oRow;

			oRow=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0];



            oHT.Add("@Code", oRow[ItemData.CODE_FIELD]);
            oHT.Add("@NewCode", oRow[ItemData.NEWCODE_FIELD]);
			oHT.Add("@CnName",oRow[ItemData.CNNAME_FIELD]);
			oHT.Add("@EnName",oRow[ItemData.ENNAME_FIELD]);
			oHT.Add("@CatCode",oRow[ItemData.CATCODE_FIELD]);
			oHT.Add("@Special",oRow[ItemData.SPECIAL_FIELD]);
			oHT.Add("@MacCode",oRow[ItemData.MACCODE_FIELD]);
			oHT.Add("@PurMak",oRow[ItemData.PURMAK_FIELD]);
			oHT.Add("@UnitCode",oRow[ItemData.UNITCODE_FIELD]);
			oHT.Add("@State",oRow[ItemData.STATE_FIELD]);
			oHT.Add("@Batch",oRow[ItemData.BATCH_FIELD]);

			oHT.Add("@SerialNo",oRow[ItemData.SERIALNO_FIELD]);
			oHT.Add("@Checked",oRow[ItemData.CHECKED_FIELD]);
			oHT.Add("@ChkRptCode",oRow[ItemData.CHKRPTCODE_FIELD]);
			oHT.Add("@ABC",oRow[ItemData.ABC_FIELD]);
			oHT.Add("@CstPrice",oRow[ItemData.CSTPRICE_FIELD]);
			oHT.Add("@EvaPrice",oRow[ItemData.EVAPRICE_FIELD]);
			oHT.Add("@AccType",oRow[ItemData.ACCTYPE_FIELD]);
			oHT.Add("@UppNum",oRow[ItemData.UPPNUM_FIELD]);
			oHT.Add("@LowNum",oRow[ItemData.LOWNUM_FIELD]);
			oHT.Add("@SafNum",oRow[ItemData.SAFNUM_FIELD]);
			
			oHT.Add("@OrdNum",oRow[ItemData.ORDNUM_FIELD]);
			oHT.Add("@OrdBat",oRow[ItemData.ORDBAT_FIELD]);
			oHT.Add("@DefSto",oRow[ItemData.DEFSTO_FIELD]);
			oHT.Add("@DefCon",oRow[ItemData.DEFCON_FIELD]);
			oHT.Add("@SetEnable",oRow[ItemData.SETENABLE_FIELD]);
			oHT.Add("@EnFrmDate",oRow[ItemData.ENFRMDATE_FIELD]);
			oHT.Add("@EnEndDate",oRow[ItemData.ENENDDATE_FIELD]);
			oHT.Add("@EnRemark",oRow[ItemData.ENREMARK_FIELD]);
			oHT.Add("@SetFreezed",oRow[ItemData.SETFREEZED_FIELD]);
			oHT.Add("@FrFrmDate",oRow[ItemData.FRFRMDATE_FIELD]);

			oHT.Add("@FrEndDate",oRow[ItemData.FRENDDATE_FIELD]);
			oHT.Add("@FrRemark",oRow[ItemData.FRREMARK_FIELD]);
			oHT.Add("@PrvCode",oRow[ItemData.PRVCODE_FIELD]);
			oHT.Add("@Locked",oRow[ItemData.LOCKED_FIELD]);

			return (new SQLServer()).ExecSP("Sto_ItemUpdate",oHT);

		}	//End UpdateCategroy


		/// <summary>
		/// 
		/// </summary>
		/// <param name="Code"></param>
		/// <param name="CnName"></param>
		/// <param name="CatCode"></param>
		/// <param name="Special"></param>
		/// <param name="PurMak"></param>
		/// <param name="State"></param>
		/// <param name="ABC"></param>
		/// <param name="Checked"></param>
		/// <param name="Batch"></param>
		/// <param name="SerialNo"></param>
		/// <param name="Records">��ѯ��¼������</param>
		/// <returns>����������ʵ��</returns>
		public ItemData ComplexQueryItems(string Code,
                                          string NewCode,
										  string CnName,
										  int CatCode,
										  string Special,
										  string PurMak,
										  string State,
										  string ABC,
										  string Checked,
										  string Batch,	
										  string SerialNo,
										  int Records
										  )
		{
			ItemData oItemData=new ItemData();

			Hashtable oHT=new Hashtable();

			oHT.Add("@Code",InputCheck.EffectiveSQLInput(Code));
            oHT.Add("@NewCode",InputCheck.EffectiveSQLInput(NewCode));
			oHT.Add("@CnName",InputCheck.EffectiveSQLInput(CnName));
			oHT.Add("@CatCode",CatCode);
			oHT.Add("@Special",InputCheck.EffectiveSQLInput(Special));
			oHT.Add("@PurMak",InputCheck.EffectiveSQLInput(PurMak));
			oHT.Add("@State",InputCheck.EffectiveSQLInput(State));
			oHT.Add("@ABC",InputCheck.EffectiveSQLInput(ABC));
			oHT.Add("@Checked",Checked);
			oHT.Add("@Batch",Batch);
			oHT.Add("@SerialNo",SerialNo);
			oHT.Add("@Records",Records);

			if ((new SQLServer()).ExecSPReturnDS("Sto_ItemCompleteQuery",oHT,oItemData.Tables[ItemData.ITEM_TABLE])==false)
			{
				this.Message="Error,Sto_ItemQueryByCode,Please look the log file!";
			}
			return oItemData;
		}
		/// <summary>
		/// �����������ƺ͹���ȡ�������ļ���Ϣ��
		/// </summary>
		/// <param name="ItemName">string:	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
		/// <returns>ItemData:	����������ʵ��.</returns>
		public ItemData GetItemByNameAndSpec(string ItemName, string ItemSpec)
		{
			ItemData oItemData = new ItemData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemName", ItemName);
			oHT.Add("@ItemSpec", ItemSpec);
			 
			new SQLServer().ExecSPReturnDS("Sto_ItemGetByNameAndSpec",oHT,oItemData.Tables[ItemData.ITEM_TABLE]);
			return oItemData;
		}
		/// <summary>
		/// �����������Ƶ�ƴ������ĸ���������ϵĲ�ѯ��
		/// </summary>
		/// <param name="PYZM">string:	ƴ������</param>
		/// <returns>ItemData:	����������ʵ��.</returns>
		public ItemData GetItemByPY(string PYZM)
		{
			ItemData oItemData = new ItemData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PYZM",PYZM);

			new SQLServer().ExecSPReturnDS("Sto_ItemGetByPY",oHT,oItemData.Tables[ItemData.ITEM_TABLE]);
			return oItemData;
		}
		/// <summary>
		/// ����SQL����ȡ������Ϣ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL��䡣</param>
		/// <returns>ItemData:	��������ʵ�塣</returns>
		public ItemData GetItemBySQL(string Sql_Statement)
		{
			ItemData oItemData=new ItemData();
			Hashtable oHT=new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oItemData.Tables[ItemData.ITEM_TABLE]);
			return oItemData;
		}
		/// <summary>
		/// ����ʹ��Ƶ�ʻ�ȡǰN�����ϡ�
		/// </summary>
		/// <returns>ItemData:	��������ʵ�塣</returns>
		public ItemData GetItemByUseCount()
		{
			ItemData oItemData = new ItemData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Sto_ItemGetByUseCount",oItemData.Tables[ItemData.ITEM_TABLE]);
			return oItemData;
		}
		/// <summary>
		/// ��ȡ���ϵ��Ƽ���š�
		/// </summary>
		/// <param name="PrefixStr">string:	���ǰ׺���ɲֿ��źͷ�������Ӷ��ɡ�</param>
		/// <returns>ItemData:	��������ʵ�塣</returns>
		public ItemData GetItemRecommandCode(string PrefixStr)
		{
			ItemData oItemData = new ItemData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PrefixStr",PrefixStr);
			oSQLServer.ExecSPReturnDS("Sto_ItemGetRecommandCode",oHT,oItemData.Tables[ItemData.ITEM_TABLE]);
			return oItemData;
		}
		/// <summary>
		/// ɾ���������ļ���¼
		/// </summary>
		/// <param name="Codes">string:	���ϱ�Ŵ���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteItemsByCodes(string Codes)
		{
			bool ret=true;

			Hashtable oHT=new Hashtable();

			oHT.Add("@Codes",Codes);
			
			if ((new SQLServer()).ExecSP("Sto_ItemDelete",oHT)==false)
			{
				this.Message="Error,Sto_ItemDelete,Please look the log file!";
				ret=false;
			}
			return ret;
		}

	}
}


