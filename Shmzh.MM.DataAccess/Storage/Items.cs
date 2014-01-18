using System;
using MZHCommon.Database;
using Shmzh.MM.Common;
using System.Data;
using System.Collections;
using MZHCommon.Input;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// Categories 的摘要说明。
	/// </summary>
	public class Items:Messages
	{
		/// <summary>
		/// 新增物料主数据
		/// </summary>
		/// <param name="oItemData">物料主数据实体</param>
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
		/// 编辑物料主数据
		/// </summary>
		/// <param name="oItemData">物料主数据实体</param>
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
		/// <param name="Records">查询记录集数量</param>
		/// <returns>物料主数据实体</returns>
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
		/// 根据物料名称和规格获取物料主文件信息。
		/// </summary>
		/// <param name="ItemName">string:	物料名称。</param>
		/// <param name="ItemSpec">string:	规格型号。</param>
		/// <returns>ItemData:	物料主数据实体.</returns>
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
		/// 根据物料名称的拼音首字母来进行物料的查询。
		/// </summary>
		/// <param name="PYZM">string:	拼音串。</param>
		/// <returns>ItemData:	物料主数据实体.</returns>
		public ItemData GetItemByPY(string PYZM)
		{
			ItemData oItemData = new ItemData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PYZM",PYZM);

			new SQLServer().ExecSPReturnDS("Sto_ItemGetByPY",oHT,oItemData.Tables[ItemData.ITEM_TABLE]);
			return oItemData;
		}
		/// <summary>
		/// 根据SQL语句获取物料信息。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句。</param>
		/// <returns>ItemData:	物料数据实体。</returns>
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
		/// 根据使用频率获取前N个物料。
		/// </summary>
		/// <returns>ItemData:	物料数据实体。</returns>
		public ItemData GetItemByUseCount()
		{
			ItemData oItemData = new ItemData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Sto_ItemGetByUseCount",oItemData.Tables[ItemData.ITEM_TABLE]);
			return oItemData;
		}
		/// <summary>
		/// 获取物料的推荐编号。
		/// </summary>
		/// <param name="PrefixStr">string:	编号前缀，由仓库编号和分类号连接而成。</param>
		/// <returns>ItemData:	物料数据实体。</returns>
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
		/// 删除物料主文件记录
		/// </summary>
		/// <param name="Codes">string:	物料编号串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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


