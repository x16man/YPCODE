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
    using System.Collections.Generic;
 
	/// <summary>
	/// PurchaseOrder ��ժҪ˵����
	/// </summary>
	public class BillOfReceive :Messages,IInItem
	{
        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Shmzh.Components.SystemComponent.SQLServerDAL.Grant();
        private IList<GrantInfo> grantinfo;
		#region ���캯��
		public BillOfReceive()
		{
		}
		#endregion


        private bool CheckInvoice(string strInvoiceNo)
        {
            if (strInvoiceNo != null && strInvoiceNo != "")
            {
                if (strInvoiceNo.IndexOf("��") > 0)
                    return false;
               
            }
            return true;
        }

		#region IInItem ��Ա
		/// <summary>
		/// ���ϵ�¼�롣
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			bool ret = true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			//�ж����ϲֿ��Ƿ�Ϊ�ա�
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = BillOfReceiveData.NoStorage;
				return false;
			}
			//�жϲɹ�Ա�Ƿ�Ϊ�ա�
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "-1"||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "��")
			{
				this.Message = BillOfReceiveData.NoBuyer;
				return false;
			}
			//�ж��Ƶ��˺Ͳɹ�Ա�Ƿ�Ϊͬһ���ˡ�
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString())
			{
				this.Message = "�ɹ�Ա����ͬʱΪ�Ƶ��ˣ�";
				return false;
			}
			//�жϷ�Ʊ���Ƿ�Ϊ��.
            if (!CheckInvoice(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0]["InvoiceNo"].ToString()))
			{
				this.Message = "��Ʊ�Ų��������Ķ��ţ�";
				return false;
			}
			//ִ�вɹ����ϵ��½�������
			if (oBillOfReceives.InsertEntry(Entry) == false)
			{
				this.Message = oBillOfReceives.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�¼�벢���ύ��
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			//�ж����ϲֿ��Ƿ�Ϊ�ա�
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = BillOfReceiveData.NoStorage;
				return false;
			}
			//�жϲɹ�Ա�Ƿ�Ϊ�ա�
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "-1"||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "��")

			{
				this.Message = BillOfReceiveData.NoBuyer;
				return false;
			}
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString())
			{
				this.Message = "�ɹ�Ա����ͬʱΪ�Ƶ��ˣ�";
				return false;
			}
			//�жϷ�Ʊ���Ƿ�Ϊ��.
			if (!CheckInvoice(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0]["InvoiceNo"].ToString()))
			{
                this.Message = "��Ʊ�Ų��������Ķ��ţ�";
				return false;
			}
			//ִ�вɹ����ϵ��½�������
			if (oBillOfReceives.InsertAndPresentEntry(Entry) == false)
			{
				this.Message = oBillOfReceives.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			EntryNo = Convert.ToInt32(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			//�жϲɹ����ϵ����޸ĵ�ǰ��������
//			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				//�ж����ϲֿ��Ƿ�Ϊ�ա�
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString() == "-1")
				{
					this.Message = BillOfReceiveData.NoStorage;
					return false;
				}
				//�жϲɹ�Ա�Ƿ�Ϊ�ա�
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "-1"||
					oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "��")
				{
					this.Message = BillOfReceiveData.NoBuyer;
					return false;
				}
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
					oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString())
				{
					this.Message = "�ɹ�Ա����ͬʱΪ�Ƶ��ˣ�";
					return false;
				}
				//�жϷ�Ʊ���Ƿ�Ϊ��.
				if (!CheckInvoice(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0]["InvoiceNo"].ToString().Trim()))
				{
                    this.Message = "��Ʊ�Ų��������Ķ��ţ�";
					return false;
				}
				//ִ�вɹ����ϵ��½�������
				if (oBillOfReceives.UpdateEntry(Entry) == false)
				{
					this.Message = oBillOfReceives.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ��޸Ĳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			EntryNo = Convert.ToInt32(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(int.Parse(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�жϲɹ����ϵ����޸Ĳ����ύ��ǰ��������
//			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				oBORData = (BillOfReceiveData)Entry;
				//�ж����ϲֿ��Ƿ�Ϊ�ա�
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString() == "-1")
				{
					this.Message = BillOfReceiveData.NoStorage;
					return false;
				}
				//�жϲɹ�Ա�Ƿ�Ϊ�ա�
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "-1"||
					oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "��")
				{
					this.Message = BillOfReceiveData.NoBuyer;
					return false;
				}
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
					oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString())
				{
					this.Message = "�ɹ�Ա����ͬʱΪ�Ƶ��ˣ�";
					return false;
				}
				//�жϷ�Ʊ���Ƿ�Ϊ��.
				if (!CheckInvoice(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0]["InvoiceNo"].ToString().Trim()))
				{
                    this.Message = "��Ʊ�Ų��������Ķ��ţ�";
					return false;
				}
				//ִ�вɹ����ϵ��½�������
				if (oBillOfReceives.UpdateAndPresentEntry(Entry) == false)
				{
					this.Message = oBillOfReceives.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			//�жϲɹ����ϵ���ɾ����ǰ��������
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel )
			{
				if (oBillOfReceives.DeleteEntry(EntryNo) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XDelete;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			//BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);

			//�жϲɹ����ϵ���ɾ����ǰ��������
			//if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel )
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				if (oBillOfReceives.DeleteEntry(EntryNo) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�״̬�޸ġ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();

			if (oBillOfReceives.UpdateEntryState(EntryNo,newState) == false)
			{
				this.Message=oBillOfReceives.Message;
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
            //ҳ����ȡ����
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
            //���ݿ�ԭ��������
            BillOfReceiveData oBORTempData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(int.Parse(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж������˺��Ƶ��˻�ɹ�Ա�Ƿ���ͬһ���ˡ�
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ASSESSOR1_FIELD].ToString() ==
                oBORTempData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERNAME_FIELD].ToString())
			{
				this.Message = "�����˲���ͬʱΪ�ɹ�Ա��";
				return false;
			}
			else if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ASSESSOR1_FIELD].ToString() ==
                    oBORTempData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORNAME_FIELD].ToString())
			{
				this.Message = "�����˲���ͬʱΪ�Ƶ��ˣ�";
				return false;
			}

			//�жϲɹ����ϵ���һ��������ǰ��������
            if (oBORTempData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				if (oBillOfReceives.FirstAudit(Entry) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(int.Parse(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�жϲɹ����ϵ��Ķ���������ǰ��������
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oBillOfReceives.SecondAudit(Entry) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XSecondAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(int.Parse(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�жϲɹ����ϵ�������������ǰ��������
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oBillOfReceives.ThirdAudit(Entry) == false)
				{
					this.Message = oBillOfReceives.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XThirdAudit;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// ���ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			//�жϲɹ����ϵ����ύ��ǰ��������
//			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId))
			{
				if (oBillOfReceives.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "����Ȩ���д˲���!";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			//�жϲɹ����ϵ������ϵ�ǰ��������
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oBillOfReceives.Cancel(EntryNo, newState) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	״̬��</param>
		/// <param name="UserLoginID">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);

			//�жϲɹ����ϵ������ϵ�ǰ��������
//			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginID))
			{
				if (oBillOfReceives.Cancel(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ����񸶿
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginID">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Pay(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			//�жϲɹ����ϵ��ĸ����ǰ��������
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Received )
			{
				if (oBillOfReceives.Pay(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XPay;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �������ϵ���ˮ�Ż�ȡ���ϵ�������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			return oBillOfReceiveData;
		}


        /// <summary>
        /// �������ϵ���ˮ�Ż�ȡ���ϵ�������Ϣ��
        /// </summary>
        /// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
        /// <returns>object:	���ϵ�����ʵ�塣</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            BillOfReceiveData oBillOfReceiveData;
            BillOfReceives oBillOfReceives = new BillOfReceives();
            oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryOldByEntryNo(EntryNo);
            return oBillOfReceiveData;
        }


      

        public bool BRInvoiceUpdate(int EntryNo,string strInvoiceNo)
        {
            BillOfReceives oBillOfReceives = new BillOfReceives();
            return oBillOfReceives.BRInvoiceNoUpdate(EntryNo, strInvoiceNo);
       }
		/// <summary>
		/// �������ϵ���ˮ�Ż�ȡ���ϵ�������Ϣ������ģʽ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNoInMode(EntryNo);
			return oBillOfReceiveData;
		}
		/// <summary>
		/// �������ϵ���Ż�ȡ���ϵ���Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	���ϵ���š�</param>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryCode(EntryCode);
			return oBillOfReceiveData;
		}
		/// <summary>
		/// ��ȡ�������ϵ���
		/// </summary>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryAll()
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryAll();
			return oBillOfReceiveData;
		}
		/// <summary>
		/// �������ϵ��Ƶ����ű�Ż�ȡ���ϵ���Ϣ��
		/// </summary>
		/// <param name="DeptCode">string:	���ϵ��Ƶ����ű�š�</param>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryByDept(DeptCode);
			return oBillOfReceiveData;
		}

		#endregion

		#region ���ϵ�ר�з��� 
		/// <summary>
		/// ���ݹ�Ӧ�̴�����Դ������
		/// </summary>
		/// <param name="PrvCode"></param>
		/// <returns></returns>
		public object GetEntryByPrvCode(string PrvCode)
		{
			PBSData oPBSData;
            BillOfReceives oBillOfReceives = new BillOfReceives();
			oPBSData = (PBSData)oBillOfReceives.GetEntryByPrvCode(PrvCode);
			return oPBSData;
		}
		/// <summary>
		/// ����pkid�б�����ϸ��
		/// </summary>
		/// <param name="List"></param>
		/// <returns></returns>
		public object GetPBSDByList(string List)
		{
			PBSDData oPBSData;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oPBSData = (PBSDData)oBillOfReceives.GetPBSDByList(List);
			return oPBSData;
		}
		/// <summary>
		/// �ɹ����ϵ����ϲ�����
		/// </summary>
		/// <param name="Entry">object:	���ϵ�����</param>
		/// <returns>bool:	���ϳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Receive(object Entry)
		{
			bool ret = true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = Entry as BillOfReceiveData;
			/*
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.ACCEPTCODE_FIELD].ToString())
			{
				this.Message = "�����˲���ͬʱΪ�Ƶ��ˣ�";
				return false;
			}
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == 
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.ACCEPTCODE_FIELD].ToString())
			{
				this.Message = "�����˲���ͬʱΪ�ɹ�Ա��";
				return false;
			}  */
			if (oBillOfReceives.Receive(Entry) == false)
			{
				this.Message = oBillOfReceives.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
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
			BillOfReceiveData oBorData;
			BillOfReceives oBors = new BillOfReceives();
			oBorData = (BillOfReceiveData)oBors.GetEntryByEntryNo(EntryNo);   

			if (oBorData.Count > 0)
			{
				EntryState = oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
				switch (Operation)
				{
						#region �༭
					case OP.Edit://�༭��
						if (EntryState == DocStatus.New || 
							EntryState == DocStatus.Cancel || 
							EntryState == DocStatus.FstNoPass || 
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
							EntryState == DocStatus.OrdReject
							)
						{
                            grant = new Shmzh.Components.SystemComponent.SQLServerDAL.Grant();
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
                          EntryState == DocStatus.OrdReject
                          )
                        {
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
								ret = false;
							}
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region һ������
					case OP.FirstAudit://һ��������
						if (EntryState == DocStatus.Present)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region ��������
					case OP.SecondAudit://����������
						if (EntryState == DocStatus.FstPass)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region ��������
					case OP.ThirdAudit://����������		
						if (EntryState == DocStatus.SecPass)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion 
						#region ����
					case OP.Red://���֡�
						if (EntryState == DocStatus.Drawed)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region ����
					case OP.O://���ϡ�
						if (EntryState == DocStatus.TrdPass)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region ����
					case OP.Cancel://���ϡ�
						if (EntryState == DocStatus.New ||
							EntryState == DocStatus.FstNoPass ||
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
							EntryState == DocStatus.OrdReject)
						{
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
								ret = false;
							}
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
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
								ret = false;
							}
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
