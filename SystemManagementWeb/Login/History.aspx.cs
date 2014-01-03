using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.Login
{
    public partial class History : BasePage
    {
        #region Property
        public byte QueryMode
        {
            get { return (byte) ViewState["QueryMode"]; }
            set { ViewState["QueryMode"] = value;} 
        }
        #endregion

        #region private method
        private void myDataBind()
        {
            switch (this.QueryMode)
            {
                case 1:
                    this.BindData();
                    break;
                case 2:
                    this.BindSearch();
                    break;
            }
        }
        /// <summary>
        /// 数据绑定。
        /// </summary>
        private void BindData()
        {
            var objs = CurrentUser.HasRight(RightEnum.LogViewAll) ? DataProvider.HistoryProvider.GetAllByDateTime(DateTime.Today, DateTime.Today.AddDays(1)) : DataProvider.HistoryProvider.GetByUserAndDateTime(CurrentUser.LoginName, DateTime.Today,
                                                                                                                                                                                                             DateTime.Today.AddDays(1));
            this.dg_History.DataSource = objs;
            this.dg_History.DataBind();
        }
        private void BindSearch()
        {
            DateTime beginDate = DateTime.MinValue, endDate = DateTime.MaxValue;
            if(!string.IsNullOrEmpty(this.ToolbarCalendar_BeginDate.Text))
            {
                beginDate = DateTime.Parse(this.ToolbarCalendar_BeginDate.Text);
            }
            if(!string.IsNullOrEmpty(this.ToolbarCalendar_EndDate.Text))
            {
                endDate = DateTime.Parse(this.ToolbarCalendar_EndDate.Text);
                if (endDate <= beginDate )
                    endDate = beginDate.AddDays(1);
                else
                {
                    endDate = endDate.AddDays(1);
                }
            }
            if(beginDate == DateTime.MinValue && endDate == DateTime.MaxValue)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"needQueryCondition","alert('请指定查询的日期范围！')",true);
                return;
            }

            var objs = CurrentUser.HasRight(RightEnum.LogViewAll) ? DataProvider.HistoryProvider.GetAllByDateTime(beginDate, endDate) : DataProvider.HistoryProvider.GetByUserAndDateTime(CurrentUser.LoginName, beginDate,
                                                                                                                                                                                                             endDate);
            this.dg_History.DataSource = objs;
            this.dg_History.DataBind();
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.QueryMode = 1;
                this.ToolbarCalendar_BeginDate.Text = DateTime.Today.ToShortDateString();
                this.ToolbarCalendar_EndDate.Text = DateTime.Today.ToShortDateString();
                this.myDataBind();
            }
            this.dg_History.AutoDataBind = myDataBind;
        }

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch(item.ItemId.ToUpper())
            {
                case "QUERY":
                    this.QueryMode = 2;
                    break;
                case "PRE":
                    if(string.IsNullOrEmpty(this.ToolbarCalendar_BeginDate.Text))
                    {
                        this.ToolbarCalendar_BeginDate.Text = DateTime.Today.AddDays(-1).ToShortDateString();
                        this.ToolbarCalendar_EndDate.Text = DateTime.Today.AddDays(-1).ToShortDateString();
                    }

                    this.ToolbarCalendar_BeginDate.Text =
                        DateTime.Parse(this.ToolbarCalendar_BeginDate.Text).AddDays(-1).ToShortDateString();
                    this.ToolbarCalendar_EndDate.Text = this.ToolbarCalendar_BeginDate.Text;
                    this.QueryMode = 2;
                    break;
                case "NEXT":
                    if(string.IsNullOrEmpty(this.ToolbarCalendar_EndDate.Text))
                    {
                        this.ToolbarCalendar_BeginDate.Text = DateTime.Today.ToShortDateString();
                        this.ToolbarCalendar_EndDate.Text = DateTime.Today.ToShortDateString();
                    }
                    this.ToolbarCalendar_EndDate.Text =
                        DateTime.Parse(this.ToolbarCalendar_EndDate.Text).AddDays(1).ToShortDateString();
                    this.ToolbarCalendar_BeginDate.Text = this.ToolbarCalendar_EndDate.Text;
                    this.QueryMode = 2;
                    break;
            }
            this.myDataBind();
        }
        #endregion
    }
}
