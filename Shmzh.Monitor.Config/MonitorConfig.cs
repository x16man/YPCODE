using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Shmzh.Monitor.Gadget;

namespace Shmzh.Monitor.Config
{
    /// <summary>
    /// 监控窗体配置信息类。
    /// </summary>
    public class MonitorConfig
    {
        #region Fields

        private List<BasePointInfo> _basePointList; 
        private List<ImageInfo> _imageList;
        private List<LineInfo> _lineList;
        private List<TextInfo> _textList;
        private List<TagInfo> _tagList;
        private List<DeviceInfo> _deviceList;
        private List<HoverInfo> _hoverList;
        private List<TagImageInfo> _tagImageList;
        private List<PieInfo> _pieList;
        private List<ITriggerEvent> _leftClickEventList;
        private List<ITriggerEvent> _rightClickEventList;
        private List<ITriggerEvent> _doubleClickEventList;
        private List<PoolInfo> _poolList;
        private List<LitePoolInfo> _litePoolList;
        private List<GaugeInfo> _gaugeList;
        #endregion

        #region CTOR
        /// <summary>
        /// 监控窗体配置信息类的构造函数。
        /// </summary>
        public MonitorConfig()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// 监控窗体的背景对象。
        /// </summary>
        public BackGroundInfo FormBackGround { get; set; }

        public List<BasePointInfo> BasePointList
        {
            get
            {
                if (_basePointList == null)
                    _basePointList = new List<BasePointInfo>();
                return _basePointList;
            }
            set { _basePointList = value; } 
        } 
        /// <summary>
        /// 监控窗体的图片对象集合。
        /// </summary>
        public List<ImageInfo> ImageList 
        {
            get
            {
                if (_imageList == null)
                    _imageList = new List<ImageInfo>();
                return _imageList;
            }
            set { _imageList = value; } 
        }
        /// <summary>
        /// 监控窗体的关联指标的图片对象集合。
        /// </summary>
        public List<TagImageInfo> TagImageList
        {
            get
            {
                if (_tagImageList == null)
                    _tagImageList = new List<TagImageInfo>();
                return _tagImageList;
            }
            set { _tagImageList = value; }
        }
        /// <summary>
        /// 监控窗体的线型对象集合。
        /// </summary>
        public List<LineInfo> LineList
        {
            get 
            {
                if (_lineList == null)
                    _lineList = new List<LineInfo>();
                return _lineList;
            }
            set { _lineList = value; }
        }
        /// <summary>
        /// 监控窗体的文字型对象集合。
        /// </summary>
        public List<TextInfo> TextList
        {
             get 
            {
                if (_textList == null)
                    _textList = new List<TextInfo>();
                return _textList;
            }
            set { _textList = value; }
        }
        /// <summary>
        /// 监控窗体的指标对象集合。
        /// </summary>
        public List<TagInfo> TagList
        {
            get 
            {
                if (_tagList == null)
                    _tagList = new List<TagInfo>();
                return _tagList;
            }
            set { _tagList = value; }
        }
        /// <summary>
        /// 监控窗体的设备对象集合。
        /// </summary>
        public List<DeviceInfo> DeviceList
        {
            get
            {
                if (_deviceList == null)
                    _deviceList = new List<DeviceInfo>();
                return _deviceList;
            }
            set { _deviceList = value; }
        }

        /// <summary>
        /// 有鼠标移过效果的对象集合。
        /// </summary>
        public List<HoverInfo> HoverList
        {
            get 
            {
                if (_hoverList == null)
                    _hoverList = new List<HoverInfo>();
                return _hoverList;
            }
            set { _hoverList = value; }
        }
        /// <summary>
        /// 监控窗体的饼图对象集合。
        /// </summary>
        public List<PieInfo> PieList
        {
            get
            {
                if (_pieList == null)
                    _pieList = new List<PieInfo>();
                return _pieList;
            }
            set { _pieList = value; }
        }

        public List<ITriggerEvent> LeftClickList
        {
            get
            {
                if (this._leftClickEventList == null)
                    _leftClickEventList = new List<ITriggerEvent>();
                return _leftClickEventList;
            }
            set { _leftClickEventList = value; }
        }

        public List<ITriggerEvent> DoubleClickList
        {
            get
            {
                if (this._doubleClickEventList == null)
                    _doubleClickEventList = new List<ITriggerEvent>();
                return _doubleClickEventList;
            }
            set { _doubleClickEventList = value; }
        }

        public List<ITriggerEvent> RightClickList
        {
            get
            {
                if (this._rightClickEventList == null)
                    _rightClickEventList = new List<ITriggerEvent>();
                return _rightClickEventList;
            }
            set { _rightClickEventList = value; }
        }

        public List<PoolInfo> PoolList
        {
            get
            {
                if (this._poolList == null)
                    _poolList = new List<PoolInfo>();
                return _poolList;
            }
            set { _poolList = value; }
        }

        public List<LitePoolInfo> LitePoolList
        {
            get
            {
                if(_litePoolList == null)
                    _litePoolList = new List<LitePoolInfo>();
                return _litePoolList;
            }
            set { _litePoolList = value; }
        }

        public List<GaugeInfo> GaugeList
        {
            get
            {
                if(_gaugeList == null)
                    _gaugeList = new List<GaugeInfo>();
                return _gaugeList;
            }
            set { _gaugeList = value; }
        }

        /// <summary>
        /// 监控窗体的时钟对象。
        /// </summary>
        public ClockInfo Clock { get; set; }
        
        #endregion 
        
        #region Method
        /// <summary>
        /// 根据配置信息呈现到窗体界面。
        /// </summary>
        public void Render(Graphics g)
        {

        }

        #endregion
    }
}
