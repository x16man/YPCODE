namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// 提供postback功能的ToolbarItem的公共接口。
	/// </summary>
	public interface IPostBackToolbarItem
	{
        
		/// <summary>
		/// ToolbarItem提交时触发的事件。
		/// </summary>
		event ItemEventHandler ItemSubmitted;
	}
}
