using System.Collections;
using MZHCommon.Database;
using Shmzh.MM.Common;
//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// 供应商/客户数据实体层。
	/// </summary>
	public class PPRNs : Messages
	{
		public PPRNs()
		{		}
		/// <summary>
		///  获得所有供应商/客户信息。
		/// </summary>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNAll ()
		{
			PPRNData ds = new PPRNData ();
			SQLServer mysp = new SQLServer ();

			if (!mysp.ExecSPReturnDS("Pur_PPRNGetAll",ds.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return ds;
		}
		/// <summary>
		/// 根据类别、状态、已核准 三个条件获得供应商/客户信息。
		/// </summary>
		/// <param name="Type">string:	类别。</param>
		/// <param name="Status">string:	状态。</param>
		/// <param name="Approve">string:	已核准。</param>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNByTypeAndStatusAndApprove(string Type, string Status, string Approve)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PPRNData myDS = new PPRNData ();

			myHT.Add ("@Type",Type);
			myHT.Add ("@Status",Status);
			myHT.Add ("@Approve",Approve);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetByTypeAndStatusAndApprove", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据供应商/客户编号获得供应商/客户信息。
		/// </summary>
		/// <param name="Code">string:	供应商/客户编号。</param>
		/// <returns>PPRNData:	供应商/客户数据集。</returns>
		public PPRNData GetPPRNByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PPRNData myDS = new PPRNData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetByCode", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 获取当前编号最大的供应商信息.
		/// </summary>
		/// <returns>PPRNData:	供应商/客户数据集。</returns>
		public PPRNData GetPPRNWithMaxCode()
		{
			PPRNData myDS = new PPRNData ();
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetWithMaxCode",myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据供应商/客户中文名称获得供应商/客户信息。
		/// </summary>
		/// <param name="CNName">string:	供应商/客户中文名称。</param>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNByCNName(string CNName)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PPRNData myDS = new PPRNData ();

			myHT.Add ("@CNName",CNName);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetByCNName", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据供应商/客户英文名来获取供应商/客户信息。
		/// </summary>
		/// <param name="ENName">string:	供应商/客户英文名。</param>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNByENName(string ENName)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PPRNData myDS = new PPRNData ();

			myHT.Add ("@ENName",ENName);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetByENName", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 获取本单位信息。
		/// </summary>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNSelf()
		{
			PPRNData myDS = new PPRNData ();
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetSelf", myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 供应商/客户 增加。
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	供应商/客户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Add(PPRNData myPPRNData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@Code",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString());				//供应商代码。
			myHT.Add ("@CNName",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CNNAME_FIELD].ToString());			//中文名称。
			myHT.Add ("@ENName",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ENNAME_FIELD].ToString());			//英文名称。
			myHT.Add ("@Type",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TYPE_FIELD].ToString());				//类别。
			myHT.Add ("@Status",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.STATUS_FIELD].ToString());			//状态。
			myHT.Add ("@Approve",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.APPROVE_FIELD].ToString());		//已核准。
			myHT.Add ("@Currency",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CURRENCY_FIELD].ToString());		//货币代码。
			myHT.Add ("@PayStyle",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.PAYSTYLE_FIELD].ToString());		//付款方式。
			myHT.Add ("@Tel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TEL_FIELD].ToString());				//电话。
			myHT.Add ("@Fax",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.FAX_FIELD].ToString());				//传真。
			myHT.Add ("@Email",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.EMAIL_FIELD].ToString());			//邮箱。
			myHT.Add ("@LinkMan",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKMAN_FIELD].ToString());		//联系人。
			myHT.Add ("@LinkTel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKTEL_FIELD].ToString());		//联系人电话。
			myHT.Add ("@LinkMail",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKMAIL_FIELD].ToString());		//联系人邮箱。
			myHT.Add ("@AccLink",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCLINK_FIELD].ToString());		//财务联系人。
			myHT.Add ("@AccLinkTel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCLINKTEL_FIELD].ToString());	//财务联系人电话。
			myHT.Add ("@Address",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ADDRESS_FIELD].ToString());		//地址。
			myHT.Add ("@Zip",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ZIP_FIELD].ToString());				//邮编。
			myHT.Add ("@Licence",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LICENCE_FIELD].ToString());		//营业执照号码。
			myHT.Add ("@RegMoney",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.REGMONEY_FIELD].ToString());		//注册资金。
			myHT.Add ("@Turnover",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TURNOVER_FIELD].ToString());		//年营业额。
			myHT.Add ("@Deputy",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.DEPUTY_FIELD].ToString());			//法人代表。
			myHT.Add ("@Bank",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.BANK_FIELD].ToString());				//开户银行。
			myHT.Add ("@Account",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCOUNT_FIELD].ToString());		//账户。
			myHT.Add ("@TaxNO",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TAXNO_FIELD].ToString());			//税务登记号。
			myHT.Add ("@Country",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.COUNTRY_FIELD].ToString());		//国家。
			myHT.Add ("@State",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.STATE_FIELD].ToString());			//州省。
			myHT.Add ("@City",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CITY_FIELD].ToString());				//城市。
			myHT.Add ("@PurchaseAcc",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.PURCHASEACC_FIELD].ToString());//采购账户。
			myHT.Add ("@APAcc",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.APACC_FIELD].ToString());			//应付账户。
			myHT.Add ("@Remark",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.REMARK_FIELD].ToString());			//备注。
			myHT.Add("@CatCode",int.Parse(myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CatCode_Field].ToString()));//供应商分类。
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRNInsert",myHT))
			{
				this.Message = PPRNData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PPRNData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// 供应商/客户 修改。
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	供应商/客户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(PPRNData myPPRNData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@OldCode", myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.OLDCODE_FIELD].ToString());			//修改前的代码。
			myHT.Add ("@Code",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString());					//修改后的代码。
			myHT.Add ("@CNName",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CNNAME_FIELD].ToString());				//中文名称。
			myHT.Add ("@ENName",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ENNAME_FIELD].ToString());				//英文名称。
			myHT.Add ("@Type",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TYPE_FIELD].ToString());					//类别。
			myHT.Add ("@Status",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.STATUS_FIELD].ToString());				//状态。
			myHT.Add ("@Approve",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.APPROVE_FIELD].ToString());			//已核准。
			myHT.Add ("@Currency",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CURRENCY_FIELD].ToString());			//货币代码。
			myHT.Add ("@PayStyle",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.PAYSTYLE_FIELD].ToString());			//付款方式。
			myHT.Add ("@Tel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TEL_FIELD].ToString());					//电话。
			myHT.Add ("@Fax",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.FAX_FIELD].ToString());					//传真。
			myHT.Add ("@Email",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.EMAIL_FIELD].ToString());				//邮箱。
			myHT.Add ("@LinkMan",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKMAN_FIELD].ToString());			//联系人。
			myHT.Add ("@LinkTel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKTEL_FIELD].ToString());			//联系人电话。
			myHT.Add ("@LinkMail",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKMAIL_FIELD].ToString());			//联系人邮箱。
			myHT.Add ("@AccLink",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCLINK_FIELD].ToString());			//财务联系人。
			myHT.Add ("@AccLinkTel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCLINKTEL_FIELD].ToString());		//财务联系人电话。
			myHT.Add ("@Address",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ADDRESS_FIELD].ToString());			//地址。
			myHT.Add ("@Zip",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ZIP_FIELD].ToString());					//邮编。
			myHT.Add ("@Licence",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LICENCE_FIELD].ToString());			//营业执照号码。
			myHT.Add ("@RegMoney",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.REGMONEY_FIELD].ToString());			//注册资金。
			myHT.Add ("@Turnover",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TURNOVER_FIELD].ToString());			//年营业额。
			myHT.Add ("@Deputy",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.DEPUTY_FIELD].ToString());				//法人代表。
			myHT.Add ("@Bank",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.BANK_FIELD].ToString());					//开户银行。
			myHT.Add ("@Account",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCOUNT_FIELD].ToString());			//账户。
			myHT.Add ("@TaxNO",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TAXNO_FIELD].ToString());				//税务登记号。
			myHT.Add ("@Country",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.COUNTRY_FIELD].ToString());			//国家。
			myHT.Add ("@State",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.STATE_FIELD].ToString());				//州省。
			myHT.Add ("@City",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CITY_FIELD].ToString());					//城市。
			myHT.Add ("@PurchaseAcc",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.PURCHASEACC_FIELD].ToString());	//采购账户。
			myHT.Add ("@APAcc",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.APACC_FIELD].ToString());				//应付账户。
			myHT.Add ("@Remark",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.REMARK_FIELD].ToString());				//备注。
			myHT.Add("@CatCode",int.Parse(myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CatCode_Field].ToString()));//供应商分类。
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRNUpdate",myHT))
			{
				this.Message = PPRNData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PPRNData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 供应商/客户 删除。
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	供应商/客户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(PPRNData myPPRNData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@Code", myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRNDelete",myHT))
			{
				this.Message = PPRNData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PPRNData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 根据供应商代码字符串进行供应商删除。
		/// </summary>
		/// <param name="Codes">string:	供应商字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@Codes", Codes);

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRNDeleteByCodes",myHT))
			{
				this.Message = PPRNData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PPRNData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}

		#region 通用查询
		public PPRNData GetPPRNBySQL(string Sql_Statement)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PPRNData myDS = new PPRNData ();

			myHT.Add("@Sql_Statement",Sql_Statement);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Qry_ExecSQL", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		#endregion
	}
}
