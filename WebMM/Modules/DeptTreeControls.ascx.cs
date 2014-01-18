

namespace MZHMM.WebMM.Modules
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using Shmzh.Components.SystemComponent;
    using System.Collections.Generic;
    
	/// <summary>
	///		DeptTreeControls 的摘要说明。
	/// </summary>
	public partial class DeptTreeControls : System.Web.UI.UserControl
	{
	   // private EntryDept objEntryDept = null;
        private List<DeptInfo> Deptlist;
        private Shmzh.Components.SystemComponent.SQLServerDAL.Dept dept = new Shmzh.Components.SystemComponent.SQLServerDAL.Dept();
        private string _company = "";

        private string ret = "";

        //private int i;

        /// <summary>
        /// 是否完成前次清除 
        /// </summary>
        private bool bclearStatus = true;

        //private string strValue;

        //private string strtemp;

        /// <summary>
        /// 是否完成前次设置 
        /// </summary>
        private bool bSetStatus = true;

        List<string> lstcheckbox = new List<string>();

        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if (!this.IsPostBack)
            {
                BuildDeptTree();

            }
		}

        private void BuildDeptTree()
        {
            //objEntryDept = (new Organize()).GetAllDeptsByCompany(_company);
            Deptlist = dept.GetAllAvalibleCompanyCode(_company) as List<DeptInfo>;

            TreeNode tn = new TreeNode();

            //string FilterExpr = "ParentDept = '-1'";
            //System.Data.DataRow[] dr = new System.Data.DataRow[objEntryDept.Tables[0].Select(FilterExpr).Length];
            var Depts = Deptlist.FindAll(o => o.ParentDept == "-1");

            //dr = objEntryDept.Tables[0].Select(FilterExpr);
            if (Depts.Count  > 0)
            {
                //tn.Text=dr[0]["ParentDeptName"].ToString();
                tn.Text = Depts[0].DeptCnName;
                tn.Value = Depts[0].DeptCode;
                
            }

            tn.Expanded = true;
            AddSubNode(Deptlist, tn);
            TreeView1.Nodes.Add(tn);

        }


        private void AddSubNode(List<DeptInfo> dt, TreeNode tn)
        {
           // string FilterExpr = "ParentDept = '" + tn.Value + "'";
           // System.Data.DataRow[] dr = new System.Data.DataRow[dt.Select(FilterExpr).Length];
            var subDepts = Deptlist.FindAll(o => o.ParentDept == tn.Value);
            //dr = dt.Select(FilterExpr);
            if (subDepts.Count > 0)
            {
                for (int i = 0; i < subDepts.Count ; i++)
                {
                    TreeNode subTn = new TreeNode();
                   // subTn.Value = dr[i].ItemArray[0].ToString();
                    //subTn.Text = dr[i].ItemArray[2].ToString();

                    subTn.Value = subDepts[i].DeptCode;
                    subTn.Text = subDepts[i].DeptCnName;
                    //subTn.Checked  = true;
                    //subTn.NodeData=getNodeData((bool)dr[i].ItemArray[13]);
                    subTn.Target = "normalNodeType";
                    //	subTn.NavigateUrl="EmpBrower.aspx?DeptCode="+subTn.ID;
                    //	subTn.Target="empframe";
                    AddSubNode(dt, subTn);
                    tn.ChildNodes.Add(subTn);
                }
            }
        }


        /// <summary>
        /// 得到选中的列表
        /// </summary>
        /// <returns></returns>
        public string GetAllCheckedList()
        {
            //strValue = "";
            //foreach(string strtemp in lstcheckbox.ToArray())
            //{
            //    strValue +=  "," + strtemp;
            //}
            //return strValue.TrimStart(',');
            for (int i = 0; i < TreeView1.Nodes.Count; i++)
            {
                if (TreeView1.Nodes[i].Checked)
                {
                    if (ret == "")
                    {
                        ret = ret + TreeView1.Nodes[i].Value;
                    }
                    else
                    {
                        ret = ret + "," + TreeView1.Nodes[i].ChildNodes;
                    }
                }

                GetAllCheckListString(TreeView1.Nodes[i]);

            }
            return ret;
        }

        private void GetAllCheckListString(TreeNode tn)
        {
            for (int i = 0; i < tn.ChildNodes.Count; i++)
            {
                if (tn.ChildNodes[i].Checked)
                {
                    if (ret == "")
                    {
                        ret = ret + tn.ChildNodes[i].Value;
                    }
                    else
                    {
                        ret = ret + "," + tn.ChildNodes[i].Value;
                    }
                }
                GetAllCheckListString(tn.ChildNodes[i]);
            }
        }

        public void ClearAllNodeChecked()
        {
            if (TreeView1.Nodes.Count != 0)
            {
                if (bclearStatus && bSetStatus)
                {
                    bclearStatus = false;
                    Clears(TreeView1.Nodes[0]);
                    bclearStatus = true;
                }
            }
        }

        private void Clears(TreeNode tnClearNode)
        {
            for (int i = 0; i < tnClearNode.ChildNodes.Count; i++)
            {
                tnClearNode.ChildNodes[i].Checked = false;
                Clears(tnClearNode.ChildNodes[i]);
            }
        }

        public void SetCheckLists(string checkList)
        {
            if (checkList != "")
            {
                if (bSetStatus)
                {
                    bSetStatus = false;
                    SetCheckList(TreeView1.Nodes[0], checkList);
                    bSetStatus = true;
                }
            }
        }

        private void SetCheckList(TreeNode tn, string checkList)
        {
            for (int i = 0; i < tn.ChildNodes.Count; i++)
            {
                if (checkList.IndexOf(tn.ChildNodes[i].Value) > 0)
                {
                    tn.ChildNodes[i].Checked = true;
                    if(!lstcheckbox.Contains(tn.ChildNodes[i].Value))
                        lstcheckbox.Add(tn.ChildNodes[i].Value);
                    
                }
                SetCheckList(tn.ChildNodes[i], checkList);
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.TreeView1.SelectedNode.Checked)
                lstcheckbox.Add(TreeView1.SelectedNode.Value);
            else
                lstcheckbox.Remove(TreeView1.SelectedNode.Value);
        }
    }
}
