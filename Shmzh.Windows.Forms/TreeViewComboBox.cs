using System;
using System.Drawing;
using System.Windows.Forms;
namespace Shmzh.Windows.Forms
{
    public class TreeViewComboBox : ComboBox
    {
        private const int WM_LBUTTONDOWN = 0x201, WM_LBUTTONDBLCLK = 0x203;
        readonly ToolStripControlHost treeViewHost;
        ToolStripDropDown DropDown;

        public TreeViewComboBox()
        {
            this.AutoSize = false;
            var treeView = new TreeView();
            treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);
            treeView.BorderStyle = BorderStyle.None;
            

            treeViewHost = new ToolStripControlHost(treeView);
            treeViewHost.Validated += new EventHandler(treeViewHost_Validated);
            //treeViewHost.AutoSize = true;
            
            DropDown = new ResizableToolStripDropDown { Width = this.Width, Height=100,Padding = new Padding(10,10,10,10),BackColor = Color.ForestGreen};
            DropDown.Items.Add(treeViewHost);
            //treeViewHost.Dock = DockStyle.Fill;
        }

        void treeViewHost_Validated(object sender, EventArgs e)
        {
            
        }
        

        public void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.SelectedItem = InnerTreeView.SelectedNode;
            this.SelectedText = InnerTreeView.SelectedNode.Text;
            this.SelectedValue = InnerTreeView.SelectedNode.Tag;
            this.Text = InnerTreeView.SelectedNode.Text;
            
            DropDown.Close();
        }
        public TreeView InnerTreeView
        {
            get { return treeViewHost.Control as TreeView; }
        }
        private void ShowDropDown()
        {
            if (DropDown != null)
            {
                treeViewHost.Size = new System.Drawing.Size(DropDownWidth - 30, DropDownHeight-30);
                DropDown.Show(this, 0, this.Height);


                if(this.SelectedItem is TreeNode)
                {
                    var selectedNode = this.SelectedItem as TreeNode;
                    selectedNode.EnsureVisible();
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                ShowDropDown();
                return;
            }
            base.WndProc(ref m);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DropDown != null)
                {
                    DropDown.Dispose();
                    DropDown = null;
                }
            }
            base.Dispose(disposing);
        }
        

    }



}
