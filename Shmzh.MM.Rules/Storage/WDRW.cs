
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.SQLServerDAL;
    using System.Collections.Generic;
	/// <summary>
	/// ���ϵ���ҵ�����㡣
	/// </summary>
	public class WDRW :Messages,IInItem
	{
        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Grant();
        private IList<GrantInfo> grantinfo;

		#region ���캯��
		public WDRW()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// ���ϵ������ӡ�
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			// TODO:  ��� WDRW.Insert ʵ��
			bool ret = true;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			//�ж���û��ָ�����ϲֿ⡣
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = WDRWData.NoStorage;
				return false;
			}
			//�ж���û��ָ����;��
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = WDRWData.NoPurpose;
				return false;
			}
			//�ж���û��ָ�����ò��š�
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.ReqDept_Field].ToString() == "-1")
			{
				this.Message = WDRWData.NoDept;
				return false;
			}
			//�ж���û��ָ�������ˡ�
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PROPOSER_FIELD].ToString().Trim() == "")
			{
				this.Message = WDRWData.NoProposer;
				return false;
			}
			//ִ�����ϵ����½�������
			ret = oWDRWs.InsertEntry(Entry);
			this.Message = oWDRWs.Message;
			return ret;
		}
		/// <summary>
		/// ���ϵ����½����������ύ����
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  ��� WDRW.Insert ʵ��
			bool ret = true;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			//�ж���û��ָ�����ϲֿ⡣
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = WDRWData.NoStorage;
				return false;
			}
			//�ж���û��ָ����;��
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = WDRWData.NoPurpose;
				return false;
			}
			//�ж���û��ָ�����ò��š�
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.ReqDept_Field].ToString() == "-1")
			{
				this.Message = WDRWData.NoDept;
				return false;
			}
			//�ж���û��ָ�������ˡ�
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PROPOSER_FIELD].ToString().Trim() == "")
			{
				this.Message = WDRWData.NoProposer;
				return false;
			}
			//ִ�����ϵ����½����������ύ������
			ret = oWDRWs.InsertAndPresentEntry(Entry);
			this.Message = oWDRWs.Message;
			return ret;
		}
		/// <summary>
		/// ���ϵ����޸ġ�
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			// TODO:  ��� WDRW.Update ʵ��
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			//�ж����ϵ��޸ĵ�ǰ��������
			if ( this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId) )
			{
				//�ж���û��ָ�����ϲֿ⡣
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.STOCODE_FIELD].ToString() == "-1")
				{
					this.Message = WDRWData.NoStorage;
					return false;
				}
				//�ж���û��ָ����;��
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WDRWData.NoPurpose;
					return false;
				}
				//�ж���û��ָ�����ò��š�
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.ReqDept_Field].ToString() == "-1")
				{
					this.Message = WDRWData.NoDept;
					return false;
				}
				//�ж���û��ָ�������ˡ�
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PROPOSER_FIELD].ToString().Trim() == "")
				{
					this.Message = WDRWData.NoProposer;
					return false;
				}
				//ִ�����ϵ����½�������
				ret = oWDRWs.UpdateEntry(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ����޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  ��� WDRW.Update ʵ��
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			//�ж����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				//�ж���û��ָ�����ϲֿ⡣
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.STOCODE_FIELD].ToString() == "-1")
				{
					this.Message = WDRWData.NoStorage;
					return false;
				}
				//�ж���û��ָ����;��
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WDRWData.NoPurpose;
					return false;
				}
				//�ж���û��ָ�����ò��š�
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.ReqDept_Field].ToString() == "-1")
				{
					this.Message = WDRWData.NoDept;
					return false;
				}
				//�ж���û��ָ�������ˡ�
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PROPOSER_FIELD].ToString().Trim() == "")
				{
					this.Message = WDRWData.NoProposer;
					return false;
				}
				//ִ�����ϵ����½�������
				ret = oWDRWs.UpdateAndPresentEntry(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			bool ret = true;
			WDRWs oWDRWs = new WDRWs();
			//�ж����ϵ�ɾ����ǰ��������
			if (this.CheckPreCondition(EntryNo,OP.Delete))
			{
				ret =  oWDRWs.DeleteEntry(EntryNo);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XDelete;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo,string UserLoginId)
		{
			 bool ret = true;
			WDRWs oWDRWs = new WDRWs();
			//�ж����ϵ�ɾ����ǰ��������
			if (this.CheckPreCondition(EntryNo,OP.Delete,UserLoginId))
			{
				ret = oWDRWs.DeleteEntry(EntryNo);
				this.Message = oWDRWs.Message;
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ���״̬�ı䡣
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬ ��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  ��� WDRW.UpdateEntryState ʵ��
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();

			ret = oWDRWs.UpdateEntryState(EntryNo,newState);
			this.Message=oWDRWs.Message;
			return ret;
		}
		/// <summary>
		/// ���ϵ���һ��������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  ��� WDRW.FirstAduit ʵ��
			bool ret = true;
			int EntryNo;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//�ж����ϵ�һ��������ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.FirstAudit))
			{
				ret = oWDRWs.FirstAudit(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ��Ķ���������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  ��� WDRW.SecondAduit ʵ��
			bool ret = true;
			int EntryNo;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//�ж����ϵ�����������ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.SecondAudit) )
			{
				ret = oWDRWs.SecondAudit(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XSecondAudit ;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�������������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  ��� WDRW.ThirdAduit ʵ��
			bool ret = true;
			int EntryNo;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//�ж����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo,OP.ThirdAudit) )
			{
				ret = oWDRWs.ThirdAudit(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XThirdAudit;
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
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//�ж����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId) )
			{
				ret = oWDRWs.Present(EntryNo, newState, UserLoginId);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
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
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//�ж����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Cancel) )
			{
				ret = oWDRWs.Cancel(EntryNo, newState);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//�ж����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginId) )
			{
				ret = oWDRWs.Cancel(EntryNo, newState,UserLoginId);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ��ܷ���
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Refuse(int EntryNo, string UserLoginId)
		{
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//�ж����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.O) )
			{
				ret = oWDRWs.DrawRefuse(EntryNo, UserLoginId);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XRefuse;
				ret = false;
			}
			return ret;
		}
		public bool DRW2PROS(int EntryNo)
		{
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//�ж����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo,OP.O) )
			{
				ret = oWDRWs.Draw2Pros(EntryNo);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "���ݲ����������빺��������";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �������ϵ�����ˮ������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  ��� WDRW.GetEntryByEntryNo ʵ��
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryNo(EntryNo);
			return oWDRWData;
		}

        /// <summary>
        /// �������ϵ�����ˮ������ȡ���ݡ�
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>object:	����ʵ�塣</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            // TODO:  ��� WDRW.GetEntryByEntryNo ʵ��
            WDRWData oWDRWData;
            WDRWs oWDRWs = new WDRWs();
            oWDRWData = (WDRWData)oWDRWs.GetEntryOldByEntryNo(EntryNo);
            return oWDRWData;
        }

		/// <summary>
		/// �������ϵ��ı������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  ��� WDRW.GetEntryByEntryCode ʵ��
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryCode(EntryCode);
			return oWDRWData;
		}
		/// <summary>
		/// ��ȡ�������ϵ���
		/// </summary>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryAll()
		{
			// TODO:  ��� WDRW.GetEntryAll ʵ��
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryAll();
			return oWDRWData;
		}
		/// <summary>
		/// ��ȡָ���Ƶ����ŵ����ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  ��� WDRW.GetEntryByDept ʵ��
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByDept(DeptCode);
			return oWDRWData;
		}

		#endregion

		#region ר�з���
		/// <summary>
		/// ����ģʽ�»�ȡ���ϵ������ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			// TODO:  ��� WDRW.GetEntryByEntryNo ʵ��
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryNoOutMode(EntryNo);
			return oWDRWData;
		}
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="Operation">string:	�������롣</param>
		/// <returns>bool:	����ǰ����������true,�����Ϸ���false��</returns>
		public bool CheckPreCondition(int EntryNo, string Operation)
		{
			bool ret = false;
			string EntryState;
			
			if (Operation == OP.New)
			{
				return true;
			}
			WDRWData oWDRWData;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryNo(EntryNo);	//2005-10-21�޸�,�޸�ǰ�����������.GetEntryByEntryNoOutMode������
			
			if (oWDRWData.Count > 0)
			{
				EntryState = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				switch (Operation)
				{
					case OP.Edit://�༭��
						if (EntryState == DocStatus.New || 
							EntryState == DocStatus.Cancel || 
							EntryState == DocStatus.FstNoPass || 
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
							EntryState == DocStatus.OrdReject
							)
						{
							return true;
						}
						else
						{
							ret = false;
						}
						break;
					case OP.Submit://�ύ��
						if (EntryState == DocStatus.New)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
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
					case OP.Cancel://���ϡ�
						if (EntryState == DocStatus.New ||
							EntryState == DocStatus.FstNoPass ||
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
							EntryState == DocStatus.OrdReject)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
					case OP.Delete://ɾ����
						if (EntryState == DocStatus.Cancel)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
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
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
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
			WDRWData oWDRWData;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryNo(EntryNo);   //2005-10-21�޸�,�޸�ǰ�����������.GetEntryByEntryNoOutMode������

			if (oWDRWData.Count > 0)
			{
				EntryState = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
				switch (Operation)
				{
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
