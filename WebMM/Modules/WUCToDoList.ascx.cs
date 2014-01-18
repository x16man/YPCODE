using System;
using System.Web.UI.WebControls;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Common;
using Shmzh.Components.WorkFlow;

namespace WebMM.Modules
{
    /// <summary>
    /// 待办事宜的用户Web组件.
    /// </summary>
    public partial class WUCToDoList : System.Web.UI.UserControl
    {
        #region Property
        public Shmzh.Components.SystemComponent.User CurrentUser
        {
            get { return Session["User"] as Shmzh.Components.SystemComponent.User; }
        }
        #endregion

        #region event
        /// <summary>
        /// 页面加载事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.CurrentUser.HasRight(SysRight.Anothertodo))
                {
                    this.mzhDataGrid1.Visible = false;
                    this.BindAnotherToDoList();
                    spanOP.Visible = true;
                }
                else
                {
                    this.anotherToDoListDiv.Visible = false;
                    this.BindToDoList();
                    spanOP.Visible = false;
                }
            }
        }
        /// <summary>
        /// 通过按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYesTop_Click(object sender, EventArgs e)
        {
            var taskIDs = this.GetSelectedTaskID();
            var assessor = CurrentUser.EmpName;
            var userLoginId = CurrentUser.LoginName;
            const string entryState = "T";
            const string flag = "Y";

            if (taskIDs != "")
            {
                new PurchaseSystem().BatchThirdAudit(taskIDs, assessor, userLoginId, entryState, flag);
                this.BindAnotherToDoList();
            }
            
        }
        /// <summary>
        /// 退回按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNoTop_Click(object sender, EventArgs e)
        {
            var taskIDs = this.GetSelectedTaskID();
            var assessor = CurrentUser.EmpName;
            var userLoginId = CurrentUser.LoginName;
            const string entryState = "Z";
            const string flag = "N";
            //三级审批。
            if (taskIDs != "")
            {
                new PurchaseSystem().BatchThirdAudit(taskIDs, assessor, userLoginId, entryState, flag);
                this.BindAnotherToDoList();
            }
        }
        #endregion

        #region method
        /// <summary>
        /// 绑定普通的代办事宜。
        /// </summary>
        private void BindToDoList()
        {
            var myTask = new Shmzh.Components.WorkFlow.Task();
            this.mzhDataGrid1.DataSource = myTask.GetAllTasksByUser(CurrentUser.LoginName).Tables[TaskData.TODOTASKLIST_TABLE];
            this.mzhDataGrid1.DataBind();
        }
        /// <summary>
        /// 绑定带批量处理的代办事宜。
        /// </summary>
        private void BindAnotherToDoList()
        {
            var myTask = new Shmzh.Components.WorkFlow.Task();
            this.mzhDataGrid2.DataSource = myTask.GetAllTasksByUser(CurrentUser.LoginName).Tables[0];
            this.mzhDataGrid2.DataBind();
        }
        /// <summary>
        /// 获取被选中的Task_ID.
        /// </summary>
        /// <returns>string:	选中的Task_ID串。</returns>
        private string GetSelectedTaskID()
        {
            var selectedTaskID = "";

            foreach (DataGridItem item in this.mzhDataGrid2.Items)
            {
                var chkItem = (CheckBox)item.FindControl("checkThis");
                if (chkItem.Checked)
                {
                   selectedTaskID += mzhDataGrid2.DataKeys[item.ItemIndex].ToString() + ",";
                }
            }
            return selectedTaskID;
        }
        #endregion

        protected void LkYesTop_Click(object sender, EventArgs e)
        {
            var taskIDs = this.GetSelectedTaskID();
            var assessor = CurrentUser.EmpName;
            var userLoginId = CurrentUser.LoginName;
            const string entryState = "T";
            const string flag = "Y";

            if (taskIDs != "")
            {
                new PurchaseSystem().BatchThirdAudit(taskIDs, assessor, userLoginId, entryState, flag);
                this.BindAnotherToDoList();
            }
        }

        protected void LkNoTop_Click(object sender, EventArgs e)
        {
            var taskIDs = this.GetSelectedTaskID();
            var assessor = CurrentUser.EmpName;
            var userLoginId = CurrentUser.LoginName;
            const string entryState = "Z";
            const string flag = "N";
            //三级审批。
            if (taskIDs != "")
            {
                new PurchaseSystem().BatchThirdAudit(taskIDs, assessor, userLoginId, entryState, flag);
                this.BindAnotherToDoList();
            }
        }
        
    }
}