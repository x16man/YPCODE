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
	/// ��;�����ݷ��ʲ㡣
	/// </summary>
	public class Purposes : Messages
	{
		public Purposes()
		{}
		/// <summary>
		/// ���������;��
		/// </summary>
		/// <returns>PurposeData:	��;����ʵ�塣</returns>
		public PurposeData GetPurposeAll()
		{
			PurposeData myDS = new PurposeData ();

			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetAll", myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ��ȡ������Ч����;��
		/// </summary>
		/// <returns>PurposeData:	��;����ʵ�塣</returns>
		public PurposeData GetPurposeAvalible()
		{
			PurposeData myDS = new PurposeData();

			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetAvalible", myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ������;��������;��Ϣ��
		/// </summary>
		/// <param name="Code">string:	��;���롣</param>
		/// <returns>PurposeData:	��;����ʵ�塣</returns>
		public PurposeData GetPurposeByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PurposeData myDS = new PurposeData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByCode", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ������;���Ʋ�����;��Ϣ��
		/// </summary>
		/// <param name="Description">string:	��;���ơ�</param>
		/// <returns>PurposeData:	��;����ʵ�塣</returns>
		public PurposeData GetPurposeByDescription(string Description)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PurposeData myDS = new PurposeData ();

			myHT.Add ("@Description",Description);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByDescription", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ���ݷ����ȡ��;��
		/// </summary>
		/// <param name="strClassify">string:	��;�����š�</param>
		/// <returns>PurposeData�� ��;ʵ�塣</returns>
		public PurposeData GetPurposeByClassify(string strClassify)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PurposeData myDS = new PurposeData ();

			myHT.Add ("@Classify",strClassify);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByClassify", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		public PurposeData GetPurposeByClassifyWithFlag(string strClassify,int Flag)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PurposeData myDS = new PurposeData ();

			myHT.Add ("@Classify",strClassify);
			myHT.Add ("@Flag", Flag);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByClassifyWithFlag", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		public PurposeData GetAvailablePurposeByPYWithFlag(string Classify,string PY, int Flag)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PurposeData myDS = new PurposeData ();
			myHT.Add("@Classify",Classify);
			myHT.Add ("@PYZM",PY);
			myHT.Add ("@Flag", Flag);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByPYWithFlag", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		public PurposeData GetAvailablePurposeByPY(string Classify,string PY)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PurposeData myDS = new PurposeData ();
		    myHT.Add("@Classify",Classify);
			myHT.Add ("@PYZM",PY);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByPY", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ��;���ӡ�
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	��;����ʵ�塣</param>
		/// <returns>bool:	���ӳɹ�����true,ʧ�ܷ���false.</returns>
		public bool Add(PurposeData myPurposeData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@Code",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@TargetAcc",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.TARGETACC_FIELD].ToString());
			myHT.Add ("@Enable",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.ENABLE_FIELD].ToString());
			myHT.Add ("@Classify",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CLASSIFY_FIELD].ToString());
			myHT.Add ("@ProjectCode",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.PROJECT_CODE_FIELD].ToString());
			myHT.Add ("@Flag", int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.FLAG_FIELD].ToString()));
			if (myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.thisYear_Field] == null)
				myHT.Add("@thisYear", null);
			else 
				myHT.Add("@thisYear", int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.thisYear_Field].ToString()));

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_PurposeInsert",myHT))
			{
				this.Message = PurposeData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PurposeData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// ��;�޸ġ�
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	��;����ʵ�塣</param>
		/// <returns>bool:	�޸ĳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(PurposeData myPurposeData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@OldCode",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.OLDCODE_FIELD].ToString());
			myHT.Add ("@Code",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@TargetAcc",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.TARGETACC_FIELD].ToString());
			myHT.Add ("@Enable",int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.ENABLE_FIELD].ToString()));
			myHT.Add ("@Classify",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CLASSIFY_FIELD].ToString());
			myHT.Add ("@ProjectCode",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.PROJECT_CODE_FIELD].ToString());
			myHT.Add ("@Flag", int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.FLAG_FIELD].ToString()) );
			if (myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.thisYear_Field] == null)
				myHT.Add("@thisYear",null);
			else
				myHT.Add("@thisYear",int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.thisYear_Field].ToString()));

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_PurposeUpdate",myHT))
			{
				this.Message = PurposeData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PurposeData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ��;ɾ����
		/// </summary>
		/// <param name="myStoData">PurposeData:	��;����ʵ�塣</param>
		/// <returns>bool:	ɾ���ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(PurposeData myPurposeData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable ();
			myHT.Add ("@Code", myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_PurposeDelete",myHT))
			{
				this.Message = PurposeData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PurposeData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ���ݴ������;���봮����ɾ����
		/// </summary>
		/// <param name="Codes">string:	��;�����ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable myHT = new Hashtable();
			myHT.Add("@Codes",Codes);
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_PurposeDeleteByCodes",myHT))
			{
				this.Message = PurposeData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PurposeData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		///	����SQL�����в�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL ��䡣</param>
		/// <returns>PurposeData:	��;����ʵ�塣</returns>
		public PurposeData GetPurposeBySQL(string Sql_Statement)
		{
			PurposeData oPurposeData = new PurposeData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oPurposeData.Tables[PurposeData.USE_TABLE]);
			return oPurposeData;
		}
	}
}
