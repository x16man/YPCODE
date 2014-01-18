using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Shmzh.MM.Facade;
using Shmzh.MM.Common;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// UsingBrowser ��ժҪ˵����
	/// </summary>
    public partial class UsingBrowser : System.Web.UI.Page
	{
		#region Field
        ItemSystem oItemSystem = new ItemSystem();
        //PurposeData ds = new PurposeData();
        //ClassifyData dsclass = new ClassifyData();

		#endregion

        #region Property
        /// <summary>
        /// ��ڱ�־.
        /// </summary>
	    public int Flag
	    {
	        get {return int.Parse(ViewState["Flag"].ToString());}
            set { ViewState["Flag"] = value;}
	    }
        /// <summary>
        /// ��ѯ��־��
        /// </summary>
        public int SelectFlag
        {
            get { return int.Parse(ViewState["SelectFlag"].ToString()); }
            set { ViewState["SelectFlag"] = value; }
        }
        /// <summary>
        /// ��;����Id.
        /// </summary>
        private string ClassifyID
        {
            get
            {
                return ViewState["ClassifyID"].ToString();
            }
            set
            {
                ViewState["ClassifyID"] = value;
            }
        }
        #endregion

        #region ˽�з���
        
		/// <summary>
		/// ΪDataGrid������Դ
		/// </summary>
		private void myDataBind()
		{
            this.ClassifyID = this.dllUsingClassify.SelectedValue;

            PurposeData ds;
            if (this.SelectFlag == 1)
            {
                if (this.Flag == 1)
				    ds = oItemSystem.GetPurposeByClassifyWithFlag(ClassifyID,this.Flag);				
			    else
				    ds = oItemSystem.GetPurposeByClassify(ClassifyID);
                this.DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
     
            }
            else if(this.SelectFlag == 2)
            {
                var pyzm = this.txtContent.Text;

                if (!string.IsNullOrEmpty(pyzm))
                {
                    ds = this.Flag == 1 ? oItemSystem.GetAvailablePurposeByPYWithFlag(this.ClassifyID, pyzm, this.Flag) 
                                        : oItemSystem.GetAvailablePurposeByPY(this.ClassifyID, pyzm);
                    this.DataGrid1.DataSource = ds;
                    DataGrid1.DataBind();
                }        
            }
		}
		/// <summary>
		/// ΪDropDownList������Դ
		/// </summary>
		private void ddlDataBind()
		{
            var dsclass = oItemSystem.GetClassifyAvalible();
            var dv = dsclass.Tables[0].DefaultView;
			dv.RowFilter = "ParentID <> '��'";
			dllUsingClassify.DataSource = dv;
			dllUsingClassify.DataTextField = ClassifyData.DESCRIPTION_FIELD;
			dllUsingClassify.DataValueField = ClassifyData.CODE_FIELD;
			dllUsingClassify.DataBind();

            dllUsingClassify.Items.Insert(0,new ListItem("----ȫ��---","-1"));
            ClassifyID = dsclass.Tables[0].Rows[0][ClassifyData.CODE_FIELD].ToString();
		}

		#endregion

		#region �¼�
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!IsPostBack)
			{
                this.Flag = int.Parse(this.Request["Flag"]);
				ddlDataBind();
				
			    this.SelectFlag = 1;
				myDataBind();
			}
			else
			{
			    this.DataGrid1.AutoDataBind = myDataBind;
			}
		}

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("ondblclick", string.Format("setPurposeInfo('{0}','{1}');", e.Item.Cells[3].Text, e.Item.Cells[5].Text));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtContent.Text))
            {
                this.SelectFlag = 2;
                this.myDataBind();
            }
        }

        protected void dllUsingClassify_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectFlag = 1;
            myDataBind();
        }

		#endregion 
	}
}
