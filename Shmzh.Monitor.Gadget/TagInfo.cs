using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Gadget
{
    public class TagInfo : TextBaseInfo
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Double _value = double.NaN;
        private Boolean isInitialized = false;
        #endregion

        public TagInfo()
        {
            this.ValueTime = DateTime.MinValue;
        }

        #region Property
        /// <summary>
        /// 数据类型。可选值：Second/Min/Min15/Hour/Day/Month/Year.
        /// </summary>
        public String DataType { get; set; }
        public String TagId { get; set; }
        /// <summary>
        /// 指标名称。
        /// </summary>
        public String TagName { get; set; }
        /// <summary>
        /// 取值的时间。
        /// </summary>
        public DateTime ValueTime { get; set; }
        public String StringFormat { get; set; }
        public override String TriggerEvent { get; set; }
        public Double Value
        {
            get { return _value;}
            set
            {
                if(_value == value) return;
                _value = value;
                if (_value.Equals(Double.MinValue))
                    Text = Utils.IsDebug ? String.Format("Tag“{0}”Error!", TagId ?? "") : String.Format(this.StringFormat, 0);
                if (Double.IsInfinity(_value) || Double.IsNaN(_value))
                    Text = Utils.IsDebug ? String.Format(this.StringFormat, _value) : String.Format(this.StringFormat, 0);
                else
                    Text = String.Format(this.StringFormat, _value);
                OnValueChanged();
            }
        }

        public String Text { get; set; }
        public String MonitorObj { get; set; }
        public String BorderColorExp { private get; set; }
        public String NormalColorExp { private get; set; }
        public String SelectedColorExp { private get; set; }
        /// <summary>
        /// 字的颜色。
        /// </summary>
        public new Color NormalColor { get; set; }
        
        /// <summary>
        /// 选中时字的颜色。
        /// </summary>
        public new Color SelectedColor { get; set; }
        
        /// <summary>
        /// 边框的颜色。
        /// </summary>
        public new Color BorderColor { get; set; }
        
        #endregion

        #region Method
        public void Render(Graphics g)
        {
            var absoluteX = this.BasePoint == null ? this.X : this.BasePoint.X + this.X;
            var absoluteY = this.BasePoint == null ? this.Y : this.BasePoint.Y + this.Y;
                                
            if (!isInitialized)
            {
                OnValueChanged();
                isInitialized = true;
            }
            if(ParentNode is DeviceInfo)
            {
                var devInfo = ParentNode as DeviceInfo;
                if(devInfo.State != DeviceState.Running) return;
            }

            var tempSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.Default;
            
            var fontStyle = FontStyle.Regular;
            Brush brush;
            Color backColor;

            if (IsMouseOver)
            {
                if (SelectedIsItalic)
                {
                    fontStyle |= FontStyle.Italic;
                }
                if (SelectedIsBold)
                {
                    fontStyle |= FontStyle.Bold;
                }
                if (SelectedIsUnderLine)
                {
                    fontStyle |= FontStyle.Underline;
                }
                brush = new SolidBrush(SelectedColor);
                backColor = SelectedBackColor;
            }
            else
            {
                if (NormalIsItalic)
                {
                    fontStyle |= FontStyle.Italic;
                }
                if (NormalIsBold)
                {
                    fontStyle |= FontStyle.Bold;
                }
                if (NormalIsUnderLine)
                {
                    fontStyle |= FontStyle.Underline;
                }
                brush = new SolidBrush(NormalColor);
                backColor = NormalBackColor;
            }

            var sf = new StringFormat {LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center};
            switch (Align)
            {
                case TextAlign.Left:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case TextAlign.Center:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case TextAlign.Right:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            sf.FormatFlags = StringFormatFlags.NoWrap;
            sf.FormatFlags |= StringFormatFlags.NoClip;
            
            var font = new Font(FontFamily, FontSize, fontStyle);
            SizeF sizeF = String.IsNullOrEmpty(Text) ? new SizeF(500, font.Height) : g.MeasureString(Text, font, new PointF(absoluteX, absoluteY), sf);
            if (Width == 0 || Height == 0)
            {
                Bounds = new Rectangle(new Point(absoluteX, absoluteY), new Size(Convert.ToInt32(Math.Ceiling(sizeF.Width)), Convert.ToInt32(Math.Ceiling(sizeF.Height))));
            }
            else
            {
                Bounds = new Rectangle(absoluteX, absoluteY, Width, Height);
            }
            
            //画背景。
            if (backColor != Color.Transparent) g.FillRectangle(new SolidBrush(backColor), Bounds);
            //画字。
            if (!String.IsNullOrEmpty(Text)) g.DrawString(Text, font, brush, Bounds, sf);

            if (Width == 0 || Height == 0)
            {
                Bounds = new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height + BottomWidth / 2);
            }
           
            //画边框。
            if (BorderColor != Color.Transparent)
            {
                using (var pen = new Pen(BorderColor))
                {
                    var halfTop = TopWidth / 2F;
                    var halfBottom = BottomWidth / 2F;
                    if (BottomWidth == 1)
                    {
                        halfBottom--;
                    }

                    if (LeftWidth > 0)
                    {
                        pen.Width = LeftWidth;
                        g.DrawLine(pen, Bounds.Left, Bounds.Top - TopWidth, Bounds.Left, Bounds.Bottom);
                    }
                    if (TopWidth > 0)
                    {
                        pen.Width = TopWidth;
                        g.DrawLine(pen, Bounds.Left, Bounds.Top - halfTop, Bounds.Right, Bounds.Top - halfTop);
                    }
                    if (RightWidth > 0)
                    {
                        pen.Width = RightWidth;
                        g.DrawLine(pen, Bounds.Right, Bounds.Top - TopWidth, Bounds.Right, Bounds.Bottom);
                    }
                    if (BottomWidth > 0)
                    {
                        pen.Width = BottomWidth;
                        g.DrawLine(pen, Bounds.Left, Bounds.Bottom - halfBottom, Bounds.Right, Bounds.Bottom - halfBottom);
                    }

                    Bounds = Rectangle.Inflate(Bounds, Math.Max(LeftWidth, RightWidth), Math.Max(TopWidth, BottomWidth));
                }
            }
            font.Dispose();
            brush.Dispose();
            sf.Dispose();
            g.SmoothingMode = tempSmoothingMode;
        }

        private void OnValueChanged()
        {
            //此句是为了兼容将“文本”配置到"指标"的"StringFormat"属性里的做法。
            if (String.IsNullOrEmpty(TagId) && !String.IsNullOrEmpty(StringFormat) && !StringFormat.Contains("{0}"))
                Text = StringFormat;

            if (Utils.IsExp(BorderColorExp))
            {
                BorderColor = StringUtil.StringToColor(Utils.CalcExpString(BorderColorExp, Value, MonitorObj), Color.Black);
            }
            else
            {
                BorderColor = StringUtil.StringToColor(BorderColorExp, Color.Black);
            }

            if (Utils.IsExp(SelectedColorExp))
            {
                SelectedColor = StringUtil.StringToColor(Utils.CalcExpString(SelectedColorExp, Value, MonitorObj), Color.Black);
            }
            else
            {
                SelectedColor = StringUtil.StringToColor(SelectedColorExp, Color.Black);
            }

            if (Utils.IsExp(NormalColorExp))
            {
                NormalColor = StringUtil.StringToColor(Utils.CalcExpString(NormalColorExp, Value, MonitorObj), Color.Black);
            }
            else
            {
                NormalColor = StringUtil.StringToColor(NormalColorExp, Color.Black);
            }
        }
        #endregion

    }        
}

