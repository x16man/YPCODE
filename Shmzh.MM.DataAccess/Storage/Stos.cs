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
	/// Stos ��ժҪ˵����
	/// </summary>
	public class Stos : Messages
	{
		public Stos()
		{		}
		/// <summary>
		/// ������вֿ⡣
		/// </summary>
		/// <returns>StoData:	�ֿ�����ʵ�塣</returns>
		public StoData GetStoAll()
		{
			StoData myDS = new StoData ();

			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoGetAll", myDS.Tables [StoData.STO_TABLE]))
			{
				this.Message = StoData.QUERY_FAILED;
			}
			return myDS;
		}

        /// <summary>
        /// ������вֿ⡣
        /// </summary>
        /// <returns>StoData:	�ֿ�����ʵ�塣</returns>
        public StoData GetStoAllCode()
        {
            StoData myDS = new StoData();

            SQLServer mySP = new SQLServer();
            if (!mySP.ExecSPReturnDS("Sto_StoGetAllCode", myDS.Tables[StoData.STO_TABLE]))
            {
                this.Message = StoData.QUERY_FAILED;
            }
            return myDS;
        }

		/// <summary>
		/// ���ݲֿ��Ż�òֿ���Ϣ��
		/// </summary>
		/// <param name="Code">string:	�ֿ��š�</param>
		/// <returns>StoData:	�ֿ�����ʵ�塣</returns>
		public StoData GetStoByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			StoData myDS = new StoData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoGetByCode", myHT, myDS.Tables [StoData.STO_TABLE]))
			{
				this.Message = StoData.QUERY_FAILED;
			}
			return myDS;
		}

        public StockData GetQueryStock(string LoginName)
        {
            StockData oStockData = new StockData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@UserLoginId", LoginName);


            oSQLServer.ExecSPReturnDS("Sto_StockQueryGetByItem", oHT, oStockData.Tables[StockData.WSTK_TABLE]);
            return oStockData;
        }

		/// <summary>
		/// ���ݲֿ����Ʋ��Ҳֿ���Ϣ��
		/// </summary>
		/// <param name="Description">string:	�ֿ����ơ�</param>
		/// <returns>StoData:	�ֿ�����ʵ�塣</returns>
		public StoData GetStoByDescription(string Description)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			StoData myDS = new StoData ();

			myHT.Add ("@Description",Description);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoGetByDescription", myHT, myDS.Tables [StoData.STO_TABLE]))
			{
				this.Message = StoData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// �ֿ����ӡ�
		/// </summary>
		/// <param name="myStoData">StoData:	��λ����ʵ�塣</param>
		/// <returns>bool:	���ӳɹ�����true,ʧ�ܷ���false.</returns>
		public bool Add(StoData myStoData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@Code",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@Locked",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.LOCKED_FIELD].ToString());
			myHT.Add ("@StorageAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.STOACC_FIELD].ToString());
			myHT.Add ("@TransferAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.TRFACC_FIELD].ToString());
			myHT.Add ("@ReturnAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.RETURNACC_FIELD].ToString());
			myHT.Add ("@Address",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.ADDRESS_FIELD].ToString());
			myHT.Add ("@Relation",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.RELATION_FIELD].ToString());
			

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoInsert",myHT))
			{
				this.Message = StoData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// �ֿ��޸ġ�
		/// </summary>
		/// <param name="myStoData">StoData:	�ֿ�����ʵ�塣</param>
		/// <returns>bool:	�޸ĳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(StoData myStoData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@Code",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@Locked",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.LOCKED_FIELD].ToString());
			myHT.Add ("@StorageAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.STOACC_FIELD].ToString());
			myHT.Add ("@TransferAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.TRFACC_FIELD].ToString());
			myHT.Add ("@ReturnAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.RETURNACC_FIELD].ToString());
			myHT.Add ("@Address",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.ADDRESS_FIELD].ToString());
			myHT.Add ("@Relation",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.RELATION_FIELD].ToString());
			
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoUpdate",myHT))
			{
				this.Message = StoData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// �ֿ�ɾ����
		/// </summary>
		/// <param name="myStoData">StoData:	�ֿ�����ʵ�塣</param>
		/// <returns>bool:	ɾ���ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(StoData myStoData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable ();
			myHT.Add ("@Code", myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.CODE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoDelete",myHT))
			{
				this.Message = StoData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ���ݴ���Ĳֿ���봮����ɾ����
		/// </summary>
		/// <param name="Codes">string:	�ֿ�����ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable();
            myHT.Add("@Code", Codes);
			SQLServer mySP = new SQLServer ();
            if (mySP.ExecSP("Sto_StoDelete", myHT))
			{
				this.Message = StoData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = mySP.ExceptionMessage;
				retValue = false;
			}
			return retValue;
		}
	}
}
