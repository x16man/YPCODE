using System;
using Shmzh.MM.Common;
using Shmzh.MM.DataAccess;
using Shmzh.MM.BusinessRules;
namespace Shmzh.MM.Facade
{
	/// <summary>
	///		ItemSystem 的摘要说明。
	///     <remarks>
	///         提供操作物料主文件的唯一的接口
	///     </remarks>
	///     <remarks>
	///         提供远程调用
	///     </remarks>
	/// </summary>
	public class ItemSystem: MarshalByRefObject,IWDRWSystem,IWRTSSystem,IStockSystem,IWADJSystem,IMAIOSystem,IWTOWSystem,IWINWSystem, IWITRSystem, IProjectSystem, IRealDrawItem
	{
		private string _Message;

		public string Message
		{
			get{return _Message;}
		}

		#region "物资目录部分"

		/// <summary>
		/// 		/// 增加一个目录
		/// </summary>
		/// <param name="oCategoryData">目录实体</param>
		/// <returns>true or false</returns>
		public bool AddCategory(CategoryData oCategoryData)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oCategoryData!=null)
			{
				Category oCategory=new Category();

				if(oCategory.Insert(oCategoryData)==false)
				{
					_Message=oCategory.Message;
					ret=false;
				}
			}

			return ret;

		}	//End AddCategory


		/// <summary>
		/// 编辑一个目录
		/// 		/// </summary>
		/// <param name="oCategoryData">目录实体</param>
		/// <returns>true or false</returns>
		public bool EditCategory(CategoryData oCategoryData)
		{
			bool ret=true;

			if (oCategoryData!=null)
			{
				Category oCategory=new Category();

				if(oCategory.Update(oCategoryData)==false)
				{
					_Message=oCategory.Message;
					ret=false;
				}
			}

			return ret;
		}	//End EditCategory

		/// <summary>
		/// 删除的分类
		/// </summary>
		/// <param name="Code">删除的分类列表</param>
		/// <returns>true or false</returns>
		public bool DeleteCategory(string Code)
		{
			bool ret=true;
			Category oCategory=new Category();

			if(oCategory.Delete(Code)==false)
			{
				_Message=oCategory.Message;
				ret=false;
			}
			else
			{
				_Message=oCategory.Message;
			}
			return ret;
		}	//End DeleteCategory

		/// <summary>
		///  根据目录编号查询
		/// </summary>
		/// <param name="Code">目录编号</param>
		/// <returns>目录实体</returns>
		public CategoryData QueryCategoryByCode(int Code)
		{
			return (new Category()).GetCategoryByCode(Code);
		}

		/// <summary>
		/// 得到所有的目录
		/// </summary>
		/// <returns>目录实体</returns>
		public CategoryData QueryAllCategories()
		{
			return (new Category()).GetCategories();
		}		// End GetAllCategories
		/// <summary>
		/// 获取除未分类以外的目录列表。
		/// </summary>
		/// <returns>目录实体</returns>
		public CategoryData QueryAvailableCategories()
		{
			return (new Category()).GetAvailableCategories();
		}		// End GetAllCategories
		

		#endregion

		#region "度量单位部分"
		/// <summary>
		/// 增加一个度量单位
		/// </summary>
		/// <param name="oUnitData">度量单位实体</param>
		/// <returns>true or false</returns>
		public bool AddUnit(UnitData oUnitData)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oUnitData!=null)
			{
				Unit oUnit=new Unit();

				if(oUnit.Insert(oUnitData)==false)
				{
					_Message=oUnit.Message;
					ret=false;
				}
			}

			return ret;

		}	//End AddUnit


		/// <summary>
		/// 编辑一个度量单位
		/// </summary>
		/// <param name="oUnitData">度量单位实体</param>
		/// <returns>true or false</returns>
		public bool EditUnit(UnitData oUnitData)
		{
			bool ret=true;

			if (oUnitData!=null)
			{
				Unit oUnit=new Unit();

				if(oUnit.Update(oUnitData)==false)
				{
					_Message=oUnit.Message;
					ret=false;
				}
			}

			return ret;
		}	//End EditUnit

		/// <summary>
		/// 删除的度量单位
		/// </summary>
		/// <param name="Code">删除的分类列表</param>
		/// <returns>true or false</returns>
		public bool DeleteUnit(string Code)
		{
			bool ret=true;
			Unit oUnit=new Unit();

			if(oUnit.Delete(Code)==false)
			{
				_Message=oUnit.Message;
				ret=false;
			}
			else
			{
				_Message=oUnit.Message;
			}
			return ret;
		}	//End DeleteUnit

		/// <summary>
		///  根据度量单位编号查询
		/// </summary>
		/// <param name="Code">度量单位编号</param>
		/// <returns>度量单位</returns>
		public UnitData QueryUnitByCode(int Code)
		{
			return (new Unit()).GetUnitByCode(Code);
		}

		/// <summary>
		/// 得到所有的目录
		/// </summary>
		/// <returns>目录实体</returns>
		public UnitData QueryAllUnits()
		{
			return (new Unit()).GetUnits();
		}		// End QueryAllUnits
		#endregion

		#region "仓库部分"
		/// <summary>
		/// 获取所有仓库信息。
		/// </summary>
		/// <returns>StoData:	仓库数据实体。</returns>
		public StoData GetStoAll()
		{
			Stos myStos = new Stos();
			return myStos.GetStoAll();
		}
		/// <summary>
		/// 根据仓库编号获取仓库信息。
		/// </summary>
		/// <param name="Code">string:	仓库编号。</param>
		/// <returns>StoData:	仓库数据实体。</returns>
		public StoData GetStoByCode(string Code)
		{
			Stos myStos = new Stos();
			return myStos.GetStoByCode(Code);
		}
		/// <summary>
		/// 根据仓库名称返回仓库信息。
		/// </summary>
		/// <param name="Description">string:	仓库名称。</param>
		/// <returns>StoData:	仓库数据实体。</returns>
		public StoData GetStoByDescription(string Description)
		{
			Stos myStos = new Stos();
			return myStos.GetStoByDescription(Description);
		}
		/// <summary>
		/// 仓库增加。
		/// </summary>
		/// <param name="myStoData">StoData:	仓库数据实体。</param>
		/// <returns>bool:	仓库增加成功返回true，失败返回false。</returns>
		public bool AddSto(StoData myStoData)
		{
			bool ret = true;
			if (myStoData != null)
			{
				Sto mySto = new Sto();
				ret = mySto.Add(myStoData);
				this._Message = mySto.Message;
			}
			else
			{
				this._Message = StoData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 仓库修改。
		/// </summary>
		/// <param name="myStoData">StoData:	仓库数据实体。</param>
		/// <returns>bool:	仓库修改成功返回true，失败返回false。</returns>
		public bool UpdateSto(StoData myStoData,string strOldName)
		{
			bool ret = true;
			if (myStoData != null)
			{
				Sto mySto = new Sto();
                ret = mySto.Update(myStoData, strOldName);
				this._Message = mySto.Message;
			}
			else
			{
				this._Message = StoData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 仓库删除。
		/// </summary>
		/// <param name="myStoData">StoData:	仓库数据实体。</param>
		/// <returns>bool:	仓库删除成功返回true，失败返回false。</returns>
		public bool DeleteSto(StoData myStoData)
		{
			bool ret = true;
			if (myStoData != null)
			{
				Sto mySto = new Sto();
				ret = mySto.Delete(myStoData);
				this._Message = mySto.Message;
			}
			else
			{
				this._Message = StoData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据传入的仓库代码串进行删除。
		/// </summary>
		/// <param name="Codes">string:	仓库代码串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteSto (string Codes)
		{
			bool ret = true;
			if (Codes == null || Codes == "")
			{
				this._Message = StoData.NO_OBJECT;
				ret = false;
			}
			else
			{
				Sto mySto = new Sto();
				ret = mySto.Delete(Codes);
				this._Message = mySto.Message;
			}
			return ret;
		}
		#endregion

		#region "架位部分"
		/// <summary>
		/// 根据架位编号返回架位信息。
		/// </summary>
		/// <param name="Code">int:	架位编号。</param>
		/// <returns>StoConData:	架位数据实体。</returns>
		public StoConData GetStoConByCode(int Code)
		{
			StoCons myStoCons = new StoCons();
			return myStoCons.GetStoConByCode(Code);
		}
		/// <summary>
		/// 根据仓库编号返回架位信息。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <returns>StoConData:	架位数据实体。</returns>
		public StoConData GetStoConByStoCode(string StoCode)
		{
			StoCons myStoCons = new StoCons();
			return myStoCons.GetStoConByStoCode(StoCode);
		}
		/// <summary>
		/// 根据仓库编号和架位名称返回架位信息。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="Description">string:	架位名称。</param>
		/// <returns>StoConData:	架位数据实体。</returns>
		public StoConData GetStoConByStoCodeAndDescription(string StoCode, string Description)
		{
			StoCons myStoCons = new StoCons();
			return myStoCons.GetStoConByStoCodeAndDescription(StoCode,Description);
		}
		/// <summary>
		/// 架位增加。
		/// </summary>
		/// <param name="myStoConData">StoConData:	架位数据实体。</param>
		/// <returns>bool:	架位增加成功返回true，失败返回false。</returns>
		public bool AddStoCon(StoConData myStoConData)
		{
			bool ret = true;
			if (myStoConData != null)
			{
				StoCon myStoCon = new StoCon();
				ret = myStoCon.Add(myStoConData);
				this._Message = myStoCon.Message;
			}
			else
			{
				this._Message = StoConData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 架位修改。
		/// </summary>
		/// <param name="myStoConData">StoConData:	架位数据实体。</param>
		/// <returns>bool:	架位修改成功返回true，失败返回false。</returns>
		public bool UpdateStoCon(StoConData myStoConData)
		{
			bool ret = true;
			if (myStoConData != null)
			{
				StoCon myStoCon = new StoCon();
				ret = myStoCon.Update(myStoConData);
				this._Message = myStoCon.Message;
			}
			else
			{
				this._Message = StoConData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 架位删除。
		/// </summary>
		/// <param name="myStoConData">StoConData:	架位数据实体。</param>
		/// <returns>bool:	架位删除成功返回true，失败返回false。</returns>
		public bool DeleteStoCon(StoConData myStoConData)
		{
			bool ret = true;
			if (myStoConData != null)
			{
				StoCon myStoCon = new StoCon();
				ret = myStoCon.Delete(myStoConData);
				this._Message = myStoCon.Message;
			}
			else
			{
				this._Message = StoConData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		
		/// <summary>
		/// 根据传入的架位编号进行架位删除。
		/// </summary>
		/// <param name="Codes">string:	架位编号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteStoCon(string Codes)
		{
			bool ret = true;
			if (Codes != null || Codes !="")
			{
				StoCon myStoCon = new StoCon();
				ret = myStoCon.Delete(Codes);
				this._Message = myStoCon.Message;
			}
			else
			{
				this._Message = StoConData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		#endregion

		#region "检验报告部分"

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public CheckReportData QueryAllCheckReports()
		{
			return (new CheckReport ()).GetCheckReportByCode(-1);
		}		// End QueryAllCheckReports

		#endregion

		#region "物料主文件"
		/// <summary>
		/// 增加物料主文件记录
		/// </summary>
		/// <param name="oItemData">物料主文件实体</param>
		/// <returns>true or false</returns>
		public bool AddItem(ItemData oItemData)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oItemData!=null)
			{
				Item oItem=new Item();

				if(oItem.Insert(oItemData)==false)
				{
					_Message=oItem.Message;
					ret=false;
				}
			}

			return ret;
		}	//End AddItem

		/// <summary>
		/// 更新物料主文件记录
		/// </summary>
		/// <param name="oItemData">物料主文件实体</param>
		/// <returns>true or false</returns>
		public bool EditItem(ItemData oItemData)
		{
			bool ret=true;
			//
			// Check preconditions
			//
			if (oItemData!=null)
			{
				Item oItem=new Item();

				if(oItem.Update(oItemData)==false)
				{
					_Message=oItem.Message;
					ret=false;
				}
			}

			return ret;
		}		//End EditItem

		/// <summary>
		/// 删除的物料主文件
		/// </summary>
		/// <param name="Code">删除的物料主文件列表</param>
		/// <returns>true or false</returns>
		public bool DeleteItem(string Code)
		{
			bool ret=true;
			Item oItem=new Item();

			if(oItem.Delete(Code)==false)
			{
				_Message=oItem.Message;
				ret=false;
			}
			else
			{
				_Message=oItem.Message;
			}
			return ret;
		}	//End DeleteItem
		
		/// <summary>
		/// 根据类别选出物料
		/// </summary>
		/// <param name="Code">int:	分类编号。</param>
		/// <returns>物料主数据实体</returns>
		public ItemData GetItemsByCatCode(int Code)
		{
			return (new Item()).GetItemsByCatCode(Code);
		}

		/// <summary>
		/// 根据ABC得到物资列表
		/// </summary>
		/// <param name="ABC">ABC分类方法</param>
		/// <returns>物料主数据实体</returns>
		public ItemData GetItemsByABC(string ABC)
		{
			return (new Item()).GetItemsByABC(ABC);
		}

		/// <summary>
		/// 获取指定数量记录数的物料主文件。
		/// </summary>
		/// <param name="Count">int:	数量。</param>
		/// <returns>ItemData:	物料主数据实体。</returns>
		public ItemData GetItemsNums(int Count)
		{
			return (new Item()).GetItemsNums(Count);
		}
		/// <summary>
		/// 根据SQL语句获取物料清单。
		/// </summary>
		/// <param name="strSQL">string:	SQL语句。</param>
		/// <returns>ItemData:	物料主数据实体。</returns>
		public ItemData GetItemsBySQL(string strSQL)
		{
			return (new Item()).GetItemsBySQL(strSQL);
		}
        /// <summary>
        /// 根据根据物料名称和规格类型获取物料清单。
        /// </summary>
        /// <param name="strSQL">string:	SQL语句。</param>
        /// <returns>ItemData:	物料主数据实体。</returns>
        public ItemData GetItemsByNameAndSpec(string ItemName,string ItemSpec)
        {
            return (new Item()).GetItemsByNameAndSpec(ItemName,ItemSpec);
        }
		/// <summary>
		/// 根据物料编号获取物料。
		/// </summary>
		/// <param name="Code">string:	物料编号。</param>
		/// <returns>ItemData:	物料主数据实体。</returns>
		public ItemData GetItemByCode(string Code)
		{
			return new Item().GetItemByCode(Code);
		}
        /// <summary>
        /// 根据新物料编号获取物料。
        /// </summary>
        /// <param name="newCode"></param>
        /// <returns></returns>
        public ItemData GetItemsByNewCode(string newCode)
        {
            return new Item().GetItemsByNewCode(newCode);
        }
		/// <summary>
		/// 根据物料编号模糊查找物料信息。
		/// </summary>
		/// <param name="Code">string:	物料编号。</param>
		/// <returns>ItemData:	物料主数据实体。</returns>
		public ItemData GetItemsByCode(string Code)
		{
			return (new Item()).GetItemsByCode(Code);
		}
		/// <summary>
		/// 根据物料名称模糊查找物料信息 。
		/// </summary>
		/// <param name="Name">string:	物料名称。</param>
		/// <returns>ItemData:	物料主数据实体。</returns>
		public ItemData GetItemsByName(string Name)
		{
			return (new Item()).GetItemsByName(Name);
		}
		/// <summary>
		/// 根据物料名称的拼音首字母来进行物料的查询。
		/// </summary>
		/// <param name="PYZM">string:	拼音串。</param>
		/// <returns>ItemData:	物料主数据实体.</returns>
		public ItemData GetItemsByPY(string PY)
		{
			return (new Item()).GetItemsByPY(PY);
		}
		/// <summary>
		/// 根据规格型号模糊查找物料信息。
		/// </summary>
		/// <param name="Spec">string:	规格型号。</param>
		/// <returns>ItemData:	物料主数据实体。</returns>
		public ItemData GetItemsBySpec (string Spec)
		{
			return (new Item()).GetItemsBySpec(Spec);
		}
		/// <summary>
		/// 根据物料编号、物料名称、规格型号模糊查找物料信息。
		/// </summary>
		/// <param name="QueryContent">string:	模糊查询内容。</param>
		/// <returns>ItemData:	物料主数据实体。</returns>
		public ItemData GetItemsByCodeAndNameAndSpec(string QueryContent)
		{
			return new Item().GetItemsByCodeAndNameAndSpec(QueryContent);
		}
		/// <summary>
		/// 获取一个空的物料主数据实体.
		/// </summary>
		/// <returns>ItemData:	物料主数据实体。</returns>
		public ItemData GetItemNone()
		{
			//return (new Item()).GetItemsByCode("约定飘逝在落叶的季节 ");
			return new ItemData();
		}
		/// <summary>
		/// 根据使用频率获得物料清单。
		/// </summary>
		/// <returns>ItemData:	物料主数据实体。</returns>
		public ItemData GetItemByUseCount()
		{
			return new Items().GetItemByUseCount();
		}
		/// <summary>
		/// 获取物料的推荐编号。
		/// </summary>
		/// <param name="PrefixStr">string:	物料编号前缀。</param>
		/// <returns>string:	推荐编号。</returns>
		public string GetItemRecommandCode(string PrefixStr)
		{
			ItemData oItemData;
			string RecommandCode;
			oItemData = new Items().GetItemRecommandCode(PrefixStr);
			RecommandCode = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
			return RecommandCode;
		}
		/// <summary>
		/// 根据物料名称和规格型号获取物料信息。
		/// </summary>
		/// <param name="ItemName">string:	物料名称。</param>
		/// <param name="ItemSpec">string:	规格型号。</param>
		/// <returns>ItemData:	物料主数据实体.</returns>
		public ItemData GetItemByNameAndSpec(string ItemName, string ItemSpec)
		{
			return new Items().GetItemByNameAndSpec(ItemName, ItemSpec);
		}
		#endregion
		
		#region "用途部分"
		/// <summary>
		/// 获取所有用途。
		/// </summary>
		/// <returns>PurposeData:	用途数据实体。</returns>
		public PurposeData GetPurposeAll()
		{
			Purposes oPurposes = new Purposes();
			return oPurposes.GetPurposeAll();
		}
		/// <summary>
		/// 获取所有有效的用途。
		/// </summary>
		/// <returns>PurposeData:	用途数据实体。</returns>
		public PurposeData GetPurposeAvalible()
		{
			Purposes oPurposes = new Purposes();
			return oPurposes.GetPurposeAvalible();
		}
		/// <summary>
		/// 根据用途代码获取用途信息.
		/// </summary>
		/// <param name="Code">string:	用途代码。</param>
		/// <returns>PurposeData:	用途数据实体。</returns>
		public PurposeData GetPurposeByCode(string Code)
		{
			Purposes oPurposes = new Purposes();
			return oPurposes.GetPurposeByCode(Code);
		}
		/// <summary>
		/// 用途增加。
		/// </summary>
		/// <param name="oPurposeData">PurposeData:	用途数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddPurpose(PurposeData oPurposeData)
		{
			bool ret = true;
			if (oPurposeData != null)
			{
				Purpose oPurpose = new Purpose();
				ret = oPurpose.Add(oPurposeData);
				this._Message = oPurpose.Message;
			}
			else
			{
				this._Message = PurposeData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 用途修改。
		/// </summary>
		/// <param name="oPurposeData">PurposeData:	用户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdatePurpose(PurposeData oPurposeData)
		{
			bool ret = true;
			if (oPurposeData != null)
			{
				Purpose oPurpose = new Purpose();
				ret = oPurpose.Update(oPurposeData);
				this._Message = oPurpose.Message;
			}
			else
			{
				this._Message = PurposeData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 用途单条记录删除。
		/// </summary>
		/// <param name="oPurposeData">PurposeData:	用途数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePurpose(PurposeData oPurposeData)
		{
			bool ret = true;
			if (oPurposeData != null)
			{
				Purpose oPurpose = new Purpose();
				ret = oPurpose.Delete(oPurposeData);
				this._Message = oPurpose.Message;
			}
			else
			{
				this._Message = PurposeData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 用途多条记录删除。
		/// </summary>
		/// <param name="Codes">string:	用户代码字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeletePurpose(string Codes)
		{
			bool ret = true;
			if (Codes != null && Codes != "")
			{
				Purpose oPurpose = new Purpose();
				ret = oPurpose.Delete(Codes);
				this._Message = oPurpose.Message;
			}
			else
			{
				this._Message = PurposeData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据用途分类获得“使用理由及用途”
		/// </summary>
		/// <param name="strClassifyID">用途分类号</param>
		/// <returns></returns>
		public PurposeData GetPurposeByClassify(string strClassifyID)
		{
			Purposes oPurposes = new Purposes();
			return oPurposes.GetPurposeByClassify(strClassifyID);
		}
		public PurposeData GetPurposeByClassifyWithFlag(string strClassifyID,int Flag)
		{
			return new Purposes().GetPurposeByClassifyWithFlag(strClassifyID, Flag);
		}
		public PurposeData GetAvailablePurposeByPYWithFlag(string Classify,string PYZM, int Flag)
		{
			return new Purposes().GetAvailablePurposeByPYWithFlag(Classify,PYZM, Flag);
		}
		public PurposeData GetAvailablePurposeByPY(string Classify,string PYZM)
		{
			return new Purposes().GetAvailablePurposeByPY(Classify,PYZM);
		}
#endregion

		#region "用途分类部分"
		/// <summary>
		/// 获取所有用途分类。
		/// </summary>
		/// <returns>ClassifyData:	用途分类数据实体。</returns>
		public ClassifyData GetClassifyAll()
		{
			var oClassifys = new Classifys();
			return oClassifys.GetClassifyAll();
		}
		/// <summary>
		/// 获取所有有效的用途分类。
		/// </summary>
		/// <returns</returns>
		public ClassifyData GetClassifyAvalible()
		{
			var oClassifys = new Classifys();
			return oClassifys.GetClassifyAvalible();
		}
        public ClassifyData GetClassifyAvalibleWithNull()
        {
            var oClassifys = new Classifys();
            return oClassifys.GetClassifyAvalibleWithNull();
        }
		/// <summary>
		/// 获取正在使用的用途分类。
		/// </summary>
		/// <returns>>ClassifyData:	用途分类数据实体。</returns>
		public ClassifyData GetClassifyInUsing()
		{
			return new Classifys().GetClassifyInUsing();
		}
		/// <summary>
		/// 根据用途分类代码获取用途信息.
		/// </summary>
		/// <param name="Code">string:	用途分类代码。</param>
		/// <returns>ClassifyData:	用途分类数据实体。</returns>
		public ClassifyData GetClassifyByCode(string Code)
		{
			Classifys oClassifys = new Classifys();
			return oClassifys.GetClassifyByCode(Code);
		}
		/// <summary>
		/// 用途分类增加。
		/// </summary>
		/// <param name="oClassifyData">ClassifyData:	用途分类数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddClassify(ClassifyData oClassifyData)
		{
			bool ret = true;
			if (oClassifyData != null)
			{
				Classify oClassify = new Classify();
				ret = oClassify.Add(oClassifyData);
				this._Message = oClassify.Message;
			}
			else
			{
				this._Message = ClassifyData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 用途分类修改。
		/// </summary>
		/// <param name="oClassifyData">ClassifyData:	用户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateClassify(ClassifyData oClassifyData)
		{
			bool ret = true;
			if (oClassifyData != null)
			{
				Classify oClassify = new Classify();
				ret = oClassify.Update(oClassifyData);
				this._Message = oClassify.Message;
			}
			else
			{
				this._Message = ClassifyData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 用途分类单条记录删除。
		/// </summary>
		/// <param name="oClassifyData">ClassifyData:	用途分类数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteClassify(ClassifyData oClassifyData)
		{
			bool ret = true;
			if (oClassifyData != null)
			{
				Classify oClassify = new Classify();
				ret = oClassify.Delete(oClassifyData);
				this._Message = oClassify.Message;
			}
			else
			{
				this._Message = ClassifyData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 用途分类多条记录删除。
		/// </summary>
		/// <param name="Codes">string:	用户代码字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteClassify(string Codes)
		{
			bool ret = true;
			if (Codes != null && Codes != "")
			{
				Classify oClassify = new Classify();
				ret = oClassify.Delete(Codes);
				this._Message = oClassify.Message;
			}
			else
			{
				this._Message = ClassifyData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		#endregion

        #region "仓库管理员部分"
		/// <summary>
		/// 根据仓库管理员主键获取仓库管理员信息。
		/// </summary>
		/// <param name="PKID">int:	仓库管理员主键ID。</param>
		/// <returns>StoManagerData:	仓库管理员数据实体。</returns>
		public StoManagerData GetStoManagerByPKID(int PKID)
		{
			StoManagers oStoManagers = new StoManagers();
			return oStoManagers.GetStoManagerByPKID(PKID);
		}
		/// <summary>
		/// 根据管理员编号获取管理员管理的仓库信息。
		/// </summary>
		/// <param name="Usercode">string:	管理员编号。</param>
		/// <returns>StoManagerData:	仓库管理员数据实体。</returns>
		public StoManagerData GetStoManagerByUserCode(string UserCode)
		{
			StoManagers oStoManagers = new StoManagers();
			return oStoManagers.GetStoManagerByUserCode(UserCode);
		}

		/// <summary>
		/// 获取指定仓库的管理员。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <returns>StoManagerData:	仓库管理员数据实体。</returns>
		public StoManagerData GetStoManagerByStoCode(string StoCode)
		{
			StoManagers oStoManagers = new StoManagers();
			return oStoManagers.GetStoManagerByStoCode(StoCode);
		}
		/// <summary>
		/// 增加仓库管理员。
		/// </summary>
		/// <param name="oStoManagerData">StoManagerData:	仓库管理员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddStoManager(StoManagerData oStoManagerData)
		{
			bool ret = true;
			if (oStoManagerData != null)
			{
				StoManager oStoManager = new StoManager();
				ret = oStoManager.Add(oStoManagerData);
				this._Message = oStoManager.Message;
			}
			else
			{
				this._Message = StoManagerData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 更新仓库管理员 。
		/// </summary>
		/// <param name="oStoManagerData">StoManagerData:	仓库管理员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateStoManager(StoManagerData oStoManagerData)
		{
			bool ret = true;
			if (oStoManagerData != null)
			{
				StoManager oStoManager = new StoManager();
				ret = oStoManager.Update(oStoManagerData);
				this._Message = oStoManager.Message;
			}
			else
			{
				this._Message = StoManagerData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 删除仓库管理员。
		/// </summary>
		/// <param name="oStoManagerData">StoManagerData:	仓库管理员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteStoManager(StoManagerData oStoManagerData)
		{
			bool ret = true;
			if (oStoManagerData != null)
			{
				StoManager oStoManager = new StoManager();
				ret = oStoManager.Delete(oStoManagerData);
				this._Message = oStoManager.Message;
			}
			else
			{
				this._Message = StoManagerData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据传入的仓库管理员主键串进行删除。
		/// </summary>
		/// <param name="PKIDs">string:	管理员主键串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteStoManager(string PKIDs)
		{
			bool ret = true;
			if (PKIDs != null && PKIDs != "")
			{
				StoManager oStoManager = new StoManager();
				ret = oStoManager.Delete(PKIDs);
				this._Message = oStoManager.Message;
			}
			else
			{
				this._Message = StoManagerData.NO_OBJECT;
				ret = false;
			}
			return ret;
		}
#endregion

		#region IWDRWSystem成员 领料单部分
		/// <summary>
		/// 检验领料单操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="Operation">string:	操作代码。</param>
		/// <returns>bool:	符合前提条件返回true,不符合返回false.</returns>
		public bool CheckPreconditionOfWDRW(int EntryNo,string Operation)
		{
			WDRW oWDRW = new WDRW();
			return oWDRW.CheckPreCondition(EntryNo, Operation);
		}
		/// <summary>
		/// 检验领料单操作的前提条件.
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="Operation">string:	操作代码。</param>
		/// <param name="UserLoginID">string:	操作人.</param>
		/// <returns>bool:	符合前提条件返回true,不符合返回false.</returns>
		public bool CheckPreconditionOfWDRW(int EntryNo, string Operation, string UserLoginID)
		{
			WDRW oWDRW = new WDRW();
			return oWDRW.CheckPreCondition(EntryNo, Operation, UserLoginID);
		}
		/// <summary>
		/// 领料单的增加。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddWDRW(WDRWData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WDRW oWDRW = new WDRW();
				ret = oWDRW.Insert(oEntry);
				this._Message=oWDRW.Message;
			}
			else
			{
				this._Message = WDRWData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentWDRW(WDRWData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WDRW oWDRW = new WDRW();
				ret = oWDRW.InsertAndPresent(oEntry);
				this._Message=oWDRW.Message;
			}
			else
			{
				this._Message = WDRWData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的修改。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateWDRW(WDRWData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WDRW oWDRW = new WDRW();
				ret = oWDRW.Update(oEntry);
				this._Message=oWDRW.Message;
			}
			else
			{
				this._Message = WDRWData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的修改并且提交。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentWDRW(WDRWData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WDRW oWDRW = new WDRW();
				ret = oWDRW.UpdateAndPresent(oEntry);
				this._Message=oWDRW.Message;
			}
			else
			{
				this._Message = WDRWData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteWDRW(int EntryNo)
		{
			bool ret = true;
			
			WDRW oWDRW = new WDRW();
			ret = oWDRW.Delete(EntryNo);
			this._Message=oWDRW.Message;
			
			return ret;
		}
		/// <summary>
		/// 领料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:	用户。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteWDRW(int EntryNo,string UserLoginId)
		{
			bool ret = true;

			WDRW oWDRW = new WDRW();
			ret = oWDRW.Delete(EntryNo,UserLoginId);
			this._Message = oWDRW.Message;

			return ret;
		}
		/// <summary>
		/// 领料单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentWDRW(int EntryNo,string UserLoginId)
		{
			bool ret = true;
						
			WDRW oWDRW = new WDRW();
			ret = oWDRW.Present(EntryNo,DocStatus.Present, UserLoginId);
			this._Message=oWDRW.Message;
			
			return ret;
		}
		/// <summary>
		/// 领料单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelWDRW(int EntryNo)
		{
			bool ret = true;
						
			WDRW oWDRW = new WDRW();
			ret = oWDRW.Cancel(EntryNo,DocStatus.Cancel);
			this._Message=oWDRW.Message;
			
			return ret;
		}
		/// <summary>
		/// 领料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelWDRW(int EntryNo,string UserLoginId)
		{
			bool ret = true;
						
			WDRW oWDRW = new WDRW();
			ret = oWDRW.Cancel(EntryNo,DocStatus.Cancel,UserLoginId);
			this._Message=oWDRW.Message;
			
			return ret;
		}
		/// <summary>
		/// 领料单拒发。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool RefuseWDRW(int EntryNo, string UserLoginId)
		{
			bool ret = true;

			WDRW oWDRW = new WDRW();
			ret = oWDRW.Refuse(EntryNo, UserLoginId);
			this._Message = oWDRW.Message;

			return ret;
		}

		public bool WDRW2PROS(int EntryNo)
		{
			bool ret = true;

			WDRW oWDRW = new WDRW();
			ret = oWDRW.DRW2PROS(EntryNo);
			this._Message = oWDRW.Message;

			return ret;
		}
		/// <summary>
		/// 领料单的部门审批。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditWDRW(WDRWData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WDRW oWDRW = new WDRW();
				ret = oWDRW.FirstAudit(oEntry);
				this._Message=oWDRW.Message;
			}
			else
			{
				this._Message = WDRWData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的财务审批。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditWDRW(WDRWData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WDRW oWDRW = new WDRW();
				ret = oWDRW.SecondAudit(oEntry);
				this._Message=oWDRW.Message;
			}
			else
			{
				this._Message = WDRWData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditWDRW(WDRWData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WDRW oWDRW = new WDRW();
				ret = oWDRW.ThirdAudit(oEntry);
				this._Message=oWDRW.Message;
			}
			else
			{
				this._Message = WDRWData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 获取所有领料单。
		/// </summary>
		/// <returns>WDRWData:	单据实体。</returns>
		public WDRWData GetWDRWAll()
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryAll();
		}
		/// <summary>
		/// 根据用户获取所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		public WDRWData GetWDRWAll(string UserLoginId)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// 根据用户获取所有单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>WDRWData:	单据实体。</returns>
        public WDRWData GetWDRWByPerson(string EmpCode)
        {
            WDRWs oWDRWs = new WDRWs();
            return (WDRWData)oWDRWs.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// 根据状态获取领料单清单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		public WDRWData GetWDRWByState(string EntryState)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryByState(EntryState);
		}
		/// <summary>
		/// 根据流水号获取领料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		public WDRWData GetWDRWByEntryNo(int EntryNo)
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryByEntryNo(EntryNo);
		}

        /// <summary>
        /// 根据流水号获取领料单。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>WDRWData:	单据实体。</returns>
        public WDRWData GetWDRWOldByEntryNo(int EntryNo)
        {
            WDRW oWDRW = new WDRW();
            return (WDRWData)oWDRW.GetEntryOldByEntryNo(EntryNo);
        }
		/// <summary>
		/// 根据父单据流水号获取红字。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WDRWData:	领料单实体。</returns>
		public WDRWData GetWDRWRedByEntryNo(int EntryNo)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryRedByEntryNo(EntryNo);
		}
		/// <summary>
		/// 根据流水号获取领料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		public WDRWData GetWDRWByEntryNoOutMode(int EntryNo)
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryByEntryNoOutMode(EntryNo);
		}
		/// <summary>
		/// 根据编号获取领料单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		public WDRWData GetWDRWByEntryCode(string EntryCode)
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// 根据制单部门编号获取领料单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		public WDRWData GetWDRWByDept(string DeptCode)
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryByDept(DeptCode);
		}

		/// <summary>
		/// 根据部门编号获取领料单来源清单。
		/// </summary>
		/// <param name="DeptCode">string:	部门编号。</param>
		/// <returns>WDRWData:	领料单数据实体。</returns>
		public WDRWData GetWDRWSourceListByDeptCode(string DeptCode)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetSourceEntryLisByDeptCode(DeptCode);
		}
		/// <summary>
		/// 根据所选源单据号获取可用的明细内容。
		/// </summary>
		/// <param name="PKIDs">string:	单据的PKIDs。</param>
		/// <returns>WDRWData:	领料单数据实体。</returns>
		public WDRWData GetWDRWSourceDetailByPKIDs(string PKIDs)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetSourceEntryDetailByEntryNos(PKIDs);
		}
		/// <summary>
		/// 根据信息反馈的ID获取领料单实体。
		/// </summary>
		/// <param name="PKIDs">string:	信息反馈IDs。</param>
		/// <returns>WDRWData:	领料单数据实体。</returns>
		public WDRWData GetWDRWByFeedbackIDs(string PKIDs)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryByFeedbackPKIDs(PKIDs);
		}
		#endregion

		#region IWRTSSystem 成员 生产退料单部分
		/// <summary>
		/// 生产退料单的增加。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddWRTS(WRTSData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WRTS oWRTS = new WRTS();
				ret = oWRTS.Insert(oEntry);
				this._Message=oWRTS.Message;
			}
			else
			{
				this._Message = WRTSData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单的增加并且马上提交。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentWRTS(WRTSData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WRTS oWRTS = new WRTS();
				ret = oWRTS.InsertAndPresent(oEntry);
				this._Message=oWRTS.Message;
			}
			else
			{
				this._Message = WRTSData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单的修改。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateWRTS(WRTSData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WRTS oWRTS = new WRTS();
				ret = oWRTS.Update(oEntry);
				this._Message=oWRTS.Message;
			}
			else
			{
				this._Message = WRTSData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单的修改并且马上提交。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentWRTS(WRTSData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WRTS oWRTS = new WRTS();
				ret = oWRTS.UpdateAndPresent(oEntry);
				this._Message=oWRTS.Message;
			}
			else
			{
				this._Message = WRTSData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteWRTS(int EntryNo)
		{
			bool ret = true;
			
			WRTS oWRTS = new WRTS();
			ret = oWRTS.Delete(EntryNo);
			this._Message=oWRTS.Message;
			
			return ret;
		}
		/// <summary>
		/// 生产退料单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentWRTS(int EntryNo, string UserCode)
		{
			bool ret = true;
						
			WRTS oWRTS = new WRTS();
			ret = oWRTS.Present(EntryNo,DocStatus.Present, UserCode);
			this._Message=oWRTS.Message;
			
			return ret;
		}
		/// <summary>
		/// 生产退料单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelWRTS(int EntryNo)
		{
			bool ret = true;
						
			WRTS oWRTS = new WRTS();
			ret = oWRTS.Cancel(EntryNo,DocStatus.Cancel);
			this._Message=oWRTS.Message;
			
			return ret;
		}
		public bool CancelWRTS(int EntryNo,string UserLoginId)
		{
			bool ret = true;
						
			WRTS oWRTS = new WRTS();
			ret = oWRTS.Cancel(EntryNo,DocStatus.Cancel,UserLoginId);
			this._Message=oWRTS.Message;
			
			return ret;
		}
		/// <summary>
		/// 生产退料单的部门审批。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditWRTS(WRTSData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WRTS oWRTS = new WRTS();
				ret = oWRTS.FirstAudit(oEntry);
				this._Message=oWRTS.Message;
			}
			else
			{
				this._Message = WRTSData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单的财务审批。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditWRTS(WRTSData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WRTS oWRTS = new WRTS();
				ret = oWRTS.SecondAudit(oEntry);
				this._Message=oWRTS.Message;
			}
			else
			{
				this._Message = WRTSData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditWRTS(WRTSData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WRTS oWRTS = new WRTS();
				ret = oWRTS.ThirdAudit(oEntry);
				this._Message=oWRTS.Message;
			}
			else
			{
				this._Message = WRTSData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 获取所有生产退料单。
		/// </summary>
		/// <returns>WRTSData:	单据实体。</returns>
		public WRTSData GetWRTSAll()
		{
			WRTS oWRTS = new WRTS();
			return (WRTSData)oWRTS.GetEntryAll();
		}


       


        /// <summary>
        /// 获取所有生产退料单。
        /// </summary>
        /// <returns>WRTSData:	单据实体。</returns>
        public WRTSData GetWRTSByPerson(string EmpCode)
        {
            WRTS oWRTS = new WRTS();
            return (WRTSData)oWRTS.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// 根据流水号获取生产退料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WRTSData:	单据实体。</returns>
		public WRTSData GetWRTSByEntryNo(int EntryNo)
		{
			WRTS oWRTS = new WRTS();
			return (WRTSData)oWRTS.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// 收料模式下，根据流水号获取生产退料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WRTSData:	单据实体。</returns>
		public WRTSData GetWRTSByEntryNoInMode(int EntryNo)
		{
			WRTS oWRTS = new WRTS();
			return (WRTSData)oWRTS.GetEntryByEntryNoInMode(EntryNo);

		}
		/// <summary>
		/// 根据编号获取生产退料单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>WRTSData:	单据实体。</returns>
		public WRTSData GetWRTSByEntryCode(string EntryCode)
		{
			WRTS oWRTS = new WRTS();
			return (WRTSData)oWRTS.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// 根据制单部门编号获取生产退料单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WRTSData:	单据实体。</returns>
		public WRTSData GetWRTSByDept(string DeptCode)
		{
			WRTS oWRTS = new WRTS();
			return (WRTSData)oWRTS.GetEntryByDept(DeptCode);
		}

		public bool Check(WRTSData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WRTS oWRTS = new WRTS();
				ret = oWRTS.Check(oEntry);
				this._Message=oWRTS.Message;
			}
			else
			{
				this._Message = WRTSData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 生产退料单收料
		/// </summary>
		/// <param name="oWRTSData"></param>
		/// <returns></returns>
		public bool ReceiveRTS(WRTSData oWRTSData)
		{
			bool ret = true;
			if (oWRTSData!=null)
			{
				WRTS oWRTS = new WRTS();

				if(oWRTS.Receive(oWRTSData)==false)
				{
					_Message=oWRTS.Message;
					ret=false;
				}
			}
			return ret;
		}
		#endregion

		#region IStockSystem 成员
		/// <summary>
		/// 根据使用频度获取库存。
		/// </summary>
		/// <returns>StockData:	库存实体．</returns>
		public StockData GetStockByUseCount()
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetStockByUseCount();
		}
		/// <summary>
		/// 根据仓库编号获取该仓库的库存．
		/// </summary>
		/// <param name="StoCode">string:	仓库编号．</param>
		/// <returns>StockData:	库存实体．</returns>
		public StockData GetStockByStoCode(string StoCode)
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetStockByStoCode(StoCode);
		}
		/// <summary>
		/// 根据架位编号获取库存．
		/// </summary>
		/// <param name="ConCode">int:	架位编号．</param>
		/// <returns>StockData:	库存实体．</returns>
		public StockData GetStockByConCode(int ConCode)
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetStockByConCode(ConCode);
		}
		/// <summary>
		/// 获取报警库存。
		/// </summary>
		/// <returns>StockData:	库存实体．</returns>
		public StockData GetStockByWarning()
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetWarningStock();
		}
		/// <summary>
		/// 获取高报警库存。
		/// </summary>
		/// <returns>StockData:	库存实体．</returns>
		public StockData GetStockByUppWarning()
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetUppWarningStock();
		}
		/// <summary>
		/// 获取某一个仓库物料的合计库存。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <returns>StockData:	库存实体．</returns>
		public StockData GetStockSumByStoCode(string StoCode)
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetStockSumByStoCode(StoCode);
		}
		/// <summary>
		/// 根据物料编号和架位编号获取该物料在该架位的总的库存数。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="ConCode">int:	架位编号。</param>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetStockSumByItemCodeAndConCode(string ItemCode, int ConCode)
		{
			return new Stocks().GetStockSumByItemCodeAndConCode(ItemCode, ConCode);
		}
		/// <summary>
		/// 根据指定仓库和物料信息获取库存数据。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="ItemName">string :	物料名称。</param>
		/// <param name="ItemSpec">string:	规格型号。</param>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetStockSumByStoCodeAndItem(string StoCode,string ItemCode,string ItemName, string ItemSpec)
		{
			return new Stocks().GetStockSumByStoCodeAndItem(StoCode, ItemCode, ItemName, ItemSpec);
		}
		/// <summary>
		/// 获取物料的总库存。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="ItemName">string:	物料名称。</param>
		/// <param name="ItemSpec">string:	规格型号。</param>
		/// <returns></returns>
		public StockData GetStockSumByItem(string ItemCode,string ItemName, string ItemSpec)
		{
			return new Stocks().GetStockSumByItem(ItemCode, ItemName, ItemSpec);
		}
		/// <summary>
		/// 获取可供选择的库存数据。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="ItemCodeList">string:	物料编号串。</param>
		/// <param name="ItemNumList">string:	实发数量串。</param>
		/// <returns>StockChoiceData:	可供选择的库存数据集。</returns>
		public StockChoiceData GetStockChoice(int DocCode,int EntryNo, string SerialNoList, string ItemCodeList,string ItemNumList)
		{
			WDRWs oWDRWs = new WDRWs();
			return oWDRWs.GetStockChoice(DocCode, EntryNo, SerialNoList, ItemCodeList, ItemNumList);
		}
		/// <summary>
		/// 库存发料。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="SerialNoList">string:	领料单明细顺序号。</param>
		/// <param name="ItemNumList">string:	领料单明细发料数。</param>
		/// <param name="PKIDList">string:	库存ID串。</param>
		/// <param name="ItemDrawNumList">string:	库存扣除数串。</param>
		/// <returns>bool:	发料成功返回true，失败返回false。</returns>
		public bool DrawOutStock(int EntryNo,string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			WDRWs oWDRWs = new WDRWs();
			
			ret = oWDRWs.DrawOutStock(EntryNo,SerialNoList,ItemNumList,PKIDList,ItemDrawNumList, UserCode, UserName, UserLoginId);
			this._Message = oWDRWs.Message;
			return ret;
		}
		/// <summary>
		/// 月结。
		/// </summary>
		/// <param name="Year">int:	年份。</param>
		/// <param name="Month">int:	月份。</param>
		/// <returns>bool:	成功返回true，失败返回false.</returns>
		public bool YJ(int Year, int Month)
		{
			bool ret = false;
			Stocks oStocks = new Stocks();

			ret = oStocks.YJ(Year, Month);
			return ret;
		}

        /// <summary>
        /// 科目月归结.
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public bool YJKM(DateTime beginDate, DateTime endDate)
        {
            bool ret = false;
            Stocks oStocks = new Stocks();

            ret = oStocks.YJKM(beginDate, endDate);
            return ret;
        }

        public bool YJKMNotNull(DateTime beginDate, DateTime endDate)
        {
            bool ret = false;
            Stocks oStocks = new Stocks();

            ret = oStocks.YJKMNoNull(beginDate, endDate);
            return ret;
        }
		#endregion

		#region 通用查询
		/// <summary>
		/// 用途通用查询。
		/// </summary>
		/// <param name="SQL_Statement">string:	SQL语句。</param>
		/// <returns>PurposeData:	用途实体。</returns>
		public PurposeData GetPurposeBySQL(string SQL_Statement)
		{
			Purposes oPurposes = new Purposes();
			return oPurposes.GetPurposeBySQL(SQL_Statement);
		}
		/// <summary>
		/// 领料单的通用查询。
		/// </summary>
		/// <param name="Sql_Statement"></param>
		/// <returns></returns>
		public WDRWData GetWDRWBySQL(string Sql_Statement)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryBySQL(Sql_Statement);
		}
		public WDRWData GetWDRWByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate, DateTime EndDate)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryByDeptAndAuthorAndAuditResult(AuthorDept, AuthorCode, AuditResult,StartDate,EndDate);
		}
		/// <summary>
		/// 生产退料单的通用查询。
		/// </summary>
		/// <param name="Sql_Statement"></param>
		/// <returns></returns>
		public WRTSData GetWRTSBySQL(string Sql_Statement)
		{
			WRTSs oWRTSs = new WRTSs();
			return (WRTSData)oWRTSs.GetEntryBySQL(Sql_Statement);
		}

       

		/// <summary>
		/// 转库单通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>WTRFData:	转库单数据实体。</returns>
		public WTRFData GetWTRFBySQL(string Sql_Statement)
		{
			WTRFs oWTRFs = new WTRFs();
			return (WTRFData)oWTRFs.GetEntryBySQL(Sql_Statement);
		}
		/// <summary>
		/// 架位调整单通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>WTRFData:	架位调整单数据实体。</returns>
		public WADJData GetWADJBySQL(string Sql_Statement)
		{
			WADJs oWADJs = new WADJs();
			return (WADJData)oWADJs.GetEntryBySQL(Sql_Statement);
		}

		/// <summary>
		/// 报废单通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>WTRFData:	报废单数据实体。</returns>
		public WSCRData GetWSCRBySQL(string Sql_Statement)
		{
			WSCRs oWSCRs = new WSCRs();
			return (WSCRData)oWSCRs.GetEntryBySQL(Sql_Statement);
		}
		/// <summary>
		/// 库存通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句.</param>
		/// <returns>StockData:	库存数据实体。</returns>
		public StockData GetStockBySQL(string Sql_Statement)
		{
			Stocks oStocks = new Stocks();
			return (StockData)oStocks.GetStockBySQL(Sql_Statement);
		}
		/// <summary>
		/// 查询库存里最近的库存记录
		/// </summary>
		/// <param name="top">返回的库存记录数</param>
		/// <returns>结果集</returns>
		public StockData GetStockByTop(int top)
		{
			Stocks oStocks = new Stocks();
			return (StockData)oStocks.GetStockByTop(top);
		}
		#endregion

		#region IWTRFSystem 成员
		/// <summary>
		/// 转库单的增加。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddWTRF(WTRFData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.Insert(oEntry);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentWTRF(WTRFData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.InsertAndPresent(oEntry);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的修改。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateWTRF(WTRFData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.Update(oEntry);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的修改并且提交。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentWTRF(WTRFData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.UpdateAndPresent(oEntry);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteWTRF(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.Delete(EntryNo);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentWTRF(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.Present(EntryNo, DocStatus.Present,UserLoginId);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelWTRF(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.Cancel(EntryNo, DocStatus.Cancel);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 转库单的作废.
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号.</param>
		/// <param name="UserLoginId">string: 用户登录名.</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelWTRF(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.Cancel(EntryNo, DocStatus.Cancel,UserLoginId);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的部门审批。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditWTRF(WTRFData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.FirstAudit(oEntry);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的财务审批。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditWTRF(WTRFData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.SecondAudit(oEntry);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditWTRF(WTRFData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.ThirdAudit(oEntry);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 获取所有转库单。
		/// </summary>
		/// <returns>WTRFData:	转库单实体。</returns>
		public WTRFData GetWTRFAll()
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryAll();
		}

		/// <summary>
		/// 根据指定用户获取所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>WTRFData:	转库单实体。</returns>
		public WTRFData GetWTRFAll(string UserLoginId)
		{
			WTRFs oWTRFs = new WTRFs();
			return (WTRFData)oWTRFs.GetEntryAll(UserLoginId);
		}
		/// <summary>
		/// 根据转库单流水号获取转库单。
		/// </summary>
		/// <param name="EntryNo">int:	转库单流水号。</param>
		/// <returns>WTRFData:	转库单实体。</returns>
		public WTRFData GetWTRFByEntryNo(int EntryNo)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByEntryNo(EntryNo);
		}

		/// <summary>
		/// 根据转库单编号获取转库单。
		/// </summary>
		/// <param name="EntryCode">string:	转库单编号。</param>
		/// <returns>WTRFData:	转库单实体。</returns>
		public WTRFData GetWTRFByEntryCode(string EntryCode)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByEntryCode(EntryCode);
		}

		/// <summary>
		/// 根据制单部门编号获取转库单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WTRFData:	转库单实体。</returns>
		public WTRFData GetWTRFByDept(string DeptCode)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// 获取所有的转库单的数据来源。
		/// </summary>
		/// <returns>WTRFData:	转库单的数据来源数据实体。</returns>
		public WTRFData GetWTRFSAll()
		{
			WTRF oWTRF = new WTRF();
			return oWTRF.GetWTRFSAll();
		}
		/// <summary>
		/// 转库单采购确认。
		/// </summary>
		/// <param name="EntryNo">int:	转库单流水号。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AffirmWTRF(int EntryNo,string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WTRF oWTRF = new WTRF();
				ret = oWTRF.Affirm(EntryNo,DocStatus.OrdExec,UserLoginId);
				this._Message = oWTRF.Message;
			}
			else
			{
				this._Message = WTRFData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据PKIDs获取转库单.
		/// </summary>
		/// <param name="PKIDs">string:	主键串.</param>
		/// <returns>WTRFData: 转库单数据实体.</returns>
		public WTRFData GetWTRFSByPKIDs(string PKIDs)
		{
			WTRFData d;
			WTRF oWTRF = new WTRF();
			d=oWTRF.GetWTRFSByPKIDs(PKIDs);
			return d;
		}

		/// <summary>
		/// 根据流水号获取转库单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WTRFData:	单据实体。</returns>
		public WTRFData GetWTRFByEntryNoOutMode(int EntryNo)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByEntryNoOutMode(EntryNo);
		}
		/// <summary>
		/// 根据流水号获取转库单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WTRFData:	单据实体。</returns>
		public WTRFData GetWTRFByEntryNoInMode(int EntryNo)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByEntryNoInMode(EntryNo);
		}

		/// <summary>
		/// 根据状态获取转库单清单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>WTRFData:	单据实体。</returns>
		public WTRFData GetWTRFByState()
		{
			WTRFs oWTRFs = new WTRFs();
			return (WTRFData)oWTRFs.GetEntryByState();
		}
		/// <summary>
		/// 转库时发料。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="SerialNoList">string:	领料单明细顺序号。</param>
		/// <param name="ItemNumList">string:	领料单明细发料数。</param>
		/// <param name="PKIDList">string:	库存ID串。</param>
		/// <param name="ItemDrawNumList">string:	库存扣除数串。</param>
		/// <returns>bool:	发料成功返回true，失败返回false。</returns>
		public bool TransDrawOutStock(int EntryNo,string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			WTRFs oWTRFs = new WTRFs();
			
			ret = oWTRFs.TransDrawOutStock(EntryNo,SerialNoList,ItemNumList,PKIDList,ItemDrawNumList, UserCode, UserName, UserLoginId);
			this._Message = oWTRFs.Message;
			return ret;
		}

		/// <summary>
		/// 转库单收料。
		/// </summary>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool TransDrawInStock( int EntryNo,string StoCode,string StoName, string SerialNoList,string ItemCodeList,string ConCodeList,string ConNameList,string UserCode, string UserName, string UserLoginId)
		{
			bool ret = true;
			WTRFs oWTRFs=new WTRFs();

			ret = oWTRFs.TransDrawInStock(EntryNo,StoCode,StoName,SerialNoList,ItemCodeList,ConCodeList,ConNameList,UserCode,UserName,UserLoginId);
            this._Message=oWTRFs.Message;			
			return ret;
		}
		#endregion
	
		#region IWSCRSystem成员
		/// <summary>
		/// 报废单的增加。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddWSCR(WSCRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.Insert(oEntry);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 报废单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentWSCR(WSCRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.InsertAndPresent(oEntry);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 报废单的修改。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateWSCR(WSCRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.Update(oEntry);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 报废单的修改并且提交。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentWSCR(WSCRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.UpdateAndPresent(oEntry);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 报废单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteWSCR(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.Delete(EntryNo);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 报废单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentWSCR(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.Present(EntryNo, DocStatus.Present,UserLoginId);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 报废单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelWSCR(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.Cancel(EntryNo, DocStatus.Cancel);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		public bool CancelWSCR(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.Cancel(EntryNo, DocStatus.Cancel,UserLoginId);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 报废单的部门审批。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditWSCR(WSCRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.FirstAudit(oEntry);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 报废单的财务审批。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditWSCR(WSCRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.SecondAudit(oEntry);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 报废单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditWSCR(WSCRData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.ThirdAudit(oEntry);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 获取所有报废单。
		/// </summary>
		/// <returns>WSCRData:	报废单实体。</returns>
		public WSCRData GetWSCRAll()
		{
			WSCR oWSCR = new WSCR();
			return (WSCRData)oWSCR.GetEntryAll();
		}

		/// <summary>
		/// 根据指定用户获取所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>WSCRData:	报废单实体。</returns>
		public WSCRData GetWSCRAll(string UserLoginId)
		{
			WSCRs oWSCRs = new WSCRs();
			return (WSCRData)oWSCRs.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// 根据指定用户获取所有单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>WSCRData:	报废单实体。</returns>
        public WSCRData GetWSCRByPerson(string EmpCode)
        {
            WSCRs oWSCRs = new WSCRs();
            return (WSCRData)oWSCRs.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// 根据报废单流水号获取报废单。
		/// </summary>
		/// <param name="EntryNo">int:	报废单流水号。</param>
		/// <returns>WSCRData:	报废单实体。</returns>
		public WSCRData GetWSCRByEntryNo(int EntryNo)
		{
			WSCR oWSCR = new WSCR();
			return (WSCRData)oWSCR.GetEntryByEntryNo(EntryNo);
		}

		public WSCRData GetWSCRByEntryNoDiscardMode(int EntryNo)
		{
			WSCR oWSCR = new WSCR();
			return (WSCRData)oWSCR.GetEntryByEntryNoDiscardMode(EntryNo);
		}
		/// <summary>
		/// 根据报废单编号获取报废单。
		/// </summary>
		/// <param name="EntryCode">string:	报废单编号。</param>
		/// <returns>WSCRData:	报废单实体。</returns>
		public WSCRData GetWSCRByEntryCode(string EntryCode)
		{
			WSCR oWSCR = new WSCR();
			return (WSCRData)oWSCR.GetEntryByEntryCode(EntryCode);
		}

		/// <summary>
		/// 根据制单部门编号获取报废单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WSCRData:	报废单实体。</returns>
		public WSCRData GetWSCRByDept(string DeptCode)
		{
			WSCR oWSCR = new WSCR();
			return (WSCRData)oWSCR.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// 获取所有的报废单的数据来源。
		/// </summary>
		/// <returns>WSCRData:	报废单的数据来源数据实体。</returns>
		public WSCRData GetWSCRSAll()
		{
			WSCR oWSCR = new WSCR();
			return oWSCR.GetWSCRSAll();
		}
		/// <summary>
		/// 报废单采购确认。
		/// </summary>
		/// <param name="EntryNo">int:	报废单流水号。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AffirmWSCR(int EntryNo,string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WSCR oWSCR = new WSCR();
				ret = oWSCR.Affirm(EntryNo,DocStatus.OrdExec,UserLoginId);
				this._Message = oWSCR.Message;
			}
			else
			{
				this._Message = WSCRData.NOOBJECT;
				ret = false;
			}
			return ret;
		}
		public WSCRData GetWSCRSByPKIDs(string PKIDs)
		{
			WSCRData d;
			WSCR oWSCR = new WSCR();
			d=oWSCR.GetWSCRSByPKIDs(PKIDs);
			return d;
		}

		/// <summary>
		/// 根据状态获取报废单清单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>WSCRData:	单据实体。</returns>
		public WSCRData GetWSCRByState()
		{
			WSCRs oWSCRs = new WSCRs();
			return (WSCRData)oWSCRs.GetEntryByState();
		}
		/// <summary>
		/// 报废
		/// </summary>
		/// <param name="EntryNo"></param>
		/// <param name="SerialNoList"></param>
		/// <param name="UserCode"></param>
		/// <param name="UserName"></param>
		/// <returns></returns>
		public bool DiscardWSCR( int EntryNo,string SerialNoList,string ItemNumList,string PKIDList,string ItemDrawNumList,string UserCode, string UserName, string UserLoginId)
		{
			bool ret = true;
			WSCRs oWSCRs=new WSCRs();
			ret = oWSCRs.DiscardWSCR(EntryNo,SerialNoList,ItemNumList,PKIDList,ItemDrawNumList,UserCode,UserName,UserLoginId);
			this._Message=oWSCRs.Message;			
			return ret;
		}
		/// <summary>
		/// 生产退料单收料
		/// </summary>
		/// <param name="EntryNo">退料单单据流水号</param>
		/// <param name="SerialNoList">单据明细内容顺序号列表，以","分隔</param>
		/// <param name="ItemNumList">退料单物料发料数列表，以","分隔</param>
		/// <param name="PKIDList">仓库物料的PKID列表，以","分隔</param>
		/// <param name="ItemDrawNumList">具体从仓库选择后得到的发料数列表，以","分隔</param>
		/// <param name="UserCode">用户</param>
		/// <param name="UserName">用户名</param>
		/// <param name="UserLoginId">登陆ID</param>
		/// <returns></returns>
		public bool RTVReceive( int EntryNo,string SerialNoList,string ItemNumList,string PKIDList,string ItemDrawNumList,string UserCode, string UserName, string UserLoginId ,string ItemPriceList)
		{
			bool ret = true;
			PRTVs oPRTVs=new PRTVs();
			ret = oPRTVs.RTVReceive(EntryNo,SerialNoList,ItemNumList,PKIDList,ItemDrawNumList,UserCode,UserName,UserLoginId,ItemPriceList);
			this._Message=oPRTVs.Message;			
			return ret;
		}
		#endregion

		#region IWADJSystem 成员
		/// <summary>
		/// 获取可供选择的库存数据。
		/// </summary>		
		/// <param name="ItemCode">string:	物料编号串。</param>
		/// <param name="ItemNum">string:	实发数量串。</param>
		/// <returns>StockChoiceData:	可供选择的库存数据集。</returns>
		public WADJData GetStockCon(string ItemCode,string StoCode)
		{
			WADJs oWADJs = new WADJs();
			return oWADJs.GetStockCon(ItemCode,StoCode);
		}
		/// <summary>
		/// 转库单的增加。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddWADJ(WADJData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.Insert(oEntry);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddAndPresentWADJ(WADJData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.InsertAndPresent(oEntry);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的修改。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateWADJ(WADJData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.Update(oEntry);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的修改并且提交。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentWADJ(WADJData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.UpdateAndPresent(oEntry);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteWADJ(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.Delete(EntryNo);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool PresentWADJ(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.Present(EntryNo, DocStatus.Present,UserLoginId);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool CancelWADJ(int EntryNo)
		{
			bool ret = true;
			
			if (EntryNo >= 0)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.Cancel(EntryNo, DocStatus.Cancel);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的部门审批。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAuditWADJ(WADJData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.FirstAudit(oEntry);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的财务审批。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAuditWADJ(WADJData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.SecondAudit(oEntry);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 转库单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAuditWADJ(WADJData oEntry)
		{
			bool ret = true;
			
			if (oEntry != null)
			{
				WADJ oWADJ = new WADJ();
				ret = oWADJ.ThirdAudit(oEntry);
				this._Message = oWADJ.Message;
			}
			else
			{
				this._Message = WADJData.NOOBJECT;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 获取所有转库单。
		/// </summary>
		/// <returns>WADJData:	转库单实体。</returns>
		public WADJData GetWADJAll()
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryAll();
		}

		/// <summary>
		/// 根据指定用户获取所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>WADJData:	转库单实体。</returns>
		public WADJData GetWADJAll(string UserLoginId)
		{
			WADJs oWADJs = new WADJs();
			return (WADJData)oWADJs.GetEntryAll(UserLoginId);
		}
		/// <summary>
		/// 根据转库单流水号获取转库单。
		/// </summary>
		/// <param name="EntryNo">int:	转库单流水号。</param>
		/// <returns>WADJData:	转库单实体。</returns>
		public WADJData GetWADJByEntryNo(int EntryNo)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByEntryNo(EntryNo);
		}

		/// <summary>
		/// 根据转库单编号获取转库单。
		/// </summary>
		/// <param name="EntryCode">string:	转库单编号。</param>
		/// <returns>WADJData:	转库单实体。</returns>
		public WADJData GetWADJByEntryCode(string EntryCode)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByEntryCode(EntryCode);
		}

		/// <summary>
		/// 根据制单部门编号获取架位调整单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WADJData:	架位单实体。</returns>
		public WADJData GetWADJByDept(string DeptCode)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// 获取所有的架位调整单的数据来源。
		/// </summary>
		/// <returns>WADJData:	架位调整单的数据来源数据实体。</returns>
		public WADJData GetWADJSAll()
		{
			WADJ oWADJ = new WADJ();
			return oWADJ.GetWADJSAll();
		}
		
		public WADJData GetWADJSByPKIDs(string PKIDs)
		{
			WADJData d;
			WADJ oWADJ = new WADJ();
			d=oWADJ.GetWADJSByPKIDs(PKIDs);
			return d;
		}

		/// <summary>
		/// 根据流水号获取转库单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WADJData:	单据实体。</returns>
		public WADJData GetWADJByEntryNoOutMode(int EntryNo)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByEntryNoOutMode(EntryNo);
		}
		/// <summary>
		/// 根据流水号获取转库单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WADJData:	单据实体。</returns>
		public WADJData GetWADJByEntryNoInMode(int EntryNo)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByEntryNoInMode(EntryNo);
		}

		/// <summary>
		/// 根据状态获取转库单清单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>WADJData:	单据实体。</returns>
		public WADJData GetWADJByState()
		{
			WADJs oWADJs = new WADJs();
			return (WADJData)oWADJs.GetEntryByState();
		}
		
		#endregion

		#region IMAIOSystem 成员
		/// <summary>
		/// 库存盘点数据的新增。
		/// </summary>
		/// <param name="oMAIOData">MAIOData:	库存盘点数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddMAIO(MAIOData oMAIOData)
		{
			bool ret = true;
			if (oMAIOData != null)
			{
				MAIO oMAIO = new MAIO();
				ret = oMAIO.Add(oMAIOData);
				this._Message = oMAIO.Message;
			}
			else
			{
				this._Message = "空对象！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 修改库存盘点记录。
		/// </summary>
		/// <param name="oMAIOData">MAIOData:	库存盘点记录。</param>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="ConName">string:	架位名称。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateMAIO(MAIOData oMAIOData, string StoCode, string ConName)
		{
			bool ret = true;
			if (oMAIOData != null)
			{
				MAIO oMAIO = new MAIO();
				ret = oMAIO.Update(oMAIOData,StoCode,ConName);
				this._Message = oMAIO.Message;
			}
			else
			{
				this._Message = "空对象！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据物料编号、仓库编号、架位名称获取库存盘点记录。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="ConName">string:	架位名称。</param>
		/// <returns>MAIOData:	库存盘点数据实体。</returns>
		public MAIOData GetMAIOByItemCodeAndStoCodeAndConName(string ItemCode,
			string StoCode,
			string ConName)
		{
			return new MAIOs().GetMAIOByItemCodeAndStoCodeAndConName(ItemCode, StoCode, ConName);
		}
		/// <summary>
		/// 根据物料编号获取库存盘点记录。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <returns>MAIOData:	库存盘点数据实体。</returns>
		public MAIOData GetMAIOByItemCode(string ItemCode)
		{
			return new MAIOs().GetMAIOByItemCode(ItemCode);
		}
		#endregion
		#region OutData 成员
		/// <summary>
		/// 获取所有待发和已发的单据清单。
		/// </summary>
		/// <returns>OutData:	发料单据清单的数据实体。</returns>
		public	OutData GetOutDataAll()
		{
			return new Outs().GetOutDataAll();
		}
		/// <summary>
		/// 获取当前管理员的待发或已发的单据清单。
		/// </summary>
		/// <param name="UserCode">string:	用户编号。</param>
		/// <returns>OutData:	发料单据清单的数据实体。</returns>
		public OutData GetOutDataByStoManager(string UserCode)
		{
			return new Outs().GetOutDataByStoManager(UserCode);
		}
		/// <summary>
		/// 根据仓库管理员获取待发料的单据清单。
		/// </summary>
		/// <param name="UserCode">string:	用户编号。</param>
		/// <returns>OutData:	发料单据清单的数据实体。</returns>
		public OutData GetOutDataByStoManagerWithTODO(string UserCode)
		{
			return new Outs().GetOutDataByStoManagerAndEntryState(UserCode,"T");
		}
		#endregion
		#region IO
		/// <summary>
		/// 根据指定的物料编号获取收发明细帐。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <returns>IOData:	收发明细帐实体。</returns>
		public IOData GetIOByItemCode(string ItemCode)
		{
			return new IOs().GetIOByItemCode(ItemCode);
		}
		/// <summary>
		/// 根据物料编号和日期范围获取收发明细账.
		/// </summary>
		/// <param name="ItemCode">物料编号.</param>
		/// <param name="StartDate">开始日期.</param>
		/// <param name="EndDate">结束日期.</param>
		/// <returns>IOData</returns>
		public IOData GetIOByItemCodeAndDate(string ItemCode,DateTime StartDate, DateTime EndDate)
		{
			return new IOs().GetIOByItemCodeAndDate(ItemCode,StartDate,EndDate);
		}
		#endregion
		#region YCL 
		/// <summary>
		/// 根据日期范围获取原材料收发的分组求和记录.
		/// </summary>
		/// <param name="StartDate">开始日期</param>
		/// <param name="EndDate">结束日期</param>
		/// <returns>原材料收发分组记录集.</returns>
		public YCLGroupData GetYCLGroupByDate(DateTime StartDate, DateTime EndDate)
		{
			return new YCLs().GetYCLGroupByDate(StartDate, EndDate);
		}
		public YCLData GetYCLNow()
		{
			return new YCLs().GetYCLNow();
		}
		/// <summary>
		/// 根据日期范围获取原材料收发的记录集.
		/// </summary>
		/// <param name="StartDate">开始日期</param>
		/// <param name="EndDate">结束日期.</param>
		/// <returns>原材料收发记录集.</returns>
		public YCLData GetYCLByDate(DateTime StartDate, DateTime EndDate)
		{
			return new YCLs().GetYCLByDate(StartDate, EndDate);
		}
		/// <summary>
		/// 获取全部的原材料收发记录.
		/// </summary>
		/// <returns>原材料收发记录集.</returns>
		public YCLData GetYCLALL()
		{
			return new YCLs().GetYCLALL();
		}
		/// <summary>
		/// 根据原材料收发主键值获取原材料收发记录.
		/// </summary>
		/// <param name="PKID"></param>
		/// <returns></returns>
		public YCLData GetYCLByPKID(int PKID)
		{
			return new YCLs().GetYCLByPKID(PKID);
		}
		/// <summary>
		/// 根据物料编号和时间范围获取原材料收发记录.
		/// </summary>
		/// <param name="itemCode">物料编号</param>
		/// <param name="startDate">开始日期</param>
		/// <param name="endDate">结束</param>
		/// <returns>YCLData实体.</returns>
		public YCLData GetYCLByItemAndDate(string itemCode,DateTime startDate,DateTime endDate)
		{
			return new YCLs().GetYCLByItemAndDate(itemCode,startDate,endDate);
		}
		/// <summary>
		/// 增加原材料收发记录.
		/// </summary>
		/// <param name="oYCLData">原材料收发记录.</param>
		/// <returns>bool</returns>
		public bool AddYCL(YCLData oYCLData)
		{
			return new YCLs().Add(oYCLData);
		}
		/// <summary>
		/// 修改原材料收发记录.
		/// </summary>
		/// <param name="oYCLData">原材料收发记录.</param>
		/// <returns>bool</returns>
		public bool UpdateYCL(YCLData oYCLData)
		{
			return new YCLs().Update(oYCLData);
		}
		/// <summary>
		/// 删除原材料收发记录.
		/// </summary>
		/// <param name="PKID">主键值</param>
		/// <returns>bool</returns>
		public bool DeleteYCL(int PKID)
		{
			return new YCLs().Delete(PKID);
		}
		#endregion

		#region IWTOWSystem 成员

		/// <summary>
		/// 检验委外加工申请单操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
		/// <param name="Operation">string:	操作代码。</param>
		/// <returns>bool:	符合前提条件返回true,不符合返回false.</returns>
		public bool CheckPreconditionOfWTOW(int EntryNo,string Operation,string UserLoginId)
		{
			WTOW oWTOW = new WTOW();
			return oWTOW.CheckPreCondition(EntryNo, Operation,UserLoginId);
		}
		public bool AddWTOW(WTOWData oEntry)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.Insert(oEntry);
			this._Message = oWTOW.Message;
			return ret;
		}

		public bool AddAndPresentWTOW(WTOWData oEntry)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.InsertAndPresent(oEntry);
			this._Message = oWTOW.Message;
			return ret;
		}

		public bool UpdateWTOW(WTOWData oEntry)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.Update(oEntry);
			this._Message = oWTOW.Message;
			return ret;
		}

		public bool UpdateAndPresentWTOW(WTOWData oEntry)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.UpdateAndPresent(oEntry);
			this._Message = oWTOW.Message;
			return ret;
		}

		public bool DeleteWTOW(int EntryNo)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.Delete(EntryNo);
			this._Message = oWTOW.Message;
			return ret;
		}


        public bool DeleteWTOW(int EntryNo,string strAuthorLogin)
        {
            WTOW oWTOW = new WTOW();
            bool ret;
            ret = oWTOW.Delete(EntryNo, strAuthorLogin);
            this._Message = oWTOW.Message;
            return ret;
        }

		public bool PresentWTOW(int EntryNo, string UserLoginId)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.Present(EntryNo,DocStatus.Present,UserLoginId);
			this._Message = oWTOW.Message;
			return ret;
		}

		public bool CancelWTOW(int EntryNo)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.Cancel(EntryNo,DocStatus.Cancel);
			this._Message = oWTOW.Message;
			return ret;
		}
		public bool CancelWTOW(int EntryNo,string UserLoginId)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.Cancel(EntryNo,DocStatus.Cancel,UserLoginId);
			this._Message = oWTOW.Message;
			return ret;
		}
		/// <summary>
		/// 委外加工申请单拒发。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单单流水号。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool RefuseWTOW(int EntryNo, string UserLoginId)
		{
			bool ret = true;

			WTOW oWTOW = new WTOW();
			ret = oWTOW.Refuse(EntryNo, UserLoginId);
			this._Message = oWTOW.Message;

			return ret;
		}
		public bool FirstAuditWTOW(WTOWData oEntry)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.FirstAudit(oEntry);
			this._Message = oWTOW.Message;
			return ret;
		}

		public bool SecondAuditWTOW(WTOWData oEntry)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.SecondAudit(oEntry);
			this._Message = oWTOW.Message;
			return ret;
		}

		public bool ThirdAuditWTOW(WTOWData oEntry)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.ThirdAudit(oEntry);
			this._Message = oWTOW.Message;
			return ret;
		}

		public bool StockOutWTOW(WTOWData oEntry)
		{
			WTOW oWTOW = new WTOW();
			bool ret;
			ret = oWTOW.StockOut(oEntry);
			this._Message = oWTOW.Message;
			return ret;
		}
		public WTOWData GetWTOWAll()
		{
			return (WTOWData)(new WTOW().GetEntryAll());
		}
		public WTOWData GetEntryAll(string UserLoginId)
		{
			return (WTOWData)(new WTOW().GetEntryAll(UserLoginId));
		}

        public WTOWData GetEntryByPerson(string EmpCode)
        {
            return (WTOWData)(new WTOW().GetEntryByPerson(EmpCode));
        }

		public WTOWData GetEntryBySQL(string Sql_Statement)
		{
			return (WTOWData)(new WTOWs().GetEntryBySQL(Sql_Statement));
		}
		public WTOWData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			return (WTOWData)(new WTOWs().GetEntryByDeptAndAuthorAndAuditResult(AuthorDept, AuthorCode, AuditResult,StartDate,EndDate));
		}
		public WTOWData GetWTOWByEntryNo(int EntryNo)
		{
			return (WTOWData)(new WTOW().GetEntryByEntryNo(EntryNo));
		}

        public WTOWData GetWTOWOldByEntryNo(int EntryNo)
        {
            return (WTOWData)(new WTOW().GetEntryOldByEntryNo(EntryNo));
        }

        public WTOWData GetWTOWRedByEntryNo(int EntryNo)
        {
            return (WTOWData)(new WTOW().GetEntryRedByEntryNo(EntryNo));
        }

		public WTOWData GetWTOWByState(string EntryState)
		{
			return null;
		}
		public WTOWData GetWTOWByEntryNoOutMode(int EntryNo)
		{
			return (WTOWData)(new WTOW().GetEntryByEntryNoOutMode(EntryNo));
		}

		public WTOWData GetWTOWByEntryCode(string EntryCode)
		{
			return (WTOWData)(new WTOW().GetEntryByEntryCode(EntryCode));
		}

		public WTOWData GetWTOWByDept(string DeptCode)
		{
			return (WTOWData)(new WTOW().GetEntryByDept(DeptCode));
		}
		public WTOWData GetWTOWBySQL(string SQL_Statement)
		{
			return (WTOWData)(new WTOWs().GetEntryBySQL(SQL_Statement));
		}
		public WTOWData GetWTOWValidData()
		{
			return (WTOWData)(new WTOWs().GetWTOWValidData());
		}
		#endregion

		#region IWINWSystem 成员
		public bool CheckPreconditionOfWINW(int EntryNo,string Operation,string UserLoginId)
		{
			WINW oWINW = new WINW();
			return oWINW.CheckPreCondition(EntryNo, Operation,UserLoginId);
		}
		public bool AddWINW(WINWData oEntry)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.Insert(oEntry);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool AddAndPresentWINW(WINWData oEntry)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.InsertAndPresent(oEntry);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool UpdateWINW(WINWData oEntry)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.Update(oEntry);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool UpdateAndPresentWINW(WINWData oEntry)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.UpdateAndPresent(oEntry);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool DeleteWINW(int EntryNo, string UserLoginId)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.Delete(EntryNo, UserLoginId);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool PresentWINW(int EntryNo, string UserLoginId)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.Present(EntryNo,DocStatus.Present, UserLoginId);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool CancelWINW(int EntryNo, string UserLoginId)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.Cancel(EntryNo, DocStatus.Cancel, UserLoginId);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool FirstAuditWINW(WINWData oEntry)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.FirstAudit(oEntry);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool SecondAuditWINW(WINWData oEntry)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.SecondAudit(oEntry);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool ThirdAuditWINW(WINWData oEntry)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.ThirdAudit(oEntry);
			this._Message = oWINW.Message;
			return ret;
		}

		public bool StockInWINW(WINWData oEntry)
		{
			WINW oWINW = new WINW();
			bool ret = oWINW.StockIn(oEntry);
			this._Message = oWINW.Message;
			return ret;
		}

		public WINWData GetWINWAll(string UserLoginId)
		{
			return (WINWData)(new WINW().GetEntryAll(UserLoginId));
		}

        public WINWData GetWINWByPerson(string EmpCode)
        {
            return (WINWData)(new WINW().GetEntryByPerson(EmpCode));
        }

		public WINWData GetWINWByEntryNo(int EntryNo)
		{
			return (WINWData)(new WINW().GetEntryByEntryNo(EntryNo));
		}

        public WINWData GetWINWOldByEntryNo(int EntryNo)
        {
            return (WINWData)(new WINW().GetEntryOldByEntryNo(EntryNo));
        }


        public WINWData GetWINWRedByEntryNo(int EntryNo)
        {
            return (WINWData)(new WINW().GetEntryRedByEntryNo(EntryNo));
        }

		public WINWData GetWINWBySQL(string SQL_Statement)
		{
			return (WINWData)(new WINWs().GetEntryBySQL(SQL_Statement));
		}
		public WINWData GetWINWByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			return (WINWData)(new WINWs().GetEntryByDeptAndAuthorAndAuditResult(AuthorDept, AuthorCode, AuditResult,StartDate,EndDate));
		}
		public WINWData GetWTOWValidDataByEntryNos(string EntryNos, int PSerialNo)
		{
			return (WINWData)(new WINWs().GetWTOWValidDataByEntryNos(EntryNos, PSerialNo));
		}
		#endregion

		#region Analysis
		public CurrentMonth_WithdrawData Get_CurrentMonth_Withdraw(int Year, int Month)
		{
			Analysis oA = new Analysis();
			CurrentMonth_WithdrawData oData;
			oData = oA.Get_CurentMonth_Withdraw(Year, Month);

			this._Message = oA.Message;

			return oData;
		}
		public CurrentABCStockData Get_CurrentABCStock()
		{
			Analysis oA = new Analysis();
			CurrentABCStockData oData;
			oData = oA.Get_CurrentABCStock();

			this._Message = oA.Message;

			return oData;
		}
		public CurrentVendorINData Get_CurrentVendorIN(int Year,int Month)
		{
			Analysis oA = new Analysis();
			CurrentVendorINData oData;
			oData = oA.Get_CurrentVendorIN(Year, Month);

			this._Message = oA.Message;

			return oData;
		}
		public CurrentROSData Get_CurrentROS(int Year, int Month)
		{
			Analysis oA = new Analysis();
			CurrentROSData oData;
			oData = oA.Get_CurrentROS(Year, Month);
			this._Message = oA.Message;
			return oData;
		}
		
		public CurrentROSData Get_CurrentROS(int ResultCode, int Year, int Month)
		{
			Analysis oA = new Analysis();
			CurrentROSData oData;
			oData = oA.Get_CurrentROS(ResultCode, Year, Month);
			this._Message = oA.Message;
			return oData;
		}

		public CurrentStockData Get_CurrentStock(string ABC)
		{
			Analysis oA = new Analysis();
			CurrentStockData oData;
			oData = oA.Get_CurrentStock(ABC);

			this._Message = oA.Message;

			return oData;
		}
		public CurrentStockData Get_CurrentStock(string ABC, string StoName, string CatName)
		{
			Analysis oA = new Analysis();
			CurrentStockData oData;
			oData = oA.Get_CurrentStock(ABC, StoName, CatName);

			this._Message = oA.Message;

			return oData;
		}
		public VendorInDetailData Get_VendorInDetail(string PrvCode,int Year, int Month)
		{
			Analysis oA = new Analysis();
			VendorInDetailData oData;
			oData = oA.Get_VendorInDetail(PrvCode,Year, Month);

			this._Message = oA.Message;

			return oData;
		}

		public VendorInDetailData Get_VendorInDetail(string PrvCode,DateTime StartDate, DateTime EndDate)
		{
			Analysis oA = new Analysis();
			VendorInDetailData oData;
			oData = oA.Get_VendorInDetail(PrvCode,StartDate, EndDate);

			this._Message = oA.Message;

			return oData;
		}
		public WithDrawDetailData Get_WithDrawDetail(string Classify, int Year, int Month)
		{
			Analysis oA = new Analysis();
			WithDrawDetailData oData;
			oData = oA.Get_WithDrawDetail(Classify, Year, Month);

			this._Message = oA.Message;

			return oData;
		}
		/// <summary>
		/// 获取发料明细数据。
		/// </summary>
		/// <param name="ClassifyName">string:	用途分类。</param>
		/// <param name="ReqReason">string:	用途。</param>
		/// <param name="AuthorDeptName">string:	制单部门。</param>
		/// <param name="StartDate">DateTime:	开始日期。</param>
		/// <param name="EndDate">DateTime:	结束日期。</param>
		/// <returns>WithDrawDetailData:	发料明细数据实体。</returns>
		public WithDrawDetailData Get_WithDrawDetail(string ClassifyName, string ReqReason, string AuthorDeptName,DateTime StartDate, DateTime EndDate)
		{
			Analysis oA = new Analysis();
			WithDrawDetailData oData;
			oData = oA.Get_WithDrawDetail(ClassifyName, ReqReason, AuthorDeptName, StartDate,EndDate);
			this._Message = oA.Message;

			return oData;
		}
		/// <summary>
		/// 获取申购明细。
		/// </summary>
		/// <param name="ClassifyName">string:	用途分类。</param>
		/// <param name="ReqReason">string:	用途。</param>
		/// <param name="AuthorDeptName">string:	部门。</param>
		/// <param name="StartDate">DateTime:	开始日期。</param>
		/// <param name="EndDate">DateTime:	结束日期。</param>
		/// <returns>ROSDetailsData: 申购明细实体。</returns>
		public ROSDetailsData Get_ROSDetails(string ClassifyName, string ReqReason, string AuthorDeptName,DateTime StartDate, DateTime EndDate,int Flag)
		{
			Analysis oA = new Analysis();
			ROSDetailsData oData;
			oData = oA.Get_ROSDetails(ClassifyName,ReqReason,AuthorDeptName,StartDate,EndDate,Flag);
			this._Message = oA.Message;
			return oData;
		}
		#endregion

		#region IWITRSystem 成员

		public bool Insert(WITRData oData)
		{
			bool ret;
			WITR oWITR = new WITR();
		    ret = oWITR.Insert(oData);
			this._Message = oWITR.Message;
			return ret;
		}

		public bool InsertAndPresent(WITRData oData)
		{
			bool ret;
			WITR oWITR = new WITR();
			ret = oWITR.InsertAndPresent(oData);
			this._Message = oWITR.Message;
			return ret;
		}

		public bool Update(WITRData oData)
		{
			bool ret;
			WITR oWITR = new WITR();
			ret = oWITR.Update(oData);
			this._Message = oWITR.Message;
			return ret;
		}

		public bool UpdateAndPresent(WITRData oData)
		{
			bool ret;
			WITR oWITR = new WITR();
			ret = oWITR.UpdateAndPresent(oData);
			this._Message = oWITR.Message;
			return ret;
		}
		public bool Cancel(WITRData oData)
		{
			bool ret;
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Cancel(oData);
			this._Message = oWITRs.Message;
			return ret;
		}
		public bool Delete(WITRData oData)
		{
			bool ret;
			WITR oWITR = new WITR();
			ret = oWITR.Delete(oData);
			this._Message = oWITR.Message;
			return ret;
		}

		public bool Affirm(WITRData oData)
		{
			bool ret;
			WITR oWITR = new WITR();
			ret = oWITR.Affirm(oData);
			this._Message = oWITR.Message;
			return ret;
		}

		public bool Refuse(WITRData oData)
		{
			bool ret;
			WITR oWITR = new WITR();
			ret = oWITR.Refuse(oData);
			this._Message = oWITR.Message;
			return ret;
		}
		/// <summary>
		/// 新物料申请转采购需求单。
		/// </summary>
		/// <param name="oData">新物料申请单。</param>
		/// <returns>bool</returns>
		public bool ToPROS(WITRData oData)
		{
			bool ret;
			WITR oWITR = new WITR();
			ret = oWITR.ToPROS(oData);
			this._Message = oWITR.Message;
			return ret;
		}
		/// <summary>
		/// 新物料申请转月度计划需求单。
		/// </summary>
		/// <param name="oData">新物料申请单。</param>
		/// <returns>bool</returns>
		public bool ToMRP(WITRData oData)
		{
			bool ret;
			WITR oWITR = new WITR();
			ret = oWITR.ToMRP(oData);
			this._Message = oWITR.Message;
			return ret;
		}
		public WITRData GetWITRAll()
		{
			return new WITRs().GetWITRALL();
		}

		public WITRData GetWITRByPKID(int PKID)
		{
			return new WITRs().GetWITRByPKID(PKID);
		}

		#endregion

		#region IProjectSystem 成员
		/// <summary>
		/// 
		/// </summary>
		/// <param name="PrjCode"></param>
		/// <returns></returns>
		public ProjectItemData GetProjectItemByPrjCode(string PrjCode)
		{
			return new ProjectItems().GetProjectItemByCode(PrjCode);
		}

		#endregion

		#region IRealDrawItem 成员
		/// <summary>
		/// 根据项目编号获取项目相关的领料记录.
		/// </summary>
		/// <param name="projectCode">string:	项目编号.</param>
		/// <returns>项目相关领料集合.</returns>
		public RealDrawItemData GetByProjectCode(string projectCode)
		{
			return new RealDrawItems().GetByProjectCode(projectCode);
		}

		#endregion
	}
}
