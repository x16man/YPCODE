#region ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved

#region �ĵ���Ϣ
/******************************************************************************
**		�ļ�: 
**		����: 
**		����: 
**
**              
**		����: �ź�
**		����: 
*******************************************************************************
**		�޸���ʷ
*******************************************************************************
**		����:		����:		����:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion �ĵ���Ϣ


namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// Cancel ��ժҪ˵����
	/// </summary>
	public class Cancel	 : Messages
	{
		#region ��Ա����
		//
		//TODO: �ڴ˴���ӳ�Ա������
		//
		#endregion

		#region ����
		//
		//TODO: �ڴ˴�������ԡ�
		//
		#endregion
		
		#region ˽�з���
		//
		//TODO: ����˴���˽�з�����
		//
		#endregion

		#region ��������
		public bool Insert(CancelData Entry)
		{
			bool ret = true;

			Cancels oCancels = new Cancels();
			//ִ�вɹ��������½���
			if (oCancels.InsertEntry(Entry) == false)
			{
				this.Message = oCancels.Message;
				ret = false;
			}
			return ret;
		}
		public bool InsertAndPresent(CancelData Entry)
		{
			bool ret = true;

			Cancels oCancels = new Cancels();
			if (oCancels.InsertAndPresentEntry(Entry) == false)
			{
				this.Message = oCancels.Message;
				ret = false;
			}
			return ret;
		}
		public bool Update(CancelData Entry)
		{
			bool ret = true;
	
			Cancels oCancels = new Cancels();
			//�ж��޸ĵ�ǰ��������
			if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
				Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
				Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
				Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
				Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass 
				)
			{
				if (oCancels.UpdateEntry(Entry) == false)
				{
					this.Message = oCancels.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "�ɹ��������������޸ĵ�ǰ��������";
				ret = false;
			}
			return ret;
		}
		public bool UpdateAndPresent(CancelData Entry)
		{
			bool ret = true;

			Cancels oCancels = new Cancels();
			CancelData oCancelData = oCancels.GetEntryByEntryNo(int.Parse(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryNo_Field].ToString()));
			
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass 
				)
			{
				if (oCancels.UpdateAndPresentEntry(Entry) == false)
				{
					this.Message = oCancels.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "�ɹ��������������޸ĵ�ǰ������!";
				ret = false;
			}
			return ret;
		}
		public bool Delete(int EntryNo)
		{
			bool ret=true;

			Cancels oCancels = new Cancels();
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//�жϲɹ�����ɾ����ǰ��������
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel)
			{
				if (oCancels.DeleteEntry(EntryNo) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "�ɹ�������������ɾ����ǰ������!";
				ret = false;
			}
			return ret;
		}
		public bool FirstAudit(CancelData Entry)
		{
			bool ret=true;
			int EntryNo;
			Cancels oCancels = new Cancels();
			EntryNo = int.Parse(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryNo_Field].ToString());
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//�ж�һ��������ǰ���������鿴����֮ǰ�ĵ���״̬�Ƿ���ָ�ɡ�
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Present)
			{
				//���û�н������ȷ�������б���
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit1_Field].ToString() != "Y" &&
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit1_Field].ToString() != "N")
				{
					this.Message = "��ȷ�������ͨ�����ǲ�ͨ����";
					ret = false;
				}
				//���������ͨ��������û��дԭ��
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit1_Field].ToString() == "N" &&
					(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest1_Field] == null ||
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest1_Field].ToString().Trim() == "") )
				{
					this.Message = "��д��������ͨ����ԭ��";
					return false;
				}
				if (oCancels.FirstAudit(Entry) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "�ɹ�������������һ��������ǰ��������";
				ret = false;
			}
			return ret;
		}
		public bool SecondAudit(CancelData Entry)
		{
			bool ret=true;
			int EntryNo;
			Cancels oCancels = new Cancels();
			EntryNo = int.Parse(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryNo_Field].ToString());
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//�ж�һ��������ǰ���������鿴����֮ǰ�ĵ���״̬�Ƿ���ָ�ɡ�
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstPass)
			{
				//���û�н������ȷ�������б���
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit2_Field].ToString() != "Y" &&
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit2_Field].ToString() != "N")
				{
					this.Message = "��ȷ�������ͨ�����ǲ�ͨ����";
					ret = false;
				}
				//���������ͨ��������û��дԭ��
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit2_Field].ToString() == "N" &&
					(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest2_Field] == null ||
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest2_Field].ToString().Trim() == "") )
				{
					this.Message = "��д��������ͨ����ԭ��";
					return false;
				}
				if (oCancels.SecondAudit(Entry) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "�ɹ������������϶���������ǰ��������";
				ret = false;
			}
			return ret;
		}
		public bool ThirdAudit(CancelData Entry)
		{
			bool ret=true;
			int EntryNo;
			Cancels oCancels = new Cancels();
			EntryNo = int.Parse(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryNo_Field].ToString());
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//�ж�һ��������ǰ���������鿴����֮ǰ�ĵ���״̬�Ƿ���ָ�ɡ�
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecPass)
			{
				//���û�н������ȷ�������б���
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit3_Field].ToString() != "Y" &&
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit3_Field].ToString() != "N")
				{
					this.Message = "��ȷ�������ͨ�����ǲ�ͨ����";
					ret = false;
				}
				//���������ͨ��������û��дԭ��
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit3_Field].ToString() == "N" &&
					(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest3_Field] == null ||
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest3_Field].ToString().Trim() == "") )
				{
					this.Message = "��д��������ͨ����ԭ��";
					return false;
				}
				if (oCancels.ThirdAudit(Entry) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "�ɹ�����������������������ǰ��������";
				ret = false;
			}
			return ret;
		}
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Cancels oCancels = new Cancels();
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//�ж�һ��������ǰ��������
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass)
			{
				if (oCancels.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "�ɹ��������������ύ��ǰ��������";
				ret = false;
			}
			return ret;
		}
		public bool XCancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;

			Cancels oCancels = new Cancels();
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//�ж�һ��������ǰ��������
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass)
			{
				if (oCancels.Cancel(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "�ɹ����������������ϵ�ǰ��������";
				ret = false;
			}
			return ret;
		}
		#endregion

		#region ���캯��
		public Cancel()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
