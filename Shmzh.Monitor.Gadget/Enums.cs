using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Gadget
{
    public enum DeviceState
    {
        /// <summary>
        /// 停止。
        /// </summary>
        Stopped = 0,

        /// <summary>
        /// 运行。
        /// </summary>
        Running = 1,

        /// <summary>
        /// 故障。
        /// </summary>
        Malfunction = 2,

        /// <summary>
        /// 检修。
        /// </summary>
        Repairing = 3
    }

    public enum TextAlign
    { 
        Left,
        Right,
        Center,
    }
}
