// <copyright file="GroupInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 部门信息实体。
    /// </summary>
    [Serializable]
    public class OrgTypeInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public OrgTypeInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }
        /// <summary>
        /// 级别。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Level { get; set; }
        /// <summary>
        /// 中文名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CnName { get; set; }
        /// <summary>
        /// 英文名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string EnName { get; set; }
        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        #endregion
    }
}
