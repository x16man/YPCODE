namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// �ṩpostback���ܵ�ToolbarItem�Ĺ����ӿڡ�
	/// </summary>
	public interface IPostBackToolbarItem
	{
        
		/// <summary>
		/// ToolbarItem�ύʱ�������¼���
		/// </summary>
		event ItemEventHandler ItemSubmitted;
	}
}
