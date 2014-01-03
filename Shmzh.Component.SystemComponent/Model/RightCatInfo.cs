// <copyright file="RightCatInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 权限分组信息
    /// </summary>
    [Serializable]
    public class RightCatInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public RightCatInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 权限分组编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }

        /// <summary>
        /// 权限分组名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 权限分组描述。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Desc { get; set; }
        /// <summary>
        /// 权限分组所属产品编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }
        /// <summary>
        /// 权限分组是否。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        #endregion
    }
}
