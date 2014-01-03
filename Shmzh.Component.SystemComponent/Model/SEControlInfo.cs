// <copyright file="SEControlInfo.cs" company="Shmzh Technology">
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
    public class SEControlInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public SEControlInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 查询模块控件Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }
        /// <summary>
        /// 查询模块ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ModuleId { get; set; }
        /// <summary>
        /// 查询模块控件标签名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string LabelName { get; set; }
        /// <summary>
        /// 查询模块控件类型ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ControlTypeId { get; set; }
        /// <summary>
        /// 查询控件数据类型ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int DataTypeId { get; set; }
        /// <summary>
        /// 显示绑定字段。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DataTextField { get; set; }
        /// <summary>
        /// 值绑定字段。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DataValueField { get; set; }
        /// <summary>
        /// 数据绑定方法的装配集。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Assembly { get; set; }
        /// <summary>
        /// 装配集中类名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ObjType { get; set; }
        /// <summary>
        /// 数据绑定方法。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Method { get; set; }
        /// <summary>
        /// 表、视图名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TableName { get; set; }
        /// <summary>
        /// 字段名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string FieldName { get; set; }
        /// <summary>
        /// 运算符
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Operator { get; set; }
        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsValid { get; set; }
        /// <summary>
        /// 顺序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int SerialNo { get; set; }
        /// <summary>
        /// 查询模块控件类型的备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
