using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.Web.UI.Controls
{
    /// <summary>
    /// 标题控件。
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:MzhTitle runat=server></{0}:MzhTitle>")]
    [Designer("Shmzh.Web.UI.Designer.MzhTitleDesigner")]
    public class MzhTitle :System.Web.UI.WebControls.WebControl
    {
        #region Property
        /// <summary>
        /// MzhTitle的文本。
        /// </summary>
        [Bindable(true),Localizable(true),Category("Appearance"),DefaultValue(""),]
        public string Text
        {
            get
            {
                var s = (string)ViewState["Text"];
                return (s ?? String.Empty);
            }
            set
            {
                ViewState["Text"] = value;
            }
        }
        /// <summary>
        /// 标题对应的系统配置中Key代码。
        /// </summary>
        [Bindable(true),Localizable(true),Category("Appearance"),DefaultValue(""),]
        public string Key
        {
            get
            {
                var s = (string)ViewState["MzhTitleKey"];
                return (s ?? String.Empty);
            }
            set
            {
                ViewState["MzhTitleKey"] = value;
            }
        }
        #endregion

        public MzhTitle()
        {
            
        }
        protected override void Render(HtmlTextWriter output)
        {
            if(string.IsNullOrEmpty(this.Text))
            {
                try
                {
                    if (string.IsNullOrEmpty(this.Page.Request["Title"]))
                    {
                        if (string.IsNullOrEmpty(this.Key))
                        {
                            //do nothing.
                        }
                        else
                        {
                            var obj = DataProvider.SettingProvider.GetByKey(this.Key);
                            if (obj != null)
                            {
                                this.Text = obj.Value;
                            }
                        }
                    }
                    else
                    {
                        this.Text = this.Page.Request["Title"];
                    }
                }
                catch
                {
                }
                

            }
            if(!string.IsNullOrEmpty(this.Text) && this.Visible)
            {
                if(string.IsNullOrEmpty(this.CssClass))
                    output.Write(string.Format("<h1 id=\"{0}\" class=\"mzhTitle\"><span>{1}</span></h1>", this.ID, this.Text));
                else
                {
                    output.Write(string.Format("<h1 id=\"{0}\" class=\"{1}\"><span>{2}</span></h1>", this.ID, this.CssClass, this.Text));
                }
                
            }

        }
    }
}
