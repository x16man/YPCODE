// <copyright file="SEControlTypeInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 查询模块控件类型信息。
    /// </summary>
    [Serializable]
    public class SEControlTypeInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public SEControlTypeInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 查询模块控件类型原始ID。
        /// </summary>
        public int OldId { get; set; }
        /// <summary>
        /// 查询模块控件类型Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// 查询模块控件类型名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        
        /// <summary>
        /// 查询模块控件类型的备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
