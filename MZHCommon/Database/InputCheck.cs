using System;
using System.Data;

namespace MZHCommon.Input
{
	/// <summary>
	/// InputCheck 的摘要说明。
	/// </summary>
	public class  InputCheck
	{
		public static string ErrorInfo;

	
		[SerializableAttribute]
			public enum Enum_Input_Format
		{
			/// <summary>
			///     字符
			/// </summary>
			Format_Char = 1,
			/// <summary>
			///     整数.
			/// </summary>
			Format_Int = 2,
			/// <summary>
			///     实数
			/// </summary>
			Format_Float = 3,
			/// <summary>
			///     日期
			/// </summary>
			Format_Date = 4,
			/// <summary>
			///     布尔
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
		/// 检测一行数据DataRow,格式是否正确
		/// </summary>
		/// <param name="aRow">要检测的行</param>
		/// <param name="FieldName">字段名</param>
		/// <param name="FieldLabel">字段标题</param>
		/// <param name="MustInput">是否必须输入</param>
		/// <param name="InputFormat">输入格式</param>
		/// <param name="MaxLen">最大长度</param>
		/// <returns>真假，错误信息放置在RowError最大长度中</returns>
		public static bool IsValidField(DataRow aRow,string FieldName,string FieldLabel,bool MustInput,Enum_Input_Format InputFormat, int MaxLen)
		{
			bool ret=true;

			if (MustInput==true)
			{
				//先判断字段为空的情况
				if (aRow[FieldName]==System.DBNull.Value)
				{
					ErrorInfo = aRow.RowError + "[" + FieldLabel + "] 必须输入数据。";
					ret=false;
				}

				//再判断字段为''的情况
				if (ret && (aRow[FieldName].ToString().Trim().Length==0))
				{
					ErrorInfo = aRow.RowError + "[" + FieldLabel + "] 必须输入数据。";
					ret=false;
				}

			}

			//对于有输入的信息进行判断。再判断字段有数据的情况
			if ((ret)&&(aRow[FieldName]!=System.DBNull.Value))
			{
				switch(InputFormat)
				{
					case Enum_Input_Format.Format_Char:
						if (MaxLen!=-1 && aRow[FieldName].ToString().Length>MaxLen)
						{
							ErrorInfo = aRow.RowError + "[" + FieldLabel + "] 数据长度超过" + MaxLen + "，无法保存。";
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
							ErrorInfo = ex.Message + "[" + FieldLabel + "] 输入格式有误，必须输入整数。";
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
								ErrorInfo =  "[" + FieldLabel + "] 输入数值太大(应小于32767)";
								ret=false;
							}
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] 输入格式有误，必须输入整数。";
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
								ErrorInfo =  "[" + FieldLabel + "] 输入数值太大(应小于"+System.Int64.MaxValue+")";
								ret=false;
							}
						}
						catch(Exception ex)
						{
							ErrorInfo = ex.Message + "[" + FieldLabel + "] 输入格式有误，必须输入整数。";
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
							ErrorInfo = ex.Message + "[" + FieldLabel + "] 输入格式有误，必须输入实数。。";
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
							ErrorInfo = ex.Message + "[" + FieldLabel + "] 输入格式有误，必须输入时间。";
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
							ErrorInfo = ex.Message + "[" + FieldLabel + "] 输入格式有误，必须输入布尔型数据。";
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
							ErrorInfo = ex.Message + "[" + FieldLabel + "] 输入格式有误，必须输入二进制数据。";
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
		/// 检测某个变量数据格式是否正确
		/// </summary>
		/// <param name="aValue">变量值</param>
		/// <param name="aLabel">变量名</param>
		/// <param name="MustInput">是否必须输入</param>
		/// <param name="MaxLen">输入格式</param>
		/// <returns></returns>
		public static bool IsValidVar(string aValue,string aLabel,bool MustInput,Enum_Input_Format InputFormat,int MaxLen)
		{
			bool ret=true;

            //先判断为空的情况
			if (MustInput)
			{
				if (aValue=="")
				{
					ErrorInfo="[" + aLabel + "] 必须输入数据。";
					ret=false;
				}
			}
			//再判断字段有数据的情况
			if (ret)
			{
				switch(InputFormat)
				{
					case Enum_Input_Format.Format_Char:
						if (MaxLen!=-1 && aValue.Length>MaxLen)
						{
							ErrorInfo =  "[" + aLabel + "] 数据长度超过" + MaxLen + "，无法保存。";
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
							ErrorInfo = ex.Message + "[" + aLabel + "] 输入格式有误，必须输入整数。";
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
							ErrorInfo = ex.Message + "[" + aLabel + "] 输入格式有误，必须输入整数。";
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
							ErrorInfo = ex.Message + "[" + aLabel + "] 输入格式有误，必须输入整数。";
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
							ErrorInfo = ex.Message + "[" + aLabel + "] 输入格式有误，必须输入实数。。";
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
							ErrorInfo = ex.Message + "[" + aLabel + "] 输入格式有误，必须输入时间。";
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
							ErrorInfo = ex.Message + "[" + aLabel + "] 输入格式有误，必须输入布尔型数据。";
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
							ErrorInfo = ex.Message + "[" + FieldLabel + "] 输入格式有误，必须输入二进制数据。";
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
		/// 过滤字段的空值
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
		/// 把DATETIME字段后面的时间截掉
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
		/// 把DATETIME字段前面的日期截掉
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

