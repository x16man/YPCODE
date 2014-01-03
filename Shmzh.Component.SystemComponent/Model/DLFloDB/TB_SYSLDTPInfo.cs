using System;
using System.ComponentModel;

namespace Shmzh.Components.SystemComponent
{
    [Serializable]
    public class TB_SYSLDTPInfo
    {
        #region Property
        /// <summary>
        /// 部门领导类型Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int TypeId { get; set; }
        /// <summary>
        /// 顺序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ClassOrder { get; set; }
        /// <summary>
        /// 部门领导类型名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TypeName { get; set; }
        /// <summary>
        /// 有效性。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool Enable { get; set; }
        #endregion

        #region CTOR
        public TB_SYSLDTPInfo(){}
        #endregion
    }
}
