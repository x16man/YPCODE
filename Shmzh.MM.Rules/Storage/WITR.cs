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
	using System.Data;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	using MZHCommon.Input;
	using MZHCommon.Database;
	using System.Collections;
	/// <summary>
	/// WITR ��ժҪ˵����
	/// </summary>
	public class WITR : Messages
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
		/// <summary>
		/// �����������½���
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "û��ָ���������ƣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqReasonCode_Field] == System.DBNull.Value || 
				oData.Tables[0].Rows[0][WITRData.ReqReasonCode_Field].ToString() == "-1" ||
				oData.Tables[0].Rows[0][WITRData.ReqReasonCode_Field].ToString() == "")
			{
				this.Message = "û��ָ����;��";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "û��ָ�����ڣ�";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "û��ָ��������";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Insert(oData);
			this.Message = oWITRs.Message;
			return ret;
		}

		/// <summary>
		/// �����������½��������ύ.
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "û��ָ���������ƣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "û��ָ�����ڣ�";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "û��ָ��������";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.InsertAndPresent(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// �����������޸ġ�
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "û��ָ���������ƣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "û��ָ�����ڣ�";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "û��ָ��������";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Update(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// �����������޸Ĳ������ύ��
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "û��ָ���������ƣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "û��ָ�����ڣ�";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "û��ָ��������";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.UpdateAndPresent(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// �������ύ.
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "û��ָ���������ƣ�";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "û��ָ�����ڣ�";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "û��ָ��������";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Present(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// ɾ�����������롣
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Delete(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// ����������ȷ�ϡ�
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Affirm(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Affirm(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// ����������ܾ�.
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Refuse(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Refuse(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// ������ת�ɹ����뵥��
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ToPROS(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.ToPros(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// ����������ת���¶ȼƻ�����
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ToMRP(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "û�����ݣ�";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.ToMRP(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		#endregion

		#region ���캯��
		public WITR()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
