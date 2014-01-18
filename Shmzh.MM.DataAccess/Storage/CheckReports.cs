using System;
using MZHCommon.Database;
using Shmzh.MM.Common;
using System.Data;
using System.Collections;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// Categories ��ժҪ˵����
	/// </summary>
	public class CheckReports:Messages
	{
		/// <summary>
		/// �������鱨��
		/// </summary>
		/// <param name="oCheckReportsData">���鱨��ʵ��</param>
		/// <returns>true or false</returns>
		public bool InsertCheckReports(CheckReportData oCheckReportsData)
		{
			Hashtable oHT=new Hashtable();
			
			DataRow oRow;
			
			oRow=oCheckReportsData.Tables[CheckReportData.CHECKREPORT_TABLE].Rows[0];

			oHT.Add("@Code",oRow[CheckReportData.CODE_FIELD]);
			oHT.Add("@Description",oRow[CheckReportData.DESCRIPTION_FIELD]);
			oHT.Add("@Locked",oRow[CheckReportData.LOCKED_FIELD]);

			return (new SQLServer()).ExecSP("Sto_CheckReportsInsert",oHT);

		}	//End InsertCheckReports


		/// <summary>
		/// �༭���鱨��
		/// </summary>
		/// <param name="oCheckReportsData">���鱨��ʵ��</param>
		/// <returns>true or false</returns>
		public bool UpdateCheckReports(CheckReportData oCheckReportsData)
		{
			Hashtable oHT=new Hashtable();

			DataRow oRow;

			oRow=oCheckReportsData.Tables[CheckReportData.CHECKREPORT_TABLE].Rows[0];

			oHT.Add("@Code",oRow[CheckReportData.CODE_FIELD]);
			oHT.Add("@Description",oRow[CheckReportData.DESCRIPTION_FIELD]);
			oHT.Add("@Locked",oRow[CheckReportData.LOCKED_FIELD]);

			return (new SQLServer()).ExecSP("Sto_CheckReportsUpdate",oHT);

		}	//End UpdateCategroy


		/// <summary>
		/// ɾ�����鱨��
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public bool DeleteCheckReportsByCode(string Code)
		{
			bool ret=true;

			Hashtable oHT=new Hashtable();

			oHT.Add("@Codes",Code);
			
			if ((new SQLServer()).ExecSP("Sto_CheckReportsDelete",oHT)==false)
			{
				this.Message="Error,Sto_CheckReportsDelete,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// �õ����鱨����Ϣ
		/// </summary>
		/// <param name="Code">IF Code=-1,�õ����еļ��鱨��</param>
		/// <returns>���ݼ�</returns>
		public CheckReportData GetCheckReportsByCode(int Code)
		{
			CheckReportData oCheckReportsData=new CheckReportData();

			Hashtable oHT=new Hashtable();

			oHT.Add("@Code",Code);
			
			if ((new SQLServer()).ExecSPReturnDS("Sto_CheckReportByCode",oHT,oCheckReportsData.Tables[CheckReportData.CHECKREPORT_TABLE])==false)
			{
				this.Message="Error,Sto_CheckReportsQueryByCode,Please look the log file!";
			}
			return oCheckReportsData;
		}		// End GetCheckReportsByCode

	}
}

