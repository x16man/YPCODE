// <copyright file="SEModuleInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 查询模块信息。
    /// </summary>
    [Serializable]
    public class SEModuleInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public SEModuleInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 原始ID。
        /// </summary>
        public string OldId { get; set; }
        /// <summary>
        /// 查询模块Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Id { get; set; }

        /// <summary>
        /// 产品编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }

        /// <summary>
        /// 查询模块名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 查询模块SQL的前缀。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string SQL { get; set; }
        /// <summary>
        /// 连接Where条件的字符串，Where 、 And 、 Or。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Where { get; set; }
        /// <summary>
        /// 查询模块的备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
