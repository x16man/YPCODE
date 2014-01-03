// <copyright file="MenuTypeInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 菜单类型实体。
    /// </summary>
    [Serializable]
    public class MenuTypeInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public MenuTypeInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 菜单类型ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ID { get; set; }

        /// <summary>
        /// 菜单类型名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 是否是框架使用的类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsUsedByFrameWork { get; set; }
        /// <summary>
        /// 菜单类型的说明。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
