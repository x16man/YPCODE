using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using ComponentArt.Web.UI;


namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_ChooseDept ��ժҪ˵����
	/// </summary>
	public partial class SYS_ChooseDept : BasePage
    {
        #region Field

	    private IList<DeptInfo> deptInfos;
        #endregion

        #region Property

        #endregion

        #region Method
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="objs">���ż��ϡ�</param>
        private void CreatTree(IList<DeptInfo> objs)
        {

            var subDepts = ((List<DeptInfo>)objs).FindAll(obj => obj.ParentDept == "-1");
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
            if (subDepts.Count > 0)
            {
                foreach (var obj in subDepts)
                {
                    var rootNode = new TreeViewNode
                                       {
                                           ID = obj.DeptCode,
                                           Value = obj.DeptCode,
                                           Text = obj.DeptCnName,
                                           CssClass = "RootNode"
                                       };
                    this.AddSubNode(this.deptInfos, rootNode);
                    this.tvDept.Nodes.Add(rootNode);
                }
                this.tvDept.ExpandAll();
            }
        }
        /// <summary>
        /// �����ӽڵ㡣
        /// </summary>
        /// <param name="objs">���ż��ϡ�</param>
        /// <param name="tn">���ڵ�</param>
        private void AddSubNode(IList<DeptInfo> objs, TreeViewNode tn)
        {
            var subDepts = ((List<DeptInfo>)objs).FindAll(obj => obj.ParentDept == tn.ID);
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
            if (subDepts.Count > 0)
            {
                foreach (var obj in subDepts)
                {
                    var subTn = new TreeViewNode
                                    {
                                        ID = obj.DeptCode,
                                        Value = obj.DeptCode,
                                        Text = obj.DeptCnName,
                                        ToolTip = obj.Remark
                                    };
                    this.AddSubNode(this.deptInfos, subTn);
                    tn.Nodes.Add(subTn);
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
			if (!this.IsPostBack)
			{
			    this.deptInfos = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(this.CompanyCode);
				CreatTree(this.deptInfos);
			}
		}
        #endregion
    }
}
