namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	/// <summary>
	/// IProjectSystem 的摘要说明。
	/// </summary>
	public interface IProjectSystem
	{
		ProjectItemData GetProjectItemByPrjCode(string PrjCode);
	}
}
