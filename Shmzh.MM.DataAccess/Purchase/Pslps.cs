//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Data.SqlClient;
	using System.Configuration ;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	/// <summary>
	/// �ɹ�Ա���ݷ��ʲ㡣
	/// </summary>
	public class Pslps : Messages
	{
		public Pslps()
		{		}
		/// <summary>
		///  ������вɹ�Ա��Ϣ��
		/// </summary>
		/// <returns>PslpData:	�ɹ�Ա����ʵ�塣</returns>
		public PslpData GetPslpAll ()
		{
			PslpData ds = new PslpData ();
			SQLServer mysp = new SQLServer ();

			if (!mysp.ExecSPReturnDS("Pur_PslpGetAll",ds.Tables [PslpData.PSLP_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return ds;
		}

        /// <summary>
        ///  ������вɹ�Ա��Ϣ��
        /// </summary>
        /// <returns>PslpData:	�ɹ�Ա����ʵ�塣</returns>
        public PslpData GetPslpAllCode()
        {
            PslpData ds = new PslpData();
            SQLServer mysp = new SQLServer();

            if (!mysp.ExecSPReturnDS("Pur_PslpGetAllCode", ds.Tables[PslpData.PSLP_TABLE]))
            {
                this.Message = PPRNData.QUERY_FAILED;
            }
            return ds;
        }

		/// <summary>
		/// ���ݲɹ�Ա�����òɹ�Ա��Ϣ��
		/// </summary>
		/// <param name="Code">string:	�ɹ�Ա���롣</param>
		/// <returns>PslpData:	�ɹ�Ա���ݼ���</returns>
		public PslpData GetPslpByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PslpData myDS = new PslpData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PslpGetByCode", myHT, myDS.Tables [PslpData.PSLP_TABLE]))
			{
				this.Message = PslpData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// �ɹ�Ա ���ӡ�
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Add(PslpData myPslpData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@Code",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.CODE_FIELD].ToString());				//�ɹ�Ա���롣
			myHT.Add ("@Description",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.DESCRIPTION_FIELD].ToString());			//�ɹ�Ա������
			myHT.Add ("@Locked",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.LOCKED_FIELD].ToString());			//������

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PslpInsert",myHT))
			{
				this.Message = PslpData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PslpData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// �ɹ�Ա �޸ġ�
		/// </summary>
		/// <param name="myPPRNData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(PslpData myPslpData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@OldCode", myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.OLDCODE_FIELD].ToString());			//�޸�ǰ�Ĵ��롣
			myHT.Add ("@Code",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.CODE_FIELD].ToString());					//�޸ĺ�Ĵ��롣
			myHT.Add ("@Description",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.DESCRIPTION_FIELD].ToString());	//�ɹ�Ա������
			
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PslpUpdate",myHT))
			{
				this.Message = PslpData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PslpData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// �ɹ�Ա ɾ����
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(PslpData myPslpData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@Code", myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.CODE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PslpDelete",myHT))
			{
				this.Message = PslpData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PslpData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ���ݲɹ�Ա�����ַ������й�Ӧ��ɾ����
		/// </summary>
		/// <param name="Codes">string:	�ɹ�Ա�ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@Codes", Codes);

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PslpDeleteByCodes",myHT))
			{
				this.Message = PslpData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PslpData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
	}
}
