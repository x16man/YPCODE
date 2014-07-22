using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Gadget
{
    public class PoolInfo : BaseInfo
    {
        #region Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private PoolStyleInfo _poolStyle = new PoolStyleInfo();
        private ValueStyleInfo _valueStyle;
        private ScaleStyleInfo _scaleStyle;
        private ScaleStyleInfo _labelStyle;
        private List<LabelItem> _labelList = new List<LabelItem>();
        private List<ScaleItem> _scaleList = new List<ScaleItem>();

        private String _unitExp;
        private String _maxScaleExp;
        private Double _value;
        private String _pieceScaleExp;
        private Double _pixelPerUnit = Double.NaN;
        private Rectangle _bounds;

        /// <summary>
        /// 是否已经初始化刻度值，即计算过各个刻度的位置和大小等。
        /// </summary>
        private Boolean isInitializedScale = false;
        /// <summary>
        /// 是否已经初始化标签值，即计算过各个标签的位置和大小等。
        /// </summary>
        private Boolean isInitializedLabel = false;
        
        #endregion

        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        public override Rectangle Bounds
        {
            get
            {
                if (_bounds == Rectangle.Empty)
                    _bounds = new Rectangle(X, Y, Width, Height);
                return _bounds;
            }
            set
            {
                _bounds = value;
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
        public String TagId { get; set; }
        public String MaxScaleExp
        {
            private get { return _maxScaleExp; }
            set 
            {
                if (_maxScaleExp == value) return;
                _maxScaleExp = value;
                this.MaxScale = Utils.IsAttribute(_maxScaleExp) ? Convert.ToDouble(Utils.GetAttrValue(MonitorObj, _maxScaleExp)) : Convert.ToDouble(_maxScaleExp);
                if(this.MaxScale == 0)
                {
                    Logger.Error("MaxScale 不能等于 0, 请改正！已改为默认值 1.0 来代替。");
                    this.MaxScale = 1.0;
                }
            }
        }
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
        /// 单位刻度表达式。
        /// </summary>
        public String PieceScaleExp
        {
            private get { return _pieceScaleExp; }
            set
            {
                if (_pieceScaleExp == value) return;
                _pieceScaleExp = value;
                this.PieceScale = Convert.ToSingle(Utils.IsAttribute(_pieceScaleExp) ? Utils.GetAttrValue(MonitorObj, _pieceScaleExp) : _pieceScaleExp);
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
                if(_value == value) return;
                _value = value;
                _valueStyle.OnValueChanged();
            }
        }

        public Double MaxScale
        {
            get; set;
        }
        public String Unit
        {
            get; set;
        }
        /// <summary>
        /// 单位刻度。
        /// </summary>
        public Single PieceScale { get; set; }
        
        // <summary>
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
        /// 刻度值的样式。
        /// </summary>
        public ScaleStyleInfo ScaleStyle
        {
            get
            {
                if (_scaleStyle == null)
                    _scaleStyle = new ScaleStyleInfo(this);
                return _scaleStyle;
            }
            set { _scaleStyle = value; }
        }
        /// <summary>
        /// 最大最小刻度值等的样式。
        /// </summary>
        public ScaleStyleInfo LabelStyle
        {
            get
            {
                if(_labelStyle == null)
                    _labelStyle = new ScaleStyleInfo(this);
                return _labelStyle;
            }
            set { _labelStyle = value;}
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

        public String MonitorObj { get; set; }
        
        private Double PixelPerUnit
        {
            get 
            {
                if (Double.IsNaN(_pixelPerUnit))
                    _pixelPerUnit = Height / MaxScale;
                return _pixelPerUnit;
            }
        }

        #region Methods
        /// <summary>
        /// Pool的绘制。
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g)
        {
            //SmoothingMode sm = g.SmoothingMode;
            //g.SmoothingMode = SmoothingMode.Default;
            Int32 halfBorder = PoolStyle.BorderWidth / 2;
            Pen pen;
            // Pool 填充背景色。
            if (!PoolStyle.BackColor.Equals(Color.Transparent))
            {
                using (SolidBrush brush = new SolidBrush(PoolStyle.BackColor))
                {
                    g.FillRectangle(brush, Bounds);
                }
            }
            if (Value == Double.MinValue) Value = 0;
            Single valuePixelV = Convert.ToSingle(PixelPerUnit * Value);
            String valueText = String.Concat(Utils.GetDecimalDigits(Value, ValueStyle.DecimalDigits), Unit);
            
            // Pool 水量 填充色。
            if(Value > 0)
            {
                RectangleF rect = new RectangleF(X, Y + Height - valuePixelV, Width, valuePixelV);
                if (String.IsNullOrEmpty(PoolStyle.FillImageSrc))
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(rect, PoolStyle.FillColor1, PoolStyle.FillColor2, 90F))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
                else
                {
                    g.DrawImage(ConfigImages.GetByKey(PoolStyle.FillImageSrc), rect);
                }
            }

            //Pool 边框。
            if (PoolStyle.BorderWidth > 0)
            {
                Color hatchBrushForeColor = Color.DeepSkyBlue;
                Color hatchBrushBackColor = Color.FromArgb(70, 70, 70);
                //HatchBrush hatchBrush = new HatchBrush(HatchStyle.BackwardDiagonal, hatchBrushForeColor, hatchBrushBackColor);
                HatchBrush hatchBrush = new HatchBrush(HatchStyle.HorizontalBrick, hatchBrushForeColor, hatchBrushBackColor);
                pen = new Pen(hatchBrush) {Width = PoolStyle.BorderWidth};
                g.DrawRectangle(pen, Bounds);
            }
            //计算位置向左或向右调整的大小。
            Int32 offset = PoolStyle.BorderWidth;
           
            #region 刻度值绘制。
            FontStyle fsScale = FontStyle.Regular;
            if (ScaleStyle.IsItalic)
            {
                fsScale |= FontStyle.Italic;
            }
            if (ScaleStyle.IsBold)
            {
                fsScale |= FontStyle.Bold;
            }
            if (ScaleStyle.IsUnderLine)
            {
                fsScale |= FontStyle.Underline;
            }
            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoWrap
            };
            Font font = new Font(FontFamily, ScaleStyle.FontSize, fsScale);
            //如果是刻度值没有初始化。
            if (!isInitializedScale)
            {
                isInitializedScale = true;
                ScaleItem scaleItem = new ScaleItem(this) { LabelValue = 0D, StringFormat = String.Concat("{0} ", Unit) };
                this.ScaleList.Add(scaleItem);
                scaleItem = new ScaleItem(this) { LabelValue = MaxScale, StringFormat = String.Concat("{0} ", Unit) };
                this.ScaleList.Add(scaleItem);

                for (Double i = 0D; i < MaxScale; i += PieceScale)
                {
                    scaleItem = new ScaleItem(this) { LabelValue = Math.Round(i, 2), StringFormat = String.Concat("{0} ", Unit) };
                    this.ScaleList.Add(scaleItem);
                }
                foreach (var item in ScaleList)
                {
                    item.PixelV = Convert.ToInt32(PixelPerUnit * item.LabelValue);
                    item.LabelSize = g.MeasureString(item.LabelText, font, new PointF(X, Y), sf);
                }

                //刻度的位置，与Max等Label相反。
                switch (LabelStyle.Align)
                {
                    case TextAlign.Right:
                        foreach (var item in ScaleList)
                        {
                            item.LineLeft = new Point(X + halfBorder, Y + Height - item.PixelV);
                            item.LineRight = new Point(X + offset + halfBorder, Y + Height - item.PixelV);
                            item.LabelLocation = new PointF(X - (int)item.LabelSize.Width - offset, item.LineLeft.Y - (int)(item.LabelSize.Height / 2));
                        }
                        break;
                    default:
                        foreach (var item in ScaleList)
                        {
                            item.LineLeft = new Point(X + Width - offset - halfBorder, Y + Height - item.PixelV);
                            item.LineRight = new Point(X + Width - halfBorder, Y + Height - item.PixelV);
                            item.LabelLocation = new PointF(X + Width + offset, item.LineLeft.Y - (int)(item.LabelSize.Height / 2));
                        }
                        break;
                }
            }
            
            pen = new Pen(ScaleStyle.LineColor) { Width = ScaleStyle.LineWidth };
            foreach (var item in ScaleList)
            {
                if (item.LabelValue == 0D || item.LabelValue == MaxScale) continue;
                //画线。
                g.DrawLine(pen, item.LineLeft, item.LineRight);
            }
            if (!ScaleStyle.BackColor.Equals(Color.Transparent))
            {
                //画字的背景。
                foreach (var item in ScaleList)
                {
                    g.FillRectangle(new SolidBrush(ScaleStyle.BackColor), new RectangleF(item.LabelLocation, item.LabelSize));
                }
            }
            SolidBrush textBrush = new SolidBrush(ScaleStyle.ForeColor);
            foreach (var item in ScaleList)
            {
                //画字。
                g.DrawString(item.LabelText, font, textBrush, item.LabelLocation);
            }
            #endregion

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
            sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoWrap
            };
            font = new Font(FontFamily, LabelStyle.FontSize, fontStyle);
            if (!isInitializedLabel)
            {
                isInitializedLabel = true;

                foreach (var item in LabelList)
                {
                    item.PixelV = Convert.ToInt32(PixelPerUnit * item.LabelValue);
                    item.LabelSize = g.MeasureString(item.LabelText, font, new PointF(X, Y), sf);
                    item.LabelNameSize = g.MeasureString(item.LabelName, font, new PointF(X, Y), sf);
                    item.MaxSize = item.LabelSize.Width >= item.LabelNameSize.Width ? item.LabelSize : item.LabelNameSize;
                }

                //刻度的位置。
                switch (LabelStyle.Align)
                {
                    case TextAlign.Center:
                        foreach (var item in LabelList)
                        {
                            item.LineLeft = new Point(X + halfBorder, Y + Height - item.PixelV);
                            item.LineRight = new Point(X + Width - halfBorder, Y + Height - item.PixelV);
                            item.LabelLocation = new PointF(item.LineLeft.X + (Width - item.LabelSize.Width) / 2, item.LineLeft.Y - item.LabelSize.Height);
                            item.LabelNameLoc = new PointF(item.LineLeft.X + (Width - item.LabelNameSize.Width) / 2, item.LineLeft.Y);
                        }
                        break;
                    case TextAlign.Right:
                        foreach (var item in LabelList)
                        {
                            item.LineLeft = new Point(X + halfBorder, Y + Height - item.PixelV);
                            item.LineRight = new Point(X + Width + (int)item.MaxSize.Width + offset, Y + Height - item.PixelV);
                            item.LabelLocation = new PointF(item.LineRight.X - item.MaxSize.Width - (item.MaxSize.Width - item.LabelSize.Width) / 2, item.LineLeft.Y - item.LabelSize.Height);
                            item.LabelNameLoc = new PointF(item.LineRight.X - item.MaxSize.Width + (item.MaxSize.Width - item.LabelNameSize.Width) / 2, item.LineLeft.Y);
                        }
                        break;
                    default: // 默认同 Left.
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
            //箭头定义。
            pen = new Pen(LabelStyle.LineColor) { Width = LabelStyle.LineWidth };
            AdjustableArrowCap lineCap = new AdjustableArrowCap(pen.Width * LabelStyle.ArrowFactor, pen.Width * LabelStyle.ArrowFactor, true);
            switch (LabelStyle.Align)
            {
                case TextAlign.Center:
                    pen.CustomStartCap = lineCap;
                    pen.CustomEndCap = lineCap;
                    break;
                case TextAlign.Right:
                    pen.CustomStartCap = lineCap;
                    break;
                default: // 默认同 Left.
                    pen.CustomEndCap = lineCap;
                    break;
            }
            foreach (var item in LabelList)
            {
                //画线。
                g.DrawLine(pen, item.LineLeft, item.LineRight);
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
            //画字。
            foreach (var item in LabelList)
            {
                g.DrawString(item.LabelName, font, textBrush, item.LabelNameLoc);
                g.DrawString(item.LabelText, font, textBrush, item.LabelLocation);
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

                pen = new Pen(ValueStyle.LineColor, ValueStyle.LineWidth);
                lineCap.Width = lineCap.Height = pen.Width * ValueStyle.ArrowFactor;
                PointF lineLeft, lineRight;
                SizeF sizeValue = g.MeasureString(valueText, font, new PointF(X, Y), sf);
                PointF valueLoc;
                switch (LabelStyle.Align)
                {
                    case TextAlign.Right:
                        pen.CustomEndCap = lineCap;
                        lineLeft = new PointF(X + Width / 3, Y + Height - valuePixelV);
                        lineRight = new PointF(X + halfBorder, Y + Height - valuePixelV);
                        valueLoc = new PointF(X + Width - sizeValue.Width - halfBorder, Y + Height - valuePixelV);
                        break;
                    default:
                        pen.CustomEndCap = lineCap;
                        lineLeft = new PointF(X + Width / 3 * 2, Y + Height - valuePixelV);
                        lineRight = new PointF(X + Width - halfBorder, Y + Height - valuePixelV);
                        valueLoc = new PointF(X + offset, Y + Height - valuePixelV);
                        break;
                }
                
                g.DrawLine(pen, lineLeft, lineRight);
                
                if (!ValueStyle.BackColor.Equals(Color.Transparent))
                {
                    //画字的背景。
                    g.FillRectangle(new SolidBrush(ValueStyle.BackColor), new RectangleF(valueLoc, sizeValue));
                }

                //调整字的位置以显示在矩形区域内。
                if (valueLoc.Y + sizeValue.Height > Y + Height)
                {
                    valueLoc.Y = Y + Height - sizeValue.Height;
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
            textBrush.Dispose();
            //g.SmoothingMode = sm;
        }
        #endregion

        public class PoolStyleInfo
        {
            public Int32 BorderWidth { get; set; }

            public Color BorderColor { get; set; }
            
            public Color BackColor { get; set; }

            public Color FillColor1 { get; set; }

            public Color FillColor2 { get; set; }

            public String FillImageSrc { get; set; }
        }

        /// <summary>
        /// 值样式类。
        /// </summary>
        public class ValueStyleInfo
        {
            #region Fields
            private PoolInfo _pool;
            private String _decimalDigitsExp;
            private Color _foreColor;
            private Color _backColor;
            private Color _lineColor;
            private Single _arrowFactor = 1.5F;
            #endregion

            public ValueStyleInfo(PoolInfo poolInfo)
            {
                _pool = poolInfo;
            }

            public String ForeColorExp { private get; set; }
            public String BackColorExp { private get; set; }
            public String LineColorExp { private get; set; }
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
            public Int32 LineWidth { get; set; }

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

            /// <summary>
            /// 字体大小emSize.
            /// </summary>
            public Single FontSize { get; set; }
            public Boolean IsBold { get; set; }
            public Boolean IsUnderLine { get; set; }
            public Boolean IsItalic { get; set; }

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

            /// <summary>
            /// 箭头大小与线宽的比例。
            /// </summary>
            public Single ArrowFactor
            {
                get { return _arrowFactor; }
                set { _arrowFactor = value; }
            }
        }

        /// <summary>
        /// 刻度样式类。
        /// </summary>
        public class ScaleStyleInfo : ValueStyleInfo
        {
            public ScaleStyleInfo(PoolInfo poolInfo):base(poolInfo){ }
            public TextAlign Align { get; set; }
        }
        
        /// <summary>
        /// 刻度类。
        /// </summary>
        public class ScaleItem
        {
            protected PoolInfo _pool;
            public ScaleItem(PoolInfo poolInfo)
            {
                _pool = poolInfo;
            }
            public Double LabelValue { get; set; }
            public virtual String StringFormat { get; set; }
            /// <summary>
            /// 获取显示的Text。
            /// </summary>
            public virtual String LabelText
            {
                get
                {
                    if (!String.IsNullOrEmpty(StringFormat))
                    {
                        return String.Format(StringFormat, Utils.GetDecimalDigits(LabelValue, _pool.ScaleStyle.DecimalDigits));
                    }
                    return Utils.GetDecimalDigits(LabelValue, _pool.ScaleStyle.DecimalDigits);
                }
            }
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
        }

        /// <summary>
        /// 标签类。
        /// </summary>
        public class LabelItem : ScaleItem
        {
            private String _labelValueExp;

            public LabelItem(PoolInfo poolInfo) : base(poolInfo){}

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
            public override String LabelText
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
        }
    }
}
