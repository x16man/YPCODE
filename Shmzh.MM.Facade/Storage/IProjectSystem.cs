namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	/// <summary>
	/// IProjectSystem ��ժҪ˵����
	/// </summary>
	public interface IProjectSystem
	{
		ProjectItemData GetProjectItemByPrjCode(string PrjCode);
	}
}
