#region ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved

#region �ĵ���Ϣ
/******************************************************************************
**		�ļ�: 
**		����: 
**		����: 
**
**              
**		����: �ź�
**		����: 
*******************************************************************************
**		�޸���ʷ
*******************************************************************************
**		����:		����:		����:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion �ĵ���Ϣ

using System;
using System.IO;
using System.IO.Compression;

namespace Shmzh.Components.Util
{
    using System.Text;
	using System.Text.RegularExpressions;
    using System.Drawing;
	/// <summary>
	/// StringUtil ��ժҪ˵����
	/// </summary>
	public class StringUtil
	{
		#region ��Ա����
		
		#endregion

		#region ����
		//
		//
		//
		#endregion
		
		#region ˽�з���
		//
		//
		//
		#endregion

		#region ��������
		/// <summary>
		/// ��ȡָ��������Ӣ���ַ���������
		/// ������վʱ����ʾ���ű�����ǳ����ã�
		/// Ϊ�˱���ҳ��ĸ�֣��Ա�������޶����ȣ�
		/// �����Ҫ�����Ľ���˫�ַ�����
		/// </summary>
		/// <param name="stringToSub">string:	ָ���ַ�����</param>
		/// <param name="length">int:	ָ�����ȡ�</param>
		/// <returns>string:	��ȡ����ַ�����</returns>
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
        /// �����ŷָ����ַ����ĸ������ַ������õ����Ű�����Ȼ�󷵻ء�
        /// ����Ѿ��е����ŵ��򲻴���
        /// </summary>
        /// <param name="commaStrings">�Զ��ŷָ����ַ�����</param>
        /// <returns>�����Ű�������µ��ַ�����</returns>
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
        /// ���ַ�������ʾ��(A,R,G,B)�͵���ɫת��ΪColor�������Aδ������Ĭ��Ϊ255��
        /// </summary>
        /// <param name="colorString">��:"255,255,255"����"255,100,100,100"</param>
        /// <param name="defaultColor">ת��ʧ��ʱ��Ĭ����ɫ��</param>
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
        /// SQL�ַ���ƴ�ӵ�ʱ���������˹ؼ��֡�
        /// </summary>
        /// <param name="inputString">��Ҫ���˵��ַ�����</param>
        /// <returns>�����Ժ���ַ�����</returns>
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
        /// �ж�����Ĵ������ַ����Ƿ������ڡ�
        /// </summary>
        /// <param name="dateStr">�������ַ�����</param>
        /// <returns>bool</returns>
        public static bool IsDate(string dateStr)
        {
            var matchStr = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$ ";

            var option = (RegexOptions.IgnoreCase | (RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace));

            return Regex.IsMatch(dateStr, matchStr, option);
        }
        /// <summary>
        /// �ж�����Ĵ�ʱ�䲿���ַ����Ƿ���ʱ�䡣
        /// </summary>
        /// <param name="timeStr">��ʱ���ʽ�ַ�����</param>
        /// <returns>bool</returns>
        public static bool IsTime(string timeStr)
        {
            return Regex.IsMatch(timeStr, @"^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$"); 
        }
        /// <summary>
        /// �ж����������ʱ���ַ����Ƿ�������ʱ�䡣
        /// </summary>
        /// <param name="dateTimeStr">����ʱ���ַ�����</param>
        /// <returns>bool</returns>
        public static bool IsDateTime(string dateTimeStr)
        {
            var matchStr = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) ";
            matchStr += @"(\s((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?))$ ";

            var option = (RegexOptions.IgnoreCase | (RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace));

            return Regex.IsMatch(dateTimeStr, matchStr, option);
        }

        /// <summary>
        /// �ж��ַ����Ƿ���������(�ɴ�С��)
        /// </summary>
        /// <param name="str">�ַ�����</param>
        /// <returns>bool</returns>
        public static bool IsNumeric(string str)
        {
            var rex = new Regex(@"^\d+(\.\d)?$");
            return rex.IsMatch( str );
        }
        /// <summary>
        /// ѹ���ַ�����
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
        /// ��ѹ�ַ�����
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
        /// ȥ��Html�ַ����е�Script�ű��Ρ�
        /// </summary>
        /// <param name="source">Դ�ַ���</param>
        /// <returns>ȥ��script��֮����ַ���</returns>
        public static string StripScript(string source)
        {
            return Regex.Replace(source, @"<script[^>]*?>.*?</script>", "",RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// ȥ������Html��ǩ�ͽű��ε��ַ���������
        /// </summary>
        /// <param name="htmlString">Դ�ַ���</param>
        /// <returns>����ַ���</returns>
        public static string StripHtml(string htmlString)
        {
            //ɾ���ű�
            htmlString = Regex.Replace(htmlString, @"<script[^>]*?>.*?</script>", "",RegexOptions.IgnoreCase);
            //ɾ��HTML
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

		#region ���캯��
		/// <summary>
		/// �չ��캯����
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
