using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 系统访问历史记录实体类。
    /// </summary>
    [Serializable]
    public class HistoryInfo
    {
        #region Property
        /// <summary>
        /// ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long Id { get; set; }
        /// <summary>
        /// 动作。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Operation{ get; set;}
        /// <summary>
        /// 访问的URL。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Url{get; set;}
        /// <summary>
        /// 用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserName { get; set; }
        /// <summary>
        /// IP地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IpAddress { get; set; }
        /// <summary>
        /// 操作时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime OpTime { get; set; }
        #endregion
        /// <summary>
        /// CTOR
        /// </summary>
        public HistoryInfo()
        {
            
        }
    }
}