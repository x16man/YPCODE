using System;
using System.Data;

namespace MZHCommon.Input
{
	/// <summary>
	/// InputCheck ��ժҪ˵����
	/// </summary>
	public class  InputCheck
	{
		public static string ErrorInfo;

	
		[SerializableAttribute]
			public enum Enum_Input_Format
		{
			/// <summary>
			///     �ַ�
			/// </summary>
			Format_Char = 1,
			/// <summary>
			///     ����.
			/// </summary>
			Format_Int = 2,
			/// <summary>
			///     ʵ��
			/// </summary>
			Format_Float = 3,
			/// <summary>
			///     ����
			/// </summary>
			Format_Date = 4,
			/// <summary>
			///     ����
			/// </summary>
			Format_Bit = 5,

			Format_Int16=6,

			Format_Int64=7,

			Format_Bytes=8
		}

		public InputCheck()
		{
			//
			// 
			//
		}


		/// <summary>
		/// ���һ������DataRow,��ʽ�Ƿ���ȷ
		/// </summary>
		/// <param name="aRow">Ҫ������</param>
		/// <param name="FieldName">�ֶ���</param>
		/// <param name="FieldLabel">�ֶα���</param>
		/// <param name="MustInput">�Ƿ��������</param>
		/// <param name="InputFormat">�����ʽ</param>
		/// <param name="MaxLen">��󳤶�</param>
		/// <returns>��٣�������Ϣ������RowError��󳤶���</returns>
		public static bool IsValidField(DataRow aRow,string FieldName,string FieldLabel,bool MustInput,Enum_Input_Format InputFormat, int MaxLen)
		{
			bool ret=true;

			if (MustInput==true)
			{
				//���ж��ֶ�Ϊ�յ����
				if (aRow[FieldName]==System.DBNull.Value)
				{
					ErrorInfo = aRow.RowError + "[" + FieldLabel + "] �����������ݡ�";
					ret=false;
				}

				//���ж��ֶ�Ϊ''�����
				if (ret && (aRow[FieldName].ToString().Trim().Length==0))
				{
					ErrorInfo = aRow.RowError + "[" + FieldLabel + "] �����������ݡ�";
					ret=false;
				}

			}

			//�������������Ϣ�����жϡ����ж��ֶ������ݵ����
			if ((ret)&&(aRow[FieldName]!=System.DBNull.Value))
			{
				switch(InputFormat)
				{
					case Enum_Input_Format.Format_Char:
						if (MaxLen!=-1 && aRow[FieldName].ToString().Length>MaxLen)
						{
							ErrorInfo = aRow.RowError + "[" + FieldLabel + "] ���ݳ��ȳ���" + MaxLen + "���޷����档";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Int:
						try
						{
							int temp;
							temp=int.Parse((aRow[FieldName]).ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] �����ʽ���󣬱�������������";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Int16:
						try
						{
							Int16 temp;
							temp=Int16.Parse((aRow[FieldName]).ToString());
							if(temp>32767)
							{
								ErrorInfo =  "[" + FieldLabel + "] ������ֵ̫��(ӦС��32767)";
								ret=false;
							}
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] �����ʽ���󣬱�������������";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Int64:
						try
						{
							Int64 temp;
							temp=Int64.Parse((aRow[FieldName]).ToString());
							if(temp>System.Int64.MaxValue)
							{
								ErrorInfo =  "[" + FieldLabel + "] ������ֵ̫��(ӦС��"+System.Int64.MaxValue+")";
								ret=false;
							}
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] �����ʽ���󣬱�������������";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Float:
						try
						{
							Double temp;
							temp=double.Parse((aRow[FieldName]).ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] �����ʽ���󣬱�������ʵ������";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Date:
						try
						{
							DateTime temp;
							temp=DateTime.Parse((aRow[FieldName]).ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] �����ʽ���󣬱�������ʱ�䡣";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Bit:
						try
						{
							bool temp;
							temp=bool.Parse((aRow[FieldName]).ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] �����ʽ���󣬱������벼�������ݡ�";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Bytes:
						try
						{
							Byte[] temp;
							temp=(Byte[])aRow[FieldName];
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] �����ʽ���󣬱���������������ݡ�";
							ret=false;
						}
						break;
					default:
						break;
				}
			}
			return ret;
		}
		


		/// <summary>
		/// ���ĳ���������ݸ�ʽ�Ƿ���ȷ
		/// </summary>
		/// <param name="aValue">����ֵ</param>
		/// <param name="aLabel">������</param>
		/// <param name="MustInput">�Ƿ��������</param>
		/// <param name="MaxLen">�����ʽ</param>
		/// <returns></returns>
		public static bool IsValidVar(string aValue,string aLabel,bool MustInput,Enum_Input_Format InputFormat,int MaxLen)
		{
			bool ret=true;

            //���ж�Ϊ�յ����
			if (MustInput)
			{
				if (aValue=="")
				{
					ErrorInfo="[" + aLabel + "] �����������ݡ�";
					ret=false;
				}
			}
			//���ж��ֶ������ݵ����
			if (ret)
			{
				switch(InputFormat)
				{
					case Enum_Input_Format.Format_Char:
						if (MaxLen!=-1 && aValue.Length>MaxLen)
						{
							ErrorInfo =  "[" + aLabel + "] ���ݳ��ȳ���" + MaxLen + "���޷����档";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Int:
						try
						{
							int temp;
							temp=int.Parse(aValue.ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + aLabel + "] �����ʽ���󣬱�������������";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Int16:
						try
						{
							Int16 temp;
							temp=Int16.Parse(aValue.ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + aLabel + "] �����ʽ���󣬱�������������";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Int64:
						try
						{
							Int64 temp;
							temp=Int64.Parse(aValue.ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + aLabel + "] �����ʽ���󣬱�������������";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Float:
						try
						{
							Double temp;
							temp=double.Parse(aValue.ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + aLabel + "] �����ʽ���󣬱�������ʵ������";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Date:
						try
						{
							DateTime temp;
							temp=DateTime.Parse(aValue.ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + aLabel + "] �����ʽ���󣬱�������ʱ�䡣";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Bit:
						try
						{
							bool temp;
							temp=bool.Parse(aValue.ToString());
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + aLabel + "] �����ʽ���󣬱������벼�������ݡ�";
							ret=false;
						}
						break;
					case Enum_Input_Format.Format_Bytes:
						/*try
						{
							Byte[] temp;
							temp=(Byte[])aValue;
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] �����ʽ���󣬱���������������ݡ�";
							ret=false;
						}*/
						break;
					default:
						break;
				}
			}
			return ret;
		}
		
		/// <summary>
		/// �����ֶεĿ�ֵ
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static string FilterDBNull(Object item)
		{
			if (item==System.DBNull.Value)
			{
				return "";
			}
			else
			{
				return item.ToString();
			}
		}

		/// <summary>
		/// ��DATETIME�ֶκ����ʱ��ص�
		/// </summary>
		/// <param name="item"></param>
		/// <param name="format"> "yyyy-MM-dd"</param>
		/// <returns></returns>
		public static string ConvertDateField(Object item,string format)
		{
			if ((item==System.DBNull.Value) ||(item.ToString().Trim()==""))
			{
				return "";
			}
			else 
			{
			return DateTime.Parse(item.ToString()).ToString(format);
			}
		}

		/// <summary>
		/// ��DATETIME�ֶ�ǰ������ڽص�
		/// </summary>
		/// <param name="item"></param>
		/// <param name="format">"HH:mm:ss"</param>
		/// <returns></returns>
		public static string ConvertTimeField(Object item,string format)
		{
			if ((item==System.DBNull.Value) ||(item.ToString().Trim()==""))
			{
				return "";
			}
			else 
			{
				return DateTime.Parse(item.ToString()).ToString(format);
			}
		}

		public static string EffectiveSQLInput(string strInput)
		{
			return strInput.Replace(",","");
		}
	}
}

