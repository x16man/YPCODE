using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using Shmzh.Monitor.Config;
using Shmzh.Monitor.Forms.Setting;
using Shmzh.Monitor.Gadget;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmBase : Form, IBaseForm
    {
        protected MonitorConfig config;
        protected System.Windows.Forms.Timer timerUpdate = new System.Windows.Forms.Timer();
        protected UpdateData updateData = null;
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //private float _scale = 1.0f;
        
        public FrmBase()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            InitializeComponent();
            
            WindowState = FormWindowState.Maximized;
            timerUpdate.Tick += new EventHandler(timerUpdate_Tick);
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            Logger.Debug("timer tick");
            UpdateData();
        }

        protected virtual void UpdateData() { }

        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                UpdateData();
                foreach (PieInfo pieInfo in config.PieList)
                {
                    pieInfo.Render(this);
                }
                foreach (GaugeInfo entity in config.GaugeList)
                {
                    entity.Render(this);
                }
                if (config.Clock != null) config.Clock.Render(this);
            }

            base.OnLoad(e);
        }

        //private GraphicsState gs;
        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.ScaleTransform(0.8F, 0.8F);
            var sw = new Stopwatch();
            sw.Start();
            base.OnPaint(e);
            if (DesignMode) return;
            if (config == null) return;
            
            Graphics g = e.Graphics;
            
            //g.ScaleTransform(_scale, _scale);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (config.FormBackGround != null) config.FormBackGround.Render(g, Width, Height);

            foreach (ImageInfo imgInfo in config.ImageList)
            {
                imgInfo.Render(g);
            }

            foreach (TagImageInfo entity in config.TagImageList)
            {
                entity.Render(g);
            }

            foreach (LineInfo lineInfo in config.LineList)
            {
                lineInfo.Render(g);
            }

            foreach (DeviceInfo devInfo in config.DeviceList)
            {
                devInfo.Render(g);
            }

            foreach (TextInfo textInfo in config.TextList)
            {
                textInfo.Render(g);
            }

            foreach (TagInfo tagInfo in config.TagList)
            {
                tagInfo.Render(g);
            }

            foreach (PoolInfo poolInfo in config.PoolList)
            {
                poolInfo.Render(g);
            }

            foreach (LitePoolInfo entity in config.LitePoolList)
            {
                entity.Render(g);
            }
            sw.Stop();

            Trace.WriteLine(string.Format("FrmBase.Render spend {0}ms",sw.ElapsedMilliseconds));
            
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            foreach (HoverInfo hoverInfo in config.HoverList)
            {
                if (hoverInfo.Bounds.Contains(e.Location))
                {
                    if (!hoverInfo.IsMouseOver)
                    {
                        this.SuspendLayout();
                        if (!String.IsNullOrEmpty(hoverInfo.TriggerEvent))
                        {
                            this.Cursor = Cursors.Hand;
                        }
                        hoverInfo.IsMouseOver = true;
                        Invalidate(hoverInfo.Bounds);
                        this.ResumeLayout(false);
                    }
                }
                else
                {
                    if (hoverInfo.IsMouseOver)
                    {
                        this.SuspendLayout();
                        if (!String.IsNullOrEmpty(hoverInfo.TriggerEvent))
                        {
                            this.Cursor = Cursors.Default;
                        }
                        hoverInfo.IsMouseOver = false;
                        Invalidate(hoverInfo.Bounds);
                        this.ResumeLayout(false);
                    }
                }
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool isDone = false;
                foreach (var tagInfo in config.TagList)
                {
                    if (tagInfo.HotBounds.Contains(e.Location))
                    {
                        //MessageBox.Show(tagInfo.TagId + ":" + tagInfo.Value);
                        var tagExpression = tagInfo.TagId.ToUpper();
                        if (tagExpression.Contains("MAX") || tagExpression.Contains("MIN") || tagExpression.Contains("AVG") || tagExpression.Contains("SUM"))
                            return;
                        
                        var tags = new String[] { tagInfo.TagId };
                        var tagNames = new String[] { tagInfo.TagName };
                        //显示状态窗口。
                        var tHandler = new ToolTipHandler();
                        tHandler.Show(String.Format("正在生成曲线，请稍候..."), this.Bounds);
                        //显示状态窗口。
                        var form = new FrmGraphSchemaStage(tags, tagNames) { MdiParent = this.MdiParent };
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.Show();
                        tHandler.Close();//隐藏状态窗口。
                        isDone = true;
                        break;
                    }
                }
                if (!isDone)
                {
                    foreach (ITriggerEvent eventInfo in config.DoubleClickList)
                    {
                        if (eventInfo.HotBounds.Contains(e.Location))
                        {
                            String code = eventInfo.TriggerEvent;
                            var obj = Shmzh.Monitor.Data.DataProvider.CategoryItemProvider.GetByCode(code);
                            if (obj != null)
                            {
                                this.MdiParent.GetType().GetMethod("ShowItem").Invoke(this.MdiParent, new object[] { obj });
                            }
                            break;
                        }
                    }
                }
            }
            base.OnMouseDoubleClick(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            //_scale = this.Width / 1024F;
            //foreach (Control ctl in this.Controls)
            //{
            //    ctl.Scale(new SizeF(_scale, _scale));
            //}
            //---------------------           
            base.OnSizeChanged(e);
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //foreach (ITriggerEvent eventInfo in config.LeftClickList)
                //{
                //    if (eventInfo.HotBounds.Contains(e.Location))
                //    {
                //        Control control = GetMainForm();
                //        if (control != null)
                //        {
                //            control.GetType().GetMethod("ShowByName").Invoke(control,
                //                                                                   new object[] { eventInfo.TriggerEvent });
                //        }
                //    }
                //}
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (Common.CurrentUser == null || !Common.CurrentUser.HasRight(Convert.ToInt32(RightType.MonitorObjConfig)))
                {
                    return;
                }
                foreach (ITriggerEvent eventInfo in config.RightClickList)
                {
                    if (eventInfo.HotBounds.Contains(e.Location))
                    {
                        ContextMenuStrip cMenuStrip = new ContextMenuStrip();
                        cMenuStrip.AutoSize = true;
                        ToolStripMenuItem menuEdit = new ToolStripMenuItem();
                        menuEdit.AutoSize = true;
                        menuEdit.Text = "编辑属性";
                        menuEdit.Tag = eventInfo.Tag;
                        menuEdit.Click += new System.EventHandler(this.menuEdit_Click);
                        cMenuStrip.Items.AddRange(new ToolStripItem[] {
                            menuEdit
                            });
                        cMenuStrip.ShowImageMargin = false;
                        cMenuStrip.Show(PointToScreen(e.Location), ToolStripDropDownDirection.Default);
                        break;
                    }
                }
            }
            base.OnMouseClick(e);
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem == null) return;
            if (menuItem.Tag is PoolInfo)
            {
                PoolInfo entity = menuItem.Tag as PoolInfo;
                //MessageBox.Show(poolInfo.MonitorObj);
                Setting.FrmMonitorObjEdit form = new FrmMonitorObjEdit(entity.MonitorObj);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Control control = GetMainForm();
                    control.GetType().GetMethod("RefreshAtOnce").Invoke(control, null);
                }
            }
            else if (menuItem.Tag is TagInfo)
            {
                TagInfo entity = menuItem.Tag as TagInfo;
                //MessageBox.Show(tagInfo.MonitorObj);
                Setting.FrmMonitorObjEdit form = new FrmMonitorObjEdit(entity.MonitorObj);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Control control = GetMainForm();
                    if (control != null)
                        control.GetType().GetMethod("RefreshAtOnce").Invoke(control, null);
                }
            }
            else if (menuItem.Tag is LitePoolInfo)
            {
                LitePoolInfo entity = menuItem.Tag as LitePoolInfo;
                Setting.FrmMonitorObjEdit form = new FrmMonitorObjEdit(entity.MonitorObj);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Control control = GetMainForm();
                    if (control != null)
                        control.GetType().GetMethod("RefreshAtOnce").Invoke(control, null);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (config != null)
            {
                if (config.Clock != null) config.Clock.Dispose();
                config = null;
            }
            if (timerUpdate != null)
                timerUpdate.Dispose();
            if (updateData != null)
                updateData.IsStopped = true;

            base.Dispose(disposing);
        }

        private Control GetMainForm()
        {
            Control control = this.TopLevelControl;
            while (control != null)
            {
                Type type = control.GetType();
                if (type.FullName == "Shmzh.Monitor.Main.FrmMain")
                {
                    break;
                }
                control = control.Parent;
            }
            return control;
        }

        #region IBaseForm 实现
        public LoadState GetLoadState()
        {
            if (updateData.IsStopped)
            {
                return LoadState.Stopped;
            }
            else if (updateData.IsFinished)
            {
                return LoadState.Finished;
            }
            else
            {
                return LoadState.Loading;
            }
        }
        #endregion
    }
}
