using System.Collections;
using MZHCommon.Database;
using Shmzh.MM.Common;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// RealDrawItems 的摘要说明。
	/// </summary>
	public class RealDrawItems :Messages
	{
		#region 构造函数
		public RealDrawItems()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 方法
		/// <summary>
		/// 根据仓库号获得库存．
		/// </summary>
		/// <param name="StoCode">string:	仓库编号．</param>
		/// <returns>StockData:	库存数据实体．</returns>
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
