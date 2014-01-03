using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 智能桌面与服务器交互数据时用到的实体类。
    /// </summary>
    [Serializable]
    public class SDTransferInfo
    {
        /// <summary>
        /// 最新阅读消息时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ViewTime { get; set; }
        /// <summary>
        /// 最近收取消息时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 在线状态。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public String OnlineStatus { get; set; }
        /// <summary>
        /// 在线人数。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public Int32 OnlineCount { get; set; }
    }
}
