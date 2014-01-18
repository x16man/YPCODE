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
    using Shmzh.MM.Common;
    using Shmzh.MM.DataAccess;
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.SQLServerDAL;
    using System.Collections.Generic;
    
		/// <summary>
	/// PurchasePlan ��ժҪ˵����
	/// </summary>
	public class PurchasePlan :Messages,IInItem  
	{

        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Grant();
        private IList<GrantInfo> grantinfo;

		#region ���캯��
		public PurchasePlan()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// �ɹ��ƻ����롣
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			bool ret = true;

			PurchasePlans oPurchasePlans = new PurchasePlans();

			if (oPurchasePlans.InsertEntry(Entry) == false)
			{
				this.Message = oPurchasePlans.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ����벢���ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;

			PurchasePlans oPurchasePlans = new PurchasePlans();

			if (oPurchasePlans.InsertAndPresentEntry(Entry) == false)
			{
				this.Message = oPurchasePlans.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			EntryNo = Convert.ToInt32(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			//�ж��޸ĵ�ǰ��������
//			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				if (oPurchasePlans.UpdateEntry(Entry) == false)
				{
					this.Message = oPurchasePlans.Message;
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
		/// �ɹ��ƻ��޸Ĳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			EntryNo = Convert.ToInt32(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(int.Parse(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж��޸ĵ�ǰ��������
//			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				if (oPurchasePlans.UpdateAndPresentEntry(Entry) == false)
				{
					this.Message = oPurchasePlans.Message;
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
		/// �ɹ��ƻ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//�ж��޸ĵ�ǰ��������
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
			{
				if (oPurchasePlans.DeleteEntry(EntryNo) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XDelete;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û�.</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo,string UserLoginId)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			//PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//�ж��޸ĵ�ǰ��������
			//if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				if (oPurchasePlans.DeleteEntry(EntryNo) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
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
		/// �ɹ��ƻ�����״̬��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();

			if (oPurchasePlans.UpdateEntryState(EntryNo,newState) == false)
			{
				this.Message=oPurchasePlans.Message;
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ�һ��������
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(int.Parse(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж��޸ĵ�ǰ��������
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				if (oPurchasePlans.FirstAudit(Entry) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XFirstAudit;
				ret =false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ��ƻ�����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(int.Parse(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж��޸ĵ�ǰ��������
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oPurchasePlans.SecondAudit(Entry) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XSecondAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ��ƻ�����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(int.Parse(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж��޸ĵ�ǰ��������
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{
				if (oPurchasePlans.ThirdAudit(Entry) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XThirdAudit;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			//PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//�ж��޸ĵ�ǰ��������
//			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId))
			{
				if (oPurchasePlans.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
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
		/// �ɹ��ƻ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//�ж��޸ĵ�ǰ��������
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			{
				if (oPurchasePlans.Cancel(EntryNo, newState) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XCancel;
				ret = false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState,string UserLoginID)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			//PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//�ж��޸ĵ�ǰ��������
//			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginID))
			{
				if (oPurchasePlans.Cancel(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
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
		/// ���ݲɹ��ƻ���ˮ�Ż�ȡ�ɹ��ƻ�������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>object:	�ɹ��ƻ�����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			return oPurchasePlanData;
		}
		
		public object GetPPByEntryNoGroupByDep(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetPPByEntryNoGroupByDep(EntryNo);
			return oPurchasePlanData;
		}
		/// <summary>
		/// ���ݲɹ��ƻ���Ż�ȡ�ɹ��ƻ�������Ϣ��
		/// </summary>
		/// <param name="EntryNo">string:	�ɹ��ƻ���š�</param>
		/// <returns>object:	�ɹ��ƻ�����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryCode(EntryCode);
			return oPurchasePlanData;
		}
		/// <summary>
		/// ��ȡ���вɹ��ƻ���
		/// </summary>
		/// <returns>object:	�ɹ��ƻ�����ʵ�塣</returns>
		public object GetEntryAll()
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryAll();
			return oPurchasePlanData;
		}
		/// <summary>
		/// ���ݲɹ��ƻ��Ƶ����ű�Ż�ȡ�ɹ��ƻ���Ϣ��
		/// </summary>
		/// <param name="DeptCode">string:	�ɹ��ƻ��Ƶ����ű�š�</param>
		/// <returns>object:	�ɹ��ƻ�����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryByDept(DeptCode);
			return oPurchasePlanData;
		}

		#endregion

		#region �ɹ��ƻ�ר�÷���
		/// <summary>
		/// ��ȡ���вɹ��ƻ���������Դ��
		/// </summary>
		/// <returns></returns>
		public PPSData GetPPSAll(string UserLoginId)
		{
			int RepeatItemCount = 0;
			int Count = 0;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			PPSData oPPSData;
			oPPSData = oPurchasePlans.GetPPSALL(UserLoginId);
			Count = oPPSData.Count;//�ɹ��ƻ���ϸ���ݵļ�¼����
			RepeatItemCount = oPPSData.RepeatItemCount;//�ɹ��ƻ����ظ����ϵ�������
			//����ɹ��ƻ������д������ظ�����,�����ÿ���ظ����ϵļƻ���¼���·���ƻ�����.
			if (RepeatItemCount > 0)
			{
				string itemcode;
				decimal price,plannum;
				int count;
				decimal itemlacknum = 0;
				for (int i = 0; i < RepeatItemCount; i++)
				{
					int lowstockindex = -1;//�Ϳ���¼���кų�ʼ��Ϊ-1��
					//���ϱ�š�
					itemcode = oPPSData.Tables[PPSData.PLANNUM_TABLE].Rows[i][PPSData.ITEMCODE_FIELD].ToString();
					//�ɹ��ƻ�������
					plannum = Convert.ToDecimal(oPPSData.Tables[PPSData.PLANNUM_TABLE].Rows[i][PPSData.ITEMNUM_FIELD].ToString());
					//�������ڲɹ��ƻ��е��ظ�������
					count = Convert.ToInt32(oPPSData.Tables[PPSData.PLANNUM_TABLE].Rows[i][PPSData.COUNT_FIELD].ToString());
					
					for (int j = 0; j < Count; j++)
					{
						if (count > 0 && oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMCODE_FIELD].ToString() == itemcode)
						{
							itemlacknum = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMLACKNUM_FIELD].ToString());
							if ( itemlacknum > 0)//������ǵͿ���¼���Ϳ���¼��itemlacknum = 0;
							{
								if ( itemlacknum >= plannum)
								{
									oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = plannum;
									price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
									oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = plannum*price;
									plannum = 0;
									count = count -1;//��ʾ�Ѵ�����һ����
									if (count == 0)//������ظ������Ѿ�������ϣ�������ѭ����
									{ break; }
								}
								else//�������������С�ڲɹ��ƻ�������
								{
									count = count - 1;//��ʾ�Ѵ�����һ����

									/*����Ѿ������һ���ظ���¼������֮ǰû�еͿ���¼��
									 * ����ʣ��ļƻ���������������������ô�����ɲɹ�������ɵġ�
									 * ��ʱ�򣬾ͽ���ʣ��Ĳɹ��ƻ����������ӵ������һ�������¼�ϡ�
									 */
									if (count == 0 && lowstockindex == -1)
									{
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = plannum;
										price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = plannum*price;
										break;//����ѭ����
									}
									/*��������һ����¼������֮ǰ�й�һ���Ϳ��ļ�¼��
									* ����ʣ����������ڱ������¼������������ô�ͱ���
									* �����¼ֻ�е��������������������Ĳɹ��ƻ�����
									* �ɵͿ��������¼���е���
									*/ 
									if (count == 0 && lowstockindex > -1)
									{
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = itemlacknum;
										price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = itemlacknum*price;
										plannum = plannum - itemlacknum;
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[lowstockindex][PPSData.ITEMNUM_FIELD] = plannum;
										break;//����ѭ����
									}
									/*����������һ�����¼������֮ǰҲû�й��Ϳ���¼��
									 * ����ʣ��Ĳɹ��ƻ��������ڱ���������������
									 * ������¼ֻ�е����������������
									 */ 
									if (count > 0 && lowstockindex == -1)
									{
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = itemlacknum;
										price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = itemlacknum*price;
										plannum = plannum - itemlacknum;
									}
									/*����������һ�������¼������֮ǰ�Ѿ����ֹ�һ���Ϳ���¼��
									 * ����ʣ��Ĳɹ��ƻ��������ڱ���������������
									 * ������¼ֻ�е����������������
									 */
									if (count > 0 && lowstockindex > -1)
									{
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = itemlacknum;
										price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = itemlacknum*price;
										plannum = plannum - itemlacknum;
									}
									
								}
							}
							else//�ǵͿ���¼���Ϳ���¼���������м��㡣
							{
								lowstockindex = j;//�����ϵͿ���¼���кš�
								count = count - 1;
								/*��������Ϳ���¼���ظ����ϵ����һ����¼��
								 * ��е����е�ʣ��ɹ��ƻ����������򣬲�����
								 * �κδ���������¼�������кš���������ٴ���
								 */ 
								if (count == 0)
								{
									oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = plannum;
									price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
									oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = plannum*price;
									break;//����ѭ����
								}
							}
							
						}
					}
				}
				//End Of����ɹ��ƻ������д������ظ�����,�����ÿ���ظ����ϵļƻ���¼���·���ƻ�����.
			}
			return oPPSData;
		}
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
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
			PurchasePlanData oPurchasePlanData;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);   

			if (oPurchasePlanData.Count > 0)
			{
				EntryState = oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
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
                            grant = new Grant();
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
						if (EntryState == DocStatus.New)
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
