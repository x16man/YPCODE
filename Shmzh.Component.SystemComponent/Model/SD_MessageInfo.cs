
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 消息实体。
    /// </summary>
    [Serializable]
    public class SD_MessageInfo
    {
        #region CTOR
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public SD_MessageInfo()
        {
        }
        
        #endregion

        #region Property
        /// <summary>
        /// 消息ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long ID { get; set; }
        /// <summary>
        /// 消息类型ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TypeId { get; set; }
        /// <summary>
        /// 消息标题。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }
        /// <summary>
        /// 消息描述。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Desc { get; set; }
        /// <summary>
        /// 优先级。
        /// </summary>
        /// <remarks></remarks>
        [Bindable(BindableSupport.Yes)]
        public short PRI { get; set; }
        /// <summary>
        /// URL地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string URL { get; set; }
        /// <summary>
        /// 消息状态。
        /// </summary>
        /// <remarks>0:新状态；1：已提示；2：已阅读。</remarks>
        [Bindable(BindableSupport.Yes)]
        public short Status { get; set; }
        /// <summary>
        /// 提交人。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Refer { get; set; }
        /// <summary>
        /// 提交人用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ReferUserName { get; set; }
        /// <summary>
        /// 处理人。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Handler { get; set; }
        /// <summary>
        /// 处理人用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string HandlerUserName { get; set; }
        /// <summary>
        /// 消息创建时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 消息提示时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime TipTime { get; set; }
        /// <summary>
        /// 消息阅读时间。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ViewTime { get; set; }
        /// <summary>
        /// 接收人个数。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public Int32 HandlerCount { get; set; }        
        #endregion
    }
}
