// <copyright file="OnlineStatus.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 组信息
    /// </summary>
    [Serializable]
    public class OnlineStatusInfo
    {
        #region Constructor
        ///<summary>
        /// 默认构造函数。
        ///</summary>
        public OnlineStatusInfo()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="ipAddress">IP地址。</param>
        /// <param name="status">在线状态。</param>
        /// <param name="beatTime">心跳时间。</param>
        public OnlineStatusInfo(string userName, string ipAddress, string status, DateTime beatTime)
        {
            this.UserName = userName;
            this.IPAddress = ipAddress;
            this.Status = status;
            this.BeatTime = beatTime;
        }
        
        #endregion

        #region Property
        /// <summary>
        /// 用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserName { get; set; }

        /// <summary>
        /// IP地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IPAddress { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Status { get; set; }

        /// <summary>
        /// 心跳时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime BeatTime { get; set; }
        #endregion
    }
}
