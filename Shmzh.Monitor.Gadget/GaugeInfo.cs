using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shmzh.Windows.Forms;

namespace Shmzh.Monitor.Gadget
{
    public class GaugeInfo : BaseInfo, IDisposable
    {
        #region Fields
        private AGauge aGauge;
        private String _fontFamily = "宋体";
        private Single _fontSize = 9F;        
        #endregion
        public GaugeInfo()
        {
            aGauge = new AGauge();
        }

        ~GaugeInfo()
        {
            Dispose();
        }

        /// <summary>
        /// 数据类型。可选值：Second/Min/Min15/Hour/Day/Month/Year.
        /// </summary>
        public String DataType { get; set; }
        public String TagId { get; set; }
        public Double Value { get; set; }
        public Single MaxValue { get; set; }
        public Single MinValue { get; set; }
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        public Point Center { get; set; }
        public Color BackColor { get; set; }

        public Color BaseArcColor { get; set; }
        public Int32 BaseArcRadius { get; set; }
        public Int32 BaseArcStart { get; set; }
        public Int32 BaseArcSweep { get; set; }
        public Int32 BaseArcWidth { get; set; }

        public Color ScaleLinesMajorColor { get; set; }
        public Int32 ScaleLinesMajorInnerRadius { get; set; }
        public Int32 ScaleLinesMajorOuterRadius { get; set; }
        public Int32 ScaleLinesMajorWidth { get; set; }
        public Single ScaleLinesMajorStepValue { get; set; }

        public Color ScaleLinesInterColor { get; set; }
        public Int32 ScaleLinesInterInnerRadius { get; set; }
        public Int32 ScaleLinesInterOuterRadius { get; set; }
        public Int32 ScaleLinesInterWidth { get; set; }

        public Color ScaleLinesMinorColor { get; set; }
        public Int32 ScaleLinesMinorInnerRadius { get; set; }
        public Int32 ScaleLinesMinorOuterRadius { get; set; }
        public Int32 ScaleLinesMinorWidth { get; set; }
        public Int32 ScaleLinesMinorNumOf { get; set; }

        public Color ScaleNumbersColor { get; set; }
        public String ScaleNumbersFormat { get; set; }
        public Int32 ScaleNumbersRadius { get; set; }
        public Int32 ScaleNumbersRotation { get; set; }

        /// <summary>
        /// The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.
        /// </summary>
        public Int32 NeedleType { get; set; }
        public Int32 NeedleRadius { get; set; }
        public AGauge.NeedleColorEnum NeedleColor1 { get; set; }
        public Color NeedleColor2 { get; set; }
        public Int32 NeedleWidth { get; set; }

        public Boolean[] RangesEnabled { get; set; }
        public Single[] RangesStartValue { get; set; }
        public Single[] RangesEndValue { get; set; }
        public Int32[] RangesInnerRadius { get; set; }
        public Int32[] RangesOuterRadius { get; set; }
        public Color[] RangesColor { get; set; }

        /// <summary>
        /// 字体名。
        /// </summary>
        public String FontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }
        /// <summary>
        /// 字体大小emSize.
        /// </summary>
        public Single FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }
        public Boolean IsItalic { get; set; }
        public Boolean IsBold { get; set; }
        public Boolean IsUnderLine { get; set; }

        /// <summary>
        /// 输出。
        /// </summary>
        /// <param name="control"></param>
        public void Render(Control control)
        {
            if (Width < 10 || Height < 10) return;
            aGauge.BackColor = BackColor;
            aGauge.BaseArcColor = BaseArcColor;
            aGauge.BaseArcRadius = BaseArcRadius;
            aGauge.BaseArcStart = BaseArcStart;
            aGauge.BaseArcSweep = BaseArcSweep;
            aGauge.BaseArcWidth = BaseArcWidth;
            aGauge.Center = Center;
            aGauge.Location = new Point(X, Y);
            aGauge.MaxValue = MaxValue;
            aGauge.MinValue = MinValue;
            aGauge.NeedleColor1 = NeedleColor1;
            aGauge.NeedleColor2 = NeedleColor2;
            aGauge.NeedleRadius = NeedleRadius;
            aGauge.NeedleType = NeedleType;
            aGauge.NeedleWidth = NeedleWidth;

            aGauge.RangesEnabled = RangesEnabled;
            aGauge.RangesColor = RangesColor;
            aGauge.RangesStartValue = RangesStartValue;
            aGauge.RangesEndValue = RangesEndValue;
            aGauge.RangesInnerRadius = RangesInnerRadius;
            aGauge.RangesOuterRadius = RangesOuterRadius;

            aGauge.ScaleLinesInterColor = ScaleLinesInterColor;
            aGauge.ScaleLinesInterInnerRadius = ScaleLinesInterInnerRadius;
            aGauge.ScaleLinesInterOuterRadius = ScaleLinesInterOuterRadius;
            aGauge.ScaleLinesInterWidth = ScaleLinesInterWidth;

            aGauge.ScaleLinesMajorColor = ScaleLinesMajorColor;
            aGauge.ScaleLinesMajorInnerRadius = ScaleLinesMajorInnerRadius;
            aGauge.ScaleLinesMajorOuterRadius = ScaleLinesMajorOuterRadius;
            aGauge.ScaleLinesMajorStepValue = ScaleLinesMajorStepValue;
            aGauge.ScaleLinesMajorWidth = ScaleLinesMajorWidth;

            aGauge.ScaleLinesMinorColor = ScaleLinesMinorColor;
            aGauge.ScaleLinesMinorInnerRadius = ScaleLinesMinorInnerRadius;
            aGauge.ScaleLinesMinorNumOf = ScaleLinesMinorNumOf;
            aGauge.ScaleLinesMinorOuterRadius = ScaleLinesMinorOuterRadius;
            aGauge.ScaleLinesMinorWidth = ScaleLinesMinorWidth;

            aGauge.ScaleNumbersColor = ScaleNumbersColor;
            aGauge.ScaleNumbersFormat = ScaleNumbersFormat;
            aGauge.ScaleNumbersRadius = ScaleNumbersRadius;
            aGauge.ScaleNumbersRotation = ScaleNumbersRotation;
            //aGauge.ScaleNumbersStartScaleLine = 1;
            //aGauge.ScaleNumbersStepScaleLines = 10;

            aGauge.Value = Convert.ToSingle(Value);
            aGauge.AutoSize = true;
            aGauge.Size = new Size(Width, Height);
            //设置字体。
            FontStyle fs = FontStyle.Regular;
            if (IsItalic)
            {
                fs |= FontStyle.Italic;
            }
            if (IsBold)
            {
                fs |= FontStyle.Bold;
            }
            if (IsUnderLine)
            {
                fs |= FontStyle.Underline;
            }
            Font font = new Font(FontFamily, FontSize, fs);            
            aGauge.Font = font;

            control.Controls.Add(aGauge);
        }

        /// <summary>
        /// 刷新。
        /// </summary>
        public void Refresh()
        {
            if (!aGauge.Created) return;
            aGauge.Value = Convert.ToSingle(Value);
        }

        public void Dispose()
        {
            aGauge.Dispose();
        }
    }
}
