using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MZHCommon;
using MZHCommon.Database;
//using MZHCommon.PageStyle;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;

namespace WebMM.Storage
{
    public partial class ItemUseDetail : System.Web.UI.Page
    {
        private DataSet oData = new DataSet();

        /// <summary>
        /// 连接串。
        /// </summary>
        private string ConnectString
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlParameter [] arParms = new SqlParameter[1];
			arParms[0] = new SqlParameter("@ItemCode", SqlDbType.NVarChar,20); 
			arParms[0].Value = Master.ItemCode;
			ItemData oItemData;
            oItemData = new ItemSystem().GetItemByCode(Master.ItemCode);
			if (oItemData.Count > 0)
			{
                this.txtItemCode1.Text = oItemData.Tables[0].Rows[0][ItemData.CODE_FIELD].ToString();
                this.txtItemName1.Text = oItemData.Tables[0].Rows[0][ItemData.CNNAME_FIELD].ToString();
                this.txtItemSpec1.Text = oItemData.Tables[0].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                this.txtItemUnit1.Text = oItemData.Tables[0].Rows[0][ItemData.UnitName_Field].ToString();
                this.txtStoName1.Text = oItemData.Tables[0].Rows[0][ItemData.StoName_Field].ToString();
                this.txtConName1.Text = oItemData.Tables[0].Rows[0][ItemData.ConName_Field].ToString();
				
			}
			SqlHelper.FillDataset(this.ConnectString,"Sto_ItemGetUseByCode",oData,new string[] {"MyTable"},arParms);		
						
			this.MzhDataGrid1.DataSource = oData;
			this.MzhDataGrid1.DataBind();
        }
    }
}
