using System;
using System.Data;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Common;
using MZHCommon.Input;

namespace Shmzh.MM.BusinessRules
{
	/// <summary>
	/// Unit 的摘要说明。
	/// </summary>
	public class Unit:Messages
	{
		/// <summary>
		/// 插入度量单位
		/// </summary>
		/// <param name="oUnitData">度量单位实体</param>
		/// <returns>true or false</returns>
		public bool Insert(UnitData oUnitData)
		{
			bool isValid=true;

			DataRow aRow=oUnitData.Tables[UnitData.UNIT_TABLE].Rows[0];

			//检查字段值的合法性,所有需要加以判断的字段的入口
			isValid = InputCheck.IsValidField(aRow, UnitData.CODE_FIELD, UnitData.CODE_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Int, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.DESCRIPTION_FIELD, UnitData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			
			isValid = InputCheck.IsValidField(aRow, UnitData.ABBREVIATE_FIELD,UnitData.ABBREVIATE_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 5) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.CONUNIT_FIELD,UnitData.CONUNIT_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.CONVERSION_FIELD,UnitData.CONVERSION_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.EQUIVALENCE_FIELD,UnitData.EQUIVALENCE_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;

			if (isValid)
			{
				//判断编码是否已经存在
				if (IsExistUnitCode(int.Parse(aRow[UnitData.CODE_FIELD].ToString())))
				{
					this.Message=UnitData.CODE_NOT_UNIQUE;
					isValid=false;
				}
			}
			else
			{
				this.Message=InputCheck.ErrorInfo;
			}

			if(isValid)
			{
				Units oUnits=new Units();

				if (oUnits.InsertUnit(oUnitData)==false)
				{
					this.Message=oUnits.Message;
					isValid=false;
				}
			}
			return isValid;
		}		//End Insert


		/// <summary>
		/// 更新度量单位，主要有名称、科目
		/// </summary>
		/// <param name="oUnitData">度量单位实体</param>
		/// <returns>true or false</returns>
		public bool Update(UnitData oUnitData)
		{
			bool isValid=true;

			DataRow aRow=oUnitData.Tables[UnitData.UNIT_TABLE].Rows[0];

			//检查字段值的合法性,所有需要加以判断的字段的入口
			isValid = InputCheck.IsValidField(aRow, UnitData.DESCRIPTION_FIELD, UnitData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			
			isValid = InputCheck.IsValidField(aRow, UnitData.ABBREVIATE_FIELD,UnitData.ABBREVIATE_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 5) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.CONUNIT_FIELD,UnitData.CONUNIT_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
            isValid = InputCheck.IsValidField(aRow, UnitData.CONVERSION_FIELD, UnitData.CONVERSION_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.EQUIVALENCE_FIELD,UnitData.EQUIVALENCE_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			
			if (!isValid)
			{
				this.Message=InputCheck.ErrorInfo;
			}

			if(isValid)
			{
				Units oUnits=new Units();

				if (oUnits.UpdateUnit(oUnitData)==false)
				{
					this.Message=oUnits.Message;
					isValid=false;
				}
			}
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
			string CanNotDelte="";
			string CanDelete;

			CanDelete=DoWithDeleteCode(Code,CanNotDelte);

			if (CanNotDelte=="") this.Message=CanNotDelte;

			return (new Units()).DeleteUnitByCode(CanDelete);
			
		}

		//对每一个Code进行判断，是否已经存在关联的物料主数据
		private string DoWithDeleteCode(string Code,string CanNotDelte)
		{
			return Code;
		}


		/// <summary>
		/// 得到度量单位
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public UnitData GetUnitByCode(int Code)
		{
			return (new Units()).GetUnitByCode(Code);
		}	//End GetUnitByCode


		/// <summary>
		/// 得到所有度量单位
		/// </summary>
		/// <returns>度量单位实体</returns>
		public UnitData GetUnits()
		{
			return (new Units()).GetUnitByCode(-1);
		}	//End GetUnits

		
		/// <summary>
		/// 判断度量单位是否已经存在
		/// </summary>
		/// <param name="Code">度量单位编号</param>
		/// <returns>存在或不存在</returns>
		public bool IsExistUnitCode(int Code)
		{
			bool ret=true;

			if(Code!=-1)
			{
				if ((new Units()).GetUnitByCode(Code).Tables[UnitData.UNIT_TABLE].Rows.Count==0)
				{
					ret=false;
				}
			}
			return ret;
		}	//End IsExistUnitCode
	
	}		//End class
}	//End namespace
