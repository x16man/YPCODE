namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	/// <summary>
	/// IRealDrawItem 的摘要说明。
	/// </summary>
	public interface IRealDrawItem
	{
		RealDrawItemData GetByProjectCode(string projectCode);
	}
}
