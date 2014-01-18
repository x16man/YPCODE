
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// ί��ӹ����ϵ���ҵ�����㡣
	/// </summary>
	public class WINW :Messages
	{
		#region ���캯��
		public WINW()
		{
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// ί��ӹ����ϵ������ӡ�
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			bool ret = true;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			//�ж���û��ָ����Ӧ�̡�
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.PrvCode_Field].ToString() == "-1" )
			{
				this.Message = "��û��ָ����Ӧ�̣�";
				return false;
			}
			//�ж���û��ָ�����ϲֿ⡣
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.StoCode_Field].ToString() == "-1")
			{
				this.Message = "��û��ָ�����ϲֿ⣡";
				return false;
			}
			//�ж���û��ָ���ɹ�Ա��
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.BuyerCode_Field].ToString() == "-1")
			{
				this.Message = "��û��ָ���ɹ�Ա��";
				return false;
			}
			//�ж���û��ָ����;��
//			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//				oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//			{
//				this.Message = "��û��ָ����;��";
//				return false;
//			}
			//ִ��ί��ӹ����ϵ����½�������
			ret = oWINWs.InsertEntry(Entry);
			this.Message = oWINWs.Message;
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ����½����������ύ����
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			//�ж���û��ָ����Ӧ�̡�
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.PrvCode_Field].ToString() == "-1" )
			{
				this.Message = "��û��ָ����Ӧ�̣�";
				return false;
			}
			//�ж���û��ָ�����ϲֿ⡣
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.StoCode_Field].ToString() == "-1")
			{
				this.Message = "��û��ָ�����ϲֿ⣡";
				return false;
			}
			//�ж���û��ָ���ɹ�Ա��
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.BuyerCode_Field].ToString() == "-1")
			{
				this.Message = "��û��ָ���ɹ�Ա��";
				return false;
			}
//			//�ж���û��ָ����;��
//			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//				oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//			{
//				this.Message = "��û��ָ����;��";
//				return false;
//			}
			//ִ��ί��ӹ����ϵ����½����������ύ������
			ret = oWINWs.InsertAndPresentEntry(Entry);
			this.Message = oWINWs.Message;
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ����޸ġ�
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			UserLoginId = Convert.ToString(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.AuthorLoginID_Field].ToString());

			//�ж�ί��ӹ����ϵ��޸ĵ�ǰ��������
			if ( this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId) )
			{
				//�ж���û��ָ����Ӧ�̡�
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.PrvCode_Field].ToString() == "-1" )
				{
					this.Message = "��û��ָ����Ӧ�̣�";
					return false;
				}
				//�ж���û��ָ�����ϲֿ⡣
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.StoCode_Field].ToString() == "-1")
				{
					this.Message = "��û��ָ�����ϲֿ⣡";
					return false;
				}
				//�ж���û��ָ���ɹ�Ա��
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.BuyerCode_Field].ToString() == "-1")
				{
					this.Message = "��û��ָ���ɹ�Ա��";
					return false;
				}
//				//�ж���û��ָ����;��
//				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//					oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//				{
//					this.Message = "��û��ָ����;��";
//					return false;
//				}
				//ִ��ί��ӹ����ϵ����½�������
				ret = oWINWs.UpdateEntry(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XUpdate;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ����ϡ�
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool StockIn(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			UserLoginId = Convert.ToString(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.AuthorLoginID_Field].ToString());

			//�ж�ί��ӹ����ϵ����ϵ�ǰ��������
			if ( this.CheckPreCondition(EntryNo, OP.I, UserLoginId) )
			{
				//�ж���û��ָ����;��
//				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//					oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//				{
//					this.Message = "��û��ָ����;��";
//					return false;
//				}
				//ִ��ί��ӹ����ϵ����½�������
				ret = oWINWs.StockIn(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
                this.Message = oWINWs.Message;
				ret = false;			
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ����޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			UserLoginId = Convert.ToString(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.AuthorLoginID_Field].ToString());

			//�ж�ί��ӹ����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				//�ж���û��ָ����Ӧ�̡�
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.PrvCode_Field].ToString() == "-1" )
				{
					this.Message = "��û��ָ����Ӧ�̣�";
					return false;
				}
				//�ж���û��ָ�����ϲֿ⡣
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.StoCode_Field].ToString() == "-1")
				{
					this.Message = "��û��ָ�����ϲֿ⣡";
					
					return false;
				}
				//�ж���û��ָ���ɹ�Ա��
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.BuyerCode_Field].ToString() == "-1")
				{
					this.Message = "��û��ָ���ɹ�Ա��";
					return false;
				}
//				//�ж���û��ָ����;��
//				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//					oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//				{
//					this.Message = "��û��ָ����;��";
//					return false;
//				}
				//ִ��ί��ӹ����ϵ����½�������
				ret = oWINWs.UpdateAndPresentEntry(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XUpdate;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			WINWs oWINWs = new WINWs();
			//�ж�ί��ӹ����ϵ�ɾ����ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				ret =  oWINWs.DeleteEntry(EntryNo);
				this.Message=oWINWs.Message;
			}
			else
			{
                //this.Message = WINWData.DELETE_FAILED
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ���һ��������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			int EntryNo;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			//�ж�ί��ӹ����ϵ�һ��������ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.FirstAudit))
			{
				ret = oWINWs.FirstAudit(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ��Ķ���������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			int EntryNo;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			//�ж�ί��ӹ����ϵ�����������ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.SecondAudit) )
			{
				ret = oWINWs.SecondAudit(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XSecondAudit ;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ�������������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			int EntryNo;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			//�ж�ί��ӹ����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo,OP.ThirdAudit) )
			{
				ret = oWINWs.ThirdAudit(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XThirdAudit;
				ret = false;
			}
			return ret;
		}
		
		/// <summary>
		/// ί��ӹ����ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WINWs oWINWs = new WINWs();
			
			//�ж�ί��ӹ����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo,OP.Submit, UserLoginId) )
			{
				ret = oWINWs.Present(EntryNo, newState, UserLoginId);
				this.Message=oWINWs.Message;
			}
			else
			{
                //this.Message = oWINWs.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WINWs oWINWs = new WINWs();
			
			//�ж�ί��ӹ����ϵ��޸ĵ�ǰ��������
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginId) )
			{
				ret = oWINWs.Cancel(EntryNo, newState,UserLoginId);
				this.Message=oWINWs.Message;
			}
			else
			{
                //this.Message = th.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ����ί��ӹ����ϵ�����ˮ������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WINWData oWINWData ;
			WINWs oWINWs = new WINWs();
			oWINWData = (WINWData)oWINWs.GetEntryByEntryNo(EntryNo);
			return oWINWData;
		}


        public object GetEntryOldByEntryNo(int EntryNo)
        {
            WINWData oWINWData;
            WINWs oWINWs = new WINWs();
            oWINWData = (WINWData)oWINWs.GetEntryOldByEntryNo(EntryNo);
            return oWINWData;
        }

        public object GetEntryRedByEntryNo(int EntryNo)
        {
            WINWData oWINWData;
            WINWs oWINWs = new WINWs();
            oWINWData = (WINWData)oWINWs.GetEntryRedByEntryNo(EntryNo);
            return oWINWData;
        }

		/// <summary>
		/// ��ȡ����ί��ӹ����ϵ���
		/// </summary>
		/// <param name="UserLoginId">string:	�û���</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WINWData oWINWData;
			WINWs oWINWs = new WINWs();
			oWINWData = (WINWData)oWINWs.GetEntryAll(UserLoginId);
			return oWINWData;
		}

        /// <summary>
        /// ��ȡ����ί��ӹ����ϵ���
        /// </summary>
        /// <param name="UserLoginId">string:	�û���</param>
        /// <returns>object:	����ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WINWData oWINWData;
            WINWs oWINWs = new WINWs();
            oWINWData = (WINWData)oWINWs.GetEntryByPerson(EmpCode);
            return oWINWData;
        }
		#endregion

		#region ר�з���
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����ϵ���ˮ�š�</param>
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
			WINWData oWINWData;
			WINWs oWINWs = new WINWs();
			oWINWData = (WINWData)oWINWs.GetEntryByEntryNo(EntryNo);	//2005-10-21�޸�,�޸�ǰ�����������.GetEntryByEntryNoOutMode������

			if (oWINWData.Count > 0)
			{
				EntryState = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
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
							ret = true;
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
							ret = true;
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
					case OP.I://���ϡ�
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
							ret = true;
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
							ret = true;
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
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����ϵ���ˮ�š�</param>
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
			WINWData oWINWData;
			WINWs oWINWs = new WINWs();
			oWINWData = (WINWData)oWINWs.GetEntryByEntryNo(EntryNo);   

			if (oWINWData.Count > 0)
			{
				EntryState = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
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
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
                                this.Message = "����Ȩ���д˲�����";
                                ret = false;
							}
						}
						else
						{
                            this.Message = "ֻ���ڵ����½�,����,������ͨ����ǰ���£�������Ե��ݽ����޸ģ�";
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
                                this.Message = "����Ȩ���д˲�����";
								ret = false;
							}
						}
						else
						{
                            this.Message = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ����ύ������";
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
                            this.Message = "ֻ���ڵ����Ѿ��ύ��״̬�£�������Ե��ݽ���һ��������";
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
                            this.Message = "ֻ���ڵ���һ������ͨ����ǰ���£�������Ե��ݽ��ж���������";
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
                            this.Message = "ֻ���ڵ��ݶ�������ͨ����ǰ���£�������Ե��ݽ�������������";
							ret = false;
						}
						break;
						#endregion
						#region ����
					case OP.Red://���֡�
						if (EntryState == DocStatus.Received)
						{
							ret = true;
						}
						else
						{
                            this.Message = "ֻ���ڵ��������ϵ�ǰ���£�������Ե��ݽ��к��֣�";
							ret = false;
						}
						break;
						#endregion
						#region ����
					case OP.I:
						if (EntryState == DocStatus.TrdPass)
						{
							ret = true;
						}
						else
						{
                            this.Message = "ֻ���ڵ�����������ͨ����ǰ���£�������Ե��ݽ������ϣ�";
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
                                this.Message = "����Ȩ���д˲�����";
                                ret = false;
							}
							}
						else
						{
                            this.Message = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ������ϲ�����";
								
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
                                this.Message = "����Ȩ���д˲�����";
								ret = false;
							}
						}
						else
						{
                            this.Message = "ֻ�������ϵ�״̬�²�����ɾ����";
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
