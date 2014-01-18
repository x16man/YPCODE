using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Facade;

using Shmzh.MM.Common;
namespace WebMM.Storage
{
    public partial class IODetail : System.Web.UI.Page
    {
        private IOData oIOData;
        private ItemData oItemData;
        ItemSystem oItemSystem = new ItemSystem();

        /// <summary>
        /// 物料编号。
        /// </summary>
        public string ItemCode
        {
           
            set
            {
                this.txtItemCode.Text = value;
            }
        }

        /// <summary>
        /// 物料名称。
        /// </summary>
        public string ItemName
        {
            set
            {
                this.txtItemName.Text = value;
            }
        }

        /// <summary>
        /// 规格型号。
        /// </summary>
        public string ItemSpec
        {
            set
            {
                this.txtItemSpec.Text = value;
            }
        }

        /// <summary>
        /// 单位。
        /// </summary>
        public string ItemUnit
        {
            set
            {
                this.txtItemUnit.Text = value;
            }
        }

        /// <summary>
        /// 开始日期。
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return this.txtStartDate.Text.Trim().Length != 0 ? Convert.ToDateTime(this.txtStartDate.Text.ToString()) : new DateTime(1980, 1, 1);
            }
        }

        /// <summary>
        /// 结束日期。
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return this.txtEndDate.Text.Trim().Length != 0 ? Convert.ToDateTime(this.txtEndDate.Text.Trim()) : new DateTime(1980, 1, 1);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ItemCode = Master.ItemCode;
            if (!this.IsPostBack)
            {
                myDataBind();
            }
        }

        private void myDataBind()
        {
            
           
            if (this.StartDate == new DateTime(1980, 1, 1))
            {
                oIOData = oItemSystem.GetIOByItemCode(Master.ItemCode);
            }
            else
            {
                //TODO:增加	GetIOByItemCodeAndDate 所涉及到的存储过程和方法。
                oIOData = oItemSystem.GetIOByItemCodeAndDate(Master.ItemCode, this.StartDate, this.EndDate);
            }
            oItemData = oItemSystem.GetItemByCode(Master.ItemCode);
            this.ItemCode = oItemData.Tables[0].Rows[0][ItemData.CODE_FIELD].ToString();
            this.ItemName = oItemData.Tables[0].Rows[0][ItemData.CNNAME_FIELD].ToString();
            this.ItemSpec = oItemData.Tables[0].Rows[0][ItemData.SPECIAL_FIELD].ToString();
            this.ItemUnit = oItemData.Tables[0].Rows[0][ItemData.UnitName_Field].ToString();
            DataGrid1.DataSource = oIOData;
            try
            {
                DataGrid1.DataBind();
            }
            catch (Exception e)
            {
                if (e.Source == "System.Web" && DataGrid1.CurrentPageIndex >= 1)
                {
                    DataGrid1.CurrentPageIndex--;
                    DataGrid1.DataBind();
                }
            }
        }

        protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            myDataBind();	
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            myDataBind();	
        }

        protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            myDataBind();	
        }
    }
}
