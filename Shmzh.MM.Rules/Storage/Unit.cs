using System;
using System.Data;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Common;
using MZHCommon.Input;

namespace Shmzh.MM.BusinessRules
{
	/// <summary>
	/// Unit ��ժҪ˵����
	/// </summary>
	public class Unit:Messages
	{
		/// <summary>
		/// ���������λ
		/// </summary>
		/// <param name="oUnitData">������λʵ��</param>
		/// <returns>true or false</returns>
		public bool Insert(UnitData oUnitData)
		{
			bool isValid=true;

			DataRow aRow=oUnitData.Tables[UnitData.UNIT_TABLE].Rows[0];

			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
			isValid = InputCheck.IsValidField(aRow, UnitData.CODE_FIELD, UnitData.CODE_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Int, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.DESCRIPTION_FIELD, UnitData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			
			isValid = InputCheck.IsValidField(aRow, UnitData.ABBREVIATE_FIELD,UnitData.ABBREVIATE_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 5) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.CONUNIT_FIELD,UnitData.CONUNIT_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.CONVERSION_FIELD,UnitData.CONVERSION_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, UnitData.EQUIVALENCE_FIELD,UnitData.EQUIVALENCE_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;

			if (isValid)
			{
				//�жϱ����Ƿ��Ѿ�����
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
		/// ���¶�����λ����Ҫ�����ơ���Ŀ
		/// </summary>
		/// <param name="oUnitData">������λʵ��</param>
		/// <returns>true or false</returns>
		public bool Update(UnitData oUnitData)
		{
			bool isValid=true;

			DataRow aRow=oUnitData.Tables[UnitData.UNIT_TABLE].Rows[0];

			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
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
			string CanNotDelte="";
			string CanDelete;

			CanDelete=DoWithDeleteCode(Code,CanNotDelte);

			if (CanNotDelte=="") this.Message=CanNotDelte;

			return (new Units()).DeleteUnitByCode(CanDelete);
			
		}

		//��ÿһ��Code�����жϣ��Ƿ��Ѿ����ڹ���������������
		private string DoWithDeleteCode(string Code,string CanNotDelte)
		{
			return Code;
		}


		/// <summary>
		/// �õ�������λ
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public UnitData GetUnitByCode(int Code)
		{
			return (new Units()).GetUnitByCode(Code);
		}	//End GetUnitByCode


		/// <summary>
		/// �õ����ж�����λ
		/// </summary>
		/// <returns>������λʵ��</returns>
		public UnitData GetUnits()
		{
			return (new Units()).GetUnitByCode(-1);
		}	//End GetUnits

		
		/// <summary>
		/// �ж϶�����λ�Ƿ��Ѿ�����
		/// </summary>
		/// <param name="Code">������λ���</param>
		/// <returns>���ڻ򲻴���</returns>
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
