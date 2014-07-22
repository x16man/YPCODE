using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Gadget
{   
    public abstract class BaseInfo : HoverInfo
    {
        /// <summary>
        /// X坐标。
        /// </summary>
        public virtual Int32 X { get; set; }
        /// <summary>
        /// Y坐标。
        /// </summary>
        public virtual Int32 Y { get; set; }
               
        /// <summary>
        /// 是否使用鼠标悬浮的效果。
        /// </summary>
        public virtual Boolean IsHoverEffect { get; set; }
    }
    
}
