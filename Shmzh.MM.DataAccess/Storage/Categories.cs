using System;
using MZHCommon.Database;
using Shmzh.MM.Common;
using System.Data;
using System.Collections;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// Categories 的摘要说明。
	/// </summary>
	public class Categories:Messages
	{
		public Categories()
		{
		}

		/// <summary>
		/// 新增物资目录
		/// </summary>
		/// <param name="oCategoryData">物资目录实体</param>
		/// <returns>true or false</returns>
		public bool InsertCategory(CategoryData oCategoryData)
		{
			Hashtable oHT=new Hashtable();

			DataRow oRow;

			oRow=oCategoryData.Tables[CategoryData.CATEGORIES_TABLE].Rows[0];

			oHT.Add("@Code",oRow[CategoryData.CODE_FIELD]);
			oHT.Add("@Description",oRow[CategoryData.DESCRIPTION_FIELD]);
			oHT.Add("@Locked",oRow[CategoryData.LOCKED_FIELD]);
			oHT.Add("@StorageAcc",oRow[CategoryData.STORAGEACC_FIELD]);
			oHT.Add("@TransferAcc",oRow[CategoryData.TRANSFERACC_FIELD]);
			oHT.Add("@ReturnAcc",oRow[CategoryData.RETURNACC_FIELD]);
			oHT.Add("@Remark",oRow[CategoryData.REMARK_FIELD]);
			oHT.Add("@Serial",oRow[CategoryData.SERIAL_FIELD]);

			return (new SQLServer()).ExecSP("Sto_CategoryInsert",oHT);

		}	//End InsertCategory


		/// <summary>
		/// 编辑物资目录
		/// </summary>
		/// <param name="oCategoryData">物资目录实体</param>
		/// <returns>true or false</returns>
		public bool UpdateCategroy(CategoryData oCategoryData)
		{
			Hashtable oHT=new Hashtable();

			DataRow oRow;

			oRow=oCategoryData.Tables[CategoryData.CATEGORIES_TABLE].Rows[0];

			oHT.Add("@Code",oRow[CategoryData.CODE_FIELD]);
			
			oHT.Add("@Description",oRow[CategoryData.DESCRIPTION_FIELD]);
			oHT.Add("@Locked",oRow[CategoryData.LOCKED_FIELD]);
			oHT.Add("@StorageAcc",oRow[CategoryData.STORAGEACC_FIELD]);
			oHT.Add("@TransferAcc",oRow[CategoryData.TRANSFERACC_FIELD]);
			oHT.Add("@ReturnAcc",oRow[CategoryData.RETURNACC_FIELD]);
			oHT.Add("@Remark",oRow[CategoryData.REMARK_FIELD]);
			oHT.Add("@Serial",oRow[CategoryData.SERIAL_FIELD]);

			return (new SQLServer()).ExecSP("Sto_CategoryUpdate",oHT);

		}	//End UpdateCategroy


	    /// <summary>
		/// 得到物资目录信息
		/// </summary>
		/// <param name="Code">IF Code=-1,得到所有的物资目录</param>
		/// <returns>数据集</returns>
		public CategoryData GetCategoryByCode(int Code)
		{
			CategoryData oCategoryData=new CategoryData();

			Hashtable oHT=new Hashtable();

			oHT.Add("@Code",Code);
			
			if ((new SQLServer()).ExecSPReturnDS("Sto_CategoryQueryByCode",oHT,oCategoryData.Tables[CategoryData.CATEGORIES_TABLE])==false)
			{
				this.Message="Error,Sto_GetCategoryByCode,Please look the log file!";
			}
			return oCategoryData;
		}		// End GetCategoryByCode


        public CategoryData GetAllCategory()
        {
            CategoryData oCategoryData = new CategoryData();

            Hashtable oHT = new Hashtable();

            oHT.Add("@Code", -2);

            if ((new SQLServer()).ExecSPReturnDS("Sto_CategoryQueryByCode", oHT, oCategoryData.Tables[CategoryData.CATEGORIES_TABLE]) == false)
            {
                this.Message = "Error,Sto_GetCategoryByCode,Please look the log file!";
            }
            return oCategoryData;
        }

        public CategoryData GetQueryCategory()
        {
            CategoryData oCategoryData = new CategoryData();

            if ((new SQLServer()).ExecSPReturnDS("Sto_CategoryQuery",oCategoryData.Tables[CategoryData.CATEGORIES_TABLE]) == false)
            {
                this.Message = "Error,Sto_CategoryQuery,Please look the log file!";
            }
            return oCategoryData;
        }	


		
		/// <summary>
		/// 删除分类
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public bool DeleteCategoryByCode(string Code)
		{
			bool ret=true;

			Hashtable oHT=new Hashtable();

			oHT.Add("@Codes",Code);
			
			if ((new SQLServer()).ExecSP("Sto_CategroyDelete",oHT)==false)
			{
				this.Message="Error,Sto_CategroyDelete,Please look the log file!";
				ret=false;
			}
			return ret;
		}
	}
}
