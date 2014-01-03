// <copyright file="SEDataTypeInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 查询模块数据类型信息。
    /// </summary>
    [Serializable]
    public class SEDataTypeInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public SEDataTypeInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 查询模块原始ID。
        /// </summary>
        public int OldId { get; set; }
        /// <summary>
        /// 查询模块Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// 查询模块数据类型名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        
        /// <summary>
        /// 查询模块数据类型的备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
