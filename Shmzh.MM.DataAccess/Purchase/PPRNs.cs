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
	public class PPRNs : Messages
	{
		public PPRNs()
		{		}
		/// <summary>
		///  ������й�Ӧ��/�ͻ���Ϣ��
		/// </summary>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNAll ()
		{
			PPRNData ds = new PPRNData ();
			SQLServer mysp = new SQLServer ();

			if (!mysp.ExecSPReturnDS("Pur_PPRNGetAll",ds.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return ds;
		}
		/// <summary>
		/// �������״̬���Ѻ�׼ ����������ù�Ӧ��/�ͻ���Ϣ��
		/// </summary>
		/// <param name="Type">string:	���</param>
		/// <param name="Status">string:	״̬��</param>
		/// <param name="Approve">string:	�Ѻ�׼��</param>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNByTypeAndStatusAndApprove(string Type, string Status, string Approve)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PPRNData myDS = new PPRNData ();

			myHT.Add ("@Type",Type);
			myHT.Add ("@Status",Status);
			myHT.Add ("@Approve",Approve);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetByTypeAndStatusAndApprove", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ���ݹ�Ӧ��/�ͻ���Ż�ù�Ӧ��/�ͻ���Ϣ��
		/// </summary>
		/// <param name="Code">string:	��Ӧ��/�ͻ���š�</param>
		/// <returns>PPRNData:	��Ӧ��/�ͻ����ݼ���</returns>
		public PPRNData GetPPRNByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PPRNData myDS = new PPRNData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetByCode", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ��ȡ��ǰ������Ĺ�Ӧ����Ϣ.
		/// </summary>
		/// <returns>PPRNData:	��Ӧ��/�ͻ����ݼ���</returns>
		public PPRNData GetPPRNWithMaxCode()
		{
			PPRNData myDS = new PPRNData ();
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetWithMaxCode",myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ���ݹ�Ӧ��/�ͻ��������ƻ�ù�Ӧ��/�ͻ���Ϣ��
		/// </summary>
		/// <param name="CNName">string:	��Ӧ��/�ͻ��������ơ�</param>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNByCNName(string CNName)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PPRNData myDS = new PPRNData ();

			myHT.Add ("@CNName",CNName);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetByCNName", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ���ݹ�Ӧ��/�ͻ�Ӣ��������ȡ��Ӧ��/�ͻ���Ϣ��
		/// </summary>
		/// <param name="ENName">string:	��Ӧ��/�ͻ�Ӣ������</param>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNByENName(string ENName)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PPRNData myDS = new PPRNData ();

			myHT.Add ("@ENName",ENName);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetByENName", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ��ȡ����λ��Ϣ��
		/// </summary>
		/// <returns>PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</returns>
		public PPRNData GetPPRNSelf()
		{
			PPRNData myDS = new PPRNData ();
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PPRNGetSelf", myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� ���ӡ�
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Add(PPRNData myPPRNData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@Code",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString());				//��Ӧ�̴��롣
			myHT.Add ("@CNName",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CNNAME_FIELD].ToString());			//�������ơ�
			myHT.Add ("@ENName",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ENNAME_FIELD].ToString());			//Ӣ�����ơ�
			myHT.Add ("@Type",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TYPE_FIELD].ToString());				//���
			myHT.Add ("@Status",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.STATUS_FIELD].ToString());			//״̬��
			myHT.Add ("@Approve",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.APPROVE_FIELD].ToString());		//�Ѻ�׼��
			myHT.Add ("@Currency",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CURRENCY_FIELD].ToString());		//���Ҵ��롣
			myHT.Add ("@PayStyle",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.PAYSTYLE_FIELD].ToString());		//���ʽ��
			myHT.Add ("@Tel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TEL_FIELD].ToString());				//�绰��
			myHT.Add ("@Fax",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.FAX_FIELD].ToString());				//���档
			myHT.Add ("@Email",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.EMAIL_FIELD].ToString());			//���䡣
			myHT.Add ("@LinkMan",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKMAN_FIELD].ToString());		//��ϵ�ˡ�
			myHT.Add ("@LinkTel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKTEL_FIELD].ToString());		//��ϵ�˵绰��
			myHT.Add ("@LinkMail",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKMAIL_FIELD].ToString());		//��ϵ�����䡣
			myHT.Add ("@AccLink",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCLINK_FIELD].ToString());		//������ϵ�ˡ�
			myHT.Add ("@AccLinkTel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCLINKTEL_FIELD].ToString());	//������ϵ�˵绰��
			myHT.Add ("@Address",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ADDRESS_FIELD].ToString());		//��ַ��
			myHT.Add ("@Zip",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ZIP_FIELD].ToString());				//�ʱࡣ
			myHT.Add ("@Licence",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LICENCE_FIELD].ToString());		//Ӫҵִ�պ��롣
			myHT.Add ("@RegMoney",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.REGMONEY_FIELD].ToString());		//ע���ʽ�
			myHT.Add ("@Turnover",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TURNOVER_FIELD].ToString());		//��Ӫҵ�
			myHT.Add ("@Deputy",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.DEPUTY_FIELD].ToString());			//���˴���
			myHT.Add ("@Bank",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.BANK_FIELD].ToString());				//�������С�
			myHT.Add ("@Account",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCOUNT_FIELD].ToString());		//�˻���
			myHT.Add ("@TaxNO",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TAXNO_FIELD].ToString());			//˰��ǼǺš�
			myHT.Add ("@Country",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.COUNTRY_FIELD].ToString());		//���ҡ�
			myHT.Add ("@State",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.STATE_FIELD].ToString());			//��ʡ��
			myHT.Add ("@City",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CITY_FIELD].ToString());				//���С�
			myHT.Add ("@PurchaseAcc",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.PURCHASEACC_FIELD].ToString());//�ɹ��˻���
			myHT.Add ("@APAcc",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.APACC_FIELD].ToString());			//Ӧ���˻���
			myHT.Add ("@Remark",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.REMARK_FIELD].ToString());			//��ע��
			myHT.Add("@CatCode",int.Parse(myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CatCode_Field].ToString()));//��Ӧ�̷��ࡣ
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRNInsert",myHT))
			{
				this.Message = PPRNData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PPRNData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� �޸ġ�
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(PPRNData myPPRNData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@OldCode", myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.OLDCODE_FIELD].ToString());			//�޸�ǰ�Ĵ��롣
			myHT.Add ("@Code",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString());					//�޸ĺ�Ĵ��롣
			myHT.Add ("@CNName",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CNNAME_FIELD].ToString());				//�������ơ�
			myHT.Add ("@ENName",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ENNAME_FIELD].ToString());				//Ӣ�����ơ�
			myHT.Add ("@Type",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TYPE_FIELD].ToString());					//���
			myHT.Add ("@Status",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.STATUS_FIELD].ToString());				//״̬��
			myHT.Add ("@Approve",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.APPROVE_FIELD].ToString());			//�Ѻ�׼��
			myHT.Add ("@Currency",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CURRENCY_FIELD].ToString());			//���Ҵ��롣
			myHT.Add ("@PayStyle",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.PAYSTYLE_FIELD].ToString());			//���ʽ��
			myHT.Add ("@Tel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TEL_FIELD].ToString());					//�绰��
			myHT.Add ("@Fax",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.FAX_FIELD].ToString());					//���档
			myHT.Add ("@Email",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.EMAIL_FIELD].ToString());				//���䡣
			myHT.Add ("@LinkMan",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKMAN_FIELD].ToString());			//��ϵ�ˡ�
			myHT.Add ("@LinkTel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKTEL_FIELD].ToString());			//��ϵ�˵绰��
			myHT.Add ("@LinkMail",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LINKMAIL_FIELD].ToString());			//��ϵ�����䡣
			myHT.Add ("@AccLink",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCLINK_FIELD].ToString());			//������ϵ�ˡ�
			myHT.Add ("@AccLinkTel",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCLINKTEL_FIELD].ToString());		//������ϵ�˵绰��
			myHT.Add ("@Address",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ADDRESS_FIELD].ToString());			//��ַ��
			myHT.Add ("@Zip",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ZIP_FIELD].ToString());					//�ʱࡣ
			myHT.Add ("@Licence",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.LICENCE_FIELD].ToString());			//Ӫҵִ�պ��롣
			myHT.Add ("@RegMoney",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.REGMONEY_FIELD].ToString());			//ע���ʽ�
			myHT.Add ("@Turnover",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TURNOVER_FIELD].ToString());			//��Ӫҵ�
			myHT.Add ("@Deputy",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.DEPUTY_FIELD].ToString());				//���˴���
			myHT.Add ("@Bank",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.BANK_FIELD].ToString());					//�������С�
			myHT.Add ("@Account",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.ACCOUNT_FIELD].ToString());			//�˻���
			myHT.Add ("@TaxNO",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.TAXNO_FIELD].ToString());				//˰��ǼǺš�
			myHT.Add ("@Country",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.COUNTRY_FIELD].ToString());			//���ҡ�
			myHT.Add ("@State",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.STATE_FIELD].ToString());				//��ʡ��
			myHT.Add ("@City",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CITY_FIELD].ToString());					//���С�
			myHT.Add ("@PurchaseAcc",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.PURCHASEACC_FIELD].ToString());	//�ɹ��˻���
			myHT.Add ("@APAcc",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.APACC_FIELD].ToString());				//Ӧ���˻���
			myHT.Add ("@Remark",myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.REMARK_FIELD].ToString());				//��ע��
			myHT.Add("@CatCode",int.Parse(myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CatCode_Field].ToString()));//��Ӧ�̷��ࡣ
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRNUpdate",myHT))
			{
				this.Message = PPRNData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PPRNData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� ɾ����
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(PPRNData myPPRNData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@Code", myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRNDelete",myHT))
			{
				this.Message = PPRNData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PPRNData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ���ݹ�Ӧ�̴����ַ������й�Ӧ��ɾ����
		/// </summary>
		/// <param name="Codes">string:	��Ӧ���ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@Codes", Codes);

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRNDeleteByCodes",myHT))
			{
				this.Message = PPRNData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PPRNData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}

		#region ͨ�ò�ѯ
		public PPRNData GetPPRNBySQL(string Sql_Statement)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			PPRNData myDS = new PPRNData ();

			myHT.Add("@Sql_Statement",Sql_Statement);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Qry_ExecSQL", myHT, myDS.Tables [PPRNData.PPRN_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return myDS;
		}
		#endregion
	}
}
