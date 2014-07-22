namespace Shmzh.Windows.Forms.TreeListView
{
    partial class TreeListView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TreeListView
            // 
            this.FullRowSelect = true;
            this.HideSelection = false;
            this.SmallImageList = this.imageList1;
            this.View = System.Windows.Forms.View.Details;
            this.VisibleChanged += new System.EventHandler(this.TreeListView_VisibleChanged);
            this.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.TreeListView_AfterLabelEdit);
            this.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.TreeListView_ColumnClick);
            this.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TreeListView_ItemCheck);

        }
        #endregion
    }
}
