
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// WADJ ��ժҪ˵����
	/// </summary>
	public class WADJ:Messages,IInItem
	{
		#region ���캯��
		public WADJ()
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
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			
			//����ͨ�����б��������
			WADJs oWADJs = new WADJs();

			if (oWADJs.InsertEntry(Entry) == false)
			{
				this.Message = oWADJs.Message;
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
			// TODO:  ��� WADJ.Insert ʵ��
			bool ret=true;
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			
			//����ͨ�����б��������
			WADJs oWADJs=new WADJs();

			if (oWADJs.InsertAndPresentEntry(Entry)==false)
			{
				this.Message=oWADJs.Message;
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
			// TODO:  ��� WADJ.Update ʵ��
			bool ret=true;
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			{
				this.Message = WADJData.XUpdate;
				return false;
			}
			
			//����ͨ�����б��������
			WADJs oWADJs=new WADJs();

			if (oWADJs.UpdateEntry(Entry)==false)
			{
				this.Message=oWADJs.Message;
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
			// TODO:  ��� WADJ.Update ʵ��
			bool ret=true;
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			//			//�޸ĵ�ǰ�����½������ϣ�������ͨ����
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
			//				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
			//				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
			//				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
			//				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			//			{
//			this.Message = WADJData.XUpdate;
//			return false;
			//			}
			//			//�����;��
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][WADJData.REQREASONCODE_FIELD].ToString() =="-1")//δָ����;��
			//			{
			//				this.Message = WADJData.NoPurpose;
			//				ret = false;
			//				return ret;
			//			}
			//			//������벿�š�
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][WADJData.REQDEPT_FIELD].ToString() =="-1")//δָ�����벿�š�
			//			{
			//				this.Message = WADJData.NoReqDept;
			//				ret = false;
			//				return ret;
			//			}
			//			//��������ˡ�
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][WADJData.PROPOSER_FIELD].ToString().Trim() =="")//δָ�������ˡ�
			//			{
			//				this.Message = WADJData.NoProposer;
			//				ret = false;
			//				return ret;
			//			}
			//����ͨ�����б��������
			WADJs oWADJs=new WADJs();

			if (oWADJs.UpdateAndPresentEntry(Entry)==false)
			{
				this.Message=oWADJs.Message;
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
			// TODO:  ��� WADJ.Delete ʵ��
			bool ret=true;
			WADJData oWADJData;

			WADJs oWADJs=new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNo(EntryNo);
			if (oWADJData != null && oWADJData.Count > 0)
			{
				//�������������״̬������ɾ����
				if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oWADJs.DeleteEntry(EntryNo)==false)
					{
						this.Message=oWADJs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WADJData.XDelete;
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
			// TODO:  ��� WADJ.UpdateEntryState ʵ��
			bool ret=true;

			WADJs oWADJs=new WADJs();

			if (oWADJs.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oWADJs.Message;
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
			// TODO:  ��� WADJ.FirstAduit ʵ��
			bool ret=true;

			WADJs oWADJs=new WADJs();
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;

			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			//			{
			if (oWADJs.FirstAudit(Entry) == false)
			{
				this.Message = oWADJs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WADJData.XFirstAudit;
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
			// TODO:  ��� WADJ.SecondAduit ʵ��
			bool ret=true;

			WADJs oWADJs=new WADJs();
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			//ת�ⵥ����������ǰ��������һ������ͨ����
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			//			{
			if (oWADJs.SecondAudit(Entry) == false)
			{
				this.Message=oWADJs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WADJData.XSecondAudit;
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
			// TODO:  ��� WADJ.ThirdAduit ʵ��
			bool ret = true;

			WADJs oWADJs = new WADJs();
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			//ת�ⵥ����������ǰ��������һ������ͨ����
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			//			{
			if (oWADJs.ThirdAudit(Entry) == false)
			{
				this.Message=oWADJs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WADJData.XThirdAudit;
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
			WADJData oWADJData;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���Ĳ������ύ��
			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWADJs.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oWADJs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = WADJData.XPresent;
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

			WADJs oWADJs = new WADJs();
			WADJData oWADJData;
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNo(EntryNo);
			//����״̬Ϊ�½���������ͨ���������ϣ�
			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWADJs.Cancel(EntryNo, newState) == false)
				{
					this.Message = oWADJs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WADJData.XCancel;
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
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNo(EntryNo);
			return oWADJData;
		}
		/// <summary>
		/// ����ת�ⵥ��Ż�ȡת�ⵥ������Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	ת�ⵥ��š�</param>
		/// <returns>object:	ת�ⵥ����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryCode(EntryCode);
			return oWADJData;
		}
		/// <summary>
		/// ��ȡ����ת�ⵥ��
		/// </summary>
		/// <returns>object:	ת�ⵥ����ʵ�塣</returns>
		public object GetEntryAll()
		{
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryAll();
			return oWADJData;
		}
		/// <summary>
		/// ��ȡָ�����벿�ŵ�ת�ⵥ��
		/// </summary>
		/// <param name="DeptCode">string:	���벿�ű�š�</param>
		/// <returns>object:	ת�ⵥ����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByDept(DeptCode);
			return oWADJData;
		}

		#endregion

		#region ת�ⵥר�з���
		public WADJData GetWADJSAll()
		{
			WADJData oWADJData;
			WADJs oWADJs = new WADJs();
			oWADJData = oWADJs.GetWADJAll();
			return oWADJData;
		}
		public WADJData GetWADJSByPKIDs(string PKIDs)
		{
			WADJData oWADJData;
			WADJs oWADJs = new WADJs();
			oWADJData = oWADJs.GetWADJByPKIDs(PKIDs);
			return oWADJData;
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
			// TODO:  ��� WADJ.GetEntryByEntryNo ʵ��
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNoOutMode(EntryNo);
			return oWADJData;
		}
		/// <summary>
		/// ת��ģʽ�»�ȡת�ⵥ�����ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			// TODO:  ��� WADJ.GetEntryByEntryNo ʵ��
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNoInMode(EntryNo);
			return oWADJData;
		}
		/// <summary>
		/// ת�����ϵ����ϲ�����
		/// </summary>
		/// <param name="Entry">object:	���ϵ�����</param>
		/// <returns>bool:	���ϳɹ�����true��ʧ�ܷ���false��</returns>
		
		#endregion
	}
}

