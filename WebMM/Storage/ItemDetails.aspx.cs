using System;
using System.Data;
using Shmzh.MM.Facade;
using Shmzh.MM.Common;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM
{
    /// <summary>
    /// ItemDetails ��ժҪ˵����
    /// </summary>
    public partial class ItemDetails : System.Web.UI.Page
    {
        private ItemData ds;
        private DataRow dr;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
        
            if(!Page.IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.ItemBrowse))
                {
                    return;
                }
                BindData();

            }
        }
        private void BindData()
        {
            ds = new ItemData();
            ds = (new ItemSystem()).GetItemByCode(Master.Code);
            //��ֵ
            dr=ds.Tables[ItemData.ITEM_TABLE].Rows[0];


            txtCode.Text=dr[ItemData.CODE_FIELD].ToString();
            txtNewCode.Text = dr[ItemData.NEWCODE_FIELD].ToString();
            txtCnName.Text=dr[ItemData.CNNAME_FIELD].ToString();
            if (dr[ItemData.ENNAME_FIELD]!=DBNull.Value) 
                txtEnName.Text=dr[ItemData.ENNAME_FIELD].ToString();
            
            //���Ϸ���
            txtCategory.Text=dr[ItemData.CatName_Field].ToString();


            //����״̬
            try
            {
                ddlItemState.Module_Tag = (int)SDDLTYPE.ITEMSTATE;
                ddlItemState.SelectedValue = dr[ItemData.STATE_FIELD].ToString();

                ddlItemState.SetDDL();
                txtItemState.Text = ddlItemState.SelectedText;
            }
            catch
            {
                txtItemState.Text = "";
            }


            if (dr[ItemData.SPECIAL_FIELD]!=DBNull.Value) 
                txtSpecial.Text=dr[ItemData.SPECIAL_FIELD].ToString();

            //������λ
            txtUnit.Text=dr[ItemData.UnitName_Field].ToString();


            //�ƹ�����
            try
            {
                ddlPurMak.Module_Tag = (int)SDDLTYPE.PURMAK;
                ddlPurMak.SelectedValue = dr[ItemData.PURMAK_FIELD].ToString();
                ddlPurMak.SetDDL();
                txtPurMak.Text = ddlPurMak.SelectedText;
                
            }
            catch
            {
                txtPurMak.Text = "";
            }
          

                    
            if (dr[ItemData.BATCH_FIELD].ToString()=="Y") 
                txtIsBatch.Text="��";
            else
                txtIsBatch.Text="��";

            if (dr[ItemData.CHECKED_FIELD].ToString()=="Y") 
                txtIsCheck.Text="��";
            else
                txtIsCheck.Text="��";

            //���鱨��
            try
            {
                ddlCheckReport.Module_Tag = (int)SDDLTYPE.CHECKREPORT;
                ddlCheckReport.SelectedValue = dr[ItemData.CHKRPTCODE_FIELD].ToString();
                ddlCheckReport.SetDDL();
                txtCheckReport.Text = ddlCheckReport.SelectedText;
            }
            catch
            {
                txtCheckReport.Text = "";
            }


            //ABC
            try
            {
                ddlABC.Module_Tag = (int)SDDLTYPE.ABC;
                ddlABC.SelectedValue = dr[ItemData.ABC_FIELD].ToString();
                ddlABC.SetDDL();
                txtABC.Text = ddlABC.SelectedText;
            }
            catch
            {
                txtABC.Text = "";
            }

            if (dr[ItemData.CSTPRICE_FIELD]!=DBNull.Value) 
                txtCstPrice.Text=double.Parse(dr[ItemData.CSTPRICE_FIELD].ToString()).ToString("0.#########");
            if (dr[ItemData.EVAPRICE_FIELD]!=DBNull.Value) 
                txtEvPrice.Text=double.Parse(dr[ItemData.EVAPRICE_FIELD].ToString()).ToString("0.#########");
            if (dr[ItemData.UPPNUM_FIELD]!=DBNull.Value) 
                txtUppNum.Text=double.Parse(dr[ItemData.UPPNUM_FIELD].ToString()).ToString("0.#########");
            if (dr[ItemData.LOWNUM_FIELD]!=DBNull.Value) 
                txtLowNum.Text=double.Parse(dr[ItemData.LOWNUM_FIELD].ToString()).ToString("0.#########");
            if (dr[ItemData.SAFNUM_FIELD]!=DBNull.Value) 
                txtSafNum.Text=double.Parse(dr[ItemData.SAFNUM_FIELD].ToString()).ToString("0.#########");
            if (dr[ItemData.ORDNUM_FIELD]!=DBNull.Value) 
                txtOrdNum.Text=double.Parse(dr[ItemData.ORDNUM_FIELD].ToString()).ToString("0.#########");
            if (dr[ItemData.ORDBAT_FIELD]!=DBNull.Value) 
                txtBatch.Text=double.Parse(dr[ItemData.ORDBAT_FIELD].ToString()).ToString("0.#########");

            //���ʷ�ʽ

            try
            {
                ddlAccount.Module_Tag = (int)SDDLTYPE.ACCOUNT;
                ddlAccount.SelectedValue = dr[ItemData.ACCTYPE_FIELD].ToString();
                ddlAccount.SetDDL();
                txtAccount.Text = ddlAccount.SelectedText;
            }
            catch
            {
                txtAccount.Text = "";
            }
            //�ֿ�
            txtStorage.Text=dr[ItemData.StoName_Field].ToString();
            //���湩Ӧ��
            try
            {
                ddlProvider.Module_Tag = (int)SDDLTYPE.VENDOR;

                ddlProvider.SelectedValue = dr[ItemData.PRVCODE_FIELD].ToString();
                ddlProvider.SetDDL();
                txtProvider.Text = ddlProvider.thisDDL.SelectedItem.Text;
            }
            catch
            {
                txtProvider.Text = "";
            }

            //��λ
            txtCon.Text=dr[ItemData.ConName_Field].ToString();

        }
    }
}
