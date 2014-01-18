using System;
using System.Data;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Common;
using MZHCommon.Input;
using MZHCommon.Database;
using System.Collections;

namespace Shmzh.MM.BusinessRules
{
	/// <summary>
	/// Category 的摘要说明。
	/// </summary>
	public class Item:Messages
	{
		private const string DEF_STR="#";
		private const int DEF_INT=-1;

		/// <summary>
		/// 插入物料主数据
		/// </summary>
		/// <param name="oItemData">物料主数据实体</param>
		/// <returns>true or false</returns>
		public bool Insert(ItemData oItemData)
		{
			bool isValid=true;

			DataRow aRow=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0];

			//检查字段值的合法性,所有需要加以判断的字段的入口
			isValid = InputCheck.IsValidField(aRow, ItemData.CODE_FIELD, ItemData.CODE_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
		    isValid =
		        InputCheck.IsValidField(aRow, ItemData.NEWCODE_FIELD, ItemData.NEWCODE_LABEL, false,
		                                InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.CNNAME_FIELD, ItemData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;

			//允许为空的输入判断
			isValid = InputCheck.IsValidField(aRow, ItemData.ENNAME_FIELD, ItemData.ENNAME_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.SPECIAL_FIELD,ItemData.SPECIAL_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 30) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.CSTPRICE_FIELD,ItemData.CSTPRICE_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.EVAPRICE_FIELD,ItemData.EVAPRICE_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.UPPNUM_FIELD,ItemData.UPPNUM_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.LOWNUM_FIELD,ItemData.LOWNUM_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.SAFNUM_FIELD,ItemData.SAFNUM_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.ORDNUM_FIELD,ItemData.ORDNUM_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.ORDBAT_FIELD,ItemData.ORDBAT_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.ENREMARK_FIELD,ItemData.ENREMARK_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.FRREMARK_FIELD,ItemData.FRREMARK_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;

			if (isValid)
			{
				//判断编码是否已经存在
				if (IsExistItemCode(aRow[ItemData.CODE_FIELD].ToString()))
				{
					this.Message=ItemData.CODE_NOT_UNIQUE;
					isValid=false;
				}
				if (this.IsExistItemWithNameAndSpec(aRow[ItemData.CODE_FIELD].ToString(),
					aRow[ItemData.CNNAME_FIELD].ToString(),
					aRow[ItemData.SPECIAL_FIELD].ToString()))
				{
					this.Message = "物料名称和规格型号不能有重复的记录！";
					isValid = false;
				}
			}
			else
			{
				this.Message=InputCheck.ErrorInfo;
			}
			//判断分类是否为空了。
			if (isValid)
			{
				if ( aRow[ItemData.CATCODE_FIELD].ToString() == "-1")
				{
					this.Message = "必须指定分类！";
					isValid = false;
				}
			}
			//判断缺省仓库是否为空。
			if (isValid)
			{
				if (aRow[ItemData.DEFSTO_FIELD].ToString() == "-1")
				{
					this.Message = "必须指定缺省仓库！";
					isValid = false;
				}
			}
			//判断计量单位是否为空。
			if (isValid)
			{
				if (aRow[ItemData.UNITCODE_FIELD].ToString() == "-1")
				{
					this.Message = "必须指定计量单位！";
					isValid = false;
				}
			}

			if(isValid)
			{
				Items oItems=new Items();

				if (oItems.InsertItem(oItemData)==false)
				{
					this.Message=oItems.Message;
					isValid=false;
				}
			}
			return isValid;
		}		//End Insert


		/// <summary>
		/// 更新物料主数据，主要有名称、科目
		/// </summary>
		/// <param name="oItemData">物料主数据实体</param>
		/// <returns>true or false</returns>
		public bool Update(ItemData oItemData)
		{
			bool isValid=true;

			DataRow aRow=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0];

			//检查字段值的合法性,所有需要加以判断的字段的入口
			isValid = InputCheck.IsValidField(aRow, ItemData.CNNAME_FIELD, ItemData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 30) && isValid;

			//允许为空的输入判断
            isValid =InputCheck.IsValidField(aRow, ItemData.NEWCODE_FIELD, ItemData.NEWCODE_LABEL, false,InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.ENNAME_FIELD, ItemData.ENNAME_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 30) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.SPECIAL_FIELD,ItemData.SPECIAL_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 30) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.CSTPRICE_FIELD,ItemData.CSTPRICE_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.EVAPRICE_FIELD,ItemData.EVAPRICE_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.UPPNUM_FIELD,ItemData.UPPNUM_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.LOWNUM_FIELD,ItemData.LOWNUM_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.SAFNUM_FIELD,ItemData.SAFNUM_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.ORDNUM_FIELD,ItemData.ORDNUM_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.ORDBAT_FIELD,ItemData.ORDBAT_LABEL, false, InputCheck.Enum_Input_Format.Format_Float, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.ENREMARK_FIELD,ItemData.ENREMARK_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.FRREMARK_FIELD,ItemData.FRREMARK_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;

			
			if (!isValid)
			{
				this.Message=InputCheck.ErrorInfo;
			}
			if (isValid)
			{
				if (this.IsExistItemWithNameAndSpec(aRow[ItemData.CODE_FIELD].ToString(),
					aRow[ItemData.CNNAME_FIELD].ToString(),
					aRow[ItemData.SPECIAL_FIELD].ToString()))
				{
					this.Message = "物料名称和规格型号不能有重复的记录！";
					isValid = false;
				}
			}
			if(isValid)
			{
				 Items oItems=new Items();

				if (oItems.UpdateItem(oItemData)==false)
				{
					this.Message=oItems.Message;
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

			return (new Items()).DeleteItemsByCodes(CanDelete);
			
		}

		//对每一个Code进行判断，是否已经存在关联的物料主数据
		private string DoWithDeleteCode(string Code,string CanNotDelte)
		{
			return Code;
		}

		/// <summary>
		/// 得到物料主数据
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public ItemData GetItemByCode(string Code)
		{
			return (new Items()).ComplexQueryItems(Code,DEF_STR,DEF_STR,DEF_INT,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,-1);
		}	//End GetItemByCode

		/// <summary>
		/// 判断物料主数据是否已经存在
		/// </summary>
		/// <param name="Code">物料主数据编号</param>
		/// <returns>存在或不存在</returns>
		public bool IsExistItemCode(string Code)
		{
			bool ret=true;

			if(Code!="-1")
			{
				if ((new Items()).ComplexQueryItems(Code,DEF_STR,DEF_STR,DEF_INT,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,1).Tables[ItemData.ITEM_TABLE].Rows.Count==0)
				{
					ret=false;
				}
			}
			return ret;
		}	//End IsExistItemCode
		/// <summary>
		/// 是否存在同名并且同规格型号的物料。
		/// </summary>
		/// <param name="ItemName">string:	物料名称。</param>
		/// <param name="ItemSpec">string:	规格型号。</param>
		/// <returns>bool:	存在重复返回true，不重复返回false。</returns>
		private bool IsExistItemWithNameAndSpec(string Code,string ItemName, string ItemSpec)
		{
			bool ret=true;
			ItemData oItemData;
			Items oItems;
			oItems = new Items();
			
			oItemData = oItems.GetItemByNameAndSpec(ItemName, ItemSpec);
			if (oItemData.Count > 0)
			{
				if (Code == oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString())
				{
					ret = false;
				}
				else
				{
					ret = true;
				}
			}
			else
			{
				ret = false;
			}
			
			return ret;
		}
		/// <summary>
		/// 根据类别选出物料
		/// </summary>
		/// <param name="Code"></param>
		/// <returns>物料主数据实体</returns>
		public ItemData GetItemsByCatCode(int Code)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,DEF_STR,Code,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}
		/// <summary>
		/// 根据编号选出物料
		/// </summary>
		/// <param name="Code"></param>
		/// <returns>物料主数据实体</returns>
		public ItemData GetItemsByCode(string Code)
		{
			return (new Items()).ComplexQueryItems(Code,DEF_STR,DEF_STR,DEF_INT,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}
        public ItemData GetItemsByNewCode(string newCode)
        {
            return (new Items()).ComplexQueryItems(DEF_STR, newCode, DEF_STR, DEF_INT, DEF_STR, DEF_STR, DEF_STR, DEF_STR, DEF_STR, DEF_STR, DEF_STR, DEF_INT);
        }
		/// <summary>
		/// 根据物料名称模糊查找物料信息。
		/// </summary>
		/// <param name="Name">string:	物料名称。</param>
		/// <returns>ItemData:	物料数据实体。</returns>
		public ItemData GetItemsByName(string Name)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,Name,DEF_INT,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}
		/// <summary>
		/// 根据物料名称的拼音首字母来进行物料的查询。
		/// </summary>
		/// <param name="PYZM">string:	拼音串。</param>
		/// <returns>ItemData:	物料主数据实体.</returns>
		public ItemData GetItemsByPY(string PY)
		{
			return new Items().GetItemByPY(PY);
		}
		/// <summary>
		/// 根据规格型号模糊查找物料信息。
		/// </summary>
		/// <param name="Spec">string:	物料名称。</param>
		/// <returns>ItemData:	物料数据实体。</returns>
		public ItemData GetItemsBySpec(string Spec)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,DEF_STR,DEF_INT,Spec,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}
		/// <summary>
		/// 对于物料编号、物料名称、规格型号进行模糊查找物料信息。
		/// </summary>
		/// <param name="QueryContent">string:	模糊查找内容。</param>
		/// <returns>ItemData:	物料数据实体。</returns>
		public ItemData GetItemsByCodeAndNameAndSpec(string QueryContent)
		{
			return (new Items()).ComplexQueryItems(QueryContent,DEF_STR,QueryContent,DEF_INT,QueryContent,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}

		/// <summary>
		/// 得到一定数量的Items
		/// </summary>
		/// <param name="Count"></param>
		/// <returns></returns>
		public ItemData GetItemsNums(int Count)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,DEF_STR,DEF_INT,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,Count);
		}
		/// <summary>
		/// 根据查询方案获得结果集
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public ItemData GetItemsBySQL(string Sql_Statement)
		{
			ItemData oItemData = new ItemData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oItemData.Tables[ItemData.ITEM_TABLE]);
			return oItemData;
		}
        /// <summary>
        /// 根据物料名称和规格类型查询方案获得结果集
        /// </summary>
        /// <param name="ItemName">物料名称</param>
        /// <param name="ItemSpec">规格类型</param>
        /// <returns></returns>
        public ItemData GetItemsByNameAndSpec(string ItemName,string ItemSpec)
        {
            ItemData oItemData = new ItemData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@ItemName",ItemName);
            oHT.Add("@ItemSpec",ItemSpec);
            oSQLServer.ExecSPReturnDS("Sto_Qry_NameAndSpec",oHT,oItemData.Tables[ItemData.ITEM_TABLE]);
            return oItemData;
        }
		/// <summary>
		/// 根据ABC得到物资列表
		/// </summary>
		/// <param name="ABC">ABC分类方法</param>
		/// <returns>物料主数据实体</returns>
		public ItemData GetItemsByABC(string ABC)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,DEF_STR,DEF_INT,DEF_STR,DEF_STR,DEF_STR,ABC,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}

	}		//End class
}	//End namespace

