using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shmzh.Monitor.Gadget
{
    public abstract class TextBaseInfo : BaseInfo
    {
        public BasePointInfo BasePoint { get; set; }
        /// <summary>
        /// 字体名。
        /// </summary>
        public String FontFamily { get; set; }        
        /// <summary>
        /// 字体大小emSize.
        /// </summary>
        public Single FontSize { get; set; }

        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        public TextAlign Align { get; set; }

        public Color NormalColor { get; set; }
        public Color NormalBackColor { get; set; }
        public Boolean NormalIsBold { get; set; }
        public Boolean NormalIsUnderLine { get; set; }
        /// <summary>
        /// 非选中时是否斜体。
        /// </summary>
        public Boolean NormalIsItalic { get; set; }

        public Color SelectedColor { get; set; }
        public Color SelectedBackColor { get; set; }
        public Boolean SelectedIsBold { get; set; }
        public Boolean SelectedIsUnderLine { get; set; }        
        /// <summary>
        /// 选中时是否斜体。
        /// </summary>
        public Boolean SelectedIsItalic { get; set; }

        public Color BorderColor { get; set; }
        public Int32 LeftWidth { get; set; }
        public Int32 RightWidth { get; set; }
        public Int32 TopWidth { get; set; }
        public Int32 BottomWidth { get; set; }
    }
}
