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
    using Shmzh.MM.Common;
    using Shmzh.MM.DataAccess;
	/// <summary>
	/// MAIO ��ժҪ˵����
	/// </summary>
	public class MAIO : Messages
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
		private bool check(MAIOData oMAIOData)
		{
			bool ret = true;
			if (oMAIOData.Count == 0)
			{
				this.Message = "����̵�����Ϊ�գ�";
				return false;
			}
			if (oMAIOData.ItemCode == null || oMAIOData.ItemCode == "")
			{
				this.Message = "���ϱ�Ų���Ϊ�գ�";
				return false;
			}
			if (oMAIOData.StoCode == null || oMAIOData.StoCode == "")
			{
				this.Message = "�ֿ��Ų���Ϊ�գ�";
				return false;
			}
			
			if (oMAIOData.BookNum.ToString() == null )
			{
				this.Message = "������������Ϊ�գ�";
				return false;
			}
			if (oMAIOData.BookPrice.ToString() == null)
			{
				this.Message = "���浥�۲���Ϊ�գ�";
				return false;
			}
			if (oMAIOData.ItemNum.ToString() == null)
			{
				this.Message = "ʵ����������Ϊ�գ�";
				return false;
			}
			return ret;
		}
		#endregion

		#region ��������
		public bool Add(MAIOData oMAIOData)
		{
			bool ret = false;
			if (this.check(oMAIOData))
			{
				ret = new MAIOs().Add(oMAIOData);
				if (ret == false)
				{
					this.Message = "����̵����ݱ���ʧ�ܣ�";
				}
				return ret;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// �޸Ŀ���̵��¼��
		/// </summary>
		/// <param name="oMAIOData">MAIOData:	�̵��¼ʵ�塣</param>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="ConName">string:	��λ���ơ�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(MAIOData oMAIOData, string StoCode, string ConName)
		{
			bool ret = false;
			if (this.check(oMAIOData))
			{
				ret = new MAIOs().Update(oMAIOData, StoCode, ConName);
				if (ret == false)
				{
					this.Message = "����̵����ݱ���ʧ�ܣ�";
				}
				return ret;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region ���캯��
		public MAIO()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
