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
	/// <summary>
	/// PurchaseOrder ��ժҪ˵����
	/// </summary>
	public class PurchaseOrder :Messages,IInItem
	{
		#region ���캯��
		public PurchaseOrder()
		{
		}
		#endregion

		#region IInItem ��Ա

		/// <summary>
		/// �ɹ�����¼�롣
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			bool ret = true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			//�ж���û��ָ����Ӧ�̡�
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
			{
				this.Message = PurchaseOrderData.NoPrvider;
				return false;
			}
			//ִ�вɹ��������½���
			if (oPurchaseOrders.InsertEntry(Entry) == false)
			{
				this.Message = oPurchaseOrders.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ�����¼�벢���ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			//�ж���û��ָ����Ӧ�̡�
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" || 
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
			{
				this.Message = PurchaseOrderData.NoPrvider;
				return false;
			}
			//�ж���û��ָ���ɹ�Ա��
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() == "-1"||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() =="��")
			{
				this.Message = PurchaseOrderData.NoBuyer;
				return false;
			}
			if (oPurchaseOrders.InsertAndPresentEntry(Entry) == false)
			{
				this.Message = oPurchaseOrders.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ������޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			bool ret = true;
	
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			//�ж��޸ĵ�ǰ��������
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject
				)
			{
				//�ж���û��ָ����Ӧ�̡�
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
				{
					this.Message = PurchaseOrderData.NoPrvider;
					return false;
				}
				if (oPurchaseOrders.UpdateEntry(Entry) == false)
				{
					this.Message = oPurchaseOrders.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XUpdate;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ������޸Ĳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			bool ret = true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject
				)
			{
				oPOData = (PurchaseOrderData)Entry;
				//�ж���û��ָ����Ӧ�̡�
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
				{
					this.Message = PurchaseOrderData.NoPrvider;
					return false;
				}
				//�ж���û��ָ���ɹ�Ա��
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() == "-1" ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "��")
				{
					this.Message = PurchaseOrderData.NoBuyer;
					return false;
				}
				if (oPurchaseOrders.UpdateAndPresentEntry(Entry) == false)
				{
					this.Message = oPurchaseOrders.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XUpdatePresent;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ�����ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			//�жϲɹ�����ɾ����ǰ��������
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
			{
				if (oPurchaseOrders.DeleteEntry(EntryNo) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XDelete;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ�����״̬�޸ġ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();

			if (oPurchaseOrders.UpdateEntryState(EntryNo,newState) == false)
			{
				this.Message=oPurchaseOrders.Message;
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;
			int EntryNo;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = Entry as PurchaseOrderData;
			EntryNo = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			oPOData = oPurchaseOrders.GetEntryByEntryNo(EntryNo) as PurchaseOrderData;
			//�ж�һ��������ǰ���������鿴����֮ǰ�ĵ���״̬�Ƿ���ָ�ɡ�
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Assigned)
			{
				oPOData = Entry as PurchaseOrderData;
				//���û�н������ȷ�������б���
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "Y" &&
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "N")
				{
					this.Message = "��ȷ�������ͨ�����ǲ�ͨ����";
					ret = false;
				}
				//���������ͨ��������û��дԭ��
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() == "N" &&
					(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDITSUGGEST1_FIELD] == null ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString().Trim() == "") )
				{
					this.Message = "��д��������ͨ����ԭ��";
					return false;
				}
				if (oPurchaseOrders.FirstAudit(Entry) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж϶���������ǰ��������
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oPurchaseOrders.SecondAudit(Entry) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XSecondAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж�����������ǰ��������
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{			
				if (oPurchaseOrders.ThirdAudit(Entry) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XThirdAudit;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ�����ָ�ɡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			//�ж϶���ָ�ɵ�ǰ��������
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			{
				//�ж���û��ָ����Ӧ�̡�
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
				{
					this.Message = PurchaseOrderData.NoPrvider;
					return false;
				}
				//�ж���û��ָ���ɹ�Ա��
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() == "-1"||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() == "��")
				{
					this.Message = PurchaseOrderData.NoBuyer;
					return false;
				}
				if (oPurchaseOrders.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XAssign;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			//�ж����ϵ�ǰ��������
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject)
			{
				if (oPurchaseOrders.Cancel(EntryNo, newState) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XCancel;
				ret = false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			//�ж�һ��������ǰ��������
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject)
			{
				if (oPurchaseOrders.Cancel(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ݲɹ�������ˮ�Ż�ȡ�ɹ�����������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <returns>object:	�ɹ���������ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			return oPurchaseOrderData;
		}

        /// <summary>
        /// ���ݲɹ�������ˮ�Ż�ȡ�ɹ�����������Ϣ��
        /// </summary>
        /// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
        /// <returns>object:	�ɹ���������ʵ�塣</returns>
        public object GetPORepealEntryNo(int EntryNo)
        {
         

            PurchaseOrderData oPurchaseOrderData;
            PurchaseOrders oPurchaseOrders = new PurchaseOrders();
            oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetPORepealEntryNo(EntryNo);
           // ((PurchaseOrderData)oPurchaseOrders).get
            return oPurchaseOrderData;
        }

		/// <summary>
		/// ���ݲɹ�������ˮ�Ż�ȡ�ɹ�����������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <returns>object:	�ɹ���������ʵ�塣</returns>
		public object GetEntryByEntryNoAndItemCode(int EntryNo, string ItemCode)
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNoAndItemCode(EntryNo, ItemCode);
			return oPurchaseOrderData;
		}
		/// <summary>
		/// ���ݲɹ�������Ż�ȡ�ɹ�������Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	�ɹ�������š�</param>
		/// <returns>object:	�ɹ���������ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCode(EntryCode);
			return oPurchaseOrderData;
		}
		/// <summary>
		/// ��ȡ���вɹ�������
		/// </summary>
		/// <returns>object:	�ɹ���������ʵ�塣</returns>
		public object GetEntryAll()
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryAll();
			return oPurchaseOrderData;
		}
		/// <summary>
		/// ���ݲɹ������Ƶ����ű�Ż�ȡ�ɹ�������Ϣ��
		/// </summary>
		/// <param name="DeptCode">string:	�ɹ������Ƶ����ű�š�</param>
		/// <returns>object:	�ɹ���������ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryByDept(DeptCode);
			return oPurchaseOrderData;
		}

		#endregion

		#region �ɹ�����ר�з���
		/// <summary>
		/// ��ȡ���еĲɹ�������Դ����.
		/// </summary>
		/// <param name="UserLoginId">��¼��</param>
		/// <returns>POSData</returns>
		public POSData GetPosAll(string UserLoginId)
		{
			POSData oPOSData;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPOSData = oPurchaseOrders.GetPOSAll(UserLoginId);
			return oPOSData;
		}
		/// <summary>
		/// �ɹ�����ȷ�ϡ�
		/// </summary>
		/// <param name="EntryNo">�ɹ��������</param>
		/// <param name="newState">��״̬</param>
		/// <param name="UserLoginId">��¼��</param>
		/// <returns>bool</returns>
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdPass )
			{
				if (oPurchaseOrders.Affirm(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XConfirm;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����ID����ȡ�ɹ�������Դ����ϸ����.
		/// </summary>
		/// <param name="PKIDs">�ɹ�������ԴID��.</param>
		/// <returns>POSData</returns>
		public POSData GetPOSByPKIDs(string PKIDs)
		{
			POSData oPOSData;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPOSData = oPurchaseOrders.GetPOSByPKIDs(PKIDs);
			return oPOSData;
		}
		
					   
					   
		#endregion
	}
}
