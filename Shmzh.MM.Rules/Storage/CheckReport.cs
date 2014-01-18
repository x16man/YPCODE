using System;
using System.Data;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Common;
using MZHCommon.Input;

namespace Shmzh.MM.BusinessRules
{
	/// <summary>
	/// CheckReport 的摘要说明。
	/// </summary>
	public class CheckReport:Messages
	{
		/// <summary>
		/// 插入检验报告
		/// </summary>
		/// <param name="oCheckReportData">检验报告实体</param>
		/// <returns>true or false</returns>
		public bool Insert(CheckReportData oCheckReportData)
		{
			bool isValid=true;

			DataRow aRow=oCheckReportData.Tables[CheckReportData.CHECKREPORT_TABLE].Rows[0];

			//检查字段值的合法性,所有需要加以判断的字段的入口
//			isValid = InputCheck.IsValidField(aRow, CheckReportData.CODE_FIELD, CheckReportData.CODE_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Int, -1) && isValid;
//			isValid = InputCheck.IsValidField(aRow, CheckReportData.DESCRIPTION_FIELD, CheckReportData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
//			
//			if (isValid)
//			{
//				//判断编码是否已经存在
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
		/// 更新检验报告，主要有名称、科目
		/// </summary>
		/// <param name="oCheckReportData">检验报告实体</param>
		/// <returns>true or false</returns>
		public bool Update(CheckReportData oCheckReportData)
		{
			bool isValid=true;

//			DataRow aRow=oCheckReportData.Tables[CheckReportData.CHECKREPORT_TABLE].Rows[0];
//
//			//检查字段值的合法性,所有需要加以判断的字段的入口
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
		/// 删除
		/// </summary>
		/// <param name="Code">编号列表</param>
		/// <returns></returns>
		public bool Delete(string Code)
		{
			//1.分解Code串
			//2.对每一个Code进行判断，是否已经存在关联的物料主数据
			//3.已经关联的放在列表中返回,可以删除的删除
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

		//对每一个Code进行判断，是否已经存在关联的物料主数据
		private string DoWithDeleteCode(string Code,string CanNotDelte)
		{
			return Code;
		}


		/// <summary>
		/// 得到检验报告
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public CheckReportData GetCheckReportByCode(int Code)
		{
			return (new CheckReports()).GetCheckReportsByCode(Code);
		}	//End GetCheckReportByCode


		/// <summary>
		/// 得到所有检验报告
		/// </summary>
		/// <returns>检验报告实体</returns>
		public CheckReportData GetCheckReports()
		{
			return (new CheckReports()).GetCheckReportsByCode(-1);
		}	//End GetCheckReports

		
		/// <summary>
		/// 判断检验报告是否已经存在
		/// </summary>
		/// <param name="Code">检验报告编号</param>
		/// <returns>存在或不存在</returns>
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
