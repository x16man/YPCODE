
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// �������ϵ���ҵ�����㡣
	/// </summary>
	public class WRTS :Messages,IInItem
	{
		#region ���캯��
		public WRTS()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// �������ϵ������ӡ�
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			// TODO:  ��� WRTS.Insert ʵ��
			bool ret = false;
			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oWRTSs.InsertEntry(Entry);
			this.Message = oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// �������ϵ������Ӳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  ��� WRTS.Insert ʵ��
			bool ret = false;
			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oWRTSs.InsertAndPresentEntry(Entry);
			this.Message = oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// �������ϵ����޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			// TODO:  ��� WRTS.Update ʵ��
			bool ret = false;

			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oWRTSs.UpdateEntry(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// �������ϵ����޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  ��� WRTS.Update ʵ��
			bool ret = false;

			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oWRTSs.UpdateAndPresentEntry(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// �������ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  ��� WRTS.Delete ʵ��
			bool ret = true;
			WRTSs oWRTSs = new WRTSs();
			WRTSData oWRTSData;
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNo(EntryNo);
			if (oWRTSData != null && oWRTSData.Count > 0)
			{
				//�������������״̬������ɾ����
				if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oWRTSs.DeleteEntry(EntryNo) == false)
					{
						this.Message=oWRTSs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WRTSData.XDelete;
					ret = false;
				}
			}
			else
				ret = false;
			
			return ret;
		}
		/// <summary>
		/// �������ϵ���״̬�ı䡣
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬ ��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  ��� WRTS.UpdateEntryState ʵ��
			bool ret = true;

			WRTSs oWRTSs = new WRTSs();

			ret = oWRTSs.UpdateEntryState(EntryNo,newState);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// �������ϵ���һ��������
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  ��� WRTS.FirstAduit ʵ��
			bool ret = false;

			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.FirstAudit) )
				return ret;
			ret = oWRTSs.FirstAudit(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// �������ϵ��Ķ���������
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  ��� WRTS.SecondAduit ʵ��
			bool ret = false;

			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.SecondAudit) )
				return ret;
			ret = oWRTSs.SecondAudit(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// �������ϵ�������������
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  ��� WRTS.ThirdAduit ʵ��
			bool ret = false;
			if( !IsValied(Entry,OP.ThirdAudit) )
				return ret;
			WRTSs oWRTSs = new WRTSs();

			ret = oWRTSs.ThirdAudit(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// �������ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�������ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WRTSs oWRTSs = new WRTSs();

			ret = oWRTSs.Present(EntryNo, newState, UserLoginId);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// �������ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�������ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;
			WRTSs oWRTSs = new WRTSs();
			WRTSData oWRTSData;
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNo(EntryNo);
			if(oWRTSData!=null && oWRTSData.Count>0)
			{
				if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
				{
					if (oWRTSs.Cancel(EntryNo, newState) == false)
					{
						this.Message=oWRTSs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WRTSData.XCancel;
					ret = false;
				}

			}
			else
				ret = false;
			return ret;
		}
		public bool Cancel(int EntryNo, string newState,string UserLoginId)
		{

			bool ret = true;
			WRTSs oWRTSs = new WRTSs();
			WRTSData oWRTSData;
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNo(EntryNo);
			if(oWRTSData!=null && oWRTSData.Count>0)
			{
				if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
				{
					if (oWRTSs.Cancel(EntryNo, newState,UserLoginId) == false)
					{
						this.Message=oWRTSs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WRTSData.XCancel;
					ret = false;
				}

			}
			else
				ret = false;
			return ret;
		}
		/// <summary>
		/// �����������ϵ�����ˮ������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  ��� WRTS.GetEntryByEntryNo ʵ��
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNo(EntryNo);
			return oWRTSData;
		}
		/// <summary>
		/// ����ģʽ�£�������ˮ�Ż�ȡ�������ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNoInMode(EntryNo);
			return oWRTSData;

		}
		/// <summary>
		/// �����������ϵ��ı������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  ��� WRTS.GetEntryByEntryCode ʵ��
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryCode(EntryCode);
			return oWRTSData;
		}
		/// <summary>
		/// ��ȡ�����������ϵ���
		/// </summary>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryAll()
		{
			// TODO:  ��� WRTS.GetEntryAll ʵ��
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryAll();
			return oWRTSData;
		}

        /// <summary>
        /// ��ȡ�����������ϵ���
        /// </summary>
        /// <returns>object:	����ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            // TODO:  ��� WRTS.GetEntryAll ʵ��
            WRTSData oWRTSData;
            WRTSs oWRTSs = new WRTSs();
            oWRTSData = (WRTSData)oWRTSs.GetEntryByPerson(EmpCode);
            return oWRTSData;
        }
		/// <summary>
		/// ��ȡָ���Ƶ����ŵ��������ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  ��� WRTS.GetEntryByDept ʵ��
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryByDept(DeptCode);
			return oWRTSData;
		}
		/// <summary>
		/// �������ϵ�����
		/// </summary>
		/// <param name="Entry"></param>
		/// <returns></returns>
		public bool Receive(object Entry)
		{
			bool ret = true;

			WRTSs oWRTSs = new WRTSs();

			if (oWRTSs.Receive(Entry) == false)
			{
				this.Message = oWRTSs.Message;
				ret = false;
			}
			return ret;
		}
		#endregion

		#region ���ϵ������Ա
		public bool Check(object Entry)
		{
			bool ret = true;
			WRTSs oWRTSs = new WRTSs();
			ret = oWRTSs.Check(Entry);
			this.Message = oWRTSs.Message;
			return ret;
		}
		#endregion

		#region WRTSData У�麯��
		public bool IsValied(object Entry,string strTarget)
		{
			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			switch (strTarget)
			{
				case OP.New:
					if(oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0][WRTSData.STOCODE_FIELD].ToString() =="-1" )
					{
						ret = false;
						this.Message = WRTSData.NO_STO;
					}
					break;

				case OP.FirstAudit:
					if(oEntry.Tables[0].Rows[0][InItemData.AUDIT1_FIELD].ToString().Length == 0)
					{
						ret = false;
						this.Message = WRTSData.NO_AUDIT_VALUE;
					}
					break;
				case OP.SecondAudit:
					if(oEntry.Tables[0].Rows[0][InItemData.AUDIT2_FIELD].ToString().Length == 0)
					{
						ret = false;
						this.Message = WRTSData.NO_AUDIT_VALUE;
					}
					break;
				case OP.ThirdAudit:
					if(oEntry.Tables[0].Rows[0][InItemData.AUDIT3_FIELD].ToString().Length == 0)
					{
						ret = false;
						this.Message = WRTSData.NO_AUDIT_VALUE;
					}
					break;
			}
			return ret;


			}
		#endregion
	}
}
