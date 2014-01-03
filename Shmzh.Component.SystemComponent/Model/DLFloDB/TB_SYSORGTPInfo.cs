using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 东兰工作流组织机构类型的实体。
    /// </summary>
    [Serializable]
    public class TB_SYSORGTPInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int TypeId { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ClassOrder { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TypeName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool Enable { get; set; }
    }
}
