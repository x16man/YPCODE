using System;
using System.Data;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Common;
using MZHCommon.Input;

namespace Shmzh.MM.BusinessRules
{
	/// <summary>
	/// CheckReport ��ժҪ˵����
	/// </summary>
	public class CheckReport:Messages
	{
		/// <summary>
		/// ������鱨��
		/// </summary>
		/// <param name="oCheckReportData">���鱨��ʵ��</param>
		/// <returns>true or false</returns>
		public bool Insert(CheckReportData oCheckReportData)
		{
			bool isValid=true;

			DataRow aRow=oCheckReportData.Tables[CheckReportData.CHECKREPORT_TABLE].Rows[0];

			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
//			isValid = InputCheck.IsValidField(aRow, CheckReportData.CODE_FIELD, CheckReportData.CODE_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Int, -1) && isValid;
//			isValid = InputCheck.IsValidField(aRow, CheckReportData.DESCRIPTION_FIELD, CheckReportData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
//			
//			if (isValid)
//			{
//				//�жϱ����Ƿ��Ѿ�����
//				if (IsExistCheckReportCode(int.Parse(aRow[CheckReportData.CODE_FIELD].ToString())))
//				{
//					//this.Message=CheckReportData.CODE_NOT_UNIQUE;
//					isValid=false;
//				}
//			}
//			else
//			{
//				this.Message=InputCheck.ErrorInfo;
//			}
//
//			if(isValid)
//			{
//				CheckReports oCheckReports=new CheckReports();
//
//				if (oCheckReports.InsertCheckReport(oCheckReportData)==false)
//				{
//					this.Message=oCheckReports.Message;
//					isValid=false;
//				}
//			}
			return isValid;
		}		//End Insert


		/// <summary>
		/// ���¼��鱨�棬��Ҫ�����ơ���Ŀ
		/// </summary>
		/// <param name="oCheckReportData">���鱨��ʵ��</param>
		/// <returns>true or false</returns>
		public bool Update(CheckReportData oCheckReportData)
		{
			bool isValid=true;

//			DataRow aRow=oCheckReportData.Tables[CheckReportData.CHECKREPORT_TABLE].Rows[0];
//
//			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
////			isValid = InputCheck.IsValidField(aRow, CheckReportData.DESCRIPTION_FIELD, CheckReportData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
//		
//			
//			if (!isValid)
//			{
//				this.Message=InputCheck.ErrorInfo;
//			}
//
//			if(isValid)
//			{
//				CheckReports oCheckReports=new CheckReports();
//
//				if (oCheckReports.UpdateCheckReport(oCheckReportData)==false)
//				{
//					this.Message=oCheckReports.Message;
//					isValid=false;
//				}
//			}
			return isValid;
		}		//End Update


		/// <summary>
		/// ɾ��
		/// </summary>
		/// <param name="Code">����б�</param>
		/// <returns></returns>
		public bool Delete(string Code)
		{
			//1.�ֽ�Code��
			//2.��ÿһ��Code�����жϣ��Ƿ��Ѿ����ڹ���������������
			//3.�Ѿ������ķ����б��з���,����ɾ����ɾ��
			//4.
//			string CanNotDelte="";
//			string CanDelete;
//
//			CanDelete=DoWithDeleteCode(Code,CanNotDelte);
//
//			if (CanNotDelte=="") this.Message=CanNotDelte;
//
//			return (new CheckReports()).DeleteCheckReportByCode(CanDelete);

			return true;
			
		}

		//��ÿһ��Code�����жϣ��Ƿ��Ѿ����ڹ���������������
		private string DoWithDeleteCode(string Code,string CanNotDelte)
		{
			return Code;
		}


		/// <summary>
		/// �õ����鱨��
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public CheckReportData GetCheckReportByCode(int Code)
		{
			return (new CheckReports()).GetCheckReportsByCode(Code);
		}	//End GetCheckReportByCode


		/// <summary>
		/// �õ����м��鱨��
		/// </summary>
		/// <returns>���鱨��ʵ��</returns>
		public CheckReportData GetCheckReports()
		{
			return (new CheckReports()).GetCheckReportsByCode(-1);
		}	//End GetCheckReports

		
		/// <summary>
		/// �жϼ��鱨���Ƿ��Ѿ�����
		/// </summary>
		/// <param name="Code">���鱨����</param>
		/// <returns>���ڻ򲻴���</returns>
		public bool IsExistCheckReportCode(int Code)
		{
			bool ret=true;

//			if(Code!=-1)
//			{
//				if ((new CheckReports()).GetCheckReportByCode(Code).Tables[CheckReportData.CheckReport_TABLE].Rows.Count==0)
//				{
//					ret=false;
//				}
//			}
			return ret;
		}	//End IsExistCheckReportCode
	
	}		//End class
}	//End namespace
