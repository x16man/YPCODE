namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 消息类型实体。
    /// </summary>
    [Serializable]
    public class SD_MessageTypeInfo
    {
        #region CTOR
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public SD_MessageTypeInfo()
        {
        }
        /// <summary>
        /// 消息类型的构造函数。
        /// </summary>
        /// <param name="id">消息类型id。</param>
        /// <param name="name">消息类型名称。</param>
        /// <param name="isLocked">是否锁定。</param>
        /// <param name="remark">消息类型备注。</param>
        public SD_MessageTypeInfo(string id, string name, bool isLocked, string remark)
        {
            this.ID = id;
            this.Name = name;
            this.IsLocked = isLocked;
            this.Remark = remark;
        }

        #endregion

        #region Property
        /// <summary>
        /// 消息类型ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ID { get; set; }
        /// <summary>
        /// 消息类型名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }
        /// <summary>
        /// 是否是锁定的。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsLocked { get; set; }
        /// <summary>
        /// 消息类型描述。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        /// <summary>
        /// 排序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public Int32 SerialNumber { get; set; }
        /// <summary>
        /// 消息个数。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public Int32 MsgCount { get; set; }
        #endregion
    }
}
