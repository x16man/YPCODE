using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Shmzh.Web.UI.Controls
{
    [ToolboxData("<{0}:testDataGrid runat=server></{0}:testDataGrid>")]
    [ToolboxBitmap(typeof(testDataGrid), "Shmzh.Web.UI.MzhDataGrid.bmp")]
    [ParseChildren(true)]
    public class testDataGrid : DataGrid
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 存放当前选中行(单行)ID。
        /// </summary>
        protected HtmlInputHidden tbSelectedID;
        /// <summary>
        /// 存放当前选中行(多行)的ID串（ID1,ID2,ID3）。
        /// </summary>
        protected HtmlInputHidden tbSelectedArray;
        /// <summary>
        /// 存放当前选中行(多行)的ID串('ID1','ID2','ID3')。
        /// </summary>
        protected HtmlInputHidden tbSelectedStream;
        #region CTOR
        public testDataGrid()
        {

        }
        #endregion
        protected virtual void CreateControlHierarchy()
        {
            //Logger.Info("CreateControlHierarchy");
            tbSelectedID = new HtmlInputHidden { ID = "SelectedID" };
            tbSelectedArray = new HtmlInputHidden { ID = "SelectedArray" };
            tbSelectedStream = new HtmlInputHidden { ID = "SelectedStream" };
        }
        protected override void InitializePager(DataGridItem item, int columnSpan, PagedDataSource pagedDataSource)
        {
            base.InitializePager(item, columnSpan, pagedDataSource);
            if(item.Visible)
                Logger.Info("InitializePager");
        }
        protected override void InitializeItem(DataGridItem item, DataGridColumn[] columns)
        {
            base.InitializeItem(item, columns);
            //Logger.Info("InitializeItem");
        }
        protected override void CreateChildControls()
        {
            Controls.Clear();
            ClearChildViewState();
            base.CreateChildControls();
            CreateControlHierarchy();
            PrepareControlHierarchy();
            TrackViewState();
            ChildControlsCreated = true;
        }
        protected override void PrepareControlHierarchy()
        {
            base.PrepareControlHierarchy();
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
    }
}
