//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.BusinessRules
{
	using System;
	using System.Data;
    using Shmzh.MM.Common;
    using Shmzh.MM.DataAccess;
	using MZHCommon.Input;

	/// <summary>
	/// Dept ��ժҪ˵����
	/// </summary>
	public class PPRC : Messages
	{
		/// <summary>
		/// ��Ӧ�̷��� ���ӡ�
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	��Ӧ�̷�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(PPRCData myPPRCData)
		{
			bool isValid = true;
			//�жϴ��������ʵ���Ƿ�Ϊ�ա�
			if (myPPRCData.Tables[PPRCData.PPRC_Table].Rows.Count == 0)
			{
				this.Message = "������Ϊ�գ�";
				return false;
			}
			//����������Ӳ�����
			{
				PPRCs myPPRCs = new PPRCs();
				isValid = myPPRCs.Add(myPPRCData);
				this.Message = myPPRCs.Message;
				return isValid;
			}
		}

		/// <summary>
		/// ��Ӧ�̷��� �޸ġ�
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	��Ӧ�̷�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(PPRCData myPPRCData)
		{
			bool isValid = true;
			//�жϴ��������ʵ���Ƿ�Ϊ�ա�
			if (myPPRCData.Tables[PPRCData.PPRC_Table].Rows.Count == 0)
			{
				this.Message = "������Ϊ�գ�" ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0];
			
			//�����޸ġ�
			{
				PPRCs myPPRCs = new PPRCs();
				isValid = myPPRCs.Update(myPPRCData);
				this.Message = myPPRCs.Message;
				return isValid;
			}
		}
		/// <summary>
		/// ��Ӧ�̷��� ɾ����
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	��Ӧ�̷�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(PPRCData myPPRCData)
		{
			bool isValid = true;
			if (myPPRCData.Tables[PPRCData.PPRC_Table].Rows.Count > 0)
			{
				PPRCs myPPRCs = new PPRCs();
				isValid = myPPRCs.Delete(myPPRCData);
				this.Message = myPPRCs.Message;
			}
			else
			{	
				this.Message = "������Ϊ�գ�";	
			}
			return isValid;
		}
	}
}
