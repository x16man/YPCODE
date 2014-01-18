namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Data.SqlClient;
	using System.Configuration ;
	using Shmzh.MM.Common;
	using MZHCommon.Database;
	/// <summary>
	/// ProjectItems 的摘要说明。
	/// </summary>
	public class ProjectItems : Messages
	{
		public ProjectItems()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 根据项目编号获取项目的实际物料发生情况。
		/// </summary>
		/// <param name="Code">string:	项目编号。</param>
		/// <returns>ProjectItemData</returns>
		public ProjectItemData GetProjectItemByCode(string Code)
		{
			ProjectItemData myDS = new ProjectItemData ();

			SQLServer mySP = new SQLServer ();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PNo",Code);
			if (!mySP.ExecSPReturnDS("Project_GetRealItem", oHT,myDS.Tables [ProjectItemData.ProjectItem_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
	}
}
