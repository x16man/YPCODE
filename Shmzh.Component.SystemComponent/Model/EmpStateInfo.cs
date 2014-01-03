// <copyright file="GroupInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 员工状态信息
    /// </summary>
    [Serializable]
    public class EmpStateInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public EmpStateInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 员工状态编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }

        /// <summary>
        /// 员工状态名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Description { get; set; }

        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        #endregion
    }
}
