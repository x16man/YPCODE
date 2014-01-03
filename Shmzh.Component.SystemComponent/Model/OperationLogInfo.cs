using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 系统的操作日志实体。
    /// </summary>
    [Serializable]
    public class OperationLogInfo
    {
        #region Property
        /// <summary>
        /// Id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long Id { get; set; }
        /// <summary>
        /// 操作人用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserName { get; set; }
        /// <summary>
        /// 操作时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime OpTime { get; set; }
        /// <summary>
        /// 产品编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }
        /// <summary>
        /// 操作类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OpType { get; set; }
        /// <summary>
        /// 操作描述。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OpDesc { get; set; }
        #endregion

        #region CTOR
        /// <summary>
        /// 构造函数。
        /// </summary>
        public OperationLogInfo()
        {
            
        }
        #endregion


    }
}
