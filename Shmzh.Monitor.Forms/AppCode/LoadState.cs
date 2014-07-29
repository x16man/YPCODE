using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Forms
{
    /// <summary>
    /// 数据加载状态。
    /// </summary>
    public enum LoadState : byte
    {
        /// <summary>
        /// 未知的。
        /// </summary>
        Unknown,
        /// <summary>
        /// 正在加载。
        /// </summary>
        Loading,
        /// <summary>
        /// 加载完成。
        /// </summary>
        Finished,
        /// <summary>
        /// 中止加载。
        /// </summary>
        Stopped
    }
}
