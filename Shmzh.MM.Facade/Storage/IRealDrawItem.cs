namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	/// <summary>
	/// IRealDrawItem ��ժҪ˵����
	/// </summary>
	public interface IRealDrawItem
	{
		RealDrawItemData GetByProjectCode(string projectCode);
	}
}
