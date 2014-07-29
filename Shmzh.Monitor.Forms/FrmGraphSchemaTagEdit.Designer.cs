namespace Shmzh.Monitor.Forms
{
    partial class FrmGraphSchemaTagEdit
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
            this.lblSchemeItem = new System.Windows.Forms.Label();
            this.lblSchemaItem = new System.Windows.Forms.Label();
            this.lblTagId = new System.Windows.Forms.Label();
            this.lblTagName = new System.Windows.Forms.Label();
            this.lblCurveType = new System.Windows.Forms.Label();
            this.lblCurveColor = new System.Windows.Forms.Label();
            this.txtTagId = new System.Windows.Forms.TextBox();
            this.txtTagName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbCurveType = new System.Windows.Forms.ComboBox();
            this.lblLineWidth = new System.Windows.Forms.Label();
            this.txtLineWidth = new System.Windows.Forms.TextBox();
            this.panelLineWidth = new System.Windows.Forms.Panel();
            this.cbLineType = new System.Windows.Forms.ComboBox();
            this.txtSymbolSize = new System.Windows.Forms.TextBox();
            this.cbSymbolType = new System.Windows.Forms.ComboBox();
            this.lblSymbolColor = new System.Windows.Forms.Label();
            this.lblSymbolType = new System.Windows.Forms.Label();
            this.cp_SymbolColor = new Shmzh.Windows.Forms.Pickers.ColorPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSymbolSize = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelPeriod = new System.Windows.Forms.Panel();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.cp_CurveColor = new Shmzh.Windows.Forms.Pickers.ColorPicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelLineWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSchemeItem
            // 
            this.lblSchemeItem.AutoSize = true;
            this.lblSchemeItem.Location = new System.Drawing.Point(74, 9);
            this.lblSchemeItem.Name = "lblSchemeItem";
            this.lblSchemeItem.Size = new System.Drawing.Size(65, 12);
            this.lblSchemeItem.TabIndex = 3;
            this.lblSchemeItem.Text = "方案项名称";
            // 
            // lblSchemaItem
            // 
            this.lblSchemaItem.AutoSize = true;
            this.lblSchemaItem.Location = new System.Drawing.Point(11, 10);
            this.lblSchemaItem.Name = "lblSchemaItem";
            this.lblSchemaItem.Size = new System.Drawing.Size(53, 12);
            this.lblSchemaItem.TabIndex = 2;
            this.lblSchemaItem.Text = "方案项：";
            // 
            // lblTagId
            // 
            this.lblTagId.AutoSize = true;
            this.lblTagId.Location = new System.Drawing.Point(11, 70);
            this.lblTagId.Name = "lblTagId";
            this.lblTagId.Size = new System.Drawing.Size(65, 12);
            this.lblTagId.TabIndex = 4;
            this.lblTagId.Text = "指    标：";
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Location = new System.Drawing.Point(11, 37);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(65, 12);
            this.lblTagName.TabIndex = 5;
            this.lblTagName.Text = "指标名称：";
            // 
            // lblCurveType
            // 
            this.lblCurveType.AutoSize = true;
            this.lblCurveType.Location = new System.Drawing.Point(11, 136);
            this.lblCurveType.Name = "lblCurveType";
            this.lblCurveType.Size = new System.Drawing.Size(65, 12);
            this.lblCurveType.TabIndex = 6;
            this.lblCurveType.Text = "曲线类型：";
            // 
            // lblCurveColor
            // 
            this.lblCurveColor.AutoSize = true;
            this.lblCurveColor.Location = new System.Drawing.Point(11, 103);
            this.lblCurveColor.Name = "lblCurveColor";
            this.lblCurveColor.Size = new System.Drawing.Size(65, 12);
            this.lblCurveColor.TabIndex = 7;
            this.lblCurveColor.Text = "曲线颜色：";
            // 
            // txtTagId
            // 
            this.txtTagId.Location = new System.Drawing.Point(76, 66);
            this.txtTagId.MaxLength = 500;
            this.txtTagId.Name = "txtTagId";
            this.txtTagId.Size = new System.Drawing.Size(196, 21);
            this.txtTagId.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtTagId, "指标Id或指标Id表达式，每个指标Id\r\n都要以中括号“[]”包括。");
            // 
            // txtTagName
            // 
            this.txtTagName.Location = new System.Drawing.Point(76, 33);
            this.txtTagName.Name = "txtTagName";
            this.txtTagName.Size = new System.Drawing.Size(196, 21);
            this.txtTagName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(68, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&S.保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(170, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&C.取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbCurveType
            // 
            this.cbCurveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurveType.FormattingEnabled = true;
            this.cbCurveType.Location = new System.Drawing.Point(76, 132);
            this.cbCurveType.Name = "cbCurveType";
            this.cbCurveType.Size = new System.Drawing.Size(196, 20);
            this.cbCurveType.TabIndex = 4;
            this.cbCurveType.SelectedIndexChanged += new System.EventHandler(this.cbCurveType_SelectedIndexChanged);
            // 
            // lblLineWidth
            // 
            this.lblLineWidth.AutoSize = true;
            this.lblLineWidth.Location = new System.Drawing.Point(5, 10);
            this.lblLineWidth.Name = "lblLineWidth";
            this.lblLineWidth.Size = new System.Drawing.Size(29, 12);
            this.lblLineWidth.TabIndex = 17;
            this.lblLineWidth.Text = "线宽";
            // 
            // txtLineWidth
            // 
            this.txtLineWidth.Location = new System.Drawing.Point(66, 7);
            this.txtLineWidth.Name = "txtLineWidth";
            this.txtLineWidth.Size = new System.Drawing.Size(23, 21);
            this.txtLineWidth.TabIndex = 5;
            this.txtLineWidth.Text = "1";
            // 
            // panelLineWidth
            // 
            this.panelLineWidth.AutoSize = true;
            this.panelLineWidth.Controls.Add(this.cbLineType);
            this.panelLineWidth.Controls.Add(this.txtSymbolSize);
            this.panelLineWidth.Controls.Add(this.cbSymbolType);
            this.panelLineWidth.Controls.Add(this.lblSymbolColor);
            this.panelLineWidth.Controls.Add(this.lblSymbolType);
            this.panelLineWidth.Controls.Add(this.cp_SymbolColor);
            this.panelLineWidth.Controls.Add(this.label1);
            this.panelLineWidth.Controls.Add(this.lblLineWidth);
            this.panelLineWidth.Controls.Add(this.txtLineWidth);
            this.panelLineWidth.Controls.Add(this.lblSymbolSize);
            this.panelLineWidth.Location = new System.Drawing.Point(9, 159);
            this.panelLineWidth.Name = "panelLineWidth";
            this.panelLineWidth.Size = new System.Drawing.Size(273, 91);
            this.panelLineWidth.TabIndex = 19;
            // 
            // cbLineType
            // 
            this.cbLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLineType.FormattingEnabled = true;
            this.cbLineType.Location = new System.Drawing.Point(165, 3);
            this.cbLineType.Name = "cbLineType";
            this.cbLineType.Size = new System.Drawing.Size(98, 20);
            this.cbLineType.TabIndex = 6;
            // 
            // txtSymbolSize
            // 
            this.txtSymbolSize.Location = new System.Drawing.Point(239, 36);
            this.txtSymbolSize.Name = "txtSymbolSize";
            this.txtSymbolSize.Size = new System.Drawing.Size(23, 21);
            this.txtSymbolSize.TabIndex = 8;
            this.txtSymbolSize.Text = " ";
            // 
            // cbSymbolType
            // 
            this.cbSymbolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSymbolType.FormattingEnabled = true;
            this.cbSymbolType.Location = new System.Drawing.Point(66, 35);
            this.cbSymbolType.Name = "cbSymbolType";
            this.cbSymbolType.Size = new System.Drawing.Size(98, 20);
            this.cbSymbolType.TabIndex = 7;
            // 
            // lblSymbolColor
            // 
            this.lblSymbolColor.AutoSize = true;
            this.lblSymbolColor.Location = new System.Drawing.Point(2, 68);
            this.lblSymbolColor.Name = "lblSymbolColor";
            this.lblSymbolColor.Size = new System.Drawing.Size(53, 12);
            this.lblSymbolColor.TabIndex = 19;
            this.lblSymbolColor.Text = "标记颜色";
            // 
            // lblSymbolType
            // 
            this.lblSymbolType.AutoSize = true;
            this.lblSymbolType.Location = new System.Drawing.Point(3, 39);
            this.lblSymbolType.Name = "lblSymbolType";
            this.lblSymbolType.Size = new System.Drawing.Size(53, 12);
            this.lblSymbolType.TabIndex = 19;
            this.lblSymbolType.Text = "节点标记";
            // 
            // cp_SymbolColor
            // 
            this.cp_SymbolColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cp_SymbolColor.Location = new System.Drawing.Point(66, 62);
            this.cp_SymbolColor.Name = "cp_SymbolColor";
            this.cp_SymbolColor.Size = new System.Drawing.Size(196, 21);
            this.cp_SymbolColor.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "曲线样式";
            // 
            // lblSymbolSize
            // 
            this.lblSymbolSize.AutoSize = true;
            this.lblSymbolSize.Location = new System.Drawing.Point(177, 39);
            this.lblSymbolSize.Name = "lblSymbolSize";
            this.lblSymbolSize.Size = new System.Drawing.Size(53, 12);
            this.lblSymbolSize.TabIndex = 22;
            this.lblSymbolSize.Text = "标记大小";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelPeriod
            // 
            this.panelPeriod.AutoSize = true;
            this.panelPeriod.Controls.Add(this.lblPeriod);
            this.panelPeriod.Controls.Add(this.txtPeriod);
            this.panelPeriod.Location = new System.Drawing.Point(9, 253);
            this.panelPeriod.Name = "panelPeriod";
            this.panelPeriod.Size = new System.Drawing.Size(273, 32);
            this.panelPeriod.TabIndex = 19;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(5, 10);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(53, 12);
            this.lblPeriod.TabIndex = 17;
            this.lblPeriod.Text = "均线周期";
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(66, 7);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(29, 21);
            this.txtPeriod.TabIndex = 10;
            this.txtPeriod.Text = "0";
            // 
            // cp_CurveColor
            // 
            this.cp_CurveColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cp_CurveColor.Location = new System.Drawing.Point(75, 99);
            this.cp_CurveColor.Name = "cp_CurveColor";
            this.cp_CurveColor.Size = new System.Drawing.Size(196, 21);
            this.cp_CurveColor.TabIndex = 3;
            // 
            // FrmGraphSchemaTagEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 321);
            this.Controls.Add(this.panelPeriod);
            this.Controls.Add(this.panelLineWidth);
            this.Controls.Add(this.cbCurveType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cp_CurveColor);
            this.Controls.Add(this.txtTagName);
            this.Controls.Add(this.txtTagId);
            this.Controls.Add(this.lblCurveColor);
            this.Controls.Add(this.lblCurveType);
            this.Controls.Add(this.lblTagName);
            this.Controls.Add(this.lblTagId);
            this.Controls.Add(this.lblSchemeItem);
            this.Controls.Add(this.lblSchemaItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGraphSchemaTagEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmGraphSchemaTagEdit";
            this.Load += new System.EventHandler(this.FrmGraphSchemaTagEdit_Load);
            this.panelLineWidth.ResumeLayout(false);
            this.panelLineWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelPeriod.ResumeLayout(false);
            this.panelPeriod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }        

        #endregion

        private System.Windows.Forms.Label lblSchemeItem;
        private System.Windows.Forms.Label lblSchemaItem;
        private System.Windows.Forms.Label lblTagId;
        private System.Windows.Forms.Label lblTagName;
        private System.Windows.Forms.Label lblCurveType;
        private System.Windows.Forms.Label lblCurveColor;
        private System.Windows.Forms.TextBox txtTagId;
        private System.Windows.Forms.TextBox txtTagName;
        private Shmzh.Windows.Forms.Pickers.ColorPicker cp_CurveColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbCurveType;
        private System.Windows.Forms.Label lblLineWidth;
        private System.Windows.Forms.TextBox txtLineWidth;
        private System.Windows.Forms.Panel panelLineWidth;
        private System.Windows.Forms.Label lblSymbolType;
        private System.Windows.Forms.TextBox txtSymbolSize;
        private System.Windows.Forms.ComboBox cbSymbolType;
        private System.Windows.Forms.Label lblSymbolSize;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panelPeriod;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.ComboBox cbLineType;
        private System.Windows.Forms.Label label1;
        private Shmzh.Windows.Forms.Pickers.ColorPicker cp_SymbolColor;
        private System.Windows.Forms.Label lblSymbolColor;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}