using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using Shmzh.Components.SystemComponent;
using Shmzh.Monitor.Gadget;
using Shmzh.Project.Data;
using Shmzh.Project.Entity;
using Timer = System.Windows.Forms.Timer;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmDailyTask : Form, IBaseForm
    {
        #region Fields
        private DailyTaskConfig dailyTaskConfig;
        private String configFile = "DailyTask.xml";
        private BackGroundInfo backInfo;        
        private List<TempTaskInfo> dayDataSource;
        private List<TempTaskInfo> weekDataSource;
        private System.Timers.Timer timerClock;
        private Timer timerDayPgdn;
        private Timer timerWeekPgdn;
        private Boolean isLoadingData = false;

        private delegate void GetDataSourceHandler();
        #endregion

        #region Constructor
        public FrmDailyTask()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.ResizeRedraw, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            this.BackColor = Color.Transparent;

            this.gvDay.AutoGenerateColumns = false;
            this.gvWeek.AutoGenerateColumns = false;
        }

        public FrmDailyTask(String configFile, Int32 updateTime):this()
        {
            this.configFile = configFile;

            if (updateTime > 0)
            {
                timerUpdate.Interval = updateTime * 1000;
                timerUpdate.Start();
            }

            dailyTaskConfig = LoadConfig();

            #region 设置配置。
            Label label;
            foreach (DailyTaskConfig.PriorityInfo priorityInfo in dailyTaskConfig.PriorityList)
            {
                label = new Label();
                label.Margin = new Padding(0);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = priorityInfo.Name;
                label.BackColor = priorityInfo.BackColor;
                label.ForeColor = Color.Black;
                label.AutoEllipsis = true;
                tblCutline.Controls.Add(label);
            }

            foreach (DailyTaskConfig.StateInfo stateInfo in dailyTaskConfig.StateList)
            {
                label = new Label();
                label.Margin = new Padding(0);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = stateInfo.Name;
                label.BackColor = Color.White;
                label.ForeColor = stateInfo.ForeColor;
                label.AutoEllipsis = true;
                tblCutline.Controls.Add(label);
            }

            FontStyle fs = dailyTaskConfig.TitleIsBold ? FontStyle.Bold : FontStyle.Regular;
            if (!String.IsNullOrEmpty(dailyTaskConfig.Title)) this.lblTitle.Text = dailyTaskConfig.Title;
            this.lblTitle.ForeColor = dailyTaskConfig.TitleForeColor;
            this.lblTitle.Font = new Font(dailyTaskConfig.TitleFont, dailyTaskConfig.TitleFontSize, fs, GraphicsUnit.Point);

            fs = dailyTaskConfig.LabelIsBold ? FontStyle.Bold : FontStyle.Regular;
            this.lblDayList.Text = String.Format("{0}：", dailyTaskConfig.DayListConfig.Title);
            this.lblWeekList.Text = String.Format("{0}：", dailyTaskConfig.WeekListConfig.Title);
            this.lblDayList.ForeColor =
                this.lblDate.ForeColor = this.lblWeekList.ForeColor = dailyTaskConfig.LabelForeColor;
            this.lblDayList.Font =
                this.lblDate.Font =
                this.lblWeekList.Font =
                new Font(dailyTaskConfig.LabelFont, dailyTaskConfig.LabelFontSize, fs, GraphicsUnit.Point);

            gvDay.ColumnHeadersDefaultCellStyle.BackColor = dailyTaskConfig.DayListConfig.HeaderBackColor;
            gvDay.ColumnHeadersDefaultCellStyle.ForeColor = dailyTaskConfig.DayListConfig.HeaderForeColor;
            fs = dailyTaskConfig.DayListConfig.HeaderIsBold ? FontStyle.Bold : FontStyle.Regular;
            gvDay.ColumnHeadersDefaultCellStyle.Font = new Font(dailyTaskConfig.DayListConfig.HeaderFont, dailyTaskConfig.DayListConfig.HeaderFontSize, fs, GraphicsUnit.Point);
            fs = dailyTaskConfig.DayListConfig.RowIsBold ? FontStyle.Bold : FontStyle.Regular;
            gvDay.RowTemplate.DefaultCellStyle.Font = new Font(dailyTaskConfig.DayListConfig.RowFont, dailyTaskConfig.DayListConfig.RowFontSize, fs, GraphicsUnit.Point);
            gvDay.ColumnHeadersHeight = dailyTaskConfig.DayListConfig.HeaderHeight;
            gvDay.Height = dailyTaskConfig.DayListConfig.Height;
            foreach (var col in dailyTaskConfig.DayListConfig.Columns)
            {
                gvDay.Columns[col.Name].HeaderText = col.Title;
                gvDay.Columns[col.Name].Visible = col.Visible;
            }

            gvWeek.ColumnHeadersDefaultCellStyle.BackColor = dailyTaskConfig.WeekListConfig.HeaderBackColor;
            gvWeek.ColumnHeadersDefaultCellStyle.ForeColor = dailyTaskConfig.WeekListConfig.HeaderForeColor;
            fs = dailyTaskConfig.WeekListConfig.HeaderIsBold ? FontStyle.Bold : FontStyle.Regular;
            gvWeek.ColumnHeadersDefaultCellStyle.Font = new Font(dailyTaskConfig.WeekListConfig.HeaderFont, dailyTaskConfig.WeekListConfig.HeaderFontSize, fs, GraphicsUnit.Point);
            fs = dailyTaskConfig.WeekListConfig.RowIsBold ? FontStyle.Bold : FontStyle.Regular;
            gvWeek.RowTemplate.DefaultCellStyle.Font = new Font(dailyTaskConfig.WeekListConfig.RowFont, dailyTaskConfig.WeekListConfig.RowFontSize, fs, GraphicsUnit.Point);
            gvWeek.ColumnHeadersHeight = dailyTaskConfig.WeekListConfig.HeaderHeight;
            gvWeek.Height = dailyTaskConfig.WeekListConfig.Height;
            foreach (var col in dailyTaskConfig.WeekListConfig.Columns)
            {
                gvWeek.Columns[col.Name].HeaderText = col.Title;
                gvWeek.Columns[col.Name].Visible = col.Visible;
            }

            gvDay.Top = lblDayList.Bottom + 5;
            lblDate.Left = gvDay.Right - lblDate.Width - lblDate.Margin.Left - (int)(dailyTaskConfig.LabelFontSize * 2);
            lblWeekList.Top = gvDay.Bottom + 8;
            gvWeek.Top = lblWeekList.Bottom + 5;
            //Graphics boxGraphics = this.CreateGraphics();
            //float x = boxGraphics.DpiX;
            //float y = boxGraphics.DpiY;
            #endregion 设置配置。
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 更新数据。
        /// </summary>
        public void UpdateData()
        {
            if (isLoadingData) return;            
            isLoadingData = true;

            GetDataSource();
            if (this.gvDay.InvokeRequired)
            {
                this.Invoke(new ThreadStart(BindDayGridView));
                this.Invoke(new ThreadStart(BindWeekGridView));
            }
            else
            {
                BindDayGridView();
                BindWeekGridView();
            }
            isLoadingData = false;
        }

        /// <summary>
        /// 从数据库取数据。
        /// </summary>
        private void GetDataSource()
        {
            try
            {
                dayDataSource = DataRepository.TempTaskProvider.GetDayTask(dailyTaskConfig.DayListConfig.ProjectType, dailyTaskConfig.DayListConfig.State);
            }
            catch
            {
                dayDataSource = new List<TempTaskInfo>();
            }
            try
            {
                weekDataSource = DataRepository.TempTaskProvider.GetWeekTask(dailyTaskConfig.WeekListConfig.ProjectType, dailyTaskConfig.WeekListConfig.State);
            }
            catch
            {
                weekDataSource = new List<TempTaskInfo>();
            }

            //if (dayDataSource.Count > dailyTaskConfig.DayListConfig.PageSize)
            //{
            //    if (timerDayPgdn == null)
            //    {
            //        timerDayPgdn = new Timer(this.components);
            //    }
            //    timerDayPgdn.Interval = dailyTaskConfig.DayListConfig.PgdnTime*1000;
            //    timerDayPgdn.Tick += new EventHandler(timerDayPgdn_Tick);
            //    timerDayPgdn.Start();
            //}
            //else 
            //{
            //    if (timerDayPgdn != null)
            //    {
            //        timerDayPgdn.Stop();
            //        timerDayPgdn.Dispose();
            //        timerDayPgdn = null;
            //    }
            //}

            //if(weekDataSource.Count > dailyTaskConfig.WeekListConfig.PageSize)
            //{
            //    if (timerWeekPgdn == null)
            //    {
            //        timerWeekPgdn = new Timer(this.components);
            //    }
            //    timerWeekPgdn.Interval = dailyTaskConfig.WeekListConfig.PgdnTime*1000;
            //    timerWeekPgdn.Tick += new EventHandler(timerWeekPgdn_Tick);
            //    timerWeekPgdn.Start();
            //}
            //else 
            //{
            //    if (timerWeekPgdn != null)
            //    {
            //        timerWeekPgdn.Stop();
            //        timerWeekPgdn.Dispose();
            //        timerWeekPgdn = null;
            //    }
            //}
        }

        /// <summary>
        /// 绑定24小时任务列表。
        /// </summary>
        private void BindDayGridView()
        {
            //Int32 count = dayDataSource.Count > dailyTaskConfig.DayListConfig.PageSize + dayDataIndex
            //                  ? dailyTaskConfig.DayListConfig.PageSize
            //                  : dayDataSource.Count - dayDataIndex;

            //gvDay.DataSource = dayDataSource.GetRange(dayDataIndex, count);

            this.gvDay.SuspendLayout();
            int dayDataIndex = gvDay.FirstDisplayedScrollingRowIndex;
            gvDay.DataSource = dayDataSource;
            if (dayDataIndex > 0 && dayDataSource.Count > dayDataIndex)
                gvDay.FirstDisplayedScrollingRowIndex = dayDataIndex;
            
            foreach (DataGridViewRow row in gvDay.Rows)
            {
                var entity = row.DataBoundItem as TempTaskInfo;
                if (entity == null) continue;
                UserInfo userInfo = null;

                if (gvDay.Columns[colPrincipal.Name].Visible)
                {
                    try
                    {
                        userInfo = Shmzh.Components.SystemComponent.DALFactory.DataProvider.UserProvider.GetByLoginName(entity.Principal);
                        row.Cells[colPrincipal.Name].Value = userInfo.EmpName;
                    }
                    catch { }
                }
                if (gvDay.Columns[colMaster.Name].Visible)
                {
                    try
                    {
                        userInfo = Shmzh.Components.SystemComponent.DALFactory.DataProvider.UserProvider.GetByLoginName(entity.Master);
                        row.Cells[colMaster.Name].Value = userInfo.EmpName;
                    }
                    catch { }
                }
                DailyTaskConfig.PriorityInfo priorityInfo = dailyTaskConfig.GetPriorityByName(entity.Priority);
                row.DefaultCellStyle.BackColor = priorityInfo == null ? Color.White : priorityInfo.BackColor;
                DailyTaskConfig.StateInfo stateInfo = dailyTaskConfig.GetStateByName(entity.State);
                row.DefaultCellStyle.ForeColor = stateInfo == null ? Color.Black : stateInfo.ForeColor;
            }
            this.gvDay.CurrentCell = null;
            this.gvDay_SizeChanged(this.gvDay, EventArgs.Empty);
            this.gvDay.ResumeLayout(true);
        }

        /// <summary>
        /// 绑定1周未完成任务列表。
        /// </summary>
        private void BindWeekGridView()
        {
            //Int32 count = weekDataSource.Count > dailyTaskConfig.WeekListConfig.PageSize + weekDataIndex
            //                  ? dailyTaskConfig.WeekListConfig.PageSize
            //                  : weekDataSource.Count - weekDataIndex;

            //gvWeek.DataSource = weekDataSource.GetRange(weekDataIndex, count);

            this.gvWeek.SuspendLayout();
            int weekDataIndex = gvWeek.FirstDisplayedScrollingRowIndex;
            gvWeek.DataSource = weekDataSource;
            if (weekDataIndex > 0 && dayDataSource.Count > weekDataIndex)
                gvWeek.FirstDisplayedScrollingRowIndex = weekDataIndex;
            
            foreach (DataGridViewRow row in gvWeek.Rows)
            {
                var entity = row.DataBoundItem as TempTaskInfo;
                if (entity == null) continue;
                UserInfo userInfo = null;

                if (gvWeek.Columns[colPrincipalWeek.Name].Visible)
                {
                    try
                    {
                        userInfo = Shmzh.Components.SystemComponent.DALFactory.DataProvider.UserProvider.GetByLoginName(entity.Principal);
                        row.Cells[colPrincipalWeek.Name].Value = userInfo.EmpName;
                    }
                    catch { }
                }

                if (gvWeek.Columns[colMasterWeek.Name].Visible)
                {
                    try
                    {
                        userInfo = Shmzh.Components.SystemComponent.DALFactory.DataProvider.UserProvider.GetByLoginName(entity.Master);
                        row.Cells[colMasterWeek.Name].Value = userInfo.EmpName;
                    }
                    catch { }
                }
                DailyTaskConfig.PriorityInfo priorityInfo = dailyTaskConfig.GetPriorityByName(entity.Priority);
                row.DefaultCellStyle.BackColor = priorityInfo == null ? Color.White : priorityInfo.BackColor;
                DailyTaskConfig.StateInfo stateInfo = dailyTaskConfig.GetStateByName(entity.State);
                row.DefaultCellStyle.ForeColor = stateInfo == null ? Color.Black : stateInfo.ForeColor;
            }
            this.gvWeek.CurrentCell = null;
            this.gvWeek_SizeChanged(this.gvWeek, EventArgs.Empty);
            this.gvWeek.ResumeLayout(true);
        }
        
        /// <summary>
        /// Load Config.
        /// </summary>
        /// <returns></returns>
        private DailyTaskConfig LoadConfig()
        {
            DailyTaskConfig configInfo = new DailyTaskConfig();
            XmlDocument doc = new XmlDocument();
            String xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\" + configFile);
            doc.Load(xmlPath);
            
            XmlNodeList nodeList = doc.DocumentElement.SelectNodes("BackGround/Item");
            if (nodeList.Count > 0)
            {
                XmlNode node = nodeList[0];
                backInfo = new BackGroundInfo();
                backInfo.BackColor = GetColor(node.Attributes.GetNamedItem("Color").Value);
                backInfo.Src = node.Attributes.GetNamedItem("Src").Value;
                backInfo.IsTiled = Convert.ToBoolean(node.Attributes.GetNamedItem("IsTiled").Value);
            }
            nodeList = doc.DocumentElement.SelectNodes("SpecialStyle/State/Item");
            DailyTaskConfig.StateInfo stateInfo;
            foreach (XmlNode node in nodeList)
            {
                stateInfo = new DailyTaskConfig.StateInfo();
                stateInfo.Name = node.Attributes.GetNamedItem("Name").Value;
                stateInfo.ForeColor = GetColor(node.Attributes.GetNamedItem("ForeColor").Value);
                configInfo.StateList.Add(stateInfo);
            }

            nodeList = doc.DocumentElement.SelectNodes("SpecialStyle/Priority/Item");
            DailyTaskConfig.PriorityInfo priorityInfo;
            foreach (XmlNode node in nodeList)
            {
                priorityInfo = new DailyTaskConfig.PriorityInfo();
                priorityInfo.Name = node.Attributes.GetNamedItem("Name").Value;
                priorityInfo.BackColor = GetColor(node.Attributes.GetNamedItem("BackColor").Value);
                configInfo.PriorityList.Add(priorityInfo);
            }

            XmlNode xmlNode = doc.DocumentElement.SelectSingleNode("Style/DayList");
            XmlAttribute xmlAttr = xmlNode.Attributes["Title"];
            configInfo.DayListConfig.Title = (xmlAttr == null || xmlAttr.Value.Length == 0) ? "最近24小时任务列表" : xmlAttr.Value;
            configInfo.DayListConfig.PgdnTime = Convert.ToInt32(xmlNode.Attributes["PgdnTime"].Value);
            configInfo.DayListConfig.ProjectType = xmlNode.Attributes["ProjectType"].Value;
            configInfo.DayListConfig.State = xmlNode.Attributes["State"].Value;
            configInfo.DayListConfig.Height = Convert.ToInt32(xmlNode.Attributes["Height"].Value);

            xmlNode = doc.DocumentElement.SelectSingleNode("Style/DayList/Header");
            configInfo.DayListConfig.HeaderHeight = Convert.ToInt32(xmlNode.Attributes["Height"].Value);
            configInfo.DayListConfig.HeaderBackColor = GetColor(xmlNode.Attributes["BackColor"].Value);
            configInfo.DayListConfig.HeaderForeColor = GetColor(xmlNode.Attributes["ForeColor"].Value);
            configInfo.DayListConfig.HeaderFont = xmlNode.Attributes["Font"].Value;
            configInfo.DayListConfig.HeaderFontSize = Convert.ToSingle(xmlNode.Attributes["FontSize"].Value);
            configInfo.DayListConfig.HeaderIsBold = Convert.ToBoolean(xmlNode.Attributes["IsBold"].Value); 

            xmlNode = doc.DocumentElement.SelectSingleNode("Style/DayList/Item");            
            configInfo.DayListConfig.RowFont = xmlNode.Attributes["Font"].Value;
            configInfo.DayListConfig.RowFontSize = Convert.ToSingle(xmlNode.Attributes["FontSize"].Value);
            configInfo.DayListConfig.RowIsBold = Convert.ToBoolean(xmlNode.Attributes["IsBold"].Value);

            var colNodes = doc.DocumentElement.SelectNodes("Style/DayList/Columns/Column");
            foreach (XmlNode colNode in colNodes)
            {
                DailyTaskConfig.Column column = new DailyTaskConfig.Column();
                column.Name = colNode.Attributes["Name"].Value;
                column.Title = colNode.Attributes["Title"].Value;
                column.Visible = Convert.ToBoolean(colNode.Attributes["Visible"].Value);
                configInfo.DayListConfig.Columns.Add(column);
            }

            xmlNode = doc.DocumentElement.SelectSingleNode("Style/WeekList");
            xmlAttr = xmlNode.Attributes["Title"];
            configInfo.WeekListConfig.Title = (xmlAttr == null || xmlAttr.Value.Length == 0) ? "最近1周未完成任务列表" : xmlAttr.Value;
            configInfo.WeekListConfig.PgdnTime = Convert.ToInt32(xmlNode.Attributes["PgdnTime"].Value);
            configInfo.WeekListConfig.ProjectType = xmlNode.Attributes["ProjectType"].Value;
            configInfo.WeekListConfig.State = xmlNode.Attributes["State"].Value;
            configInfo.WeekListConfig.Height = Convert.ToInt32(xmlNode.Attributes["Height"].Value);

            xmlNode = doc.DocumentElement.SelectSingleNode("Style/WeekList/Header");
            configInfo.WeekListConfig.HeaderHeight = Convert.ToInt32(xmlNode.Attributes["Height"].Value);
            configInfo.WeekListConfig.HeaderBackColor = GetColor(xmlNode.Attributes["BackColor"].Value);
            configInfo.WeekListConfig.HeaderForeColor = GetColor(xmlNode.Attributes["ForeColor"].Value);
            configInfo.WeekListConfig.HeaderFont = xmlNode.Attributes["Font"].Value;
            configInfo.WeekListConfig.HeaderFontSize = Convert.ToSingle(xmlNode.Attributes["FontSize"].Value);
            configInfo.WeekListConfig.HeaderIsBold = Convert.ToBoolean(xmlNode.Attributes["IsBold"].Value);

            xmlNode = doc.DocumentElement.SelectSingleNode("Style/WeekList/Item");            
            configInfo.WeekListConfig.RowFont = xmlNode.Attributes["Font"].Value;
            configInfo.WeekListConfig.RowFontSize = Convert.ToSingle(xmlNode.Attributes["FontSize"].Value);
            configInfo.WeekListConfig.RowIsBold = Convert.ToBoolean(xmlNode.Attributes["IsBold"].Value);
            colNodes = doc.DocumentElement.SelectNodes("Style/WeekList/Columns/Column");
            foreach (XmlNode colNode in colNodes)
            {
                DailyTaskConfig.Column column = new DailyTaskConfig.Column();
                column.Name = colNode.Attributes["Name"].Value;
                column.Title = colNode.Attributes["Title"].Value;
                column.Visible = Convert.ToBoolean(colNode.Attributes["Visible"].Value);
                configInfo.WeekListConfig.Columns.Add(column);
            }

            xmlNode = doc.DocumentElement.SelectSingleNode("Style/Title");
            configInfo.Title = xmlNode.InnerText;
            configInfo.TitleForeColor = GetColor(xmlNode.Attributes["ForeColor"].Value);
            configInfo.TitleFont = xmlNode.Attributes["Font"].Value;
            configInfo.TitleFontSize = Convert.ToSingle(xmlNode.Attributes["FontSize"].Value);
            configInfo.TitleIsBold = Convert.ToBoolean(xmlNode.Attributes["IsBold"].Value);

            xmlNode = doc.DocumentElement.SelectSingleNode("Style/Label");
            configInfo.LabelForeColor = GetColor(xmlNode.Attributes["ForeColor"].Value);
            configInfo.LabelFont = xmlNode.Attributes["Font"].Value;
            configInfo.LabelFontSize = Convert.ToSingle(xmlNode.Attributes["FontSize"].Value);
            configInfo.LabelIsBold = Convert.ToBoolean(xmlNode.Attributes["IsBold"].Value);
          
            return configInfo;
        }

        private Color GetColor(String colorString)
        {
            return Shmzh.Components.Util.StringUtil.StringToColor(colorString, Color.Black);
        }

        #endregion

        #region Events
        private void FrmDailyTask_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in gvDay.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewColumn column in gvWeek.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
            this.lblDate.Text = "当前时间：" + DateTime.Now.ToString();
            
            timerClock = new System.Timers.Timer();
            timerClock.Interval = 1000;
            timerClock.AutoReset = true;
            timerClock.Elapsed += new System.Timers.ElapsedEventHandler(timerClock_Elapsed);
            timerClock.Start();

            new Thread(new ThreadStart(this.UpdateData)) { IsBackground = true }.Start();
        }
        
        private void timerClock_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.lblDate.Created)
            {
                ThreadStart d = delegate()
                {
                    this.lblDate.Text = "当前时间：" + DateTime.Now.ToString();
                };
                this.lblDate.Invoke(d);
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(this.UpdateData)) { IsBackground = true }.Start();
        }

        private void gvWeek_SizeChanged(object sender, EventArgs e)
        {
            if (this.gvWeek.Rows.Count == 0) return;
            if (this.gvWeek.Rows.Count == this.gvWeek.DisplayedColumnCount(false))
            {
                if (timerWeekPgdn != null)
                {
                    timerWeekPgdn.Stop();
                    timerWeekPgdn.Dispose();
                    timerWeekPgdn = null;
                }
            }
            else
            {
                if (timerWeekPgdn == null)
                {
                    timerWeekPgdn = new Timer(this.components);
                    timerWeekPgdn.Interval = dailyTaskConfig.WeekListConfig.PgdnTime * 1000;
                    timerWeekPgdn.Tick += new EventHandler(timerWeekPgdn_Tick);
                }
                timerWeekPgdn.Start();
            }
        }

        private void gvDay_SizeChanged(object sender, EventArgs e)
        {
            if (this.gvDay.Rows.Count == 0) return;
            if (this.gvDay.Rows.Count == this.gvDay.DisplayedRowCount(false))
            {
                if (timerDayPgdn != null)
                {
                    timerDayPgdn.Stop();
                    timerDayPgdn.Dispose();
                    timerDayPgdn = null;
                }
            }
            else
            {
                if (timerDayPgdn == null)
                {
                    timerDayPgdn = new Timer(this.components);
                    timerDayPgdn.Interval = dailyTaskConfig.DayListConfig.PgdnTime * 1000;
                    timerDayPgdn.Tick += new EventHandler(timerDayPgdn_Tick);
                }
                timerDayPgdn.Start();
            }
        }

        private void timerWeekPgdn_Tick(object sender, EventArgs e)
        {
            //weekDataIndex += dailyTaskConfig.WeekListConfig.PageSize;
            //if (weekDataIndex >= weekDataSource.Count) weekDataIndex = 0;
            //this.BindWeekGridView();

            if (this.gvWeek.FirstDisplayedScrollingRowIndex + this.gvWeek.DisplayedRowCount(false) == this.gvWeek.Rows.Count)
                this.gvWeek.FirstDisplayedScrollingRowIndex = 0;
            else
                this.gvWeek.FirstDisplayedScrollingRowIndex++;
        }

        private void timerDayPgdn_Tick(object sender, EventArgs e)
        {
            //dayDataIndex += dailyTaskConfig.DayListConfig.PageSize;
            //if (dayDataIndex >= dayDataSource.Count) dayDataIndex = 0;
            //this.BindDayGridView();

            if (this.gvDay.FirstDisplayedScrollingRowIndex + this.gvDay.DisplayedRowCount(false) == this.gvDay.Rows.Count)
                this.gvDay.FirstDisplayedScrollingRowIndex = 0;
            else
                this.gvDay.FirstDisplayedScrollingRowIndex++;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            
            if (backInfo != null)
            {
                backInfo.Render(e.Graphics, Width, Height);
            }
        }
        #endregion

        #region IBaseForm 实现
        public LoadState GetLoadState()
        {
            if (isLoadingData)
            {
                return LoadState.Loading;
            }
            else
            {
                return LoadState.Finished;
            }
        }
        #endregion
    }
}
