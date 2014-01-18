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

namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.SQLServerDAL;
    using System.Collections.Generic;
    /// <summary>
	/// RequestOfStock ��ժҪ˵����
	/// </summary>
	public class RequestOfStock:Messages,IInItem
	{

        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Grant();
        private IList<GrantInfo> grantinfo;

		#region ���캯��
		public RequestOfStock()
		{
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// �ɹ����뵥¼�롣
		/// </summary>
		/// <param name="Entry">object:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			bool ret=true;
			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)Entry;
			//�����;��
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="-1" ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="")//δָ����;��
			{
				this.Message = RequestOfStockData.NoPurpose;
				ret = false;
				return ret;
			}
			//������벿�š�
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
			{
				this.Message = RequestOfStockData.NoReqDept;
				ret = false;
				return ret;
			}
			//��������ˡ�
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
			{
				this.Message = RequestOfStockData.NoProposer;
				ret = false;
				return ret;
			}
			//����ͨ�����б��������
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();

			if (oRequestOfStocks.InsertEntry(Entry) == false)
			{
				this.Message = oRequestOfStocks.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �½��������ύ�ɹ����뵥.
		/// </summary>
		/// <param name="Entry">object:	�ɹ����뵥��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  ��� RequestOfStock.Insert ʵ��
			bool ret=true;
			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)Entry;
			//�����;��
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="-1" ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="")//δָ����;��
			{
				this.Message = RequestOfStockData.NoPurpose;
				ret = false;
				return ret;
			}
			//������벿�š�
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
			{
				this.Message = RequestOfStockData.NoReqDept;
				ret = false;
				return ret;
			}
			//��������ˡ�
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
			{
				this.Message = RequestOfStockData.NoProposer;
				ret = false;
				return ret;
			}
			//����ͨ�����б��������
			RequestOfStocks oRequestOfStocks=new RequestOfStocks();

			if (oRequestOfStocks.InsertAndPresentEntry(Entry)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����뵥�޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			bool ret=true;
			int EntryNo;
			string UserLoginId;
		    var oROSData = (RequestOfStockData)Entry;
			EntryNo = Convert.ToInt32(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

//			oROSData = (RequestOfStockData)new RequestOfStocks().GetEntryByEntryNo(EntryNo);
//			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
//			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = RequestOfStockData.XUpdate;
//				return false;
//			}
			//�жϲ�����ǰ������.
			if (!this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				this.Message = "����Ȩ���д˲���!";
				return false;
			}
			oROSData = (RequestOfStockData)Entry;//���¸�ֵ��
			//�����;��
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="-1" ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="")//δָ����;��
			{
				this.Message = RequestOfStockData.NoPurpose;
				ret = false;
				return ret;
			}
			//������벿�š�
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
			{
				this.Message = RequestOfStockData.NoReqDept;
				ret = false;
				return ret;
			}
			//��������ˡ�
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
			{
				this.Message = RequestOfStockData.NoProposer;
				ret = false;
				return ret;
			}
			//����ͨ�����б��������
			RequestOfStocks oRequestOfStocks=new RequestOfStocks();

			if (oRequestOfStocks.UpdateEntry(Entry)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �޸Ĳ����ύ�ɹ����뵥.
		/// </summary>
		/// <param name="Entry">object:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  ��� RequestOfStock.Update ʵ��
			bool ret=true;
			int EntryNo;
			string UserLoginId;

			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)Entry;
			EntryNo = Convert.ToInt32(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			
//			RequestOfStocks oROSs = new RequestOfStocks();
//			oROSData = (RequestOfStockData)oROSs.GetEntryByEntryNo(int.Parse(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
//			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
//			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = RequestOfStockData.XUpdate;
//				return false;
//			}
			if (!this.CheckPreCondition(EntryNo,OP.Edit, UserLoginId))
			{
				this.Message = "����Ȩ���д˲���!";
				return false;
			}

			oROSData = (RequestOfStockData)Entry;  //���¸�ֵ��
			//�����;��
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="-1" ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="")//δָ����;��
			{
				this.Message = RequestOfStockData.NoPurpose;
				ret = false;
				return ret;
			}
			//������벿�š�
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
			{
				this.Message = RequestOfStockData.NoReqDept;
				ret = false;
				return ret;
			}
			//��������ˡ�
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
			{
				this.Message = RequestOfStockData.NoProposer;
				ret = false;
				return ret;
			}
			//����ͨ�����б��������
			RequestOfStocks oRequestOfStocks=new RequestOfStocks();

			if (oRequestOfStocks.UpdateAndPresentEntry(Entry)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����뵥ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	 �ɹ����뵥��ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  ��� RequestOfStock.Delete ʵ��
			bool ret=true;
			RequestOfStockData oROSData;

			RequestOfStocks oRequestOfStocks=new RequestOfStocks();
			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
			if (oROSData != null && oROSData.Count > 0)
			{
				//�������������״̬������ɾ����
				if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oRequestOfStocks.DeleteEntry(EntryNo)==false)
					{
						this.Message=oRequestOfStocks.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = RequestOfStockData.XDelete;
					ret = false;
				}
			}
			
			return ret;
		}
		/// <summary>
		/// �ɹ����뵥ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	 �ɹ����뵥��ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û�.</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			// TODO:  ��� RequestOfStock.Delete ʵ��
			bool ret=true;
			RequestOfStocks oRequestOfStocks=new RequestOfStocks();
			if (!this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				this.Message = "����Ȩ���д˲���!";
				return false;
			}
			if (oRequestOfStocks.DeleteEntry(EntryNo)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
								
			return ret;
		}
		/// <summary>
		/// �޸ĵ���״̬.
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ��.</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  ��� RequestOfStock.UpdateEntryState ʵ��
			bool ret=true;

			RequestOfStocks oRequestOfStocks=new RequestOfStocks();

			if (oRequestOfStocks.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			var ret=true;

			var oRequestOfStocks=new RequestOfStocks();
            var entryNo = (int)((RequestOfStockData)Entry).Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD];
			var oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(entryNo);
			
            if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				if (oRequestOfStocks.FirstAudit(Entry) == false)
				{
					this.Message = oRequestOfStocks.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;

			var oRequestOfStocks=new RequestOfStocks();
		    var oROSData = (RequestOfStockData)Entry;
			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(int.Parse(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ɹ����뵥����������ǰ��������һ������ͨ����
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.WZPass)
			{
				if (oRequestOfStocks.SecondAudit(Entry) == false)
				{
					this.Message=oRequestOfStocks.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XSecondAudit;
				ret =false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)Entry;
			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(int.Parse(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ɹ����뵥����������ǰ��������һ������ͨ����
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{
				if (oRequestOfStocks.ThirdAudit(Entry) == false)
				{
					this.Message=oRequestOfStocks.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XThirdAudit;
				ret = false;
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
        public bool WZAudit(int entryNo, string entryState,string audit4,string assessor4,string auditSuggest4,string itemCodes,string loginId)
        {
            bool ret = true;
            var oRequestOfStocks = new RequestOfStocks();
            var oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(entryNo);
            //�ɹ����뵥����������ǰ��������һ������ͨ����
            if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
            {
                if (oRequestOfStocks.WZAudit(entryNo,entryState,audit4,assessor4,auditSuggest4,itemCodes,loginId) == false)
                {
                    this.Message = oRequestOfStocks.Message;
                    ret = false;
                }
            }
            else
            {
                this.Message = RequestOfStockData.XWZAudit;
                ret = false;
            }
            return ret;
        }
		/// <summary>
		/// �ɹ����뵥�ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
//			RequestOfStockData oROSData;
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
//			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���Ĳ������ύ��
//			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId))
			{
				if (oRequestOfStocks.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oRequestOfStocks.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XPresent;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���������ϣ�
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oRequestOfStocks.Cancel(EntryNo, newState) == false)
				{
					this.Message = oRequestOfStocks.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginID">string:	������.</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;

			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
//			RequestOfStockData oROSData;
//			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
//			//����״̬Ϊ�½���������ͨ���������ϣ�
//			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginID))
			{
				if (oRequestOfStocks.Cancel(EntryNo, newState, UserLoginID) == false)
				{
					this.Message = oRequestOfStocks.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ݲɹ����뵥��ˮ�Ż�ȡ�ɹ����뵥������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <returns>object:	�ɹ����뵥����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
		    var oRequestOfStocks = new RequestOfStocks();
			var oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
			return oRequestOfStockData;
		}
		/// <summary>
		/// ���ݲɹ����뵥��Ż�ȡ�ɹ����뵥������Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	�ɹ����뵥��š�</param>
		/// <returns>object:	�ɹ����뵥����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
		    var oRequestOfStocks = new RequestOfStocks();
			var oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryCode(EntryCode);
			return oRequestOfStockData;
		}
		/// <summary>
		/// ��ȡ���вɹ����뵥��
		/// </summary>
		/// <returns>object:	�ɹ����뵥����ʵ�塣</returns>
		public object GetEntryAll()
		{
		    var oRequestOfStocks = new RequestOfStocks();
			var oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryAll();
			return oRequestOfStockData;
		}
		/// <summary>
		/// ��ȡָ�����벿�ŵĲɹ����뵥��
		/// </summary>
		/// <param name="DeptCode">string:	���벿�ű�š�</param>
		/// <returns>object:	�ɹ����뵥����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
		    var oRequestOfStocks = new RequestOfStocks();
			var oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryByDept(DeptCode);
			return oRequestOfStockData;
		}

		#endregion

		#region ר�÷���
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <param name="Operation">string:	�������롣</param>
		/// <param name="UserLoginID">string:	��ǰ������.</param>
		/// <returns>bool:	����ǰ����������true,�����Ϸ���false��</returns>
		public bool CheckPreCondition(int EntryNo, string Operation, string UserLoginID)
		{
			bool ret = false;
			string EntryState;
			string AuthorLoginID;
			
			if (Operation == OP.New)
			{
				return true;
			}
			RequestOfStockData oRequestOfStockData;
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
			oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);   

			if (oRequestOfStockData.Count > 0)
			{
				EntryState = oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
				switch (Operation)
				{
						#region �༭
					case OP.Edit://�༭��
						if (EntryState == DocStatus.New || 
							EntryState == DocStatus.Cancel || 
							EntryState == DocStatus.FstNoPass || 
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
                            EntryState == DocStatus.WZNoPass ||
							EntryState == DocStatus.OrdReject
							)
						{

                            grantinfo = grant.GetAllAvalibleByEmbracer(AuthorLoginID);
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
                                for (int i = 0; i < grantinfo.Count; i++)
								{
                                    if (grantinfo[i].Embracer == UserLoginID)
									{
										return true;
									}
								}
								return false;
							}
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region �ύ
					case OP.Submit://�ύ��
                        if (EntryState == DocStatus.New ||
                            EntryState == DocStatus.Cancel ||
                            EntryState == DocStatus.FstNoPass ||
                            EntryState == DocStatus.SecNoPass ||
                            EntryState == DocStatus.TrdNoPass ||
                            EntryState == DocStatus.WZNoPass ||
                            EntryState == DocStatus.OrdReject
                            )
						{
							ret = AuthorLoginID == UserLoginID;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region һ������
					case OP.FirstAudit://һ��������
						ret = EntryState == DocStatus.Present;
						break;
						#endregion
                    #region ��������
                    case OP.WZAudit://��������
                        ret = EntryState == DocStatus.FstPass;
				        break;
                    #endregion
                    #region ��������
                    case OP.SecondAudit://����������
						ret = EntryState == DocStatus.WZPass;
						break;
						#endregion
						#region ��������
					case OP.ThirdAudit://����������		
						ret = EntryState == DocStatus.SecPass;
						break;
						#endregion 
						#region ����
					case OP.Red://���֡�
						ret = EntryState == DocStatus.Drawed;
						break;
						#endregion
						#region ����
					case OP.O://���ϡ�
						ret = EntryState == DocStatus.TrdPass;
						break;
						#endregion
						#region ����
					case OP.Cancel://���ϡ�
						if (EntryState == DocStatus.New ||
							EntryState == DocStatus.FstNoPass ||
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
                            EntryState == DocStatus.WZNoPass ||
							EntryState == DocStatus.OrdReject)
						{
							ret = AuthorLoginID == UserLoginID;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region ɾ��
					case OP.Delete://ɾ����
						if (EntryState == DocStatus.Cancel)
						{
							ret = AuthorLoginID == UserLoginID;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
					default:
						ret = false;
						break;
				}
				return ret;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
