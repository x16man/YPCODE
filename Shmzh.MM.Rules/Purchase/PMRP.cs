
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.SQLServerDAL;
    using System.Collections.Generic;

	/// <summary>
	/// �������󵥵�ҵ�����㡣
	/// </summary>
	public class PMRP :Messages,IInItem
	{
        private IList<GrantInfo> grantinfo;
        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Grant();
		#region ���캯��
		public PMRP()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// �������󵥵����ӡ�
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			// TODO:  ��� PMRP.Insert ʵ��
			bool ret = true;
			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)Entry;
			//�ж��Ƿ���д����;��
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = PMRPData.NoPurpose;
				return false;
			}
			//�ж��Ƿ���д�����벿�š�
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQDEPT_FIELD].ToString() == "-1")
			{
				this.Message = PMRPData.NoReqDept;
				return false;
			}
			//�ж��Ƿ���д�������ˡ�
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.PROPOSER_FIELD].ToString().Trim() == "")
			{
				this.Message = PMRPData.NoProposer;
				return false;
			}
			//ִ������������
			ret = oPMRPs.InsertEntry(Entry);
			this.Message=oPMRPs.Message;
			return ret;
		}
		/// <summary>
		/// �������󵥵����Ӳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  ��� PMRP.Insert ʵ��
			bool ret = true;

			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)Entry;
			//�ж��Ƿ���д����;��
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = PMRPData.NoPurpose;
				return false;
			}
			//�ж��Ƿ���д�����벿�š�
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQDEPT_FIELD].ToString() == "-1")
			{
				this.Message = PMRPData.NoReqDept;
				return false;
			}
			//�ж��Ƿ���д�������ˡ�
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.PROPOSER_FIELD].ToString().Trim() == "")
			{
				this.Message = PMRPData.NoProposer;
				return false;
			}
			//ִ�����������ύ������
			ret = oPMRPs.InsertAndPresentEntry(Entry);
			this.Message=oPMRPs.Message;
			return ret;
		}
		/// <summary>
		/// �������󵥵��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			// TODO:  ��� PMRP.Update ʵ��
			bool ret = true;
			int EntryNo;
			string UserLoginId;

			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)Entry;
			
			EntryNo = Convert.ToInt32(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

//			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				//�ж��Ƿ���д����;��
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = PMRPData.NoPurpose;
					return false;
				}
				//�ж��Ƿ���д�����벿�š�
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = PMRPData.NoReqDept;
					return false;
				}
				//�ж��Ƿ���д�������ˡ�
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.PROPOSER_FIELD].ToString().Trim() == "")
				{
					this.Message = PMRPData.NoProposer;
					return false;
				}
				//ִ���޸Ĳ�����
				ret = oPMRPs.UpdateEntry(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "����Ȩ���д˲���!";
				return false;
			}
		}
		/// <summary>
		/// �������󵥵��޸Ĳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  ��� PMRP.Update ʵ��
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)Entry;

			EntryNo = Convert.ToInt32(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

//			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
//			
//			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				oPMRPData = (PMRPData)Entry;
				//�ж��Ƿ���д����;��
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = PMRPData.NoPurpose;
					return false;
				}
				//�ж��Ƿ���д�����벿�š�
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = PMRPData.NoReqDept;
					return false;
				}
				//�ж��Ƿ���д�������ˡ�
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.PROPOSER_FIELD].ToString().Trim() == "")
				{
					this.Message = PMRPData.NoProposer;
					return false;
				}
				//ִ���޸Ĳ����ύ������
				ret = oPMRPs.UpdateAndPresentEntry(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "����Ȩ���д˲���!";
				return false;
			}
		}
		/// <summary>
		/// �������󵥵�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  ��� PMRP.Delete ʵ��
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
			//�ж��Ƿ����ɾ����������ֻ�д�������״̬�ĵ��ݲű�����ɾ����
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
			{
				ret = oPMRPs.DeleteEntry(EntryNo);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XDelete;
				return false;
			}
		}
		/// <summary>
		/// �������󵥵�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			// TODO:  ��� PMRP.Delete ʵ��
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
			//�ж��Ƿ����ɾ����������ֻ�д�������״̬�ĵ��ݲű�����ɾ����
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				ret = oPMRPs.DeleteEntry(EntryNo);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "����Ȩ���д˲���!";
				return false;
			}
		}
		/// <summary>
		/// �������󵥵�״̬�ı䡣
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬ ��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  ��� PMRP.UpdateEntryState ʵ��
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			
			ret = oPMRPs.UpdateEntryState(EntryNo,newState);
			this.Message=oPMRPs.Message;
			return ret;
			
		}
		/// <summary>
		/// �������󵥵�һ��������
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  ��� PMRP.FirstAduit ʵ��
			bool ret = true;
			
			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)Entry;
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж��Ƿ����һ��������������ֻ�д����ύ״̬�ĵ��ݲű�����һ��������
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				ret = oPMRPs.FirstAudit(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XFirstAudit;
				return false;
			}
		}

        public bool IsAuditDept(string strEmpCode, int EntryNo)
        {
            PMRPs oPMRPs = new PMRPs();
            return oPMRPs.IsAuditDept(strEmpCode, EntryNo);
        }
		/// <summary>
		/// �������󵥵Ķ���������
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  ��� PMRP.SecondAduit ʵ��
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)Entry;
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж��Ƿ���϶���������������ֻ�д���һ������ͨ��״̬�ĵ��ݲű��������������
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				ret = oPMRPs.SecondAudit(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XSecondAudit;
				return false;
			}
		}
		/// <summary>
		/// �������󵥵�����������
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  ��� PMRP.ThirdAduit ʵ��
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)Entry;
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//�ж��Ƿ��������������������ֻ�д��ڶ�������ͨ��״̬�ĵ��ݲű���������������
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{
				ret = oPMRPs.ThirdAudit(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XThirdAudit;
				return false;
			}
		}
		/// <summary>
		/// ���������ύ��
		/// </summary>
		/// <param name="EntryNo">int:	����������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
//			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
//			//�ж��Ƿ�����ύ��������ֻ�д����½���������ͨ��������״̬�ĵ��ݲű������ύ��
//			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId))
			{
				ret = oPMRPs.Present(EntryNo, newState, UserLoginId);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "����Ȩ���д˲���!";
				return false;
			}
		}
		/// <summary>
		/// �����������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	����������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
			//�ж��Ƿ�������ϵ�������ֻ�д����½���������ͨ����ͨ��״̬�ĵ��ݲű��������������
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			{
				ret = oPMRPs.Cancel(EntryNo, newState);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XCancel;
				return false;
			}
		}
		/// <summary>
		/// �����������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	����������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginID">string:	operator.</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
//			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
//			//�ж��Ƿ�������ϵ�������ֻ�д����½���������ͨ����ͨ��״̬�ĵ��ݲű��������������
//			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginID))
			{
				ret = oPMRPs.Cancel(EntryNo, newState, UserLoginID);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "����Ȩ���д˲���!";
				return false;
			}
		}
		/// <summary>
		/// �����������󵥵���ˮ������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  ��� PMRP.GetEntryByEntryNo ʵ��
			PMRPData oPMRPData ;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
			return oPMRPData;
		}
		/// <summary>
		/// �����������󵥵ı������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  ��� PMRP.GetEntryByEntryCode ʵ��
			PMRPData oPMRPData ;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryCode(EntryCode);
			return oPMRPData;
		}
		/// <summary>
		/// ��ȡ�����������󵥡�
		/// </summary>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryAll()
		{
			// TODO:  ��� PMRP.GetEntryAll ʵ��
			PMRPData oPMRPData ;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryAll();
			return oPMRPData;
		}
		/// <summary>
		/// ��ȡָ���Ƶ����ŵ��������󵥡�
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  ��� PMRP.GetEntryByDept ʵ��
			PMRPData oPMRPData ;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryByDept(DeptCode);
			return oPMRPData;
		}

		#endregion
		#region ר�÷���
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	����������ˮ�š�</param>
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
			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);   

			if (oPMRPData.Count > 0)
			{
				EntryState = oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
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
							//Grants oG = new Grants();
                           
							//oG.GetEmbracersByGrantor(AuthorLoginID);
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
