#region 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved

#region 文档信息
/******************************************************************************
**		文件: 
**		名称: 
**		描述: 
**
**              
**		作者: 张豪
**		日期: 
*******************************************************************************
**		修改历史
*******************************************************************************
**		日期:		作者:		描述:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion 文档信息

using System;
using System.IO;
using System.IO.Compression;

namespace Shmzh.Components.Util
{
    using System.Text;
	using System.Text.RegularExpressions;
    using System.Drawing;
	/// <summary>
	/// StringUtil 的摘要说明。
	/// </summary>
	public class StringUtil
	{
		#region 成员变量
		
		#endregion

		#region 属性
		//
		//
		//
		#endregion
		
		#region 私有方法
		//
		//
		//
		#endregion

		#region 公开方法
		/// <summary>
		/// 截取指定长度中英文字符串方法。
		/// 在做网站时，显示新闻标题最非常有用，
		/// 为了保持页面的格局，对标题进行限定长度，
		/// 这就需要对中文进行双字符计算
		/// </summary>
		/// <param name="stringToSub">string:	指定字符串。</param>
		/// <param name="length">int:	指定长度。</param>
		/// <returns>string:	截取后的字符串。</returns>
		public static string TopNString(string stringToSub, int length) 
		{
			var regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
			var stringChar = stringToSub.ToCharArray();
			var sb = new StringBuilder();
			var nLength = 0;
			var isCut=false;

			for(var i = 0; i < stringChar.Length; i++) 
			{
				if (regex.IsMatch((stringChar[i]).ToString())) 
				{
					sb.Append(stringChar[i]);
					nLength += 2;
				}
				else 
				{
					sb.Append(stringChar[i]);
					nLength = nLength + 1;
				}

				if (nLength > length)
				{
					isCut=true;
					break;
				}
			}
		    return isCut ? sb + ".." : sb.ToString();
		}
        /// <summary>
        /// 将逗号分隔的字符串的各个子字符串都用单引号包裹，然后返回。
        /// 如果已经有单引号的则不处理。
        /// </summary>
        /// <param name="commaStrings">以逗号分隔的字符串。</param>
        /// <returns>单引号包裹后的新的字符串。</returns>
        public static string WrapSingleQuotes(string commaStrings)
        {
            var wrappedString = string.Empty;
            var ss = commaStrings.Split(',');
            foreach (var s in ss)
            {
                wrappedString += string.IsNullOrEmpty(wrappedString) ? (s.Contains("'") ? s : string.Format("'{0}'", s)) : ("," + (s.Contains("'") ? s : string.Format("'{0}'", s)));
            }
            return wrappedString;
        }

        /// <summary>
        /// 将字符串所表示的(A,R,G,B)型的颜色转换为Color对象，如果A未设置则默认为255。
        /// </summary>
        /// <param name="colorString">如:"255,255,255"或者"255,100,100,100"</param>
        /// <param name="defaultColor">转换失败时的默认颜色。</param>
        /// <returns></returns>
        public static Color StringToColor(String colorString, Color defaultColor)
        {
            if (String.IsNullOrEmpty(colorString))
            {
                return defaultColor;
            }
            String[] array = colorString.Split(',');
            try
            {
                if (array.Length == 4)
                {
                    return Color.FromArgb(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2]), Convert.ToInt32(array[3]));
                }
                return Color.FromArgb(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2]));
            }
            catch (Exception)
            {
                return defaultColor;
            }
            
        }
        /// <summary>
        /// SQL字符串拼接的时候用来过滤关键字。
        /// </summary>
        /// <param name="inputString">需要过滤的字符串。</param>
        /// <returns>过滤以后的字符串。</returns>
        public static string DeleteKeyWord(string inputString)
        {
            inputString = inputString.Trim();
            inputString = inputString.Replace("'", "");
            inputString = inputString.Replace(">", "");
            inputString = inputString.Replace("<", "");
            inputString = inputString.Replace("=", "");
            inputString = inputString.Replace("!", "");
            inputString = inputString.Replace("+", "");
            //inputString = inputString.Replace("/", "");
            //inputString = inputString.Replace("(", "");
            //inputString = inputString.Replace(")", "");
            //inputString = inputString.Replace("|", "");
            inputString = inputString.Replace("exec", "");
            inputString = inputString.Replace("xp_", "");
            inputString = inputString.Replace("sp_", "");
            inputString = inputString.Replace("declare", "");
            inputString = inputString.Replace("cmd", "");
            inputString = inputString.Replace("Union", "");
            inputString = inputString.Replace("//", "");
            inputString = inputString.Replace("..", "");
            inputString = inputString.Replace("Ox", "");
            inputString = inputString.Replace("--", "");
            //inputString = inputString.Replace(";", "");
            //inputString = inputString.Replace("\"", "");
            inputString = inputString.Replace("or", "");
            inputString = inputString.Replace("&", "");
            inputString = inputString.Replace("*", "");
            inputString = inputString.Replace("select", "");
            inputString = inputString.Replace("insert", "");
            inputString = inputString.Replace("delete", "");
            inputString = inputString.Replace("count", "");
            inputString = inputString.Replace("drop table", "");
            inputString = inputString.Replace("update", "");
            inputString = inputString.Replace("truncate", "");
            inputString = inputString.Replace("asc", "");
            inputString = inputString.Replace("mid", "");
            inputString = inputString.Replace("char", "");
            inputString = inputString.Replace("xp_cmdshell", "");
            inputString = inputString.Replace("master", "");
            inputString = inputString.Replace("net", "");
            inputString = inputString.Replace("localgroup", "");
            inputString = inputString.Replace("administrators", "");
            inputString = inputString.Replace("and", "");
            inputString = inputString.Replace("user", "");
            return inputString;
        }

        /// <summary>
        /// 判断输入的纯日期字符串是否是日期。
        /// </summary>
        /// <param name="dateStr">纯日期字符串。</param>
        /// <returns>bool</returns>
        public static bool IsDate(string dateStr)
        {
            var matchStr = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$ ";

            var option = (RegexOptions.IgnoreCase | (RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace));

            return Regex.IsMatch(dateStr, matchStr, option);
        }
        /// <summary>
        /// 判断输入的纯时间部分字符串是否是时间。
        /// </summary>
        /// <param name="timeStr">纯时间格式字符串。</param>
        /// <returns>bool</returns>
        public static bool IsTime(string timeStr)
        {
            return Regex.IsMatch(timeStr, @"^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$"); 
        }
        /// <summary>
        /// 判断输入的日期时间字符串是否是日期时间。
        /// </summary>
        /// <param name="dateTimeStr">日期时间字符串。</param>
        /// <returns>bool</returns>
        public static bool IsDateTime(string dateTimeStr)
        {
            var matchStr = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) ";
            matchStr += @"(\s((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?))$ ";

            var option = (RegexOptions.IgnoreCase | (RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace));

            return Regex.IsMatch(dateTimeStr, matchStr, option);
        }

        /// <summary>
        /// 判断字符串是否是数字型(可带小数)
        /// </summary>
        /// <param name="str">字符串。</param>
        /// <returns>bool</returns>
        public static bool IsNumeric(string str)
        {
            var rex = new Regex(@"^\d+(\.\d)?$");
            return rex.IsMatch( str );
        }
        /// <summary>
        /// 压缩字符串。
        /// </summary>
        /// <param name="tozipstr"></param>
        /// <returns></returns>
        public static string Zip(string tozipstr)
        {
            var mStream = new MemoryStream();
            var gStream = new GZipStream(mStream, CompressionMode.Compress);

            var bw = new BinaryWriter(gStream);
            bw.Write(Encoding.UTF8.GetBytes(tozipstr));
            bw.Close();

            gStream.Close();
            var outs = Convert.ToBase64String(mStream.ToArray());
            mStream.Close();
            return outs;
        }
        /// <summary>
        /// 解压字符串。
        /// </summary>
        /// <param name="zipedstr"></param>
        /// <returns></returns>
        public static string UnZip(string zipedstr)
        {
            var data = Convert.FromBase64String(zipedstr);
            var mStream = new MemoryStream(data);
            var gStream = new GZipStream(mStream, CompressionMode.Decompress);
            var streamR = new StreamReader(gStream);
            var outs = streamR.ReadToEnd();
            mStream.Close();
            gStream.Close();
            streamR.Close();
            return outs;
        }
        /// <summary>
        /// 去除Html字符串中的Script脚本段。
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>去除script段之后的字符串</returns>
        public static string StripScript(string source)
        {
            return Regex.Replace(source, @"<script[^>]*?>.*?</script>", "",RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// 去除所有Html标签和脚本段的字符串函数。
        /// </summary>
        /// <param name="htmlString">源字符串</param>
        /// <returns>结果字符串</returns>
        public static string StripHtml(string htmlString)
        {
            //删除脚本
            htmlString = Regex.Replace(htmlString, @"<script[^>]*?>.*?</script>", "",RegexOptions.IgnoreCase);
            //删除HTML
            htmlString = Regex.Replace(htmlString, @"<(.[^>]*)>", "",RegexOptions.IgnoreCase);

            htmlString = Regex.Replace(htmlString, @"([\r\n])[\s]+", "",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"-->", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"<!--.*", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(quot|#34);", "\"",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(amp|#38);", "&",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(lt|#60);", "<",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(gt|#62);", ">",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(nbsp|#160);", "   ",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(iexcl|#161);", "\xa1",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(cent|#162);", "\xa2",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(pound|#163);", "\xa3",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(copy|#169);", "\xa9",RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&#(\d+);", "",RegexOptions.IgnoreCase);
            htmlString = htmlString.Replace("<", "");
            htmlString = htmlString.Replace(">", "");
            htmlString = htmlString.Replace("\r\n", "");
            
            //var htmlEncode = HttpContext.Current.Server.HtmlEncode(htmlString);
            //if (htmlEncode != null) htmlString = htmlEncode.Trim();

            return htmlString;
        }
	    #endregion

		#region 构造函数
		/// <summary>
		/// 空构造函数。
		/// </summary>
		public StringUtil()
		{
			//
			// 
			//
		}
		#endregion
	}
}
