using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.Security;

namespace Shmzh.Components.SystemComponent
{
	/// <summary>
	/// SettingInfoDA ��ժҪ˵����
	/// </summary>
	public class SettingInfoDA
	{
        /// <summary>
        /// ϵͳ������Ϣ��
        /// </summary>
		public SettingInfoDA()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// �õ�key���Ե�value
		/// </summary>
		/// <returns>�Ƿ����ӳɹ�</returns>
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
