using System;
using System.Drawing;
using System.Web.UI.Design;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI.WebControls;

using Shmzh.Web.UI.Controls;

namespace Shmzh.Web.UI.Designer
{
	/// <summary>
	/// ToolBar控件的设计时类。
	/// </summary>
    [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.Demand,
        Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
    public class ToolbarDesigner : ControlDesigner
	{
		/// <summary>
		/// 构造函数。
		/// </summary>
		public ToolbarDesigner():base()
		{
            
		}
		/// <summary>
		/// 获取设计时的HTML代码。
		/// </summary>
		/// <returns>设计时HTML字符串。</returns>
		public override string GetDesignTimeHtml()
		{
			MzhToolbar toolbar = this.Component as MzhToolbar;
			if (toolbar.Items.Count == 0)
			{
				return CreatePlaceHolderDesignTimeHtml("Add Toolbar Items...");
			}
			else
			{
				return base.GetDesignTimeHtml();
			}
		}

		/// <summary>
		/// 创建设计时HTML代码出错时返回出错信息。
		/// </summary>
		/// <param name="e">Exception</param>
		/// <returns>出错字符串。</returns>
		protected override string GetErrorDesignTimeHtml(Exception e)
		{
			string pattern = "Error while creating design time HTML:<br/>{0}";
			return String.Format(pattern, e.Message);
		}
        /// <summary>
        /// Create a custom ActionLists collection
        /// </summary>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // Create the collection
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                // Get the base items, if any
                actionLists.AddRange(base.ActionLists);

                // Add a custom list of actions
                actionLists.Add(new CustomControlActionList(this));

                return actionLists;
            }
        }
        /// <summary>
        ///  Create an embedded DesignerActionList class
        /// </summary>
        private class CustomControlActionList : DesignerActionList
        {
             // Create private fields
             private ToolbarDesigner _parent;
             private DesignerActionItemCollection items;

             // Constructor
             public CustomControlActionList(ToolbarDesigner parent)
                 : base(parent.Component)
             {
                 _parent = parent;
             }

             // Create a set of transacted callback methods
             // Callback for the wide format
             public void FormatWide()
             {
                 MzhToolbar ctrl = (MzhToolbar)_parent.Component;

                 // Create the callback
                 TransactedChangeCallback toCall = new TransactedChangeCallback(DoFormat);
                 // Create the transacted change in the control
                 ControlDesigner.InvokeTransactedChange(ctrl, toCall, "FormatWide", "Use a wide format");
             }

             // Callback for the medium format
             public void FormatMedium()
             {
                 MzhToolbar ctrl = (MzhToolbar)_parent.Component;

                 // Create the callback
                 TransactedChangeCallback toCall = new TransactedChangeCallback(DoFormat);
                 // Create the transacted change in the control
                 ControlDesigner.InvokeTransactedChange(ctrl, toCall, "FormatMedium", "Use a medium format");
             }

             // Callback for the narrow format
             public void FormatNarrow()
             {
                 MzhToolbar ctrl = (MzhToolbar)_parent.Component;

                 // Create the callback
                 TransactedChangeCallback toCall = new TransactedChangeCallback(DoFormat);
                 // Create the transacted change in the control
                 ControlDesigner.InvokeTransactedChange(ctrl, toCall, "FormatNarrow", "Use a narrow format");
             }

             // Get the sorted list of Action items
             public override DesignerActionItemCollection GetSortedActionItems()
             {
                 if (items == null)
                 {
                     // Create the collection
                     items = new DesignerActionItemCollection();

                     // Add a header to the list
                     items.Add(new DesignerActionHeaderItem("Select a Style:"));

                     // Add three commands
                     items.Add(new DesignerActionMethodItem(this, "FormatWide", "Format Wide", true));
                     items.Add(new DesignerActionMethodItem(this, "FormatMedium", "Format Medium", true));
                     items.Add(new DesignerActionMethodItem(this, "FormatNarrow", "Format Narrow", true));
                 }
                 return items;
             }

             // Function for the callbacks to call
             public bool DoFormat(object arg)
             {
                 // Get a reference to the designer's associated component
                 MzhToolbar ctl = (MzhToolbar)_parent.Component;

                 // Get the format name from the arg
                 string fmt = (string)arg;

                 // Create property descriptors
                 PropertyDescriptor widthProp = TypeDescriptor.GetProperties(ctl)["BoxWidth"];
                 PropertyDescriptor backColorProp = TypeDescriptor.GetProperties(ctl)["BackColor"];

                 // For the selected format, set two properties
                 switch (fmt)
                 {
                     case "FormatWide":
                         widthProp.SetValue(ctl, Unit.Pixel(250));
                         backColorProp.SetValue(ctl, Color.LightBlue);
                         break;
                     case "FormatNarrow":
                         widthProp.SetValue(ctl, Unit.Pixel(100));
                         backColorProp.SetValue(ctl, Color.LightCoral);
                         break;
                     case "FormatMedium":
                         widthProp.SetValue(ctl, Unit.Pixel(150));
                         backColorProp.SetValue(ctl, Color.White);
                         break;
                 }
                 _parent.UpdateDesignTimeHtml();

                 // Return an indication of success
                 return true;
             }
         }
	}
    

}
