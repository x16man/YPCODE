using System.Collections;
using System.Data;
using MZHCommon.Database;
using Shmzh.MM.Common;

namespace Shmzh.MM.DataAccess
{

	#region public class WADJs
	/// <summary>
	/// 收料型单据的公共数据访问层。
	/// </summary>
	public class WADJs:Messages,IInItems
	{
		#region 构造函数
		public WADJs()
		{}
		#endregion 构造函数

		#region 私有方法
		/// <summary>
		/// 填充哈希表。
		/// </summary>
		/// <param name="oEntry">WADJData:	架位调整单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(WADJData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[WADJData.WADJ_TABLE].Rows[0];
			//收料模式公用字段。
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//单据流水号。
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//单据编号。
			oHT.Add("@DocCode",			oRow[InItemData.DOCCODE_FIELD]);					//单据类型。
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//单据类型名称。
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//单据类型文档编号。
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//单据状态。
			oHT.Add("@EntryDate",		oRow[InItemData.ENTRYDATE_FIELD]);					//制单日期。
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//制单人编号。
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//制单人名称。
			oHT.Add("@AuthorLoginID",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//制单人登录名。
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//制单人部门。
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//制单人部门名称。
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);					//单据合计金额。
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);						//备注。
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//单据明细内容顺序号。
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//物料编号。
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//物料名称。
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//物料规格。
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//物料单价。
			oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);						//调整数量。
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//物料金额。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//物料单位描述。
			//架位调整单特有字段。
			oHT.Add("@StoName",			oRow[WADJData.STONAME_FIELD]);						//仓库名称。
			oHT.Add("@StoCode",			oRow[WADJData.STOCODE_FIELD]);						//仓库编号。
			oHT.Add("@StoManagerCode",	oRow[WADJData.STOMANAGERCODE_FIELD]);				//仓库管理员编号。
			oHT.Add("@StoManager",		oRow[WADJData.STOMANAGER_FIELD]);					//仓库管理员名称。
			oHT.Add("@JFKM",			oRow[WADJData.JFKM_FIELD]);							//借方科目。
			oHT.Add("@SrcConCodeList",	oRow[WADJData.SRCCONCODE_FIELD]);					
			oHT.Add("@SrcConNameList",	oRow[WADJData.SRCCONNAME_FIELD]);
			oHT.Add("@TgtConCodeList",	oRow[WADJData.TGTCONCODE_FIELD]);
			oHT.Add("@TgtConNameList",	oRow[WADJData.TGTCONNAME_FIELD]);
			oHT.Add("@PKIDList",		oRow[WADJData.PKID_FIELD]);
			
			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员
		/// <summary>
		/// 单据增加。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 新建并马上提交单据。
		/// </summary>
		/// <param name="Entry">object:	架位调整单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 单据修改。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 修改并马上提交架位调整单。
		/// </summary>
		/// <param name="Entry">object:	架位调整单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 单据删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 单据状态更改。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="EntryState">string:	单据新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 架位调整单提交。
		/// </summary>
		/// <param name="EntryNo">int:	架位调整单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 架位调整单作废。
		/// </summary>
		/// <param name="EntryNo">int:	架位调整单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 根据单据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	请购单实体。</returns>
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
		/// 根据单据编号获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	请购单实体。</returns>
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
		/// 获取所有请购单。
		/// </summary>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryAll()
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Sto_WADJGetAll",oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// 根据指定的制单部门获取架位调整单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	请购单实体。</returns>
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
	
		#region 通用查询
		/// <summary>
		/// 用户默认的查询方案。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>object:	架位调整单实体。</returns>
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
		/// 根据查询方案获取结果集。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL 字符串。</param>
		/// <returns>WADJData:	架位调整单实体。</returns>
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

		#region 架位调整单专有方法
		/// <summary>
		/// 领料单发料时候，进行库存选择。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <returns>WADJData:	架位调整单实体。</returns>
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
		/// 获取架位调整单的所有数据源。
		/// </summary>
		/// <returns>WADJData:	架位调整单数据源数据实体。</returns>
		public WADJData GetWADJAll()
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_WADJGetAll",oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// 根据PKIDs获取架位调整单。
		/// </summary>
		/// <param name="PKIDs">string:	选中的PKIDs。</param>
		/// <returns>WADJData:	架位调整单数据源数据实体。</returns>
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

		#region 架位调整单专有方法
		/// <summary>
		/// 根据流水号获取架位调整单实体。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
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
		/// 收料模式下根据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 根据状态获取架位调整单。
		/// </summary>
		/// <returns>object:	架位调整单实体。</returns>
		public object GetEntryByState()
		{
			WADJData oWADJData = new WADJData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("Sto_WADJGetByState",oWADJData.Tables[WADJData.WADJ_TABLE]);
			return oWADJData;
		}
		/// <summary>
		/// 转库单发料。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="SerialNoList">string:	序列号连接串。</param>
		/// <param name="ItemNumList">string:	数量串。</param>
		/// <param name="PKIDList">string:	主键串。</param>
		/// <param name="ItemDrawNumList">string:	发料数量串。</param>
		/// <param name="UserCode">string:	用户工号。</param>
		/// <param name="UserName">string:	用户名称。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 架位调整单收料方法。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="StoName">string:	仓库名称。</param>
		/// <param name="SerialNoList">string:	顺序号。</param>
		/// <param name="ItemCodeList">string:	物料编号。</param>
		/// <param name="ConCodeList">string:	架位编号。</param>
		/// <param name="ConNameList">string:	架位名称。</param>
		/// <param name="UserCode">string:	用户编号。</param>
		/// <param name="UserName">string:	用户名称。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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