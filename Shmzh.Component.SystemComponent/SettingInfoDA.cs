using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.Security;

namespace Shmzh.Components.SystemComponent
{
	/// <summary>
	/// SettingInfoDA 的摘要说明。
	/// </summary>
	public class SettingInfoDA
	{
        /// <summary>
        /// 系统配置信息。
        /// </summary>
		public SettingInfoDA()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 得到key所对的value
		/// </summary>
		/// <returns>是否增加成功</returns>
		public string  GetKeyValue(string strkey)
		{
			//bool ret=true;

			try
			{
				string strSQL="select  [Value] from SettingInfo where SettingKey ='"+strkey.Replace("'","''")+"'";

				DataTable dt = SqlHelper.ExecuteDataset(ConnectionString.PubData  ,CommandType.Text,strSQL).Tables[0];

				if(dt.Rows.Count >= 1)
				{
					return dt.Rows[0][0].ToString();
				}
				else
				{
					return "";
				}

			}
			catch
			{
				return "";;
			}
		}
	}
}
