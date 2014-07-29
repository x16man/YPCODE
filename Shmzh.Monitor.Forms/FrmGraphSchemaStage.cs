using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Shmzh.Components.Util;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;
using ZedGraph;
using System.Diagnostics;
using Label=System.Windows.Forms.Label;
using System.Text.RegularExpressions;
using Ciloci.Flee;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmGraphSchemaStage : BaseGraphForm, IBaseForm
    {
        #region Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int _updateTime = 43200;//默认，43200秒，即12小时。
        private DateTime _lastTime = DateTime.MinValue;
        /// <summary>
        /// 曲线图中，当查看历史数据左右移动时，单次取数据点的个数。 如果设为9，取出是10个点，因为时间两端都取值。
        /// </summary>
        private static Int32 onceReadCount = 0;
        private static Int32 onceZoomCount;
        private Stopwatch _stopwatch;
        /// <summary>
        /// 窗体载入时的数据库服务器时间。
        /// </summary>
        private DateTime _serverTime;
        /// <summary>
        /// 小时的延迟，分钟，值范围0~59.
        /// </summary>
        private int hourDelay;
        /// <summary>
        /// 日、月、年的延迟，小时，值范围0~23.
        /// </summary>
        private int dayDelay;
        private bool IsRefreshedHour;
        private bool IsRefreshedDay;
        private bool isFirstLoad = true;

        /// <summary>
        /// 是否可启用即时更新。
        /// </summary>
        private Boolean isUpdateEnabled = false;
        /// <summary>
        /// 是否是即时更新状态。
        /// </summary>
        private Boolean isRealTime = true;
        /// <summary>
        /// 临时存储数据的集合。(以tagInfo.TagId作为Key)
        /// </summary>
        private PointListCollection<PointPairList> _pplCollection = new PointListCollection<PointPairList>();
        /// <summary>
        /// 临时存储数据的集合。K 线图(以tagInfo.TagId作为Key)
        /// </summary>
        private PointListCollection<StockPointList> _splCollection = new PointListCollection<StockPointList>();
        /// <summary>
        /// 图线关联的数据集合。(以tagInfo.KeyId作为Key)
        /// </summary>
        private PointListCollection<PointPairList> xPPLCollection = new PointListCollection<PointPairList>();
        /// <summary>
        /// 图线关联的数据集合。K 线图(以tagInfo.KeyId作为Key)
        /// </summary>
        private PointListCollection<StockPointList> xSPLCollection = new PointListCollection<StockPointList>();
        /// <summary>
        /// 是否正在加载曲线数据。
        /// </summary>
        private bool isLoadingCurveData;
        private bool _isLoadingFloatingData;
        protected UpdateDataRTag updateDataRTag = null;

        /// <summary>
        /// 移动平均值集合的Key后缀。
        /// </summary>
        private const String _MA = "MA";

        /// <summary>
        /// FloatingBlock集合的Key后缀。
        /// </summary>
        private const String _FB = "FB";

        private bool _isZoomed = false;
        private bool _isMoved = false;
        /// <summary>
        /// 是否已经保存的曲线(用于临时曲线)。
        /// </summary>
        private bool _isSaved = true;

        private ToolTipHandler toolTipHandler = new ToolTipHandler();

        private delegate void MoveUpdateDelegate(Boolean isToLeft, DateTime sideTime);

        /// <summary>
        /// 正则表达式。
        /// 大表达式。
        /// </summary>
        private static Regex tagRegex = new Regex(@"\[[-/\+\*\w\(\)\[\]:]+\]@\[(([-\w,:@]+\])|(\d{4}-\d{1,2}-\d{1,2}( +\d{1,2}:\d{1,2}(:\d{1,2})?)?))");
        
        #endregion

        #region Constructors
        private FrmGraphSchemaStage()
        {
            InitializeComponent();
            if (onceReadCount == 0)
            {
                onceReadCount = ConfigurationManager.AppSettings["Schema_OnceReadCount"] == null ? 9 : Convert.ToInt32(ConfigurationManager.AppSettings["Schema_OnceReadCount"]) - 1;
                onceZoomCount = ConfigurationManager.AppSettings["Schema_OnceZoomCount"] == null ? 5 : Convert.ToInt32(ConfigurationManager.AppSettings["Schema_OnceZoomCount"]);
                if (onceZoomCount > onceReadCount)
                    onceZoomCount = onceReadCount;
            }
        }
        private FrmGraphSchemaStage(String schemaName)
            : this()
        {
            if (!String.IsNullOrEmpty(schemaName))
            {
                this.GraphSchemaEntity = DataProvider.GraphSchemaProvider.GetByName(schemaName);
                this.GetSchema();
                //if (this._updateTime <= 0)
                //{
                //    this._updateTime = Common.GetUpdateTime(this.GraphSchemaEntity.DataType);
                //    this.timerUpdate.Interval = this._updateTime * 1000;
                //    this.timerUpdate.Start();
                //    isUpdateEnabled = true;
                //}
            }
        }
        public FrmGraphSchemaStage(String schemaName, Int32 updateTime) : this(schemaName)
        {
            this._isSaved = true;
            this._updateTime = updateTime;
            if (updateTime > 0)
            {
                this.timerUpdate.Interval = updateTime * 1000;
                this.timerUpdate.Start();
                isUpdateEnabled = true;
            }
        }
        public FrmGraphSchemaStage(String[] tags, String[] tagNames) : this()
        {
            if (tags == null || tags.Length == 0)
            {
                throw new Exception("未传入指标ID");
            }
            this._isSaved = false;

            this.GraphSchemaEntity = new GraphSchemaInfo() {
                DataType = "Hour",
                Name = "",
                Remark = "",
                IsValid = true,
                TabWidth = 0,
                ReferLoginName = Common.CurrentUser.LoginName,
                Layout = "1|",
            };

            this._updateTime = Common.GetUpdateTime(this.GraphSchemaEntity.DataType);
            this.timerUpdate.Interval = this._updateTime * 1000;
            this.timerUpdate.Start();
            isUpdateEnabled = true;

            this.GetSchema(tags, tagNames);
        }

        public FrmGraphSchemaStage(GraphSchemaInfo graphSchemaInfo): this()
        {
            this._isSaved = false;

            this.GraphSchemaEntity = graphSchemaInfo;

            this._updateTime = Common.GetUpdateTime(this.GraphSchemaEntity.DataType);
            this.timerUpdate.Interval = this._updateTime * 1000;
            this.timerUpdate.Start();
            isUpdateEnabled = true;

            this.AllocateMemory();
        }
        #endregion

        #region Properties
        /// <summary>
        /// 实时状态时，上次取值的时间。
        /// </summary>
        public DateTime LastTime
        {
            get
            {
                if (_lastTime == DateTime.MinValue)
                {
                    _lastTime = Common.GetXAxisMinTime(Common.GetReelTimeXAxisMaxTime(this.CurrentDataType), this.CurrentDataType);
                    this.MinTime = _lastTime;
                }
                return _lastTime;
            }
            set { _lastTime = value; }
        }

        /// <summary>
        /// 当前显示的数据类型。
        /// </summary>
        private String CurrentDataType { get; set; }

        public GraphSchemaInfo GraphSchemaEntity { get; set; }

        /// <summary>
        /// 实际获得数据的最小时间。
        /// </summary>
        private DateTime MinTime { get; set; }

        /// <summary>
        /// 实际获得数据的最大时间。
        /// </summary>
        private DateTime MaxTime { get; set; }

        private DateTime XScaleMinTime { get; set; }

        private DateTime XScaleMaxTime { get; set; }

        /// <summary>
        /// 是否已经保存的曲线(用于临时曲线)。
        /// </summary>
        public bool IsSaved
        {
            get { return this._isSaved; }
            set { this._isSaved = value; }
        }
        #endregion

        #region Enum - RefreshType
        /// <summary>
        /// 刷新图表的方式。
        /// </summary>
        private enum RefreshType
        {
            /// <summary>
            /// 增量刷新。
            /// </summary>
            Added,
            /// <summary>
            /// 全部重置。
            /// </summary>
            Reset
        }
        #endregion

        #region Override Methods
        protected override void OnLoad(EventArgs e)
        {
            this.graph.IsShowHorizontalGuideLine = true;
            this.graph.IsShowVerticalGuideLine = true;
            this.graph.GuideLineColor = Color.Green;
            this.graph.MouseWheel += new MouseEventHandler(graph_MouseWheel);

            //this.GetSchema();
            this.CurrentDataType = this.GraphSchemaEntity.DataType;

            this.BindRTagList();

            GetFloatingBlocks();
            CreateFloatingBlocks();

            this.hourDelay = Convert.ToInt32(ConfigurationManager.AppSettings["HourDelay"]);
            this.dayDelay = Convert.ToInt32(ConfigurationManager.AppSettings["DayDelay"]);
            _serverTime = DataProvider.TagProvider.GetDate();
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            this.CreateGraph();

            base.OnLoad(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            if (updateDataRTag != null && !updateDataRTag.IsFinished)
            {
                updateDataRTag.IsStopped = true;
            }
            base.OnClosed(e);
        }

        /// <summary>
        /// 实时监控时更新数据。
        /// </summary>
        protected override void UpdateData()
        {
            if (isLoadingCurveData) return;
            if (this.GraphSchemaEntity == null) return;

            isLoadingCurveData = true;

            if (this.CurrentDataType == "Min15" || this.CurrentDataType == "Min" || this.CurrentDataType == "Second")
                UpdateDataFromCache();
            else
                UpdateDataFromDB();

            isLoadingCurveData = false;

            //更新关联指标。
            if (updateDataRTag != null)
            {
                if (updateDataRTag.IsFinished)
                {
                    updateDataRTag.DoWork();
                }
            }
        }

        /// <summary>
        /// 实时监控时更新数据。
        /// 当数据类型为"Year", "Month", "Day", "Hour"时，每次都直接从数据库取曲线上的全部数据。
        /// </summary>
        private void UpdateDataFromDB()
        {
            Boolean isNeedRefresh = false;
            DateTime tickTime = _serverTime.Add(_stopwatch.Elapsed);
            if (isFirstLoad)
            {
                isFirstLoad = false;
                isNeedRefresh = true;
            }
            else
            {
                switch (this.CurrentDataType)
                {
                    case "Hour":
                        //Debug.WriteLine(String.Format("tickTime.Minute:{0}, hourDelay:{1}", tickTime.Minute, this.hourDelay));
                        if (tickTime.Minute == this.hourDelay)
                        {
                            if (!this.IsRefreshedHour)
                            {
                                //获取小时数据
                                this.IsRefreshedHour = true;
                                isNeedRefresh = true;
                                //Debug.WriteLine("取小时数据。");
                            }
                        }
                        else
                        {
                            if (this.IsRefreshedHour)
                                this.IsRefreshedHour = false;
                        }
                        break;
                    case "Day":
                    case "Month":
                    case "Year":
                        //Debug.WriteLine(String.Format("tickTime.Hour:{0}, dayDelay:{1}", tickTime.Hour, this.dayDelay));
                        if (tickTime.Hour == this.dayDelay)
                        {
                            if (!this.IsRefreshedDay)
                            {
                                //获取天数据。
                                this.IsRefreshedDay = true;
                                isNeedRefresh = true;
                                //Debug.WriteLine("取年、月、日数据。");
                            }
                        }
                        else
                        {
                            if (this.IsRefreshedDay)
                                this.IsRefreshedDay = false;
                        }
                        break;
                    default:
                        return;
                }
            }

            if (!isNeedRefresh)
                return;
            StockPointList spl;
            PointPairList pointPairList;
            DateTime beginTime = this.XScaleMinTime;
            DateTime endTime = Common.GetReelTimeXAxisMaxTime(this.CurrentDataType);
            Int32 year, month, day, hour, minute, second, millisecond;
            _pplCollection.Clear();
            _splCollection.Clear();
            foreach (GraphSchemaItemInfo itemInfo in this.GraphSchemaEntity.ItemList)
            {
                foreach (GraphSchemaTagInfo tagInfo in itemInfo.TagList)
                {
                    if (IsJapaneseCandleStick(tagInfo))
                    {
                        if (_splCollection.Contains(tagInfo.TagId) && !_splCollection.Get(tagInfo.TagId).IsEmpty) continue;
                    }
                    else
                    {
                        if (_pplCollection.Contains(tagInfo.TagId) && !_pplCollection.Get(tagInfo.TagId).IsEmpty) continue;
                    }
                    
                    pointPairList = new PointPairList();
                    spl = new StockPointList();

                    Common.GetGraphData(this.CurrentDataType, beginTime, endTime, tagInfo.TagId, IsJapaneseCandleStick(tagInfo), ref pointPairList, ref spl, false);

                    if (IsJapaneseCandleStick(tagInfo))
                    {
                        if (spl.Count > 1)
                        {
                            spl.Sort((a, b) => a.X.CompareTo(b.X));
                        }
                        if (spl.Count > 0)
                        {
                            XDate.XLDateToCalendarDate(spl[spl.Count - 1].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                            DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                            if (LastTime < dateTime) LastTime = dateTime;
                        }

                        _splCollection[tagInfo.TagId] = spl;
                        //_splCollection.Get(tagInfo.TagId).IsEmpty = false;
                    }
                    else
                    {
                        if (pointPairList.Count > 1)
                        {
                            pointPairList.Sort(SortType.XValues);
                        }
                        if (pointPairList.Count > 0)
                        {
                            XDate.XLDateToCalendarDate(pointPairList[pointPairList.Count - 1].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                            DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                            if (LastTime < dateTime) LastTime = dateTime;
                        }
                        _pplCollection[tagInfo.TagId] = pointPairList;
                        //_pplCollection.Get(tagInfo.TagId).IsEmpty = false;
                    }
                    this.MaxTime = this.LastTime;
                    if (this.XScaleMaxTime < this.MaxTime)
                    {
                        DateTime xMaxTime = Common.GetReelTimeXAxisMaxTime(this.CurrentDataType);
                        DateTime xMinTime = Common.GetXAxisMinTime(xMaxTime, this.CurrentDataType);
                        foreach (var myPane in graph.MasterPane.PaneList)
                        {
                            myPane.XAxis.Scale.Min = (double)new XDate(xMinTime);
                            myPane.XAxis.Scale.Max = (double)new XDate(xMaxTime);
                        }
                        this.RecordXScaleTime(xMinTime, xMaxTime);
                    }

                    this.GetInstantFloatingData(beginTime, endTime);
                    this.RefreshGraph(RefreshType.Reset, false);
                    //实时状态，且光标在绘图区域之外时，保持浮动窗口内的值是最新的值。
                    foreach (var ctlBlock in graph.FloatingBlocks)
                    {
                        ctlBlock.X = (double)new XDate(this.LastTime);
                    }
                }
            }
        }

        /// <summary>
        /// 实时监控时更新数据。
        /// 当数据类型为 "Min15", "Min", "Second" 时，每次都从缓存中取曲线上的最新数据。
        /// </summary>
        private void UpdateDataFromCache()
        {
            Int32 year, month, day, hour, minute, second, millisecond;
            StockPointList spl;
            PointPairList pointPairList;
            DateTime beginTime = this.LastTime;
            DateTime endTime = Common.GetReelTimeXAxisMaxTime(this.CurrentDataType);
            Boolean isNeedRefresh = false;//是否取得到数据，需要更新曲线。
            DateTime lastMaxTime = MaxTime;
            _pplCollection.Clear();
            _splCollection.Clear();
            foreach (GraphSchemaItemInfo itemInfo in this.GraphSchemaEntity.ItemList)
            {
                foreach (GraphSchemaTagInfo tagInfo in itemInfo.TagList)
                {

                    if (IsJapaneseCandleStick(tagInfo))
                    {
                        if (_splCollection.Contains(tagInfo.TagId) && !_splCollection.Get(tagInfo.TagId).IsEmpty) continue;
                    }
                    else
                    {
                        if (_pplCollection.Contains(tagInfo.TagId) && !_pplCollection.Get(tagInfo.TagId).IsEmpty) continue;
                    }
                    pointPairList = new PointPairList();
                    spl = new StockPointList();

                    //Logger.Info(beginTime.ToString() + "-----");
                    Common.GetGraphData(this.CurrentDataType, beginTime, endTime, tagInfo.TagId, IsJapaneseCandleStick(tagInfo), ref pointPairList, ref spl, true);

                    if (IsJapaneseCandleStick(tagInfo))
                    {
                        if (spl.Count > 1)
                        {
                            spl.Sort((a, b) => a.X.CompareTo(b.X));
                        }
                        if (spl.Count > 0)
                        {
                            isNeedRefresh = true;
                            XDate.XLDateToCalendarDate(spl[spl.Count - 1].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                            DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                            if (LastTime < dateTime) LastTime = dateTime;
                        }

                        _splCollection[tagInfo.TagId] = spl;
                        //_splCollection.Get(tagInfo.TagId).IsEmpty = false;
                    }
                    else
                    {
                        if (pointPairList.Count > 1)
                        {
                            pointPairList.Sort(SortType.XValues);
                        }
                        if (pointPairList.Count > 0)
                        {
                            isNeedRefresh = true;
                            XDate.XLDateToCalendarDate(pointPairList[pointPairList.Count - 1].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                            DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                            if (LastTime < dateTime) LastTime = dateTime;
                        }
                        _pplCollection[tagInfo.TagId] = pointPairList;
                        //_pplCollection.Get(tagInfo.TagId).IsEmpty = false;
                    }
                    this.MaxTime = this.LastTime;
                }
            }

            if (isNeedRefresh && lastMaxTime != MaxTime)
            {
                //当取数据的频率设置时间过短时，会连续多次取到同一条数据，这时不应去更新界面，故返回。
                //if (lastMaxTime == MaxTime) return; //改到上面做判断。

                if (graph.MasterPane.PaneList.Count > 0)
                {
                    double newMinXScale = double.NaN;

                    if (this.XScaleMaxTime < this.MaxTime)
                    {
                        DateTime dtXMaxTime = Common.GetReelTimeXAxisMaxTime(this.CurrentDataType);
                        DateTime dtXMinTime = Common.GetXAxisMinTime(dtXMaxTime, this.CurrentDataType);
                        foreach (var myPane in graph.MasterPane.PaneList)
                        {
                            myPane.XAxis.Scale.Min = new XDate(dtXMinTime);
                            myPane.XAxis.Scale.Max = new XDate(dtXMaxTime);
                        }
                        RecordXScaleTime(dtXMinTime, dtXMaxTime);

                        newMinXScale = new XDate(this.XScaleMinTime);
                    }

                    this.GetInstantFloatingData(beginTime, endTime);
                    this.RefreshGraph(RefreshType.Added, false);
                    //实时状态，且光标在绘图区域之外时，保持浮动窗口内的值是最新的值。
                    foreach (var ctlBlock in graph.FloatingBlocks)
                    {
                        ctlBlock.X = (double)new XDate(this.LastTime);
                    }

                    #region 实时状态时，如果数据的最小坐标值，小于了图上刻度的最小值，就把这部分数据删除掉，因为在实时状态下这部分数据在图表上是不可见的。
                    if (!double.IsNaN(newMinXScale))
                    {
                        foreach (var myPane in graph.MasterPane.PaneList)
                        {
                            foreach (CurveItem curveItem in myPane.CurveList)
                            {
                                GraphSchemaTagInfo tagInfo = curveItem.Tag as GraphSchemaTagInfo;
                                if (tagInfo == null) continue;

                                double tempPtX;
                                if (IsJapaneseCandleStick(tagInfo) && xSPLCollection[tagInfo.KeyId] != null && xSPLCollection[tagInfo.KeyId].Count > 0)
                                {
                                    while ((tempPtX = xSPLCollection[tagInfo.KeyId][0].X) < newMinXScale)
                                    {
                                        xSPLCollection[tagInfo.KeyId].RemoveAt(0);
                                    }
                                }
                                else if (xPPLCollection[tagInfo.KeyId] != null && xPPLCollection[tagInfo.KeyId].Count > 0)
                                {
                                    while ((tempPtX = xPPLCollection[tagInfo.KeyId][0].X) < newMinXScale)
                                    {
                                        xPPLCollection[tagInfo.KeyId].RemoveAt(0);
                                        if (tagInfo.CurveType == "CurveMA")
                                        {
                                            xPPLCollection[tagInfo.KeyId + _MA].RemoveAt(0);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// 获取 Graph Schema 配置。
        /// </summary>
        private void GetSchema()
        {
            if (this.GraphSchemaEntity == null) return;

            this.GraphSchemaEntity.ItemList = DataProvider.GraphSchemaItemProvider.GetBySchemaId(this.GraphSchemaEntity.SchemaId);
            foreach (GraphSchemaItemInfo itemInfo in this.GraphSchemaEntity.ItemList)
            {
                itemInfo.TagList = DataProvider.GraphSchemaTagProvider.GetBySchemaItemId(itemInfo.ItemId);
                foreach (GraphSchemaTagInfo tagInfo in itemInfo.TagList)
                {
                    if (IsJapaneseCandleStick(tagInfo))
                    {                        
                        if (!_splCollection.Contains(tagInfo.TagId))
                        {
                            _splCollection.Add(tagInfo.TagId);
                            _splCollection[tagInfo.TagId] = new StockPointList();
                        }
                        xSPLCollection.Add(tagInfo.KeyId);
                        xSPLCollection[tagInfo.KeyId] = new StockPointList();
                    }
                    else
                    {
                        if (!_pplCollection.Contains(tagInfo.TagId))
                        {
                            _pplCollection.Add(tagInfo.TagId);
                            _pplCollection[tagInfo.TagId] = new PointPairList();
                        }
                        xPPLCollection.Add(tagInfo.KeyId);
                        xPPLCollection[tagInfo.KeyId] = new PointPairList();
                        if(tagInfo.CurveType == "CurveMA")
                        {                            
                            xPPLCollection.Add(tagInfo.KeyId + _MA);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取 Graph Schema 配置。
        /// </summary>
        private void GetSchema(String[] tags, String[] tagNames)
        {
            if (this.GraphSchemaEntity == null) return;

            int tmpKeyId = 0;
            int idx = 0;
            foreach (String tag in tags)
            {
                String tagName = "";
                if (tagNames != null && tagNames.Length > 0)
                {
                    if (tagNames[idx] != null)
                    {
                        tagName = tagNames[idx];
                    }
                }
                if (tagName.Length == 0 && !IsTagExpression(tag))
                {
                    String tagExpression = tag.Replace("[", "").Replace("]", "");
                    TagInfo tagMSInfo = DataProvider.TagProvider.GetById(tagExpression);
                    if (tagMSInfo != null && tagMSInfo.I_Tag_Name.Length > 0)
                    {
                        tagName = tagMSInfo.I_Tag_Name;
                    }
                }
                if (tags.Length == 1)
                {
                    this.Text = String.Format("{0}", tagName);
                }
                GraphSchemaItemInfo tmpItemInfo = new GraphSchemaItemInfo()
                {
                    TitleVisible = true,
                    Title = (tagName.Length == 0 ? String.Format("指标：{0}", tag) : String.Format("{0}：{1}", tagName, tag)),
                };
                this.GraphSchemaEntity.ItemList.Add(tmpItemInfo);
                GraphSchemaTagInfo tagInfo = new GraphSchemaTagInfo()
                {
                    CurveType = "Curve",
                    CurveColor = ColorSymbolRotator.StaticNextColor.ToArgb(),
                    LineType = 2,
                    LineWidth = 1,
                    MAPeriod = 1,
                    SymbolColor = ColorSymbolRotator.StaticNextColor.ToArgb(),
                    SymbolSize = 3,
                    SymbolType = ColorSymbolRotator.StaticInstance.NextSymbol.ToString(),
                    TagId = tag,
                    TagName = (tagName.Length == 0 ? tag : tagName),
                    KeyId = tmpKeyId++,
                };
                tmpItemInfo.TagList.Add(tagInfo);
            }

            this.AllocateMemory();
        }

        /// <summary>
        /// 申请存储数据的内存。
        /// </summary>
        private void AllocateMemory()
        {
            foreach (GraphSchemaItemInfo itemInfo in this.GraphSchemaEntity.ItemList)
            {
                foreach (GraphSchemaTagInfo tagInfo in itemInfo.TagList)
                {
                    if (IsJapaneseCandleStick(tagInfo))
                    {
                        if (!_splCollection.Contains(tagInfo.TagId))
                        {
                            _splCollection.Add(tagInfo.TagId);
                            _splCollection[tagInfo.TagId] = new StockPointList();
                        }
                        xSPLCollection.Add(tagInfo.KeyId);
                        xSPLCollection[tagInfo.KeyId] = new StockPointList();
                    }
                    else
                    {
                        if (!_pplCollection.Contains(tagInfo.TagId))
                        {
                            _pplCollection.Add(tagInfo.TagId);
                            _pplCollection[tagInfo.TagId] = new PointPairList();
                        }
                        xPPLCollection.Add(tagInfo.KeyId);
                        xPPLCollection[tagInfo.KeyId] = new PointPairList();
                        if (tagInfo.CurveType == "CurveMA")
                        {
                            xPPLCollection.Add(tagInfo.KeyId + _MA);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 检验是否是指标表达式。
        /// </summary>
        /// <param name="tagExpression">指标。</param>
        /// <returns></returns>
        private bool IsTagExpression(String tagExpression)
        {
            bool isExpression = false;
            if (tagExpression.Contains("[") && tagExpression.Contains("]"))
            {
                if (!tagExpression.StartsWith("[") || !tagExpression.EndsWith("]") ||
                    tagExpression.Substring(1).Contains("["))
                {
                    isExpression = true;
                }               
            }
            return isExpression;
        }

        /// <summary>
        /// 判断是否是 K 线图。//JapaneseCandleStick
        /// </summary>
        /// <param name="tagInfo"></param>
        /// <returns></returns>
        private static Boolean IsJapaneseCandleStick(GraphSchemaTagInfo tagInfo)
        {
            return tagInfo.CurveType.Equals("JapaneseCandleStick");
        }

        /// <summary>
        /// 创建 Graph， 画图。
        /// </summary>
        private void CreateGraph()
        {
            graph.IsEnableHZoom = false;
            graph.IsEnableVZoom = false;
            graph.IsEnableSelection = false;
            graph.IsEnableHPan = false;
            graph.IsEnableVPan = false;
            if (this.GraphSchemaEntity.ItemList.Count > 0)
            {
                MasterPane masterPane = graph.MasterPane;
                masterPane.PaneList.Clear();

                var arrMargin = this.GraphSchemaEntity.Margin.Split(' ');
                if (arrMargin.Length == 1)
                {
                    masterPane.Margin.All = Convert.ToSingle(String.IsNullOrEmpty(arrMargin[0]) ? "0" : arrMargin[0]);
                }
                else
                {
                    masterPane.Margin.Left = Convert.ToSingle(String.IsNullOrEmpty(arrMargin[0]) ? "0" : arrMargin[0]);
                    masterPane.Margin.Top = Convert.ToSingle(String.IsNullOrEmpty(arrMargin[1]) ? "0" : arrMargin[1]);
                    masterPane.Margin.Right = Convert.ToSingle(String.IsNullOrEmpty(arrMargin[2]) ? "0" : arrMargin[2]);
                    masterPane.Margin.Bottom = Convert.ToSingle(String.IsNullOrEmpty(arrMargin[3]) ? "0" : arrMargin[3]);
                }
                masterPane.InnerPaneGap = this.GraphSchemaEntity.InnerPaneGap;
                graph.IsSynchronizeXAxes = true;
                masterPane.IsFontsScaled = false;
                masterPane.IsCommonScaleFactor = true;

                masterPane.Title.IsVisible = this.GraphSchemaEntity.TitleVisible;
                if (this.GraphSchemaEntity.TitleVisible)
                {
                    masterPane.Title.Text = this.GraphSchemaEntity.Title;
                    masterPane.Title.FontSpec.Size = this.GraphSchemaEntity.TitleFontSize;
                    masterPane.Title.FontSpec.Family = this.GraphSchemaEntity.TitleFontFamily;
                }

                masterPane.Legend.IsVisible = this.GraphSchemaEntity.LegendVisible;
                if (this.GraphSchemaEntity.LegendVisible)
                {
                    masterPane.Legend.FontSpec.Family = this.GraphSchemaEntity.LegendFontFamily;
                    masterPane.Legend.FontSpec.Size = this.GraphSchemaEntity.LegendFontSize;
                    masterPane.Legend.IsShowLegendSymbols = this.GraphSchemaEntity.LegendIsShowSymbols;
                    masterPane.Legend.IsHStack = this.GraphSchemaEntity.LegendIsHStack;
                    try
                    {
                        masterPane.Legend.Position = (LegendPos)Enum.Parse(typeof(LegendPos), this.GraphSchemaEntity.LegendPosition);
                    }
                    catch
                    {
                        masterPane.Legend.Position = LegendPos.Top;
                    }
                    masterPane.Legend.Gap = 0.2F;
                }
                
                int paneIndex = 0;
                int paneCount = this.GraphSchemaEntity.ItemList.Count;
                DateTime xMaxTime = Common.GetReelTimeXAxisMaxTime(this.CurrentDataType);
                DateTime xMinTime = Common.GetXAxisMinTime(xMaxTime, this.CurrentDataType);
                foreach (GraphSchemaItemInfo itemInfo in this.GraphSchemaEntity.ItemList)
                {
                    var myPane = new GraphPane(new Rectangle(40, 40, 800, 600),
                                               itemInfo.Title, itemInfo.XAxis, itemInfo.YAxis);
                    myPane.Title.IsVisible = itemInfo.TitleVisible;
                    if (itemInfo.TitleVisible)
                    {
                        myPane.Title.FontSpec.Size = itemInfo.TitleFontSize;
                        myPane.Title.FontSpec.Family = itemInfo.TitleFontFamily;
                    }

                    //myPane.XAxis.Title.FontSpec.Border.IsVisible = false;
                    //myPane.XAxis.Title.FontSpec.Border.Color = Color.Red;
                    //myPane.XAxis.Title.FontSpec.Fill = new Fill(Color.LightBlue, Color.LightSkyBlue, -90);
                    //myPane.YAxis.Title.FontSpec.Fill = new Fill(Color.LightBlue, Color.LightSkyBlue, -90);

                    myPane.Tag = itemInfo;
                    myPane.BaseDimension = 8.0F;
                    myPane.Border.IsVisible = false;                    
                    myPane.Legend.IsVisible = itemInfo.LegendVisible;                    
                    if (itemInfo.LegendVisible)
                    {
                        myPane.Legend.FontSpec.Family = itemInfo.LegendFontFamily;
                        myPane.Legend.FontSpec.Size = itemInfo.LegendFontSize;
                        myPane.Legend.IsShowLegendSymbols = itemInfo.LegendIsShowSymbols;
                        myPane.Legend.IsHStack = itemInfo.LegendIsHStack;
                        try 
                        {
                            myPane.Legend.Position = (LegendPos)Enum.Parse(typeof(LegendPos), itemInfo.LegendPosition);
                        }
                        catch
                        {
                            myPane.Legend.Position = LegendPos.Top;
                        }

                        myPane.Legend.Gap = 0.2F;
                        //myPane.Legend.Border.Style = System.Drawing.Drawing2D.DashStyle.
                        //myPane.Legend.Fill.Color = Color.FromArgb(100, myPane.Legend.Fill.Color);
                    }

                    //--------------
                    myPane.XAxis.Title.IsVisible = itemInfo.XTitleVisible;
                    if (itemInfo.XTitleVisible)
                    {
                        myPane.XAxis.Title.FontSpec.Size = itemInfo.XTitleFontSize;
                        myPane.XAxis.Title.FontSpec.Family = itemInfo.XTitleFontFamily;
                    }

                    myPane.XAxis.Scale.IsVisible = itemInfo.XScaleVisible;
                    if (itemInfo.XScaleVisible)
                    {
                        myPane.XAxis.Scale.FontSpec.Size = itemInfo.XScaleFontSize;
                        myPane.XAxis.Scale.FontSpec.Family = itemInfo.XScaleFontFamily;
                    }
                                        
                    myPane.YAxis.Scale.IsVisible = itemInfo.YScaleVisible;
                    if (itemInfo.YScaleVisible)
                    {
                        myPane.YAxis.Scale.FontSpec.Size = itemInfo.YScaleFontSize;
                        myPane.YAxis.Scale.FontSpec.Family = itemInfo.YScaleFontFaminly;
                    }
                    myPane.YAxis.Title.IsVisible = itemInfo.YTitleVisible;
                    if (itemInfo.YTitleVisible)
                    {
                        myPane.YAxis.Title.FontSpec.Size = itemInfo.YTitleFontSize;
                        myPane.YAxis.Title.FontSpec.Family = itemInfo.YTitleFontFamily;
                    }
                    
                    myPane.YAxis.MinSpace = itemInfo.MinSpaceL;
                    myPane.Y2Axis.MinSpace = itemInfo.MinSpaceR;

                    if (!String.IsNullOrEmpty(itemInfo.XScaleFormat))
                    {
                        myPane.XAxis.Scale.Format = itemInfo.XScaleFormat;
                    }
                    if (!String.IsNullOrEmpty(itemInfo.YScaleFormat))
                    {
                        myPane.YAxis.Scale.Format = itemInfo.YScaleFormat; 
                    }

                    myPane.XAxis.MajorTic.IsOutside = false;
                    myPane.XAxis.MinorTic.IsOutside = false;
                    myPane.XAxis.MajorGrid.IsVisible = true;
                    myPane.XAxis.MinorGrid.IsVisible = true;
                    myPane.XAxis.Scale.Align = AlignP.Inside;
                    myPane.YAxis.Scale.Align = AlignP.Inside;

                    myPane.Margin.All = 0;
                    myPane.IsFontsScaled = false;

                    if (paneIndex == 0)
                    {
                        myPane.Margin.Top = 10;
                    }
                    if (paneIndex == paneCount - 1)
                    {
                        myPane.Margin.Bottom = 10;
                    }

                    if (paneIndex > 0)
                    {
                        myPane.YAxis.Scale.IsSkipLastLabel = true;
                    }
                    //---------------

                    if (itemInfo.TagList.Count > 0)
                    {
                        foreach (GraphSchemaTagInfo tagInfo in itemInfo.TagList)
                        {
                            if (IsJapaneseCandleStick(tagInfo))
                            {
                                if (_splCollection[tagInfo.TagId] != null)
                                {
                                    xSPLCollection[tagInfo.KeyId] = _splCollection[tagInfo.TagId].Clone();
                                }
                            }
                            else
                            {
                                if (_pplCollection[tagInfo.TagId] != null)
                                {
                                    xPPLCollection[tagInfo.KeyId] = _pplCollection[tagInfo.TagId].Clone();
                                    if (tagInfo.CurveType == "CurveMA")
                                    {
                                        xPPLCollection[tagInfo.KeyId + _MA] = _pplCollection[tagInfo.TagId].Clone();
                                        for (Int32 i = tagInfo.MAPeriod; i < xPPLCollection[tagInfo.KeyId].Count; i++)
                                        {
                                            Double sum = 0.0;
                                            for (Int32 j = tagInfo.MAPeriod; j > 0; j--)
                                            {
                                                sum += xPPLCollection[tagInfo.KeyId][i - j].Y;
                                            }
                                            xPPLCollection[tagInfo.KeyId + _MA][i].Y = sum / tagInfo.MAPeriod;
                                        }
                                    }
                                }
                            }

                            switch (tagInfo.CurveType)
                            {
                                case "Bar":
                                    BarItem myBar = myPane.AddBar(tagInfo.TagName, xPPLCollection[tagInfo.KeyId],
                                                                  Color.FromArgb(tagInfo.CurveColor));
                                    myBar.Tag = tagInfo;
                                    break;
                                case "Curve":
                                    LineItem myCurve = myPane.AddCurve(tagInfo.TagName, xPPLCollection[tagInfo.KeyId],
                                                                       Color.FromArgb(tagInfo.CurveColor),
                                                                       SymbolType.Circle);
                                    myCurve.Tag = tagInfo;
                                    myCurve.Line.IsVisible = (tagInfo.LineType != 0);
                                    myCurve.Line.IsSmooth = (tagInfo.LineType != 1);
                                    myCurve.Line.IsAntiAlias = true;
                                    myCurve.Line.IsOptimizedDraw = false;
                                    myCurve.Line.Width = tagInfo.LineWidth;
                                    try
                                    {
                                        myCurve.Symbol.Type = (SymbolType)(Enum.Parse(typeof(SymbolType), tagInfo.SymbolType));
                                    }
                                    catch{ }
                                    myCurve.Symbol.Fill = new Fill(Color.FromArgb(tagInfo.SymbolColor == 0 ? tagInfo.CurveColor : tagInfo.SymbolColor));
                                    myCurve.Symbol.Size = tagInfo.SymbolSize;
                                    break;
                                case "CurveMA":                                    
                                    LineItem myCurveMA = myPane.AddCurve(tagInfo.TagName, xPPLCollection[tagInfo.KeyId + _MA],
                                                                       Color.FromArgb(tagInfo.CurveColor),
                                                                       SymbolType.Circle);
                                    myCurveMA.Tag = tagInfo;
                                    myCurveMA.Line.IsVisible = (tagInfo.LineType != 0);
                                    myCurveMA.Line.IsSmooth = (tagInfo.LineType != 1);
                                    myCurveMA.Line.IsAntiAlias = true;
                                    myCurveMA.Line.IsOptimizedDraw = true;
                                    myCurveMA.Line.Width = tagInfo.LineWidth;
                                    //myCurveMA.IsY2Axis = true;
                                    //myPane.Y2Axis.IsVisible = true;
                                    try
                                    {
                                        myCurveMA.Symbol.Type = (SymbolType)(Enum.Parse(typeof(SymbolType), tagInfo.SymbolType));
                                    }
                                    catch { }
                                    myCurveMA.Symbol.Fill = new Fill(Color.FromArgb(tagInfo.SymbolColor == 0 ? tagInfo.CurveColor : tagInfo.SymbolColor));
                                    myCurveMA.Symbol.Size = tagInfo.SymbolSize;
                                    break;
                                case "JapaneseCandleStick":
                                    JapaneseCandleStickItem myJCurve = myPane.AddJapaneseCandleStick(tagInfo.TagName, xSPLCollection[tagInfo.KeyId]);
                                    myJCurve.Tag = tagInfo;
                                    myJCurve.Stick.IsAutoSize = true;
                                    //myJCurve.Stick.Color = Color.FromArgb(tagInfo.CurveColor);
                                    myJCurve.Stick.Color = Color.Red;
                                    myJCurve.Stick.FallingBorder = new Border(Color.Black, 1F);
                                    myJCurve.Stick.FallingColor = Color.Green;
                                    myJCurve.Stick.FallingFill = new Fill(Color.Green);
                                    myJCurve.Stick.RisingBorder = new Border(Color.Black, 1F);
                                    myJCurve.Stick.RisingFill = new Fill(Color.Red);
                                    myJCurve.Label.FontSpec = new FontSpec(myPane.Legend.FontSpec) { FontColor = Color.FromArgb(tagInfo.CurveColor) };
                                    break;
                                default:
                                    TextObj text = new TextObj("曲线类型错误！", 0.18F, 0.40F, CoordType.PaneFraction);
                                    text.Location.AlignH = AlignH.Center;
                                    text.Location.AlignV = AlignV.Center;
                                    text.FontSpec.Border.IsVisible = false;
                                    text.FontSpec.Fill = new Fill(Color.White, Color.FromArgb(255, 0, 0), 45F);
                                    text.FontSpec.StringAlignment = StringAlignment.Center;
                                    text.FontSpec.Size = 24;
                                    text.ZOrder = ZOrder.A_InFront;
                                    myPane.GraphObjList.Add(text);
                                    break;
                            }
                        }
                    }
                    
                    myPane.IsBoundedRanges = false;
                    // Set the XAxis to date type
                    myPane.XAxis.Type = AxisType.Date;
                    //myPane.XAxis.Type = AxisType.DateAsOrdinal;
                    
                    //DateTime xMaxTime = Common.GetReelTimeXAxisMaxTime(this.CurrentDataType);
                    //DateTime xMinTime = Common.GetXAxisMinTime(xMaxTime, this.CurrentDataType);
                    myPane.XAxis.Scale.Min = (double)new XDate(xMinTime);
                    myPane.XAxis.Scale.Max = (double)new XDate(xMaxTime);
                    //this.RecordXScaleTime(xMinTime, xMaxTime);
                   
                    //myPane.BarSettings.ClusterScaleWidth = 100;
                    //// Bars are stacked
                    //myPane.BarSettings.Type = BarType.Stack;

                    myPane.YAxis.MajorGrid.IsVisible = true;
                    //myPane.XAxis.Scale.MinorStep
                    
                    // Set the XAxis labels
                    //myPane.XAxis.Scale.TextLabels = labels;

                    // Set the labels at an angle so they don't overlap
                    //myPane.XAxis.Scale.FontSpec.Angle = 30;
                    myPane.XAxis.Scale.Mag = 0;
                    //myPane.Chart.Fill = new Fill(Color.White, Color.LightYellow, 45.0F);
                    //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 90.0F);
                    //myPane.Chart.Fill = new Fill(Color.White, Color.LightCyan, 90.0F);
                    myPane.Chart.Fill = new Fill(Color.White, Color.Honeydew, 90.0F);
                    //myPane.Chart.Fill = new Fill(Color.White, Color.Ivory, 90.0F);

                    myPane.XAxis.MinorGrid.IsVisible = false;

                    //myPane.Chart.IsRectAuto = false;

                    masterPane.Add(myPane);
                    paneIndex++;
                }
                this.RecordXScaleTime(xMinTime, xMaxTime);
                
                #region 设置布局。
                using (Graphics g = graph.CreateGraphics())
                {
                    if (this.GraphSchemaEntity.Layout.Length > 0)
                    {
                        try
                        {
                            var aa = this.GraphSchemaEntity.Layout.Split('|');
                            var isColumnSpecified = aa[0].Equals("1");
                            if (aa.Length == 3)
                            {
                                var bb = aa[1].Split(',');
                                var cc = aa[2].Split(',');
                                if (bb.Length > 0 && bb.Length == cc.Length)
                                {
                                    var dd = new Int32[bb.Length];
                                    var ee = new Single[cc.Length];
                                    for (int i = 0; i < bb.Length; i++)
                                    {
                                        dd[i] = Convert.ToInt32(bb[i]);
                                        ee[i] = Convert.ToSingle(cc[i]);
                                    }
                                    masterPane.SetLayout(g, isColumnSpecified, dd, ee);
                                }
                            }
                            else
                            {
                                if (isColumnSpecified)
                                {
                                    masterPane.SetLayout(g, PaneLayout.SingleColumn);
                                }
                                else
                                {
                                    masterPane.SetLayout(g, PaneLayout.SingleRow);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            masterPane.SetLayout(g, PaneLayout.SingleColumn);
                            Logger.WarnFormat("方案[{0}]布局设置有误！已使用默认设置。", GraphSchemaEntity.Name);
                        }
                    }
                    else
                    {
                        masterPane.SetLayout(g, PaneLayout.SingleColumn);
                    }
                }

                #endregion

                this.SetScaleStep();
                graph.AxisChange();
            }

            if (DataItemBasePoint.Count > 0)
            {
                foreach (var dataItem in DataItemBasePoint)
                {
                    bool isJapaneseCandleStick = false;

                    var blockItem = dataItem.Tag as FloatingBlockItemInfo;
                    String tmpTag = blockItem.TagExp;
                    if (blockItem.TagExp.Contains(":"))
                    {
                        var tmpArray = blockItem.TagExp.Split(':');
                        tmpTag = tmpArray[0];
                        if (dataItem.ValueType != "V")
                            isJapaneseCandleStick = true;
                    }

                    if (isJapaneseCandleStick)
                    {
                        var spl = _splCollection[tmpTag];
                        xSPLCollection[dataItem.Key] = spl.Clone();
                        dataItem.Points = xSPLCollection[dataItem.Key];
                    }
                    else
                    {
                        PointPairList list = _pplCollection[tmpTag];
                        xPPLCollection[dataItem.Key] = list.Clone();
                        dataItem.Points = xPPLCollection[dataItem.Key];
                    }
                }
            }
        }

        /// <summary>
        /// 根据数据类型改变坐标轴值的显示样式。
        /// </summary>
        private void SetScaleStep()
        {
            foreach (var myPane in this.graph.MasterPane.PaneList)
            {
                switch (this.CurrentDataType)
                {
                    case "Min":
                        myPane.XAxis.Scale.MinorStep = 1;
                        myPane.XAxis.Scale.MinorUnit = DateUnit.Minute;
                        myPane.XAxis.Scale.MajorStep = 10;
                        myPane.XAxis.Scale.MajorUnit = DateUnit.Minute;
                        myPane.XAxis.Scale.Format = Common.DataTypeFormat.FormatMin;
                        break;
                    case "Min15":
                        myPane.XAxis.Scale.MinorStep = 15;
                        myPane.XAxis.Scale.MinorUnit = DateUnit.Minute;
                        myPane.XAxis.Scale.MajorStep = 2.5;
                        myPane.XAxis.Scale.MajorUnit = DateUnit.Day;
                        myPane.XAxis.Scale.Format = Common.DataTypeFormat.FormatMin15;
                        break;
                    case "Hour":
                        myPane.XAxis.Scale.MinorStep = 1;
                        myPane.XAxis.Scale.MinorUnit = DateUnit.Hour;
                        //myPane.XAxis.Scale.MajorStep = 12;
                        myPane.XAxis.Scale.MajorStep = 6;
                        myPane.XAxis.Scale.MajorUnit = DateUnit.Hour;
                        myPane.XAxis.Scale.Format = Common.DataTypeFormat.FormatHour;
                        break;
                    case "Day":
                        myPane.XAxis.Scale.MinorStep = 1;
                        myPane.XAxis.Scale.MinorUnit = DateUnit.Day;
                        myPane.XAxis.Scale.MajorStep = 10;
                        myPane.XAxis.Scale.MajorUnit = DateUnit.Day;
                        myPane.XAxis.Scale.Format = Common.DataTypeFormat.FormatDay;
                        break;
                    case "Month":
                        myPane.XAxis.Scale.MinorStep = 1;
                        myPane.XAxis.Scale.MinorUnit = DateUnit.Month;
                        myPane.XAxis.Scale.MajorStep = 1;
                        myPane.XAxis.Scale.MajorUnit = DateUnit.Year;
                        myPane.XAxis.Scale.Format = Common.DataTypeFormat.FormatMonth;
                        break;
                    case "Year":
                        //myPane.XAxis.Scale.MajorStep = 10;
                        myPane.XAxis.Scale.MinorStep = 1;
                        myPane.XAxis.Scale.MinorUnit = DateUnit.Year;
                        //myPane.XAxis.Scale.MajorUnit = DateUnit.Year;
                        //myPane.XAxis.Scale.MinorStepAuto = true;
                        myPane.XAxis.Scale.MajorStepAuto = true;
                        myPane.XAxis.Scale.Format = Common.DataTypeFormat.FormatYear;
                        break;
                }
            }
        }

        /// <summary>
        /// 刷新 Graph。
        /// </summary>
        /// <param name="refreshType">刷新的方式。</param>
        /// <param name="isToLeft">true:向左移； false:向右移。</param>
        private void RefreshGraph(RefreshType refreshType, Boolean isToLeft)
        {
            if (refreshType == RefreshType.Added)
            {
                lock (this)
                {
                    foreach (var myPane in graph.MasterPane.PaneList)
                    {
                        foreach (var curveItem in myPane.CurveList)
                        {
                            GraphSchemaTagInfo tagInfo = (GraphSchemaTagInfo)curveItem.Tag;
                            if (IsJapaneseCandleStick(tagInfo))
                            {
                                var spl = _splCollection[tagInfo.TagId];
                                if (isToLeft)
                                {
                                    xSPLCollection[tagInfo.KeyId].InsertRange(0, spl);
                                    graph.CurrentPointIndexAdd(curveItem, spl.Count);
                                }
                                else
                                {
                                    xSPLCollection[tagInfo.KeyId].AddRange(spl);                                    
                                }
                                //curveItem.Points = xSPLCollection[tagInfo.KeyId];
                            }
                            else
                            {
                                PointPairList list = _pplCollection[tagInfo.TagId];
                                if (isToLeft)
                                {
                                    xPPLCollection[tagInfo.KeyId].InsertRange(0, list);

                                    if (tagInfo.CurveType == "CurveMA")
                                    {
                                        xPPLCollection[tagInfo.KeyId + _MA] = xPPLCollection[tagInfo.KeyId].Clone();
                                        for (Int32 i = tagInfo.MAPeriod; i < xPPLCollection[tagInfo.KeyId].Count; i++)
                                        {
                                            Double sum = 0.0;
                                            for (Int32 j = tagInfo.MAPeriod; j > 0; j--)
                                            {
                                                sum += xPPLCollection[tagInfo.KeyId][i - j].Y;
                                            }
                                            xPPLCollection[tagInfo.KeyId + _MA][i].Y = sum / tagInfo.MAPeriod;
                                        }

                                        //引用类型，地址变了，故要重新赋值。
                                        curveItem.Points = xPPLCollection[tagInfo.KeyId + _MA];
                                    }
                                    graph.CurrentPointIndexAdd(curveItem, list.Count);
                                }
                                else
                                {
                                    Int32 inIndex = xPPLCollection[tagInfo.KeyId].Count;
                                    inIndex = Math.Max(inIndex, tagInfo.MAPeriod);
                                    xPPLCollection[tagInfo.KeyId].AddRange(list);
                                    if (tagInfo.CurveType == "CurveMA")
                                    {
                                        for (Int32 i = inIndex; i < xPPLCollection[tagInfo.KeyId].Count; i++)
                                        {
                                            Double sum = 0.0;
                                            for (Int32 j = tagInfo.MAPeriod; j > 0; j--)
                                            {
                                                sum += xPPLCollection[tagInfo.KeyId][i - j].Y;
                                            }
                                            xPPLCollection[tagInfo.KeyId + _MA].Add(new PointPair() { X = xPPLCollection[tagInfo.KeyId][i].X, Y = sum / tagInfo.MAPeriod });
                                        }
                                    }
                                }

                                //foreach (var pt in list)
                                //{
                                //    //curveItem.AddPoint(pt);
                                //    //xPPLCollection[tagInfo.KeyId].Add(pt);
                                //    //xPPLCollection[tagInfo.KeyId].Insert(0, pt);

                                //    //Trace.WriteLine(string.Format("{0}:point.X={1}:point.Y={2}:ItemId={3}:TagId={4}",
                                //    //                              curveItem.Points.Count, point.X, point.Y,
                                //    //                              ((GraphSchemaItemInfo)myPane.Tag).ItemId,
                                //    //                              ((GraphSchemaTagInfo)curveItem.Tag).TagId));
                                //}
                                //curveItem.Points = xPPLCollection[tagInfo.KeyId];
                            }
                        }
                    }

                    //FloatingBlock 实时的值。
                    if (DataItemBasePoint.Count > 0)
                    {
                        foreach (var dataItem in DataItemBasePoint)
                        {
                            bool isJapaneseCandleStick = false;

                            var blockItem = dataItem.Tag as FloatingBlockItemInfo;
                            String tmpTag = blockItem.TagExp;
                            if (blockItem.TagExp.Contains(":"))
                            {
                                var tmpArray = blockItem.TagExp.Split(':');
                                tmpTag = tmpArray[0];
                                if (dataItem.ValueType != "V")
                                    isJapaneseCandleStick = true;
                            }
                            if (isJapaneseCandleStick)
                            {
                                var spl = _splCollection[tmpTag];
                                if (isToLeft)
                                {
                                    xSPLCollection[dataItem.Key].InsertRange(0, spl);
                                }
                                else
                                {
                                    xSPLCollection[dataItem.Key].AddRange(spl);
                                }
                            }
                            else
                            {
                                PointPairList list = _pplCollection[tmpTag];
                                if (isToLeft)
                                {
                                    xPPLCollection[dataItem.Key].InsertRange(0, list);
                                }
                                else
                                {
                                    xPPLCollection[dataItem.Key].AddRange(list);
                                }
                            }
                        }
                    }
                }
            }
            else if (refreshType == RefreshType.Reset)
            {
                foreach (var myPane in graph.MasterPane.PaneList)
                {
                    foreach (var curveItem in myPane.CurveList)
                    {
                        GraphSchemaTagInfo tagInfo = (GraphSchemaTagInfo)curveItem.Tag;
                        if (IsJapaneseCandleStick(tagInfo))
                        {
                            StockPointList spl = _splCollection[tagInfo.TagId];
                            xSPLCollection[tagInfo.KeyId] = spl.Clone();
                            //引用类型，地址变了，故要重新赋值。
                            curveItem.Points = xSPLCollection[tagInfo.KeyId];
                        }
                        else
                        {
                            PointPairList list = _pplCollection[tagInfo.TagId];
                            xPPLCollection[tagInfo.KeyId] = list.Clone();

                            if (tagInfo.CurveType == "CurveMA")
                            {
                                xPPLCollection[tagInfo.KeyId + _MA] = list.Clone();

                                for (Int32 i = tagInfo.MAPeriod; i < xPPLCollection[tagInfo.KeyId].Count; i++)
                                {
                                    Double sum = 0.0;
                                    for (Int32 j = tagInfo.MAPeriod; j > 0; j--)
                                    {
                                        sum += xPPLCollection[tagInfo.KeyId][i - j].Y;
                                    }
                                    xPPLCollection[tagInfo.KeyId + _MA][i].Y = sum / tagInfo.MAPeriod;
                                }

                                //引用类型，地址变了，故要重新赋值。
                                curveItem.Points = xPPLCollection[tagInfo.KeyId + _MA];
                            }
                            else 
                            {
                                //引用类型，地址变了，故要重新赋值。
                                curveItem.Points = xPPLCollection[tagInfo.KeyId];
                            }                      
                        }
                    }
                }

                //FloatingBlock 实时的值。
                if (DataItemBasePoint.Count > 0)
                {
                    foreach (var dataItem in DataItemBasePoint)
                    {
                        bool isJapaneseCandleStick = false;

                        var blockItem = dataItem.Tag as FloatingBlockItemInfo;
                        String tmpTag = blockItem.TagExp;
                        if (blockItem.TagExp.Contains(":"))
                        {
                            var tmpArray = blockItem.TagExp.Split(':');
                            tmpTag = tmpArray[0];
                            if(dataItem.ValueType != "V")
                                isJapaneseCandleStick = true;
                        }

                        if (isJapaneseCandleStick)
                        {
                            var spl = _splCollection[tmpTag];
                            xSPLCollection[dataItem.Key] = spl.Clone();
                            dataItem.Points = xSPLCollection[dataItem.Key];
                        }
                        else
                        {
                            PointPairList list = _pplCollection[tmpTag];
                            xPPLCollection[dataItem.Key] = list.Clone();
                            dataItem.Points = xPPLCollection[dataItem.Key];
                        }
                    }
                }
                this.SetScaleStep();
            }

            graph.AxisChange();
            graph.Invalidate();
        }

        /// <summary>
        /// 切换指标周期。
        /// </summary>
        private void ChangeGraphDataType(DateTime endTime)
        {
            if (isLoadingCurveData) return;
            if (this.GraphSchemaEntity == null) return;
            isLoadingCurveData = true;
            
            Int32 year, month, day, hour, minute, second, millisecond;
            StockPointList spl;
            PointPairList pointPairList;
            DateTime beginTime = Common.GetXAxisMinTime(endTime, this.CurrentDataType);
            MinTime = beginTime;
            //MaxTime = endTime;
            MaxTime = DateTime.MinValue;
            _pplCollection.Clear();
            _splCollection.Clear();
            
            foreach (GraphSchemaItemInfo itemInfo in this.GraphSchemaEntity.ItemList)
            {
                foreach (GraphSchemaTagInfo tagInfo in itemInfo.TagList)
                {
                    if (IsJapaneseCandleStick(tagInfo))
                    {
                        if (_splCollection.Contains(tagInfo.TagId) && !_splCollection.Get(tagInfo.TagId).IsEmpty) continue;
                    }
                    else
                    {
                        if (_pplCollection.Contains(tagInfo.TagId) && !_pplCollection.Get(tagInfo.TagId).IsEmpty) continue;
                    }
                    pointPairList = new PointPairList();
                    spl = new StockPointList();

                    Common.GetGraphData(this.CurrentDataType, beginTime, endTime, tagInfo.TagId, IsJapaneseCandleStick(tagInfo), ref pointPairList, ref spl, true);

                    if (IsJapaneseCandleStick(tagInfo))
                    {
                        if (spl.Count > 0)
                        {
                            spl.Sort((a, b) => a.X.CompareTo(b.X));
                            XDate.XLDateToCalendarDate(spl[spl.Count - 1].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                            DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                            if (MaxTime < dateTime) MaxTime = dateTime;
                        }
                        _splCollection[tagInfo.TagId] = spl;
                        //_splCollection.Get(tagInfo.TagId).IsEmpty = false;
                    }
                    else
                    {
                        if (pointPairList.Count > 0)
                        {
                            pointPairList.Sort(SortType.XValues);
                            XDate.XLDateToCalendarDate(pointPairList[pointPairList.Count - 1].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                            DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                            if (MaxTime < dateTime) MaxTime = dateTime;
                        }
                        _pplCollection[tagInfo.TagId] = pointPairList;
                        //_pplCollection.Get(tagInfo.TagId).IsEmpty = false;
                    }
                }
            }

            isLoadingCurveData = false;
            if (MaxTime.Equals(DateTime.MinValue)) MaxTime = endTime;

            foreach (var myPane in graph.MasterPane.PaneList)
            {
                myPane.XAxis.Scale.Min = (double)new XDate(beginTime);
                myPane.XAxis.Scale.Max = (double)new XDate(endTime);
            }

            RecordXScaleTime(beginTime, endTime);
            this.GetInstantFloatingData(beginTime, endTime);
            this.RefreshGraph(RefreshType.Reset, false);

            this._isZoomed = false;
            this._isMoved = false;
        }

        /// <summary>
        /// 切换指标周期。
        /// </summary>
        private void ChangeGraphDataType(object objEndTime)
        {
            this.ChangeGraphDataType(Convert.ToDateTime(objEndTime));
        }
        
        /// <summary>
        /// 切换实时更新状态。
        /// </summary>
        /// <param name="isStop">false:开始;true:停止。</param>
        private void ChangeUpdateState(Boolean isStop)
        {
            if(isStop)
            {
                this.timerUpdate.Stop();
                isRealTime = false;
            }
            else
            {
                this.timerUpdate.Enabled = this.isUpdateEnabled;
                isRealTime = true;
            }
        }

        /// <summary>
        /// 移动时更新数据。
        /// </summary>
        /// <param name="isToLeft">true:向左移； false:向右移。</param>
        /// <param name="sideTime">曲线的边界时间，曲线上最大(左移)或最小(右移)的时间。</param>
        private void MoveUpdate(Boolean isToLeft, DateTime sideTime)
        {
            MoveUpdate(isToLeft, sideTime, onceReadCount);
        }

        /// <summary>
        /// 移动时更新数据。
        /// </summary>
        /// <param name="isToLeft">true:向左移； false:向右移。</param>
        /// <param name="sideTime">曲线的边界时间，曲线上最大(左移)或最小(右移)的时间。</param>
        /// <param name="readCount">读取数据点的个数。</param>
        private void MoveUpdate(Boolean isToLeft, DateTime sideTime, int readCount)
        {
            if (sideTime.CompareTo(new DateTime(2002, 1, 1)) < 0 || sideTime.CompareTo(DateTime.Now) > 0)
            {
                if (this.isLoadingCurveData)
                    this.isLoadingCurveData = false;
                return;
            }
            if (this.GraphSchemaEntity == null) return;
            if (this.isLoadingCurveData) return;
            this.isLoadingCurveData = true;

            Int32 year, month, day, hour, minute, second, millisecond;
            StockPointList spl;
            PointPairList ppl;
            DateTime beginTime, endTime;
            DateTime tempTime = sideTime;
            _pplCollection.Clear();
            _splCollection.Clear();
            Int32 pCount = readCount;
           
            switch (this.CurrentDataType)
            {
                case "Min":
                    //先将最大或最小时间移动一个节点，以避免取重复的节点值。
                    sideTime = isToLeft ? sideTime.AddMinutes(-1) : sideTime.AddMinutes(1);
                    //再根据最大或最小时间计算出最小或最大时间。
                    tempTime = isToLeft ? sideTime.AddMinutes(-pCount) : sideTime.AddMinutes(pCount);
                    break;
                case "Min15":
                    sideTime = isToLeft ? sideTime.AddMinutes(-15) : sideTime.AddMinutes(15);
                    tempTime = isToLeft ? sideTime.AddMinutes(-15 * pCount) : sideTime.AddMinutes(15 * pCount);
                    break;
                case "Hour":
                    sideTime = isToLeft ? sideTime.AddHours(-1) : sideTime.AddHours(1);
                    tempTime = isToLeft ? sideTime.AddHours(-pCount) : sideTime.AddHours(pCount);
                    break;
                case "Day":
                    sideTime = isToLeft ? sideTime.AddDays(-1) : sideTime.AddDays(1);
                    tempTime = isToLeft ? sideTime.AddDays(-pCount) : sideTime.AddDays(pCount);
                    break;
                case "Month":
                    sideTime = isToLeft ? sideTime.AddMonths(-1) : sideTime.AddMonths(1);
                    tempTime = isToLeft ? sideTime.AddMonths(-pCount) : sideTime.AddMonths(pCount);
                    break;
                case "Year":
                    sideTime = isToLeft ? sideTime.AddYears(-1) : sideTime.AddYears(1);
                    tempTime = isToLeft ? sideTime.AddYears(-pCount) : sideTime.AddYears(pCount);
                    break;
            }
            if (isToLeft)
            {
                beginTime = tempTime;
                endTime = sideTime;
            }
            else
            {
                beginTime = sideTime;
                endTime = tempTime;
            }
            Boolean isResetSideTime = false;
            foreach (GraphSchemaItemInfo itemInfo in this.GraphSchemaEntity.ItemList)
            {
                foreach (GraphSchemaTagInfo tagInfo in itemInfo.TagList)
                {
                    if (IsJapaneseCandleStick(tagInfo))
                    {
                        if (_splCollection.Contains(tagInfo.TagId) && !_splCollection.Get(tagInfo.TagId).IsEmpty) continue;
                    }
                    else
                    {
                        if (_pplCollection.Contains(tagInfo.TagId) && !_pplCollection.Get(tagInfo.TagId).IsEmpty) continue;
                    }

                    ppl = new PointPairList();
                    spl = new StockPointList();

                    Common.GetGraphData(this.CurrentDataType, beginTime, endTime, tagInfo.TagId, IsJapaneseCandleStick(tagInfo), ref ppl, ref spl, true);                    
                    Double xlDate = Double.NaN;
                    if (IsJapaneseCandleStick(tagInfo))
                    {
                        if (spl.Count > 1)
                        {
                            spl.Sort((a, b) => a.X.CompareTo(b.X));
                        }
                        _splCollection[tagInfo.TagId] = spl;
                        //_splCollection.Get(tagInfo.TagId).IsEmpty = false;
                        if (spl.Count > 0)
                        {
                            xlDate = isToLeft ? spl[0].X : spl[spl.Count - 1].X;
                        }
                    }
                    else
                    {
                        if (ppl.Count > 1)
                        {
                            ppl.Sort(SortType.XValues);
                        }
                        _pplCollection[tagInfo.TagId] = ppl;
                        //_pplCollection.Get(tagInfo.TagId).IsEmpty = false;
                        if (ppl.Count > 0)
                        {
                            xlDate = isToLeft ? ppl[0].X : ppl[ppl.Count - 1].X;
                        }
                    }
                    //如果取到数据。
                    if (!Double.IsNaN(xlDate))
                    {
                        isResetSideTime = true;
                        XDate.XLDateToCalendarDate(xlDate, out year, out month, out day, out hour, out minute, out second, out millisecond);
                        DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                        if (isToLeft)
                        {
                            if (MinTime > dateTime) MinTime = dateTime;
                        }
                        else
                        {
                            if (MaxTime < dateTime) MaxTime = dateTime;
                        }
                    }
                }
            }
            
            if(isResetSideTime)
            {
                this.GetInstantFloatingData(beginTime, endTime);
                this.RefreshGraph(RefreshType.Added, isToLeft);
                this.isLoadingCurveData = false;
            }
            else　//如果没有取到数据。
            {
                if (isToLeft)
                {
                    MinTime = beginTime;
                    MoveUpdate(true, beginTime);
                    //this.AsyncGetData(true, beginTime);
                }
                else
                {
                    MaxTime = endTime;
                    MoveUpdate(false, endTime);
                    //this.AsyncGetData(false, endTime);
                }
            }            
        }

        /// <summary>
        /// 获取标签上的即时变动的数据。
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        private void GetInstantFloatingData(DateTime beginTime, DateTime endTime)
        {
            if (DataItemBasePoint.Count > 0)
            {
                foreach (var dataItem in DataItemBasePoint)
                {
                    bool isJapaneseCandleStick = (dataItem.ValueType != "V");
                    PointPairList tmp_ppl = new PointPairList();
                    StockPointList tmp_spl = new StockPointList();

                    var blockItem = dataItem.Tag as FloatingBlockItemInfo;
                    String tmpTag = blockItem.TagExp;
                    if (blockItem.TagExp.Contains(":"))
                    {
                        tmpTag = blockItem.TagExp.Split(':')[0];
                    }

                    if (_pplCollection.Contains(tmpTag) && !_pplCollection.Get(tmpTag).IsEmpty) continue;
                    if (_splCollection.Contains(tmpTag) && !_splCollection.Get(tmpTag).IsEmpty) continue;

                    Common.GetGraphData(this.CurrentDataType, beginTime, endTime, tmpTag, isJapaneseCandleStick, ref tmp_ppl, ref tmp_spl, true);

                    if (isJapaneseCandleStick)
                        _splCollection[tmpTag] = tmp_spl;
                    else
                        _pplCollection[tmpTag] = tmp_ppl;
                }
            }
        }

        /// <summary>
        /// 记录 X 轴的最小和最大时间。
        /// </summary>
        /// <param name="xMinTime"></param>
        /// <param name="xMaxTime"></param>
        private void RecordXScaleTime(DateTime xMinTime, DateTime xMaxTime)
        {
            if (this.XScaleMaxTime.Equals(xMaxTime))
            {
                if (!this.XScaleMinTime.Equals(xMinTime))
                    this.XScaleMinTime = xMinTime;
                return;
            }

            if (DataItemBaseTime.Count > 0)
            {
                this._isLoadingFloatingData = true;
                var x = (double)new XDate(xMaxTime);
                TimeSpan ts = this.XScaleMaxTime.Subtract(xMaxTime).Duration();
                //List<String> dataTypeTest = Common.GetDataTypeTest(this.XScaleMaxTime, xMaxTime);

                foreach (var dataItem in DataItemBaseTime)
                {
                    if (dataItem.ValueType == "T")
                    {
                        dataItem.X = x;
                        continue;
                    }
                    var blockItem = dataItem.Tag as FloatingBlockItemInfo;
                    //if (!dataTypeTest.Contains(blockItem.DataType))
                    //{
                    //    continue;
                    //}
                    if (xPPLCollection[dataItem.Key].Exists(o => o.X.Equals(x)))
                    {
                        dataItem.X = x;
                        continue;
                    }
                    String tagExp = blockItem.TagExp;

                    //是否是要获取时间。
                    bool isCalcDateTime = false;
                    #region 计算聚合函数的值。
                    if (Common.calcRegex.IsMatch(tagExp))
                    {
                        double calcValue = double.NaN;
                        MatchCollection matchs = Common.calcRegex.Matches(tagExp);
                        for (int i = 0; i < matchs.Count; i++)
                        {
                            Match match = matchs[i];
                            var rtnCalcFunc = Common.CalcFunc(blockItem.DataType, match.Value, xMaxTime);
                            if (rtnCalcFunc.ValueType == "V")
                            {
                                calcValue = rtnCalcFunc.PointValue;
                                tagExp = tagExp.Replace(match.Value, calcValue < 0 ? String.Format("(cast({0}, double))", calcValue) : String.Format("cast({0}, double)", calcValue));
                            }
                            else if (rtnCalcFunc.ValueType == "T")
                            {
                                dataItem.ValueString = rtnCalcFunc.PointTime;
                                isCalcDateTime = true;
                                break;
                            }
                        }
                    }
                    #endregion

                    if (!isCalcDateTime)
                    {
                        #region 计算总的表达式的值。
                        String[] tagIds = DistinctTag(tagExp);
                        IGenericExpression<double> MyExpression = CacheProvider.DefineExpression(tagExp, tagIds, false);
                        //MyExpression.Context.Imports.AddMethod(
                        for (var i = 0; i < tagIds.Length; i++)
                        {
                            String temp = tagIds[i];

                            String dtExp = temp.Substring(temp.IndexOf('@') + 1);
                            DateTime dateTime = Common.CalcDateTime(dtExp, xMaxTime);

                            tagExp = temp.Substring(0, temp.IndexOf('@'));
                            tagExp = tagExp.Substring(1, tagExp.Length - 2);
                            String tmpTag = tagExp;
                            String tmpType = "V";
                            bool isJapaneseCandleStick = false;
                            if (tagExp.Contains(":"))
                            {
                                var a4 = tagExp.Split(':');
                                tmpTag = a4[0];
                                tmpType = a4[1].ToUpper();
                                if (tmpType != "V")
                                    isJapaneseCandleStick = true;
                            }

                            PointPairList pointPairList = new PointPairList();
                            StockPointList spl = new StockPointList();
                            Common.GetGraphData(blockItem.DataType, dateTime, dateTime, tmpTag, isJapaneseCandleStick, ref pointPairList, ref spl, true);
                            double tagValue = 0.0d;

                            if (isJapaneseCandleStick)
                            {
                                if (spl.Count > 0)
                                {
                                    var pt = spl.GetAt(0);
                                    switch (tmpType)
                                    {
                                        case "O":
                                            tagValue = pt.Open;
                                            break;
                                        case "C":
                                            tagValue = pt.Close;
                                            break;
                                        case "H":
                                            tagValue = pt.High;
                                            break;
                                        case "L":
                                            tagValue = pt.LowValue;
                                            break;
                                        default:
                                            tagValue = pt.Y;
                                            break;
                                    }
                                }
                            }
                            else if (pointPairList.Count > 0)
                            {
                                var pt = pointPairList[0];
                                tagValue = pt.Y;
                            }
                            MyExpression.Context.Variables[string.Format("x{0}", i)] = tagValue;
                        }
                        double retValue = MyExpression.Evaluate();
                        xPPLCollection[dataItem.Key].Add(new PointPair(x, retValue));
                        dataItem.X = x;
                        #endregion
                    }
                }
                this._isLoadingFloatingData = false;
            }

            this.XScaleMinTime = xMinTime;
            this.XScaleMaxTime = xMaxTime;
        }

        /// <summary>
        /// 将指标表达式中出现的指标转换成一个唯一的指标数组。
        /// </summary>
        /// <param name="tagExp">指标表达式。</param>
        /// <returns>指标数组（唯一性）。</returns>
        private static String[] DistinctTag(String tagExp)
        {
            var tags = new List<String>();
            var mc = tagRegex.Matches(tagExp);
            for (var i = 0; i < mc.Count; i++)
            {
                var temp = mc[i].Value;                
                if (!tags.Contains(temp))
                {
                    tags.Add(temp);
                }
            }
            return tags.ToArray();
        }

        /// <summary>
        /// 获取当前鼠标位置是否在曲线的绘制范围内。
        /// </summary>
        /// <returns></returns>
        private bool IsMouseInChart()
        {
            bool isInChart = false;

            Point pt = graph.PointToClient(MousePosition);
            if (graph.Bounds.Contains(pt))
            {
                foreach (var pane in graph.MasterPane.PaneList)
                {
                    if (pane.Chart.Rect.Contains(pt))
                    {
                        isInChart = true;
                        break;
                    }
                }
            }

            return isInChart;
        }

        /// <summary>
        /// 获取曲线区域相对于屏幕的矩形。
        /// </summary>
        /// <returns></returns>
        private Rectangle GetGraphRect()
        {
            return RectangleToScreen(graph.Bounds);
        }
        #endregion

        #region Events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    graphKeyDown(keyData);
                    return true;
                case Keys.Control | Keys.Left:
                    //向左快速移动。
                    QuickMove(true);
                    return true;
                case Keys.Control | Keys.Right:
                    //向右快速移动。
                    QuickMove(false);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 根据数据类型将baseTime向左或向右调整pointCount个时间点。
        /// </summary>
        /// <param name="baseTime">要调整的时间。</param>
        /// <param name="strDateType">数据类型。Min,Min15,Hour,Day,Month,Year.</param>
        /// <param name="pointCount">调整时间点个数。</param>
        /// <param name="isToLeft">true:向左，false:向右。</param>
        /// <returns></returns>
        private DateTime AdjustTimes(DateTime baseTime, String strDateType, int pointCount, bool isToLeft)
        {
            int n = pointCount;
            DateTime rtnTime;
            switch (strDateType)
            {
                case "Min":
                    //先将最大或最小时间移动一个节点，以避免取重复的节点值。
                    rtnTime = isToLeft ? baseTime.AddMinutes(-1 * n) : baseTime.AddMinutes(1 * n);
                    break;
                case "Min15":
                    rtnTime = isToLeft ? baseTime.AddMinutes(-15 * n) : baseTime.AddMinutes(15 * n);
                    break;
                case "Hour":
                default :
                    rtnTime = isToLeft ? baseTime.AddHours(-1 * n) : baseTime.AddHours(1 * n);
                    break;
                case "Day":
                    rtnTime = isToLeft ? baseTime.AddDays(-1 * n) : baseTime.AddDays(1 * n);
                    break;
                case "Month":
                    rtnTime = isToLeft ? baseTime.AddMonths(-1 * n) : baseTime.AddMonths(1 * n);
                    break;
                case "Year":
                    rtnTime = isToLeft ? baseTime.AddYears(-1 * n) : baseTime.AddYears(1 * n);
                    break;
            }
            return rtnTime;
        }

        /// <summary>
        /// 向左或右快速移动，一次移动半屏。
        /// </summary>
        /// <param name="isToLeft">true:向左，false:向右。</param>
        private void QuickMove(bool isToLeft)
        {
            if (isRealTime) return;
            if (!IsMouseInChart()) return;
            
            Int32 year, month, day, hour, minute, second, millisecond;
            //先计算坐标轴上刻度数，再取值，调整坐标轴起始刻度。
            var pane = graph.MasterPane.PaneList[0];

            XDate.XLDateToCalendarDate(pane.XAxis.Scale.Max, out year, out month, out day, out hour, out minute, out second, out millisecond);
            DateTime maxTime = new DateTime(year, month, day, hour, minute, second, millisecond);
            XDate.XLDateToCalendarDate(pane.XAxis.Scale.Min, out year, out month, out day, out hour, out minute, out second, out millisecond);
            DateTime minTime = new DateTime(year, month, day, hour, minute, second, millisecond);

            TimeSpan ts = maxTime.Subtract(minTime);
            ts = new TimeSpan(ts.Ticks / 2);
            
            StockPointList spl;
            PointPairList ppl;
            _pplCollection.Clear();
            _splCollection.Clear();
            Boolean isNeedRefresh = false;//是否取得到数据，需要更新曲线。
            //是否需要取数据。
            bool isNeedRequestData = false;

            if (isToLeft)
            {
                #region Quick To Left.
                //移动之后的坐标轴最小和最大时间。
                DateTime dtXMinTime = minTime.AddTicks(ts.Ticks * (-1));
                DateTime dtXMaxTime = maxTime.AddTicks(ts.Ticks * (-1));
                if (dtXMinTime < MinTime)
                    isNeedRequestData = true;
                else
                    isNeedRequestData = false;

                if (isNeedRequestData)
                {
                    DateTime endTime = AdjustTimes(MinTime, this.CurrentDataType, 1, isToLeft);
                    if (endTime < new DateTime(2002, 1, 1))
                    {
                        return;
                    }
                    DateTime beginTime = endTime.AddTicks(ts.Ticks * (-1));
                    toolTipHandler.Show("正在加载数据，请稍候...", this.Bounds);

                    DateTime oldLastTime = MinTime;
                    DateTime newLastTime = MinTime;

                    foreach (GraphSchemaItemInfo itemInfo in this.GraphSchemaEntity.ItemList)
                    {
                        foreach (GraphSchemaTagInfo tagInfo in itemInfo.TagList)
                        {
                            if (IsJapaneseCandleStick(tagInfo))
                            {
                                if (_splCollection.Contains(tagInfo.TagId) && !_splCollection.Get(tagInfo.TagId).IsEmpty) continue;
                            }
                            else
                            {
                                if (_pplCollection.Contains(tagInfo.TagId) && !_pplCollection.Get(tagInfo.TagId).IsEmpty) continue;
                            }
                            ppl = new PointPairList();
                            spl = new StockPointList();

                            Common.GetGraphData(this.CurrentDataType, beginTime, endTime, tagInfo.TagId, IsJapaneseCandleStick(tagInfo), ref ppl, ref spl, true);

                            if (IsJapaneseCandleStick(tagInfo))
                            {
                                if (spl.Count > 1)
                                {
                                    spl.Sort((a, b) => a.X.CompareTo(b.X));
                                }
                                if (spl.Count > 0)
                                {
                                    isNeedRefresh = true;
                                    XDate.XLDateToCalendarDate(spl[0].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                                    DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                                    if (newLastTime > dateTime) newLastTime = dateTime;
                                }

                                _splCollection[tagInfo.TagId] = spl;
                            }
                            else
                            {
                                if (ppl.Count > 1)
                                {
                                    ppl.Sort(SortType.XValues);
                                }
                                if (ppl.Count > 0)
                                {
                                    isNeedRefresh = true;
                                    XDate.XLDateToCalendarDate(ppl[0].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                                    DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                                    if (newLastTime > dateTime) newLastTime = dateTime;
                                }
                                _pplCollection[tagInfo.TagId] = ppl;
                            }
                            this.MinTime = newLastTime;
                        }
                    }
                    if (isNeedRefresh && oldLastTime != MinTime)
                    {
                        //当取数据的频率设置时间过短时，会连续多次取到同一条数据，这时不应去更新界面，故返回。
                        this.GetInstantFloatingData(beginTime, endTime);
                        this.RefreshGraph(RefreshType.Added, isToLeft);
                    }

                    toolTipHandler.Close();
                }

                if (dtXMinTime >= MinTime)
                {
                    //当取数据的频率设置时间过短时，会连续多次取到同一条数据，这时不应去更新界面，故返回。
                    if (graph.MasterPane.PaneList.Count > 0)
                    {
                        foreach (var myPane in graph.MasterPane.PaneList)
                        {
                            myPane.XAxis.Scale.Min = new XDate(dtXMinTime);
                            myPane.XAxis.Scale.Max = new XDate(dtXMaxTime);
                        }
                        RecordXScaleTime(dtXMinTime, dtXMaxTime);

                        graph.Invalidate();
                    }
                }
                #endregion
            }
            else
            {
                #region Quick To Right.
                
                //移动之后的坐标轴最小和最大时间。
                DateTime dtXMinTime = minTime.AddTicks(ts.Ticks);
                DateTime dtXMaxTime = maxTime.AddTicks(ts.Ticks);
                if (dtXMaxTime > MaxTime)
                    isNeedRequestData = true;
                else
                    isNeedRequestData = false;

                if (isNeedRequestData)
                {
                    DateTime beginTime = AdjustTimes(MaxTime, this.CurrentDataType, 1, isToLeft);
                    if (beginTime > DateTime.Now)
                    {
                        return;
                    }
                    DateTime endTime = beginTime.AddTicks(ts.Ticks);
                    toolTipHandler.Show("正在加载数据，请稍候...", this.Bounds);

                    DateTime oldLastTime = MaxTime;
                    DateTime newLastTime = MaxTime;
                    foreach (GraphSchemaItemInfo itemInfo in this.GraphSchemaEntity.ItemList)
                    {
                        foreach (GraphSchemaTagInfo tagInfo in itemInfo.TagList)
                        {
                            if (IsJapaneseCandleStick(tagInfo))
                            {
                                if (_splCollection.Contains(tagInfo.TagId) && !_splCollection.Get(tagInfo.TagId).IsEmpty) continue;
                            }
                            else
                            {
                                if (_pplCollection.Contains(tagInfo.TagId) && !_pplCollection.Get(tagInfo.TagId).IsEmpty) continue;
                            }
                            ppl = new PointPairList();
                            spl = new StockPointList();

                            Common.GetGraphData(this.CurrentDataType, beginTime, endTime, tagInfo.TagId, IsJapaneseCandleStick(tagInfo), ref ppl, ref spl, true);

                            if (IsJapaneseCandleStick(tagInfo))
                            {
                                if (spl.Count > 1)
                                {
                                    spl.Sort((a, b) => a.X.CompareTo(b.X));
                                }
                                if (spl.Count > 0)
                                {
                                    isNeedRefresh = true;
                                    XDate.XLDateToCalendarDate(spl[spl.Count - 1].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                                    DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                                    if (newLastTime < dateTime) newLastTime = dateTime;
                                }

                                _splCollection[tagInfo.TagId] = spl;
                            }
                            else
                            {
                                if (ppl.Count > 1)
                                {
                                    ppl.Sort(SortType.XValues);
                                }
                                if (ppl.Count > 0)
                                {
                                    isNeedRefresh = true;
                                    XDate.XLDateToCalendarDate(ppl[ppl.Count - 1].X, out year, out month, out day, out hour, out minute, out second, out millisecond);
                                    DateTime dateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                                    if (newLastTime < dateTime) newLastTime = dateTime;
                                }
                                _pplCollection[tagInfo.TagId] = ppl;
                            }
                            this.MaxTime = newLastTime;
                        }
                    }

                    if (isNeedRefresh && oldLastTime != MaxTime)
                    {
                        //当取数据的频率设置时间过短时，会连续多次取到同一条数据，这时不应去更新界面，故返回。
                        this.GetInstantFloatingData(beginTime, endTime);
                        this.RefreshGraph(RefreshType.Added, false);
                    }
                    toolTipHandler.Close();
                }

                if (dtXMaxTime <= MaxTime)
                {
                    //当取数据的频率设置时间过短时，会连续多次取到同一条数据，这时不应去更新界面，故返回。
                    if (graph.MasterPane.PaneList.Count > 0)
                    {
                        foreach (var myPane in graph.MasterPane.PaneList)
                        {
                            myPane.XAxis.Scale.Min = new XDate(dtXMinTime);
                            myPane.XAxis.Scale.Max = new XDate(dtXMaxTime);
                        }
                        RecordXScaleTime(dtXMinTime, dtXMaxTime);

                        graph.Invalidate();
                    }
                }
                #endregion
            }
        }

        private void graphKeyDown(Keys keyData)
        {
            if (!IsMouseInChart()) return;

            int year, month, day, hour, minute, second, millisecond;
            Boolean isSide;
            if (keyData.Equals(Keys.Left)) //左移。
            {
                var pane = graph.MasterPane.PaneList[0];
                if (isRealTime && graph.CurrentPoint.X <= pane.XAxis.Scale.Min)
                    return;

                isSide = !graph.GuideLineGoTo(true);
                if (isSide)
                {
                    //因为提示窗口会使主窗口焦点丢失，从而使定位线位置出错，故注释掉。
                    //if (this.isLoadingCurveData)
                    //{
                    //    toolTipHandler.Show("正在加载数据，请稍候...", this.Bounds);
                    //}
                    return;
                }
                
                if (isRealTime)
                {
                    graph.Invalidate();
                    return;
                }
                if (graph.GetCurrentPointIndex() <= onceReadCount)
                {
                    this.AsyncMoveUpdate(true, MinTime);//获取数据.
                }
                
                if (graph.CurrentPoint.X <= pane.XAxis.Scale.Min)
                {
                    foreach (var myPane in graph.MasterPane.PaneList)
                    {
                        myPane.XAxis.Scale.Max -= (myPane.XAxis.Scale.Min - graph.CurrentPoint.X);
                        myPane.XAxis.Scale.Min = graph.CurrentPoint.X;
                    }

                    DateTime xMinTime, xMaxTime;
                    XDate.XLDateToCalendarDate(pane.XAxis.Scale.Min, out year, out month, out day, out hour, out minute, out second, out millisecond);
                    xMinTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                    XDate.XLDateToCalendarDate(pane.XAxis.Scale.Max, out year, out month, out day, out hour, out minute, out second, out millisecond);
                    xMaxTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                    this.RecordXScaleTime(xMinTime, xMaxTime);

                    this._isMoved = true;

                    graph.AxisChange();
                }
                graph.Invalidate();
            }
            else if (keyData.Equals(Keys.Right)) //右移。
            {
                isSide = !graph.GuideLineGoTo(false);
                //因为提示窗口会使主窗口焦点丢失，从而使定位线位置出错，故注释掉。
                //if ( && this.isLoadingCurveData)
                //{
                //    toolTipHandler.Show("正在加载数据，请稍候...", this.Bounds);
                //    return;
                //}
                if (isSide)
                {
                    return;
                }
                if (isRealTime)
                {
                    graph.Invalidate();
                    return;
                }
                if (graph.GetCurrentPointIndex() + onceReadCount >= graph.GetCurveNPts())
                {
                    this.AsyncMoveUpdate(false, MaxTime);
                }
                if (graph.MasterPane.PaneList.Count > 0)
                {
                    var pane = graph.MasterPane.PaneList[0];
                    if (graph.CurrentPoint.X >= pane.XAxis.Scale.Max)
                    {
                        foreach (var myPane in graph.MasterPane.PaneList)
                        {
                            myPane.XAxis.Scale.Min += (graph.CurrentPoint.X - myPane.XAxis.Scale.Max);
                            myPane.XAxis.Scale.Max = graph.CurrentPoint.X;
                        }

                        DateTime xMinTime, xMaxTime;
                        XDate.XLDateToCalendarDate(pane.XAxis.Scale.Min, out year, out month, out day, out hour, out minute, out second, out millisecond);
                        xMinTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                        XDate.XLDateToCalendarDate(pane.XAxis.Scale.Max, out year, out month, out day, out hour, out minute, out second, out millisecond);
                        xMaxTime = new DateTime(year, month, day, hour, minute, second, millisecond);
                        this.RecordXScaleTime(xMinTime, xMaxTime);

                        this._isMoved = true;

                        graph.AxisChange();
                    }
                }

                graph.Invalidate();
            }
            else if (keyData.Equals(Keys.Up)) //放大。
            {
                if (onceZoomCount <= 0) return;
                DateTime minTime;
                switch (this.CurrentDataType)
                {
                    case "Min":
                        minTime = this.XScaleMinTime.AddMinutes(onceZoomCount);
                        if (this.XScaleMaxTime.Subtract(minTime).TotalMinutes < 10)
                            return;
                        break;
                    case "Min15":
                        minTime = this.XScaleMinTime.AddMinutes(onceZoomCount * 15);
                        if (this.XScaleMaxTime.Subtract(minTime).TotalMinutes < 10 * 15)
                            return;
                        break;
                    case "Hour":
                        minTime = this.XScaleMinTime.AddHours(onceZoomCount);
                        if (this.XScaleMaxTime.Subtract(minTime).TotalHours < 10)
                            return;
                        break;
                    case "Day":
                        minTime = this.XScaleMinTime.AddDays(onceZoomCount);
                        if (this.XScaleMaxTime.Subtract(minTime).TotalDays < 10)
                            return;
                        break;
                    case "Month":
                        minTime = this.XScaleMinTime.AddMonths(onceZoomCount);
                        if (Common.CalcDiffMonths(minTime, this.XScaleMaxTime) < 10)
                            return;
                        break;
                    case "Year":
                        minTime = this.XScaleMinTime.AddYears(onceZoomCount);
                        if (this.XScaleMaxTime.Year - minTime.Year + 1 < 10)
                            return;
                        break;
                    default:
                        return;
                }               
                foreach (var myPane in graph.MasterPane.PaneList)
                {
                    myPane.XAxis.Scale.Min = (double)(new XDate(minTime));
                }
                this.RecordXScaleTime(minTime, this.XScaleMaxTime);
                //this.SetScaleStep();
                graph.AxisChange();
                graph.Invalidate();
                this._isZoomed = true;
            }
            else if (keyData.Equals(Keys.Down)) //缩小。
            {
                if (onceZoomCount <= 0) return;
                DateTime minTime;//缩小后的刻度最小时间。
                DateTime tmpMinTime;//应有预存数据的最小时间。
                switch (this.CurrentDataType)
                {
                    case "Min":
                        minTime = this.XScaleMinTime.AddMinutes(onceZoomCount * (-1));
                        tmpMinTime = this.XScaleMinTime.AddMinutes(onceZoomCount * (-1));
                        break;
                    case "Min15":
                        minTime = this.XScaleMinTime.AddMinutes(onceZoomCount * 15 * (-1));
                        tmpMinTime = this.XScaleMinTime.AddMinutes(onceReadCount * 15 * (-1));
                        break;
                    case "Hour":
                        minTime = this.XScaleMinTime.AddHours(onceZoomCount * (-1));
                        tmpMinTime = this.XScaleMinTime.AddHours(onceReadCount * (-1));
                        break;
                    case "Day":
                        minTime = this.XScaleMinTime.AddDays(onceZoomCount * (-1));
                        tmpMinTime = this.XScaleMinTime.AddDays(onceReadCount * (-1));
                        break;
                    case "Month":
                        minTime = this.XScaleMinTime.AddMonths(onceZoomCount * (-1));
                        tmpMinTime = this.XScaleMinTime.AddMonths(onceReadCount * (-1));
                        break;
                    case "Year":
                        minTime = this.XScaleMinTime.AddYears(onceZoomCount * (-1));
                        tmpMinTime = this.XScaleMinTime.AddYears(onceReadCount * (-1));
                        break;
                    default:
                        return;
                }

                if (minTime < this.MinTime && this.isLoadingCurveData)
                {
                    toolTipHandler.Show("正在加载数据，请稍候...", GetGraphRect());
                    return;
                }

                foreach (var myPane in graph.MasterPane.PaneList)
                {
                    myPane.XAxis.Scale.Min = (double)(new XDate(minTime));
                }
                this.RecordXScaleTime(minTime, this.XScaleMaxTime);
                //this.SetScaleStep();
                graph.AxisChange();
                graph.Invalidate();
                this._isZoomed = true;

                if (this.MinTime > tmpMinTime)
                {
                    this.AsyncMoveUpdate(true, this.MinTime);
                }
            }
        }

        private void graph_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta >= 120)
            {
                if (!IsMouseInChart()) return;
                //SendKeys.Send("{UP}");
                graphKeyDown(Keys.Up);
            }
            else if (e.Delta <= -120)
            {
                if (!IsMouseInChart()) return;
                //SendKeys.Send("{DOWN}");
                graphKeyDown(Keys.Down);
            }
        }

        private void graph_ContextMenuBuilder(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            ToolStripSeparator mySeparator = new ToolStripSeparator();
            menuStrip.Items.Insert(0, mySeparator);

            ToolStripMenuItem dataTypeItem = new ToolStripMenuItem { Tag = "DataType", Text = "数据类型" };
            menuStrip.Items.Insert(0, dataTypeItem);

            ToolStripMenuItem menuItem = new ToolStripMenuItem{Tag = "RealTime",Text = String.Format("实时 - {0}", Common.GetDataTypeName(this.GraphSchemaEntity.DataType))};
            if (isRealTime) menuItem.Checked = true;
            menuItem.Click += new EventHandler(menuItem_Click);
            dataTypeItem.DropDownItems.Add(menuItem);

            mySeparator = new ToolStripSeparator();
            mySeparator.Tag = "-";
            dataTypeItem.DropDownItems.Add(mySeparator);

            menuItem = new ToolStripMenuItem { Tag = "Min", Text = Common.GetDataTypeName("Min") };
            menuItem.Click += new EventHandler(menuItem_Click);
            dataTypeItem.DropDownItems.Add(menuItem);

            menuItem = new ToolStripMenuItem { Tag = "Min15", Text = Common.GetDataTypeName("Min15") };
            menuItem.Click += new EventHandler(menuItem_Click);
            dataTypeItem.DropDownItems.Add(menuItem);

            menuItem = new ToolStripMenuItem { Tag = "Hour", Text = Common.GetDataTypeName("Hour") };
            menuItem.Click += new EventHandler(menuItem_Click);
            dataTypeItem.DropDownItems.Add(menuItem);

            menuItem = new ToolStripMenuItem { Tag = "Day", Text = Common.GetDataTypeName("Day") };
            menuItem.Click += new EventHandler(menuItem_Click);
            dataTypeItem.DropDownItems.Add(menuItem);

            menuItem = new ToolStripMenuItem { Tag = "Month", Text = Common.GetDataTypeName("Month") };
            menuItem.Click += new EventHandler(menuItem_Click);
            dataTypeItem.DropDownItems.Add(menuItem);

            menuItem = new ToolStripMenuItem { Tag = "Year", Text = Common.GetDataTypeName("Year") };
            menuItem.Click += new EventHandler(menuItem_Click);
            dataTypeItem.DropDownItems.Add(menuItem);

            if (!isRealTime)
            {
                foreach (ToolStripItem item in dataTypeItem.DropDownItems)
                {
                    if (item is ToolStripSeparator) continue;
                    if (item.Tag.ToString().Equals(this.CurrentDataType))
                    {
                        ((ToolStripMenuItem)item).Checked = true;
                        break;
                    }
                }
            }

            ToolStripMenuItem menuSearch = new ToolStripMenuItem { Tag = "DataType", Text = "查询" };
            menuSearch.Click += new EventHandler(menuSearch_Click);
            menuStrip.Items.Insert(1, menuSearch);

            ToolStripMenuItem menuUndo = new ToolStripMenuItem { Tag = "UndoALL", Text = "还原缩放/移动" };
            menuUndo.Enabled = (this._isZoomed || this._isMoved);
            menuUndo.Click += new EventHandler(menuUndo_Click);
            menuStrip.Items.Insert(2, menuUndo);
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            if (isRealTime)
            {
                this.ChangeGraphDataType(Common.GetReelTimeXAxisMaxTime(this.CurrentDataType));
            }
            else
            {
                this.ChangeGraphDataType(Common.GetHistoricalXAxisMaxTime(this.CurrentDataType));
            }
        }
        
        private void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                DateTime endTime;
                String dataType = item.Tag.ToString();
                if (dataType.Equals("RealTime"))
                {
                    this.ChangeUpdateState(false);
                    this.CurrentDataType = this.GraphSchemaEntity.DataType;
                    endTime = Common.GetReelTimeXAxisMaxTime(this.CurrentDataType);
                }
                else
                {
                    this.ChangeUpdateState(true);
                    this.CurrentDataType = dataType;
                    endTime = Common.GetHistoricalXAxisMaxTime(this.CurrentDataType);
                }
                //new Thread(new ParameterizedThreadStart(ChangeGraphDataType)) { IsBackground = true }.Start(endTime);
                this.toolTipHandler.Show("正在切换数据类型，请稍候...", GetGraphRect());
                this.ChangeGraphDataType(endTime);
                this.toolTipHandler.Close();
            }
        }

        private void menuSearch_Click(object sender, EventArgs e)
        {
            FrmGraphSchemaSearch frmSearch = new FrmGraphSchemaSearch();
            frmSearch.DataType = this.CurrentDataType;
            frmSearch.EndTime = this.MaxTime == DateTime.MinValue ? DateTime.Now : this.MaxTime;
            if(frmSearch.ShowDialog() == DialogResult.OK)
            {
                this.ChangeUpdateState(true);
                this.CurrentDataType = frmSearch.DataType;

                //new Thread(new ParameterizedThreadStart(ChangeGraphDataType)) { IsBackground = true }.Start(frmSearch.EndTime);
                this.toolTipHandler.Show("正在执行查询，请稍候...", GetGraphRect());
                this.ChangeGraphDataType(frmSearch.EndTime);
                this.toolTipHandler.Close();
            }
            frmSearch.Dispose();
        }
        
        private void btnDraw_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            btnDrag.Image = splitContainer1.Panel2Collapsed ? Properties.Resources.pre : Properties.Resources.next;
        }

        private void FrmGraphSchemaStage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!this._isSaved && e.CloseReason == CloseReason.UserClosing)
            //{
            //    if (MessageBox.Show("曲线尚未保存，您要保存吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        var frmGraphSchemeEdit = new FrmGraphSchemaEdit(ActionType.Save)
            //        {
            //            GraphSchemeEntity = this.GraphSchemaEntity
            //        };
            //        if (frmGraphSchemeEdit.ShowDialog() == DialogResult.OK)
            //        {
            //            this.IsSaved = true;
            //        }
            //        frmGraphSchemeEdit.Dispose();
            //    }
            //}

            if (this.btnDrag.Visible && this.RestoreBounds.Width > 1023)
            {
                Int32 w = this.RestoreBounds.Width - this.splitContainer1.SplitterDistance;
                if (w != this.GraphSchemaEntity.TabWidth)
                {
                    this.GraphSchemaEntity.TabWidth = w;
                    DataProvider.GraphSchemaProvider.Update(GraphSchemaEntity);
                }
            }
        }
        #endregion

        #region 多线程取数据。

        /// <summary>
        /// 线程获取数据。
        /// </summary>
        /// <param name="isToLeft"></param>
        /// <param name="sideTime"></param>
        private void AsyncMoveUpdate(Boolean isToLeft, DateTime sideTime)
        {
            var mvd = new MoveUpdateDelegate(MoveUpdate);
            mvd.BeginInvoke(isToLeft, sideTime, MoveUpdateCallback, null);
        }

        private void MoveUpdateCallback(IAsyncResult Iar)
        {
            //if (Iar.IsCompleted)
            //{
                toolTipHandler.Close();
            //}
        }
        #endregion //多线程取数据。

        #region 浮动窗口。
        private List<FloatingDataItem> _dataItemBasePoint;
        private List<FloatingDataItem> _dataItemBaseTime;
        private List<FloatingBlockInfo> FloatingBlockList { get; set; }
        /// <summary>
        /// 要跟随当前点变动的标签。
        /// </summary>
        private List<FloatingDataItem> DataItemBasePoint
        {
            get
            {
                if (_dataItemBasePoint == null)
                    _dataItemBasePoint = new List<FloatingDataItem>();
                return _dataItemBasePoint;
            }
            set
            { _dataItemBasePoint = value; }
        }
        /// <summary>
        /// 要跟随指定时间变动的标签。
        /// </summary>
        private List<FloatingDataItem> DataItemBaseTime
        {
            get
            {
                if (_dataItemBaseTime == null)
                    _dataItemBaseTime = new List<FloatingDataItem>();
                return _dataItemBaseTime;
            }
            set { _dataItemBaseTime = value; }
        }

        private void GetFloatingBlocks()
        {
            this.FloatingBlockList = DataProvider.FloatingBlockProvider.GetBySchemaId(GraphSchemaEntity.SchemaId);
            foreach (var block in this.FloatingBlockList)
            {
                var blockItems = DataProvider.FloatingBlockItemProvider.GetByBlockId(block.BlockId);
                if (blockItems.Count > 0)
                    block.ItemList.AddRange(blockItems);
            }
        }

        private void CreateFloatingBlocks()
        {
            foreach (var block in FloatingBlockList)
            {
                FloatingBlock ctlBlock = new FloatingBlock(block.X, block.Y);
                ctlBlock.Border.Color = Color.FromArgb(block.BorderColor);
                ctlBlock.Fill.Color = Color.FromArgb(block.FillColor);
                ctlBlock.LabelFontSpec.Family = block.LableFontFamily;
                ctlBlock.LabelFontSpec.FontColor = Color.FromArgb(block.LableForeColor);
                ctlBlock.LabelFontSpec.Size = block.LableFontSize;
                ctlBlock.IsLabelInLine = block.IsLabelInLine;
                if (!block.IsAutoSize && block.Width > 0 && block.Height > 0)
                {
                    ctlBlock.RectF = new RectangleF(block.X, block.Y, block.Width, block.Height);
                    ctlBlock.IsAutoSize = false;
                }
                else
                    ctlBlock.IsAutoSize = true;

                foreach (var blockItem in block.ItemList)
                {
                    FloatingDataItem dataItem = new FloatingDataItem();
                    dataItem.Tag = blockItem;
                    dataItem.Key = blockItem.BlockItemId + _FB;
                    dataItem.Label = blockItem.Label;
                    dataItem.UnitFontSpec.Family = blockItem.UnitFontFamily;
                    dataItem.UnitFontSpec.Size = blockItem.UnitFontSize;
                    dataItem.UnitFontSpec.FontColor = Color.FromArgb(blockItem.UnitForeColor);
                    dataItem.ValueFontSpec.Family = blockItem.ValueFontFamily;
                    dataItem.ValueFontSpec.Size = blockItem.ValueFontSize;
                    dataItem.ValueFontSpec.FontColor = Color.FromArgb(blockItem.ValueForeColor);
                    dataItem.Unit = blockItem.Unit;                    
                    ctlBlock.FloatingData.Add(dataItem);

                    if (blockItem.TagExp == "T")//坐标轴最大时间。
                    {
                        dataItem.ValueType = blockItem.TagExp;
                        dataItem.IsInstant = false;
                        DataItemBaseTime.Add(dataItem);
                        continue;
                    }
                    //else if (blockItem.TagExp.Contains("@") || maxRegex.IsMatch(blockItem.TagExp) ||
                    //    minRegex.IsMatch(blockItem.TagExp) || avgRegex.IsMatch(blockItem.TagExp) ||
                    //    sumRegex.IsMatch(blockItem.TagExp))
                    else if (blockItem.TagExp.Contains("@") || Common.calcRegex.IsMatch(blockItem.TagExp))
                    {
                        DataItemBaseTime.Add(dataItem);
                        dataItem.IsInstant = false;
                        continue;
                    }

                    if (blockItem.TagExp == "CT") //鼠标时间。
                    {
                        dataItem.IsInstant = true;
                        dataItem.ValueType = blockItem.TagExp;
                    }
                    else if (blockItem.TagExp.Contains("[") && blockItem.TagExp.Contains("]"))
                    {
                        if (blockItem.TagExp.Contains(":"))
                        {
                            String[] tmpArray = blockItem.TagExp.Split(':');
                            dataItem.ValueType = tmpArray[1];
                        }
                        dataItem.IsInstant = true;
                        DataItemBasePoint.Add(dataItem);
                    }
                    else //固定数字或者固定数字的表达式。如 1 或 1+2。
                    {
                        blockItem.DataType = "Year";
                        dataItem.IsInstant = false;
                        DataItemBaseTime.Add(dataItem);
                    }
                }
                graph.FloatingBlocks.Add(ctlBlock);
            }

            if (DataItemBaseTime.Count > 0)
            {
                foreach (var dataItem in DataItemBaseTime)
                {
                    xPPLCollection.Add(dataItem.Key);
                    xPPLCollection[dataItem.Key] = new PointPairList();
                    dataItem.Points = xPPLCollection[dataItem.Key];
                }
            }

            if (DataItemBasePoint.Count > 0)
            {
                foreach (var dataItem in DataItemBasePoint)
                {
                    bool isJapaneseCandleStick = false;
                    var blockItem = dataItem.Tag as FloatingBlockItemInfo;
                    String tmpTag = blockItem.TagExp;
                    if(blockItem.TagExp.Contains(":"))
                    {
                        String[] tmpArray = blockItem.TagExp.Split(':');
                        tmpTag = tmpArray[0];
                        if (dataItem.ValueType != "V")
                            isJapaneseCandleStick = true;
                    }

                    if (isJapaneseCandleStick)
                    {
                        if (!_splCollection.Contains(tmpTag))
                        {
                            _splCollection.Add(tmpTag);
                            _splCollection[tmpTag] = new StockPointList();
                        }
                        xSPLCollection.Add(dataItem.Key);
                        xSPLCollection[dataItem.Key] = new StockPointList();

                        dataItem.Points = xSPLCollection[dataItem.Key];
                    }
                    else
                    {
                        if (!_pplCollection.Contains(tmpTag))
                        {
                            _pplCollection.Add(tmpTag);
                            _pplCollection[tmpTag] = new PointPairList();
                        }
                        xPPLCollection.Add(dataItem.Key);
                        xPPLCollection[dataItem.Key] = new PointPairList();

                        dataItem.Points = xPPLCollection[dataItem.Key];
                    }
                }
            }
        }

        #endregion

        #region 关联项。
        private List<UpdateDataRTag.GridViewRTagList> GridViewRTagLists = new List<UpdateDataRTag.GridViewRTagList>();
        
        /// <summary>
        /// 生成TabPage, 并绑定 RTag 列表。
        /// </summary>
        private void BindRTagList()
        {
            CreateTab();
            if (this.tabControl1.TabPages.Count > 0)
            {
                updateDataRTag = new UpdateDataRTag(GridViewRTagLists);
                if (this.RestoreBounds.Width - this.GraphSchemaEntity.TabWidth > 0)
                    this.splitContainer1.SplitterDistance = this.RestoreBounds.Width - this.GraphSchemaEntity.TabWidth;
            }
            else
            {
                this.btnDrag.Visible = false;
                this.tabControl1.Visible = false;
                this.splitContainer1.Panel2Collapsed = true;
            }
        }

        /// <summary>
        /// 绑定 RTag 列表。
        /// </summary>
        private void BindRTagList(DataGridView gridView, GraphSchemaTabInfo tabInfo)
        {
            List<GraphSchemaRTagInfo> rTagInfos = DataProvider.GraphSchemaRTagProvider.GetByTabId(tabInfo.TabId);
            if (rTagInfos != null && rTagInfos.Count > 0)
            {
                gridView.Columns[0].DataPropertyName = "TagName";
                gridView.Columns[1].DataPropertyName = "TagValue";
                gridView.Columns[2].DataPropertyName = "Unit";

                gridView.DataSource = rTagInfos;
                UpdateDataRTag.GridViewRTagList obj = new UpdateDataRTag.GridViewRTagList{
                      GridView = gridView,
                      RTagList = rTagInfos
                };
                GridViewRTagLists.Add(obj);
                gridView.CurrentCell = null;
            }
        }

        /// <summary>
        /// 生成 Tab。
        /// </summary>
        private void CreateTab()
        {
            var tabs = DataProvider.GraphSchemaTabProvider.GetBySchemaId(GraphSchemaEntity.SchemaId);
            tabControl1.SuspendLayout();

            foreach (var graphSchemaTabInfo in tabs)
            {
                if(!graphSchemaTabInfo.TabVisible) continue;

                TabPage tabPage = new TabPage();
                tabControl1.Controls.Add(tabPage);
                tabPage.Padding = new Padding(3);
                tabPage.Text = graphSchemaTabInfo.TabName;
                tabPage.UseVisualStyleBackColor = true;

                if (graphSchemaTabInfo.TabType == Convert.ToByte(TabType.RelativeTag))
                {
                    if (graphSchemaTabInfo.TitleVisible)
                    {
                        Panel panelTitle = new Panel
                                               {
                                                   Height = 50,
                                                   Dock = DockStyle.Top,
                                                   Margin = new Padding(0),
                                                   BorderStyle = BorderStyle.FixedSingle
                                               };
                        Label label = new Label
                                          {
                                              Text = graphSchemaTabInfo.Title,
                                              TextAlign = ContentAlignment.MiddleCenter,
                                              Dock = DockStyle.Fill,
                                              AutoEllipsis = true
                                          };
                        label.Font = new Font(label.Font.FontFamily, 14, FontStyle.Bold, GraphicsUnit.Point);

                        panelTitle.Controls.Add(label);
                        tabPage.Controls.Add(panelTitle);
                    }

                    Panel panel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        Padding = new Padding(0,2,0,0),
                        Location = new Point(0, 50),
                        BorderStyle = BorderStyle.None
                    };

                    var colTagName = new DataGridViewTextBoxColumn();
                    var colTagValue = new DataGridViewTextBoxColumn();
                    var colUnit = new DataGridViewTextBoxColumn();

                    DataGridView gridViewRTag = new DataGridView();
                    gridViewRTag.AutoGenerateColumns = false;
                    gridViewRTag.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    gridViewRTag.BackgroundColor = Color.White;
                    gridViewRTag.BorderStyle = BorderStyle.None;
                    gridViewRTag.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    gridViewRTag.Columns.AddRange(new DataGridViewColumn[] { colTagName, colTagValue, colUnit });
                    gridViewRTag.Dock = DockStyle.Fill;
                    gridViewRTag.Margin = new Padding(0);
                    gridViewRTag.RowHeadersVisible = false;
                    gridViewRTag.ColumnHeadersVisible = true;
                    gridViewRTag.RowTemplate.Height = 24;
                    gridViewRTag.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                    gridViewRTag.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gridViewRTag.AllowUserToAddRows = false;
                    gridViewRTag.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

                    DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                    dataGridViewCellStyle1.Font = new Font("宋体", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
                    colTagName.DefaultCellStyle = dataGridViewCellStyle1;
                    colTagName.HeaderText = "指标";
                    colTagName.ReadOnly = true;
                    colTagName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    colTagName.FillWeight = 100F;
                    
                    DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
                    dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colTagValue.DefaultCellStyle = dataGridViewCellStyle2;
                    colTagValue.HeaderText = "指标值";
                    colTagValue.ReadOnly = true;
                    colTagValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    colTagName.FillWeight = 50F;

                    colUnit.HeaderText = "单位";
                    colUnit.ReadOnly = true;
                    colUnit.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    colTagName.FillWeight = 60F;

                    panel.Controls.Add(gridViewRTag);
                    tabPage.Controls.Add(panel);
                    panel.BringToFront();

                    BindRTagList(gridViewRTag, graphSchemaTabInfo);
                }
                tabControl1.ResumeLayout(false);
            }
        }
        #endregion

        #region IBaseForm 实现
        public LoadState GetLoadState()
        {
            LoadState loadState = LoadState.Unknown;
            if (isLoadingCurveData || _isLoadingFloatingData)
            {
                loadState = LoadState.Loading;
            }
            else if (updateDataRTag != null)
            {
                if (updateDataRTag.IsStopped)
                {
                    loadState = LoadState.Stopped;
                }
                else if (updateDataRTag.IsFinished)
                {
                    loadState = LoadState.Finished;
                }
                else
                {
                    loadState = LoadState.Loading;
                }
            }           
            return loadState;
        }
        #endregion

    }
}
