using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shmzh.Monitor.Gadget
{
    public interface ITriggerEvent
    {
        String TriggerEvent { get; set; }
        
        /// <summary>
        /// 用户关联数据。
        /// </summary>
        Object Tag { get; set; }

        /// <summary>
        /// 触发事件的边界矩形。
        /// </summary>
        Rectangle HotBounds { get; set; }
    }
}
