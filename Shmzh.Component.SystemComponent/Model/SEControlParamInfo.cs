// <copyright file="SEControlParamInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 查询模块控件参数信息。
    /// </summary>
    [Serializable]
    public class SEControlParamInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public SEControlParamInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 查询模块控件参数Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// 查询模块控件Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ControlId { get; set; }

        
        /// <summary>
        /// 查询模块控件参数名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParamName { get; set; }

        /// <summary>
        /// 参数类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ParamType { get; set; }
        /// <summary>
        /// 参数值。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParamValue { get; set; }
        /// <summary>
        /// 参数序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public byte ParamIndex { get; set; }
        #endregion
    }
}
