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
	/// PBRB ��ժҪ˵����
	/// </summary>
	public class PBRB:Messages,IInItem
	{
		#region ���캯��
		public PBRB()
		{
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// ����������¼�롣
		/// </summary>
		/// <param name="Entry">object:	����������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			bool ret=true;
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			//���ֿ⡣
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOSTORAGE;
				ret = false;
				return ret;
			}
			//��鹩Ӧ�̡�
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.PRVCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOVENDOR;
				ret = false;
				return ret;
			}
			//��鶩����
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString().Trim().Length == 0)
			{
				this.Message = PBRBData.NOORDER;
				ret = false;
				return ret;
			}
			else
			{
				PurchaseOrderData oPOData;
				PurchaseOrders oPurchaseOrders = new PurchaseOrders();
				string OrderCode;
				string ItemCode;
				OrderCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString();
				ItemCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString().Split(',')[0];

				oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCodeAndItemCode(OrderCode,ItemCode);
				
				if (oPOData.Count == 0)
				{
					this.Message = PBRBData.XORDER;
					ret = false;
					return ret;
				}
				else
				{
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERNO_FIELD] = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERCODE_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERNAME_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
				}
			}
			//����ͨ�����б��������
			
			PBRBs oPBRBs = new PBRBs();

			if (oPBRBs.InsertEntry(oPBRBData) == false)
			{
				this.Message = oPBRBs.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �½��������ύ����������.
		/// </summary>
		/// <param name="Entry">object:	������������</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  ��� PBRB.Insert ʵ��
			bool ret=true;
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			//���ֿ⡣
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOSTORAGE;
				ret = false;
				return ret;
			}
			//��鹩Ӧ�̡�
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.PRVCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOVENDOR;
				ret = false;
				return ret;
			}
			//��鶩����
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString().Trim().Length == 0)
			{
				this.Message = PBRBData.NOORDER;
				ret = false;
				return ret;
			}
			else
			{
				PurchaseOrderData oPOData;
				PurchaseOrders oPurchaseOrders = new PurchaseOrders();
				string OrderCode;
				string ItemCode;
				OrderCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString();
				ItemCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString().Split(',')[0];

				oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCodeAndItemCode(OrderCode,ItemCode);
				if (oPOData.Count == 0)
				{
					this.Message = PBRBData.XORDER;
					ret = false;
					return ret;
				}
				else
				{
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERNO_FIELD] = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERCODE_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERNAME_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
				}
			}
			//����ͨ�����б��������
			PBRBs oPBRBs=new PBRBs();

			if (oPBRBs.InsertAndPresentEntry(oPBRBData)==false)
			{
				this.Message=oPBRBs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �����������޸ġ�
		/// </summary>
		/// <param name="Entry">object:	����������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			// TODO:  ��� PBRB.Update ʵ��
			bool ret=true;
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));

			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			{
				this.Message = PBRBData.XUpdate;
				return false;
			}
			oPBRBData = (PBRBData)Entry;
			//���ֿ⡣
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOSTORAGE;
				ret = false;
				return ret;
			}
			//��鹩Ӧ�̡�
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.PRVCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOVENDOR;
				ret = false;
				return ret;
			}
			//��鶩����
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString().Trim().Length == 0)
			{
				this.Message = PBRBData.NOORDER;
				ret = false;
				return ret;
			}
			else
			{
				PurchaseOrderData oPOData;
				PurchaseOrders oPurchaseOrders = new PurchaseOrders();

				string OrderCode;
				string ItemCode;
				OrderCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString();
				ItemCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString().Split(',')[0];

				oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCodeAndItemCode(OrderCode,ItemCode);
				
				if (oPOData.Count == 0)
				{
					this.Message = PBRBData.XORDER;
					ret = false;
					return ret;
				}
				else
				{
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERNO_FIELD] = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERCODE_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERNAME_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
				}
			}
			//����ͨ�����б��������
			PBRBs oPBRBs=new PBRBs();

			if (oPBRBs.UpdateEntry(oPBRBData)==false)
			{
				this.Message=oPBRBs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �޸Ĳ����ύ����������.
		/// </summary>
		/// <param name="Entry">object:	����������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  ��� PBRB.Update ʵ��
			bool ret=true;
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));

			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			{
				this.Message = PBRBData.XUpdate;
				return false;
			}
			oPBRBData = (PBRBData)Entry;
			//���ֿ⡣
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOSTORAGE;
				ret = false;
				return ret;
			}
			//��鹩Ӧ�̡�
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.PRVCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOVENDOR;
				ret = false;
				return ret;
			}
			//��鶩����
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString().Trim().Length == 0)
			{
				this.Message = PBRBData.NOORDER;
				ret = false;
				return ret;
			}
			else
			{
				PurchaseOrderData oPOData;
				PurchaseOrders oPurchaseOrders = new PurchaseOrders();

				string OrderCode;
				string ItemCode;
				OrderCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString();
				ItemCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString().Split(',')[0];

				oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCodeAndItemCode(OrderCode,ItemCode);

				if (oPOData.Count == 0)
				{
					this.Message = PBRBData.XORDER;
					ret = false;
					return ret;
				}
				else
				{
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERNO_FIELD] = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERCODE_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERNAME_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
				}
			}
			//����ͨ�����б��������
			PBRBs oPBRBs=new PBRBs();

			if (oPBRBs.UpdateAndPresentEntry(oPBRBData)==false)
			{
				this.Message=oPBRBs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ����������ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	 ������������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  ��� PBRB.Delete ʵ��
			bool ret=true;
			PBRBData oPBRBData;

			PBRBs oPBRBs=new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			if (oPBRBData != null && oPBRBData.Count > 0)
			{
				//�������������״̬������ɾ����
				if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oPBRBs.DeleteEntry(EntryNo)==false)
					{
						this.Message=oPBRBs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = PBRBData.XDelete;
					ret = false;
				}
			}
			
			return ret;
		}
		/// <summary>
		/// �޸ĵ���״̬.
		/// </summary>
		/// <param name="EntryNo">int:	������������ˮ��.</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  ��� PBRB.UpdateEntryState ʵ��
			bool ret=true;

			PBRBs oPBRBs=new PBRBs();

			if (oPBRBs.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oPBRBs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	����������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  ��� PBRB.FirstAduit ʵ��
			bool ret=true;

			PBRBs oPBRBs=new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));

			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				if (oPBRBs.FirstAudit(Entry) == false)
				{
					this.Message = oPBRBs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PBRBData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	����������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  ��� PBRB.SecondAduit ʵ��
			bool ret=true;

			PBRBs oPBRBs=new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//��������������������ǰ��������һ������ͨ����
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oPBRBs.SecondAudit(Entry) == false)
				{
					this.Message=oPBRBs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PBRBData.XSecondAudit;
				ret =false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	����������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  ��� PBRB.ThirdAduit ʵ��
			bool ret = true;

			PBRBs oPBRBs = new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//��������������������ǰ��������һ������ͨ����
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{
				if (oPBRBs.ThirdAudit(Entry) == false)
				{
					this.Message=oPBRBs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PBRBData.XThirdAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �����������ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			PBRBData oPBRBData;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���Ĳ������ύ��
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oPBRBs.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oPBRBs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PBRBData.XPresent;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �������������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			PBRBs oPBRBs = new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���������ϣ�
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oPBRBs.Cancel(EntryNo, newState) == false)
				{
					this.Message = oPBRBs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = PBRBData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �������������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginID">string:	������.</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;

			PBRBs oPBRBs = new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���������ϣ�
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oPBRBs.Cancel(EntryNo, newState, UserLoginID) == false)
				{
					this.Message = oPBRBs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = PBRBData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����������������ˮ�Ż�ȡ����������������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	������������ˮ�š�</param>
		/// <returns>object:	��������������ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			return oPBRBData;
		}
		/// <summary>
		/// ����������������Ż�ȡ����������������Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	������������š�</param>
		/// <returns>object:	��������������ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryCode(EntryCode);
			return oPBRBData;
		}
		/// <summary>
		/// ��ȡ����������������
		/// </summary>
		/// <returns>object:	��������������ʵ�塣</returns>
		public object GetEntryAll()
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryAll();
			return oPBRBData;
		}
		/// <summary>
		/// ��ȡ����������������
		/// </summary>
		/// <param name="UserLoginId">string:	�û�ID��</param>
		/// <returns>object:	��������������ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryAll(UserLoginId);
			return oPBRBData;
		}
		/// <summary>
		/// ��ȡָ�����벿�ŵ�������������
		/// </summary>
		/// <param name="DeptCode">string:	���벿�ű�š�</param>
		/// <returns>object:	��������������ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByDept(DeptCode);
			return oPBRBData;
		}

		#endregion
	}
}
