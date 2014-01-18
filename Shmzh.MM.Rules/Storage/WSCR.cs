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
* penalties.  Any violations of this copyright will be WSCRecuted       *
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
	/// WSCR ��ժҪ˵����
	/// </summary>
	public class WSCR:Messages,IInItem
	{
		#region ���캯��
		public WSCR()
		{
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// ���ϵ�¼�롣
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			bool ret=true;
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//�����;��
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQREASONCODE_FIELD].ToString() =="-1")//δָ����;��
//			{
//				this.Message = WSCRData.NoPurpose;
//				ret = false;
//				return ret;
//			}
			//������벿�š�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
			{
				this.Message = WSCRData.NoReqDept;
				ret = false;
				return ret;
			}
			//��������ˡ�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
			{
				this.Message = WSCRData.NoProposer;
				ret = false;
				return ret;
			}
			//����ͨ�����б��������
			WSCRs oWSCRs = new WSCRs();

			if (oWSCRs.InsertEntry(Entry) == false)
			{
				this.Message = oWSCRs.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �½��������ύ���ϵ�.
		/// </summary>
		/// <param name="Entry">object:	���ϵ���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  ��� WSCR.Insert ʵ��
			bool ret=true;
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//�����;��
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQREASONCODE_FIELD].ToString() =="-1")//δָ����;��
//			{
//				this.Message = WSCRData.NoPurpose;
//				ret = false;
//				return ret;
//			}
			//������벿�š�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
			{
				this.Message = WSCRData.NoReqDept;
				ret = false;
				return ret;
			}
			//��������ˡ�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
			{
				this.Message = WSCRData.NoProposer;
				ret = false;
				return ret;
			}
			//����ͨ�����б��������
			WSCRs oWSCRs=new WSCRs();

			if (oWSCRs.InsertAndPresentEntry(Entry)==false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
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
			// TODO:  ��� WSCR.Update ʵ��
			bool ret=true;
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = WSCRData.XUpdate;
//				return false;
//			}
			//�����;��
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQREASONCODE_FIELD].ToString() =="-1")//δָ����;��
//			{
//				this.Message = WSCRData.NoPurpose;
//				ret = false;
//				return ret;
//			}
			//������벿�š�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
			{
				this.Message = WSCRData.NoReqDept;
				ret = false;
				return ret;
			}
			//��������ˡ�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
			{
				this.Message = WSCRData.NoProposer;
				ret = false;
				return ret;
			}
			//����ͨ�����б��������
			WSCRs oWSCRs=new WSCRs();

			if (oWSCRs.UpdateEntry(Entry)==false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �޸Ĳ����ύ���ϵ�.
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  ��� WSCR.Update ʵ��
			bool ret=true;
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = WSCRData.XUpdate;
//				return false;
//			}
			//�����;��
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQREASONCODE_FIELD].ToString() =="-1")//δָ����;��
//			{
//				this.Message = WSCRData.NoPurpose;
//				ret = false;
//				return ret;
//			}
			//������벿�š�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
			{
				this.Message = WSCRData.NoReqDept;
				ret = false;
				return ret;
			}
			//��������ˡ�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
			{
				this.Message = WSCRData.NoProposer;
				ret = false;
				return ret;
			}
			//����ͨ�����б��������
			WSCRs oWSCRs=new WSCRs();

			if (oWSCRs.UpdateAndPresentEntry(Entry)==false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	 ���ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  ��� WSCR.Delete ʵ��
			bool ret=true;
			WSCRData oROSData;

			WSCRs oWSCRs=new WSCRs();
			oROSData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			if (oROSData != null && oROSData.Count > 0)
			{
				//�������������״̬������ɾ����
				if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oWSCRs.DeleteEntry(EntryNo)==false)
					{
						this.Message=oWSCRs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WSCRData.XDelete;
					ret = false;
				}
			}
			
			return ret;
		}
		/// <summary>
		/// �޸ĵ���״̬.
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ��.</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  ��� WSCR.UpdateEntryState ʵ��
			bool ret=true;

			WSCRs oWSCRs=new WSCRs();

			if (oWSCRs.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oWSCRs.Message;
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
			// TODO:  ��� WSCR.FirstAduit ʵ��
			bool ret=true;

			WSCRs oWSCRs=new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;

			//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			//			{
			if (oWSCRs.FirstAudit(Entry) == false)
			{
				this.Message = oWSCRs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WSCRData.XFirstAudit;
			//				ret = false;
			//			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  ��� WSCR.SecondAduit ʵ��
			bool ret=true;

			WSCRs oWSCRs=new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//���ϵ�����������ǰ��������һ������ͨ����
			//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			//			{
			if (oWSCRs.SecondAudit(Entry) == false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WSCRData.XSecondAudit;
			//				ret =false;
			//			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  ��� WSCR.ThirdAduit ʵ��
			bool ret = true;

			WSCRs oWSCRs = new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//���ϵ�����������ǰ��������һ������ͨ����
			//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			//			{
			if (oWSCRs.ThirdAudit(Entry) == false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WSCRData.XThirdAudit;
			//				ret = false;
			//			}
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
			bool ret = true;
			WSCRData oROSData;
			WSCRs oWSCRs = new WSCRs();
			oROSData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���Ĳ������ύ��
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWSCRs.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oWSCRs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = WSCRData.XPresent;
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
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WSCRs oWSCRs = new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���������ϣ�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWSCRs.Cancel(EntryNo, newState,UserLoginId) == false)
				{
					this.Message = oWSCRs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WSCRData.XCancel;
				ret = false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			WSCRs oWSCRs = new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���������ϣ�
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWSCRs.Cancel(EntryNo, newState) == false)
				{
					this.Message = oWSCRs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WSCRData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ݱ��ϵ���ˮ�Ż�ȡ���ϵ�������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			return oWSCRData;
		}
		/// <summary>
		/// ���ݱ��ϵ���Ż�ȡ���ϵ�������Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	���ϵ���š�</param>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryByEntryCode(EntryCode);
			return oWSCRData;
		}
		/// <summary>
		/// ��ȡ���б��ϵ���
		/// </summary>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryAll()
		{
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryAll();
			return oWSCRData;
		}
		/// <summary>
		/// ��ȡָ�����벿�ŵı��ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	���벿�ű�š�</param>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryByDept(DeptCode);
			return oWSCRData;
		}

		#endregion

		#region ���ϵ�ר�з���
		public WSCRData GetWSCRSAll()
		{
			WSCRData oWSCRData;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = oWSCRs.GetWSCRAll();
			return oWSCRData;
		}
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			WSCRs oWSCRs = new WSCRs();

			if (oWSCRs.Affirm(EntryNo, newState, UserLoginId) == false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			return ret;
		}
		public WSCRData GetWSCRSByPKIDs(string PKIDs)
		{
			WSCRData oWSCRData;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = oWSCRs.GetWSCRByPKIDs(PKIDs);
			return oWSCRData;
		}
		public WSCRData GetEntryByEntryNoDiscardMode(int EntryNo)
		{
			// TODO:  ��� WSCR.GetEntryByEntryNo ʵ��
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryByEntryNoDiscardMode(EntryNo);
			return oWSCRData;
		}
					   
					   
		#endregion
	}
}
