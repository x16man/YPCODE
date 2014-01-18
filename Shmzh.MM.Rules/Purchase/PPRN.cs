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
	public class PPRN : Messages
	{
		/// <summary>
		/// ��Ӧ��/�ͻ� ���ӡ�
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(PPRNData myPPRNData)
		{
			bool isValid = true;
			//�жϴ��������ʵ���Ƿ�Ϊ�ա�
			if (myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
			{
				this.Message = PPRNData.NO_ROW ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0];
			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
			isValid = InputCheck.IsValidField(myRow,PPRNData.CODE_FIELD,PPRNData.CODE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,6) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CNNAME_FIELD,PPRNData.CNNAME_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ENNAME_FIELD,PPRNData.ENNAME_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TYPE_FIELD,PPRNData.TYPE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.STATUS_FIELD,PPRNData.STATUS_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.APPROVE_FIELD,PPRNData.APPROVE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CURRENCY_FIELD,PPRNData.CURRENCY_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,5) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.PAYSTYLE_FIELD,PPRNData.PAYSTYLE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TEL_FIELD,PPRNData.TEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.FAX_FIELD,PPRNData.FAX_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.EMAIL_FIELD,PPRNData.EMAIL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKMAN_FIELD,PPRNData.LINKMAN_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKTEL_FIELD,PPRNData.LINKTEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKMAIL_FIELD,PPRNData.LINKMAIL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCLINK_FIELD,PPRNData.ACCLINK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCLINKTEL_FIELD,PPRNData.ACCLINKTEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ADDRESS_FIELD,PPRNData.ADDRESS_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ZIP_FIELD,PPRNData.ZIP_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,12) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LICENCE_FIELD,PPRNData.LICENCE_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.REGMONEY_FIELD,PPRNData.REGMONEY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TURNOVER_FIELD,PPRNData.TURNOVER_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.DEPUTY_FIELD,PPRNData.DEPUTY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.BANK_FIELD,PPRNData.BANK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCOUNT_FIELD,PPRNData.ACCOUNT_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.BANK_FIELD,PPRNData.BANK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCOUNT_FIELD,PPRNData.ACCOUNT_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TAXNO_FIELD,PPRNData.TAXNO_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.COUNTRY_FIELD,PPRNData.COUNTRY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.STATE_FIELD,PPRNData.STATE_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CITY_FIELD,PPRNData.CITY_FIELD,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.PURCHASEACC_FIELD,PPRNData.PURCHASEACC_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.APACC_FIELD,PPRNData.APACC_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.REMARK_FIELD,PPRNData.REMARK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,100) && isValid;
			if ( !isValid)//���������鲻ͨ������ֱ�ӷ��ء�
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//�жϹ�Ӧ�̿ͻ�����Ƿ���Ч����Чֱ�ӷ��ء�
			if ( !IsValidNewCode(myRow[PPRNData.CODE_FIELD].ToString()))//��Ӧ��/�ͻ������Ч��
			{
				this.Message = PPRNData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//�жϹ�Ӧ�̿ͻ����������Ƿ���Ч����Чֱ�ӷ��ء�
			if ( !IsValidNewCNName(myRow[PPRNData.CNNAME_FIELD].ToString()))//��Ӧ��/�ͻ�����������Ч��
			{
				this.Message = PPRNData.CNNAME_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//�жϹ�Ӧ��Ӣ�������Ƿ���Ч����Чֱ�ӷ��ء�
			if ( !IsValidNewENName(myRow[PPRNData.ENNAME_FIELD].ToString()) )//��Ӧ��/�ͻ�Ӣ��������Ч��
			{
				this.Message = PPRNData.ENNAME_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//�ж�OTA���͵���Ч�ԣ���Чֱ�ӷ��ء�

			//ǰ������ݼ�鶼ͨ���ˡ�						
			//����������Ӳ�����
			{
				PPRNs myPPRNs = new PPRNs();
				isValid = myPPRNs.Add(myPPRNData);
				this.Message = myPPRNs.Message;
				return isValid;
			}
		}

		/// <summary>
		/// ��Ӧ��/�ͻ� �޸ġ�
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(PPRNData myPPRNData)
		{
			bool isValid = true;
			//�жϴ��������ʵ���Ƿ�Ϊ�ա�
			if (myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
			{
				this.Message = PPRNData.NO_ROW ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0];
			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
			isValid = InputCheck.IsValidField(myRow,PPRNData.CODE_FIELD,PPRNData.CODE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,6) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CNNAME_FIELD,PPRNData.CNNAME_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ENNAME_FIELD,PPRNData.ENNAME_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TYPE_FIELD,PPRNData.TYPE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.STATUS_FIELD,PPRNData.STATUS_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.APPROVE_FIELD,PPRNData.APPROVE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CURRENCY_FIELD,PPRNData.CURRENCY_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,5) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.PAYSTYLE_FIELD,PPRNData.PAYSTYLE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TEL_FIELD,PPRNData.TEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.FAX_FIELD,PPRNData.FAX_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.EMAIL_FIELD,PPRNData.EMAIL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKMAN_FIELD,PPRNData.LINKMAN_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKTEL_FIELD,PPRNData.LINKTEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKMAIL_FIELD,PPRNData.LINKMAIL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCLINK_FIELD,PPRNData.ACCLINK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCLINKTEL_FIELD,PPRNData.ACCLINKTEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ADDRESS_FIELD,PPRNData.ADDRESS_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ZIP_FIELD,PPRNData.ZIP_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,12) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LICENCE_FIELD,PPRNData.LICENCE_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.REGMONEY_FIELD,PPRNData.REGMONEY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TURNOVER_FIELD,PPRNData.TURNOVER_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.DEPUTY_FIELD,PPRNData.DEPUTY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.BANK_FIELD,PPRNData.BANK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCOUNT_FIELD,PPRNData.ACCOUNT_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.BANK_FIELD,PPRNData.BANK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCOUNT_FIELD,PPRNData.ACCOUNT_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TAXNO_FIELD,PPRNData.TAXNO_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.COUNTRY_FIELD,PPRNData.COUNTRY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.STATE_FIELD,PPRNData.STATE_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CITY_FIELD,PPRNData.CITY_FIELD,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.PURCHASEACC_FIELD,PPRNData.PURCHASEACC_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.APACC_FIELD,PPRNData.APACC_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.REMARK_FIELD,PPRNData.REMARK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,100) && isValid;
			//����������ݲ��������ݿ�Ҫ����ֱ�ӷ��ء�
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//�жϹ�Ӧ��/�ͻ���ŵ���Ч�ԣ���Чֱ�ӷ��ء�
			if ( !IsValidCode(myRow[PPRNData.OLDCODE_FIELD].ToString(),myRow[PPRNData.CODE_FIELD].ToString()))//��Ӧ��/�ͻ������Ч��
			{
				this.Message = PPRNData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//�жϹ�Ӧ��/�ͻ��������Ƶ���Ч�ԣ���Чֱ�ӷ��ء�
			if ( !IsValidCNName(myRow[PPRNData.OLDCODE_FIELD].ToString(),myRow[PPRNData.CNNAME_FIELD].ToString()))//��Ӧ��/�ͻ�����������Ч��
			{
				this.Message = PPRNData.CNNAME_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//�жϹ�Ӧ��/�ͻ�Ӣ�����Ƶ���Ч�ԣ���Чֱ�ӷ��ء�
			if ( !IsValidENName(myRow[PPRNData.OLDCODE_FIELD].ToString(),myRow[PPRNData.ENNAME_FIELD].ToString()))//��Ӧ��/�ͻ�Ӣ��������Ч��
			{
				this.Message = PPRNData.ENNAME_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//�ж�OTA���Ե���Ч�ԣ���Чֱ�ӷ��ء�
			if ( !IsValidType( myRow[PPRNData.TYPE_FIELD].ToString()) )
			{
				this.Message = PPRNData.OTA_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//�����޸ġ�
			{
				PPRNs myPPRNs = new PPRNs();
				isValid = myPPRNs.Update(myPPRNData);
				this.Message = myPPRNs.Message;
				return isValid;
			}
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� ɾ����
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	��Ӧ��/�ͻ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(PPRNData myPPRNData)
		{
			bool isValid = true;
			if (myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count > 0)
			{
				PPRNs myPPRNs = new PPRNs();
				isValid = myPPRNs.Delete(myPPRNData);
				this.Message = myPPRNs.Message;
			}
			else
			{	
				this.Message = PPRNData.NO_ROW;	
			}
			return isValid;
		}
		/// <summary>
		/// ���ݴ���Ĺ�Ӧ�̴��봮���й�Ӧ��ɾ����
		/// </summary>
		/// <param name="Codes">string:	��Ӧ�̴����ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string Codes)
		{
			bool isValid = true;
			if (Codes != null && Codes != "")
			{
				PPRNs myPPRNs = new PPRNs();
				isValid = myPPRNs.Delete(Codes);
				this.Message = myPPRNs.Message;
			}
			else
			{	
				this.Message = PPRNData.NO_ROW;	
			}
			return isValid;
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� ����ʱ�ж� ����Ƿ���Ч��
		/// </summary>
		/// <param name="Code">string:	��Ӧ��/�ͻ���š�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewCode(string Code)
		{
			PPRNs myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByCode(Code).Tables[PPRNData.PPRN_TABLE].Rows.Count > 0 ? false:true;
		}
		
		/// <summary>
		/// ��Ӧ��/�ͻ� �޸�ʱ�ж� ����Ƿ���Ч��
		/// </summary>
		/// <param name="OldCode">string:	�޸�ǰ��š�</param>
		/// <param name="Code">string:	�޸ĺ��š�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidCode(string OldCode, string Code)
		{
			PPRNData myPPRNData;
			PPRNs myPPRNs = new PPRNs();
			myPPRNData = myPPRNs.GetPPRNByCode(Code);
			if ( myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else
			{
				return OldCode==Code?true:false;
			}
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� ����ʱ�ж������Ƿ���Ч��
		/// </summary>
		/// <param name="CNName">string:	��Ӧ��/�ͻ��������ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewCNName(string CNName)
		{
			PPRNs myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByCNName(CNName).Tables[PPRNData.PPRN_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� �޸�ʱ�ж����������Ƿ���Ч��
		/// </summary>
		/// <param name="OldCode">string:	�޸�ǰ��Ӧ��/�ͻ���š�</param>
		/// <param name="CCName">string:	�޸ĺ�Ĺ�Ӧ��/�ͻ��������ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidCNName(string OldCode, string CCName)
		{
			PPRNData myPPRNData;
			PPRNs myPPRNs = new PPRNs();
			myPPRNData = myPPRNs.GetPPRNByCNName(CCName);
			if ( myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else
			{
				return OldCode==myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString()?true:false;
			}
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� ����ʱ�ж�Ӣ�������Ƿ���Ч��
		/// </summary>
		/// <param name="ENName">string:	��Ӧ��/�ͻ�Ӣ�����ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewENName(string ENName)
		{
			PPRNs myPPRNs = new PPRNs();
			if (ENName == null || ENName == "")
				return true;
			else
				return myPPRNs.GetPPRNByENName(ENName).Tables[PPRNData.PPRN_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// ��Ӧ��/�ͻ� �޸�ʱ�ж�Ӣ�������Ƿ���Ч��
		/// </summary>
		/// <param name="OldCode">string:	�޸�ǰ��Ӧ��/�ͻ���š�</param>
		/// <param name="ENName">string:	�޸ĺ�Ӧ��/�ͻ�Ӣ�����ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidENName(string OldCode, string ENName)
		{
			PPRNData myPPRNData;
			if (ENName == null || ENName == "")
				return true;
			else
			{
				PPRNs myPPRNs = new PPRNs();
				myPPRNData = myPPRNs.GetPPRNByENName(ENName);
				if ( myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
				{
					return true;
				}
				else
				{
					return OldCode==myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString()?true:false;
				}
			}
		}
		//�����ж���Ҫ���жϣ��û��Ƿ�ѡ����OTA���͡�
		//OTA���ͣ���ϵͳĬ�ϼ�¼ʹ�õ����͡�
		//ֻ����һ����¼��OTA���͵ġ�
		//����Ҫ�������͵ļ�顣
		private bool IsValidType(string Type)
		{
			if ( Type == "O")//��Ӧ��/�ͻ������������"O",��ʾ��OTA���͹�Ӧ�̡�
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
