using System;
using System.Threading;

namespace Shmzh.Monitor.Forms
{
    partial class FrmDailyTask
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
            if (this.timerClock != null)
            {
                this.timerClock.Stop();
                this.timerClock.Dispose();
            }
            dailyTaskConfig = null;
            configFile = null;
            backInfo = null;
            dayDataSource = null;
            weekDataSource = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.txtHideFocus = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.gvWeek = new System.Windows.Forms.DataGridView();
            this.colIDWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriorityWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStateWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrincipalWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlanFinishDateWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMasterWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTimeWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDayList = new System.Windows.Forms.Label();
            this.lblWeekList = new System.Windows.Forms.Label();
            this.gvDay = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlanFinishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.tblCutline = new System.Windows.Forms.TableLayoutPanel();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.panelTitle.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDay)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.txtHideFocus);
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(699, 50);
            this.panelTitle.TabIndex = 1;
            // 
            // txtHideFocus
            // 
            this.txtHideFocus.Location = new System.Drawing.Point(13, -200);
            this.txtHideFocus.Name = "txtHideFocus";
            this.txtHideFocus.Size = new System.Drawing.Size(100, 21);
            this.txtHideFocus.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(699, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "中控室日常任务进行图";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.gvWeek);
            this.panelMain.Controls.Add(this.lblDate);
            this.panelMain.Controls.Add(this.lblDayList);
            this.panelMain.Controls.Add(this.lblWeekList);
            this.panelMain.Controls.Add(this.gvDay);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 50);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(699, 435);
            this.panelMain.TabIndex = 2;
            // 
            // gvWeek
            // 
            this.gvWeek.AllowUserToAddRows = false;
            this.gvWeek.AllowUserToDeleteRows = false;
            this.gvWeek.AllowUserToResizeRows = false;
            this.gvWeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvWeek.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvWeek.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvWeek.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvWeek.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.gvWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvWeek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIDWeek,
            this.colNameWeek,
            this.colPriorityWeek,
            this.colStateWeek,
            this.colPrincipalWeek,
            this.colPlanFinishDateWeek,
            this.colMasterWeek,
            this.colCreateTimeWeek});
            this.gvWeek.EnableHeadersVisualStyles = false;
            this.gvWeek.Location = new System.Drawing.Point(9, 225);
            this.gvWeek.Name = "gvWeek";
            this.gvWeek.ReadOnly = true;
            this.gvWeek.RowHeadersVisible = false;
            this.gvWeek.RowTemplate.Height = 28;
            this.gvWeek.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gvWeek.Size = new System.Drawing.Size(681, 98);
            this.gvWeek.TabIndex = 4;
            this.gvWeek.TabStop = false;
            this.gvWeek.SizeChanged += new System.EventHandler(this.gvWeek_SizeChanged);
            // 
            // colIDWeek
            // 
            this.colIDWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIDWeek.DataPropertyName = "ID";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIDWeek.DefaultCellStyle = dataGridViewCellStyle17;
            this.colIDWeek.FillWeight = 50F;
            this.colIDWeek.HeaderText = "编号";
            this.colIDWeek.Name = "colIDWeek";
            this.colIDWeek.ReadOnly = true;
            this.colIDWeek.Width = 54;
            // 
            // colNameWeek
            // 
            this.colNameWeek.DataPropertyName = "Name";
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colNameWeek.DefaultCellStyle = dataGridViewCellStyle18;
            this.colNameWeek.FillWeight = 200F;
            this.colNameWeek.HeaderText = "任务名称";
            this.colNameWeek.Name = "colNameWeek";
            this.colNameWeek.ReadOnly = true;
            // 
            // colPriorityWeek
            // 
            this.colPriorityWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPriorityWeek.DataPropertyName = "Priority";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPriorityWeek.DefaultCellStyle = dataGridViewCellStyle19;
            this.colPriorityWeek.FillWeight = 50F;
            this.colPriorityWeek.HeaderText = "优先级";
            this.colPriorityWeek.Name = "colPriorityWeek";
            this.colPriorityWeek.ReadOnly = true;
            this.colPriorityWeek.Width = 66;
            // 
            // colStateWeek
            // 
            this.colStateWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStateWeek.DataPropertyName = "State";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStateWeek.DefaultCellStyle = dataGridViewCellStyle20;
            this.colStateWeek.FillWeight = 60F;
            this.colStateWeek.HeaderText = "当前状态";
            this.colStateWeek.Name = "colStateWeek";
            this.colStateWeek.ReadOnly = true;
            this.colStateWeek.Width = 78;
            // 
            // colPrincipalWeek
            // 
            this.colPrincipalWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPrincipalWeek.DataPropertyName = "Principal";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPrincipalWeek.DefaultCellStyle = dataGridViewCellStyle21;
            this.colPrincipalWeek.FillWeight = 70F;
            this.colPrincipalWeek.HeaderText = "指定负责人";
            this.colPrincipalWeek.Name = "colPrincipalWeek";
            this.colPrincipalWeek.ReadOnly = true;
            this.colPrincipalWeek.Width = 90;
            // 
            // colPlanFinishDateWeek
            // 
            this.colPlanFinishDateWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPlanFinishDateWeek.DataPropertyName = "PlanFinishDate";
            this.colPlanFinishDateWeek.FillWeight = 90F;
            this.colPlanFinishDateWeek.HeaderText = "限定时间";
            this.colPlanFinishDateWeek.Name = "colPlanFinishDateWeek";
            this.colPlanFinishDateWeek.ReadOnly = true;
            this.colPlanFinishDateWeek.Width = 78;
            // 
            // colMasterWeek
            // 
            this.colMasterWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMasterWeek.DataPropertyName = "Master";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMasterWeek.DefaultCellStyle = dataGridViewCellStyle22;
            this.colMasterWeek.FillWeight = 60F;
            this.colMasterWeek.HeaderText = "发布人";
            this.colMasterWeek.Name = "colMasterWeek";
            this.colMasterWeek.ReadOnly = true;
            this.colMasterWeek.Width = 66;
            // 
            // colCreateTimeWeek
            // 
            this.colCreateTimeWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCreateTimeWeek.DataPropertyName = "CreateTime";
            this.colCreateTimeWeek.FillWeight = 90F;
            this.colCreateTimeWeek.HeaderText = "发布时间";
            this.colCreateTimeWeek.Name = "colCreateTimeWeek";
            this.colCreateTimeWeek.ReadOnly = true;
            this.colCreateTimeWeek.Width = 78;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(471, 7);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(161, 12);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "当前时间：2009-05-18 12:40";
            // 
            // lblDayList
            // 
            this.lblDayList.AutoSize = true;
            this.lblDayList.Location = new System.Drawing.Point(9, 7);
            this.lblDayList.Name = "lblDayList";
            this.lblDayList.Size = new System.Drawing.Size(125, 12);
            this.lblDayList.TabIndex = 0;
            this.lblDayList.Text = "最近24小时任务列表：";
            // 
            // lblWeekList
            // 
            this.lblWeekList.AutoSize = true;
            this.lblWeekList.Location = new System.Drawing.Point(9, 202);
            this.lblWeekList.Name = "lblWeekList";
            this.lblWeekList.Size = new System.Drawing.Size(143, 12);
            this.lblWeekList.TabIndex = 3;
            this.lblWeekList.Text = "最近1周未完成任务列表：";
            // 
            // gvDay
            // 
            this.gvDay.AllowUserToAddRows = false;
            this.gvDay.AllowUserToDeleteRows = false;
            this.gvDay.AllowUserToResizeRows = false;
            this.gvDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDay.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvDay.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.gvDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvDay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colPriority,
            this.colState,
            this.colPrincipal,
            this.colPlanFinishDate,
            this.colMaster,
            this.colCreateTime});
            this.gvDay.EnableHeadersVisualStyles = false;
            this.gvDay.Location = new System.Drawing.Point(9, 22);
            this.gvDay.Name = "gvDay";
            this.gvDay.ReadOnly = true;
            this.gvDay.RowHeadersVisible = false;
            this.gvDay.RowTemplate.Height = 23;
            this.gvDay.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gvDay.Size = new System.Drawing.Size(681, 116);
            this.gvDay.TabIndex = 2;
            this.gvDay.SizeChanged += new System.EventHandler(this.gvDay_SizeChanged);
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colID.DataPropertyName = "ID";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colID.DefaultCellStyle = dataGridViewCellStyle24;
            this.colID.FillWeight = 50F;
            this.colID.HeaderText = "编号";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 54;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.DefaultCellStyle = dataGridViewCellStyle25;
            this.colName.FillWeight = 200F;
            this.colName.HeaderText = "任务名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colPriority
            // 
            this.colPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPriority.DataPropertyName = "Priority";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPriority.DefaultCellStyle = dataGridViewCellStyle26;
            this.colPriority.FillWeight = 50F;
            this.colPriority.HeaderText = "优先级";
            this.colPriority.Name = "colPriority";
            this.colPriority.ReadOnly = true;
            this.colPriority.Width = 66;
            // 
            // colState
            // 
            this.colState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colState.DataPropertyName = "State";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colState.DefaultCellStyle = dataGridViewCellStyle27;
            this.colState.FillWeight = 60F;
            this.colState.HeaderText = "当前状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            this.colState.Width = 78;
            // 
            // colPrincipal
            // 
            this.colPrincipal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPrincipal.DataPropertyName = "Principal";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colPrincipal.DefaultCellStyle = dataGridViewCellStyle28;
            this.colPrincipal.FillWeight = 70F;
            this.colPrincipal.HeaderText = "指定负责人";
            this.colPrincipal.Name = "colPrincipal";
            this.colPrincipal.ReadOnly = true;
            this.colPrincipal.Width = 90;
            // 
            // colPlanFinishDate
            // 
            this.colPlanFinishDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPlanFinishDate.DataPropertyName = "PlanFinishDate";
            this.colPlanFinishDate.FillWeight = 90F;
            this.colPlanFinishDate.HeaderText = "限定时间";
            this.colPlanFinishDate.Name = "colPlanFinishDate";
            this.colPlanFinishDate.ReadOnly = true;
            this.colPlanFinishDate.Width = 78;
            // 
            // colMaster
            // 
            this.colMaster.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMaster.DataPropertyName = "Master";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMaster.DefaultCellStyle = dataGridViewCellStyle29;
            this.colMaster.FillWeight = 60F;
            this.colMaster.HeaderText = "发布人";
            this.colMaster.Name = "colMaster";
            this.colMaster.ReadOnly = true;
            this.colMaster.Width = 66;
            // 
            // colCreateTime
            // 
            this.colCreateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCreateTime.DataPropertyName = "CreateTime";
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colCreateTime.DefaultCellStyle = dataGridViewCellStyle30;
            this.colCreateTime.FillWeight = 90F;
            this.colCreateTime.HeaderText = "发布时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            this.colCreateTime.Width = 78;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.tblCutline);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 443);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(699, 42);
            this.panelFooter.TabIndex = 3;
            // 
            // tblCutline
            // 
            this.tblCutline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tblCutline.AutoSize = true;
            this.tblCutline.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblCutline.ColumnCount = 2;
            this.tblCutline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCutline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCutline.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tblCutline.Location = new System.Drawing.Point(469, 13);
            this.tblCutline.Name = "tblCutline";
            this.tblCutline.RowCount = 1;
            this.tblCutline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCutline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCutline.Size = new System.Drawing.Size(215, 21);
            this.tblCutline.TabIndex = 0;
            // 
            // timerUpdate
            // 
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // FrmDailyTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(699, 485);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTitle);
            this.Name = "FrmDailyTask";
            this.Text = "中控室日常任务进行图";
            this.Load += new System.EventHandler(this.FrmDailyTask_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDay)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblDayList;
        private System.Windows.Forms.DataGridView gvDay;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblWeekList;
        private System.Windows.Forms.DataGridView gvWeek;
        private System.Windows.Forms.TableLayoutPanel tblCutline;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanFinishDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriorityWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStateWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrincipalWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanFinishDateWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMasterWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTimeWeek;
        private System.Windows.Forms.TextBox txtHideFocus;
    }
}