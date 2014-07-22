namespace Shmzh.Monitor.Forms
{
    partial class FrmGraphSchemaEdit
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTitleFontFamily = new System.Windows.Forms.ComboBox();
            this.txtInnerPaneGap = new System.Windows.Forms.TextBox();
            this.txtMargin = new System.Windows.Forms.TextBox();
            this.txtTitleFontSize = new System.Windows.Forms.TextBox();
            this.chkTitleVisible = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLegendFontSize = new System.Windows.Forms.TextBox();
            this.cbLegendPosition = new System.Windows.Forms.ComboBox();
            this.cbLegendFontFamily = new System.Windows.Forms.ComboBox();
            this.chkLegendIsHStack = new System.Windows.Forms.CheckBox();
            this.chkLegendIsShowSymbols = new System.Windows.Forms.CheckBox();
            this.chkLegendVisible = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDataType = new System.Windows.Forms.Label();
            this.chkIsValid = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdoV = new System.Windows.Forms.RadioButton();
            this.rdoH = new System.Windows.Forms.RadioButton();
            this.txtLayout1 = new System.Windows.Forms.TextBox();
            this.txtLayout2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnCancel);
            this.pnlButton.Controls.Add(this.btnSave);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButton.Location = new System.Drawing.Point(0, 358);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(551, 38);
            this.pnlButton.TabIndex = 29;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(464, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(383, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(551, 358);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRemark);
            this.tabPage1.Controls.Add(this.lblRemark);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.lblName);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(543, 333);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本属性";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(72, 60);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(463, 267);
            this.txtRemark.TabIndex = 2;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(27, 80);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 6;
            this.lblRemark.Text = "备注：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 26);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(463, 21);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(27, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "名称：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbTitleFontFamily);
            this.tabPage2.Controls.Add(this.txtInnerPaneGap);
            this.tabPage2.Controls.Add(this.txtMargin);
            this.tabPage2.Controls.Add(this.txtTitleFontSize);
            this.tabPage2.Controls.Add(this.chkTitleVisible);
            this.tabPage2.Controls.Add(this.txtTitle);
            this.tabPage2.Controls.Add(this.lblTitle);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.cbDataType);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.lblDataType);
            this.tabPage2.Controls.Add(this.chkIsValid);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(543, 333);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "高级属性";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(448, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "字体";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(333, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "字体大小";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(127, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "(选中为有效。只有有效的图才会在监控界面显示)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(190, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "(各个图之间的间距，默认为0。示例：2.5)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(190, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(347, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "(ALL 或者 左 上 右 下。示例1：10.5；示例2：10.5 0 10.5 0)";
            // 
            // cbTitleFontFamily
            // 
            this.cbTitleFontFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbTitleFontFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTitleFontFamily.FormattingEnabled = true;
            this.cbTitleFontFamily.Location = new System.Drawing.Point(402, 224);
            this.cbTitleFontFamily.MaxDropDownItems = 12;
            this.cbTitleFontFamily.MaxLength = 30;
            this.cbTitleFontFamily.Name = "cbTitleFontFamily";
            this.cbTitleFontFamily.Size = new System.Drawing.Size(121, 20);
            this.cbTitleFontFamily.TabIndex = 10;
            // 
            // txtInnerPaneGap
            // 
            this.txtInnerPaneGap.Location = new System.Drawing.Point(73, 165);
            this.txtInnerPaneGap.MaxLength = 3;
            this.txtInnerPaneGap.Name = "txtInnerPaneGap";
            this.txtInnerPaneGap.Size = new System.Drawing.Size(113, 21);
            this.txtInnerPaneGap.TabIndex = 7;
            // 
            // txtMargin
            // 
            this.txtMargin.Location = new System.Drawing.Point(73, 132);
            this.txtMargin.MaxLength = 30;
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.Size = new System.Drawing.Size(113, 21);
            this.txtMargin.TabIndex = 6;
            // 
            // txtTitleFontSize
            // 
            this.txtTitleFontSize.Location = new System.Drawing.Point(334, 224);
            this.txtTitleFontSize.MaxLength = 3;
            this.txtTitleFontSize.Name = "txtTitleFontSize";
            this.txtTitleFontSize.Size = new System.Drawing.Size(51, 21);
            this.txtTitleFontSize.TabIndex = 10;
            // 
            // chkTitleVisible
            // 
            this.chkTitleVisible.AutoSize = true;
            this.chkTitleVisible.Checked = true;
            this.chkTitleVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTitleVisible.Location = new System.Drawing.Point(273, 226);
            this.chkTitleVisible.Name = "chkTitleVisible";
            this.chkTitleVisible.Size = new System.Drawing.Size(48, 16);
            this.chkTitleVisible.TabIndex = 9;
            this.chkTitleVisible.Text = "可见";
            this.chkTitleVisible.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(73, 224);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(179, 21);
            this.txtTitle.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(9, 228);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(41, 12);
            this.lblTitle.TabIndex = 38;
            this.lblTitle.Text = "标题：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLegendFontSize);
            this.groupBox2.Controls.Add(this.cbLegendPosition);
            this.groupBox2.Controls.Add(this.cbLegendFontFamily);
            this.groupBox2.Controls.Add(this.chkLegendIsHStack);
            this.groupBox2.Controls.Add(this.chkLegendIsShowSymbols);
            this.groupBox2.Controls.Add(this.chkLegendVisible);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(5, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(532, 79);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图例";
            // 
            // txtLegendFontSize
            // 
            this.txtLegendFontSize.Location = new System.Drawing.Point(329, 18);
            this.txtLegendFontSize.MaxLength = 3;
            this.txtLegendFontSize.Name = "txtLegendFontSize";
            this.txtLegendFontSize.Size = new System.Drawing.Size(51, 21);
            this.txtLegendFontSize.TabIndex = 13;
            // 
            // cbLegendPosition
            // 
            this.cbLegendPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbLegendPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLegendPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLegendPosition.FormattingEnabled = true;
            this.cbLegendPosition.Location = new System.Drawing.Point(80, 17);
            this.cbLegendPosition.MaxDropDownItems = 12;
            this.cbLegendPosition.MaxLength = 20;
            this.cbLegendPosition.Name = "cbLegendPosition";
            this.cbLegendPosition.Size = new System.Drawing.Size(121, 20);
            this.cbLegendPosition.TabIndex = 11;
            // 
            // cbLegendFontFamily
            // 
            this.cbLegendFontFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbLegendFontFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLegendFontFamily.FormattingEnabled = true;
            this.cbLegendFontFamily.Location = new System.Drawing.Point(397, 18);
            this.cbLegendFontFamily.MaxDropDownItems = 12;
            this.cbLegendFontFamily.MaxLength = 30;
            this.cbLegendFontFamily.Name = "cbLegendFontFamily";
            this.cbLegendFontFamily.Size = new System.Drawing.Size(121, 20);
            this.cbLegendFontFamily.TabIndex = 14;
            // 
            // chkLegendIsHStack
            // 
            this.chkLegendIsHStack.AutoSize = true;
            this.chkLegendIsHStack.Checked = true;
            this.chkLegendIsHStack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLegendIsHStack.Location = new System.Drawing.Point(12, 51);
            this.chkLegendIsHStack.Name = "chkLegendIsHStack";
            this.chkLegendIsHStack.Size = new System.Drawing.Size(216, 16);
            this.chkLegendIsHStack.TabIndex = 15;
            this.chkLegendIsHStack.Text = "横向排列(选中为横向，不选为纵向)";
            this.chkLegendIsHStack.UseVisualStyleBackColor = true;
            // 
            // chkLegendIsShowSymbols
            // 
            this.chkLegendIsShowSymbols.AutoSize = true;
            this.chkLegendIsShowSymbols.Checked = true;
            this.chkLegendIsShowSymbols.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLegendIsShowSymbols.Location = new System.Drawing.Point(268, 48);
            this.chkLegendIsShowSymbols.Name = "chkLegendIsShowSymbols";
            this.chkLegendIsShowSymbols.Size = new System.Drawing.Size(90, 16);
            this.chkLegendIsShowSymbols.TabIndex = 16;
            this.chkLegendIsShowSymbols.Text = "显示 Symbol";
            this.chkLegendIsShowSymbols.UseVisualStyleBackColor = true;
            // 
            // chkLegendVisible
            // 
            this.chkLegendVisible.AutoSize = true;
            this.chkLegendVisible.Checked = true;
            this.chkLegendVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLegendVisible.Location = new System.Drawing.Point(268, 20);
            this.chkLegendVisible.Name = "chkLegendVisible";
            this.chkLegendVisible.Size = new System.Drawing.Size(48, 16);
            this.chkLegendVisible.TabIndex = 12;
            this.chkLegendVisible.Text = "可见";
            this.chkLegendVisible.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "显示位置：";
            // 
            // cbDataType
            // 
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Location = new System.Drawing.Point(73, 196);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(113, 20);
            this.cbDataType.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "间距：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "边距：";
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(9, 200);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(65, 12);
            this.lblDataType.TabIndex = 35;
            this.lblDataType.Text = "数据类型：";
            // 
            // chkIsValid
            // 
            this.chkIsValid.AutoSize = true;
            this.chkIsValid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsValid.Checked = true;
            this.chkIsValid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsValid.Location = new System.Drawing.Point(9, 105);
            this.chkIsValid.Name = "chkIsValid";
            this.chkIsValid.Size = new System.Drawing.Size(108, 16);
            this.chkIsValid.TabIndex = 5;
            this.chkIsValid.Text = "方案是否有效：";
            this.chkIsValid.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rdoV);
            this.groupBox1.Controls.Add(this.rdoH);
            this.groupBox1.Controls.Add(this.txtLayout1);
            this.groupBox1.Controls.Add(this.txtLayout2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 90);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "布局";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(117, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "(示例  分栏：1,2,1 比例：1,1,1)";
            // 
            // rdoV
            // 
            this.rdoV.AutoSize = true;
            this.rdoV.Checked = true;
            this.rdoV.Location = new System.Drawing.Point(65, 25);
            this.rdoV.Name = "rdoV";
            this.rdoV.Size = new System.Drawing.Size(47, 16);
            this.rdoV.TabIndex = 2;
            this.rdoV.TabStop = true;
            this.rdoV.Text = "纵向";
            this.rdoV.UseVisualStyleBackColor = true;
            this.rdoV.CheckedChanged += new System.EventHandler(this.rdoV_CheckedChanged);
            // 
            // rdoH
            // 
            this.rdoH.AutoSize = true;
            this.rdoH.Location = new System.Drawing.Point(10, 25);
            this.rdoH.Name = "rdoH";
            this.rdoH.Size = new System.Drawing.Size(47, 16);
            this.rdoH.TabIndex = 1;
            this.rdoH.Text = "横向";
            this.rdoH.UseVisualStyleBackColor = true;
            this.rdoH.CheckedChanged += new System.EventHandler(this.rdoH_CheckedChanged);
            // 
            // txtLayout1
            // 
            this.txtLayout1.Location = new System.Drawing.Point(48, 55);
            this.txtLayout1.Name = "txtLayout1";
            this.txtLayout1.Size = new System.Drawing.Size(95, 21);
            this.txtLayout1.TabIndex = 3;
            // 
            // txtLayout2
            // 
            this.txtLayout2.Location = new System.Drawing.Point(209, 55);
            this.txtLayout2.Name = "txtLayout2";
            this.txtLayout2.Size = new System.Drawing.Size(95, 21);
            this.txtLayout2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "比例：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "分栏：";
            // 
            // FrmGraphSchemaEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(551, 396);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGraphSchemaEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "方案编辑";
            this.Load += new System.EventHandler(this.FrmGraphSchemeEdit_Load);
            this.Shown += new System.EventHandler(this.FrmGraphSchemaEdit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTitleFontFamily;
        private System.Windows.Forms.TextBox txtInnerPaneGap;
        private System.Windows.Forms.TextBox txtMargin;
        private System.Windows.Forms.TextBox txtTitleFontSize;
        private System.Windows.Forms.CheckBox chkTitleVisible;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLegendFontSize;
        private System.Windows.Forms.ComboBox cbLegendPosition;
        private System.Windows.Forms.ComboBox cbLegendFontFamily;
        private System.Windows.Forms.CheckBox chkLegendIsHStack;
        private System.Windows.Forms.CheckBox chkLegendIsShowSymbols;
        private System.Windows.Forms.CheckBox chkLegendVisible;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.CheckBox chkIsValid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoV;
        private System.Windows.Forms.RadioButton rdoH;
        private System.Windows.Forms.TextBox txtLayout1;
        private System.Windows.Forms.TextBox txtLayout2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}