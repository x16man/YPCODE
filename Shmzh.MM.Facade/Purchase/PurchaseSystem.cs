using System;
using Shmzh.MM.BusinessRules;
using Shmzh.MM.Common;
using Shmzh.MM.DataAccess;

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

namespace Shmzh.MM.Facade
{
	/// <summary>
	/// PBaseSystem 的摘要说明。
	/// </summary>
	public class PurchaseSystem : MarshalByRefObject,IPPRNSystem,IPslpSystem,IPMRPSystem, IPOSystem, IPPSystem, IBRSystem,IPCBRSystem,IPRTVSystem,IPBRBSystem,IPAYSystem,IAudit3System,IPPRCSystem   ,ICancelSystem
	{
		#region 成员变量
		
		#endregion

		#region 属性
        public string Message { get; set; }
		#endregion

		#region IPPRNSystem 成员
		/// <summary>
		/// 获得所有供应商/客户.
		/// </summary>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNAll()
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNAll();
		}
		/// <summary>
		/// 根据供应商/客户编号获取供应商/客户信息。
		/// </summary>
		/// <param name="Code">string:	供应商/客户编号。</param>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNByCode(string Code)
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByCode(Code);
		}
		/// <summary>
		/// 获取当前供应商编号的供应商。
		/// </summary>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNWithMaxCode()
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNWithMaxCode();
		}
		/// <summary>
		/// 根据供应商/客户中文名称获得供应商/客户信息。
		/// </summary>
		/// <param name="CNName">string:	供应商/客户中文名称。</param>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNByCNName(string CNName)
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByCNName(CNName);
		}
		/// <summary>
		/// 根据供应商/客户英文名称获得供应商/客户信息。
		/// </summary>
		/// <param name="ENName">string:	供应商/客户英文名称。</param>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNByENName(string ENName)
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByENName(ENName);
		}
		/// <summary>
		/// 根据类别、状态、已核准来获得供应商/客户信息。
		/// </summary>
		/// <param name="Type">string:	类别。</param>
		/// <param name="Status">string:	状态。</param>
		/// <param name="Approve">string:	已核准。</param>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNByTypeAndStatusAndApprove(string Type, string Status, string Approve)
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByTypeAndStatusAndApprove(Type,Status,Approve);
		}
		/// <summary>
		/// 获取本单位信息。
		/// </summary>
		/// <returns>PPRNData:	供应商/客户数据实体。</returns>
		public PPRNData GetPPRNSelf()
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNSelf();
		}
		/// <summary>
		/// 供应商/客户 增加。
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	供应商/客户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddPPRN(PPRNData myPPRNData)
		{
			bool ret = true;
			// 条件检查，看是不是空对象。
			if (myPPRNData != null)
			{
				var myPPRN = new PPRN();
				if(myPPRN.Insert(myPPRNData) == false)
				{
					ret = false;
				}
				this.Message = myPPRN.Message;
			}
			else
			{
				this.Message = PPRNData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 供应商/客户 修改。
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	供应商/客户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdatePPRN(PPRNData myPPRNData)
		{
			bool ret = true;
			// 条件检查，看是不是空对象。
			if (myPPRNData != null)
			{
				var myPPRN = new PPRN();
				if(myPPRN.Update(myPPRNData) == false)
				{
					ret = false;
				}
				this.Message = myPPRN.Message;
			}
			else
			{
				this.Message = PPRNData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 供应商/客户 删除。
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	供应商/客户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePPRN(PPRNData myPPRNData)
		{
			bool ret = true;
			// 条件检查，看是不是空对象。
			if (myPPRNData != null)
			{
				var myPPRN = new PPRN();
				if(myPPRN.Delete(myPPRNData) == false)
				{
					ret = false;
				}
				this.Message = myPPRN.Message;
			}
			else
			{
				this.Message = PPRNData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据传入的供应商代码字符串进行供应商删除。
		/// </summary>
		/// <param name="Codes">string:	供应商代码串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePPRN(string Codes)
		{
			bool ret = true;
			// 条件检查，看是不是空对象。
			if (Codes != null && Codes != "")
			{
				var myPPRN = new PPRN();
				if(myPPRN.Delete(Codes) == false)
				{
					ret = false;
				}
				this.Message = myPPRN.Message;
			}
			else
			{
				this.Message = PPRNData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		#endregion

		#region IPslpSystem 成员
		/// <summary>
		/// 获取全部采购员。
		/// </summary>
		/// <returns>PslpData:	采购员数据实体。</returns>
		PslpData IPslpSystem.GetPslpAll()
		{
			var myPlsps = new Pslps();
			return myPlsps.GetPslpAll();
		}
		/// <summary>
		/// 根据采购员代码获取采购员。
		/// </summary>
		/// <param name="Code">string:	采购员代码。</param>
		/// <returns>PslpData:	采购员数据实体。</returns>
		PslpData IPslpSystem.GetPslpByCode(string Code)
		{
			var myPlsps = new Pslps();
			return myPlsps.GetPslpByCode(Code);
		}
		/// <summary>
		/// 采购员增加。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddPslp(PslpData myPslpData)
		{
			bool ret = true;
			if (myPslpData != null)
			{
				var myPslps = new Pslps();
				ret = myPslps.Add(myPslpData);
			}
			else
			{
				this.Message = PslpData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购员修改。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdatePslp(PslpData myPslpData)
		{
			bool ret = true;
			if (myPslpData != null)
			{
				var myPslps = new Pslps();
				ret = myPslps.Update(myPslpData);
			}
			else
			{
				this.Message = PslpData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购员单条记录删除。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePslp(PslpData myPslpData)
		{
			bool ret = true;
			if (myPslpData != null)
			{
				var myPslps = new Pslps();
				ret = myPslps.Delete(myPslpData);
			}
			else
			{
				this.Message = PslpData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购员多条记录删除。
		/// </summary>
		/// <param name="Codes">string:	采购员代码串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool IPslpSystem.DeletePslp(string Codes)
		{
			bool ret = true;
			if (Codes != null && Codes != "")
			{
				var myPslps = new Pslps();
				ret = myPslps.Delete(Codes);
			}
			else
			{
				this.Message = PslpData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}

		#endregion

		#region 单据配置信息

		/// <summary>
		/// 得到单据的序号
		/// </summary>
		/// <param name="DocCode">int:	单据类型。</param>
		/// <returns>int:	单据的序号。</returns>
		public int GetNextNoByCode(int DocCode)
		{
			return (new BillOfDocuments()).GetNextNoByCode(DocCode);

		}	//End GetNextNoByCode

		/// <summary>
		/// 更新单据的序列号.
		/// </summary>
		/// <param name="DocCode">int:	单据类型。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateNextNoByCode(int DocCode)
		{
			return (new BillOfDocuments()).UpdateNextNoByCode(DocCode);

		}	//End UpdateNextNoByCode

		/// <summary>
		/// 得到指定的单据配置信息实体.
		/// </summary>
		/// <param name="DocCode">int: 单据类型。</param>
		/// <returns>BillOfDocumentData:	单据配置信息实体。</returns>
		public BillOfDocumentData GetDocEntryByCode(int DocCode)
		{
			return (new BillOfDocuments()).GetDocByCode(DocCode);
		}

		#endregion

		#region 采购申请单(RequestOfStock)
		
		/// <summary>
		/// 增加采购申请单。
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddRequestOfStock(RequestOfStockData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oRequestOfStock=new RequestOfStock();

				if(oRequestOfStock.Insert(oEntry)==false)
				{
					Message=oRequestOfStock.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 新建并提交采购申请单。
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentRequestOfStock(RequestOfStockData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oRequestOfStock=new RequestOfStock();

				if(oRequestOfStock.InsertAndPresent(oEntry)==false)
				{
					Message=oRequestOfStock.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单修改。
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateRequestOfStock(RequestOfStockData oEntry)
		{
			bool ret = true;
			if (oEntry!=null)
			{
				var oRequestOfStock=new RequestOfStock();

				if(oRequestOfStock.Update(oEntry)==false)
				{
					Message=oRequestOfStock.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 修改并且提交采购申请单.
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentRequestOfStock(RequestOfStockData oEntry)
		{
			bool ret = true;
			if (oEntry!=null)
			{
				var oRequestOfStock=new RequestOfStock();

				if(oRequestOfStock.UpdateAndPresent(oEntry)==false)
				{
					Message=oRequestOfStock.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteRequestOfStock(int EntryNo)
		{
			bool ret=true;
			
			var oRequestOfStock=new RequestOfStock();

			if(oRequestOfStock.Delete(EntryNo)==false)
			{
				Message=oRequestOfStock.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 提交采购申请单。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <param name="UserLoginId">string:	用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentRequestOfStock(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			
			var oRequestOfStock=new RequestOfStock();

			if(oRequestOfStock.Present(EntryNo,DocStatus.Present,UserLoginId) == false)
			{
				Message = oRequestOfStock.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelRequestOfStock(int EntryNo)
		{
			bool ret = true;
			
			var oRequestOfStock = new RequestOfStock();
			if(oRequestOfStock.Cancel(EntryNo,DocStatus.Cancel) == false)
			{
				Message = oRequestOfStock.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <param name="UserLoginID">string:	操作人.</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelRequestOfStock(int EntryNo,string UserLoginID)
		{
			bool ret = true;
			
			var oRequestOfStock = new RequestOfStock();
			if(oRequestOfStock.Cancel(EntryNo,DocStatus.Cancel,UserLoginID) == false)
			{
				Message = oRequestOfStock.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单部门审批。
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditRequestOfStock(RequestOfStockData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oRequestOfStock=new RequestOfStock();

				if(oRequestOfStock.FirstAudit(oEntry)==false)
				{
					Message=oRequestOfStock.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单财务审批。
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditRequestOfStock(RequestOfStockData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oRequestOfStock=new RequestOfStock();

				if(oRequestOfStock.SecondAudit(oEntry)==false)
				{
					Message=oRequestOfStock.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单厂长审批。
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditRequestOfStock(RequestOfStockData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oRequestOfStock=new RequestOfStock();

				if(oRequestOfStock.ThirdAudit(oEntry)==false)
				{
					Message=oRequestOfStock.Message;
					ret=false;
				}
			}
			return ret;
		}
        /// <summary>
        /// 紧急申购单物资审核。
        /// </summary>
        /// <param name="entryNo">单据号。</param>
        /// <param name="entryState">状态</param>
        /// <param name="audit4">审核结果</param>
        /// <param name="assessor4">审核人</param>
        /// <param name="auditSuggest4">审核意见</param>
        /// <param name="itemCodes">物料编号串</param>
        /// <param name="loginId">审批人登录名</param>
        /// <returns>bool</returns>
        public bool WZAuditRequestOfStock(int entryNo, string entryState,string audit4,string assessor4,string auditSuggest4,string itemCodes, string loginId)
        {
            var oRequestOfStock = new RequestOfStock();

            if (oRequestOfStock.WZAudit(entryNo,entryState,audit4,assessor4,auditSuggest4,itemCodes,loginId) == false)
            {
                Message = oRequestOfStock.Message;
                return false;
            }
            else
            {
                return true;
            }
        }

	    public bool BatchThirdAudit(string TaskIDs,string Assessor,string UserLoginId,string EntryState,string Flag)
		{
			bool ret = false;
			var oROSs = new RequestOfStocks();
			if ( false == oROSs.BatchThirdAudit(TaskIDs,Assessor,UserLoginId,EntryState,Flag))
			{
				Message = oROSs.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 获取所有的采购申请单。
		/// </summary>
		/// <returns>RequestOfStockData:	采购申请单实体。</returns>
		public RequestOfStockData GetRequestOfStockAll()
		{
			var oRequestOfStock=new RequestOfStock();
			return (RequestOfStockData)oRequestOfStock.GetEntryAll();
		}
		/// <summary>
		/// 获取用户默认的系统查询结果。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>RequestOfStockData:	采购申请单实体。</returns>
		public RequestOfStockData GetRequestOfStockAll(string UserLoginId)
		{
			var oRequestOfStocks = new RequestOfStocks();
			return (RequestOfStockData)oRequestOfStocks.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// 获取用户默认的系统查询结果。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>RequestOfStockData:	采购申请单实体。</returns>
        public RequestOfStockData GetRequestOfStockByPerson(string Empcode)
        {
            var oRequestOfStocks = new RequestOfStocks();
            return (RequestOfStockData)oRequestOfStocks.GetEntryByPerson(Empcode);
        }

		/// <summary>
		/// 根据采购申请单流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>RequestOfStockData:	采购申请单数据实体。</returns>
		public RequestOfStockData GetRequestOfStockByEntryNo(int EntryNo)
		{
			var oRequestOfStock = new RequestOfStock();
			return (RequestOfStockData)oRequestOfStock.GetEntryByEntryNo(EntryNo);
		}

        /// <summary>
        /// 根据采购申请单流水号获取单据的申请理由代码
        /// </summary>
        /// <param name="EntryNo"></param>
        /// <returns></returns>
        public string GetReqReasonCode(string EntryNo)
        {
            try
            {
                var oRequestOfStock = GetRequestOfStockByEntryNo(int.Parse(EntryNo));

                if (oRequestOfStock.Tables[RequestOfStockData.PROS_TABLE].Rows.Count > 0)
                {
                    return
                        oRequestOfStock.Tables[RequestOfStockData.PROS_TABLE].Rows[0][
                            RequestOfStockData.REQREASONCODE_FIELD].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {

                return "";
            }
           
        }
        
        /// <summary>
        /// 根据采购申请单流水号获取单据的申请理由代码
        /// </summary>
        /// <param name="EntryNo"></param>
        /// <returns></returns>
        public string GetReqReasonCodeByBREntryNo(string EntryNo,string strSerialNo)
        {
            try
            {
                string strBRValue = "";
                var tmpValue = GetPOByEntryNo(int.Parse(EntryNo));

                for (int i = 0; i < tmpValue.Tables[PurchaseOrderData.PORD_TABLE].Rows.Count; i++)
                {
                    if(tmpValue.Tables[PurchaseOrderData.PORD_TABLE].Rows[i]["SerialNo"].ToString() == strSerialNo)
                    {
                        strBRValue = tmpValue.Tables[PurchaseOrderData.PORD_TABLE].Rows[i]["SourceEntry"].ToString();
                        break;
                    }
                }
               

                if (strBRValue != "")
                    return GetReqReasonCode(strBRValue);
                else
                {
                    return "";
                }
            }
            catch
            {

                return "";
            }

        }

		/// <summary>
		/// 根据采购申请单编号获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>RequestOfStockData:	采购申请单数据实体。</returns>
		public RequestOfStockData GetRequestOfStockByEntryCode(string EntryCode)
		{
			var oRequestOfStock = new RequestOfStock();
			return (RequestOfStockData)oRequestOfStock.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// 获取某一个部门的采购申请单。
		/// </summary>
		/// <param name="DeptCode">string:	部门编号。</param>
		/// <returns>RequestOfStockData:	采购申请单数据实体。</returns>
		public RequestOfStockData GetRequestOfStockByDept(string DeptCode)
		{
			var oRequestOfStock = new RequestOfStock();
			return (RequestOfStockData)oRequestOfStock.GetEntryByDept(DeptCode);
		}
        /// <summary>
        /// 获取紧急申购单的用途编号。
        /// </summary>
        /// <param name="entryNo">紧急申购单号。</param>
        /// <param name="serialNo">序号。</param>
        /// <returns>用途编号。</returns>
        public string GetROS_ReqReasonCode(int entryNo, int serialNo)
        {
            return new RequestOfStocks().GetReqReasonCode(entryNo, serialNo);
        }
		#endregion

		#region IPMRPSystem 成员
		/// <summary>
		/// 物料需求单的增加。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddPMRP(PMRPData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPMRP = new PMRP();
				ret = oPMRP.Insert(oEntry);
				this.Message=oPMRP.Message;
			}
			else
			{
				this.Message = PMRPData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 物料需求单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentPMRP(PMRPData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPMRP = new PMRP();
				ret = oPMRP.InsertAndPresent(oEntry);
				this.Message=oPMRP.Message;
			}
			else
			{
				this.Message = PMRPData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 物料需求单的修改。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdatePMRP(PMRPData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPMRP = new PMRP();
				ret = oPMRP.Update(oEntry);
				this.Message=oPMRP.Message;
			}
			else
			{
				this.Message = PMRPData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 物料需求单的修改并且提交。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentPMRP(PMRPData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPMRP = new PMRP();
				ret = oPMRP.UpdateAndPresent(oEntry);
				this.Message=oPMRP.Message;
			}
			else
			{
				this.Message = PMRPData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 物料需求单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePMRP(int EntryNo)
		{
			bool ret = true;
			
			var oPMRP = new PMRP();
			ret = oPMRP.Delete(EntryNo);
			this.Message=oPMRP.Message;
			
			return ret;
		}
		/// <summary>
		/// 物料需求单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:	用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentPMRP(int EntryNo, string UserLoginId)
		{
			bool ret = true;
						
			var oPMRP = new PMRP();
			ret = oPMRP.Present(EntryNo,DocStatus.Present, UserLoginId);
			this.Message=oPMRP.Message;
			
			return ret;
		}
		/// <summary>
		/// 物料需求单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginID">string:	operator.</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelPMRP(int EntryNo, string UserLoginID)
		{
			bool ret = true;
						
			var oPMRP = new PMRP();
			ret = oPMRP.Cancel(EntryNo,DocStatus.Cancel, UserLoginID);
			this.Message=oPMRP.Message;
			
			return ret;
		}
		/// <summary>
		/// 物料需求单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelPMRP(int EntryNo)
		{
			bool ret = true;
						
			var oPMRP = new PMRP();
			ret = oPMRP.Cancel(EntryNo,DocStatus.Cancel);
			this.Message=oPMRP.Message;
			
			return ret;
		}

        public bool IsAuditDept(string strEmpCode, int EntryNo)
        {
            var oPMRP = new PMRP();
            return oPMRP.IsAuditDept(strEmpCode, EntryNo);
        }
		/// <summary>
		/// 物料需求单的部门审批。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditPMRP(PMRPData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPMRP = new PMRP();
				ret = oPMRP.FirstAudit(oEntry);
				this.Message=oPMRP.Message;
			}
			else
			{
				this.Message = PMRPData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 物料需求单的财务审批。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditPMRP(PMRPData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPMRP = new PMRP();
				ret = oPMRP.SecondAudit(oEntry);
				this.Message=oPMRP.Message;
			}
			else
			{
				this.Message = PMRPData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 物料需求单的厂长审批。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditPMRP(PMRPData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPMRP = new PMRP();
				ret = oPMRP.ThirdAudit(oEntry);
				this.Message=oPMRP.Message;
			}
			else
			{
				this.Message = PMRPData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 获取所有物料需求单。
		/// </summary>
		/// <returns>PMRPData:	单据实体。</returns>
		public PMRPData GetPMRPAll()
		{
			var oPMRP = new PMRP();
			return (PMRPData)oPMRP.GetEntryAll();
		}
        /// <summary>
        /// 根据用户获取单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>PMRPData:	单据实体。</returns>
        public PMRPData GetPMRPAll(string UserLoginId)
        {
            var oPMRPs = new PMRPs();
            return (PMRPData)oPMRPs.GetEntryAll(UserLoginId);
        }

		/// <summary>
		/// 根据用户获取单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>PMRPData:	单据实体。</returns>
		public PMRPData GetPMRPByPerson(string EmpCode)
		{
			var oPMRPs = new PMRPs();
            return (PMRPData)oPMRPs.GetEntryByPerson(EmpCode);
		}
		/// <summary>
		/// 根据流水号获取物料需求单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>PMRPData:	单据实体。</returns>
		public PMRPData GetPMRPByEntryNo(int EntryNo)
		{
			var oPMRP = new PMRP();
			return (PMRPData)oPMRP.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// 根据编号获取物料需求单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>PMRPData:	单据实体。</returns>
		public PMRPData GetPMRPByEntryCode(string EntryCode)
		{
			var oPMRP = new PMRP();
			return (PMRPData)oPMRP.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// 根据制单部门编号获取物料需求单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PMRPData:	单据实体。</returns>
		public PMRPData GetPMRPByDept(string DeptCode)
		{
			var oPMRP = new PMRP();
			return (PMRPData)oPMRP.GetEntryByDept(DeptCode);
		}

		#endregion

		#region IPOSystem 成员
		/// <summary>
		/// 采购订单的增加。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddPO(PurchaseOrderData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.Insert(oEntry);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentPO(PurchaseOrderData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.InsertAndPresent(oEntry);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单的修改。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdatePO(PurchaseOrderData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.Update(oEntry);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单的修改并且提交。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentPO(PurchaseOrderData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.UpdateAndPresent(oEntry);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePO(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.Delete(EntryNo);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentPO(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.Present(EntryNo, DocStatus.Assigned,UserLoginId);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelPO(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.Cancel(EntryNo, DocStatus.Cancel);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购订单作废。
		/// </summary>
		/// <param name="EntryNo">int:	流水号。</param>
		/// <param name="UserLoginID">string:	用户。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelPO(int EntryNo, string UserLoginID)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.Cancel(EntryNo, DocStatus.Cancel,UserLoginID);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单的部门审批。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditPO(PurchaseOrderData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.FirstAudit(oEntry);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单的财务审批。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditPO(PurchaseOrderData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.SecondAudit(oEntry);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单的厂长审批。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditPO(PurchaseOrderData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.ThirdAudit(oEntry);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 获取所有采购订单。
		/// </summary>
		/// <returns>PurchaseOrderData:	采购订单实体。</returns>
		public PurchaseOrderData GetPOAll()
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryAll();
		}
		/// <summary>
		/// 获取针对液铝的还处于执行中的订单清单。
		/// </summary>
		/// <returns>PurchaseOrderData:	采购订单实体。</returns>
		public PurchaseOrderData GetYLPOInExec()
		{
			return (PurchaseOrderData)new PurchaseOrders().GetYLExecOrder();
		}
		/// <summary>
		/// 根据指定用户获取所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>PurchaseOrderData:	采购订单实体。</returns>
		public PurchaseOrderData GetPOAll(string UserLoginId)
		{
			var oPurchaseOrders = new PurchaseOrders();
			return (PurchaseOrderData)oPurchaseOrders.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// 根据指定用户获指定用户取所有单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>PurchaseOrderData:	采购订单实体。</returns>
        public PurchaseOrderData GetPOByPerson(string EmpCode)
        {
            var oPurchaseOrders = new PurchaseOrders();
            return (PurchaseOrderData)oPurchaseOrders.GetEntryByPerson(EmpCode);
        }

        

		/// <summary>
		/// 根据采购订单流水号获取采购订单。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <returns>PurchaseOrderData:	采购订单实体。</returns>
		public PurchaseOrderData GetPOByEntryNo(int EntryNo)
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryByEntryNo(EntryNo);
		}

        /// <summary>
        /// 根据采购订单流水号获取采购撤消单。
        /// </summary>
        /// <param name="EntryNo">int:	采购单流水号。</param>
        /// <returns>PurchaseOrderData:	采购撤消单实体。</returns>
        public PurchaseOrderData GetPORepealEntryNo(int EntryNo)
        {
            var oPurchaseOrder = new PurchaseOrder();
            return (PurchaseOrderData)oPurchaseOrder.GetPORepealEntryNo(EntryNo);
        }
		/// <summary>
		/// 根据采购订单流水号和物料编号获取采购订单。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <returns>PurchaseOrderData:	采购订单实体。</returns>
		public PurchaseOrderData GetPOByEntryNo(int EntryNo, string ItemCode)
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryByEntryNoAndItemCode(EntryNo, ItemCode);
		}
		/// <summary>
		/// 根据采购订单编号获取采购订单。
		/// </summary>
		/// <param name="EntryCode">string:	采购订单编号。</param>
		/// <returns>PurchaseOrderData:	采购订单实体。</returns>
		public PurchaseOrderData GetPOByEntryCode(string EntryCode)
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryByEntryCode(EntryCode);
		}

		/// <summary>
		/// 根据制单部门编号获取采购订单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PurchaseOrderData:	采购订单实体。</returns>
		public PurchaseOrderData GetPOByDept(string DeptCode)
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// 获取所有的采购订单的数据来源。
		/// </summary>
		/// <returns>POSData:	采购订单的数据来源数据实体。</returns>
		public POSData GetPOSAll(string UserLoginId)
		{
			PurchaseOrder oPurchaseOrder = new PurchaseOrder();
			return oPurchaseOrder.GetPosAll(UserLoginId);
		}
		/// <summary>
		/// 采购订单采购确认或拒绝。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="EntryState">string:	单据状态。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AffirmPO(int EntryNo,string EntryState, string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				var oPurchaseOrder = new PurchaseOrder();
				ret = oPurchaseOrder.Affirm(EntryNo,EntryState,UserLoginId);
				this.Message = oPurchaseOrder.Message;
			}
			else
			{
				this.Message = PurchaseOrderData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		public POSData GetPOSByPKIDs(string PKIDs)
		{
			POSData d;
			var oPurchaseOrder = new PurchaseOrder();
			d=oPurchaseOrder.GetPOSByPKIDs(PKIDs);
			return d;
		}
        /// <summary>
        /// 获取采购订单的用途编号。
        /// </summary>
        /// <param name="entryNo">采购订单号。</param>
        /// <param name="serialNo">序号。</param>
        /// <returns>用途编号。</returns>
        public string GetPO_ReqReasonCode(int entryNo, int serialNo)
        {
            return new PurchaseOrders().GetReqReasonCode(entryNo, serialNo);       
        }
		#endregion

		#region IPPSystem 成员
		/// <summary>
		/// 采购计划的插入。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddPP(PurchasePlanData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.Insert(oEntry);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划的新建并且提交。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentPP(PurchasePlanData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.InsertAndPresent(oEntry);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划的修改。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdatePP(PurchasePlanData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.Update(oEntry);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划的修改并且提交。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentPP(PurchasePlanData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.UpdateAndPresent(oEntry);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePP(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo > 0)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.Delete(EntryNo);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划提交。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentPP(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo > 0)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.Present(EntryNo,DocStatus.Present, UserLoginId);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelPP(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo > 0)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.Cancel(EntryNo,DocStatus.Cancel);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <param name="UserLoginID">string:	操作人。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelPP(int EntryNo, string UserLoginID)
		{
			bool ret = true;
			
			if (EntryNo > 0)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.Cancel(EntryNo,DocStatus.Cancel,UserLoginID);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划部门审批。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditPP(PurchasePlanData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.FirstAudit(oEntry);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划财务审批。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditPP(PurchasePlanData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.SecondAudit(oEntry);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划厂长审批。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditPP(PurchasePlanData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPurchasePlan = new PurchasePlan();
				ret = oPurchasePlan.ThirdAudit(oEntry);
				this.Message = oPurchasePlan.Message;
			}
			else
			{
				this.Message = PurchasePlanData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 获取所有采购计划。
		/// </summary>
		/// <returns>PurchasePlanData:	采购计划数据实体。</returns>
		public PurchasePlanData GetPPAll()
		{
			var oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetEntryAll();
		}
		/// <summary>
		/// 根据用户返回所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>PurchasePlanData:	采购计划数据实体。</returns>
		public PurchasePlanData GetPPAll(string UserLoginId)
		{
			var oPurchasePlans = new PurchasePlans();
			return (PurchasePlanData)oPurchasePlans.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// 根据用户返回本人所有单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>PurchasePlanData:	采购计划数据实体。</returns>
        public PurchasePlanData GetPPByPerson(string EmpCode)
        {
            var oPurchasePlans = new PurchasePlans();
            return (PurchasePlanData)oPurchasePlans.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// 根据采购计划流水号获取采购计划。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>PurchasePlanData:	采购计划数据实体。</returns>
		public PurchasePlanData GetPPByEntryNo(int EntryNo)
		{
			PurchasePlan oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// 根据采购计划流水号，获取除零以外的计划内容。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>PurchasePlanData:	采购计划实体。</returns>
		public PurchasePlanData GetPPByEntryNoExceptZero(int EntryNo)
		{
			var oPurchasePlans = new PurchasePlans();
			return (PurchasePlanData)oPurchasePlans.GetEntryByEntryNoExceptZero(EntryNo);
		}
		/// <summary>
		/// 获取根据部门分组求和的采购计划内容。(移动平台用)
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>PurchasePlanData:	采购计划实体。</returns>
		public PurchasePlanData GetPPByEntryNoGroupByDep(int EntryNo)
		{
			var oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetPPByEntryNoGroupByDep(EntryNo);
		}
		/// <summary>
		/// 根据采购计划编号获取采购计划。
		/// </summary>
		/// <param name="EntryCode">string:	采购计划编号。</param>
		/// <returns>PurchasePlanData:	采购计划数据实体。</returns>
		public PurchasePlanData GetPPByEntryCode(string EntryCode)
		{
			var oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// 根据制单部门编号获取采购计划。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PurchasePlanData:	采购计划数据实体。</returns>
		public PurchasePlanData GetPPByDept(string DeptCode)
		{
			var oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// 获取采购计划数据源。
		/// </summary>
		/// <returns>PPSData:	采购计划数据源数据实体。</returns>
		public PPSData GetPPSAll(string UserLoginId)
		{
			var oPurchasePlan = new PurchasePlan();
			return oPurchasePlan.GetPPSAll(UserLoginId);
		}
        /// <summary>
        /// 获取采购计划内容项的用途编号。
        /// </summary>
        /// <param name="entryNo">采购计划号。</param>
        /// <param name="serialNo">序号。</param>
        /// <returns></returns>
        public string GetPP_ReqReasonCode(int entryNo, int serialNo)
        {
            return new PurchasePlans().GetReqReasonCode(entryNo, serialNo);
        }
		#endregion

		#region 收料单(IBRSystem成员)
		
		/// <summary>
		/// 增加收料单。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddBR(BillOfReceiveData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oBillOfReceive=new BillOfReceive();

				if(oBillOfReceive.Insert(oEntry)==false)
				{
					Message=oBillOfReceive.Message;
					ret=false;
				}
			}
			return ret;
		}	
		/// <summary>
		/// 增加并且提交收料单。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentBR(BillOfReceiveData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oBillOfReceive=new BillOfReceive();

				if(oBillOfReceive.InsertAndPresent(oEntry)==false)
				{
					Message=oBillOfReceive.Message;
					ret=false;
				}
			}
			return ret;
		}	
		/// <summary>
		/// 收料单修改。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateBR(BillOfReceiveData oEntry)
		{
			bool ret = true;
			if (oEntry!=null)
			{
				var oBillOfReceive=new BillOfReceive();

				if(oBillOfReceive.Update(oEntry)==false)
				{
					Message=oBillOfReceive.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 收料单修改并且提交。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentBR(BillOfReceiveData oEntry)
		{
			bool ret = true;
			if (oEntry!=null)
			{
				var oBillOfReceive=new BillOfReceive();

				if(oBillOfReceive.UpdateAndPresent(oEntry)==false)
				{
					Message=oBillOfReceive.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 收料单收料。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ReceiveBR(BillOfReceiveData oEntry)
		{
			bool ret = true;
			if (oEntry!=null)
			{
				var oBillOfReceive=new BillOfReceive();

				if(oBillOfReceive.Receive(oEntry)==false)
				{
					Message=oBillOfReceive.Message;
					ret=false;
				}
			}
			return ret;
		}
        public bool RejectBR(int entryNo,string loginName)
        {
            bool ret = true;
            
            var oBillOfReceives = new BillOfReceives();

            if (oBillOfReceives.Reject(entryNo,loginName) == false)
            {
                Message = oBillOfReceives.Message;
                ret = false;
            }
            
            return ret;
        }
		/// <summary>
		/// 收料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteBR(int EntryNo)
		{
			bool ret=true;
			
			var oBillOfReceive=new BillOfReceive();

			if(oBillOfReceive.Delete(EntryNo)==false)
			{
				Message=oBillOfReceive.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 提交收料单。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentBR(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			
			var oBillOfReceive=new BillOfReceive();

			if(oBillOfReceive.Present(EntryNo,DocStatus.Present, UserLoginId) == false)
			{
				Message = oBillOfReceive.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelBR(int EntryNo)
		{
			bool ret = true;
			
			var oBillOfReceive = new BillOfReceive();
			if(oBillOfReceive.Cancel(EntryNo,DocStatus.Cancel) == false)
			{
				Message = oBillOfReceive.Message;
				ret = false;
			}
			return ret;
		}
		
		/// <summary>
		/// 收料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <param name="UserLoginID">string:	操作人登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelBR(int EntryNo, string UserLoginID)
		{
			bool ret = true;
			
			var oBillOfReceive = new BillOfReceive();
			if(oBillOfReceive.Cancel(EntryNo,DocStatus.Cancel,UserLoginID) == false)
			{
				Message = oBillOfReceive.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单付款操作。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <param name="UserLoginID">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PayBR(int EntryNo, string UserLoginID)
		{
			bool ret = true;

			var oBillOfReceive = new BillOfReceive();
			if(oBillOfReceive.Pay(EntryNo, DocStatus.Pay, UserLoginID) == false)
			{
				Message = oBillOfReceive.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单部门审批。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditBR(BillOfReceiveData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oBillOfReceive=new BillOfReceive();

				if(oBillOfReceive.FirstAudit(oEntry)==false)
				{
					Message=oBillOfReceive.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 收料单财务审批。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditBR(BillOfReceiveData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oBillOfReceive=new BillOfReceive();

				if(oBillOfReceive.SecondAudit(oEntry)==false)
				{
					Message=oBillOfReceive.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 收料单厂长审批。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditBR(BillOfReceiveData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oBillOfReceive=new BillOfReceive();

				if(oBillOfReceive.ThirdAudit(oEntry)==false)
				{
					Message=oBillOfReceive.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 获取所有的收料单。
		/// </summary>
		/// <returns>BillOfReceiveData:	收料单实体。</returns>
		public BillOfReceiveData GetBRAll()
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryAll();
		}
		/// <summary>
		/// 根据用户获取所有收料单列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>BillOfReceiveData:	收料单实体。</returns>
		public BillOfReceiveData GetBRAll(string UserLoginId)
		{
			var oBillOfReceives = new BillOfReceives();
			return (BillOfReceiveData)oBillOfReceives.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// 根据用户获取所有收料单列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>BillOfReceiveData:	收料单实体。</returns>
        public BillOfReceiveData GetEntryByPerson(string EmpCode)
        {
            var oBillOfReceives = new BillOfReceives();
            return (BillOfReceiveData)oBillOfReceives.GetEntryByPerson(EmpCode);
        }

		/// <summary>
		/// 根据状态获取收料单清单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>BillOfReceiveData:	收料单实体。</returns>
		public BillOfReceiveData GetBRByState(string EntryState)
		{
			var oBillOfReceives = new BillOfReceives();
			return (BillOfReceiveData)oBillOfReceives.GetEntryByState(EntryState);
		}
		/// <summary>
		/// 根据收料单流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>BillOfReceiveData:	收料单数据实体。</returns>
        public BillOfReceiveData GetBRByEntryNo(int EntryNo)
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryByEntryNo(EntryNo);
		}

       

        /// <summary>
        /// 根据收料单流水号获取单据。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>BillOfReceiveData:	收料单数据实体。</returns>
        public BillOfReceiveData GetBROldByEntryNo(int EntryNo)
        {
            var oBillOfReceive = new BillOfReceive();
            return (BillOfReceiveData)oBillOfReceive.GetEntryOldByEntryNo(EntryNo);
        }

        /// <summary>
        /// 根据收料单流水号获取单据。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>BillOfReceiveData:	收料单数据实体。</returns>
        public bool BRInvoiceUpdate(int EntryNo, string strInvoiceNo)
        {
            var oBillOfReceive = new BillOfReceive();
            return oBillOfReceive.BRInvoiceUpdate(EntryNo, strInvoiceNo);
        }

		/// <summary>
		/// 根据发票号和物料编号获取采购收料单信息.
		/// </summary>
		/// <param name="InvoiceNo">string:	发票号.</param>
		/// <param name="ItemCode">string:	物料编号.</param>
		/// <returns>BillOfReceiveData:	收料单数据实体。</returns>
		public BillOfReceiveData GetBRByInvoiceNoAndItemCode(string InvoiceNo, string ItemCode)
		{
			var oBillOfReceives = new BillOfReceives();
			return (BillOfReceiveData)oBillOfReceives.GetEntryByInvoiceNoAndItemCode(InvoiceNo, ItemCode);
		}
		/// <summary>
		/// 根据指定收料单流水号获取红字的初始信息。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>BillOfReceiveData:	收料单数据实体。</returns>
		public BillOfReceiveData GetBRRedByEntryNo(int EntryNo)
		{
			var oBillOfReceives = new BillOfReceives();
			return (BillOfReceiveData)oBillOfReceives.GetEntryRedByEntryNo(EntryNo)	;
		}
		/// <summary>
		/// 根据收料单编号获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>BillOfReceiveData:	收料单数据实体。</returns>
		public BillOfReceiveData GetBRByEntryCode(string EntryCode)
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// 收料模式下，根据收料单编号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>BillOfReceiveData:	收料单数据实体。</returns>
		public BillOfReceiveData GetBRByEntryNoInMode(int EntryNo)
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryByEntryNoInMode(EntryNo);
		}
		/// <summary>
		/// 获取某一个部门的收料单。
		/// </summary>
		/// <param name="DeptCode">string:	部门编号。</param>
		/// <returns>BillOfReceiveData:	收料单数据实体。</returns>
		public BillOfReceiveData GetBRByDept(string DeptCode)
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryByDept(DeptCode);
		}

		/// <summary>
		/// 根据供应商代码获得源数据。
		/// </summary>
		/// <param name="PrvCode"></param>
		/// <returns></returns>
		public PBSData GetPBSAEntryByPrvCode(string PrvCode)
		{
			var oBillOfReceive = new BillOfReceive();
			return (PBSData)oBillOfReceive.GetEntryByPrvCode(PrvCode);

		}

		/// <summary>
		/// 根据pkid列表获得明细。
		/// </summary>
		/// <param name="List"></param>
		/// <returns></returns>
		public PBSDData GetPBSDByList(string List)
		{
			var oBillOfReceive = new BillOfReceive();
			return (PBSDData)oBillOfReceive.GetPBSDByList(List);
		}

        /// <summary>
        /// 获取采购收料单的用途编号。
        /// </summary>
        /// <param name="entryNo">采购收料单号。</param>
        /// <param name="serialNo">序号。</param>
        /// <returns>用途编号。</returns>
        public string GetBor_ReqReasonCode(int entryNo, int serialNo)
        {
            return new BillOfReceives().GetReqReasonCode(entryNo, serialNo);
        }
		#endregion

		#region 收料验收单(IPCBRSystem 成员)
		/// <summary>
		/// 收料验收单的增加。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddPCBR(PCBRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPCBR = new PCBR();
				ret = oPCBR.Insert(oEntry);
				this.Message=oPCBR.Message;
			}
			else
			{
				this.Message = PCBRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentPCBR(PCBRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPCBR = new PCBR();
				ret = oPCBR.InsertAndPresent(oEntry);
				this.Message=oPCBR.Message;
			}
			else
			{
				this.Message = PCBRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单的修改。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdatePCBR(PCBRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPCBR = new PCBR();
				ret = oPCBR.Update(oEntry);
				this.Message=oPCBR.Message;
			}
			else
			{
				this.Message = PCBRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单的修改并且马上提交。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentPCBR(PCBRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPCBR = new PCBR();
				ret = oPCBR.UpdateAndPresent(oEntry);
				this.Message=oPCBR.Message;
			}
			else
			{
				this.Message = PCBRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePCBR(int EntryNo)
		{
			bool ret = true;
			
			var oPCBR = new PCBR();
			ret = oPCBR.Delete(EntryNo);
			this.Message=oPCBR.Message;
			
			return ret;
		}
		/// <summary>
		/// 收料验收单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentPCBR(int EntryNo, string UserLoginId)
		{
			bool ret = true;
						
			var oPCBR = new PCBR();
			ret = oPCBR.Present(EntryNo,DocStatus.Present, UserLoginId);
			this.Message=oPCBR.Message;
			
			return ret;
		}
		/// <summary>
		/// 收料验收单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelPCBR(int EntryNo)
		{
			bool ret = true;
						
			var oPCBR = new PCBR();
			ret = oPCBR.Cancel(EntryNo,DocStatus.Cancel);
			this.Message=oPCBR.Message;
			
			return ret;
		}
		/// <summary>
		/// 收料验收单的部门审批。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditPCBR(PCBRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPCBR = new PCBR();
				ret = oPCBR.FirstAudit(oEntry);
				this.Message=oPCBR.Message;
			}
			else
			{
				this.Message = PCBRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单的财务审批。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditPCBR(PCBRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPCBR = new PCBR();
				ret = oPCBR.SecondAudit(oEntry);
				this.Message=oPCBR.Message;
			}
			else
			{
				this.Message = PCBRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单的厂长审批。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditPCBR(PCBRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				var oPCBR = new PCBR();
				ret = oPCBR.ThirdAudit(oEntry);
				this.Message=oPCBR.Message;
			}
			else
			{
				this.Message = PCBRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 获取所有收料验收单。
		/// </summary>
		/// <returns>PCBRData:	单据实体。</returns>
		public PCBRData GetPCBRAll()
		{
			var oPCBR = new PCBR();
			return (PCBRData)oPCBR.GetEntryAll();
		}
		/// <summary>
		/// 根据流水号获取收料验收单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>PCBRData:	单据实体。</returns>
		public PCBRData GetPCBRByEntryNo(int EntryNo)
		{
			var oPCBR = new PCBR();
			return (PCBRData)oPCBR.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// 根据编号获取收料验收单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>PCBRData:	单据实体。</returns>
		public PCBRData GetPCBRByEntryCode(string EntryCode)
		{
			var oPCBR = new PCBR();
			return (PCBRData)oPCBR.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// 根据制单部门编号获取收料验收单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PCBRData:	单据实体。</returns>
		public PCBRData GetPCBRByDept(string DeptCode)
		{
			var oPCBR = new PCBR();
			return (PCBRData)oPCBR.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// 根据供应商获取已收料的收料单。
		/// </summary>
		/// <param name="PrvCode">string:	供应商编号。</param>
		/// <returns>CBRSData：	验收单来源实体。</returns>
		public CBRSData GetCBRSByPrvCode(string PrvCode)
		{
			var oPCBR = new PCBR();
			return oPCBR.GetCBRSByPrvCode(PrvCode); 
		}
		/// <summary>
		/// 根据供应商在指定的日期范围内获取已收料的收料单。
		/// </summary>
		/// <param name="PrvCode">string:	供应商编号。</param>
		/// <param name="StartDate">DateTime:	开始日期。</param>
		/// <param name="EndDate">DateTime:	结束日期。</param>
		/// <returns>CBRSData：	验收单来源实体。</returns>
		public CBRSData GetCBRSByPrvCodeAndDate(string PrvCode, DateTime StartDate, DateTime EndDate)
		{
			var oPCBR = new PCBR();
			return oPCBR.GetCBRSByPrvCodeAndDate(PrvCode, StartDate, EndDate); 
		}
		#endregion

		#region 检验项
		public CITMData GetCITMByRepCode(int RepCode)
		{
			var oCITM = new CITM();
			return (CITMData)oCITM.GetByRepCode(RepCode);
		}
		#endregion

		#region 采购退料单(IPRTVSystem成员)
		
		/// <summary>
		/// 增加采购退料单。
		/// </summary>
		/// <param name="oEntry">PRTVData:	采购退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddPRTV(PRTVData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oPRTV=new PRTV();

				if(oPRTV.Insert(oEntry)==false)
				{
					Message=oPRTV.Message;
					ret=false;
				}
			}
			return ret;
		}



		/// <summary>
		/// 新建并且提交采购退货单。
		/// </summary>
		/// <param name="oEntry">PRTVData：	采购退货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentPRTV(PRTVData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oPRTV=new PRTV();

				if(oPRTV.InsertAndPresent(oEntry)==false)
				{
					Message=oPRTV.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单修改。
		/// </summary>
		/// <param name="oEntry">PRTVData:	采购退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdatePRTV(PRTVData oEntry,string strEmpCode)
		{
			bool ret = true;
			if (oEntry!=null)
			{
				var oPRTV=new PRTV();

                if (oPRTV.Update(oEntry, strEmpCode) == false)
				{
					Message=oPRTV.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 修改并且提交采购退货单。
		/// </summary>
		/// <param name="oEntry">PRTVData：	采购退货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
        public bool UpdateAndPresentPRTV(PRTVData oEntry, string strEmpCode)
		{
			bool ret = true;
			if (oEntry!=null)
			{
				var oPRTV=new PRTV();

                if (oPRTV.UpdateAndPresent(oEntry, strEmpCode) == false)
				{
					Message=oPRTV.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购退料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePRTV(int EntryNo,string strEmpCode)
		{
			bool ret=true;
			
			var oPRTV=new PRTV();

            if (oPRTV.Delete(EntryNo, strEmpCode) == false)
			{
				Message=oPRTV.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 提交采购退料单。
		/// </summary>
		/// <param name="EntryNo">int:	采购退料单流水号。</param>
		/// <param name="UserLoginId">string:	操作人登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentPRTV(int EntryNo, string UserLoginId,string strEmpCode)
		{
			bool ret = true;
			
			var oPRTV=new PRTV();

            if (oPRTV.Present(EntryNo, DocStatus.Present, UserLoginId, strEmpCode) == false)
			{
				Message = oPRTV.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购退料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
        //public bool CancelPRTV(int EntryNo,string strEmpCode)
        //{
        //    bool ret = true;
			
        //    PRTV oPRTV = new PRTV();
        //    if(oPRTV.Cancel(EntryNo,DocStatus.Cancel,) == false)
        //    {
        //        Message = oPRTV.Message;
        //        ret = false;
        //    }
        //    return ret;
        //}
		/// <summary>
		/// 作废采购退货单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:	操作人登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
        public bool CancelPRTV(int EntryNo, string UserLoginId, string strEmpCode)
		{
			bool ret = true;
			
			var oPRTV = new PRTV();
            if (oPRTV.Cancel(EntryNo, DocStatus.Cancel, UserLoginId, strEmpCode) == false)
			{
				Message = oPRTV.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单部门审批。
		/// </summary>
		/// <param name="oEntry">PRTVData:	采购退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditPRTV(PRTVData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				var oPRTV=new PRTV();

				if(oPRTV.FirstAudit(oEntry)==false)
				{
					Message=oPRTV.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单财务审批。
		/// </summary>
		/// <param name="oEntry">PRTVData:	采购退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditPRTV(PRTVData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				PRTV oPRTV=new PRTV();

				if(oPRTV.SecondAudit(oEntry)==false)
				{
					Message=oPRTV.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单厂长审批。
		/// </summary>
		/// <param name="oEntry">PRTVData:	采购退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditPRTV(PRTVData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				PRTV oPRTV=new PRTV();

				if(oPRTV.ThirdAudit(oEntry)==false)
				{
					Message=oPRTV.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 获取所有的采购退料单。
		/// </summary>
		/// <returns>PRTVData:	采购退料单实体。</returns>
		public PRTVData GetPRTVAll()
		{
			PRTV oPRTV=new PRTV();
			return (PRTVData)oPRTV.GetEntryAll();
		}


        

        /// <summary>
        /// 获取所有的采购退料单。
        /// </summary>
        /// <returns>PRTVData:	采购退料单实体。</returns>
        public PRTVData GetPRTVByPerson(string EmpCode)
        {
            PRTV oPRTV = new PRTV();
            return (PRTVData)oPRTV.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// 根据采购退料单流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>PRTVData:	采购退料单数据实体。</returns>
		public PRTVData GetPRTVByEntryNo(int EntryNo)
		{
			PRTV oPRTV = new PRTV();
			return (PRTVData)oPRTV.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// 在发料模式下根据采购退料单流水号获取单据
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号</param>
		/// <returns>PRTVData:	采购退料单数据实体。</returns>
		public PRTVData GetPRTVByEntryNoInMode(int EntryNo)
		{
			PRTV oPRTV = new PRTV();
			return (PRTVData)oPRTV.GetEntryByEntryNoInMode(EntryNo);
		}
		/// <summary>
		/// 根据采购退料单编号获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>PRTVData:	采购退料单数据实体。</returns>
		public PRTVData GetPRTVByEntryCode(string EntryCode)
		{
			PRTV oPRTV = new PRTV();
			return (PRTVData)oPRTV.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// 获取某一个部门的采购退料单。
		/// </summary>
		/// <param name="DeptCode">string:	部门编号。</param>
		/// <returns>PRTVData:	采购退料单数据实体。</returns>
		public PRTVData GetPRTVByDept(string DeptCode)
		{
			PRTV oPRTV = new PRTV();
			return (PRTVData)oPRTV.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// 根据PKID获取数据源。
		/// </summary>
		/// <param name="PKID"></param>
		/// <returns></returns>
		public RTVSData GetRTVSByPKID(string PKID)
		{
			PRTV oPRTV = new PRTV();
			return (RTVSData)oPRTV.GetRTVSByPKID(PKID);
		}

		/// <summary>
		/// 根据采购收料单获取退货单内容。
		/// </summary>
		/// <param name="PKID">string:	采购收料单ID。</param>
		/// <returns>RTVSDetailData：	采购退货单明细内容实体。</returns>
		public RTVSDetailData GetRTVSDetailByPKID(string PKID)
		{
			PRTV oPRTV = new PRTV();
			return (RTVSDetailData)oPRTV.GetRTVSDetailByPKID(PKID);
		}

		#endregion

		#region 通用查询
		/// <summary>
		/// 采购申请单通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>RequestOfStockData:	采购申请单数据实体。</returns>
		public RequestOfStockData GetRequestOfStockBySQL(string Sql_Statement)
		{
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
			return oRequestOfStocks.GetEntryBySQL(Sql_Statement);
		}
		
		public RequestOfStockData GetRequestOfStockByDeptAndAuthorAndAuditResult(string AuthorDept,string AuthorCode,int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
			return oRequestOfStocks.GetEntryByDeptAndAuthorAndAuditResult(AuthorDept, AuthorCode, AuditResult,StartDate,EndDate);
		}
		/// <summary>
		/// 物料需求单通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>PMRPData:	物料需求单数据实体。</returns>
		public PMRPData GetPMRPBySQL(string Sql_Statement)
		{
			PMRPs oPMRPs = new PMRPs();
			return oPMRPs.GetEntryBySQL(Sql_Statement);
		}
		public PMRPData GetPMRPByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			PMRPs oPMRPs = new PMRPs();
			return oPMRPs.GetEntryByDeptAndAuthorAndAuditResult(AuthorDept, AuthorCode, AuditResult,StartDate,EndDate);
		}
		/// <summary>
		/// 采购计划通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>PurchasePlanData:	采购计划数据实体。</returns>
		public PurchasePlanData GetPPBySQL(string Sql_Statement)
		{
			PurchasePlans oPurchasePlans = new PurchasePlans();
			return oPurchasePlans.GetEntryBySQL(Sql_Statement);
		}
		/// <summary>
		/// 采购订单通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>PurchaseOrderData:	采购订单数据实体.</returns>
		public PurchaseOrderData GetPOBySQl(string Sql_Statement)
		{
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			return oPurchaseOrders.GetEntryBySQL(Sql_Statement);
		}
		public PurchaseOrderData GetPOByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			return oPurchaseOrders.GetEntryByDeptAndAuthorAndAuditResult(AuthorDept, AuthorCode, AuditResult,StartDate,EndDate);
		}
		/// <summary>
		/// 收料单通用查询.
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>BillOfReceiveData:	收料单数据实体。</returns>
		public BillOfReceiveData GetBRBySQL(string Sql_Statement)
		{
			BillOfReceives oBillOfReceives = new BillOfReceives();
			return oBillOfReceives.GetEntryBySQL(Sql_Statement);
		}
		public BillOfReceiveData GetBRByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			BillOfReceives oBillOfReceives = new BillOfReceives();
			return oBillOfReceives.GetEntryByDeptAndAuthorAndAuditResult(AuthorDept, AuthorCode, AuditResult,StartDate,EndDate);
		}
		/// <summary>
		/// 采购退货单通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>PRTVData:	采购退货单数据实体。</returns>
		public PRTVData GetPRTVBySQL(string Sql_Statement)
		{
			PRTVs oPRTVs = new PRTVs();
			return oPRTVs.GetEntryBySQL(Sql_Statement);
		}
		public PRTVData getPRTVByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate, DateTime EndDate)
		{
			PRTVs oPRTVs = new PRTVs();
			return oPRTVs.GetEntryByDeptAndAuthorAndAuditResult(AuthorDept, AuthorCode, AuditResult,StartDate,EndDate);
		}
		/// <summary>
		/// 采购撤销单通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句。</param>
		/// <returns>CancelData: 采购撤销单数据实体。</returns>
		public CancelData GetCancelBySQL(string Sql_Statement)
		{
			Cancels oCancels = new Cancels();
			return oCancels.GetEntryBySQL(Sql_Statement);
		}
		/// <summary>
		/// 供应商通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>PPRNData:	供应商数据实体。</returns>
		public PPRNData GetPPRNBySQL(string Sql_Statement)
		{
			PPRNs myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNBySQL(Sql_Statement);
		}
		/// <summary>
		/// 批次进货单通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>PPRNData:	供应商数据实体。</returns>
		public PBRBData GetPBRBBySQL(string Sql_Statement)
		{
			PBRBs myPBRBs = new PBRBs();
			return myPBRBs.GetEntryBySQL(Sql_Statement);
		}
		#endregion

		#region IPBRBSystem 成员
		/// <summary>
		/// 
		/// </summary>
		/// <param name="oEntry"></param>
		/// <returns></returns>
		public bool AddPBRB(PBRBData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				PBRB oPBRB=new PBRB();

				if(oPBRB.Insert(oEntry)==false)
				{
					Message=oPBRB.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="oEntry"></param>
		/// <returns></returns>
		public bool AddAndPresentPBRB(PBRBData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				PBRB oPBRB=new PBRB();

				if(oPBRB.InsertAndPresent(oEntry)==false)
				{
					Message=oPBRB.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="oEntry"></param>
		/// <returns></returns>
		public bool UpdatePBRB(PBRBData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				PBRB oPBRB=new PBRB();

				if(oPBRB.Update(oEntry)==false)
				{
					Message=oPBRB.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="oEntry"></param>
		/// <returns></returns>
		public bool UpdateAndPresentPBRB(PBRBData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				PBRB oPBRB=new PBRB();

				if(oPBRB.UpdateAndPresent(oEntry)==false)
				{
					Message=oPBRB.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="EntryNo"></param>
		/// <returns></returns>
		public bool DeletePBRB(int EntryNo)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			PBRB oPBRB=new PBRB();

			if(oPBRB.Delete(EntryNo)==false)
			{
				Message=oPBRB.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="EntryNo"></param>
		/// <param name="UserLoginId"></param>
		/// <returns></returns>
		public bool PresentPBRB(int EntryNo, string UserLoginId)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			PBRB oPBRB=new PBRB();

			if(oPBRB.Present(EntryNo, DocStatus.Present, UserLoginId)==false)
			{
				Message=oPBRB.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="EntryNo"></param>
		/// <param name="UserLoginId"></param>
		/// <returns></returns>
		public bool CancelPBRB(int EntryNo, string UserLoginId)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			PBRB oPBRB=new PBRB();

			if(oPBRB.Cancel(EntryNo,DocStatus.Cancel, UserLoginId) == false)
			{
				Message=oPBRB.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 批次进货单财务审批
		/// </summary>
		/// <param name="oEntry"></param>
		/// <returns></returns>
		public bool FirstAuditPBRB(PBRBData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry!=null)
			{
				PBRB oPBRB=new PBRB();

				if(oPBRB.FirstAudit(oEntry)==false)
				{
					Message=oPBRB.Message;
					ret=false;
				}
			}
			return ret;
		}

		/// <summary>
		/// 批次进货单财务审批
		/// </summary>
		/// <param name="oEntry">PBRBData:	批次进货单.</param>
		/// <returns></returns>
		public bool SecondAuditPBRB(PBRBData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry != null)
			{
				PBRB oPBRB = new PBRB();

				if(oPBRB.SecondAudit(oEntry) == false)
				{
					Message = oPBRB.Message;
					ret = false;
				}
			}
			return ret;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="oEntry"></param>
		/// <returns></returns>
		public bool ThirdAuditPBRB(PBRBData oEntry)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oEntry != null)
			{
				PBRB oPBRB = new PBRB();

				if(oPBRB.ThirdAudit(oEntry) == false)
				{
					Message = oPBRB.Message;
					ret = false;
				}
			}
			return ret;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="UserLoginId"></param>
		/// <returns></returns>
		public PBRBData GetPBRBAll(string UserLoginId)
		{
			PBRBData oPBRBData;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryAll(UserLoginId);
			return oPBRBData;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="EntryNo"></param>
		/// <returns></returns>
		public PBRBData GetPBRBByEntryNo(int EntryNo)
		{
			PBRBData oPBRBData;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			return oPBRBData;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="EntryCode"></param>
		/// <returns></returns>
		public PBRBData GetPBRBByEntryCode(string EntryCode)
		{
			PBRBData oPBRBData;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryCode(EntryCode);
			return oPBRBData;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="DeptCode"></param>
		/// <returns></returns>
		public PBRBData GetPBRBByDept(string DeptCode)
		{
			PBRBData oPBRBData;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByDept(DeptCode);
			return oPBRBData;
		}

		/// <summary>
		/// 获取当前可用批号。
		/// </summary>
		/// <param name="YYMM">string:	当前的年月字符串。</param>
		/// <returns>string:	批号。</returns>
		public string GetPBRBBatchCode(string YYMM)
		{
			return new PBRBs().GetBatchCode(YYMM);
		}
		#endregion

		#region 待收料清单
		/// <summary>
		/// 获取所有待收料清单。
		/// </summary>
		/// <returns>InData：	待收料清单实体。</returns>
		public InData GetInDataAll()
		{
			return new INs().GetInDataAll();
		}
		/// <summary>
		/// 根据仓库管理员获取待收料清单。
		/// </summary>
		/// <param name="UserCode">string:	仓库管理员编号。</param>
		/// <returns>InData:	待收料单据清单实体。</returns>
		public InData GetInDataByStoManager(string UserCode)
		{
			return new INs().GetInDataByStoManager(UserCode);
		}
		/// <summary>
		/// 根据管理员获取待收料的单据清单。
		/// </summary>
		/// <param name="UserCode">string:	用户编号。</param>
		/// <returns>InData:	待收料单据清单实体。</returns>
		public InData GetInDataByStoManagerWithTODO(string UserCode)
		{
			return new INs().GetInDataByStoManagerAndEntryState(UserCode, "T");
		}
		#endregion

		#region IPAYSystem 成员

		public bool Insert(PPAYData oEntry)
		{
			bool ret = false;
			PPAYs oPPAYs = new PPAYs();
			ret = oPPAYs.Insert(oEntry);
			this.Message = oPPAYs.Message;
			return ret;
		}
		public bool Update(PPAYData oEntry)
		{
			bool ret = false;
			PPAYs oPPAYs = new PPAYs();
			ret = oPPAYs.Update(oEntry);
			this.Message = oPPAYs.Message;
			return ret;
		}
		public bool Present(PPAYData oEntry)
		{
			bool ret = false;
			PPAYs oPPAYs = new PPAYs();
			ret = oPPAYs.Present(oEntry);
			this.Message = oPPAYs.Message;
			return ret;
		}
		public bool InsertAndPresent(PPAYData oEntry)
		{
			bool ret = false;
			PPAYs oPPAYs = new PPAYs();
			ret = oPPAYs.InsertAndPresent(oEntry);
			this.Message = oPPAYs.Message;
			return ret;
		}
		public bool UpdateAndPresent(PPAYData oEntry)
		{
			bool ret = false;
			PPAYs oPPAYs = new PPAYs();
			ret = oPPAYs.UpdateAndPresent(oEntry);
			this.Message = oPPAYs.Message;
			return ret;
		}
		public bool Cancel(PPAYData oEntry)
		{
			bool ret = false;
			PPAYs oPPAYs = new PPAYs();
			ret = oPPAYs.Cancel(oEntry);
			this.Message = oPPAYs.Message;
			return ret;
		}

		public bool ThirdAudit(PPAYData oEntry)
		{
			bool ret = false;
			PPAYs oPPAYs = new PPAYs();
			ret = oPPAYs.ThirdAudit(oEntry);
			this.Message = oPPAYs.Message;
			return ret;
		}

		public bool Delete(PPAYData oEntry)
		{
			bool ret = false;
			PPAYs oPPAYs = new PPAYs();
			ret = oPPAYs.Delete(oEntry);
			this.Message = oPPAYs.Message;
			return ret;
		}

		public bool Pay(PPAYData oEntry)
		{
			bool ret = false;
			PPAYs oPPAYs = new PPAYs();
			ret = oPPAYs.PAY(oEntry);
			this.Message = oPPAYs.Message;
			return ret;
		}

		public PPAYData GetPayAll()
		{
			PPAYData oData;
			oData = new PPAYs().GetPAYAll();
			return oData;
		}

        public PPAYData GetPayByDept(string strDeptCode)
        {
            PPAYData oData;
            oData = new PPAYs().GetPAYByDept(strDeptCode);
            return oData;
        }

        public PPAYData GetPayByPerson(string EmpCode)
        {
            PPAYData oData;
            oData = new PPAYs().GetPAYByPerson(EmpCode);
            return oData;
        }

		public PPAYData GetPayByEntryNo(int EntryNo)
		{
			PPAYData oData;
			oData = new PPAYs().GetPAYByEntryNo(EntryNo);
			return oData;
		}
		public PPAYData GetPayByInvoiceNo(string InvoiceNo)
		{
			PPAYData oData;
			oData = new PPAYs().GetPAYByInvoiceNo(InvoiceNo);
			return oData;
		}
		public PPAYData GetPayBySQL(string SQLStatement)
		{
			PPAYData oData;
			oData = new PPAYs().GetEntryBySQL(SQLStatement);
			return oData;
		}
		#endregion

		#region IAudit3System 成员
		/// <summary>
		/// 获取所有待厂长审批的单据的实体。
		/// </summary>
		/// <returns>Audit3Data:	厂长审批的单据.</returns>
		public Audit3Data GetAudit3DataByToAudit(string UserLoginId)
		{
			Audit3s DA = new Audit3s();
			Audit3Data oData;
			oData = DA.GetAudit3DataToAudit(UserLoginId);

			return oData;
		}
		/// <summary>
		/// 根据SQL语句获取厂长审批的单据的实体。
		/// </summary>
		/// <param name="SqL_Statement"></param>
		/// <returns>Audit3Data:	厂长审批的单据.</returns>
		public Audit3Data GetAudit3DataBySQL(string Sql_Statement)
		{
			Audit3s DA = new Audit3s();
			Audit3Data oData;
			oData = DA.GetAudit3DataBySQL(Sql_Statement);
			return oData;
		}

		#endregion

		#region 单据流转信息
		public DocItemRouteData GetDocItemRouteData(int EntryNo,int DocCode,int SerialNo,string ItemCode)
		{
			return new Analysis().Get_DocItemRoute(EntryNo,DocCode,SerialNo,ItemCode);
		}
		#endregion

		#region IPPRCSystem 成员

		public PPRCData GetPPRCAll()
		{
			PPRCs DA = new PPRCs();
			return DA.GetPPRCAll();
		}

		public PPRCData GetPPRCByCode(int Code)
		{
			PPRCs DA = new PPRCs();
			return DA.GetPPRCByCode(Code);
		}

		public bool AddPPRC(PPRCData myPPRCData)
		{
			PPRCs DA = new PPRCs();
			bool ret;
			ret = DA.Add(myPPRCData);
			this.Message = DA.Message;
			return ret;
		}

		public bool UpdatePPRC(PPRCData myPPRCData)
		{
			PPRCs DA = new PPRCs();
			bool ret;
			ret = DA.Update(myPPRCData);
			this.Message = DA.Message;
			return ret;
		}

		public bool DeletePPRC(PPRCData myPPRCData)
		{
			PPRCs DA = new PPRCs();
			bool ret;
			ret = DA.Delete(myPPRCData);
			this.Message = DA.Message;
			return ret;
		}

		#endregion

		#region ICancelSystem 成员
		/// <summary>
		/// 采购撤销单新建。
		/// </summary>
		/// <param name="oEntry">CancelData:	采购撤销单新建。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool AddCancel(CancelData oEntry)
		{
			bool ret=true;
			if (oEntry!=null)
			{
				Cancel oCancel = new Cancel();

				if(oCancel.Insert(oEntry)==false)
				{
					Message=oCancel.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购撤销单修改。
		/// </summary>
		/// <param name="oEntry">CancelData:	采购撤销单实体。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool UpdateCancel(CancelData oEntry)
		{
			bool ret=true;
			if (oEntry!=null)
			{
				Cancel oCancel = new Cancel();

				if(oCancel.Update(oEntry)==false)
				{
					Message=oCancel.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购撤销单新建并且提交。
		/// </summary>
		/// <param name="oEntry">CancelData:	采购撤销单实体。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool AddAndPresentCancel(CancelData oEntry)
		{
			bool ret=true;
			if (oEntry!=null)
			{
				Cancel oCancel = new Cancel();



				if(oCancel.InsertAndPresent(oEntry)==false)
				{
					Message=oCancel.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购撤销单修改并且提交。
		/// </summary>
		/// <param name="oEntry">CancelData:	采购撤销单实体。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool UpdateAndPresentCancel(CancelData oEntry)
		{
			bool ret=true;
			if (oEntry!=null)
			{
				Cancel oCancel = new Cancel();

				if(oCancel.UpdateAndPresent(oEntry)==false)
				{
					Message=oCancel.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购撤销单提交。
		/// </summary>
		/// <param name="EntryNo">int:	采购撤销单编号。</param>
		/// <param name="UserLoginId">string: 用户ID。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool PresentCancel(int EntryNo, string UserLoginId)
		{
			bool ret=true;
			Cancel oCancel = new Cancel();
			if(oCancel.Present(EntryNo,DocStatus.Present, UserLoginId)==false)
			{
				Message=oCancel.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 采购撤销单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购撤销单编号。</param>
		/// <param name="UserLoginId">string: 用户ID。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool CancelCancel(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			Cancels oCancels = new Cancels();


            CancelData canceldata = oCancels.GetEntryByEntryNo(EntryNo);

            if(canceldata.Tables[0].Rows[0]["EntryState"].ToString() == DocStatus.New
                || canceldata.Tables[0].Rows[0]["EntryState"].ToString() == DocStatus.TrdNoPass
            || canceldata.Tables[0].Rows[0]["EntryState"].ToString() == DocStatus.SecNoPass
                || canceldata.Tables[0].Rows[0]["EntryState"].ToString() == DocStatus.FstNoPass)
            {

                if (canceldata.Tables[0].Rows[0]["AuthorLoginID"].ToString() == UserLoginId)
                {
                    if (oCancels.Cancel(EntryNo, DocStatus.Cancel, UserLoginId) == false)
                    {
                        Message = oCancels.Message;
                        ret = false;
                    }
                }
                else
                {
                    Message = "你无权操作！";
                    ret = false;
                }
            }
            else
            {
                Message = "采购撤销单作废的前提是，单据处于新建、审批不通过的状态！";
                ret = false;
            }
			return ret;
		}
		/// <summary>
		/// 采购撤销单删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购撤销单编号。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool DeleteCancel(int EntryNo)
		{
			bool ret = true;
			Cancels oCancels = new Cancels();



			if (oCancels.DeleteEntry(EntryNo)==false)
			{
				Message = oCancels.Message;
				ret = false;
			}
			return ret;
		}

        /// <summary>
        /// 采购撤销单删除。
        /// </summary>
        /// <param name="EntryNo">int:	采购撤销单编号。</param>
        /// <returns>bool:	成功返回True，失败返回false。</returns>
        public bool DeleteCancel(int EntryNo,string strEmpCode)
        {
            bool ret = true;
            Cancels oCancels = new Cancels();


            CancelData canceldata = oCancels.GetEntryByEntryNo(EntryNo);

            if (canceldata.Tables[0].Rows[0]["EntryState"].ToString() == DocStatus.Cancel)
            {

                if (canceldata.Tables[0].Rows[0]["AuthorCode"].ToString() == strEmpCode)
                {
                    if (oCancels.DeleteEntry(EntryNo) == false)
                    {
                        Message = oCancels.Message;
                        ret = false;
                    }
                }
                else
                {
                    Message = "你无权操作！";
                    ret = false;
                }
            }
            else
            {
                Message = "采购撤销单删除的前提是，单据处于作废的状态！";
                ret = false;
            }
            
            return ret;
        }

		/// <summary>
		/// 采购撤销单部门审批。
		/// </summary>
		/// <param name="oEntry">CancelData:	采购撤销单实体。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool FirstAuditCancel(CancelData oEntry)
		{
			bool ret=true;
			if (oEntry!=null)
			{
				Cancel oCancel = new Cancel();

				if(oCancel.FirstAudit(oEntry)==false)
				{
					Message=oCancel.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购撤销单财务审批。
		/// </summary>
		/// <param name="oEntry">CancelData:	采购撤销单实体。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool SecondAuditCacel(CancelData oEntry)
		{
			bool ret=true;
			if (oEntry!=null)
			{
				Cancel oCancel = new Cancel();

				if(oCancel.SecondAudit(oEntry)==false)
				{
					Message=oCancel.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 采购撤销单厂长审批。
		/// </summary>
		/// <param name="oEntry">CancelData:	采购撤销单实体。</param>
		/// <returns>bool:	成功返回True，失败返回false。</returns>
		public bool ThirdAuditCancel(CancelData oEntry)
		{
			bool ret=true;
			if (oEntry!=null)
			{
				Cancel oCancel = new Cancel();

				if(oCancel.ThirdAudit(oEntry)==false)
				{
					Message=oCancel.Message;
					ret=false;
				}
			}
			return ret;
		}
		/// <summary>
		/// 获取所有采购撤销单。
		/// </summary>
		/// <param name="UserLoginID">string:	用户ID。</param>
		/// <returns>CancelData:	采购撤销单实体。</returns>
		public CancelData GetCancelAll(string UserLoginID)
		{
			return new Cancels().GetEntryAll(UserLoginID);
		}

        /// <summary>
        /// 获取所有采购撤销单。
        /// </summary>
        /// <param name="UserLoginID">string:	用户ID。</param>
        /// <returns>CancelData:	采购撤销单实体。</returns>
        public CancelData GetCancelByPerson(string EmpCode)
        {
            return new Cancels().GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// 根据编号获取采购撤销单。
		/// </summary>
		/// <param name="EntryNo">int：	采购撤销单编号。</param>
		/// <returns>CancelData:	采购撤销单实体。</returns>
		public CancelData GetCancelByEntryNo(int EntryNo)
		{
			return new Cancels().GetEntryByEntryNo(EntryNo);
		}

		#endregion
	}
}
