using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Common.Storage;
using Shmzh.MM.DataAccess.Storage;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using Shmzh.Components.SystemComponent;

namespace WebMM.Storage
{
    public partial class InventoryDetail : System.Web.UI.Page
    {
        #region Property
        public Shmzh.Components.SystemComponent.User CurrentUser
        {
            get { return Session["User"] as Shmzh.Components.SystemComponent.User; }
        }
        public int ParentId
        {
            get { return int.Parse(this.Request["Id"]); }
        }
        public ListBase<InventoryDetailInfo> InventoryDetailInfos
        {
            get
            {
                if(Session["InventoryDetailInfos"] == null)
                {
                    return null;
                }
                return Session["InventoryDetailInfos"] as ListBase<InventoryDetailInfo>;
            }
            set { Session["InventoryDetailInfos"] = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// 绑定单位下拉列表。
        /// </summary>
        private void BindUnit()
        {
            this.ddlUnit.Items.Clear();
            var objs = new ItemSystem().QueryAllUnits();
            for (var i = 0; i < objs.Tables[UnitData.UNIT_TABLE].Rows.Count; i++)
            {
                var item = new ListItem(objs.Tables[UnitData.UNIT_TABLE].Rows[i][UnitData.DESCRIPTION_FIELD].ToString(), objs.Tables[UnitData.UNIT_TABLE].Rows[i][UnitData.CODE_FIELD].ToString());
                this.ddlUnit.Items.Add(item);
            }
        }
        /// <summary>
        /// 绑定仓库架位。
        /// </summary>
        /// <param name="stoCode">仓库编号。</param>
        private void BindCon(string stoCode)
        {
            this.ddlCon.Items.Clear();
            var objs = new ItemSystem().GetStoConByStoCode(stoCode);
            for (var i = 0; i < objs.Tables[StoConData.STOCON_TABLE].Rows.Count; i++)
            {
                var item = new ListItem(objs.Tables[StoConData.STOCON_TABLE].Rows[i][StoConData.DESCRIPTION_FIELD].ToString(), objs.Tables[StoConData.STOCON_TABLE].Rows[i][StoConData.CODE_FIELD].ToString());
                this.ddlCon.Items.Add(item);
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(!string.IsNullOrEmpty(this.Request["Id"]))
                {
                    var id = int.Parse(this.Request["Id"]);
                    var obj = new Inventorys().GetById(id);
                    this.txtName.Text = obj.Name;
                    this.txtStorage.Text = obj.StoName;
                    this.txtDate.Text = obj.Date.ToShortDateString();
                    this.txtRemark.Text = obj.Remark;
                    this.BindCon(obj.StoCode);
                    this.BindUnit();

                    this.InventoryDetailInfos = new InventoryDetails().GetByParentId(id);
                    this.DataGrid1.DataSource = InventoryDetailInfos;
                    this.DataGrid1.DataBind();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var itemCode = this.txtItemCode.Text.Trim();
            var conCode = int.Parse(this.ddlCon.SelectedValue);
            if(this.InventoryDetailInfos.Exists(item=>item.ItemCode == itemCode && item.ConCode == conCode))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"NotUnique",string.Format("alert(\"{0}\");","该物料在该架位已经存在记录了，不能再添加！"),true);
                return;
            }
            else
            {
                if(string.IsNullOrEmpty(this.txtInventoryAmount.Text))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "EmptyInventoryAmount", string.Format("alert(\"{0}\");", "盘点数量不能为空！"), true);
                    return;
                }
                decimal inventoryAmount;
                try
                {
                    inventoryAmount = decimal.Parse(this.txtInventoryAmount.Text.Trim());
                }
                catch
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectInventoryAmount", string.Format("alert(\"{0}\");", "盘点数量必须为数字型！"), true);
                    return;
                }
                if(inventoryAmount > 0)
                {
                    var obj = new InventoryDetailInfo();
                    obj.Id = 0;
                    obj.ItemCode = this.txtItemCode.Text.Trim();
                    obj.ItemName = this.txtItemName.Text.Trim();
                    obj.ItemSpec = this.txtItemSpec.Text.Trim();
                    obj.ItemUnit = this.ddlUnit.SelectedItem.Text;
                    obj.CarryingAmount = 0;
                    obj.InventoryAmount = decimal.Parse(this.txtInventoryAmount.Text);
                    obj.ParentId = this.ParentId;
                    obj.ConCode = int.Parse(this.ddlCon.SelectedValue);
                    obj.ConName = this.ddlCon.SelectedItem.Text;
                    if(new InventoryDetails().Insert(obj) > 0)
                    {
                        this.InventoryDetailInfos.Add(obj);
                        this.txtId.Text = string.Empty;
                        this.txtItemCode.Text = string.Empty;
                        this.txtItemName.Text = string.Empty;
                        this.txtItemSpec.Text = string.Empty;
                        this.ddlUnit.SelectedIndex = 0;
                        this.ddlCon.SelectedIndex = 0;
                        this.txtCarrryingAmount.Text = string.Empty;
                        this.txtInventoryAmount.Text = string.Empty;
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "InsertFailed", string.Format("alert(\"{0}\");", "添加失败！"), true);
                    }
                    
                    this.DataGrid1.DataSource = this.InventoryDetailInfos;
                    this.DataGrid1.DataBind();
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectInventoryAmount", string.Format("alert(\"{0}\");", "盘点数量必须>0！"), true);
                    return;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.DataGrid1.SelectedID))
            {
                var id = long.Parse(this.DataGrid1.SelectedID);
                var obj = this.InventoryDetailInfos.Find(item => item.Id == id);
                if (obj != null)
                {
                    if(obj.CarryingAmount == 0)
                    {
                        if(new InventoryDetails().Delete(obj.Id))
                        {
                            this.InventoryDetailInfos.Remove(obj);
                            this.DataGrid1.DataSource = this.InventoryDetailInfos;
                            this.DataGrid1.DataBind();
                        }
                        else
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "DeleteFailed", string.Format("alert(\"{0}\");", "删除失败！"), true);
                            return;
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Cannotdelete", string.Format("alert(\"{0}\");", "由于存在账面数量，所以该记录不允许删除！"), true);
                        return;
                    }
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "Cannotdelete", string.Format("alert(\"{0}\");", "在单据上没有找到对应记录！"), true);
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "Cannotdelete", string.Format("alert(\"{0}\");", "请先选中记录然后再删除！"), true);
                
            }
        }

        protected void btnForItemCode_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text != "")
            {
                if (txtItemCode.Text != "-1")//-1表示是OTI物料。名称、规格型号等都是由用户临时指定的。
                {
                    //
                    //设置物料名称，规格型号，单价控件为只读并灰掉单位控件
                    //
                    this.txtItemName.ReadOnly = true;
                    this.txtItemSpec.ReadOnly = true;
                    this.ddlUnit.Enabled = false;
                    //
                    //需要从物料数据库中获取
                    //

                    var oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    //存在物料数据
                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        txtItemCode.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpec.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        //度量单位
                        ddlUnit.SelectedValue =
                            oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString();
                        txtCarrryingAmount.Text = "0";
                        txtCarrryingAmount.Enabled = false;
                    }
                    else
                    {
                        //
                        //不存在缺省为需要输入数据,弹出物料浏览界面,提供用户选择
                        //
                    }
                }
                else
                {
                    //
                    //用户直接输入
                    //
                    this.txtItemName.ReadOnly = false;
                    this.txtItemSpec.ReadOnly = false;
                    this.ddlUnit.Enabled = true;
                    var oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpec.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        //度量单位
                        ddlUnit.SelectedValue =
                            oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString();
                        txtCarrryingAmount.Text = "0";
                        txtCarrryingAmount.Enabled = false;
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //保存主表信息
            var inventory = new Inventorys().GetById(this.ParentId);
            if(inventory.Name != this.txtName.Text.Trim() || inventory.Remark != this.txtRemark.Text.Trim() || inventory.UserId != this.CurrentUser.thisUserInfo.PKID)
            {
                inventory.Name = this.txtName.Text.Trim();
                inventory.Remark = this.txtRemark.Text.Trim();
                inventory.UserId = this.CurrentUser.thisUserInfo.PKID;

                if(new Inventorys().Update(inventory)==false)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(),"SaveFailed",string.Format("alert(\"{0}\");","盘点基本信息保存失败！"),true);
                    return;
                }
            }

            //保存从表信息
            var length = this.DataGrid1.Items.Count;
            for(var i=0;i<length;i++)
            {
                var ctrl = this.DataGrid1.Items[i].FindControl("txtInventoryAmount") as TextBox;
                if(ctrl != null)
                {
                    if (string.IsNullOrEmpty(ctrl.Text)) ctrl.Text = "0";
                    try
                    {
                        var inventoryAmount = decimal.Parse(ctrl.Text);
                    }
                    catch
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectInventoryAmount",
                                          string.Format("alert(\"第{0}行的盘点数量，格式类似不正确！\");", i + 1), true);
                        return;

                    }
                    
                }
            }
            //检验通过以后。
            for (var i = 0; i < length; i++)
            {
                var ctrl = this.DataGrid1.Items[i].FindControl("txtInventoryAmount") as TextBox;
                if (ctrl != null)
                {
                    var inventoryAmount = decimal.Parse(ctrl.Text);
                    this.InventoryDetailInfos[i].InventoryAmount = inventoryAmount;
                }
            }
            foreach(var obj in this.InventoryDetailInfos)
            {
                if(!new InventoryDetails().Update(obj))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SaveFailed",string.Format("alert(\"保存失败！\");"), true);
                    break;
                }
            }
            this.DataGrid1.DataSource = this.InventoryDetailInfos;
            this.DataGrid1.DataBind();
            
        }

        protected void btnInit_Click(object sender, EventArgs e)
        {
            foreach(var obj in this.InventoryDetailInfos)
            {
                obj.InventoryAmount = obj.CarryingAmount;
            }
            this.DataGrid1.DataSource = this.InventoryDetailInfos;
            this.DataGrid1.DataBind();
        }
    }
}
