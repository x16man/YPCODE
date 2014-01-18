using System.Collections;
using MZHCommon.Database;
using Shmzh.MM.Common;
//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// ��Ӧ��/�ͻ�����ʵ��㡣
	/// </summary>
	public class PPRCs : Messages
	{
		public PPRCs()
		{		}
		/// <summary>
		///  ������й�Ӧ�̷�����Ϣ��
		/// </summary>
		/// <returns>PPRCData:	��Ӧ�̷�������ʵ�塣</returns>
		public PPRCData GetPPRCAll ()
		{
			PPRCData ds = new PPRCData ();
			SQLServer mysp = new SQLServer ();

			mysp.ExecSPReturnDS("Pur_PPRCGetAll",ds.Tables [PPRCData.PPRC_Table]);
			
			return ds;
		}
		/// <summary>
		/// ���ݱ�Ż�ȡ��Ӧ�̷��ࡣ
		/// </summary>
		/// <param name="Code">int:	��š�</param>
		/// <returns>PPRCData:	��Ӧ�̷�������ʵ�塣</returns>
		public PPRCData GetPPRCByCode(int Code)
		{
			PPRCData ds = new PPRCData();
			SQLServer mysp = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Code", Code);

			mysp.ExecSPReturnDS("Pur_PPRCGetByCode",oHT,ds.Tables [PPRCData.PPRC_Table]);
			return ds;
		}
		/// <summary>
		/// ��Ӧ�̷������ӡ�
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	��Ӧ�̷�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Add(PPRCData myPPRCData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			
			myHT.Add("@CnName",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.CnName_Field].ToString());			//�������ơ�
			myHT.Add("@EnName",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.EnName_Field].ToString());			//Ӣ�����ơ�
			myHT.Add("@Desc", myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.Desc_Field].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRCInsert",myHT))
			{
				retValue = true;
			}
			else
			{
				this.Message = "��Ӧ�̷������ʧ�ܣ�";
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// ��Ӧ�̷����޸ġ�
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	��Ӧ�̷�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(PPRCData myPPRCData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��

			myHT.Add ("@Code",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.Code_Field].ToString());	
			myHT.Add("@CnName",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.CnName_Field].ToString());			//�������ơ�
			myHT.Add("@EnName",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.EnName_Field].ToString());			//Ӣ�����ơ�
			myHT.Add("@Desc", myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.Desc_Field].ToString());
			
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRCUpdate",myHT))
			{
				retValue = true;
			}
			else
			{
				this.Message = "��Ӧ�̷����޸�ʧ�ܣ�";
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ��Ӧ�̷���ɾ����
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	��Ӧ�̷�������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(PPRCData myPPRCData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@Code", myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.Code_Field].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRCDelete",myHT))
			{
				retValue = true;
			}
			else
			{
				this.Message = "��Ӧ�̷���ɾ��ʧ�ܣ�";
				retValue = false;
			}
			return retValue;
		}
	}
}
