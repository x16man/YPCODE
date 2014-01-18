
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// WTRF ��ժҪ˵����
	/// </summary>
	public class WTRF:Messages,IInItem
	{
		#region ���캯��
		public WTRF()
		{
			
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// ת�ⵥ¼�롣
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			bool ret=true;
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			
			//����ͨ�����б��������
			WTRFs oWTRFs = new WTRFs();

			if (oWTRFs.InsertEntry(Entry) == false)
			{
				this.Message = oWTRFs.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// �½��������ύת�ⵥ.
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥ��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  ��� WTRF.Insert ʵ��
			bool ret=true;
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			
			//����ͨ�����б��������
			WTRFs oWTRFs=new WTRFs();

			if (oWTRFs.InsertAndPresentEntry(Entry)==false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ת�ⵥ�޸ġ�
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			// TODO:  ��� WTRF.Update ʵ��
			bool ret=true;
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			{
				this.Message = WTRFData.XUpdate;
				return false;
			}
			
			//����ͨ�����б��������
			WTRFs oWTRFs=new WTRFs();

			if (oWTRFs.UpdateEntry(Entry)==false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �޸Ĳ����ύת�ⵥ.
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  ��� WTRF.Update ʵ��
			bool ret=true;
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
//			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = WTRFData.XUpdate;
//				return false;
//			}
//			//�����;��
//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][WTRFData.REQREASONCODE_FIELD].ToString() =="-1")//δָ����;��
//			{
//				this.Message = WTRFData.NoPurpose;
//				ret = false;
//				return ret;
//			}
//			//������벿�š�
//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][WTRFData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
//			{
//				this.Message = WTRFData.NoReqDept;
//				ret = false;
//				return ret;
//			}
//			//��������ˡ�
//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][WTRFData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
//			{
//				this.Message = WTRFData.NoProposer;
//				ret = false;
//				return ret;
//			}
			//����ͨ�����б��������
			WTRFs oWTRFs=new WTRFs();

			if (oWTRFs.UpdateAndPresentEntry(Entry)==false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ת�ⵥɾ����
		/// </summary>
		/// <param name="EntryNo">int:	 ת�ⵥ��ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  ��� WTRF.Delete ʵ��
			bool ret=true;
			WTRFData oWTRFData;

			WTRFs oWTRFs=new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			if (oWTRFData != null && oWTRFData.Count > 0)
			{
				//�������������״̬������ɾ����
				if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oWTRFs.DeleteEntry(EntryNo)==false)
					{
						this.Message=oWTRFs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WTRFData.XDelete;
					ret = false;
				}
			}
			
			return ret;
		}
		/// <summary>
		/// �޸ĵ���״̬.
		/// </summary>
		/// <param name="EntryNo">int:	ת�ⵥ��ˮ��.</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  ��� WTRF.UpdateEntryState ʵ��
			bool ret=true;

			WTRFs oWTRFs=new WTRFs();

			if (oWTRFs.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  ��� WTRF.FirstAduit ʵ��
			bool ret=true;

			WTRFs oWTRFs=new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;

			//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			//			{
			if (oWTRFs.FirstAudit(Entry) == false)
			{
				this.Message = oWTRFs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WTRFData.XFirstAudit;
			//				ret = false;
			//			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  ��� WTRF.SecondAduit ʵ��
			bool ret=true;

			WTRFs oWTRFs=new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			//ת�ⵥ����������ǰ��������һ������ͨ����
			//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			//			{
			if (oWTRFs.SecondAudit(Entry) == false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WTRFData.XSecondAudit;
			//				ret =false;
			//			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	ת�ⵥʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  ��� WTRF.ThirdAduit ʵ��
			bool ret = true;

			WTRFs oWTRFs = new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			//ת�ⵥ����������ǰ��������һ������ͨ����
			//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			//			{
			if (oWTRFs.ThirdAudit(Entry) == false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WTRFData.XThirdAudit;
			//				ret = false;
			//			}
			return ret;
		}
		/// <summary>
		/// ת�ⵥ�ύ��
		/// </summary>
		/// <param name="EntryNo">int:	ת�ⵥ��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			WTRFData oWTRFData;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���Ĳ������ύ��
			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWTRFs.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oWTRFs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = WTRFData.XPresent;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ת�ⵥ���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	ת�ⵥ��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			WTRFs oWTRFs = new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���������ϣ�
			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWTRFs.Cancel(EntryNo, newState) == false)
				{
					this.Message = oWTRFs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WTRFData.XCancel;
				ret = false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WTRFs oWTRFs = new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���������ϣ�
			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWTRFs.Cancel(EntryNo, newState,UserLoginId) == false)
				{
					this.Message = oWTRFs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WTRFData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����ת�ⵥ��ˮ�Ż�ȡת�ⵥ������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	ת�ⵥ��ˮ�š�</param>
		/// <returns>object:	ת�ⵥ����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			return oWTRFData;
		}
		/// <summary>
		/// ����ת�ⵥ��Ż�ȡת�ⵥ������Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	ת�ⵥ��š�</param>
		/// <returns>object:	ת�ⵥ����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryCode(EntryCode);
			return oWTRFData;
		}
		/// <summary>
		/// ��ȡ����ת�ⵥ��
		/// </summary>
		/// <returns>object:	ת�ⵥ����ʵ�塣</returns>
		public object GetEntryAll()
		{
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryAll();
			return oWTRFData;
		}
		/// <summary>
		/// ��ȡָ�����벿�ŵ�ת�ⵥ��
		/// </summary>
		/// <param name="DeptCode">string:	���벿�ű�š�</param>
		/// <returns>object:	ת�ⵥ����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByDept(DeptCode);
			return oWTRFData;
		}

		#endregion

		#region ת�ⵥר�з���
		public WTRFData GetWTRFSAll()
		{
			WTRFData oWTRFData;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = oWTRFs.GetWTRFAll();
			return oWTRFData;
		}
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			WTRFs oWTRFs = new WTRFs();

			if (oWTRFs.Affirm(EntryNo, newState, UserLoginId) == false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			return ret;
		}
		public WTRFData GetWTRFSByPKIDs(string PKIDs)
		{
			WTRFData oWTRFData;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = oWTRFs.GetWTRFByPKIDs(PKIDs);
			return oWTRFData;
		}
		
					   
					   
		#endregion

		#region ת��ר�з���
		/// <summary>
		/// ת��ģʽ�»�ȡת�ⵥ�����ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			// TODO:  ��� WTRF.GetEntryByEntryNo ʵ��
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNoOutMode(EntryNo);
			return oWTRFData;
		}
		/// <summary>
		/// ת��ģʽ�»�ȡת�ⵥ�����ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			// TODO:  ��� WTRF.GetEntryByEntryNo ʵ��
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNoInMode(EntryNo);
			return oWTRFData;
		}
		/// <summary>
		/// ת�����ϵ����ϲ�����
		/// </summary>
		/// <param name="Entry">object:	���ϵ�����</param>
		/// <returns>bool:	���ϳɹ�����true��ʧ�ܷ���false��</returns>
		
		#endregion
	}
	}

