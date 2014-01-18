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
	/// Category ��ժҪ˵����
	/// </summary>
	public class Item:Messages
	{
		private const string DEF_STR="#";
		private const int DEF_INT=-1;

		/// <summary>
		/// ��������������
		/// </summary>
		/// <param name="oItemData">����������ʵ��</param>
		/// <returns>true or false</returns>
		public bool Insert(ItemData oItemData)
		{
			bool isValid=true;

			DataRow aRow=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0];

			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
			isValid = InputCheck.IsValidField(aRow, ItemData.CODE_FIELD, ItemData.CODE_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
		    isValid =
		        InputCheck.IsValidField(aRow, ItemData.NEWCODE_FIELD, ItemData.NEWCODE_LABEL, false,
		                                InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;
			isValid = InputCheck.IsValidField(aRow, ItemData.CNNAME_FIELD, ItemData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 50) && isValid;

			//����Ϊ�յ������ж�
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
				//�жϱ����Ƿ��Ѿ�����
				if (IsExistItemCode(aRow[ItemData.CODE_FIELD].ToString()))
				{
					this.Message=ItemData.CODE_NOT_UNIQUE;
					isValid=false;
				}
				if (this.IsExistItemWithNameAndSpec(aRow[ItemData.CODE_FIELD].ToString(),
					aRow[ItemData.CNNAME_FIELD].ToString(),
					aRow[ItemData.SPECIAL_FIELD].ToString()))
				{
					this.Message = "�������ƺ͹���ͺŲ������ظ��ļ�¼��";
					isValid = false;
				}
			}
			else
			{
				this.Message=InputCheck.ErrorInfo;
			}
			//�жϷ����Ƿ�Ϊ���ˡ�
			if (isValid)
			{
				if ( aRow[ItemData.CATCODE_FIELD].ToString() == "-1")
				{
					this.Message = "����ָ�����࣡";
					isValid = false;
				}
			}
			//�ж�ȱʡ�ֿ��Ƿ�Ϊ�ա�
			if (isValid)
			{
				if (aRow[ItemData.DEFSTO_FIELD].ToString() == "-1")
				{
					this.Message = "����ָ��ȱʡ�ֿ⣡";
					isValid = false;
				}
			}
			//�жϼ�����λ�Ƿ�Ϊ�ա�
			if (isValid)
			{
				if (aRow[ItemData.UNITCODE_FIELD].ToString() == "-1")
				{
					this.Message = "����ָ��������λ��";
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
		/// �������������ݣ���Ҫ�����ơ���Ŀ
		/// </summary>
		/// <param name="oItemData">����������ʵ��</param>
		/// <returns>true or false</returns>
		public bool Update(ItemData oItemData)
		{
			bool isValid=true;

			DataRow aRow=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0];

			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
			isValid = InputCheck.IsValidField(aRow, ItemData.CNNAME_FIELD, ItemData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 30) && isValid;

			//����Ϊ�յ������ж�
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
					this.Message = "�������ƺ͹���ͺŲ������ظ��ļ�¼��";
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

			return (new Items()).DeleteItemsByCodes(CanDelete);
			
		}

		//��ÿһ��Code�����жϣ��Ƿ��Ѿ����ڹ���������������
		private string DoWithDeleteCode(string Code,string CanNotDelte)
		{
			return Code;
		}

		/// <summary>
		/// �õ�����������
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public ItemData GetItemByCode(string Code)
		{
			return (new Items()).ComplexQueryItems(Code,DEF_STR,DEF_STR,DEF_INT,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,-1);
		}	//End GetItemByCode

		/// <summary>
		/// �ж������������Ƿ��Ѿ�����
		/// </summary>
		/// <param name="Code">���������ݱ��</param>
		/// <returns>���ڻ򲻴���</returns>
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
		/// �Ƿ����ͬ������ͬ����ͺŵ����ϡ�
		/// </summary>
		/// <param name="ItemName">string:	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
		/// <returns>bool:	�����ظ�����true�����ظ�����false��</returns>
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
		/// �������ѡ������
		/// </summary>
		/// <param name="Code"></param>
		/// <returns>����������ʵ��</returns>
		public ItemData GetItemsByCatCode(int Code)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,DEF_STR,Code,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}
		/// <summary>
		/// ���ݱ��ѡ������
		/// </summary>
		/// <param name="Code"></param>
		/// <returns>����������ʵ��</returns>
		public ItemData GetItemsByCode(string Code)
		{
			return (new Items()).ComplexQueryItems(Code,DEF_STR,DEF_STR,DEF_INT,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}
        public ItemData GetItemsByNewCode(string newCode)
        {
            return (new Items()).ComplexQueryItems(DEF_STR, newCode, DEF_STR, DEF_INT, DEF_STR, DEF_STR, DEF_STR, DEF_STR, DEF_STR, DEF_STR, DEF_STR, DEF_INT);
        }
		/// <summary>
		/// ������������ģ������������Ϣ��
		/// </summary>
		/// <param name="Name">string:	�������ơ�</param>
		/// <returns>ItemData:	��������ʵ�塣</returns>
		public ItemData GetItemsByName(string Name)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,Name,DEF_INT,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}
		/// <summary>
		/// �����������Ƶ�ƴ������ĸ���������ϵĲ�ѯ��
		/// </summary>
		/// <param name="PYZM">string:	ƴ������</param>
		/// <returns>ItemData:	����������ʵ��.</returns>
		public ItemData GetItemsByPY(string PY)
		{
			return new Items().GetItemByPY(PY);
		}
		/// <summary>
		/// ���ݹ���ͺ�ģ������������Ϣ��
		/// </summary>
		/// <param name="Spec">string:	�������ơ�</param>
		/// <returns>ItemData:	��������ʵ�塣</returns>
		public ItemData GetItemsBySpec(string Spec)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,DEF_STR,DEF_INT,Spec,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}
		/// <summary>
		/// �������ϱ�š��������ơ�����ͺŽ���ģ������������Ϣ��
		/// </summary>
		/// <param name="QueryContent">string:	ģ���������ݡ�</param>
		/// <returns>ItemData:	��������ʵ�塣</returns>
		public ItemData GetItemsByCodeAndNameAndSpec(string QueryContent)
		{
			return (new Items()).ComplexQueryItems(QueryContent,DEF_STR,QueryContent,DEF_INT,QueryContent,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}

		/// <summary>
		/// �õ�һ��������Items
		/// </summary>
		/// <param name="Count"></param>
		/// <returns></returns>
		public ItemData GetItemsNums(int Count)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,DEF_STR,DEF_INT,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,DEF_STR,Count);
		}
		/// <summary>
		/// ���ݲ�ѯ������ý����
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
        /// �����������ƺ͹�����Ͳ�ѯ������ý����
        /// </summary>
        /// <param name="ItemName">��������</param>
        /// <param name="ItemSpec">�������</param>
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
		/// ����ABC�õ������б�
		/// </summary>
		/// <param name="ABC">ABC���෽��</param>
		/// <returns>����������ʵ��</returns>
		public ItemData GetItemsByABC(string ABC)
		{
			return (new Items()).ComplexQueryItems(DEF_STR,DEF_STR,DEF_STR,DEF_INT,DEF_STR,DEF_STR,DEF_STR,ABC,DEF_STR,DEF_STR,DEF_STR,DEF_INT);
		}

	}		//End class
}	//End namespace

