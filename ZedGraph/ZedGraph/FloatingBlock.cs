///Created by Wang Junhui.
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace ZedGraph
{
    public class FloatingBlock : BoxObj
    {
        #region Fields
        private FloatingData _floatingData = new FloatingData();
        /// <summary>
        /// Private field holding the SizeF into which this <see cref="TextObj"/>
        /// should be rendered. Use the public property <see cref="TextObj.LayoutArea"/>
        /// to access this value.
        /// </summary>
        private RectangleF _rectF;
        private FontSpec _labelFontSpec = new FontSpec("宋体", 12, Color.Black, true, false, false) { StringAlignment = StringAlignment.Near };
        /// <summary>
        /// 标签尺寸。
        /// </summary>
        private SizeF _labelSizeF = new SizeF(0, 0);
        /// <summary>
        /// 值尺寸。
        /// </summary>
        private SizeF _valueSizeF = new SizeF(0, 0);
        /// <summary>
        /// 单位尺寸。
        /// </summary>
        private SizeF _unitSizeF = new SizeF(0, 0);
        private SizeF _valueUnitSizeF = new SizeF(0, 0);
        /// <summary>
        /// 边框与内容之间的间距。
        /// </summary>
        private float _padding = 2.0F;
        /// <summary>
        /// 两项之间的间距。
        /// </summary>
        private float _gapV = 2.0F;
        /// <summary>
        /// 值和单位之间的间距。
        /// </summary>
        private float _gapH = 2.0F;
        /// <summary>
        /// 是否自动调整大小。
        /// </summary>
        private bool _isAutoSize = true;
        /// <summary>
        /// 是否计算过每一项的大小。
        /// </summary>
        private bool _isCalcElementSize = false;
        /// <summary>
        /// 是否第一次绘出。第一次画时，不论是否自动调整大小都要进行计算。
        /// </summary>
        private bool _isFirstDraw = true;

        //private bool _isVisible = false;
        //private int _zIndex = 0;
        #endregion

        #region Constructs

        public FloatingBlock() : this(0, 0, 1, 1) { }

        public FloatingBlock(float x, float y) : this(x, y, 1, 1) { }
            
        public FloatingBlock(double x, double y, double width, double height, Color borderColor, Color fillColor)
            : base(x, y, width, height, borderColor, fillColor)
        {
            this._rectF.Location = new PointF((float)x, (float)y);
            this.Border = new Border(borderColor, Default.PenWidth);
            this.Fill = new Fill(fillColor);
            _labelFontSpec.Border.IsVisible = false;
            _labelFontSpec.Fill.Color = Color.Transparent;
        }

        public FloatingBlock(double x, double y, double width, double height)
            : base(x, y, width, height)
        {
            this._rectF.Location = new PointF((float)x, (float)y);
            this.Border = new Border(Default.BorderColor, Default.PenWidth);
            this.Fill = new Fill(Default.FillColor);
            _labelFontSpec.Border.IsVisible = false;
            _labelFontSpec.Fill.Color = Color.Transparent;            
        }
        #endregion

        #region Properties
        /// <summary>
        /// 浮动窗口的数据集合。
        /// </summary>
        public FloatingData FloatingData
        {
            get { return this._floatingData; }
            set { this._floatingData = value; }
        }

        /// <summary>
        /// Get the bounding rectangle for the <see cref="FloatingBlock"/> in screen coordinates
        /// </summary>
        /// <value>A screen rectangle in pixel units</value>
        public RectangleF RectF
        {
            get { return _rectF; }
            set { _rectF = value; }
        }

        /// <summary>
        /// 浮动窗口的标签样式。
        /// </summary>
        public FontSpec LabelFontSpec
        {
            get { return _labelFontSpec; }
            set { this._labelFontSpec = value; }
        }

        /// <summary>
        /// 标签和值是否显示在同一行。
        /// </summary>
        public Boolean IsLabelInLine{ get; set; }

        ///// <summary>
        ///// 浮动窗口是否显示。
        ///// </summary>
        //public bool IsVisible 
        //{
        //    get { return this._isVisible; }
        //    set { this._isVisible = value; }
        //}

        /// <summary>
        /// 是否正移动。只读属性，若要停止移动，请调用方法 StopDrag 。
        /// </summary>
        public bool IsMoving { get; private set; }
        private float OffsetX { get; set; }
        private float OffsetY { get; set; }
        ///// <summary>
        ///// 多个 FloatingBlock 之间的层次。
        ///// </summary>
        //public int ZIndex { get { return _zIndex; } set { _zIndex = value; } }

        public double X
        {
            //get
            //{
            //    return this._floatingData.Count > 0 ? this._floatingData[0].X : 0.0d;
            //}
            set
            {
                foreach (var item in this._floatingData)
                    if (item.IsInstant)
                        item.X = value;
            }
        }

        /// <summary>
        /// 是否自动调整大小。
        /// </summary>
        public bool IsAutoSize
        {
            get { return _isAutoSize; }
            set { _isAutoSize = value; }
        }
        #endregion

        #region Defaults
        /// <summary>
        /// A simple struct that defines the
        /// default property values for the <see cref="FloatingBlock"/> class.
        /// </summary>
        new public struct Default
        {
            //public static Fill Fill = new Fill(Color.Black);
            //public static Border Border = new Border(Color.DarkRed, 1.0F);

            /// <summary>
            /// The default pen width used for the <see cref="FloatingBlock"/> border
            /// (<see cref="ZedGraph.LineBase.Width"/> property).  Units are points (1/72 inch).
            /// </summary>
            public static float PenWidth = 1.0F;
            /// <summary>
            /// The default color used for the <see cref="FloatingBlock"/> border
            /// (<see cref="ZedGraph.LineBase.Color"/> property).
            /// </summary>
            public static Color BorderColor = Color.Red;
            /// <summary>
            /// The default color used for the <see cref="FloatingBlock"/> fill
            /// (<see cref="ZedGraph.Fill.Color"/> property).
            /// </summary>
            public static Color FillColor = Color.Black;
        }       
        #endregion

        #region Methods
        private void CalcElementSize(Graphics g, float scaleFactor)
        {
            foreach (var item in this.FloatingData)
            {
                SizeF tmpSizeF = this.LabelFontSpec.MeasureString(g, item.Label, scaleFactor);
                if (tmpSizeF.Width > this._labelSizeF.Width)
                    this._labelSizeF.Width = tmpSizeF.Width;
                if (tmpSizeF.Height > this._labelSizeF.Height)
                    this._labelSizeF.Height = tmpSizeF.Height;

                tmpSizeF = item.ValueFontSpec.MeasureString(g, item.ValueString, scaleFactor);
                item.ValueSizeF = tmpSizeF;
                if (tmpSizeF.Width > this._valueSizeF.Width)
                    this._valueSizeF.Width = tmpSizeF.Width;
                if (tmpSizeF.Height > this._valueSizeF.Height)
                    this._valueSizeF.Height = tmpSizeF.Height;

                tmpSizeF = item.UnitFontSpec.MeasureString(g, item.Unit.ToString(), scaleFactor);
                item.UnitSizeF = tmpSizeF;
                if (tmpSizeF.Width > this._unitSizeF.Width)
                    this._unitSizeF.Width = tmpSizeF.Width;
                if (tmpSizeF.Height > this._unitSizeF.Height)
                    this._unitSizeF.Height = tmpSizeF.Height;
            }
            this._valueUnitSizeF.Width = this._valueSizeF.Width + this._unitSizeF.Width + _gapH;
            this._valueUnitSizeF.Height = Math.Max(this._valueSizeF.Height, this._unitSizeF.Height);
        }

        public void CalcRect(Graphics g, float scaleFactor)
        {
            if (!_isCalcElementSize)
            {
                CalcElementSize(g, scaleFactor);
                _isCalcElementSize = true;
            }
            
            if (_isAutoSize)
            {
                if (this.IsLabelInLine)
                {
                    this._labelSizeF.Height = this._valueUnitSizeF.Height = Math.Max(this._labelSizeF.Height, this._valueUnitSizeF.Height);
                    _rectF.Width = this._labelSizeF.Width + this._valueUnitSizeF.Width + _gapH + _padding * 2;
                    _rectF.Height = (this._labelSizeF.Height + _gapV) * this.FloatingData.Count + _padding * 2 - _gapV;
                }
                else
                {
                    _rectF.Width = Math.Max(this._labelSizeF.Width, this._valueUnitSizeF.Width) + _padding * 2;
                    _rectF.Height = (this._labelSizeF.Height + this._valueUnitSizeF.Height + _gapV * 2) * this.FloatingData.Count + _padding * 2 - _gapV;
                }
            }
            else
            {
                if (this.IsLabelInLine)
                {
                    this._labelSizeF.Height = this._valueUnitSizeF.Height = Math.Max(this._labelSizeF.Height, this._valueUnitSizeF.Height);
                    float totalH = (this._labelSizeF.Height) * this.FloatingData.Count + _padding * 2;
                    _gapV = (_rectF.Height - totalH) / (this.FloatingData.Count - 1);
                }
                else
                {
                    float totalH = (this._labelSizeF.Height + this._valueUnitSizeF.Height) * this.FloatingData.Count + _padding * 2;
                    _gapV = (_rectF.Height - totalH) / (this.FloatingData.Count * 2 - 1);
                }
                if (_gapV < 0) _gapV = 0;
            }
        }

        override public void Draw(Graphics g, PaneBase pane, float scaleFactor)
        {
            // if the FloatingBlock is not visible, do nothing
            if (!_isVisible)
                return;

            #region 只有当所有Item的Value值最大长度变化时才重新计算。
            if (_isFirstDraw) //第一次绘出。
            {
                CalcRect(g, scaleFactor);
                _isFirstDraw = false;
            }
            else
            {
                float tmpW = 0.0f;
                foreach (var item in this.FloatingData)
                {
                    var itemW = item.ValueFontSpec.GetWidth(g, item.ValueString, scaleFactor);
                    if (itemW != item.ValueSizeF.Width)
                    {
                        if (itemW > tmpW) tmpW = itemW;
                        item.ValueSizeF = new SizeF(itemW, item.ValueSizeF.Height);
                    }
                }
                if (tmpW > this._valueSizeF.Width)
                {
                    this._valueSizeF.Width = tmpW;
                    this._valueUnitSizeF.Width = this._valueSizeF.Width + this._unitSizeF.Width + _gapH;
                    if (_isAutoSize)
                    {
                        CalcRect(g, scaleFactor);
                    }
                }
            }
            #endregion

            if (_rectF.Height < 1 || _rectF.Width < 1)
                return;
            if (Math.Abs(_rectF.Left) < 100000 &&
                    Math.Abs(_rectF.Top) < 100000 &&
                    Math.Abs(_rectF.Right) < 100000 &&
                    Math.Abs(_rectF.Bottom) < 100000)
            {
                // If the box is to be filled, fill it
                _fill.Draw(g, _rectF);

                // Draw the border around the box if required
                _border.Draw(g, pane, scaleFactor, _rectF);

                int i = 0;
                var x = _rectF.X + _padding;
                var baseY = _rectF.Y + _padding;
                if (_border.IsVisible) 
                    baseY += _border.Width;
                foreach (var item in this.FloatingData)
                {
                    float y = 0.0f;
                    if (IsLabelInLine)
                    {
                        y = baseY + (this._labelSizeF.Height + _gapV) * i + this._labelSizeF.Height / 2; //行中间位置(垂直方向)
                        this._labelFontSpec.Draw(g, pane, item.Label, x, y, AlignH.Left, AlignV.Center, scaleFactor, this._labelSizeF);

                        item.ValueFontSpec.Draw(g, pane, item.ValueString, _rectF.Right - _padding - this._unitSizeF.Width - _gapH - item.ValueSizeF.Width,
                            y, AlignH.Left, AlignV.Center, scaleFactor, this._valueSizeF);

                        item.UnitFontSpec.Draw(g, pane, item.Unit.ToString(), _rectF.Right -_padding - item.UnitSizeF.Width,
                            y, AlignH.Left, AlignV.Center, scaleFactor, this._unitSizeF);
                    }
                    else
                    {
                        y = baseY + (this._labelSizeF.Height + this._valueUnitSizeF.Height + _gapV * 2) * i;

                        this._labelFontSpec.Draw(g, pane, item.Label, x, y + this._labelSizeF.Height / 2, AlignH.Left, AlignV.Center, scaleFactor, this._labelSizeF);

                        item.ValueFontSpec.Draw(g, pane, item.ValueString, _rectF.Right - _padding - this._unitSizeF.Width - _gapH - item.ValueSizeF.Width,
                            y + this._labelSizeF.Height + _gapV + this._valueSizeF.Height / 2, AlignH.Left, AlignV.Center, scaleFactor, this._valueSizeF);

                        item.UnitFontSpec.Draw(g, pane, item.Unit.ToString(), _rectF.Right - _padding - item.UnitSizeF.Width,
                            y + this._labelSizeF.Height + _gapV + this._unitSizeF.Height / 2, AlignH.Left, AlignV.Center, scaleFactor, this._unitSizeF);
                    }

                    i++;
                }
            }
        }

        /// <summary>
        /// 测试浮动窗口是否包含某点。
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public Boolean HitTest(PointF pt)
        {
            return this._rectF.Contains(pt);
        }

        /// <summary>
        /// 拖动到指定位置。
        /// </summary>
        /// <param name="pt">鼠标位置。</param>
        public void MoveTo(PointF pt)
        {
            if (this.IsMoving)
                this._rectF.Location = new PointF(pt.X - this.OffsetX, pt.Y - this.OffsetY);
        }

        /// <summary>
        /// 开始拖动。
        /// </summary>
        /// <param name="pt">鼠标位置。</param>
        public void StartDrag(PointF pt)
        {
            this.OffsetX = pt.X - this.RectF.X;
            this.OffsetY = pt.Y - this.RectF.Y;
            this.IsMoving = true;
        }

        /// <summary>
        /// 停止拖动。
        /// </summary>
        public void StopDrag()
        {
            this.IsMoving = false;
        }
        #endregion
    }
}
