using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 东兰工作流组织机构树的实体。
    /// </summary>
    [Serializable]
    public class TB_ORGTREEInfo
    {
        /// <summary>
        /// 父级部门 Id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ParentID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ItemName { get; set; }

        /// <summary>
        /// 部门类型
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int TypeID { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool Enable { get; set; }


        /// <summary>
        /// 部门Id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ItemID { get; set; }



    }
}
