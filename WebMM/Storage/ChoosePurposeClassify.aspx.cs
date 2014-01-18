using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Shmzh.MM.Facade;
using Shmzh.MM.Common;
using ComponentArt.Web.UI;

namespace WebMM.Storage
{
    public partial class ChoosePurposeClassify : System.Web.UI.Page
    {
        ItemSystem oItemSystem = new ItemSystem();
        private DataTable dt = new DataTable();

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = oItemSystem.GetClassifyAvalible().Tables[0];
                CreatTree(dt);
            }
        }


        private void CreatTree(DataTable dt)
        {
            DataRow [] dtSub = dt.Select("parentId= '无'");
            if (dtSub.Length > 0)
            {
                for(int i=0;i<dtSub.Length;i++)
                {
                    var tn = new TreeViewNode { ID = dtSub[i]["ClassifyId"].ToString(), Text = dtSub[i]["Description"].ToString(), CssClass = "RootNode" };
                    AddSubNode(dt, dtSub[i]["ClassifyId"].ToString(), tn);
                    tn.Expanded = true;
                    this.tvPurpose.Nodes.Add(tn);
                }
            }
        }

        private void AddSubNode(DataTable dt,string strParentId, TreeViewNode tn)
        {
            DataRow[] dtSubNode = dt.Select("parentId='" + strParentId + "'");

            if (dtSubNode.Length > 0)
            {
                for (int j = 0; j < dtSubNode.Length; j++)
                {
                    var subTn = new TreeViewNode
                    {
                        ID = string.Format("{0}|{1}", dtSubNode[j]["ClassifyId"].ToString(), dtSubNode[j]["Description"].ToString()),
                        Value = string.Format("{0}|{1}", dtSubNode[j]["ClassifyId"].ToString(), dtSubNode[j]["Description"].ToString()),
                        Text = dtSubNode[j]["Description"].ToString()
                        
                    };
                    AddSubNode(dt, dtSubNode[j]["ClassifyId"].ToString(), subTn);
                    tn.Nodes.Add(subTn);
                }
            }
        }
    }
}
