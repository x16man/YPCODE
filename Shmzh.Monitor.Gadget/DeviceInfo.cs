using System;
using System.Drawing;
using System.IO;

namespace Shmzh.Monitor.Gadget
{
    public class DeviceInfo : TextBaseInfo
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region CTOR
        public DeviceInfo()
        {
            this.CurrentSrc = String.Empty;
        }
        #endregion

        #region property
        /// <summary>
        /// Padding Top。
        /// </summary>
        public Int32 PaddingTop { get; set; }
        /// <summary>
        /// Padding Left。
        /// </summary>
        public Int32 PaddingLeft { get; set; }
        
        /// <summary>
        /// 运行图片。
        /// </summary>
        public String RunSrc { get; set; }

        /// <summary>
        /// 停止图片。
        /// </summary>
        public String StopSrc { get; set; }
        
        /// <summary>
        /// 故障图片。
        /// </summary>
        public String MalfunctionSrc { get; set; }
        
        /// <summary>
        /// 检修图片。
        /// </summary>
        public String RepairSrc { get; set; }
        
        /// <summary>
        /// 显示的文本。
        /// </summary>
        public String Text { get; set; }
        /// <summary>
        /// 关联的指标Id。
        /// </summary>
        public String DevCode { get; set; }
        /// <summary>
        /// 数据类型（秒、分钟、15分钟、小时、天、月、年）
        /// </summary>
        public String DataType { get; set; }
        /// <summary>
        /// 设备状态。
        /// </summary>
        public DeviceState State { get; set; }
        /// <summary>
        /// 点击触发的事件。
        /// </summary>
        public override String TriggerEvent { get; set; }
        /// <summary>
        /// 是否竖写的文本。
        /// </summary>
        public Boolean IsVertical { get; set; }

        /// <summary>
        /// 当前的图片源。
        /// </summary>
        private String CurrentSrc { get; set; }
        /// <summary>
        /// 当前图片。
        /// </summary>
        private Image CurrentImage { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// 绘制呈现。
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g)
        {
            String orgSrc = "";
            switch (State)
            {
                case DeviceState.Stopped:
                    orgSrc = StopSrc;
                    break;
                case DeviceState.Running:
                    orgSrc = RunSrc;
                    break;
                case DeviceState.Malfunction:
                    orgSrc = MalfunctionSrc;
                    break;
                case DeviceState.Repairing:
                    orgSrc = RepairSrc;
                    break;
                default:
                    orgSrc = StopSrc;
                    break;
            }
            if (!String.IsNullOrEmpty(orgSrc))
            {
                if (this.CurrentSrc != orgSrc)
                {
                    this.CurrentSrc = orgSrc;
                    if (!ConfigImages.ContainsKey(orgSrc))
                    {
                        Logger.Error(String.Format("设备图片“{0}”找不到!", orgSrc));
                    }
                    CurrentImage = ConfigImages.GetByKey(orgSrc);
                }
                if (CurrentImage != null)
                {
                    Image img = CurrentImage;
                    Width = Width == 0 ? img.Width : Width;
                    Height = Height == 0 ? img.Height : Height;
                    Bounds = new Rectangle(X, Y, Width, Height);
                    //画图片。
                    g.DrawImage(img, Bounds);
                }
            }
            else
            {
                Bounds = new Rectangle(X, Y, Width, Height);
            }
            
            var fontStyle = FontStyle.Regular;
            Brush brush;
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
            }

            var sf = new StringFormat
                         {
                             Alignment = StringAlignment.Near,
                             LineAlignment = StringAlignment.Near,
                             FormatFlags = StringFormatFlags.NoWrap
                         };
            if (IsVertical)
            {
                sf.FormatFlags |= StringFormatFlags.DirectionVertical;
            }
            var font = new Font(FontFamily, FontSize, fontStyle);
            //画字。
            g.DrawString(Text, font, brush, X + PaddingLeft, Y + PaddingTop, sf);
            font.Dispose();
            brush.Dispose();
            sf.Dispose();
        }
        #endregion
    }
}
