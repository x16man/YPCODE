using System;
using System.ComponentModel;
using Shmzh.Web.UI.Controls;
namespace Shmzh.Web.UI.Designer
{
	/// <summary>
	/// �ṩToolbarItem�����ʱ֧�֡�
	/// </summary>
	public class ToolbarItemCollectionEditor : System.ComponentModel.Design.CollectionEditor
	{
		/// <summary>
		/// �չ��캯����
		/// </summary>
		/// <param name="type"></param>
		public ToolbarItemCollectionEditor(Type type) : base(type)
		{ }
		/// <summary>
		/// Provides a list of available item types.
		/// �ṩһ����Ч��ToolbarItem�����б�
		/// </summary>
		/// <returns> <see cref="ToolbarItem"/> ������б�.</returns>
		protected override Type[] CreateNewItemTypes()
		{
			return new Type[]
			{
				//typeof(ToolbarLink),
				typeof(ToolbarButton),
				typeof(ToolbarDropdownList),
				typeof(ToolbarTextBox),
				typeof(ToolbarCalendar),
				typeof(ToolbarLabel),
				typeof(ToolbarSeparator),
				typeof(ToolbarCheckBox)
			};
		}


	}
}
