using System;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_SettingInfoEdit : BasePage
    {
        private SettingInfo settinginfo;

        public string Op
        {
            get
            {
                if (Request.QueryString["Op"] == null)
                {
                    return "";
                }
                else
                {
                    return Request.QueryString["Op"];
                }
            }
        }


        public string Id
        {
            get {
                return Request.QueryString["Id"] ?? "";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!CurrentUser.HasRight(RightEnum.SettingMaintain))
                {
                    this.SetNoRightInfo(true);
                    return;
                }

                String category = Request.QueryString["category"];
                if (!String.IsNullOrEmpty(category))
                {                    
                    this.txtCategory.Attributes.Add("ReadOnly", "ReadOnly");
                }

                tbiSave.Visible = true;
                if (Op.ToLower() == "edit")
                {
                    BindData();
                    this.txtSettingKey.Attributes.Add("ReadOnly", "ReadOnly");
                    //tbiAdd.Visible = false;
                }
                else if (Op.ToLower() == "new")
                {
                    if (!String.IsNullOrEmpty(category))
                    {
                        this.txtCategory.Text = category;
                    }
                    //tbiAdd.Visible = false;
                }
                else
                {
                    //tbiAdd.Visible = false;
                    tbiSave.Visible = false;
                }
            }
        }

        private void BindData()
        {
            settinginfo =  DataProvider.SettingProvider.GetByKey(this.Id);

            this.txtCategory.Text = settinginfo.Category;
            this.tb_Remark.Text = settinginfo.Remark;
            this.txtSettingKey.Text = settinginfo.Key;
            this.txtValue.Text = settinginfo.Value;
        }

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            settinginfo = new SettingInfo();
            if(item.ItemId.ToLower() == "save")
            {
                if (Op.ToLower() == "edit")
                {
                    try
                    {
                        settinginfo.Key = this.txtSettingKey.Text;
                        settinginfo.Value = this.txtValue.Text;
                        settinginfo.Remark = this.tb_Remark.Text;
                        settinginfo.Category = this.txtCategory.Text;
                        if (DataProvider.SettingProvider.Update(settinginfo))
                        {
                            //this.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script>alert('开关量修改成功！');parent.opener.document.location = 'SYS_SettingInfoList.aspx';window.close();</script>");
                            this.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script>alert('开关量修改成功！');parent.opener.document.location = parent.opener.document.location;window.close();</script>");
                        }
                        else
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script>alert('开关量修改失败！');</script>");

                        }


                    }
                    catch
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script>alert('开关量修改失败！');</script>");
                    }
                }
                else if (Op.ToLower() == "new")
                {
                    try
                    {
                        if (!DataProvider.SettingProvider.IsExist(txtSettingKey.Text))
                        {
                            settinginfo.Key = this.txtSettingKey.Text;
                            settinginfo.Value = this.txtValue.Text;
                            settinginfo.Remark = this.tb_Remark.Text;
                            settinginfo.Category = this.txtCategory.Text;
                            if (DataProvider.SettingProvider.Insert(settinginfo))
                            {
                                //this.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script>alert('开关量新增成功！');parent.opener.document.location = 'SYS_SettingInfoList.aspx';window.close();</script>");
                                ////AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);

                                this.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script>alert('开关量新增成功！');parent.opener.document.location = parent.opener.document.location;window.close();</script>");
                            }
                            else
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "Error", "<script>alert('开关量新增失败！');</script>");

                            }
                        }
                        else
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "Success1", "<script>alert('开关量已存在！');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script>alert('" + ex.Message + "！');</script>");
                    }
                }
            }
        }

       
    }
}
