namespace Shmzh.Monitor.Forms
{
    partial class FrmQuickGraphSchema
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
            this.btnSelectTas = new System.Windows.Forms.Button();
            this.cbTags = new System.Windows.Forms.ComboBox();
            this.cbCurveType = new System.Windows.Forms.ComboBox();
            this.lblCurveType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panelPeriod = new System.Windows.Forms.Panel();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.panelLineWidth = new System.Windows.Forms.Panel();
            this.cbLineType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPeriod.SuspendLayout();
            this.panelLineWidth.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectTas
            // 
            this.btnSelectTas.Location = new System.Drawing.Point(312, 12);
            this.btnSelectTas.Name = "btnSelectTas";
            this.btnSelectTas.Size = new System.Drawing.Size(42, 23);
            this.btnSelectTas.TabIndex = 3;
            this.btnSelectTas.Text = "选择";
            this.btnSelectTas.UseVisualStyleBackColor = true;
            this.btnSelectTas.Click += new System.EventHandler(this.btnSelectTas_Click);
            // 
            // cbTags
            // 
            this.cbTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTags.FormattingEnabled = true;
            this.cbTags.Location = new System.Drawing.Point(82, 14);
            this.cbTags.Name = "cbTags";
            this.cbTags.Size = new System.Drawing.Size(224, 20);
            this.cbTags.TabIndex = 4;
            // 
            // cbCurveType
            // 
            this.cbCurveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurveType.FormattingEnabled = true;
            this.cbCurveType.Location = new System.Drawing.Point(82, 48);
            this.cbCurveType.Name = "cbCurveType";
            this.cbCurveType.Size = new System.Drawing.Size(224, 20);
            this.cbCurveType.TabIndex = 18;
            this.cbCurveType.SelectedIndexChanged += new System.EventHandler(this.cbCurveType_SelectedIndexChanged);
            // 
            // lblCurveType
            // 
            this.lblCurveType.AutoSize = true;
            this.lblCurveType.Location = new System.Drawing.Point(17, 52);
            this.lblCurveType.Name = "lblCurveType";
            this.lblCurveType.Size = new System.Drawing.Size(65, 12);
            this.lblCurveType.TabIndex = 17;
            this.lblCurveType.Text = "曲线类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "指标名：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(148, 123);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "生成曲线";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panelPeriod
            // 
            this.panelPeriod.AutoSize = true;
            this.panelPeriod.Controls.Add(this.lblPeriod);
            this.panelPeriod.Controls.Add(this.txtPeriod);
            this.panelPeriod.Location = new System.Drawing.Point(204, 78);
            this.panelPeriod.Name = "panelPeriod";
            this.panelPeriod.Size = new System.Drawing.Size(112, 32);
            this.panelPeriod.TabIndex = 21;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(5, 10);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(65, 12);
            this.lblPeriod.TabIndex = 17;
            this.lblPeriod.Text = "均线周期：";
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(73, 6);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(29, 21);
            this.txtPeriod.TabIndex = 18;
            this.txtPeriod.Text = "10";
            // 
            // panelLineWidth
            // 
            this.panelLineWidth.AutoSize = true;
            this.panelLineWidth.Controls.Add(this.cbLineType);
            this.panelLineWidth.Controls.Add(this.label3);
            this.panelLineWidth.Location = new System.Drawing.Point(13, 78);
            this.panelLineWidth.Name = "panelLineWidth";
            this.panelLineWidth.Size = new System.Drawing.Size(177, 32);
            this.panelLineWidth.TabIndex = 20;
            // 
            // cbLineType
            // 
            this.cbLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLineType.FormattingEnabled = true;
            this.cbLineType.Location = new System.Drawing.Point(69, 6);
            this.cbLineType.Name = "cbLineType";
            this.cbLineType.Size = new System.Drawing.Size(98, 20);
            this.cbLineType.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "曲线样式：";
            // 
            // FrmQuickGraphSchema
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 156);
            this.Controls.Add(this.panelPeriod);
            this.Controls.Add(this.panelLineWidth);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbCurveType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCurveType);
            this.Controls.Add(this.cbTags);
            this.Controls.Add(this.btnSelectTas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickGraphSchema";
            this.ShowIcon = false;
            this.Text = "快速生成指标曲线方案";
            this.Load += new System.EventHandler(this.FrmQuickGraphSchema_Load);
            this.panelPeriod.ResumeLayout(false);
            this.panelPeriod.PerformLayout();
            this.panelLineWidth.ResumeLayout(false);
            this.panelLineWidth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectTas;
        private System.Windows.Forms.ComboBox cbTags;
        private System.Windows.Forms.ComboBox cbCurveType;
        private System.Windows.Forms.Label lblCurveType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panelPeriod;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.Panel panelLineWidth;
        private System.Windows.Forms.ComboBox cbLineType;
        private System.Windows.Forms.Label label3;


    }
}