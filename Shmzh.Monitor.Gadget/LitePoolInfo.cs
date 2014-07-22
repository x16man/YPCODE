using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Gadget
{
    public class LitePoolInfo : BaseInfo
    {
        #region Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private PoolStyleInfo _poolStyle = new PoolStyleInfo();
        private ValueStyleInfo _valueStyle;
        private ScaleStyleInfo _labelStyle;
        private List<LabelItem> _labelList = new List<LabelItem>();
        private List<ScaleItem> _scaleList = new List<ScaleItem>();

        private String _unitExp;
        private Double _value;
        private Double _pixelPerUnit = Double.NaN;
        private String _zeroText;
        private Rectangle _rectBounds;
        /// <summary>
        /// 是否已经初始化标签值，即计算过各个标签的位置和大小等。
        /// </summary>
        private Boolean isInitializedLabel = false;
        #endregion

        #region Property
        /// <summary>
        /// 宽度.
        /// </summary>
        public Int32 Width { get; set; }
        /// <summary>
        /// 高度.
        /// </summary>
        public Int32 Height { get; set; }

        /// <summary>
        /// 矩形框的边界。
        /// </summary>
        private Rectangle RectBounds
        {
            get
            {
                if (_rectBounds == Rectangle.Empty)
                {
                    _rectBounds = new Rectangle(X, Y, Width, Height);
                    base.HotBounds = _rectBounds;
                }
                return _rectBounds;
            }
        }
        
        /// <summary>
        /// 字体名。
        /// </summary>
        public String FontFamily { get; set; }

        /// <summary>
        /// 数据类型。可选值：Second/Min/Min15/Hour/Day/Month/Year.
        /// </summary>
        public String DataType { get; set; }
        /// <summary>
        /// 指标Id.
        /// </summary>
        public String TagId { get; set; }
        /// <summary>
        /// 单位表达式.
        /// </summary>
        public String UnitExp
        {
            private get { return _unitExp; }
            set
            {
                if (_unitExp == value) return;
                _unitExp = value;
                this.Unit = Utils.IsAttribute(_unitExp) ? Utils.GetAttrValue(MonitorObj, _unitExp) : _unitExp;
            }
        }
        
        /// <summary>
        /// 指标对应值。
        /// </summary>
        public Double Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
                _value = value;
                _valueStyle.OnValueChanged();
            }
        }
        /// <summary>
        /// 最大刻度.
        /// </summary>
        public Double MaxScale
        {
            get;
            set;
        }
        /// <summary>
        /// 单位.
        /// </summary>
        public String Unit
        {
            get;
            set;
        }
        /// <summary>
        /// 池的样式。
        /// </summary>
        public PoolStyleInfo PoolStyle { get { return _poolStyle; } set { _poolStyle = value; } }
        /// <summary>
        /// 当前值的样式。
        /// </summary>
        public ValueStyleInfo ValueStyle
        {
            get
            {
                if (_valueStyle == null)
                    _valueStyle = new ValueStyleInfo(this);
                return _valueStyle;
            }
            set { _valueStyle = value; }
        }
       
        /// <summary>
        /// 最大最小刻度值等的样式。
        /// </summary>
        public ScaleStyleInfo LabelStyle
        {
            get
            {
                if (_labelStyle == null)
                    _labelStyle = new ScaleStyleInfo(this);
                return _labelStyle;
            }
            set { _labelStyle = value; }
        }
        /// <summary>
        /// 标签列表。
        /// </summary>
        public List<LabelItem> LabelList
        {
            get
            {
                if (_labelList == null)
                    _labelList = new List<LabelItem>();
                return _labelList;
            }
            set { _labelList = value; }
        }
        /// <summary>
        /// 刻度列表。
        /// </summary>
        public List<ScaleItem> ScaleList { get { return _scaleList; } set { _scaleList = value; } }
        /// <summary>
        /// 监控对象.
        /// </summary>
        public String MonitorObj { get; set; }
        /// <summary>
        /// 每单位像素.
        /// </summary>
        private Double PixelPerUnit
        {
            get
            {
                if (Double.IsNaN(_pixelPerUnit))
                {
                    Double maxScale = 1.0d;
                    //从大到小排序。
                    if (LabelList.Count > 0)
                    {
                        LabelList.Sort((a, b) => b.LabelValue.CompareTo(a.LabelValue));
                        if (LabelList[0].LabelValue != 0d) maxScale = LabelList[0].LabelValue;
                    }
                    _pixelPerUnit = Height / maxScale;
                }
                return _pixelPerUnit;
            }
        }
        /// <summary>
        /// 0值的位置。
        /// </summary>
        private PointF ZeroTextLoc { get; set; }
        /// <summary>
        /// 0值.
        /// </summary>
        private String ZeroText
        {
            get
            {
                if(_zeroText == null)
                {
                    _zeroText = String.Format("{0} {1}", Utils.GetDecimalDigits(0D, this.LabelStyle.DecimalDigits), Unit);
                }
                return _zeroText;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// LitePool的绘制。
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g)
        {
            Int32 halfBorder = PoolStyle.BorderWidth / 2;

            if (Value == Double.MinValue) Value = 0.0;
            Int32 valuePixelV = Convert.ToInt32(PixelPerUnit * Value);
            String valueText = String.Concat(Utils.GetDecimalDigits(Value, ValueStyle.DecimalDigits), Unit);
            
            //计算位置向左或向右调整的大小。
            Int32 offset = PoolStyle.BorderWidth;
            
            #region 最大最小等标签绘制。
            FontStyle fontStyle = FontStyle.Regular;
            if (LabelStyle.IsItalic)
            {
                fontStyle |= FontStyle.Italic;
            }
            if (LabelStyle.IsBold)
            {
                fontStyle |= FontStyle.Bold;
            }
            if (LabelStyle.IsUnderLine)
            {
                fontStyle |= FontStyle.Underline;
            }
            StringFormat sf = new StringFormat
                                  {
                                      LineAlignment = StringAlignment.Center,
                                      Alignment = StringAlignment.Center,
                                      FormatFlags = StringFormatFlags.NoWrap
                                  };
            Font font = new Font(FontFamily, LabelStyle.FontSize, fontStyle);

            if (!isInitializedLabel)
            {
                isInitializedLabel = true;
                SizeF zeroSizeF = g.MeasureString(ZeroText, font, new PointF(0, 0), sf);
                foreach (var item in LabelList)
                {
                    item.PixelV = Convert.ToInt32(PixelPerUnit * item.LabelValue);
                    item.LabelSize = g.MeasureString(item.LabelText, font, new PointF(X, Y), sf);
                    item.LabelNameSize = g.MeasureString(item.LabelName, font, new PointF(X, Y), sf);
                    item.MaxSize = item.LabelSize.Width >= item.LabelNameSize.Width ? item.LabelSize : item.LabelNameSize;
                    item.FillRect = new RectangleF(X, Y + Height - item.PixelV, Width, item.PixelV);
                }
                
                //刻度的位置。
                switch (LabelStyle.Align)
                {
                    case TextAlign.Center:
                        ZeroTextLoc = new PointF(X + (Width - zeroSizeF.Width)/2, Y + Height + halfBorder);
                        foreach (var item in LabelList)
                        {
                            item.LineLeft = new Point(X + halfBorder, Y + Height - item.PixelV);
                            item.LineRight = new Point(X + Width - halfBorder, Y + Height - item.PixelV);
                            item.LabelLocation = new PointF(item.LineLeft.X + (Width - item.LabelSize.Width) / 2, item.LineLeft.Y - item.LabelSize.Height);
                            item.LabelNameLoc = new PointF(item.LineLeft.X + (Width - item.LabelNameSize.Width) / 2, item.LineLeft.Y);
                        }
                        break;
                    case TextAlign.Right:
                        ZeroTextLoc = new PointF(X + Width + halfBorder, Y + Height - zeroSizeF.Height / 2);
                        foreach (var item in LabelList)
                        {
                            item.LineLeft = new Point(X + halfBorder, Y + Height - item.PixelV);
                            item.LineRight = new Point(X + Width + (int)item.MaxSize.Width + offset, Y + Height - item.PixelV);
                            item.LabelLocation = new PointF(item.LineRight.X - item.MaxSize.Width - (item.MaxSize.Width - item.LabelSize.Width) / 2, item.LineLeft.Y - item.LabelSize.Height);
                            item.LabelNameLoc = new PointF(item.LineRight.X - item.MaxSize.Width + (item.MaxSize.Width - item.LabelNameSize.Width) / 2, item.LineLeft.Y);
                        }
                        break;
                    default: // 默认同 Left.
                        ZeroTextLoc = new PointF(X - zeroSizeF.Width - halfBorder, Y + Height - zeroSizeF.Height / 2);
                        foreach (var item in LabelList)
                        {
                            item.LineLeft = new Point(X - (int)item.MaxSize.Width - offset, Y + Height - item.PixelV);
                            item.LineRight = new Point(X + Width - halfBorder, Y + Height - item.PixelV);
                            item.LabelLocation = new PointF(item.LineLeft.X + (item.MaxSize.Width - item.LabelSize.Width) / 2, item.LineLeft.Y - item.LabelSize.Height);
                            item.LabelNameLoc = new PointF(item.LineLeft.X + (item.MaxSize.Width - item.LabelNameSize.Width) / 2, item.LineLeft.Y);
                        }
                        break;
                }
            }
            Pen pen = new Pen(LabelStyle.LineColor) { Width = LabelStyle.LineWidth };
           
            foreach (var item in LabelList)
            {
                //填色。
                g.FillRectangle(new SolidBrush(item.FillColor), item.FillRect);
            }

            //Pool 边框。
            if (PoolStyle.BorderWidth > 0)
            {
                g.DrawRectangle(new Pen(PoolStyle.BorderColor) { Width = PoolStyle.BorderWidth }, RectBounds);
            }
            SolidBrush textBrush = null;
            if (LabelStyle.Visible)
            {
                if (LabelStyle.LineWidth > 0)
                {
                    foreach (var item in LabelList)
                    {
                        //画线。
                        g.DrawLine(pen, item.LineLeft, item.LineRight);
                    }
                }
                if (!LabelStyle.BackColor.Equals(Color.Transparent))
                {
                    //画字的背景。
                    foreach (var item in LabelList)
                    {
                        g.FillRectangle(new SolidBrush(LabelStyle.BackColor), new RectangleF(item.LabelLocation, item.LabelSize));
                    }
                }
                textBrush = new SolidBrush(LabelStyle.ForeColor);

                // 画 0 值标签。
                g.DrawString(ZeroText, font, textBrush, ZeroTextLoc);

                //画字。
                foreach (var item in LabelList)
                {
                    g.DrawString(item.LabelName, font, textBrush, item.LabelNameLoc);
                    g.DrawString(item.LabelText, font, textBrush, item.LabelLocation);
                }
            }

            #endregion

            #region 值的绘制。
            if (Value > 0)
            {
                fontStyle = FontStyle.Regular;
                if (ValueStyle.IsItalic)
                {
                    fontStyle |= FontStyle.Italic;
                }
                if (ValueStyle.IsBold)
                {
                    fontStyle |= FontStyle.Bold;
                }
                if (ValueStyle.IsUnderLine)
                {
                    fontStyle |= FontStyle.Underline;
                }
                sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.NoWrap
                };
                font = new Font(FontFamily, ValueStyle.FontSize, fontStyle);
                pen = new Pen(ValueStyle.LineColor, ValueStyle.LineWidth);
                //箭头定义。
                AdjustableArrowCap lineCap = new AdjustableArrowCap(pen.Width * ValueStyle.ArrowFactor, pen.Width * ValueStyle.ArrowFactor, true);
                PointF lineLeft, lineRight;
                SizeF sizeValue = g.MeasureString(valueText, font, new PointF(X, Y), sf);
                PointF valueLoc;
                switch (ValueStyle.Align)
                {
                    case "outerleft":
                        pen.CustomEndCap = lineCap;
                        lineLeft = new PointF(X - sizeValue.Width - lineCap.Width - halfBorder, Y + Height - valuePixelV);
                        lineRight = new PointF(X - halfBorder, Y + Height - valuePixelV);
                        valueLoc = new PointF(lineLeft.X, lineLeft.Y - sizeValue.Height);
                        Bounds = Rectangle.Ceiling(new RectangleF(lineLeft.X, Y - sizeValue.Height, lineRight.X - lineLeft.X, Height + sizeValue.Height + ValueStyle.LineWidth));
                        break;
                    case "outerright":
                        pen.CustomEndCap = lineCap;
                        lineLeft = new PointF(X + Width + sizeValue.Width + lineCap.Width + halfBorder, Y + Height - valuePixelV);
                        lineRight = new PointF(X + Width + halfBorder, Y + Height - valuePixelV);
                        valueLoc = new PointF(X + Width + halfBorder + lineCap.Width, lineLeft.Y - sizeValue.Height);
                        Bounds = Rectangle.Ceiling(new RectangleF(lineRight.X, Y - sizeValue.Height, lineLeft.X - lineRight.X, Height + sizeValue.Height + ValueStyle.LineWidth));
                        break;
                    case "innerright":
                        pen.CustomEndCap = lineCap;
                        lineLeft = new PointF(X + Width - sizeValue.Width - lineCap.Width - halfBorder, Y + Height - valuePixelV);
                        lineRight = new PointF(X + Width - halfBorder, Y + Height - valuePixelV);
                        valueLoc = new PointF(lineLeft.X, lineLeft.Y - sizeValue.Height);
                        Bounds = Rectangle.Ceiling(new RectangleF(lineLeft.X, Y - sizeValue.Height, lineRight.X - lineLeft.X, Height + sizeValue.Height + ValueStyle.LineWidth));
                        break;
                    default:
                        pen.CustomEndCap = lineCap;
                        lineLeft = new PointF(X + sizeValue.Width + lineCap.Width + halfBorder, Y + Height - valuePixelV);
                        lineRight = new PointF(X + halfBorder, Y + Height - valuePixelV);
                        valueLoc = new PointF(X + halfBorder + lineCap.Width, lineLeft.Y - sizeValue.Height);
                        Bounds = Rectangle.Ceiling(new RectangleF(lineRight.X, Y - sizeValue.Height, lineLeft.X - lineRight.X, Height + sizeValue.Height + ValueStyle.LineWidth));
                        break;
                }
                g.DrawLine(pen, lineLeft, lineRight);
                
                if (!ValueStyle.BackColor.Equals(Color.Transparent))
                {
                    //画字的背景。
                    g.FillRectangle(new SolidBrush(ValueStyle.BackColor), new RectangleF(valueLoc, sizeValue));
                }

                font = new Font(FontFamily, ValueStyle.FontSize, fontStyle);
                textBrush = new SolidBrush(ValueStyle.ForeColor);
                //画字。
                g.DrawString(valueText, font, textBrush, valueLoc);
            }

            #endregion

            pen.Dispose();
            font.Dispose();
            sf.Dispose();
            if (textBrush != null) textBrush.Dispose();
            //g.SmoothingMode = sm;
        }
        #endregion

        /// <summary>
        /// 池样式实体.
        /// </summary>
        public class PoolStyleInfo
        {
            #region Property
            /// <summary>
            /// 边框宽度.
            /// </summary>
            public Int32 BorderWidth { get; set; }
            /// <summary>
            /// 边框颜色.
            /// </summary>
            public Color BorderColor { get; set; }
            #endregion
        }

        /// <summary>
        /// 值样式类。
        /// </summary>
        public class ValueStyleInfo
        {
            #region Fields
            private LitePoolInfo _pool;
            private String _decimalDigitsExp;
            private Color _foreColor;
            private Color _backColor;
            private Color _lineColor;
            private Single _arrowFactor = 1.5F;
            #endregion

            #region Property
            /// <summary>
            /// 前景色表达式.
            /// </summary>
            public String ForeColorExp { private get; set; }
            /// <summary>
            /// 背景色表达式.
            /// </summary>
            public String BackColorExp { private get; set; }
            /// <summary>
            /// 线颜色表达式.
            /// </summary>
            public String LineColorExp { private get; set; }
            /// <summary>
            /// 前景色.
            /// </summary>
            public Color ForeColor
            {
                get
                {
                    if (!Utils.IsExp(ForeColorExp))
                    {
                        _foreColor = StringUtil.StringToColor(ForeColorExp, Color.Black);
                    }
                    if (_foreColor == Color.Empty) _foreColor = Color.Black;
                    return _foreColor;
                }
            }
            /// <summary>
            /// 背景色.
            /// </summary>
            public Color BackColor
            {
                get
                {
                    if (!Utils.IsExp(BackColorExp))
                    {
                        _backColor = StringUtil.StringToColor(BackColorExp, Color.Transparent);
                    }
                    if (_backColor == Color.Empty) _backColor = Color.Transparent;
                    return _backColor;
                }
            }
            /// <summary>
            /// 线颜色.
            /// </summary>
            public Color LineColor
            {
                get
                {
                    if (!Utils.IsExp(LineColorExp))
                    {
                        _lineColor = StringUtil.StringToColor(LineColorExp, Color.Black);
                    }
                    if (_lineColor == Color.Empty) _lineColor = Color.Black;
                    return _lineColor;
                }
            }
            /// <summary>
            /// 线宽度.
            /// </summary>
            public Int32 LineWidth { get; set; }

            /// <summary>
            /// 箭头大小与线宽的比例。
            /// </summary>
            public Single ArrowFactor
            {
                get { return _arrowFactor; }
                set { _arrowFactor = value; }
            }
            /// <summary>
            /// 字体大小emSize.
            /// </summary>
            public Single FontSize { get; set; }
            /// <summary>
            /// 是否粗体.
            /// </summary>
            public Boolean IsBold { get; set; }
            /// <summary>
            /// 是否带下滑线.
            /// </summary>
            public Boolean IsUnderLine { get; set; }
            /// <summary>
            /// 是否斜体.
            /// </summary>
            public Boolean IsItalic { get; set; }
            /// <summary>
            /// 水平位置.
            /// </summary>
            public String Align { get; set; }
            /// <summary>
            /// 小数点位数表达式.
            /// </summary>
            public String DecimalDigitsExp
            {
                private get { return _decimalDigitsExp; }
                set
                {
                    if (_decimalDigitsExp == value) return;
                    _decimalDigitsExp = value;
                    this.DecimalDigits = Convert.ToInt32(Utils.IsAttribute(_decimalDigitsExp) ? Utils.GetAttrValue(_pool.MonitorObj, _decimalDigitsExp) : _decimalDigitsExp);
                }
            }

            /// <summary>
            /// 小数位数。
            /// </summary>
            public Int32 DecimalDigits { get; set; }
            #endregion

            #region CTOR
            public ValueStyleInfo(LitePoolInfo poolInfo)
            {
                _pool = poolInfo;
            }
            #endregion

            #region method
            /// <summary>
            /// 当 Pool 的 Value 变化时,更新 Value 显示的样式。
            /// </summary>
            public void OnValueChanged()
            {
                if (Utils.IsExp(ForeColorExp))
                {
                    _foreColor = StringUtil.StringToColor(Utils.CalcExpString(ForeColorExp, _pool.Value, _pool.MonitorObj), Color.Black);
                }
                if (Utils.IsExp(BackColorExp))
                {
                    _backColor = StringUtil.StringToColor(Utils.CalcExpString(BackColorExp, _pool.Value, _pool.MonitorObj), Color.Transparent);
                }
                if (Utils.IsExp(LineColorExp))
                {
                    _lineColor = StringUtil.StringToColor(Utils.CalcExpString(LineColorExp, _pool.Value, _pool.MonitorObj), Color.Black);
                }
            }
            #endregion

        }

        /// <summary>
        /// 刻度样式类。
        /// </summary>
        public class ScaleStyleInfo : ValueStyleInfo
        {
            #region CTOR
            public ScaleStyleInfo(LitePoolInfo poolInfo) : base(poolInfo) { }
            #endregion

            #region Property
            /// <summary>
            /// 文字水平位置.
            /// </summary>
            public new TextAlign Align { get; set; }
            /// <summary>
            /// 标签是否可见。
            /// </summary>
            public Boolean Visible { get; set; }
            #endregion
        }

        /// <summary>
        /// 刻度类。
        /// </summary>
        public abstract class ScaleItem
        {
            #region Field
            protected LitePoolInfo _pool;
            #endregion

            #region CTOR
            protected ScaleItem(LitePoolInfo poolInfo)
            {
                _pool = poolInfo;
            }
            #endregion

            #region Property
            /// <summary>
            /// 标签值.
            /// </summary>
            public Double LabelValue { get; set; }
            /// <summary>
            /// 字符格式.
            /// </summary>
            public virtual String StringFormat { get; set; }
            ///// <summary>
            ///// 获取显示的Text。
            ///// </summary>
            //public virtual String LabelText
            //{
            //    get
            //    {
            //        //if (!String.IsNullOrEmpty(StringFormat))
            //        //{
            //        //    return String.Format(StringFormat, Utils.GetDecimalDigits(LabelValue, _pool.ScaleStyle.DecimalDigits));
            //        //}
            //        //return Utils.GetDecimalDigits(LabelValue, _pool.ScaleStyle.DecimalDigits);
            //        return String.Empty;
            //    }
            //}
            /// <summary>
            /// Text的尺寸。
            /// </summary>
            public SizeF LabelSize { get; set; }
            /// <summary>
            /// 标尺线的左端。
            /// </summary>
            public Point LineLeft { get; set; }
            /// <summary>
            /// 标尺线的右端。
            /// </summary>
            public Point LineRight { get; set; }
            /// <summary>
            /// Text的输出位置。
            /// </summary>
            public PointF LabelLocation { get; set; }
            /// <summary>
            /// 像素长度。
            /// </summary>
            public Int32 PixelV { get; set; }
            #endregion
        }

        /// <summary>
        /// 标签类。
        /// </summary>
        public class LabelItem : ScaleItem
        {
            #region Field
            private String _labelValueExp;
            private String _fillColorExp;
            #endregion

            #region CTOR
            public LabelItem(LitePoolInfo poolInfo) : base(poolInfo) { }
            #endregion

            #region Property
            /// <summary>
            /// 填充色.
            /// </summary>
            public Color FillColor { get; set; }
            /// <summary>
            /// 填充色表达式.
            /// </summary>
            public String FillColorExp
            {
                private get { return _fillColorExp; }
                set
                {
                    if(_fillColorExp == value) return;
                    _fillColorExp = value;
                    this.FillColor = Utils.IsAttribute(_fillColorExp) ? StringUtil.StringToColor(Utils.GetAttrValue(_pool.MonitorObj, _fillColorExp), Color.White) : StringUtil.StringToColor(_fillColorExp, Color.White);
                }
            }
            /// <summary>
            /// 标签值表达式.
            /// </summary>
            public String LabelValueExp
            {
                private get { return _labelValueExp; }
                set
                {
                    if (_labelValueExp == value) return;
                    _labelValueExp = value;
                    this.LabelValue = Utils.IsAttribute(LabelValueExp) ? Convert.ToDouble(Utils.GetAttrValue(_pool.MonitorObj, LabelValueExp)) : Convert.ToDouble(LabelValueExp);
                }
            }

            /// <summary>
            /// 获取显示的Text。
            /// </summary>
            public String LabelText
            {
                get
                {
                    if (!String.IsNullOrEmpty(StringFormat))
                    {
                        return String.Format(StringFormat, Utils.GetDecimalDigits(LabelValue, _pool.LabelStyle.DecimalDigits));
                    }
                    return Utils.GetDecimalDigits(LabelValue, _pool.LabelStyle.DecimalDigits);
                }
            }
            /// <summary>
            /// 字符格式.
            /// </summary>
            public override String StringFormat
            {
                get
                {
                    return String.Concat("{0} ", _pool.Unit);
                }
                set
                {
                    base.StringFormat = value;
                }
            }
            /// <summary>
            /// 标签名称.
            /// </summary>
            public String LabelName { get; set; }

            /// <summary>
            /// 标签名称Text的输出位置。
            /// </summary>
            public PointF LabelNameLoc { get; set; }

            /// <summary>
            /// 标签名称Text的尺寸。
            /// </summary>
            public SizeF LabelNameSize { get; set; }

            /// <summary>
            /// 标签名称和值中较大的尺寸。
            /// </summary>
            public SizeF MaxSize { get; set; }
            /// <summary>
            /// 要填充的区域。
            /// </summary>
            public RectangleF FillRect { get; set; }
            #endregion
        }
    }
}
