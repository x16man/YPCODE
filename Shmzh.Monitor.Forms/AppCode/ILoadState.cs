using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Forms
{
    public interface ILoadState
    {
        /// <summary>
        /// 获取数据加载状态。
        /// </summary>
        LoadState GetLoadState();
    }
}
