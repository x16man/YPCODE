using System;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using ComponentArt.Web.UI;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Enum;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_RoleRight ��ժҪ˵����
	/// </summary>
	public partial class SYS_RoleRight : BasePage
	{
		#region ��Ա����
#pragma warning disable 169
        private static readonly string ROLERIGHTINSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RoleRightInsertFailed"));
        private static readonly string ROLERIGHTINSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RoleRightInsertSuccess"));
        private static readonly string ROLERIGHTDELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RoleRightDeleteFailed"));
        private static readonly string ROLERIGHTDELETESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RoleRightDeleteSuccess"));
        private static readonly string ROLERIGHTNOROLE = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RoleRightNoRole"));
#pragma warning restore 169
        protected Repeater RepRights;

		#endregion

        #region Property
        /// <summary>
        /// ��Ʒ��š�
        /// </summary>
	    public short ProductCode
	    {
            get { return short.Parse(this.txtProductCode.Value); }
            set { this.txtProductCode.Value = value.ToString(); }
	    }
        /// <summary>
        /// ��ɫ��š�
        /// </summary>
	    public int RoleCode
	    {
            get { return int.Parse(this.txtRoleCode.Value); }
            set { this.txtRoleCode.Value = value.ToString(); }
	    }
        #endregion

        #region Method
        /// <summary>
        /// ��Ȩ�޷�����Ϣ��Repeater�ؼ���
        /// </summary>
        private void BindRightCat()
        {
            var objs = DataProvider.RightCatProvider.GetAllAvalibleByProductCode(this.ProductCode);
            objs.Add(new RightCatInfo {Code = "0", Name = "����", Desc = string.Empty, ProductCode = this.ProductCode, IsValid = "Y"});
            this.CateLogList.DataSource = objs;
            this.CateLogList.DataBind();
        }
        /// <summary>
        /// �󶨽�ɫ��Ϣ��
        /// </summary>
        private void BindRole()
        {
            var objs = DataProvider.RoleProvider.GetAllByProductCode(this.ProductCode);
            tvRole.Nodes.Clear();
            foreach(var obj in objs)
            {
                var oNode = new TreeViewNode
                                {ID = obj.RoleCode.ToString(), Value = obj.RoleCode.ToString(), Text = obj.RoleName, ToolTip = obj.Remark};
                if(obj.IsValid != "Y")
                {
                    oNode.ImageUrl = "User_gray.png";
                }
                this.tvRole.Nodes.Add(oNode);
            }
        }
        /// <summary>
        /// �������е�Ȩ���
        /// </summary>
        /// <param name="roleCode">��ɫ��</param>
        private void SetCheckBoxList(string roleCode)
        {
            if (string.IsNullOrEmpty(roleCode)) return;

            //var al = new Right().GetAllByRoleCode(int.Parse(roleCode));
            var objs = DataProvider.RoleRightProvider.GetByRoleCode(short.Parse(roleCode));
            foreach(var obj in objs)
            {
                foreach (RepeaterItem item in this.CateLogList.Items)
                {
                    var chkList = item.FindControl("CkbList") as CheckBoxList;
                    if (chkList == null) continue;
                    foreach (ListItem listItem in chkList.Items)
                    {
                        if (obj.RightCode.ToString() == listItem.Value)
                        {
                            listItem.Selected = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// ҳ������¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
		{
			this.ProductCode = short.Parse(this.Request["ProductCode"]);
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!this.IsPostBack)
			{
				if(!CurrentUser.HasRight(RightEnum.UserRoleRightMaintain))
				{
                    this.SetNoRightInfo(true);
				    return;
				}
                switch (this.ProductCode)
                {
                    case ProductEnum.KM: //֪ʶ�⡣
                        if (!CurrentUser.HasRight(RightEnum.KM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.MM: //���Ϲ���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.MM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.RS: //��Դ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.RS))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PC: //Ѳ�����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PC))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.VM: //��Ӧ�̹���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.VM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.QA: //ˮ�ʷ���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.QA))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PD: //��������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PD))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PM: //��Ŀ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.SD: //��������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.SD))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.WS: //��վ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.WS))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.FW: //ϵͳ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.FW))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.CM: //��ͬ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.CM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.ET: //ʳ�ù���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.ET))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.EP: //���ù���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.EP))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.SM: //����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.SM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.QF: //ˮ��Ԥ��ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.QF))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.MT: //�������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.MT))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PR: //��������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PR))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PDV: //�����豸����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PDV))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.OA: //OA��ҳϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.OA))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PS: //�������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PS))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PG: //�����ɼ�ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PG))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.AM: //��������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.AM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.GQ: //ȫ�ֲ�ѯϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.GQ))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.HR: //���¹���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.HR))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.CW: //���չ���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.CW))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.ODV: //�����豸����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.ODV))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.WF://����������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.WF))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                }
			    BindRole();
			    BindRightCat();
			}
		}
        /// <summary>
        /// Ȩ�޷����б����ݰ󶨡�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CateLogList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var catList = (CheckBoxList)e.Item.FindControl("CkbList");
                var rightCatCode = ((Label)e.Item.FindControl("PKID")).Text.Trim();

                if (rightCatCode == "0")
                {
                    var objs = DataProvider.RightProvider.GetAllAvalibleOtherByProductCode(this.ProductCode);
                    foreach (var obj in objs)
                    {
                        var item = new ListItem(obj.RightName, obj.RightCode.ToString());
                        
                        item.Attributes.Add("title",string.Format("({0}){1}",obj.RightCode,obj.Remark));

                        catList.Items.Add(item);
                    }
                }
                else
                {
                    var objs = DataProvider.RightProvider.GetAllAvalibleByRightCatCode(rightCatCode);
                    foreach (var obj in objs)
                    {
                        var item = new ListItem(obj.RightName, obj.RightCode.ToString());
                        item.Attributes.Add("title", string.Format("({0}){1}", obj.RightCode, obj.Remark));

                        catList.Items.Add(item);
                    }
                }
            }
        }

        #endregion

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.CateLogList.ItemDataBound += this.CateLogList_ItemDataBound;
		}
		#endregion

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch(item.ItemId.ToUpper())
            {
                case "DELETE":
                    var obj = DataProvider.RoleProvider.GetByCode(short.Parse(this.tvRole.SelectedNode.Value));
                    if (DataProvider.RoleProvider.Delete(obj))
                    {
                        DataProvider.OperationLogProvider.Insert(new OperationLogInfo()
                                                                     {
                                                                         UserName = this.CurrentUser.LoginName,
                                                                         OpTime = DateTime.Now,
                                                                         ProductCode = this.ProductCode,
                                                                         OpType = OpTypeEnum.RoleRightOperation,
                                                                         OpDesc = string.Format("��ɫɾ�� {0}", obj)
                                                                     });
                        AddScript(ROLERIGHTDELETESUCCESS_SCRIPT);
                    }
                    else
                    {
                        AddScript(ROLERIGHTDELETEFAILED_SCRIPT);
                    }
                    BindRole();
                    break;
            }
        }

        protected void tvRole_NodeSelected(object sender, ComponentArt.Web.UI.TreeViewNodeEventArgs e)
        {
            this.RoleCode = int.Parse(e.Node.Value);
            this.tbiSelectAll.Checked = false;
            this.BindRightCat();
            this.SetCheckBoxList(e.Node.Value);
        }

        protected void MzhToolbar2_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch(item.ItemId.ToUpper())
            {
                case "SELECTALL":
                    this.tbiClearAll.Checked = false;
                    foreach (RepeaterItem oItem in this.CateLogList.Items)
                    {
                        var chkList = oItem.FindControl("CkbList") as CheckBoxList;
                        if (chkList == null) continue;
                        foreach(ListItem obj in chkList.Items)
                        {
                            obj.Selected = true;
                        }
                    }
                    break;
                case "CLEARALL":
                    this.tbiSelectAll.Checked = false;
                    foreach (RepeaterItem oItem in this.CateLogList.Items)
                    {
                        var chkList = oItem.FindControl("CkbList") as CheckBoxList;
                        if (chkList == null) continue;
                        foreach (ListItem obj in chkList.Items)
                        {
                            obj.Selected = false;
                        }
                    }
                    break;
                case "SAVE":
                    var rightList = "";
                    if (this.tvRole.SelectedNode!=null && !string.IsNullOrEmpty(this.tvRole.SelectedNode.Value))
                    {
                        foreach (RepeaterItem oItem in this.CateLogList.Items)
                        {
                            var chkList = oItem.FindControl("CkbList") as CheckBoxList;
                            if (chkList == null) continue;
                            foreach (ListItem obj in chkList.Items)
                            {
                                rightList += obj.Selected ? obj.Value + "," : string.Empty;
                            }
                        }
                        rightList = rightList.TrimEnd(',');
                        if (rightList != "")
                        {
                            var obj = DataProvider.RoleProvider.GetByCode(short.Parse(this.tvRole.SelectedNode.Value));
                            if(DataProvider.RoleRightProvider.Delete(short.Parse(this.tvRole.SelectedNode.Value)))
                            {
                                if(DataProvider.RoleRightProvider.Insert(short.Parse(this.tvRole.SelectedNode.Value), rightList))
                                {
                                    DataProvider.OperationLogProvider.Insert(new OperationLogInfo()
                                                                                 {
                                                                                     UserName = this.CurrentUser.LoginName,
                                                                                     OpTime = DateTime.Now,
                                                                                     ProductCode = this.ProductCode,
                                                                                     OpType = OpTypeEnum.RoleRightOperation,
                                                                                     OpDesc = string.Format("��ɫȨ�ޱ�� {0}-RightCode:{1}", obj, rightList)
                                                                                 });   
                                    this.BindRightCat();
                                    this.SetCheckBoxList(this.tvRole.SelectedNode.Value);
                                    AddScript(ROLERIGHTINSERTSUCCESS_SCRIPT);
                                }
                                else
                                {
                                    AddScript(ROLERIGHTINSERTFAILED_SCRIPT);
                                }
                            }
                            else
                            {
                                AddScript(ROLERIGHTINSERTFAILED_SCRIPT);
                            }
                        }
                        else
                        {
                            AddScript(this.GetType(), "NoRole", "<script>alert('û��ѡ��Ȩ�ޣ�');</script>");
                        }
                    }
                    else
                    {
                        AddScript(this.GetType(), "NoRole", "<script>alert('û��ѡ�н�ɫ��');</script>");
                    }
                    break;
            }
            
        }
		
	}
}
