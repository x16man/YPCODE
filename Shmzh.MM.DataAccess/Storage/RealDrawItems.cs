using System.Collections;
using MZHCommon.Database;
using Shmzh.MM.Common;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// RealDrawItems ��ժҪ˵����
	/// </summary>
	public class RealDrawItems :Messages
	{
		#region ���캯��
		public RealDrawItems()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region ����
		/// <summary>
		/// ���ݲֿ�Ż�ÿ�森
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��ţ�</param>
		/// <returns>StockData:	�������ʵ�壮</returns>
		public RealDrawItemData GetByProjectCode(string  projectCode)
		{
			RealDrawItemData oRealDrawItemData = new RealDrawItemData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PNo",projectCode);

			oSQLServer.ExecSPReturnDS("Project_GetRealItem",oHT,oRealDrawItemData.Tables[RealDrawItemData.RealItem_Table]);
			return oRealDrawItemData;
		}
		#endregion
	}
}
