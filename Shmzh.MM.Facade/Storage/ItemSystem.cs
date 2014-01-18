using System;
using Shmzh.MM.Common;
using Shmzh.MM.DataAccess;
using Shmzh.MM.BusinessRules;
namespace Shmzh.MM.Facade
{
	/// <summary>
	///		ItemSystem ��ժҪ˵����
	///     <remarks>
	///         �ṩ�����������ļ���Ψһ�Ľӿ�
	///     </remarks>
	///     <remarks>
	///         �ṩԶ�̵���
	///     </remarks>
	/// </summary>
	public class ItemSystem: MarshalByRefObject,IWDRWSystem,IWRTSSystem,IStockSystem,IWADJSystem,IMAIOSystem,IWTOWSystem,IWINWSystem, IWITRSystem, IProjectSystem, IRealDrawItem
	{
		private string _Message;

		public string Message
		{
			get{return _Message;}
		}

		#region "����Ŀ¼����"

		/// <summary>
		/// 		/// ����һ��Ŀ¼
		/// </summary>
		/// <param name="oCategoryData">Ŀ¼ʵ��</param>
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
		/// �༭һ��Ŀ¼
		/// 		/// </summary>
		/// <param name="oCategoryData">Ŀ¼ʵ��</param>
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
		/// ɾ���ķ���
		/// </summary>
		/// <param name="Code">ɾ���ķ����б�</param>
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
		///  ����Ŀ¼��Ų�ѯ
		/// </summary>
		/// <param name="Code">Ŀ¼���</param>
		/// <returns>Ŀ¼ʵ��</returns>
		public CategoryData QueryCategoryByCode(int Code)
		{
			return (new Category()).GetCategoryByCode(Code);
		}

		/// <summary>
		/// �õ����е�Ŀ¼
		/// </summary>
		/// <returns>Ŀ¼ʵ��</returns>
		public CategoryData QueryAllCategories()
		{
			return (new Category()).GetCategories();
		}		// End GetAllCategories
		/// <summary>
		/// ��ȡ��δ���������Ŀ¼�б�
		/// </summary>
		/// <returns>Ŀ¼ʵ��</returns>
		public CategoryData QueryAvailableCategories()
		{
			return (new Category()).GetAvailableCategories();
		}		// End GetAllCategories
		

		#endregion

		#region "������λ����"
		/// <summary>
		/// ����һ��������λ
		/// </summary>
		/// <param name="oUnitData">������λʵ��</param>
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
		/// �༭һ��������λ
		/// </summary>
		/// <param name="oUnitData">������λʵ��</param>
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
		/// ɾ���Ķ�����λ
		/// </summary>
		/// <param name="Code">ɾ���ķ����б�</param>
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
		///  ���ݶ�����λ��Ų�ѯ
		/// </summary>
		/// <param name="Code">������λ���</param>
		/// <returns>������λ</returns>
		public UnitData QueryUnitByCode(int Code)
		{
			return (new Unit()).GetUnitByCode(Code);
		}

		/// <summary>
		/// �õ����е�Ŀ¼
		/// </summary>
		/// <returns>Ŀ¼ʵ��</returns>
		public UnitData QueryAllUnits()
		{
			return (new Unit()).GetUnits();
		}		// End QueryAllUnits
		#endregion

		#region "�ֿⲿ��"
		/// <summary>
		/// ��ȡ���вֿ���Ϣ��
		/// </summary>
		/// <returns>StoData:	�ֿ�����ʵ�塣</returns>
		public StoData GetStoAll()
		{
			Stos myStos = new Stos();
			return myStos.GetStoAll();
		}
		/// <summary>
		/// ���ݲֿ��Ż�ȡ�ֿ���Ϣ��
		/// </summary>
		/// <param name="Code">string:	�ֿ��š�</param>
		/// <returns>StoData:	�ֿ�����ʵ�塣</returns>
		public StoData GetStoByCode(string Code)
		{
			Stos myStos = new Stos();
			return myStos.GetStoByCode(Code);
		}
		/// <summary>
		/// ���ݲֿ����Ʒ��زֿ���Ϣ��
		/// </summary>
		/// <param name="Description">string:	�ֿ����ơ�</param>
		/// <returns>StoData:	�ֿ�����ʵ�塣</returns>
		public StoData GetStoByDescription(string Description)
		{
			Stos myStos = new Stos();
			return myStos.GetStoByDescription(Description);
		}
		/// <summary>
		/// �ֿ����ӡ�
		/// </summary>
		/// <param name="myStoData">StoData:	�ֿ�����ʵ�塣</param>
		/// <returns>bool:	�ֿ����ӳɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ֿ��޸ġ�
		/// </summary>
		/// <param name="myStoData">StoData:	�ֿ�����ʵ�塣</param>
		/// <returns>bool:	�ֿ��޸ĳɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �ֿ�ɾ����
		/// </summary>
		/// <param name="myStoData">StoData:	�ֿ�����ʵ�塣</param>
		/// <returns>bool:	�ֿ�ɾ���ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ݴ���Ĳֿ���봮����ɾ����
		/// </summary>
		/// <param name="Codes">string:	�ֿ���봮��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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

		#region "��λ����"
		/// <summary>
		/// ���ݼ�λ��ŷ��ؼ�λ��Ϣ��
		/// </summary>
		/// <param name="Code">int:	��λ��š�</param>
		/// <returns>StoConData:	��λ����ʵ�塣</returns>
		public StoConData GetStoConByCode(int Code)
		{
			StoCons myStoCons = new StoCons();
			return myStoCons.GetStoConByCode(Code);
		}
		/// <summary>
		/// ���ݲֿ��ŷ��ؼ�λ��Ϣ��
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <returns>StoConData:	��λ����ʵ�塣</returns>
		public StoConData GetStoConByStoCode(string StoCode)
		{
			StoCons myStoCons = new StoCons();
			return myStoCons.GetStoConByStoCode(StoCode);
		}
		/// <summary>
		/// ���ݲֿ��źͼ�λ���Ʒ��ؼ�λ��Ϣ��
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="Description">string:	��λ���ơ�</param>
		/// <returns>StoConData:	��λ����ʵ�塣</returns>
		public StoConData GetStoConByStoCodeAndDescription(string StoCode, string Description)
		{
			StoCons myStoCons = new StoCons();
			return myStoCons.GetStoConByStoCodeAndDescription(StoCode,Description);
		}
		/// <summary>
		/// ��λ���ӡ�
		/// </summary>
		/// <param name="myStoConData">StoConData:	��λ����ʵ�塣</param>
		/// <returns>bool:	��λ���ӳɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��λ�޸ġ�
		/// </summary>
		/// <param name="myStoConData">StoConData:	��λ����ʵ�塣</param>
		/// <returns>bool:	��λ�޸ĳɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��λɾ����
		/// </summary>
		/// <param name="myStoConData">StoConData:	��λ����ʵ�塣</param>
		/// <returns>bool:	��λɾ���ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ݴ���ļ�λ��Ž��м�λɾ����
		/// </summary>
		/// <param name="Codes">string:	��λ��š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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

		#region "���鱨�沿��"

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public CheckReportData QueryAllCheckReports()
		{
			return (new CheckReport ()).GetCheckReportByCode(-1);
		}		// End QueryAllCheckReports

		#endregion

		#region "�������ļ�"
		/// <summary>
		/// �����������ļ���¼
		/// </summary>
		/// <param name="oItemData">�������ļ�ʵ��</param>
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
		/// �����������ļ���¼
		/// </summary>
		/// <param name="oItemData">�������ļ�ʵ��</param>
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
		/// ɾ�����������ļ�
		/// </summary>
		/// <param name="Code">ɾ�����������ļ��б�</param>
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
		/// �������ѡ������
		/// </summary>
		/// <param name="Code">int:	�����š�</param>
		/// <returns>����������ʵ��</returns>
		public ItemData GetItemsByCatCode(int Code)
		{
			return (new Item()).GetItemsByCatCode(Code);
		}

		/// <summary>
		/// ����ABC�õ������б�
		/// </summary>
		/// <param name="ABC">ABC���෽��</param>
		/// <returns>����������ʵ��</returns>
		public ItemData GetItemsByABC(string ABC)
		{
			return (new Item()).GetItemsByABC(ABC);
		}

		/// <summary>
		/// ��ȡָ��������¼�����������ļ���
		/// </summary>
		/// <param name="Count">int:	������</param>
		/// <returns>ItemData:	����������ʵ�塣</returns>
		public ItemData GetItemsNums(int Count)
		{
			return (new Item()).GetItemsNums(Count);
		}
		/// <summary>
		/// ����SQL����ȡ�����嵥��
		/// </summary>
		/// <param name="strSQL">string:	SQL��䡣</param>
		/// <returns>ItemData:	����������ʵ�塣</returns>
		public ItemData GetItemsBySQL(string strSQL)
		{
			return (new Item()).GetItemsBySQL(strSQL);
		}
        /// <summary>
        /// ���ݸ����������ƺ͹�����ͻ�ȡ�����嵥��
        /// </summary>
        /// <param name="strSQL">string:	SQL��䡣</param>
        /// <returns>ItemData:	����������ʵ�塣</returns>
        public ItemData GetItemsByNameAndSpec(string ItemName,string ItemSpec)
        {
            return (new Item()).GetItemsByNameAndSpec(ItemName,ItemSpec);
        }
		/// <summary>
		/// �������ϱ�Ż�ȡ���ϡ�
		/// </summary>
		/// <param name="Code">string:	���ϱ�š�</param>
		/// <returns>ItemData:	����������ʵ�塣</returns>
		public ItemData GetItemByCode(string Code)
		{
			return new Item().GetItemByCode(Code);
		}
        /// <summary>
        /// ���������ϱ�Ż�ȡ���ϡ�
        /// </summary>
        /// <param name="newCode"></param>
        /// <returns></returns>
        public ItemData GetItemsByNewCode(string newCode)
        {
            return new Item().GetItemsByNewCode(newCode);
        }
		/// <summary>
		/// �������ϱ��ģ������������Ϣ��
		/// </summary>
		/// <param name="Code">string:	���ϱ�š�</param>
		/// <returns>ItemData:	����������ʵ�塣</returns>
		public ItemData GetItemsByCode(string Code)
		{
			return (new Item()).GetItemsByCode(Code);
		}
		/// <summary>
		/// ������������ģ������������Ϣ ��
		/// </summary>
		/// <param name="Name">string:	�������ơ�</param>
		/// <returns>ItemData:	����������ʵ�塣</returns>
		public ItemData GetItemsByName(string Name)
		{
			return (new Item()).GetItemsByName(Name);
		}
		/// <summary>
		/// �����������Ƶ�ƴ������ĸ���������ϵĲ�ѯ��
		/// </summary>
		/// <param name="PYZM">string:	ƴ������</param>
		/// <returns>ItemData:	����������ʵ��.</returns>
		public ItemData GetItemsByPY(string PY)
		{
			return (new Item()).GetItemsByPY(PY);
		}
		/// <summary>
		/// ���ݹ���ͺ�ģ������������Ϣ��
		/// </summary>
		/// <param name="Spec">string:	����ͺš�</param>
		/// <returns>ItemData:	����������ʵ�塣</returns>
		public ItemData GetItemsBySpec (string Spec)
		{
			return (new Item()).GetItemsBySpec(Spec);
		}
		/// <summary>
		/// �������ϱ�š��������ơ�����ͺ�ģ������������Ϣ��
		/// </summary>
		/// <param name="QueryContent">string:	ģ����ѯ���ݡ�</param>
		/// <returns>ItemData:	����������ʵ�塣</returns>
		public ItemData GetItemsByCodeAndNameAndSpec(string QueryContent)
		{
			return new Item().GetItemsByCodeAndNameAndSpec(QueryContent);
		}
		/// <summary>
		/// ��ȡһ���յ�����������ʵ��.
		/// </summary>
		/// <returns>ItemData:	����������ʵ�塣</returns>
		public ItemData GetItemNone()
		{
			//return (new Item()).GetItemsByCode("Լ��Ʈ������Ҷ�ļ��� ");
			return new ItemData();
		}
		/// <summary>
		/// ����ʹ��Ƶ�ʻ�������嵥��
		/// </summary>
		/// <returns>ItemData:	����������ʵ�塣</returns>
		public ItemData GetItemByUseCount()
		{
			return new Items().GetItemByUseCount();
		}
		/// <summary>
		/// ��ȡ���ϵ��Ƽ���š�
		/// </summary>
		/// <param name="PrefixStr">string:	���ϱ��ǰ׺��</param>
		/// <returns>string:	�Ƽ���š�</returns>
		public string GetItemRecommandCode(string PrefixStr)
		{
			ItemData oItemData;
			string RecommandCode;
			oItemData = new Items().GetItemRecommandCode(PrefixStr);
			RecommandCode = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
			return RecommandCode;
		}
		/// <summary>
		/// �����������ƺ͹���ͺŻ�ȡ������Ϣ��
		/// </summary>
		/// <param name="ItemName">string:	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
		/// <returns>ItemData:	����������ʵ��.</returns>
		public ItemData GetItemByNameAndSpec(string ItemName, string ItemSpec)
		{
			return new Items().GetItemByNameAndSpec(ItemName, ItemSpec);
		}
		#endregion
		
		#region "��;����"
		/// <summary>
		/// ��ȡ������;��
		/// </summary>
		/// <returns>PurposeData:	��;����ʵ�塣</returns>
		public PurposeData GetPurposeAll()
		{
			Purposes oPurposes = new Purposes();
			return oPurposes.GetPurposeAll();
		}
		/// <summary>
		/// ��ȡ������Ч����;��
		/// </summary>
		/// <returns>PurposeData:	��;����ʵ�塣</returns>
		public PurposeData GetPurposeAvalible()
		{
			Purposes oPurposes = new Purposes();
			return oPurposes.GetPurposeAvalible();
		}
		/// <summary>
		/// ������;�����ȡ��;��Ϣ.
		/// </summary>
		/// <param name="Code">string:	��;���롣</param>
		/// <returns>PurposeData:	��;����ʵ�塣</returns>
		public PurposeData GetPurposeByCode(string Code)
		{
			Purposes oPurposes = new Purposes();
			return oPurposes.GetPurposeByCode(Code);
		}
		/// <summary>
		/// ��;���ӡ�
		/// </summary>
		/// <param name="oPurposeData">PurposeData:	��;����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��;�޸ġ�
		/// </summary>
		/// <param name="oPurposeData">PurposeData:	�û�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��;������¼ɾ����
		/// </summary>
		/// <param name="oPurposeData">PurposeData:	��;����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��;������¼ɾ����
		/// </summary>
		/// <param name="Codes">string:	�û������ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ������;�����á�ʹ�����ɼ���;��
		/// </summary>
		/// <param name="strClassifyID">��;�����</param>
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

		#region "��;���ಿ��"
		/// <summary>
		/// ��ȡ������;���ࡣ
		/// </summary>
		/// <returns>ClassifyData:	��;��������ʵ�塣</returns>
		public ClassifyData GetClassifyAll()
		{
			var oClassifys = new Classifys();
			return oClassifys.GetClassifyAll();
		}
		/// <summary>
		/// ��ȡ������Ч����;���ࡣ
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
		/// ��ȡ����ʹ�õ���;���ࡣ
		/// </summary>
		/// <returns>>ClassifyData:	��;��������ʵ�塣</returns>
		public ClassifyData GetClassifyInUsing()
		{
			return new Classifys().GetClassifyInUsing();
		}
		/// <summary>
		/// ������;��������ȡ��;��Ϣ.
		/// </summary>
		/// <param name="Code">string:	��;������롣</param>
		/// <returns>ClassifyData:	��;��������ʵ�塣</returns>
		public ClassifyData GetClassifyByCode(string Code)
		{
			Classifys oClassifys = new Classifys();
			return oClassifys.GetClassifyByCode(Code);
		}
		/// <summary>
		/// ��;�������ӡ�
		/// </summary>
		/// <param name="oClassifyData">ClassifyData:	��;��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��;�����޸ġ�
		/// </summary>
		/// <param name="oClassifyData">ClassifyData:	�û�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��;���൥����¼ɾ����
		/// </summary>
		/// <param name="oClassifyData">ClassifyData:	��;��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��;���������¼ɾ����
		/// </summary>
		/// <param name="Codes">string:	�û������ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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

        #region "�ֿ����Ա����"
		/// <summary>
		/// ���ݲֿ����Ա������ȡ�ֿ����Ա��Ϣ��
		/// </summary>
		/// <param name="PKID">int:	�ֿ����Ա����ID��</param>
		/// <returns>StoManagerData:	�ֿ����Ա����ʵ�塣</returns>
		public StoManagerData GetStoManagerByPKID(int PKID)
		{
			StoManagers oStoManagers = new StoManagers();
			return oStoManagers.GetStoManagerByPKID(PKID);
		}
		/// <summary>
		/// ���ݹ���Ա��Ż�ȡ����Ա����Ĳֿ���Ϣ��
		/// </summary>
		/// <param name="Usercode">string:	����Ա��š�</param>
		/// <returns>StoManagerData:	�ֿ����Ա����ʵ�塣</returns>
		public StoManagerData GetStoManagerByUserCode(string UserCode)
		{
			StoManagers oStoManagers = new StoManagers();
			return oStoManagers.GetStoManagerByUserCode(UserCode);
		}

		/// <summary>
		/// ��ȡָ���ֿ�Ĺ���Ա��
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <returns>StoManagerData:	�ֿ����Ա����ʵ�塣</returns>
		public StoManagerData GetStoManagerByStoCode(string StoCode)
		{
			StoManagers oStoManagers = new StoManagers();
			return oStoManagers.GetStoManagerByStoCode(StoCode);
		}
		/// <summary>
		/// ���Ӳֿ����Ա��
		/// </summary>
		/// <param name="oStoManagerData">StoManagerData:	�ֿ����Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���²ֿ����Ա ��
		/// </summary>
		/// <param name="oStoManagerData">StoManagerData:	�ֿ����Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ɾ���ֿ����Ա��
		/// </summary>
		/// <param name="oStoManagerData">StoManagerData:	�ֿ����Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ݴ���Ĳֿ����Ա����������ɾ����
		/// </summary>
		/// <param name="PKIDs">string:	����Ա��������</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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

		#region IWDRWSystem��Ա ���ϵ�����
		/// <summary>
		/// �������ϵ�������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="Operation">string:	�������롣</param>
		/// <returns>bool:	����ǰ����������true,�����Ϸ���false.</returns>
		public bool CheckPreconditionOfWDRW(int EntryNo,string Operation)
		{
			WDRW oWDRW = new WDRW();
			return oWDRW.CheckPreCondition(EntryNo, Operation);
		}
		/// <summary>
		/// �������ϵ�������ǰ������.
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="Operation">string:	�������롣</param>
		/// <param name="UserLoginID">string:	������.</param>
		/// <returns>bool:	����ǰ����������true,�����Ϸ���false.</returns>
		public bool CheckPreconditionOfWDRW(int EntryNo, string Operation, string UserLoginID)
		{
			WDRW oWDRW = new WDRW();
			return oWDRW.CheckPreCondition(EntryNo, Operation, UserLoginID);
		}
		/// <summary>
		/// ���ϵ������ӡ�
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ������Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ����޸ġ�
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ����޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteWDRW(int EntryNo)
		{
			bool ret = true;
			
			WDRW oWDRW = new WDRW();
			ret = oWDRW.Delete(EntryNo);
			this._Message=oWDRW.Message;
			
			return ret;
		}
		/// <summary>
		/// ���ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteWDRW(int EntryNo,string UserLoginId)
		{
			bool ret = true;

			WDRW oWDRW = new WDRW();
			ret = oWDRW.Delete(EntryNo,UserLoginId);
			this._Message = oWDRW.Message;

			return ret;
		}
		/// <summary>
		/// ���ϵ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool PresentWDRW(int EntryNo,string UserLoginId)
		{
			bool ret = true;
						
			WDRW oWDRW = new WDRW();
			ret = oWDRW.Present(EntryNo,DocStatus.Present, UserLoginId);
			this._Message=oWDRW.Message;
			
			return ret;
		}
		/// <summary>
		/// ���ϵ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool CancelWDRW(int EntryNo)
		{
			bool ret = true;
						
			WDRW oWDRW = new WDRW();
			ret = oWDRW.Cancel(EntryNo,DocStatus.Cancel);
			this._Message=oWDRW.Message;
			
			return ret;
		}
		/// <summary>
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool CancelWDRW(int EntryNo,string UserLoginId)
		{
			bool ret = true;
						
			WDRW oWDRW = new WDRW();
			ret = oWDRW.Cancel(EntryNo,DocStatus.Cancel,UserLoginId);
			this._Message=oWDRW.Message;
			
			return ret;
		}
		/// <summary>
		/// ���ϵ��ܷ���
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ��ĳ���������
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ�������ϵ���
		/// </summary>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		public WDRWData GetWDRWAll()
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryAll();
		}
		/// <summary>
		/// �����û���ȡ���е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		public WDRWData GetWDRWAll(string UserLoginId)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// �����û���ȡ���е����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>WDRWData:	����ʵ�塣</returns>
        public WDRWData GetWDRWByPerson(string EmpCode)
        {
            WDRWs oWDRWs = new WDRWs();
            return (WDRWData)oWDRWs.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// ����״̬��ȡ���ϵ��嵥��
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		public WDRWData GetWDRWByState(string EntryState)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryByState(EntryState);
		}
		/// <summary>
		/// ������ˮ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		public WDRWData GetWDRWByEntryNo(int EntryNo)
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryByEntryNo(EntryNo);
		}

        /// <summary>
        /// ������ˮ�Ż�ȡ���ϵ���
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>WDRWData:	����ʵ�塣</returns>
        public WDRWData GetWDRWOldByEntryNo(int EntryNo)
        {
            WDRW oWDRW = new WDRW();
            return (WDRWData)oWDRW.GetEntryOldByEntryNo(EntryNo);
        }
		/// <summary>
		/// ���ݸ�������ˮ�Ż�ȡ���֡�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WDRWData:	���ϵ�ʵ�塣</returns>
		public WDRWData GetWDRWRedByEntryNo(int EntryNo)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryRedByEntryNo(EntryNo);
		}
		/// <summary>
		/// ������ˮ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		public WDRWData GetWDRWByEntryNoOutMode(int EntryNo)
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryByEntryNoOutMode(EntryNo);
		}
		/// <summary>
		/// ���ݱ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		public WDRWData GetWDRWByEntryCode(string EntryCode)
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		public WDRWData GetWDRWByDept(string DeptCode)
		{
			WDRW oWDRW = new WDRW();
			return (WDRWData)oWDRW.GetEntryByDept(DeptCode);
		}

		/// <summary>
		/// ���ݲ��ű�Ż�ȡ���ϵ���Դ�嵥��
		/// </summary>
		/// <param name="DeptCode">string:	���ű�š�</param>
		/// <returns>WDRWData:	���ϵ�����ʵ�塣</returns>
		public WDRWData GetWDRWSourceListByDeptCode(string DeptCode)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetSourceEntryLisByDeptCode(DeptCode);
		}
		/// <summary>
		/// ������ѡԴ���ݺŻ�ȡ���õ���ϸ���ݡ�
		/// </summary>
		/// <param name="PKIDs">string:	���ݵ�PKIDs��</param>
		/// <returns>WDRWData:	���ϵ�����ʵ�塣</returns>
		public WDRWData GetWDRWSourceDetailByPKIDs(string PKIDs)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetSourceEntryDetailByEntryNos(PKIDs);
		}
		/// <summary>
		/// ������Ϣ������ID��ȡ���ϵ�ʵ�塣
		/// </summary>
		/// <param name="PKIDs">string:	��Ϣ����IDs��</param>
		/// <returns>WDRWData:	���ϵ�����ʵ�塣</returns>
		public WDRWData GetWDRWByFeedbackIDs(string PKIDs)
		{
			WDRWs oWDRWs = new WDRWs();
			return (WDRWData)oWDRWs.GetEntryByFeedbackPKIDs(PKIDs);
		}
		#endregion

		#region IWRTSSystem ��Ա �������ϵ�����
		/// <summary>
		/// �������ϵ������ӡ�
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������ϵ������Ӳ��������ύ��
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������ϵ����޸ġ�
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������ϵ����޸Ĳ��������ύ��
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteWRTS(int EntryNo)
		{
			bool ret = true;
			
			WRTS oWRTS = new WRTS();
			ret = oWRTS.Delete(EntryNo);
			this._Message=oWRTS.Message;
			
			return ret;
		}
		/// <summary>
		/// �������ϵ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool PresentWRTS(int EntryNo, string UserCode)
		{
			bool ret = true;
						
			WRTS oWRTS = new WRTS();
			ret = oWRTS.Present(EntryNo,DocStatus.Present, UserCode);
			this._Message=oWRTS.Message;
			
			return ret;
		}
		/// <summary>
		/// �������ϵ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// �������ϵ��ĳ���������
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ�����������ϵ���
		/// </summary>
		/// <returns>WRTSData:	����ʵ�塣</returns>
		public WRTSData GetWRTSAll()
		{
			WRTS oWRTS = new WRTS();
			return (WRTSData)oWRTS.GetEntryAll();
		}


       


        /// <summary>
        /// ��ȡ�����������ϵ���
        /// </summary>
        /// <returns>WRTSData:	����ʵ�塣</returns>
        public WRTSData GetWRTSByPerson(string EmpCode)
        {
            WRTS oWRTS = new WRTS();
            return (WRTSData)oWRTS.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// ������ˮ�Ż�ȡ�������ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WRTSData:	����ʵ�塣</returns>
		public WRTSData GetWRTSByEntryNo(int EntryNo)
		{
			WRTS oWRTS = new WRTS();
			return (WRTSData)oWRTS.GetEntryByEntryNo(EntryNo);
		}
		/// <summary>
		/// ����ģʽ�£�������ˮ�Ż�ȡ�������ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WRTSData:	����ʵ�塣</returns>
		public WRTSData GetWRTSByEntryNoInMode(int EntryNo)
		{
			WRTS oWRTS = new WRTS();
			return (WRTSData)oWRTS.GetEntryByEntryNoInMode(EntryNo);

		}
		/// <summary>
		/// ���ݱ�Ż�ȡ�������ϵ���
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>WRTSData:	����ʵ�塣</returns>
		public WRTSData GetWRTSByEntryCode(string EntryCode)
		{
			WRTS oWRTS = new WRTS();
			return (WRTSData)oWRTS.GetEntryByEntryCode(EntryCode);
		}
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�������ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WRTSData:	����ʵ�塣</returns>
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
		/// �������ϵ�����
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

		#region IStockSystem ��Ա
		/// <summary>
		/// ����ʹ��Ƶ�Ȼ�ȡ��档
		/// </summary>
		/// <returns>StockData:	���ʵ�壮</returns>
		public StockData GetStockByUseCount()
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetStockByUseCount();
		}
		/// <summary>
		/// ���ݲֿ��Ż�ȡ�òֿ�Ŀ�森
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��ţ�</param>
		/// <returns>StockData:	���ʵ�壮</returns>
		public StockData GetStockByStoCode(string StoCode)
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetStockByStoCode(StoCode);
		}
		/// <summary>
		/// ���ݼ�λ��Ż�ȡ��森
		/// </summary>
		/// <param name="ConCode">int:	��λ��ţ�</param>
		/// <returns>StockData:	���ʵ�壮</returns>
		public StockData GetStockByConCode(int ConCode)
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetStockByConCode(ConCode);
		}
		/// <summary>
		/// ��ȡ������档
		/// </summary>
		/// <returns>StockData:	���ʵ�壮</returns>
		public StockData GetStockByWarning()
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetWarningStock();
		}
		/// <summary>
		/// ��ȡ�߱�����档
		/// </summary>
		/// <returns>StockData:	���ʵ�壮</returns>
		public StockData GetStockByUppWarning()
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetUppWarningStock();
		}
		/// <summary>
		/// ��ȡĳһ���ֿ����ϵĺϼƿ�档
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <returns>StockData:	���ʵ�壮</returns>
		public StockData GetStockSumByStoCode(string StoCode)
		{
			Stocks oStocks = new Stocks();
			return oStocks.GetStockSumByStoCode(StoCode);
		}
		/// <summary>
		/// �������ϱ�źͼ�λ��Ż�ȡ�������ڸü�λ���ܵĿ������
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ConCode">int:	��λ��š�</param>
		/// <returns>StockData:	�������ʵ�壮</returns>
		public StockData GetStockSumByItemCodeAndConCode(string ItemCode, int ConCode)
		{
			return new Stocks().GetStockSumByItemCodeAndConCode(ItemCode, ConCode);
		}
		/// <summary>
		/// ����ָ���ֿ��������Ϣ��ȡ������ݡ�
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ItemName">string :	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
		/// <returns>StockData:	�������ʵ�壮</returns>
		public StockData GetStockSumByStoCodeAndItem(string StoCode,string ItemCode,string ItemName, string ItemSpec)
		{
			return new Stocks().GetStockSumByStoCodeAndItem(StoCode, ItemCode, ItemName, ItemSpec);
		}
		/// <summary>
		/// ��ȡ���ϵ��ܿ�档
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ItemName">string:	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
		/// <returns></returns>
		public StockData GetStockSumByItem(string ItemCode,string ItemName, string ItemSpec)
		{
			return new Stocks().GetStockSumByItem(ItemCode, ItemName, ItemSpec);
		}
		/// <summary>
		/// ��ȡ�ɹ�ѡ��Ŀ�����ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="ItemCodeList">string:	���ϱ�Ŵ���</param>
		/// <param name="ItemNumList">string:	ʵ����������</param>
		/// <returns>StockChoiceData:	�ɹ�ѡ��Ŀ�����ݼ���</returns>
		public StockChoiceData GetStockChoice(int DocCode,int EntryNo, string SerialNoList, string ItemCodeList,string ItemNumList)
		{
			WDRWs oWDRWs = new WDRWs();
			return oWDRWs.GetStockChoice(DocCode, EntryNo, SerialNoList, ItemCodeList, ItemNumList);
		}
		/// <summary>
		/// ��淢�ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="SerialNoList">string:	���ϵ���ϸ˳��š�</param>
		/// <param name="ItemNumList">string:	���ϵ���ϸ��������</param>
		/// <param name="PKIDList">string:	���ID����</param>
		/// <param name="ItemDrawNumList">string:	���۳�������</param>
		/// <returns>bool:	���ϳɹ�����true��ʧ�ܷ���false��</returns>
		public bool DrawOutStock(int EntryNo,string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			WDRWs oWDRWs = new WDRWs();
			
			ret = oWDRWs.DrawOutStock(EntryNo,SerialNoList,ItemNumList,PKIDList,ItemDrawNumList, UserCode, UserName, UserLoginId);
			this._Message = oWDRWs.Message;
			return ret;
		}
		/// <summary>
		/// �½ᡣ
		/// </summary>
		/// <param name="Year">int:	��ݡ�</param>
		/// <param name="Month">int:	�·ݡ�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false.</returns>
		public bool YJ(int Year, int Month)
		{
			bool ret = false;
			Stocks oStocks = new Stocks();

			ret = oStocks.YJ(Year, Month);
			return ret;
		}

        /// <summary>
        /// ��Ŀ�¹��.
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

		#region ͨ�ò�ѯ
		/// <summary>
		/// ��;ͨ�ò�ѯ��
		/// </summary>
		/// <param name="SQL_Statement">string:	SQL��䡣</param>
		/// <returns>PurposeData:	��;ʵ�塣</returns>
		public PurposeData GetPurposeBySQL(string SQL_Statement)
		{
			Purposes oPurposes = new Purposes();
			return oPurposes.GetPurposeBySQL(SQL_Statement);
		}
		/// <summary>
		/// ���ϵ���ͨ�ò�ѯ��
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
		/// �������ϵ���ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement"></param>
		/// <returns></returns>
		public WRTSData GetWRTSBySQL(string Sql_Statement)
		{
			WRTSs oWRTSs = new WRTSs();
			return (WRTSData)oWRTSs.GetEntryBySQL(Sql_Statement);
		}

       

		/// <summary>
		/// ת�ⵥͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>WTRFData:	ת�ⵥ����ʵ�塣</returns>
		public WTRFData GetWTRFBySQL(string Sql_Statement)
		{
			WTRFs oWTRFs = new WTRFs();
			return (WTRFData)oWTRFs.GetEntryBySQL(Sql_Statement);
		}
		/// <summary>
		/// ��λ������ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>WTRFData:	��λ����������ʵ�塣</returns>
		public WADJData GetWADJBySQL(string Sql_Statement)
		{
			WADJs oWADJs = new WADJs();
			return (WADJData)oWADJs.GetEntryBySQL(Sql_Statement);
		}

		/// <summary>
		/// ���ϵ�ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>WTRFData:	���ϵ�����ʵ�塣</returns>
		public WSCRData GetWSCRBySQL(string Sql_Statement)
		{
			WSCRs oWSCRs = new WSCRs();
			return (WSCRData)oWSCRs.GetEntryBySQL(Sql_Statement);
		}
		/// <summary>
		/// ���ͨ�ò�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL���.</param>
		/// <returns>StockData:	�������ʵ�塣</returns>
		public StockData GetStockBySQL(string Sql_Statement)
		{
			Stocks oStocks = new Stocks();
			return (StockData)oStocks.GetStockBySQL(Sql_Statement);
		}
		/// <summary>
		/// ��ѯ���������Ŀ���¼
		/// </summary>
		/// <param name="top">���صĿ���¼��</param>
		/// <returns>�����</returns>
		public StockData GetStockByTop(int top)
		{
			Stocks oStocks = new Stocks();
			return (StockData)oStocks.GetStockByTop(top);
		}
		#endregion

		#region IWTRFSystem ��Ա
		/// <summary>
		/// ת�ⵥ�����ӡ�
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�����Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ���޸ġ�
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ���޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ��ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ���ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ������.
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ��.</param>
		/// <param name="UserLoginId">string: �û���¼��.</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�ĳ���������
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ����ת�ⵥ��
		/// </summary>
		/// <returns>WTRFData:	ת�ⵥʵ�塣</returns>
		public WTRFData GetWTRFAll()
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryAll();
		}

		/// <summary>
		/// ����ָ���û���ȡ���е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>WTRFData:	ת�ⵥʵ�塣</returns>
		public WTRFData GetWTRFAll(string UserLoginId)
		{
			WTRFs oWTRFs = new WTRFs();
			return (WTRFData)oWTRFs.GetEntryAll(UserLoginId);
		}
		/// <summary>
		/// ����ת�ⵥ��ˮ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	ת�ⵥ��ˮ�š�</param>
		/// <returns>WTRFData:	ת�ⵥʵ�塣</returns>
		public WTRFData GetWTRFByEntryNo(int EntryNo)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByEntryNo(EntryNo);
		}

		/// <summary>
		/// ����ת�ⵥ��Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryCode">string:	ת�ⵥ��š�</param>
		/// <returns>WTRFData:	ת�ⵥʵ�塣</returns>
		public WTRFData GetWTRFByEntryCode(string EntryCode)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByEntryCode(EntryCode);
		}

		/// <summary>
		/// �����Ƶ����ű�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WTRFData:	ת�ⵥʵ�塣</returns>
		public WTRFData GetWTRFByDept(string DeptCode)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// ��ȡ���е�ת�ⵥ��������Դ��
		/// </summary>
		/// <returns>WTRFData:	ת�ⵥ��������Դ����ʵ�塣</returns>
		public WTRFData GetWTRFSAll()
		{
			WTRF oWTRF = new WTRF();
			return oWTRF.GetWTRFSAll();
		}
		/// <summary>
		/// ת�ⵥ�ɹ�ȷ�ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	ת�ⵥ��ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ����PKIDs��ȡת�ⵥ.
		/// </summary>
		/// <param name="PKIDs">string:	������.</param>
		/// <returns>WTRFData: ת�ⵥ����ʵ��.</returns>
		public WTRFData GetWTRFSByPKIDs(string PKIDs)
		{
			WTRFData d;
			WTRF oWTRF = new WTRF();
			d=oWTRF.GetWTRFSByPKIDs(PKIDs);
			return d;
		}

		/// <summary>
		/// ������ˮ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WTRFData:	����ʵ�塣</returns>
		public WTRFData GetWTRFByEntryNoOutMode(int EntryNo)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByEntryNoOutMode(EntryNo);
		}
		/// <summary>
		/// ������ˮ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WTRFData:	����ʵ�塣</returns>
		public WTRFData GetWTRFByEntryNoInMode(int EntryNo)
		{
			WTRF oWTRF = new WTRF();
			return (WTRFData)oWTRF.GetEntryByEntryNoInMode(EntryNo);
		}

		/// <summary>
		/// ����״̬��ȡת�ⵥ�嵥��
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>WTRFData:	����ʵ�塣</returns>
		public WTRFData GetWTRFByState()
		{
			WTRFs oWTRFs = new WTRFs();
			return (WTRFData)oWTRFs.GetEntryByState();
		}
		/// <summary>
		/// ת��ʱ���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="SerialNoList">string:	���ϵ���ϸ˳��š�</param>
		/// <param name="ItemNumList">string:	���ϵ���ϸ��������</param>
		/// <param name="PKIDList">string:	���ID����</param>
		/// <param name="ItemDrawNumList">string:	���۳�������</param>
		/// <returns>bool:	���ϳɹ�����true��ʧ�ܷ���false��</returns>
		public bool TransDrawOutStock(int EntryNo,string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			WTRFs oWTRFs = new WTRFs();
			
			ret = oWTRFs.TransDrawOutStock(EntryNo,SerialNoList,ItemNumList,PKIDList,ItemDrawNumList, UserCode, UserName, UserLoginId);
			this._Message = oWTRFs.Message;
			return ret;
		}

		/// <summary>
		/// ת�ⵥ���ϡ�
		/// </summary>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool TransDrawInStock( int EntryNo,string StoCode,string StoName, string SerialNoList,string ItemCodeList,string ConCodeList,string ConNameList,string UserCode, string UserName, string UserLoginId)
		{
			bool ret = true;
			WTRFs oWTRFs=new WTRFs();

			ret = oWTRFs.TransDrawInStock(EntryNo,StoCode,StoName,SerialNoList,ItemCodeList,ConCodeList,ConNameList,UserCode,UserName,UserLoginId);
            this._Message=oWTRFs.Message;			
			return ret;
		}
		#endregion
	
		#region IWSCRSystem��Ա
		/// <summary>
		/// ���ϵ������ӡ�
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ������Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ����޸ġ�
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ����޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ���ϵ��ĳ���������
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ���б��ϵ���
		/// </summary>
		/// <returns>WSCRData:	���ϵ�ʵ�塣</returns>
		public WSCRData GetWSCRAll()
		{
			WSCR oWSCR = new WSCR();
			return (WSCRData)oWSCR.GetEntryAll();
		}

		/// <summary>
		/// ����ָ���û���ȡ���е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>WSCRData:	���ϵ�ʵ�塣</returns>
		public WSCRData GetWSCRAll(string UserLoginId)
		{
			WSCRs oWSCRs = new WSCRs();
			return (WSCRData)oWSCRs.GetEntryAll(UserLoginId);
		}

        /// <summary>
        /// ����ָ���û���ȡ���е����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>WSCRData:	���ϵ�ʵ�塣</returns>
        public WSCRData GetWSCRByPerson(string EmpCode)
        {
            WSCRs oWSCRs = new WSCRs();
            return (WSCRData)oWSCRs.GetEntryByPerson(EmpCode);
        }
		/// <summary>
		/// ���ݱ��ϵ���ˮ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>WSCRData:	���ϵ�ʵ�塣</returns>
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
		/// ���ݱ��ϵ���Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryCode">string:	���ϵ���š�</param>
		/// <returns>WSCRData:	���ϵ�ʵ�塣</returns>
		public WSCRData GetWSCRByEntryCode(string EntryCode)
		{
			WSCR oWSCR = new WSCR();
			return (WSCRData)oWSCR.GetEntryByEntryCode(EntryCode);
		}

		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WSCRData:	���ϵ�ʵ�塣</returns>
		public WSCRData GetWSCRByDept(string DeptCode)
		{
			WSCR oWSCR = new WSCR();
			return (WSCRData)oWSCR.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// ��ȡ���еı��ϵ���������Դ��
		/// </summary>
		/// <returns>WSCRData:	���ϵ���������Դ����ʵ�塣</returns>
		public WSCRData GetWSCRSAll()
		{
			WSCR oWSCR = new WSCR();
			return oWSCR.GetWSCRSAll();
		}
		/// <summary>
		/// ���ϵ��ɹ�ȷ�ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ����״̬��ȡ���ϵ��嵥��
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>WSCRData:	����ʵ�塣</returns>
		public WSCRData GetWSCRByState()
		{
			WSCRs oWSCRs = new WSCRs();
			return (WSCRData)oWSCRs.GetEntryByState();
		}
		/// <summary>
		/// ����
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
		/// �������ϵ�����
		/// </summary>
		/// <param name="EntryNo">���ϵ�������ˮ��</param>
		/// <param name="SerialNoList">������ϸ����˳����б���","�ָ�</param>
		/// <param name="ItemNumList">���ϵ����Ϸ������б���","�ָ�</param>
		/// <param name="PKIDList">�ֿ����ϵ�PKID�б���","�ָ�</param>
		/// <param name="ItemDrawNumList">����Ӳֿ�ѡ���õ��ķ������б���","�ָ�</param>
		/// <param name="UserCode">�û�</param>
		/// <param name="UserName">�û���</param>
		/// <param name="UserLoginId">��½ID</param>
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

		#region IWADJSystem ��Ա
		/// <summary>
		/// ��ȡ�ɹ�ѡ��Ŀ�����ݡ�
		/// </summary>		
		/// <param name="ItemCode">string:	���ϱ�Ŵ���</param>
		/// <param name="ItemNum">string:	ʵ����������</param>
		/// <returns>StockChoiceData:	�ɹ�ѡ��Ŀ�����ݼ���</returns>
		public WADJData GetStockCon(string ItemCode,string StoCode)
		{
			WADJs oWADJs = new WADJs();
			return oWADJs.GetStockCon(ItemCode,StoCode);
		}
		/// <summary>
		/// ת�ⵥ�����ӡ�
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�����Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ���޸ġ�
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ���޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ��ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ���ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ת�ⵥ�ĳ���������
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
		/// ��ȡ����ת�ⵥ��
		/// </summary>
		/// <returns>WADJData:	ת�ⵥʵ�塣</returns>
		public WADJData GetWADJAll()
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryAll();
		}

		/// <summary>
		/// ����ָ���û���ȡ���е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>WADJData:	ת�ⵥʵ�塣</returns>
		public WADJData GetWADJAll(string UserLoginId)
		{
			WADJs oWADJs = new WADJs();
			return (WADJData)oWADJs.GetEntryAll(UserLoginId);
		}
		/// <summary>
		/// ����ת�ⵥ��ˮ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	ת�ⵥ��ˮ�š�</param>
		/// <returns>WADJData:	ת�ⵥʵ�塣</returns>
		public WADJData GetWADJByEntryNo(int EntryNo)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByEntryNo(EntryNo);
		}

		/// <summary>
		/// ����ת�ⵥ��Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryCode">string:	ת�ⵥ��š�</param>
		/// <returns>WADJData:	ת�ⵥʵ�塣</returns>
		public WADJData GetWADJByEntryCode(string EntryCode)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByEntryCode(EntryCode);
		}

		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ��λ��������
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WADJData:	��λ��ʵ�塣</returns>
		public WADJData GetWADJByDept(string DeptCode)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByDept(DeptCode);
		}
		/// <summary>
		/// ��ȡ���еļ�λ��������������Դ��
		/// </summary>
		/// <returns>WADJData:	��λ��������������Դ����ʵ�塣</returns>
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
		/// ������ˮ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WADJData:	����ʵ�塣</returns>
		public WADJData GetWADJByEntryNoOutMode(int EntryNo)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByEntryNoOutMode(EntryNo);
		}
		/// <summary>
		/// ������ˮ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WADJData:	����ʵ�塣</returns>
		public WADJData GetWADJByEntryNoInMode(int EntryNo)
		{
			WADJ oWADJ = new WADJ();
			return (WADJData)oWADJ.GetEntryByEntryNoInMode(EntryNo);
		}

		/// <summary>
		/// ����״̬��ȡת�ⵥ�嵥��
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>WADJData:	����ʵ�塣</returns>
		public WADJData GetWADJByState()
		{
			WADJs oWADJs = new WADJs();
			return (WADJData)oWADJs.GetEntryByState();
		}
		
		#endregion

		#region IMAIOSystem ��Ա
		/// <summary>
		/// ����̵����ݵ�������
		/// </summary>
		/// <param name="oMAIOData">MAIOData:	����̵�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
				this._Message = "�ն���";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �޸Ŀ���̵��¼��
		/// </summary>
		/// <param name="oMAIOData">MAIOData:	����̵��¼��</param>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="ConName">string:	��λ���ơ�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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
				this._Message = "�ն���";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �������ϱ�š��ֿ��š���λ���ƻ�ȡ����̵��¼��
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="ConName">string:	��λ���ơ�</param>
		/// <returns>MAIOData:	����̵�����ʵ�塣</returns>
		public MAIOData GetMAIOByItemCodeAndStoCodeAndConName(string ItemCode,
			string StoCode,
			string ConName)
		{
			return new MAIOs().GetMAIOByItemCodeAndStoCodeAndConName(ItemCode, StoCode, ConName);
		}
		/// <summary>
		/// �������ϱ�Ż�ȡ����̵��¼��
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <returns>MAIOData:	����̵�����ʵ�塣</returns>
		public MAIOData GetMAIOByItemCode(string ItemCode)
		{
			return new MAIOs().GetMAIOByItemCode(ItemCode);
		}
		#endregion
		#region OutData ��Ա
		/// <summary>
		/// ��ȡ���д������ѷ��ĵ����嵥��
		/// </summary>
		/// <returns>OutData:	���ϵ����嵥������ʵ�塣</returns>
		public	OutData GetOutDataAll()
		{
			return new Outs().GetOutDataAll();
		}
		/// <summary>
		/// ��ȡ��ǰ����Ա�Ĵ������ѷ��ĵ����嵥��
		/// </summary>
		/// <param name="UserCode">string:	�û���š�</param>
		/// <returns>OutData:	���ϵ����嵥������ʵ�塣</returns>
		public OutData GetOutDataByStoManager(string UserCode)
		{
			return new Outs().GetOutDataByStoManager(UserCode);
		}
		/// <summary>
		/// ���ݲֿ����Ա��ȡ�����ϵĵ����嵥��
		/// </summary>
		/// <param name="UserCode">string:	�û���š�</param>
		/// <returns>OutData:	���ϵ����嵥������ʵ�塣</returns>
		public OutData GetOutDataByStoManagerWithTODO(string UserCode)
		{
			return new Outs().GetOutDataByStoManagerAndEntryState(UserCode,"T");
		}
		#endregion
		#region IO
		/// <summary>
		/// ����ָ�������ϱ�Ż�ȡ�շ���ϸ�ʡ�
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <returns>IOData:	�շ���ϸ��ʵ�塣</returns>
		public IOData GetIOByItemCode(string ItemCode)
		{
			return new IOs().GetIOByItemCode(ItemCode);
		}
		/// <summary>
		/// �������ϱ�ź����ڷ�Χ��ȡ�շ���ϸ��.
		/// </summary>
		/// <param name="ItemCode">���ϱ��.</param>
		/// <param name="StartDate">��ʼ����.</param>
		/// <param name="EndDate">��������.</param>
		/// <returns>IOData</returns>
		public IOData GetIOByItemCodeAndDate(string ItemCode,DateTime StartDate, DateTime EndDate)
		{
			return new IOs().GetIOByItemCodeAndDate(ItemCode,StartDate,EndDate);
		}
		#endregion
		#region YCL 
		/// <summary>
		/// �������ڷ�Χ��ȡԭ�����շ��ķ�����ͼ�¼.
		/// </summary>
		/// <param name="StartDate">��ʼ����</param>
		/// <param name="EndDate">��������</param>
		/// <returns>ԭ�����շ������¼��.</returns>
		public YCLGroupData GetYCLGroupByDate(DateTime StartDate, DateTime EndDate)
		{
			return new YCLs().GetYCLGroupByDate(StartDate, EndDate);
		}
		public YCLData GetYCLNow()
		{
			return new YCLs().GetYCLNow();
		}
		/// <summary>
		/// �������ڷ�Χ��ȡԭ�����շ��ļ�¼��.
		/// </summary>
		/// <param name="StartDate">��ʼ����</param>
		/// <param name="EndDate">��������.</param>
		/// <returns>ԭ�����շ���¼��.</returns>
		public YCLData GetYCLByDate(DateTime StartDate, DateTime EndDate)
		{
			return new YCLs().GetYCLByDate(StartDate, EndDate);
		}
		/// <summary>
		/// ��ȡȫ����ԭ�����շ���¼.
		/// </summary>
		/// <returns>ԭ�����շ���¼��.</returns>
		public YCLData GetYCLALL()
		{
			return new YCLs().GetYCLALL();
		}
		/// <summary>
		/// ����ԭ�����շ�����ֵ��ȡԭ�����շ���¼.
		/// </summary>
		/// <param name="PKID"></param>
		/// <returns></returns>
		public YCLData GetYCLByPKID(int PKID)
		{
			return new YCLs().GetYCLByPKID(PKID);
		}
		/// <summary>
		/// �������ϱ�ź�ʱ�䷶Χ��ȡԭ�����շ���¼.
		/// </summary>
		/// <param name="itemCode">���ϱ��</param>
		/// <param name="startDate">��ʼ����</param>
		/// <param name="endDate">����</param>
		/// <returns>YCLDataʵ��.</returns>
		public YCLData GetYCLByItemAndDate(string itemCode,DateTime startDate,DateTime endDate)
		{
			return new YCLs().GetYCLByItemAndDate(itemCode,startDate,endDate);
		}
		/// <summary>
		/// ����ԭ�����շ���¼.
		/// </summary>
		/// <param name="oYCLData">ԭ�����շ���¼.</param>
		/// <returns>bool</returns>
		public bool AddYCL(YCLData oYCLData)
		{
			return new YCLs().Add(oYCLData);
		}
		/// <summary>
		/// �޸�ԭ�����շ���¼.
		/// </summary>
		/// <param name="oYCLData">ԭ�����շ���¼.</param>
		/// <returns>bool</returns>
		public bool UpdateYCL(YCLData oYCLData)
		{
			return new YCLs().Update(oYCLData);
		}
		/// <summary>
		/// ɾ��ԭ�����շ���¼.
		/// </summary>
		/// <param name="PKID">����ֵ</param>
		/// <returns>bool</returns>
		public bool DeleteYCL(int PKID)
		{
			return new YCLs().Delete(PKID);
		}
		#endregion

		#region IWTOWSystem ��Ա

		/// <summary>
		/// ����ί��ӹ����뵥������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="Operation">string:	�������롣</param>
		/// <returns>bool:	����ǰ����������true,�����Ϸ���false.</returns>
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
		/// ί��ӹ����뵥�ܷ���
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥����ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
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

		#region IWINWSystem ��Ա
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
		/// ��ȡ������ϸ���ݡ�
		/// </summary>
		/// <param name="ClassifyName">string:	��;���ࡣ</param>
		/// <param name="ReqReason">string:	��;��</param>
		/// <param name="AuthorDeptName">string:	�Ƶ����š�</param>
		/// <param name="StartDate">DateTime:	��ʼ���ڡ�</param>
		/// <param name="EndDate">DateTime:	�������ڡ�</param>
		/// <returns>WithDrawDetailData:	������ϸ����ʵ�塣</returns>
		public WithDrawDetailData Get_WithDrawDetail(string ClassifyName, string ReqReason, string AuthorDeptName,DateTime StartDate, DateTime EndDate)
		{
			Analysis oA = new Analysis();
			WithDrawDetailData oData;
			oData = oA.Get_WithDrawDetail(ClassifyName, ReqReason, AuthorDeptName, StartDate,EndDate);
			this._Message = oA.Message;

			return oData;
		}
		/// <summary>
		/// ��ȡ�깺��ϸ��
		/// </summary>
		/// <param name="ClassifyName">string:	��;���ࡣ</param>
		/// <param name="ReqReason">string:	��;��</param>
		/// <param name="AuthorDeptName">string:	���š�</param>
		/// <param name="StartDate">DateTime:	��ʼ���ڡ�</param>
		/// <param name="EndDate">DateTime:	�������ڡ�</param>
		/// <returns>ROSDetailsData: �깺��ϸʵ�塣</returns>
		public ROSDetailsData Get_ROSDetails(string ClassifyName, string ReqReason, string AuthorDeptName,DateTime StartDate, DateTime EndDate,int Flag)
		{
			Analysis oA = new Analysis();
			ROSDetailsData oData;
			oData = oA.Get_ROSDetails(ClassifyName,ReqReason,AuthorDeptName,StartDate,EndDate,Flag);
			this._Message = oA.Message;
			return oData;
		}
		#endregion

		#region IWITRSystem ��Ա

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
		/// ����������ת�ɹ����󵥡�
		/// </summary>
		/// <param name="oData">���������뵥��</param>
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
		/// ����������ת�¶ȼƻ����󵥡�
		/// </summary>
		/// <param name="oData">���������뵥��</param>
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

		#region IProjectSystem ��Ա
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

		#region IRealDrawItem ��Ա
		/// <summary>
		/// ������Ŀ��Ż�ȡ��Ŀ��ص����ϼ�¼.
		/// </summary>
		/// <param name="projectCode">string:	��Ŀ���.</param>
		/// <returns>��Ŀ������ϼ���.</returns>
		public RealDrawItemData GetByProjectCode(string projectCode)
		{
			return new RealDrawItems().GetByProjectCode(projectCode);
		}

		#endregion
	}
}
