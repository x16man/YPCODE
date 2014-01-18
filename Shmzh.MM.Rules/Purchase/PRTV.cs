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
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// PurchaseOrder ��ժҪ˵����
	/// </summary>
	public class PRTV :Messages,IInItem
	{

        private PRTVData prtvHistoryData;
		#region ���캯��
		public PRTV()
		{
		}
		#endregion

		#region IInItem ��Ա

		/// <summary>
		/// �ɹ����ϵ�¼�롣
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			bool ret = false;
            PRTVs oPRTVs = new PRTVs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oPRTVs.InsertEntry(Entry);

			this.Message = oPRTVs.Message;

			return ret;
		}

		/// <summary>
		/// �ɹ����ϵ�¼�벢�������ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = false;
			PRTVs oPRTVs = new PRTVs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oPRTVs.InsertAndPresentEntry(Entry);

			this.Message = oPRTVs.Message;

			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			bool ret = false;
			int EntryNo;
			PRTVData oEntry =   (PRTVData)Entry;
			EntryNo = oEntry.EntryNo;
			oEntry =  (PRTVData)new PRTVs().GetEntryByEntryNo(EntryNo);
			if (oEntry.EntryState == DocStatus.New ||
				oEntry.EntryState == DocStatus.Cancel ||
				oEntry.EntryState == DocStatus.FstNoPass||
				oEntry.EntryState == DocStatus.SecNoPass ||
				oEntry.EntryState == DocStatus.TrdNoPass)
			{
				PRTVs oPRTVs = new PRTVs();
				if( !IsValied(Entry,OP.New) )
					return ret;
				ret = oPRTVs.UpdateEntry(Entry);

				this.Message = oPRTVs.Message;
			}
			else
			{
				ret = false;
				this.Message = PRTVData.XUpdate;
			}
			return ret;
		}

        /// <summary>
        /// �ɹ����ϵ��޸ġ�
        /// </summary>
        /// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
        /// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
        public bool Update(object Entry,string strEmpCode)
        {
            bool ret = false;
            int EntryNo;
            PRTVData oEntry = (PRTVData)Entry;
            EntryNo = oEntry.EntryNo;
            oEntry = (PRTVData)new PRTVs().GetEntryByEntryNo(EntryNo);
            if (oEntry.EntryState == DocStatus.New ||
                oEntry.EntryState == DocStatus.Cancel ||
                oEntry.EntryState == DocStatus.FstNoPass ||
                oEntry.EntryState == DocStatus.SecNoPass ||
                oEntry.EntryState == DocStatus.TrdNoPass)
            {
                if(!CheckOperateUser(Entry,strEmpCode))
                {
                    return false;
                }
                PRTVs oPRTVs = new PRTVs();
                if (!IsValied(Entry, OP.New))
                    return ret;
                ret = oPRTVs.UpdateEntry(Entry);

                this.Message = oPRTVs.Message;
            }
            else
            {
                ret = false;
                this.Message = PRTVData.XUpdate;
            }
            return ret;
        }
		/// <summary>
		/// �ɹ����ϵ��޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			bool ret = false;
			int EntryNo;
			PRTVData oEntry =   (PRTVData)Entry;
			EntryNo = oEntry.EntryNo;
			oEntry =  (PRTVData)new PRTVs().GetEntryByEntryNo(EntryNo);
			if (oEntry.EntryState == DocStatus.New ||
				oEntry.EntryState == DocStatus.Cancel ||
				oEntry.EntryState == DocStatus.FstNoPass||
				oEntry.EntryState == DocStatus.SecNoPass ||
				oEntry.EntryState == DocStatus.TrdNoPass)
			{
                
				PRTVs oPRTVs = new PRTVs();
				if( !IsValied(Entry,OP.New) )
					return ret;
				ret = oPRTVs.UpdateAndPresentEntry(Entry);

				this.Message = oPRTVs.Message;
			}
			else
			{
				ret = false;
				this.Message = PRTVData.XUpdate;
			}
			return ret;
		}

        /// <summary>
        /// �ɹ����ϵ��޸Ĳ��������ύ��
        /// </summary>
        /// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
        /// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
        public bool UpdateAndPresent(object Entry,string strEmpCode)
        {
            bool ret = false;
            int EntryNo;
            PRTVData oEntry = (PRTVData)Entry;
            EntryNo = oEntry.EntryNo;
            oEntry = (PRTVData)new PRTVs().GetEntryByEntryNo(EntryNo);
            if (oEntry.EntryState == DocStatus.New ||
                oEntry.EntryState == DocStatus.Cancel ||
                oEntry.EntryState == DocStatus.FstNoPass ||
                oEntry.EntryState == DocStatus.SecNoPass ||
                oEntry.EntryState == DocStatus.TrdNoPass)
            {
                if(!CheckOperateUser(Entry,strEmpCode))
                {
                    return false;
                }
                PRTVs oPRTVs = new PRTVs();
                if (!IsValied(Entry, OP.Edit))
                    return ret;
                ret = oPRTVs.UpdateAndPresentEntry(Entry);

                this.Message = oPRTVs.Message;
            }
            else
            {
                ret = false;
                this.Message = PRTVData.XUpdate;
            }
            return ret;
        }
		/// <summary>
		/// �ɹ����ϵ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{

			bool ret=true;
			PRTVData oPRTVData;

			PRTVs oPRTVs=new PRTVs();
			oPRTVData = (PRTVData)oPRTVs.GetEntryByEntryNo(EntryNo);
			if (oPRTVData != null && oPRTVData.Count > 0)
			{
				//�������������״̬������ɾ����
				if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
                    if (!IsValied(oPRTVData, OP.Delete))
                        return false;
					if (oPRTVs.DeleteEntry(EntryNo) == false)
					{
						this.Message=oPRTVs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = PRTVData.XDelete;
					ret = false;
				}
			}
			
			return ret;
		}


        /// <summary>
        /// �ɹ����ϵ�ɾ����
        /// </summary>
        /// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
        /// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
        public bool Delete(int EntryNo,string strEmpCode)
        {

            bool ret = true;
            PRTVData oPRTVData;

            PRTVs oPRTVs = new PRTVs();
            oPRTVData = (PRTVData)oPRTVs.GetEntryByEntryNo(EntryNo);
            if (oPRTVData != null && oPRTVData.Count > 0)
            {
                //�������������״̬������ɾ����
                if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
                {
                    if(!CheckOperateUser(EntryNo,strEmpCode))
                    {
                        return false;
                    }
                    if (!IsValied(oPRTVData, OP.Delete))
                        return false;
                    if (oPRTVs.DeleteEntry(EntryNo) == false)
                    {
                        this.Message = oPRTVs.Message;
                        ret = false;
                    }
                }
                else
                {
                    this.Message = PRTVData.XDelete;
                    ret = false;
                }
            }

            return ret;
        }

		/// <summary>
		/// �ɹ����ϵ�״̬�޸ġ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;

			PRTVs oPRTVs = new PRTVs();

			if (oPRTVs.UpdateEntryState(EntryNo,newState) == false)
			{
				this.Message=oPRTVs.Message;
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=false;
			int EntryNo = ((PRTVData)Entry).EntryNo;
			PRTVData oEntry = (PRTVData)new PRTVs().GetEntryByEntryNo(EntryNo);
			if (oEntry.EntryState == DocStatus.Present)
			{
				PRTVs oPRTVs = new PRTVs();
				if( !IsValied(Entry,OP.FirstAudit) )
					return ret;

				ret = oPRTVs.FirstAudit(Entry);
				this.Message=oPRTVs.Message;
			}
			else
			{
				ret = false;
				this.Message = PRTVData.XFirstAudit;
			}
			
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=false;
			int EntryNo = ((PRTVData)Entry).EntryNo;
			PRTVData oEntry = (PRTVData)new PRTVs().GetEntryByEntryNo(EntryNo);
			if (oEntry.EntryState == DocStatus.FstPass)
			{
				PRTVs oPRTVs = new PRTVs();
				if( !IsValied(Entry,OP.SecondAudit) )
					return ret;

				ret = oPRTVs.SecondAudit(Entry);
				this.Message=oPRTVs.Message;
			}
			else
			{
				ret = false;
				this.Message = PRTVData.XSecondAudit;
			}
	
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=false;
			int EntryNo = ((PRTVData)Entry).EntryNo;
			PRTVData oEntry = (PRTVData)new PRTVs().GetEntryByEntryNo(EntryNo);
            if (oEntry.EntryState == DocStatus.SecPass)
			{
				PRTVs oPRTVs = new PRTVs();

				if( !IsValied(Entry,OP.ThirdAudit) )
					return ret;

				ret = oPRTVs.ThirdAudit(Entry);

				this.Message=oPRTVs.Message;
			}
			else
			{
				ret = false;
				this.Message = PRTVData.XThirdAudit;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ����ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
        public bool Present(int EntryNo, string newState, string UserLoginId)
        {
            bool ret = true;

            PRTVData oEntry = (PRTVData)new PRTVs().GetEntryByEntryNo(EntryNo);
            if (oEntry.EntryState == DocStatus.New ||
                        oEntry.EntryState == DocStatus.Cancel ||
                         oEntry.EntryState == DocStatus.FstNoPass ||
                         oEntry.EntryState == DocStatus.SecNoPass ||
                         oEntry.EntryState == DocStatus.TrdNoPass ||
                         oEntry.EntryState == DocStatus.OrdReject
                         )
            {


                PRTVs oPRTVs = new PRTVs();

                if (oPRTVs.Present(EntryNo, newState, UserLoginId) == false)
                {
                    this.Message = oPRTVs.Message;
                    ret = false;
                }
            }
            else
            {
                ret = false;
                this.Message = PRTVData.XPresent;
            }

            return ret;
        }


        /// <summary>
        /// �ɹ����ϵ��ύ��
        /// </summary>
        /// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
        /// <param name="newState">string:	��״̬��</param>
        /// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
        public bool Present(int EntryNo, string newState,string UserLoginId, string strEmpCode)
        {
            bool ret = true;

            PRTVData oEntry = (PRTVData)new PRTVs().GetEntryByEntryNo(EntryNo);
            if (oEntry.EntryState == DocStatus.New ||
                        oEntry.EntryState == DocStatus.Cancel ||
                         oEntry.EntryState == DocStatus.FstNoPass ||
                         oEntry.EntryState == DocStatus.SecNoPass ||
                         oEntry.EntryState == DocStatus.TrdNoPass ||
                         oEntry.EntryState == DocStatus.OrdReject
                         )
            {

                if (!CheckOperateUser(EntryNo, strEmpCode))
                {
                    return false;
                }


                PRTVs oPRTVs = new PRTVs();

                if (oPRTVs.Present(EntryNo, newState, UserLoginId) == false)
                {
                    this.Message = oPRTVs.Message;
                    ret = false;
                }
            }
            else
            {
                ret = false;
                this.Message = PRTVData.XPresent;
            }

            return ret;
        }

		/// <summary>
		/// �ɹ����ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			
			PRTVs oPRTVs = new PRTVs();
			PRTVData oPRTVData;
			oPRTVData = (PRTVData)oPRTVs.GetEntryByEntryNo(EntryNo);
			if (oPRTVData.EntryState == DocStatus.New ||
				oPRTVData.EntryState == DocStatus.FstNoPass ||
				oPRTVData.EntryState == DocStatus.SecNoPass ||
				oPRTVData.EntryState == DocStatus.TrdNoPass )
			{
               
				if (oPRTVs.Cancel(EntryNo, newState) == false)
				{
					this.Message=oPRTVs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PRTVData.XCancel;
				ret = false;
			}
			return ret;
		}

        //public bool Cancel(int EntryNo, string newState,string strEmpCode)
        //{
        //    bool ret = true;

        //    PRTVs oPRTVs = new PRTVs();
        //    PRTVData oPRTVData;
        //    oPRTVData = (PRTVData)oPRTVs.GetEntryByEntryNo(EntryNo);
        //    if (oPRTVData.EntryState == DocStatus.New ||
        //        oPRTVData.EntryState == DocStatus.FstNoPass ||
        //        oPRTVData.EntryState == DocStatus.SecNoPass ||
        //        oPRTVData.EntryState == DocStatus.TrdNoPass)
        //    {
        //        if (!CheckOperateUser(EntryNo, strEmpCode))
        //        {
        //            return false;
        //        }

        //        if (oPRTVs.Cancel(EntryNo, newState) == false)
        //        {
        //            this.Message = oPRTVs.Message;
        //            ret = false;
        //        }
        //    }
        //    else
        //    {
        //        this.Message = PRTVData.XCancel;
        //        ret = false;
        //    }
        //    return ret;
        //}

		/// <summary>
		/// �ɹ��˻������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	����״̬��</param>
		/// <param name="UserLoginId">string:	�����ˡ�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState,string UserLoginId)
		{
			bool ret=true;

			PRTVs oPRTVs = new PRTVs();
			PRTVData oPRTVData;
			oPRTVData = (PRTVData)oPRTVs.GetEntryByEntryNo(EntryNo);
			if (oPRTVData.EntryState == DocStatus.New ||
				oPRTVData.EntryState == DocStatus.FstNoPass ||
				oPRTVData.EntryState == DocStatus.SecNoPass ||
				oPRTVData.EntryState == DocStatus.TrdNoPass )
			{
               
				if (oPRTVs.Cancel(EntryNo, newState,UserLoginId) == false)
				{
					this.Message=oPRTVs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PRTVData.XCancel;
				ret = false;
			}
			return ret;
		}

        public bool Cancel(int EntryNo, string newState, string UserLoginId,string strEmpCode)
        {
            bool ret = true;

            PRTVs oPRTVs = new PRTVs();
            PRTVData oPRTVData;
            oPRTVData = (PRTVData)oPRTVs.GetEntryByEntryNo(EntryNo);
            if (oPRTVData.EntryState == DocStatus.New ||
                oPRTVData.EntryState == DocStatus.FstNoPass ||
                oPRTVData.EntryState == DocStatus.SecNoPass ||
                oPRTVData.EntryState == DocStatus.TrdNoPass)
            {
                if(!CheckOperateUser(EntryNo,strEmpCode))
                {
                    return false;
                }
                if (oPRTVs.Cancel(EntryNo, newState, UserLoginId) == false)
                {
                    this.Message = oPRTVs.Message;
                    ret = false;
                }
            }
            else
            {
                this.Message = PRTVData.XCancel;
                ret = false;
            }
            return ret;
        }

		/// <summary>
		/// ���ݲɹ����ϵ���ˮ�Ż�ȡ�ɹ����ϵ�������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <returns>object:	�ɹ����ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PRTVData oPRTVData ;
			PRTVs oPRTVs = new PRTVs();
			oPRTVData = (PRTVData)oPRTVs.GetEntryByEntryNo(EntryNo);
			return oPRTVData;
		}
		/// <summary>
		/// �ڷ���ģʽ�¸��ݲɹ����ϵ���ˮ�Ż�ȡ�ɹ����ϵ�������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <returns>object:	�ɹ����ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			PRTVData oPRTVData ;
			PRTVs oPRTVs = new PRTVs();
			oPRTVData = (PRTVData)oPRTVs.GetEntryByEntryNoInMode(EntryNo);
			return oPRTVData;
		}
		/// <summary>
		/// ���ݲɹ����ϵ���Ż�ȡ�ɹ����ϵ���Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	�ɹ����ϵ���š�</param>
		/// <returns>object:	�ɹ����ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PRTVData oPRTVData ;
			PRTVs oPRTVs = new PRTVs();
			oPRTVData = (PRTVData)oPRTVs.GetEntryByEntryCode(EntryCode);
			return oPRTVData;
		}
		/// <summary>
		/// ��ȡ���вɹ����ϵ���
		/// </summary>
		/// <returns>object:	�ɹ����ϵ�����ʵ�塣</returns>
		public object GetEntryAll()
		{
			PRTVData oPRTVData ;
			PRTVs oPRTVs = new PRTVs();
			oPRTVData = (PRTVData)oPRTVs.GetEntryAll();
			return oPRTVData;
		}

        /// <summary>
        /// ��ȡ���вɹ����ϵ���
        /// </summary>
        /// <returns>object:	�ɹ����ϵ�����ʵ�塣</returns>
        public object GetEntryAll(string strEmpCode)
        {
            PRTVData oPRTVData;
            PRTVs oPRTVs = new PRTVs();
            oPRTVData = (PRTVData)oPRTVs.GetEntryAll();
            return oPRTVData;
        }


        /// <summary>
        /// ��ȡ���вɹ����ϵ���
        /// </summary>
        /// <returns>object:	�ɹ����ϵ�����ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            PRTVData oPRTVData;
            PRTVs oPRTVs = new PRTVs();
            oPRTVData = (PRTVData)oPRTVs.GetEntryByPerson(EmpCode);
            return oPRTVData;
        }
		/// <summary>
		/// ���ݲɹ����ϵ��Ƶ����ű�Ż�ȡ�ɹ����ϵ���Ϣ��
		/// </summary>
		/// <param name="DeptCode">string:	�ɹ����ϵ��Ƶ����ű�š�</param>
		/// <returns>object:	�ɹ����ϵ�����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PRTVData oPRTVData ;
			PRTVs oPRTVs = new PRTVs();
			oPRTVData = (PRTVData)oPRTVs.GetEntryByDept(DeptCode);
			return oPRTVData;
		}

		#endregion

		#region �ɹ����ϵ�ר�з��� 
//		/// <summary>
//		/// ���ݹ�Ӧ�̴�����Դ������
//		/// </summary>
//		/// <param name="PrvCode"></param>
//		/// <returns></returns>
//		public object GetEntryByPrvCode(string PrvCode)
//		{
//			PBSData oPBSData;
//			PRTVs oPRTVs = new PRTVs();
//			oPBSData = (PBSData)oPRTVs.GetEntryByPrvCode(PrvCode);
//			return oPBSData;
//		}
//		/// <summary>
//		/// ����pkid�б�����ϸ��
//		/// </summary>
//		/// <param name="List"></param>
//		/// <returns></returns>
//		public object GetPBSDByList(string List)
//		{
//			PBSDData oPBSData;
//			PRTVs oPRTVs = new PRTVs();
//			oPBSData = (PBSDData)oPRTVs.GetPBSDByList(List);
//			return oPBSData;
//		}

		/// <summary>
		/// ����PKID��ȡ����Դ��
		/// </summary>
		/// <param name="PKID"></param>
		/// <returns></returns>
		public object GetRTVSByPKID(string PKID)
		{
			RTVSData oRTVSData;
			PRTVs oPRTVs = new PRTVs();
			oRTVSData = (RTVSData)oPRTVs.GetRTVSByPKID(PKID);
			return oRTVSData;
		}
		
		public object GetRTVSDetailByPKID(string PKID)
		{
			RTVSDetailData oRTVSDetailData;
			PRTVs oPRTVs = new PRTVs();
			oRTVSDetailData = (RTVSDetailData)oPRTVs.GetRTVSDetailByPKID(PKID);
			return oRTVSDetailData;
		}

					   
		#endregion

		#region PRTVData DataУ�麯��
		/// <summary>
		/// ����������Ч�ԡ�
		/// </summary>
		/// <param name="Entry">object��	�ɹ��˻���ʵ�塣</param>
		/// <param name="strTarget">string:	����ģʽ��</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		public bool IsValied(object Entry,string strTarget)
		{
			bool ret = true;
			PRTVData oEntry = (PRTVData)Entry;
			switch (strTarget)
			{
				case OP.New:
					if(oEntry.Tables[0].Rows[0][PRTVData.STOCODE_FIELD].ToString() =="-1"  )	//�жϲֿ⡣
					{
						ret = false;
						this.Message = PRTVData.NO_STO;
					}
					if (oEntry.Tables[0].Rows[0][PRTVData.BUYERCODE_FIELD].ToString() == "-1")//�жϲɹ�Ա
					{
						ret = false;
						this.Message = "��û��ָ���ɹ�Ա��";
					}
					
					if (oEntry.Tables[0].Rows[0][InItemData.REMARK_FIELD] == null || oEntry.Tables[0].Rows[0][InItemData.REMARK_FIELD].ToString() == "")
					{
						ret = false;
						this.Message = "���ڱ�ע����ָ���˻����ɣ�";
					}
					break;
                //case OP.Edit:
                //    //prtvHistoryData = new PRTV().GetEntryByEntryNo(oEntry.EntryNo) as PRTVData;
                //    //if (prtvHistoryData.Tables[0].Rows[0][InItemData.AUTHORCODE_FIELD] != oEntry.Tables[0].Rows[0][InItemData.AUTHORCODE_FIELD].ToString())
                //    //{
                //    //    return false;
                //    //    this.Message = "����Ȩ�޸ģ�";
                //    //}
                //    if (oEntry.Tables[0].Rows[0][PRTVData.STOCODE_FIELD].ToString() == "-1")	//�жϲֿ⡣
                //    {
                //        ret = false;
                //        this.Message = PRTVData.NO_STO;
                //    }
                //    if (oEntry.Tables[0].Rows[0][PRTVData.BUYERCODE_FIELD].ToString() == "-1")//�жϲɹ�Ա
                //    {
                //        ret = false;
                //        this.Message = "��û��ָ���ɹ�Ա��";
                //    }

                //    if (oEntry.Tables[0].Rows[0][InItemData.REMARK_FIELD] == null || oEntry.Tables[0].Rows[0][InItemData.REMARK_FIELD].ToString() == "")
                //    {
                //        ret = false;
                //        this.Message = "���ڱ�ע����ָ���˻����ɣ�";
                //    }
                //    break;
                //case OP.Delete:
                //case OP.Submit:
                //case OP.Cancel:
                //    prtvHistoryData = new PRTV().GetEntryByEntryNo(oEntry.EntryNo) as PRTVData;
                //    if (prtvHistoryData.Tables[0].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() != oEntry.Tables[0].Rows[0][InItemData.AUTHORCODE_FIELD].ToString())
                //    {
                //        this.Message = "����Ȩ�޸ģ�";
                //        return false;
                       
                //    }
                //    //�Ƿ��Ǳ���ɾ��
                //    break;

				case OP.FirstAudit:
					if(oEntry.Tables[0].Rows[0][InItemData.AUDIT1_FIELD].ToString().Length == 0) //�ж��Ƿ�������
					{
						ret = false;
						this.Message = PRTVData.NO_AUDIT_VALUE;
					}
					break;
				case OP.SecondAudit:
					if(oEntry.Tables[0].Rows[0][InItemData.AUDIT2_FIELD].ToString().Length == 0)  //�ж��Ƿ�������
					{
						ret = false;
						this.Message = PRTVData.NO_AUDIT_VALUE;
					}
					break;
				case OP.ThirdAudit:
					if(oEntry.Tables[0].Rows[0][InItemData.AUDIT3_FIELD].ToString().Length == 0)   //�ж��Ƿ�������
					{
						ret = false;
						this.Message = PRTVData.NO_AUDIT_VALUE;
					}
					break;
			}

			return ret;


		}

        /// <summary>
        /// ��������Ա�Ƿ�Ϊ������
        /// </summary>
        /// <param name="Entry"></param>
        /// <param name="strEmpCode"></param>
        /// <returns></returns>
        public bool CheckOperateUser(object Entry, string strEmpCode)
        {
            bool bstatus = true;
            PRTVData oEntry = (PRTVData)Entry;

            if (oEntry.Tables[0].Rows.Count > 0)
            {
                prtvHistoryData = new PRTV().GetEntryByEntryNo(oEntry.EntryNo) as PRTVData;
                if (prtvHistoryData.Tables[0].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() != strEmpCode)
                {
                    this.Message = "����Ȩ������";
                    bstatus =  false;
                }
            }
            else
            {
                this.Message = "����Ȩ������";
                bstatus = false;

            }

            return bstatus;
        }

        /// <summary>
        /// ��������Ա�Ƿ�Ϊ������
        /// </summary>
        /// <param name="Entry"></param>
        /// <param name="strEmpCode"></param>
        /// <returns></returns>
        public bool CheckOperateUser(int iEntryNo, string strEmpCode)
        {
            bool bstatus = true;


            if (iEntryNo > 0)
            {
                prtvHistoryData = new PRTV().GetEntryByEntryNo(iEntryNo) as PRTVData;
                if (prtvHistoryData.Tables[0].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() != strEmpCode)
                {
                    this.Message = "����Ȩ������";
                    bstatus = false;
                }
            }
            else
            {
                this.Message = "����Ȩ������";
                bstatus = false;

            }

            return bstatus;
        }


       
		#endregion
	}
}
