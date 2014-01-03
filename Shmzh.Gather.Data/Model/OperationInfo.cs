using System;
using System.ComponentModel;
using Shmzh.Gather.Data.Enum;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 报表操作信息类。
    /// </summary>
    [Serializable]
    public class OperationInfo
    {
        #region Property
        /// <summary>
        /// 报表分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal Id { get; set; }
        
        /// <summary>
        /// 报表分类名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 操作人代码。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OperatorCode { get; set; }

        /// <summary>
        /// 操作人姓名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OperatorName { get; set; }

        /// <summary>
        /// 操作人IP地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OperatorIp { get; set; }

        /// <summary>
        /// 报表编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ReportCode { get; set; }

        /// <summary>
        /// 操作类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public OperateType OperateType { get; set; }

        /// <summary>
        /// 时间点。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int CycleId { get; set; }

        /// <summary>
        /// 更改信息。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ModifyInfo { get; set; }

        /// <summary>
        /// 更改前的XML值。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OldXml { get; set; }
        /// <summary>
        /// 是否进行Gzip压缩.
        /// </summary>
        public bool IsZipped { get; set; }
        #endregion

        /// <summary>
        /// 报表操作信息实体的构造函数。
        /// </summary>
        public OperationInfo()
        {}
    }
}
