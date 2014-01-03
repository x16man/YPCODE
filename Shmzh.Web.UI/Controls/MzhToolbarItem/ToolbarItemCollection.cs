using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

using Shmzh.Web.UI.Designer;

namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// Maintains a collection of <see cref="ToolbarItem"/>
	/// objects.
	/// </summary>
	[Editor(typeof(ToolbarItemCollectionEditor), typeof(UITypeEditor))]
	public class ToolbarItemCollection : CollectionBase,INamingContainer
    {
        #region delegate
        /// <summary>
		/// Raised if an item is was added.
		/// </summary>
		public event ItemEventHandler ItemAdded;

		/// <summary>
		/// Raised if an item was removed.
		/// </summary>
		public event ItemEventHandler ItemRemoved;

		/// <summary>
		/// Raised if the controls were removed.
		/// </summary>
		public event EventHandler ItemsCleared;
        #endregion

        #region Constructor
        /// <summary>
		/// 空构造函数。
		/// </summary>
		public ToolbarItemCollection()
		{
        }
        #endregion

        #region Event
        /// <summary>
		/// ToolbarItem移除完成事件。
		/// </summary>
		/// <param name="index">索引</param>
		/// <param name="value"></param>
		protected override void OnRemoveComplete(int index, object value)
		{
			if (ItemRemoved != null) ItemRemoved(value as ToolbarItem);

			base.OnRemoveComplete (index, value);
		}
		/// <summary>
		/// ToolbarItem插入完成事件。
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		protected override void OnInsertComplete(int index, object value)
		{
			if (ItemAdded != null) ItemAdded(value as ToolbarItem);

			base.OnInsertComplete (index, value);
		}
		/// <summary>
		/// ToolbarItemClear事件。
		/// </summary>
		protected override void OnClear()
		{
			if (ItemsCleared != null) ItemsCleared(this, null);
			base.OnClear ();
        }
        #endregion

        #region Property
        /// <summary>
		/// Gets a toolbar item by its unique
		/// item ID.
		/// </summary>
		public ToolbarItem this[string itemId]
		{
			get 
			{
				foreach (ToolbarItem item in this.List)
				{
					if (item.ItemId == itemId) return item;
				}

				return null;   
			}
        }
        #endregion

        #region Method
        /// <summary>
		/// Adds an item to the list.
		/// </summary>
		/// <param name="item"></param>
		public void Add(ToolbarItem item)
		{
			if (item.ItemId == String.Empty) item.ItemId = item.ID;
			this.List.Add(item);
		}
		/// <summary>
		/// Adds an item at a given position.
		/// </summary>
		/// <param name="index">Zero-based index of the item.</param>
		/// <param name="item">Item to be added.</param>
		public void Insert(int index, ToolbarItem item)
		{
			this.List.Insert(index, item);
		}
		/// <summary>
		/// Gets the index of a toolbar item.
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(ToolbarItem item)
		{
			return this.List.IndexOf(item);
		}
		/// <summary>
		/// 在ToolbarItemCollection中根据ToolbarItem的ID进行定位。
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public int IndexOf(string itemId)
		{
			var item = this[itemId];
			if (item == null)
			{
				return -1;
			}
		    return this.IndexOf(item);
		}
		/// <summary>
		/// Removes an item from the toolbar.
		/// </summary>
		/// <param name="itemId">The unique
		/// <see cref="ToolbarItem.ItemId"/> of the
		/// item.</param>
		public void RemoveItem(string itemId)
		{
			var item = this[itemId];
			if (item != null) this.List.Remove(item);
        }
        #endregion
    }
}
