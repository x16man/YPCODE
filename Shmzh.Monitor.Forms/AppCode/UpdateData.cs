using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Shmzh.Monitor.Config;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Gadget;


namespace Shmzh.Monitor.Forms
{
    public class UpdateData : UpdateBase
    {
        #region Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        ///// <summary>
        ///// 取数据时单个线程所包含的对象个数。
        ///// </summary>
        //private static Int32 threadObjCount = 0;
        //private Int32 _runThreads = 0;
        private static Regex devRegex = new Regex(@"[\{|\}|\[|\]]");
        private Stopwatch _stopwatch = new Stopwatch();
        #endregion

        #region Constructor
        public UpdateData(Control form, MonitorConfig mConfig)
            : base(form,mConfig)
        {
            
            //if (threadObjCount == 0)
            //{
            //    threadObjCount = ConfigurationManager.AppSettings["ThreadObjCount"] == null ? 10 : Convert.ToInt32(ConfigurationManager.AppSettings["ThreadObjCount"]);
            //}
        }
        #endregion

        
        #region Property
        ///// <summary>
        ///// 更新线程是否中止。
        ///// </summary>
        //public Boolean IsStopped { get; set; }

        ///// <summary>
        ///// 所有线程是否都已完成。
        ///// </summary>
        //public Boolean IsFinished
        //{
        //    get
        //    {
        //        return (_runThreads == 0);
        //    }
        //}

        
        /// <summary>
        /// 当前服务器时间。
        /// </summary>
        public DateTime CurrentServerTime { get; private set; }
        #endregion

        /// <summary>
        /// 将Tag、Device、Line集合以 OnceCount 个为一组进行拆分，每一组建一个线程进行取值。
        /// </summary>
        public void DoWork()
        { 
            Logger.Debug("in DoWork");
            if(_config == null) return;
            Logger.Debug("not return");
            if (!Shmzh.Components.Util.Internet.IsConnected()) return;
            //取服务器时间。
            CurrentServerTime = DataProvider.TagProvider.GetDate();
            _stopwatch.Reset();
            _stopwatch.Start();
            //Thread thread;
            Int32 count = threadObjCount;

            
            if (_config.DeviceList.Count > 0)
            {
                IsStopped = false;
                for (int i = 0; i < _config.DeviceList.Count; i += threadObjCount)
                {
                    count = _config.DeviceList.Count > threadObjCount + i
                                      ? threadObjCount
                                      : _config.DeviceList.Count - i;
                    this.IncreaseRunThreads();

                    //thread = new Thread(this.UpdateDeviceList) {IsBackground = true};
                    //thread.Start(_config.DeviceList.GetRange(i, count));

                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdateDeviceList), _config.DeviceList.GetRange(i, count));
                }
            }

            if(_config.LineList.Count > 0)
            {
                IsStopped = false;
                for (int i = 0; i < _config.LineList.Count; i += threadObjCount)
                {
                    count = _config.LineList.Count > threadObjCount + i
                                      ? threadObjCount
                                      : _config.LineList.Count - i;
                    this.IncreaseRunThreads();
                    //System.Diagnostics.Debug.WriteLine("Count:" + _runThreads.ToString());

                    //thread = new Thread(this.UpdateLineList) {IsBackground = true};
                    //thread.Start(_config.LineList.GetRange(i, count));

                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdateLineList), _config.LineList.GetRange(i, count));
                }
            }

            if(_config.TagImageList.Count > 0)
            {
                IsStopped = false;
                for (int i = 0; i < _config.TagImageList.Count; i += threadObjCount)
                {
                    count = _config.TagImageList.Count > threadObjCount + i
                                      ? threadObjCount
                                      : _config.TagImageList.Count - i;
                    this.IncreaseRunThreads();
                    //System.Diagnostics.Debug.WriteLine("Count:" + _runThreads.ToString());

                    //thread = new Thread(this.UpdateTagImageList) {IsBackground = true};
                    //thread.Start(_config.TagImageList.GetRange(i, count));

                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdateTagImageList), _config.TagImageList.GetRange(i, count));
                }
            }

            if (_config.PieList.Count > 0)
            {
                IsStopped = false;
                for (int i = 0; i < _config.PieList.Count; i += threadObjCount)
                {
                    count = _config.PieList.Count > threadObjCount + i
                                      ? threadObjCount
                                      : _config.PieList.Count - i;
                    this.IncreaseRunThreads();
                   
                    //thread = new Thread(this.UpdatePieList) {IsBackground = true};
                    //thread.Start(_config.PieList.GetRange(i, count));

                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdatePieList), _config.PieList.GetRange(i, count));
                }
            }

            if (_config.PoolList.Count > 0)
            {
                IsStopped = false;
                for (int i = 0; i < _config.PoolList.Count; i += threadObjCount)
                {
                    count = _config.PoolList.Count > threadObjCount + i
                                      ? threadObjCount
                                      : _config.PoolList.Count - i;
                    this.IncreaseRunThreads();

                    //thread = new Thread(this.UpdatePooList) {IsBackground = true};
                    //thread.Start(_config.PoolList.GetRange(i, count));

                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdatePooList), _config.PoolList.GetRange(i, count));
                }
            }

            if (_config.LitePoolList.Count > 0)
            {
                IsStopped = false;
                for (int i = 0; i < _config.LitePoolList.Count; i += threadObjCount)
                {
                    count = _config.LitePoolList.Count > threadObjCount + i
                                      ? threadObjCount
                                      : _config.LitePoolList.Count - i;
                    this.IncreaseRunThreads();

                    //thread = new Thread(this.UpdateLitePoolList) {IsBackground = true};
                    //thread.Start(_config.LitePoolList.GetRange(i, count));

                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdateLitePoolList), _config.LitePoolList.GetRange(i, count));
                }
            }

            if(_config.GaugeList.Count > 0)
            {
                IsStopped = false;
                for (int i = 0; i < _config.GaugeList.Count; i += threadObjCount)
                {
                    count = _config.GaugeList.Count > threadObjCount + i
                                ? threadObjCount
                                : _config.GaugeList.Count - i;
                    this.IncreaseRunThreads();

                    //thread = new Thread(this.UpdateGaugeList) { IsBackground = true };
                    //thread.Start(_config.GaugeList.GetRange(i, count));

                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdateGaugeList), _config.GaugeList.GetRange(i, count));
                }
            }

            if (_config.TagList.Count > 0)
            {
                Logger.Debug("TagList'Count > 0");
                IsStopped = false;
                for (int i = 0; i < _config.TagList.Count; i += threadObjCount)
                {
                    count = _config.TagList.Count > threadObjCount + i
                                      ? threadObjCount
                                      : _config.TagList.Count - i;
                    this.IncreaseRunThreads();

                    //thread = new Thread(this.UpdateTagList) {IsBackground = true};
                    //thread.Start(_config.TagList.GetRange(i, count));

                    //将方法排入队列以便执行，并指定包含该方法所用数据的对象。 此方法在有线程池线程变得可用时执行。
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdateTagList), _config.TagList.GetRange(i, count));
                    
                }
            }

        }
        
        #region Methods
        
        #region Update Device
        /// <summary>
        /// 更新设备状态。
        /// </summary>
        /// <param name="devInfo"></param>
        private static void UpdateDeviceState(DeviceInfo devInfo)
        {
            try
            {
                var runStatusInfo = DataProvider.RunStatusProvider.Get_Current_By_DevCode(devRegex.Replace(devInfo.DevCode, ""));
                if (runStatusInfo != null)
                {
                    devInfo.State = (DeviceState)runStatusInfo.Status;
                }
            }
            catch
            {
                devInfo.State = DeviceState.Stopped;
            }
        }

        /// <summary>
        /// 本类中，单个线程运行该方法时使用。
        /// </summary>
        /// <param name="oDeviceList"></param>
        private void UpdateDeviceList(Object oDeviceList)
        {
            if (oDeviceList is List<DeviceInfo>)
                this.UpdateDevices(oDeviceList as List<DeviceInfo>);
        }
        
        private void UpdateDevices(List<DeviceInfo> deviceList)
        {
            foreach (var devInfo in deviceList)
            {
                if (this.IsStopped)
                {
                    break;
                }
                if (!String.IsNullOrEmpty(devInfo.DevCode))
                {
                    var oldState = devInfo.State;
                    UpdateDeviceState(devInfo);
                    //System.Diagnostics.Debug.WriteLine("UpdateDevices:TagId" + devInfo.TagId + ":" + devInfo.State);
                    if (oldState != devInfo.State)
                    {
                        _form.Invalidate(devInfo.Bounds);
                        foreach (HoverInfo hoverInfo in devInfo.ChildNodes)
                        {
                            _form.Invalidate(hoverInfo.Bounds);
                        }
                    }
                }
            }
            this.DecreaseRunThreads();
        }
        #endregion

        #region Update Tag
        /// <summary>
        /// 本类中，单个线程运行该方法时使用。
        /// </summary>
        /// <param name="oTagList"></param>
        private void UpdateTagList(object oTagList)
        {
            Logger.Debug("UpdateTagList");
            if (oTagList is List<TagInfo>)
                this.UpdateTags(oTagList as List<TagInfo>);
        }
        
        private void UpdateTags(List<TagInfo> list)
        {
            Logger.Debug("UpdateTags");
            foreach (var tagInfo in list)
            {
                if (this.IsStopped)
                {
                    Logger.Debug("this.IsStopped");
                    break;
                }
                if (!String.IsNullOrEmpty(tagInfo.TagId))
                {

                    //var oldValue = tagInfo.Value;
                    //try
                    //{
                    //    tagInfo.Value = DataProvider.GetCurrentValue(tagInfo.TagId, tagInfo.DataType);
                    //}
                    //catch 
                    //{
                    //    tagInfo.Value = 0.0d;
                    //}

                    ////System.Diagnostics.Debug.WriteLine("UpdateTags:TagId" + tagInfo.TagId + ":" + tagInfo.Value);
                    //////测试
                    ////if (oldValue != 0d && tagInfo.Value == 0)
                    ////{
                    ////    Logger.Info(String.Format("TagId：{0},旧值：{1},新值：{2}", tagInfo.TagId, oldValue, tagInfo.Value));
                    ////}

                    //if (!oldValue.Equals(tagInfo.Value))
                    //{
                    //    //因为没有指定字的区域大小时，不同的值，字符的长度可能不同，刷新区域宽度增加150，以便字符显示完全。
                    //    _form.Invalidate(new Rectangle(tagInfo.Bounds.Location,
                    //                                   new Size(tagInfo.Bounds.Width + 150, tagInfo.Bounds.Height + tagInfo.BottomWidth)));
                    //}
                    var oldText = tagInfo.Text;
                    String tagExp = tagInfo.TagId;
                    DateTime realServerTime = CurrentServerTime.AddMilliseconds(_stopwatch.ElapsedMilliseconds);
                    Logger.Debug(string.Format("{0}---{1}",tagInfo.ValueTime,realServerTime));
                    List<String> dataTypeTest = Common.GetDataTypeTest(tagInfo.ValueTime, realServerTime);
                    Logger.Debug("I'm here.");

                    if (!dataTypeTest.Contains(tagInfo.DataType))
                        continue;
                    Logger.Debug("hello");
                    //是否是要获取时间。
                    bool isCalcDateTime = false;
                    if (Common.calcRegex.IsMatch(tagExp))
                    {
                        MatchCollection matchs = Common.calcRegex.Matches(tagExp);
                        
                        for (int i = 0; i < matchs.Count; i++)
                        {
                            Match match = matchs[i];
                            var rtnCalcFunc = Common.CalcFunc(tagInfo.DataType, match.Value, CurrentServerTime);
                            if (rtnCalcFunc.ValueType == "V")
                            {
                                var calcValue = rtnCalcFunc.PointValue;
                                tagExp = tagExp.Replace(match.Value, calcValue < 0 ? String.Format("(cast({0}, double))", calcValue) : String.Format("cast({0}, double)", calcValue));
                            }
                            else if (rtnCalcFunc.ValueType == "T")
                            {
                                tagInfo.Text = rtnCalcFunc.PointTime;
                                isCalcDateTime = true;
                                break;
                            }
                        }
                    }
                    Logger.Debug(isCalcDateTime);
                    if (!isCalcDateTime)
                    {
                        try
                        {
                            tagInfo.Value = DataProvider.GetCurrentValue(tagExp, tagInfo.DataType);
                        }
                        catch
                        {
                            tagInfo.Value = 0.0d;
                        }
                    }

                    if (oldText != tagInfo.Text)
                    {
                        //此次取值与上次取值不等时，认为取到了新的值才去更新上次取值时间。
                        //这是因为，比如小时的数据，不一定就在整点的时候立马就有数据。
                        //当然这样的话如果两个小时取得的数据是相同的，就不会提高取值的效率，但总体来讲还是有一定程度的提高的。
                        tagInfo.ValueTime = realServerTime;

                        Logger.Debug("更新取值时间！");
                        //因为没有指定字的区域大小时，不同的值，字符的长度可能不同，刷新区域宽度增加150，以便字符显示完全。
                        _form.Invalidate(new Rectangle(tagInfo.Bounds.Location,
                                                       new Size(tagInfo.Bounds.Width + 150, tagInfo.Bounds.Height + tagInfo.BottomWidth)));
                    }
                }
            }
            this.DecreaseRunThreads();
        }
        
        #endregion

        #region Update Line
        /// <summary>
        /// 本类中，单个线程运行该方法时使用。
        /// </summary>
        /// <param name="oLineList"></param>
        private void UpdateLineList(Object oLineList)
        {

            if (oLineList is List<LineInfo>)
                this.UpdateLines(oLineList as List<LineInfo>);
        }

        private void UpdateLines(List<LineInfo> list)
        {
            foreach (LineInfo lineInfo in list)
            {
                if (this.IsStopped)
                {
                    break;
                }
                if (!String.IsNullOrEmpty(lineInfo.TagId))
                {
                    var oldValue = lineInfo.Value;
                    try
                    {
                        lineInfo.Value = DataProvider.GetCurrentValue(lineInfo.TagId, lineInfo.DataType);
                    }
                    catch
                    {
                        lineInfo.Value = 0.0d;
                    }
                    //System.Diagnostics.Debug.WriteLine("UpdateLines:TagId" + lineInfo.TagId + ":" + lineInfo.Value);

                    if (!oldValue.Equals(lineInfo.Value))
                    {
                        _form.Invalidate(lineInfo.Bounds);
                    }
                }
            }
            this.DecreaseRunThreads();
        }
        #endregion

        #region Update TagImage
        private void UpdateTagImageList(Object oTagImageList)
        {
            if (oTagImageList is List<TagImageInfo>)
                this.UpdateTagImages(oTagImageList as List<TagImageInfo>);
        }

        private void UpdateTagImages(List<TagImageInfo> list)
        {
            foreach (TagImageInfo tagImageInfo in list)
            {
                if (this.IsStopped)
                {
                    break;
                }
                if (!String.IsNullOrEmpty(tagImageInfo.TagId))
                {
                    var oldValue = tagImageInfo.Value;
                    try
                    {
                        tagImageInfo.Value = DataProvider.GetCurrentValue(tagImageInfo.TagId, tagImageInfo.DataType);
                    }
                    catch
                    {
                        tagImageInfo.Value = 0.0d;
                    }
                    //System.Diagnostics.Debug.WriteLine("UpdateLines:TagId" + lineInfo.TagId + ":" + lineInfo.Value);

                    if (!oldValue.Equals(tagImageInfo.Value))
                    {
                        _form.Invalidate(tagImageInfo.Bounds);
                    }
                }
            }
            this.DecreaseRunThreads();
        }
        #endregion

        #region Update Pie
        private void UpdatePieList(Object oPieList)
        {
            if (oPieList is List<PieInfo>)
                this.UpdatePies(oPieList as List<PieInfo>);
        }

        private void UpdatePies(List<PieInfo> list)
        {
            foreach (PieInfo pieInfo in list)
            {
                if(this.IsStopped)
                {
                    break;
                }
                Boolean isChanged = false;
                foreach (PieInfo.ItemInfo itemInfo in pieInfo.ItemList)
                {
                    if (!String.IsNullOrEmpty(itemInfo.TagId))
                    {
                        var oldValue = itemInfo.Value;
                        try
                        {
                            itemInfo.Value = DataProvider.GetCurrentValue(itemInfo.TagId, itemInfo.DataType);
                        }
                        catch
                        {
                            itemInfo.Value = 0.0d;
                        }
                        if (!isChanged && !oldValue.Equals(itemInfo.Value))
                        {
                            isChanged = true;
                        }
                    }
                }
                if (isChanged)
                {
                    pieInfo.Refresh();
                }
            }
            this.DecreaseRunThreads();
        }
        #endregion

        #region Update Pool
        private void UpdatePooList(Object oPoolList)
        {
            if (oPoolList is List<PoolInfo>)
                this.UpdatePools(oPoolList as List<PoolInfo>);
        }

        public void UpdatePools(List<PoolInfo> list)
        {
            foreach (PoolInfo poolInfo in list)
            {
                if (this.IsStopped)
                {
                    break;
                }
                if (!String.IsNullOrEmpty(poolInfo.TagId))
                {
                    var oldValue = poolInfo.Value;
                    try
                    {
                        poolInfo.Value = DataProvider.GetCurrentValue(poolInfo.TagId, poolInfo.DataType);
                    }
                    catch
                    {
                        poolInfo.Value = 0.0d;
                    }
                    if (!oldValue.Equals(poolInfo.Value))
                    {
                        _form.Invalidate(poolInfo.Bounds);
                    }
                }
            }
            this.DecreaseRunThreads();
        }
        #endregion

        #region Update LitePool
        private void UpdateLitePoolList(Object oLitePoolList)
        {
            if (oLitePoolList is List<LitePoolInfo>)
                this.UpdatePools(oLitePoolList as List<LitePoolInfo>);
        }

        public void UpdatePools(List<LitePoolInfo> list)
        {
            foreach (LitePoolInfo poolInfo in list)
            {
                if (this.IsStopped)
                {
                    break;
                }
                if (!String.IsNullOrEmpty(poolInfo.TagId))
                {
                    var oldValue = poolInfo.Value;
                    try
                    {
                        poolInfo.Value = DataProvider.GetCurrentValue(poolInfo.TagId, poolInfo.DataType);
                    }
                    catch
                    {
                        poolInfo.Value = 0.0d;
                    }
                    
                    if (!oldValue.Equals(poolInfo.Value))
                    {
                        _form.Invalidate(poolInfo.Bounds);
                    }
                }
            }
            this.DecreaseRunThreads();
        }
        #endregion

        #region Update Gauge
        private void UpdateGaugeList(Object oGaugeList)
        {
            if (oGaugeList is List<GaugeInfo>)
                this.UpdateGauges(oGaugeList as List<GaugeInfo>);
        }
        
        public void UpdateGauges(List<GaugeInfo> list)
        {
            foreach (GaugeInfo gaugeInfo in list)
            {
                if (this.IsStopped)
                {
                    break;
                }
                if (!String.IsNullOrEmpty(gaugeInfo.TagId))
                {
                    var oldValue = gaugeInfo.Value;
                    try
                    {
                        gaugeInfo.Value = DataProvider.GetCurrentValue(gaugeInfo.TagId, gaugeInfo.DataType);
                    }
                    catch
                    {
                        gaugeInfo.Value = 0.0d;
                    }

                    if (!oldValue.Equals(gaugeInfo.Value))
                    {
                        gaugeInfo.Refresh();
                    }
                }
            }

            this.DecreaseRunThreads();
        }
        #endregion

        #endregion
    }
        
}
