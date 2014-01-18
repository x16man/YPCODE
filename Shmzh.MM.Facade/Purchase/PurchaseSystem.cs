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
	/// PBaseSystem ��ժҪ˵����
	/// </summary>
	public class PurchaseSystem : MarshalByRefObject,IPPRNSystem,IPslpSystem,IPMRPSystem, IPOSystem, IPPSystem, IBRSystem,IPCBRSystem,IPRTVSystem,IPBRBSystem,IPAYSystem,IAudit3System,IPPRCSystem   ,ICancelSystem
	{
		#region ��Ա����
		
		#endregion

		#region ����
        public string Message { get; set; }
		#endregion

		#region IPPRNSystem ��Ա
		/// <summary>
		/// ������й�Ӧ��/�ͻ�.
		/// </summary>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNAll()
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNAll();
		}
		/// <summary>
		/// ���ݹ�Ӧ��/�ͻ���Ż�ȡ��Ӧ��/�ͻ���Ϣ��
		/// </summary>
		/// <param name="Code">string:	��Ӧ��/�ͻ���š�</param>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNByCode(string Code)
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByCode(Code);
		}
		/// <summary>
		/// ��ȡ��ǰ��Ӧ�̱�ŵĹ�Ӧ�̡�
		/// </summary>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNWithMaxCode()
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNWithMaxCode();
		}
		/// <summary>
		/// ���ݹ�Ӧ��/�ͻ��������ƻ�ù�Ӧ��/�ͻ���Ϣ��
		/// </summary>
		/// <param name="CNName">string:	��Ӧ��/�ͻ��������ơ�</param>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNByCNName(string CNName)
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByCNName(CNName);
		}
		/// <summary>
		/// ���ݹ�Ӧ��/�ͻ�Ӣ�����ƻ�ù�Ӧ��/�ͻ���Ϣ��
		/// </summary>
		/// <param name="ENName">string:	��Ӧ��/�ͻ�Ӣ�����ơ�</param>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNByENName(string ENName)
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByENName(ENName);
		}
		/// <summary>
		/// �������״̬���Ѻ�׼����ù�Ӧ��/�ͻ���Ϣ��
		/// </summary>
		/// <param name="Type">string:	���</param>
		/// <param name="Status">string:	״̬��</param>
		/// <param name="Approve">string:	�Ѻ�׼��</param>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNByTypeAndStatusAndApprove(string Type, string Status, string Approve)
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByTypeAndStatusAndApprove(Type,Status,Approve);
		}
		/// <summary>
		/// ��ȡ����λ��Ϣ��
		/// </summary>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNSelf()
		{
			var myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNSelf();
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� ���ӡ�
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool AddPPRN(PPRNData myPPRNData)
		{
			bool ret = true;
			// ������飬���ǲ��ǿն���
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
		/// ��Ӧ��/�ͻ� �޸ġ�
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdatePPRN(PPRNData myPPRNData)
		{
			bool ret = true;
			// ������飬���ǲ��ǿն���
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
		/// ��Ӧ��/�ͻ� ɾ����
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeletePPRN(PPRNData myPPRNData)
		{
			bool ret = true;
			// ������飬���ǲ��ǿն���
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
		/// ���ݴ���Ĺ�Ӧ�̴����ַ������й�Ӧ��ɾ����
		/// </summary>
		/// <param name="Codes">string:	��Ӧ�̴��봮��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeletePPRN(string Codes)
		{
			bool ret = true;
			// ������飬���ǲ��ǿն���
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

		#region IPslpSystem ��Ա
		/// <summary>
		/// ��ȡȫ���ɹ�Ա��
		/// </summary>
		/// <returns>PslpData:	�ɹ�Ա����ʵ�塣</returns>
		PslpData IPslpSystem.GetPslpAll()
		{
			var myPlsps = new Pslps();
			return myPlsps.GetPslpAll();
		}
		/// <summary>
		/// ���ݲɹ�Ա�����ȡ�ɹ�Ա��
		/// </summary>
		/// <param name="Code">string:	�ɹ�Ա���롣</param>
		/// <returns>PslpData:	�ɹ�Ա����ʵ�塣</returns>
		PslpData IPslpSystem.GetPslpByCode(string Code)
		{
			var myPlsps = new Pslps();
			return myPlsps.GetPslpByCode(Code);
		}
		/// <summary>
		/// �ɹ�Ա���ӡ�
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ�Ա�޸ġ�
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ�Ա������¼ɾ����
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ�Ա������¼ɾ����
		/// </summary>
		/// <param name="Codes">string:	�ɹ�Ա���봮��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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

		#region ����������Ϣ

		/// <summary>
		/// �õ����ݵ����
		/// </summary>
		/// <param name="DocCode">int:	�������͡�</param>
		/// <returns>int:	���ݵ���š�</returns>
		public int GetNextNoByCode(int DocCode)
		{
			return (new BillOfDocuments()).GetNextNoByCode(DocCode);

		}	//End GetNextNoByCode

		/// <summary>
		/// ���µ��ݵ����к�.
		/// </summary>
		/// <param name="DocCode">int:	�������͡�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateNextNoByCode(int DocCode)
		{
			return (new BillOfDocuments()).UpdateNextNoByCode(DocCode);

		}	//End UpdateNextNoByCode

		/// <summary>
		/// �õ�ָ���ĵ���������Ϣʵ��.
		/// </summary>
		/// <param name="DocCode">int: �������͡�</param>
		/// <returns>BillOfDocumentData:	����������Ϣʵ�塣</returns>
		public BillOfDocumentData GetDocEntryByCode(int DocCode)
		{
			return (new BillOfDocuments()).GetDocByCode(DocCode);
		}

		#endregion

		#region �ɹ����뵥(RequestOfStock)
		
		/// <summary>
		/// ���Ӳɹ����뵥��
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �½����ύ�ɹ����뵥��
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����뵥�޸ġ�
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �޸Ĳ����ύ�ɹ����뵥.
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����뵥��ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ύ�ɹ����뵥��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <param name="UserLoginID">string:	������.</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����뵥����������
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����뵥����������
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����뵥����������
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
        /// �����깺��������ˡ�
        /// </summary>
        /// <param name="entryNo">���ݺš�</param>
        /// <param name="entryState">״̬</param>
        /// <param name="audit4">��˽��</param>
        /// <param name="assessor4">�����</param>
        /// <param name="auditSuggest4">������</param>
        /// <param name="itemCodes">���ϱ�Ŵ�</param>
        /// <param name="loginId">�����˵�¼��</param>
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
		/// ��ȡ���еĲɹ����뵥��
		/// </summary>
		/// <returns>RequestOfStockData:	�ɹ����뵥ʵ�塣</returns>
		public RequestOfStockData GetRequestOfStockAll()
		{
			var oRequestOfStock=new RequestOfStock();
			return (RequestOfStockData)oRequestOfStock.GetEntryAll();
		}
		/// <summary>
		/// ��ȡ�û�Ĭ�ϵ�ϵͳ��ѯ�����
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>RequestOfStockData:	�ɹ����뵥ʵ�塣</returns>
		public RequestOfStockData GetRequestOfStockAll(string UserLoginId)
		{
			var oRequestOfStocks = new RequestOfStocks();
			return (RequestOfStockData)oRequestOfStocks.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// ��ȡ�û�Ĭ�ϵ�ϵͳ��ѯ�����
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>RequestOfStockData:	�ɹ����뵥ʵ�塣</returns>
        public RequestOfStockData GetRequestOfStockByPerson(string Empcode)
        {
            var oRequestOfStocks = new RequestOfStocks();
            return (RequestOfStockData)oRequestOfStocks.GetEntryByPerson(Empcode);
        }

		/// <summary>
		/// ���ݲɹ����뵥��ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>RequestOfStockData:	�ɹ����뵥����ʵ�塣</returns>
		public RequestOfStockData GetRequestOfStockByEntryNo(int EntryNo)
		{
			var oRequestOfStock = new RequestOfStock();
			return (RequestOfStockData)oRequestOfStock.GetEntryByEntryNo(EntryNo);
		}

        /// <summary>
        /// ���ݲɹ����뵥��ˮ�Ż�ȡ���ݵ��������ɴ���
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
        /// ���ݲɹ����뵥��ˮ�Ż�ȡ���ݵ��������ɴ���
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
		/// ���ݲɹ����뵥��Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>RequestOfStockData:	�ɹ����뵥����ʵ�塣</returns>
		public RequestOfStockData GetRequestOfStockByEntryCode(string EntryCode)
		{
			var oRequestOfStock = new RequestOfStock();
			return (RequestOfStockData)oRequestOfStock.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// ��ȡĳһ�����ŵĲɹ����뵥��
		/// </summary>
		/// <param name="DeptCode">string:	���ű�š�</param>
		/// <returns>RequestOfStockData:	�ɹ����뵥����ʵ�塣</returns>
		public RequestOfStockData GetRequestOfStockByDept(string DeptCode)
		{
			var oRequestOfStock = new RequestOfStock();
			return (RequestOfStockData)oRequestOfStock.GetEntryByDept(DeptCode);
		}
        /// <summary>
        /// ��ȡ�����깺������;��š�
        /// </summary>
        /// <param name="entryNo">�����깺���š�</param>
        /// <param name="serialNo">��š�</param>
        /// <returns>��;��š�</returns>
        public string GetROS_ReqReasonCode(int entryNo, int serialNo)
        {
            return new RequestOfStocks().GetReqReasonCode(entryNo, serialNo);
        }
		#endregion

		#region IPMRPSystem ��Ա
		/// <summary>
		/// �������󵥵����ӡ�
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������󵥵����Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������󵥵��޸ġ�
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������󵥵��޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������󵥵�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeletePMRP(int EntryNo)
		{
			bool ret = true;
			
			var oPMRP = new PMRP();
			ret = oPMRP.Delete(EntryNo);
			this.Message=oPMRP.Message;
			
			return ret;
		}
		/// <summary>
		/// �������󵥵��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool PresentPMRP(int EntryNo, string UserLoginId)
		{
			bool ret = true;
						
			var oPMRP = new PMRP();
			ret = oPMRP.Present(EntryNo,DocStatus.Present, UserLoginId);
			this.Message=oPMRP.Message;
			
			return ret;
		}
		/// <summary>
		/// �������󵥵����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginID">string:	operator.</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool CancelPMRP(int EntryNo, string UserLoginID)
		{
			bool ret = true;
						
			var oPMRP = new PMRP();
			ret = oPMRP.Cancel(EntryNo,DocStatus.Cancel, UserLoginID);
			this.Message=oPMRP.Message;
			
			return ret;
		}
		/// <summary>
		/// �������󵥵����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������󵥵Ĳ���������
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������󵥵Ĳ���������
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������󵥵ĳ���������
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ�����������󵥡�
		/// </summary>
		/// <returns>PMRPData:	����ʵ�塣</returns>
		public PMRPData GetPMRPAll()
		{
			var oPMRP = new PMRP();
			return (PMRPData)oPMRP.GetEntryAll();
		}
        /// <summary>
        /// �����û���ȡ�����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>PMRPData:	����ʵ�塣</returns>
        public PMRPData GetPMRPAll(string UserLoginId)
        {
            var oPMRPs = new PMRPs();
            return (PMRPData)oPMRPs.GetEntryAll(UserLoginId);
        }

		/// <summary>
		/// �����û���ȡ�����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>PMRPData:	����ʵ�塣</returns>
		public PMRPData GetPMRPByPerson(string EmpCode)
		{
			var oPMRPs = new PMRPs();
            return (PMRPData)oPMRPs.GetEntryByPerson(EmpCode);
		}
		/// <summary>
		/// ������ˮ�Ż�ȡ�������󵥡�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>PMRPData:	����ʵ�塣</returns>
		public PMRPData GetPMRPByEntryNo(int EntryNo)
		{
			var oPMRP = new PMRP();
			return (PMRPData)oPMRP.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// ���ݱ�Ż�ȡ�������󵥡�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>PMRPData:	����ʵ�塣</returns>
		public PMRPData GetPMRPByEntryCode(string EntryCode)
		{
			var oPMRP = new PMRP();
			return (PMRPData)oPMRP.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�������󵥡�
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PMRPData:	����ʵ�塣</returns>
		public PMRPData GetPMRPByDept(string DeptCode)
		{
			var oPMRP = new PMRP();
			return (PMRPData)oPMRP.GetEntryByDept(DeptCode);
		}

		#endregion

		#region IPOSystem ��Ա
		/// <summary>
		/// �ɹ����������ӡ�
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����������Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��������޸ġ�
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��������޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ�������ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��������ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	��ˮ�š�</param>
		/// <param name="UserLoginID">string:	�û���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ������Ĳ���������
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ������Ĳ���������
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ������ĳ���������
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ���вɹ�������
		/// </summary>
		/// <returns>PurchaseOrderData:	�ɹ�����ʵ�塣</returns>
		public PurchaseOrderData GetPOAll()
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryAll();
		}
		/// <summary>
		/// ��ȡ���Һ���Ļ�����ִ���еĶ����嵥��
		/// </summary>
		/// <returns>PurchaseOrderData:	�ɹ�����ʵ�塣</returns>
		public PurchaseOrderData GetYLPOInExec()
		{
			return (PurchaseOrderData)new PurchaseOrders().GetYLExecOrder();
		}
		/// <summary>
		/// ����ָ���û���ȡ���е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>PurchaseOrderData:	�ɹ�����ʵ�塣</returns>
		public PurchaseOrderData GetPOAll(string UserLoginId)
		{
			var oPurchaseOrders = new PurchaseOrders();
			return (PurchaseOrderData)oPurchaseOrders.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// ����ָ���û���ָ���û�ȡ���е����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>PurchaseOrderData:	�ɹ�����ʵ�塣</returns>
        public PurchaseOrderData GetPOByPerson(string EmpCode)
        {
            var oPurchaseOrders = new PurchaseOrders();
            return (PurchaseOrderData)oPurchaseOrders.GetEntryByPerson(EmpCode);
        }

        

		/// <summary>
		/// ���ݲɹ�������ˮ�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <returns>PurchaseOrderData:	�ɹ�����ʵ�塣</returns>
		public PurchaseOrderData GetPOByEntryNo(int EntryNo)
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryByEntryNo(EntryNo);
		}

        /// <summary>
        /// ���ݲɹ�������ˮ�Ż�ȡ�ɹ���������
        /// </summary>
        /// <param name="EntryNo">int:	�ɹ�����ˮ�š�</param>
        /// <returns>PurchaseOrderData:	�ɹ�������ʵ�塣</returns>
        public PurchaseOrderData GetPORepealEntryNo(int EntryNo)
        {
            var oPurchaseOrder = new PurchaseOrder();
            return (PurchaseOrderData)oPurchaseOrder.GetPORepealEntryNo(EntryNo);
        }
		/// <summary>
		/// ���ݲɹ�������ˮ�ź����ϱ�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <returns>PurchaseOrderData:	�ɹ�����ʵ�塣</returns>
		public PurchaseOrderData GetPOByEntryNo(int EntryNo, string ItemCode)
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryByEntryNoAndItemCode(EntryNo, ItemCode);
		}
		/// <summary>
		/// ���ݲɹ�������Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryCode">string:	�ɹ�������š�</param>
		/// <returns>PurchaseOrderData:	�ɹ�����ʵ�塣</returns>
		public PurchaseOrderData GetPOByEntryCode(string EntryCode)
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryByEntryCode(EntryCode);
		}

		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PurchaseOrderData:	�ɹ�����ʵ�塣</returns>
		public PurchaseOrderData GetPOByDept(string DeptCode)
		{
			var oPurchaseOrder = new PurchaseOrder();
			return (PurchaseOrderData)oPurchaseOrder.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// ��ȡ���еĲɹ�������������Դ��
		/// </summary>
		/// <returns>POSData:	�ɹ�������������Դ����ʵ�塣</returns>
		public POSData GetPOSAll(string UserLoginId)
		{
			PurchaseOrder oPurchaseOrder = new PurchaseOrder();
			return oPurchaseOrder.GetPosAll(UserLoginId);
		}
		/// <summary>
		/// �ɹ������ɹ�ȷ�ϻ�ܾ���
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="EntryState">string:	����״̬��</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
        /// ��ȡ�ɹ���������;��š�
        /// </summary>
        /// <param name="entryNo">�ɹ������š�</param>
        /// <param name="serialNo">��š�</param>
        /// <returns>��;��š�</returns>
        public string GetPO_ReqReasonCode(int entryNo, int serialNo)
        {
            return new PurchaseOrders().GetReqReasonCode(entryNo, serialNo);       
        }
		#endregion

		#region IPPSystem ��Ա
		/// <summary>
		/// �ɹ��ƻ��Ĳ��롣
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ����½������ύ��
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ����޸ġ�
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ����޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <param name="UserLoginID">string:	�����ˡ�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ�����������
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ�����������
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ��ƻ�����������
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ���вɹ��ƻ���
		/// </summary>
		/// <returns>PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</returns>
		public PurchasePlanData GetPPAll()
		{
			var oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetEntryAll();
		}
		/// <summary>
		/// �����û��������е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</returns>
		public PurchasePlanData GetPPAll(string UserLoginId)
		{
			var oPurchasePlans = new PurchasePlans();
			return (PurchasePlanData)oPurchasePlans.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// �����û����ر������е����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</returns>
        public PurchasePlanData GetPPByPerson(string EmpCode)
        {
            var oPurchasePlans = new PurchasePlans();
            return (PurchasePlanData)oPurchasePlans.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// ���ݲɹ��ƻ���ˮ�Ż�ȡ�ɹ��ƻ���
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</returns>
		public PurchasePlanData GetPPByEntryNo(int EntryNo)
		{
			PurchasePlan oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// ���ݲɹ��ƻ���ˮ�ţ���ȡ��������ļƻ����ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>PurchasePlanData:	�ɹ��ƻ�ʵ�塣</returns>
		public PurchasePlanData GetPPByEntryNoExceptZero(int EntryNo)
		{
			var oPurchasePlans = new PurchasePlans();
			return (PurchasePlanData)oPurchasePlans.GetEntryByEntryNoExceptZero(EntryNo);
		}
		/// <summary>
		/// ��ȡ���ݲ��ŷ�����͵Ĳɹ��ƻ����ݡ�(�ƶ�ƽ̨��)
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>PurchasePlanData:	�ɹ��ƻ�ʵ�塣</returns>
		public PurchasePlanData GetPPByEntryNoGroupByDep(int EntryNo)
		{
			var oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetPPByEntryNoGroupByDep(EntryNo);
		}
		/// <summary>
		/// ���ݲɹ��ƻ���Ż�ȡ�ɹ��ƻ���
		/// </summary>
		/// <param name="EntryCode">string:	�ɹ��ƻ���š�</param>
		/// <returns>PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</returns>
		public PurchasePlanData GetPPByEntryCode(string EntryCode)
		{
			var oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�ɹ��ƻ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</returns>
		public PurchasePlanData GetPPByDept(string DeptCode)
		{
			var oPurchasePlan = new PurchasePlan();
			return (PurchasePlanData)oPurchasePlan.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// ��ȡ�ɹ��ƻ�����Դ��
		/// </summary>
		/// <returns>PPSData:	�ɹ��ƻ�����Դ����ʵ�塣</returns>
		public PPSData GetPPSAll(string UserLoginId)
		{
			var oPurchasePlan = new PurchasePlan();
			return oPurchasePlan.GetPPSAll(UserLoginId);
		}
        /// <summary>
        /// ��ȡ�ɹ��ƻ����������;��š�
        /// </summary>
        /// <param name="entryNo">�ɹ��ƻ��š�</param>
        /// <param name="serialNo">��š�</param>
        /// <returns></returns>
        public string GetPP_ReqReasonCode(int entryNo, int serialNo)
        {
            return new PurchasePlans().GetReqReasonCode(entryNo, serialNo);
        }
		#endregion

		#region ���ϵ�(IBRSystem��Ա)
		
		/// <summary>
		/// �������ϵ���
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���Ӳ����ύ���ϵ���
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ��޸ġ�
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ��޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ύ���ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="UserLoginID">string:	�����˵�¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ����������
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="UserLoginID">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ�����������
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ�����������
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ�����������
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ���е����ϵ���
		/// </summary>
		/// <returns>BillOfReceiveData:	���ϵ�ʵ�塣</returns>
		public BillOfReceiveData GetBRAll()
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryAll();
		}
		/// <summary>
		/// �����û���ȡ�������ϵ��б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>BillOfReceiveData:	���ϵ�ʵ�塣</returns>
		public BillOfReceiveData GetBRAll(string UserLoginId)
		{
			var oBillOfReceives = new BillOfReceives();
			return (BillOfReceiveData)oBillOfReceives.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// �����û���ȡ�������ϵ��б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>BillOfReceiveData:	���ϵ�ʵ�塣</returns>
        public BillOfReceiveData GetEntryByPerson(string EmpCode)
        {
            var oBillOfReceives = new BillOfReceives();
            return (BillOfReceiveData)oBillOfReceives.GetEntryByPerson(EmpCode);
        }

		/// <summary>
		/// ����״̬��ȡ���ϵ��嵥��
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>BillOfReceiveData:	���ϵ�ʵ�塣</returns>
		public BillOfReceiveData GetBRByState(string EntryState)
		{
			var oBillOfReceives = new BillOfReceives();
			return (BillOfReceiveData)oBillOfReceives.GetEntryByState(EntryState);
		}
		/// <summary>
		/// �������ϵ���ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
        public BillOfReceiveData GetBRByEntryNo(int EntryNo)
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryByEntryNo(EntryNo);
		}

       

        /// <summary>
        /// �������ϵ���ˮ�Ż�ȡ���ݡ�
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
        public BillOfReceiveData GetBROldByEntryNo(int EntryNo)
        {
            var oBillOfReceive = new BillOfReceive();
            return (BillOfReceiveData)oBillOfReceive.GetEntryOldByEntryNo(EntryNo);
        }

        /// <summary>
        /// �������ϵ���ˮ�Ż�ȡ���ݡ�
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
        public bool BRInvoiceUpdate(int EntryNo, string strInvoiceNo)
        {
            var oBillOfReceive = new BillOfReceive();
            return oBillOfReceive.BRInvoiceUpdate(EntryNo, strInvoiceNo);
        }

		/// <summary>
		/// ���ݷ�Ʊ�ź����ϱ�Ż�ȡ�ɹ����ϵ���Ϣ.
		/// </summary>
		/// <param name="InvoiceNo">string:	��Ʊ��.</param>
		/// <param name="ItemCode">string:	���ϱ��.</param>
		/// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
		public BillOfReceiveData GetBRByInvoiceNoAndItemCode(string InvoiceNo, string ItemCode)
		{
			var oBillOfReceives = new BillOfReceives();
			return (BillOfReceiveData)oBillOfReceives.GetEntryByInvoiceNoAndItemCode(InvoiceNo, ItemCode);
		}
		/// <summary>
		/// ����ָ�����ϵ���ˮ�Ż�ȡ���ֵĳ�ʼ��Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
		public BillOfReceiveData GetBRRedByEntryNo(int EntryNo)
		{
			var oBillOfReceives = new BillOfReceives();
			return (BillOfReceiveData)oBillOfReceives.GetEntryRedByEntryNo(EntryNo)	;
		}
		/// <summary>
		/// �������ϵ���Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
		public BillOfReceiveData GetBRByEntryCode(string EntryCode)
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// ����ģʽ�£��������ϵ���Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
		public BillOfReceiveData GetBRByEntryNoInMode(int EntryNo)
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryByEntryNoInMode(EntryNo);
		}
		/// <summary>
		/// ��ȡĳһ�����ŵ����ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	���ű�š�</param>
		/// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
		public BillOfReceiveData GetBRByDept(string DeptCode)
		{
			var oBillOfReceive = new BillOfReceive();
			return (BillOfReceiveData)oBillOfReceive.GetEntryByDept(DeptCode);
		}

		/// <summary>
		/// ���ݹ�Ӧ�̴�����Դ���ݡ�
		/// </summary>
		/// <param name="PrvCode"></param>
		/// <returns></returns>
		public PBSData GetPBSAEntryByPrvCode(string PrvCode)
		{
			var oBillOfReceive = new BillOfReceive();
			return (PBSData)oBillOfReceive.GetEntryByPrvCode(PrvCode);

		}

		/// <summary>
		/// ����pkid�б�����ϸ��
		/// </summary>
		/// <param name="List"></param>
		/// <returns></returns>
		public PBSDData GetPBSDByList(string List)
		{
			var oBillOfReceive = new BillOfReceive();
			return (PBSDData)oBillOfReceive.GetPBSDByList(List);
		}

        /// <summary>
        /// ��ȡ�ɹ����ϵ�����;��š�
        /// </summary>
        /// <param name="entryNo">�ɹ����ϵ��š�</param>
        /// <param name="serialNo">��š�</param>
        /// <returns>��;��š�</returns>
        public string GetBor_ReqReasonCode(int entryNo, int serialNo)
        {
            return new BillOfReceives().GetReqReasonCode(entryNo, serialNo);
        }
		#endregion

		#region �������յ�(IPCBRSystem ��Ա)
		/// <summary>
		/// �������յ������ӡ�
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������յ������Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������յ����޸ġ�
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������յ����޸Ĳ��������ύ��
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������յ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeletePCBR(int EntryNo)
		{
			bool ret = true;
			
			var oPCBR = new PCBR();
			ret = oPCBR.Delete(EntryNo);
			this.Message=oPCBR.Message;
			
			return ret;
		}
		/// <summary>
		/// �������յ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool PresentPCBR(int EntryNo, string UserLoginId)
		{
			bool ret = true;
						
			var oPCBR = new PCBR();
			ret = oPCBR.Present(EntryNo,DocStatus.Present, UserLoginId);
			this.Message=oPCBR.Message;
			
			return ret;
		}
		/// <summary>
		/// �������յ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool CancelPCBR(int EntryNo)
		{
			bool ret = true;
						
			var oPCBR = new PCBR();
			ret = oPCBR.Cancel(EntryNo,DocStatus.Cancel);
			this.Message=oPCBR.Message;
			
			return ret;
		}
		/// <summary>
		/// �������յ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������յ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������յ��ĳ���������
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ�����������յ���
		/// </summary>
		/// <returns>PCBRData:	����ʵ�塣</returns>
		public PCBRData GetPCBRAll()
		{
			var oPCBR = new PCBR();
			return (PCBRData)oPCBR.GetEntryAll();
		}
		/// <summary>
		/// ������ˮ�Ż�ȡ�������յ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>PCBRData:	����ʵ�塣</returns>
		public PCBRData GetPCBRByEntryNo(int EntryNo)
		{
			var oPCBR = new PCBR();
			return (PCBRData)oPCBR.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// ���ݱ�Ż�ȡ�������յ���
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>PCBRData:	����ʵ�塣</returns>
		public PCBRData GetPCBRByEntryCode(string EntryCode)
		{
			var oPCBR = new PCBR();
			return (PCBRData)oPCBR.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�������յ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PCBRData:	����ʵ�塣</returns>
		public PCBRData GetPCBRByDept(string DeptCode)
		{
			var oPCBR = new PCBR();
			return (PCBRData)oPCBR.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// ���ݹ�Ӧ�̻�ȡ�����ϵ����ϵ���
		/// </summary>
		/// <param name="PrvCode">string:	��Ӧ�̱�š�</param>
		/// <returns>CBRSData��	���յ���Դʵ�塣</returns>
		public CBRSData GetCBRSByPrvCode(string PrvCode)
		{
			var oPCBR = new PCBR();
			return oPCBR.GetCBRSByPrvCode(PrvCode); 
		}
		/// <summary>
		/// ���ݹ�Ӧ����ָ�������ڷ�Χ�ڻ�ȡ�����ϵ����ϵ���
		/// </summary>
		/// <param name="PrvCode">string:	��Ӧ�̱�š�</param>
		/// <param name="StartDate">DateTime:	��ʼ���ڡ�</param>
		/// <param name="EndDate">DateTime:	�������ڡ�</param>
		/// <returns>CBRSData��	���յ���Դʵ�塣</returns>
		public CBRSData GetCBRSByPrvCodeAndDate(string PrvCode, DateTime StartDate, DateTime EndDate)
		{
			var oPCBR = new PCBR();
			return oPCBR.GetCBRSByPrvCodeAndDate(PrvCode, StartDate, EndDate); 
		}
		#endregion

		#region ������
		public CITMData GetCITMByRepCode(int RepCode)
		{
			var oCITM = new CITM();
			return (CITMData)oCITM.GetByRepCode(RepCode);
		}
		#endregion

		#region �ɹ����ϵ�(IPRTVSystem��Ա)
		
		/// <summary>
		/// ���Ӳɹ����ϵ���
		/// </summary>
		/// <param name="oEntry">PRTVData:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �½������ύ�ɹ��˻�����
		/// </summary>
		/// <param name="oEntry">PRTVData��	�ɹ��˻���ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����ϵ��޸ġ�
		/// </summary>
		/// <param name="oEntry">PRTVData:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �޸Ĳ����ύ�ɹ��˻�����
		/// </summary>
		/// <param name="oEntry">PRTVData��	�ɹ��˻���ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ύ�ɹ����ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <param name="UserLoginId">string:	�����˵�¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϲɹ��˻�����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:	�����˵�¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����ϵ�����������
		/// </summary>
		/// <param name="oEntry">PRTVData:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����ϵ�����������
		/// </summary>
		/// <param name="oEntry">PRTVData:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ɹ����ϵ�����������
		/// </summary>
		/// <param name="oEntry">PRTVData:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ���еĲɹ����ϵ���
		/// </summary>
		/// <returns>PRTVData:	�ɹ����ϵ�ʵ�塣</returns>
		public PRTVData GetPRTVAll()
		{
			PRTV oPRTV=new PRTV();
			return (PRTVData)oPRTV.GetEntryAll();
		}


        

        /// <summary>
        /// ��ȡ���еĲɹ����ϵ���
        /// </summary>
        /// <returns>PRTVData:	�ɹ����ϵ�ʵ�塣</returns>
        public PRTVData GetPRTVByPerson(string EmpCode)
        {
            PRTV oPRTV = new PRTV();
            return (PRTVData)oPRTV.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// ���ݲɹ����ϵ���ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>PRTVData:	�ɹ����ϵ�����ʵ�塣</returns>
		public PRTVData GetPRTVByEntryNo(int EntryNo)
		{
			PRTV oPRTV = new PRTV();
			return (PRTVData)oPRTV.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// �ڷ���ģʽ�¸��ݲɹ����ϵ���ˮ�Ż�ȡ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ��</param>
		/// <returns>PRTVData:	�ɹ����ϵ�����ʵ�塣</returns>
		public PRTVData GetPRTVByEntryNoInMode(int EntryNo)
		{
			PRTV oPRTV = new PRTV();
			return (PRTVData)oPRTV.GetEntryByEntryNoInMode(EntryNo);
		}
		/// <summary>
		/// ���ݲɹ����ϵ���Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>PRTVData:	�ɹ����ϵ�����ʵ�塣</returns>
		public PRTVData GetPRTVByEntryCode(string EntryCode)
		{
			PRTV oPRTV = new PRTV();
			return (PRTVData)oPRTV.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// ��ȡĳһ�����ŵĲɹ����ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	���ű�š�</param>
		/// <returns>PRTVData:	�ɹ����ϵ�����ʵ�塣</returns>
		public PRTVData GetPRTVByDept(string DeptCode)
		{
			PRTV oPRTV = new PRTV();
			return (PRTVData)oPRTV.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// ����PKID��ȡ����Դ��
		/// </summary>
		/// <param name="PKID"></param>
		/// <returns></returns>
		public RTVSData GetRTVSByPKID(string PKID)
		{
			PRTV oPRTV = new PRTV();
			return (RTVSData)oPRTV.GetRTVSByPKID(PKID);
		}

		/// <summary>
		/// ���ݲɹ����ϵ���ȡ�˻������ݡ�
		/// </summary>
		/// <param name="PKID">string:	�ɹ����ϵ�ID��</param>
		/// <returns>RTVSDetailData��	�ɹ��˻�����ϸ����ʵ�塣</returns>
		public RTVSDetailData GetRTVSDetailByPKID(string PKID)
		{
			PRTV oPRTV = new PRTV();
			return (RTVSDetailData)oPRTV.GetRTVSDetailByPKID(PKID);
		}

		#endregion

		#region ͨ�ò�ѯ
		/// <summary>
		/// �ɹ����뵥ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>RequestOfStockData:	�ɹ����뵥����ʵ�塣</returns>
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
		/// ��������ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>PMRPData:	������������ʵ�塣</returns>
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
		/// �ɹ��ƻ�ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>PurchasePlanData:	�ɹ��ƻ�����ʵ�塣</returns>
		public PurchasePlanData GetPPBySQL(string Sql_Statement)
		{
			PurchasePlans oPurchasePlans = new PurchasePlans();
			return oPurchasePlans.GetEntryBySQL(Sql_Statement);
		}
		/// <summary>
		/// �ɹ�����ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>PurchaseOrderData:	�ɹ���������ʵ��.</returns>
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
		/// ���ϵ�ͨ�ò�ѯ.
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
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
		/// �ɹ��˻���ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>PRTVData:	�ɹ��˻�������ʵ�塣</returns>
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
		/// �ɹ�������ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL��䡣</param>
		/// <returns>CancelData: �ɹ�����������ʵ�塣</returns>
		public CancelData GetCancelBySQL(string Sql_Statement)
		{
			Cancels oCancels = new Cancels();
			return oCancels.GetEntryBySQL(Sql_Statement);
		}
		/// <summary>
		/// ��Ӧ��ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>PPRNData:	��Ӧ������ʵ�塣</returns>
		public PPRNData GetPPRNBySQL(string Sql_Statement)
		{
			PPRNs myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNBySQL(Sql_Statement);
		}
		/// <summary>
		/// ���ν�����ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>PPRNData:	��Ӧ������ʵ�塣</returns>
		public PBRBData GetPBRBBySQL(string Sql_Statement)
		{
			PBRBs myPBRBs = new PBRBs();
			return myPBRBs.GetEntryBySQL(Sql_Statement);
		}
		#endregion

		#region IPBRBSystem ��Ա
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
		/// ���ν�������������
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
		/// ���ν�������������
		/// </summary>
		/// <param name="oEntry">PBRBData:	���ν�����.</param>
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
		/// ��ȡ��ǰ�������š�
		/// </summary>
		/// <param name="YYMM">string:	��ǰ�������ַ�����</param>
		/// <returns>string:	���š�</returns>
		public string GetPBRBBatchCode(string YYMM)
		{
			return new PBRBs().GetBatchCode(YYMM);
		}
		#endregion

		#region �������嵥
		/// <summary>
		/// ��ȡ���д������嵥��
		/// </summary>
		/// <returns>InData��	�������嵥ʵ�塣</returns>
		public InData GetInDataAll()
		{
			return new INs().GetInDataAll();
		}
		/// <summary>
		/// ���ݲֿ����Ա��ȡ�������嵥��
		/// </summary>
		/// <param name="UserCode">string:	�ֿ����Ա��š�</param>
		/// <returns>InData:	�����ϵ����嵥ʵ�塣</returns>
		public InData GetInDataByStoManager(string UserCode)
		{
			return new INs().GetInDataByStoManager(UserCode);
		}
		/// <summary>
		/// ���ݹ���Ա��ȡ�����ϵĵ����嵥��
		/// </summary>
		/// <param name="UserCode">string:	�û���š�</param>
		/// <returns>InData:	�����ϵ����嵥ʵ�塣</returns>
		public InData GetInDataByStoManagerWithTODO(string UserCode)
		{
			return new INs().GetInDataByStoManagerAndEntryState(UserCode, "T");
		}
		#endregion

		#region IPAYSystem ��Ա

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

		#region IAudit3System ��Ա
		/// <summary>
		/// ��ȡ���д����������ĵ��ݵ�ʵ�塣
		/// </summary>
		/// <returns>Audit3Data:	���������ĵ���.</returns>
		public Audit3Data GetAudit3DataByToAudit(string UserLoginId)
		{
			Audit3s DA = new Audit3s();
			Audit3Data oData;
			oData = DA.GetAudit3DataToAudit(UserLoginId);

			return oData;
		}
		/// <summary>
		/// ����SQL����ȡ���������ĵ��ݵ�ʵ�塣
		/// </summary>
		/// <param name="SqL_Statement"></param>
		/// <returns>Audit3Data:	���������ĵ���.</returns>
		public Audit3Data GetAudit3DataBySQL(string Sql_Statement)
		{
			Audit3s DA = new Audit3s();
			Audit3Data oData;
			oData = DA.GetAudit3DataBySQL(Sql_Statement);
			return oData;
		}

		#endregion

		#region ������ת��Ϣ
		public DocItemRouteData GetDocItemRouteData(int EntryNo,int DocCode,int SerialNo,string ItemCode)
		{
			return new Analysis().Get_DocItemRoute(EntryNo,DocCode,SerialNo,ItemCode);
		}
		#endregion

		#region IPPRCSystem ��Ա

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

		#region ICancelSystem ��Ա
		/// <summary>
		/// �ɹ��������½���
		/// </summary>
		/// <param name="oEntry">CancelData:	�ɹ��������½���</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
		/// �ɹ��������޸ġ�
		/// </summary>
		/// <param name="oEntry">CancelData:	�ɹ�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
		/// �ɹ��������½������ύ��
		/// </summary>
		/// <param name="oEntry">CancelData:	�ɹ�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
		/// �ɹ��������޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">CancelData:	�ɹ�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
		/// �ɹ��������ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ���������š�</param>
		/// <param name="UserLoginId">string: �û�ID��</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
		/// �ɹ����������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ���������š�</param>
		/// <param name="UserLoginId">string: �û�ID��</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
                    Message = "����Ȩ������";
                    ret = false;
                }
            }
            else
            {
                Message = "�ɹ����������ϵ�ǰ���ǣ����ݴ����½���������ͨ����״̬��";
                ret = false;
            }
			return ret;
		}
		/// <summary>
		/// �ɹ�������ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ���������š�</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
        /// �ɹ�������ɾ����
        /// </summary>
        /// <param name="EntryNo">int:	�ɹ���������š�</param>
        /// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
                    Message = "����Ȩ������";
                    ret = false;
                }
            }
            else
            {
                Message = "�ɹ�������ɾ����ǰ���ǣ����ݴ������ϵ�״̬��";
                ret = false;
            }
            
            return ret;
        }

		/// <summary>
		/// �ɹ�����������������
		/// </summary>
		/// <param name="oEntry">CancelData:	�ɹ�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
		/// �ɹ�����������������
		/// </summary>
		/// <param name="oEntry">CancelData:	�ɹ�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
		/// �ɹ�����������������
		/// </summary>
		/// <param name="oEntry">CancelData:	�ɹ�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����True��ʧ�ܷ���false��</returns>
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
		/// ��ȡ���вɹ���������
		/// </summary>
		/// <param name="UserLoginID">string:	�û�ID��</param>
		/// <returns>CancelData:	�ɹ�������ʵ�塣</returns>
		public CancelData GetCancelAll(string UserLoginID)
		{
			return new Cancels().GetEntryAll(UserLoginID);
		}

        /// <summary>
        /// ��ȡ���вɹ���������
        /// </summary>
        /// <param name="UserLoginID">string:	�û�ID��</param>
        /// <returns>CancelData:	�ɹ�������ʵ�塣</returns>
        public CancelData GetCancelByPerson(string EmpCode)
        {
            return new Cancels().GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// ���ݱ�Ż�ȡ�ɹ���������
		/// </summary>
		/// <param name="EntryNo">int��	�ɹ���������š�</param>
		/// <returns>CancelData:	�ɹ�������ʵ�塣</returns>
		public CancelData GetCancelByEntryNo(int EntryNo)
		{
			return new Cancels().GetEntryByEntryNo(EntryNo);
		}

		#endregion
	}
}
