using System;
using System.Collections.Generic;
using ComponentArt.Web.UI;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// �ಿ��ѡ����档
	/// </summary>
	public partial class SYS_ChooseDepts :BasePage
	{
		#region ��Ա����
		protected string IdInitializtion = string.Empty;
		protected string NameInitializtion = string.Empty;
		#endregion

		#region ����
		/// <summary>
		/// ��ǰѡ�е��û�ID��
		/// </summary>
		protected string[] DeptCodes
		{
			get
			{
                return !string.IsNullOrEmpty(Request["DeptCodes"]) ? Request["DeptCodes"].Split(',') : null;
			}
		}
		#endregion

		#region ����
		/// <summary>
		/// ������������
		/// </summary>
		/// <param name="depts">���ż���</param>
		/// <param name="tv">TreeView�ؼ���</param>
		private void CreatTree(List<DeptInfo> depts, ComponentArt.Web.UI.TreeView tv)
		{
		    var subDepts = depts.FindAll(obj => obj.ParentDept == "-1");
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
        	foreach(var obj in subDepts)
			{
                var tn = new TreeViewNode
                             {
                                 ID = obj.DeptCode,
                                 Value = obj.DeptCode,
                                 Text = obj.DeptCnName,
                                 CssClass = "RootNode",
                                 Expanded = true,
                                 ShowCheckBox = true,
                             };
                if (this.DeptCodes != null && this.DeptCodes.Length > 0)
                {
                    for (var j = 0; j < this.DeptCodes.Length; j++)
                    {
                        if (tn.ID.Split('|')[0] == this.DeptCodes[j])
                        {
                            this.IdInitializtion += string.Format(this.IdInitializtion == string.Empty ? @"'{0}'" : @",'{0}'", tn.ID);
                            this.NameInitializtion += string.Format(this.NameInitializtion == string.Empty ? @"'{0}'" : @",'{0}'", tn.Text);
                            tn.Checked = true;
                        }
                    }
                }
			    AddSubNode(depts, tn);

				tv.Nodes.Add(tn);
			}
		}
		/// <summary>
		/// �����ӽڵ㡣
		/// </summary>
		/// <param name="depts">���ż��ϡ�</param>
		/// <param name="tn">���ڵ㡣</param>
		private void AddSubNode(List<DeptInfo> depts,TreeViewNode tn)
		{
		    var subDepts = depts.FindAll(obj => obj.ParentDept == tn.ID);
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
			if(subDepts.Count > 0)
			{
				foreach(var obj in subDepts)
				{
                    var subTn = new TreeViewNode
                                             {
                                                 ID = obj.DeptCode,
                                                 Value = obj.DeptCode,
                                                 Text = obj.DeptCnName,
                                                 ShowCheckBox = true,
                                             };
                    if (this.DeptCodes != null && this.DeptCodes.Length > 0)
                    {
                        for (var j = 0; j < this.DeptCodes.Length; j++)
                        {
                            if (subTn.ID.Split('|')[0] == this.DeptCodes[j])
                            {
                                this.IdInitializtion += string.Format(this.IdInitializtion == string.Empty ? @"'{0}'" : @",'{0}'", subTn.ID);
                                this.NameInitializtion += string.Format(this.NameInitializtion == string.Empty ? @"'{0}'" : @",'{0}'", subTn.Text);
                                subTn.Checked = true;
                            }
                        }
                    }
				    AddSubNode(depts,subTn);
					tn.Nodes.Add(subTn);
				}
			}
		}
        #endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
                var depts = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(this.CompanyCode) as List<DeptInfo>;
                this.CreatTree(depts, tvDept);
			}			
		}
        /// <summary>
        /// �ύ��ť�¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string deptCodes = string.Empty, deptNames = string.Empty;
            
            foreach(var oNode in tvDept.CheckedNodes)
            {
                deptCodes += string.Format(deptCodes.Length>0?",{0}":"{0}",oNode.ID);
                deptNames += string.Format(deptNames.Length > 0?",{0}":"{0}",oNode.Text);
            }
            /*
             * deptCodes,deptNames
             */
            var script = string.Format("<script>window.opener.setDeptInfo('{0}','{1}');window.close();</script>",  deptCodes, deptNames);
            AddScript(this.GetType(), "FeedBack", script);
        }
	}
}
