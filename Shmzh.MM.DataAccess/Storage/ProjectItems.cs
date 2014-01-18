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
	/// ProjectItems ��ժҪ˵����
	/// </summary>
	public class ProjectItems : Messages
	{
		public ProjectItems()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ������Ŀ��Ż�ȡ��Ŀ��ʵ�����Ϸ��������
		/// </summary>
		/// <param name="Code">string:	��Ŀ��š�</param>
		/// <returns>ProjectItemData</returns>
		public ProjectItemData GetProjectItemByCode(string Code)
		{
			ProjectItemData myDS = new ProjectItemData ();

			SQLServer mySP = new SQLServer ();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PNo",Code);
			if (!mySP.ExecSPReturnDS("Project_GetRealItem", oHT,myDS.Tables [ProjectItemData.ProjectItem_Table]))
			{
				this.Message = "��ѯʧ�ܣ�";
			}
			return myDS;
		}
	}
}
