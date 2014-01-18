
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// ί��ӹ����뵥��ҵ�����㡣
	/// </summary>
	public class WTOW :Messages,IInItem
	{
		#region ���캯��
		public WTOW()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// ί��ӹ����뵥�����ӡ�
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			// TODO:  ��� WTOW.Insert ʵ��
			bool ret = true;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
//			//�ж���û��ָ�����ϲֿ⡣
//			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.STOCODE_FIELD].ToString() == "-1")
//			{
//				this.Message = WTOWData.NoStorage;
//				return false;
//			}
			//�ж���û��ָ����;��
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = WTOWData.NoPurpose;
				return false;
			}
			//�ж���û��ָ�����ò��š�
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
			{
				this.Message = WTOWData.NoDept;
				return false;
			}
			//�ж���û��ָ�������ˡ�
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
			{
				this.Message = WTOWData.NoProposer;
				return false;
			}
			//ִ��ί��ӹ����뵥���½�������
			ret = oWTOWs.InsertEntry(Entry);
			this.Message = oWTOWs.Message;
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥���½����������ύ����
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  ��� WTOW.Insert ʵ��
			bool ret = true;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
//			//�ж���û��ָ�����ϲֿ⡣
//			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.STOCODE_FIELD].ToString() == "-1")
//			{
//				this.Message = WTOWData.NoStorage;
//				return false;
//			}
			//�ж���û��ָ����;��
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = WTOWData.NoPurpose;
				return false;
			}
			//�ж���û��ָ�����ò��š�
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
			{
				this.Message = WTOWData.NoDept;
				return false;
			}
			//�ж���û��ָ�������ˡ�
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
			{
				this.Message = WTOWData.NoProposer;
				return false;
			}
			//ִ��ί��ӹ����뵥���½����������ύ������
			ret = oWTOWs.InsertAndPresentEntry(Entry);
			this.Message = oWTOWs.Message;
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥���޸ġ�
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			// TODO:  ��� WTOW.Update ʵ��
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//�ж�ί��ӹ����뵥�޸ĵ�ǰ��������
			if ( this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId) )
			{
//				//�ж���û��ָ�����ϲֿ⡣
//				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.STOCODE_FIELD].ToString() == "-1")
//				{
//					this.Message = WTOWData.NoStorage;
//					return false;
//				}
				//�ж���û��ָ����;��
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WTOWData.NoPurpose;
					return false;
				}
				//�ж���û��ָ�����ò��š�
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = WTOWData.NoDept;
					return false;
				}
				//�ж���û��ָ�������ˡ�
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
				{
					this.Message = WTOWData.NoProposer;
					return false;
				}
				//ִ��ί��ӹ����뵥���½�������
				ret = oWTOWs.UpdateEntry(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XUpdate;
				ret = false;
			}
			return ret;
		}
		public bool StockOut(object Entry)
		{
			// TODO:  ��� WTOW.Update ʵ��
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//�ж�ί��ӹ����뵥���ϵ�ǰ��������
			if ( this.CheckPreCondition(EntryNo, OP.O, UserLoginId) )
			{
				//�ж���û��ָ����;��
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WTOWData.NoPurpose;
					return false;
				}
				//�ж���û��ָ�����ò��š�
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = WTOWData.NoDept;
					return false;
				}
				//�ж���û��ָ�������ˡ�
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
				{
					this.Message = WTOWData.NoProposer;
					return false;
				}
				//ִ��ί��ӹ����뵥���½�������
				ret = oWTOWs.StockOut(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;			
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥���޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  ��� WTOW.Update ʵ��
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//�ж�ί��ӹ����뵥�޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
//				//�ж���û��ָ�����ϲֿ⡣
//				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.STOCODE_FIELD].ToString() == "-1")
//				{
//					this.Message = WTOWData.NoStorage;
//					
//					return false;
//				}
				//�ж���û��ָ����;��
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WTOWData.NoPurpose;
					return false;
				}
				//�ж���û��ָ�����ò��š�
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = WTOWData.NoDept;
					return false;
				}
				//�ж���û��ָ�������ˡ�
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
				{
					this.Message = WTOWData.NoProposer;
					return false;
				}
				//ִ��ί��ӹ����뵥���½�������
				ret = oWTOWs.UpdateAndPresentEntry(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XUpdate;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥��ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			bool ret = true;
			WTOWs oWTOWs = new WTOWs();
			//�ж�ί��ӹ����뵥ɾ����ǰ��������
			if (this.CheckPreCondition(EntryNo,OP.Delete))
			{
				ret =  oWTOWs.DeleteEntry(EntryNo);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XDelete;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥��ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			WTOWs oWTOWs = new WTOWs();
			//�ж�ί��ӹ����뵥ɾ����ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				ret =  oWTOWs.DeleteEntry(EntryNo);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥��״̬�ı䡣
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬ ��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  ��� WTOW.UpdateEntryState ʵ��
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();

			ret = oWTOWs.UpdateEntryState(EntryNo,newState);
			this.Message=oWTOWs.Message;
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥��һ��������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  ��� WTOW.FirstAduit ʵ��
			bool ret = true;
			int EntryNo;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//�ж�ί��ӹ����뵥һ��������ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.FirstAudit))
			{
				ret = oWTOWs.FirstAudit(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥�Ķ���������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  ��� WTOW.SecondAduit ʵ��
			bool ret = true;
			int EntryNo;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//�ж�ί��ӹ����뵥����������ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.SecondAudit) )
			{
				ret = oWTOWs.SecondAudit(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XSecondAudit ;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥������������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  ��� WTOW.ThirdAduit ʵ��
			bool ret = true;
			int EntryNo;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//�ж�ί��ӹ����뵥�޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo,OP.ThirdAudit) )
			{
				ret = oWTOWs.ThirdAudit(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XThirdAudit;
				ret = false;
			}
			return ret;
		}
		
		/// <summary>
		/// ί��ӹ����뵥�ύ��
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();
			
			//�ж�ί��ӹ����뵥�޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo,OP.Submit, UserLoginId) )
			{
				ret = oWTOWs.Present(EntryNo, newState, UserLoginId);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();
			
			//�ж�ί��ӹ����뵥�޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Cancel) )
			{
				ret = oWTOWs.Cancel(EntryNo, newState);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();
			
			//�ж�ί��ӹ����뵥�޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginId) )
			{
				ret = oWTOWs.Cancel(EntryNo, newState,UserLoginId);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = "����Ȩ���д˲�����";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥�ܷ���
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Refuse(int EntryNo, string UserLoginId)
		{
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();
			
			//�ж�ί��ӹ����뵥�޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.O) )
			{
				ret = oWTOWs.DrawRefuse(EntryNo, UserLoginId);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XRefuse;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����ί��ӹ����뵥����ˮ������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  ��� WTOW.GetEntryByEntryNo ʵ��
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryNo(EntryNo);
			return oWTOWData;
		}

        /// <summary>
        /// ����ί��ӹ����뵥����ˮ������ȡ���ݡ�
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>object:	����ʵ�塣</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            // TODO:  ��� WTOW.GetEntryByEntryNo ʵ��
            WTOWData oWTOWData;
            WTOWs oWTOWs = new WTOWs();
            oWTOWData = (WTOWData)oWTOWs.GetEntryOldByEntryNo(EntryNo);
            return oWTOWData;
        }

        /// <summary>
        /// ����ί��ӹ����뵥����ˮ������ȡ���ݡ�
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>object:	����ʵ�塣</returns>
        public object GetEntryRedByEntryNo(int EntryNo)
        {
            // TODO:  ��� WTOW.GetEntryByEntryNo ʵ��
            WTOWData oWTOWData;
            WTOWs oWTOWs = new WTOWs();
            oWTOWData = (WTOWData)oWTOWs.GetEntryRedByEntryNo(EntryNo);
            return oWTOWData;
        }
		/// <summary>
		/// ����ί��ӹ����뵥�ı������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  ��� WTOW.GetEntryByEntryCode ʵ��
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryCode(EntryCode);
			return oWTOWData;
		}
		/// <summary>
		/// ��ȡ����ί��ӹ����뵥��
		/// </summary>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryAll()
		{
			// TODO:  ��� WTOW.GetEntryAll ʵ��
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryAll();
			return oWTOWData;
		}
		public object GetEntryAll(string UserLoginId)
		{
			WTOWData oWTOWData;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryAll(UserLoginId);
			return oWTOWData;
		}

        public object GetEntryByPerson(string Empcode)
        {
            WTOWData oWTOWData;
            WTOWs oWTOWs = new WTOWs();
            oWTOWData = (WTOWData)oWTOWs.GetEntryByPerson(Empcode);
            return oWTOWData;
        }

		/// <summary>
		/// ��ȡָ���Ƶ����ŵ�ί��ӹ����뵥��
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  ��� WTOW.GetEntryByDept ʵ��
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByDept(DeptCode);
			return oWTOWData;
		}

		#endregion

		#region ר�з���
		/// <summary>
		/// ����ģʽ�»�ȡί��ӹ����뵥�����ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryNoOutMode(EntryNo);
			return oWTOWData;
		}
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
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
			WTOWData oWTOWData;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryNo(EntryNo);	//2005-10-21�޸�,�޸�ǰ�����������.GetEntryByEntryNoOutMode������

			if (oWTOWData.Count > 0)
			{
				EntryState = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
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
							ret = true;
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
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
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
			WTOWData oWTOWData;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryNo(EntryNo);   

			if (oWTOWData.Count > 0)
			{
				EntryState = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
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
