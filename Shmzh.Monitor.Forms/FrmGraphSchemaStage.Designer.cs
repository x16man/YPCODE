namespace Shmzh.Monitor.Forms
{
    partial class FrmGraphSchemaStage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDrag = new System.Windows.Forms.Button();
            this.graph = new ZedGraph.ZedGraphControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panelMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(658, 457);
            this.panelMain.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.LimeGreen;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDrag);
            this.splitContainer1.Panel1.Controls.Add(this.graph);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(658, 457);
            this.splitContainer1.SplitterDistance = 437;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnDrag
            // 
            this.btnDrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrag.BackColor = System.Drawing.Color.Transparent;
            this.btnDrag.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDrag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.next;
            this.btnDrag.Location = new System.Drawing.Point(414, 1);
            this.btnDrag.Name = "btnDrag";
            this.btnDrag.Size = new System.Drawing.Size(24, 20);
            this.btnDrag.TabIndex = 2;
            this.btnDrag.UseVisualStyleBackColor = true;
            this.btnDrag.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // graph
            // 
            this.graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graph.GuideLineColor = System.Drawing.Color.Empty;
            this.graph.Location = new System.Drawing.Point(0, 0);
            this.graph.Name = "graph";
            this.graph.ScrollGrace = 0;
            this.graph.ScrollMaxX = 0;
            this.graph.ScrollMaxY = 0;
            this.graph.ScrollMaxY2 = 0;
            this.graph.ScrollMinX = 0;
            this.graph.ScrollMinY = 0;
            this.graph.ScrollMinY2 = 0;
            this.graph.Size = new System.Drawing.Size(437, 457);
            this.graph.TabIndex = 1;
            this.graph.ContextMenuBuilder += new ZedGraph.ZedGraphControl.ContextMenuBuilderEventHandler(this.graph_ContextMenuBuilder);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(48, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(219, 457);
            this.tabControl1.TabIndex = 0;
            // 
            // FrmGraphSchemaStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 457);
            this.Controls.Add(this.panelMain);
            this.Name = "FrmGraphSchemaStage";
            this.Text = "FrmGraphSchemaStage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGraphSchemaStage_FormClosing);
            this.panelMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl graph;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnDrag;
    }
}