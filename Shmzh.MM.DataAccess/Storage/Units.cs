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
	public class Units:Messages
	{
		/// <summary>
		/// ����������λ
		/// </summary>
		/// <param name="oUnitData">������λʵ��</param>
		/// <returns>true or false</returns>
		public bool InsertUnit(UnitData oUnitData)
		{
			Hashtable oHT=new Hashtable();

			DataRow oRow;

			oRow=oUnitData.Tables[UnitData.UNIT_TABLE].Rows[0];

			oHT.Add("@Code",oRow[UnitData.CODE_FIELD]);
			oHT.Add("@Description",oRow[UnitData.DESCRIPTION_FIELD]);
			oHT.Add("@Abbreviate",oRow[UnitData.ABBREVIATE_FIELD]);
			oHT.Add("@Equivalence",oRow[UnitData.EQUIVALENCE_FIELD]);
			oHT.Add("@Conversion",oRow[UnitData.CONVERSION_FIELD]);
			oHT.Add("@ConUnit",oRow[UnitData.CONUNIT_FIELD]);
			oHT.Add("@UnitType",oRow[UnitData.UNITTYPE_FIELD]);
			oHT.Add("@Locked",oRow[UnitData.LOCKED_FIELD]);

			return (new SQLServer()).ExecSP("Sto_UnitInsert",oHT);

		}	//End InsertUnit


		/// <summary>
		/// �༭������λ
		/// </summary>
		/// <param name="oUnitData">������λʵ��</param>
		/// <returns>true or false</returns>
		public bool UpdateUnit(UnitData oUnitData)
		{
			Hashtable oHT=new Hashtable();

			DataRow oRow;

			oRow=oUnitData.Tables[UnitData.UNIT_TABLE].Rows[0];

			oHT.Add("@Code",oRow[UnitData.CODE_FIELD]);
			oHT.Add("@Description",oRow[UnitData.DESCRIPTION_FIELD]);
			oHT.Add("@Abbreviate",oRow[UnitData.ABBREVIATE_FIELD]);
			oHT.Add("@Equivalence",oRow[UnitData.EQUIVALENCE_FIELD]);
			oHT.Add("@Conversion",oRow[UnitData.CONVERSION_FIELD]);
			oHT.Add("@ConUnit",oRow[UnitData.CONUNIT_FIELD]);
			oHT.Add("@UnitType",oRow[UnitData.UNITTYPE_FIELD]);
			oHT.Add("@Locked",oRow[UnitData.LOCKED_FIELD]);

			return (new SQLServer()).ExecSP("Sto_UnitUpdate",oHT);

		}	//End UpdateCategroy


		/// <summary>
		/// ɾ��������λ
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public bool DeleteUnitByCode(string Code)
		{
			bool ret=true;

			Hashtable oHT=new Hashtable();

			oHT.Add("@Codes",Code);
			
			if ((new SQLServer()).ExecSP("Sto_UnitDelete",oHT)==false)
			{
				this.Message="Error,Sto_UnitDelete,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// �õ�������λ��Ϣ
		/// </summary>
		/// <param name="Code">IF Code=-1,�õ����еĶ�����λ</param>
		/// <returns>���ݼ�</returns>
		public UnitData GetUnitByCode(int Code)
		{
			UnitData oUnitData=new UnitData();

			Hashtable oHT=new Hashtable();

			oHT.Add("@Code",Code);
			
			if ((new SQLServer()).ExecSPReturnDS("Sto_UnitQueryByCode",oHT,oUnitData.Tables[UnitData.UNIT_TABLE])==false)
			{
				this.Message="Error,Sto_UnitQueryByCode,Please look the log file!";
			}
			return oUnitData;
		}		// End GetUnitByCode

	}
}

