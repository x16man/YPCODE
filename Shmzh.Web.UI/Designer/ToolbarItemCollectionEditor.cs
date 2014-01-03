using System;
using System.ComponentModel;
using Shmzh.Web.UI.Controls;
namespace Shmzh.Web.UI.Designer
{
	/// <summary>
	/// 提供ToolbarItem的设计时支持。
	/// </summary>
	public class ToolbarItemCollectionEditor : System.ComponentModel.Design.CollectionEditor
	{
		/// <summary>
		/// 空构造函数。
		/// </summary>
		/// <param name="type"></param>
		public ToolbarItemCollectionEditor(Type type) : base(type)
		{ }
		/// <summary>
		/// Provides a list of available item types.
		/// 提供一个有效的ToolbarItem类型列表。
		/// </summary>
		/// <returns> <see cref="ToolbarItem"/> 对象的列表.</returns>
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
