// <copyright file="SESchemaInfo.cs" company="Shmzh Technology">
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
    public class SESchemaInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public SESchemaInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 查询方案Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// 查询模块ID.
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ModuleId { get; set; }
        
        /// <summary>
        /// 用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserCode { get; set; }
        
        /// <summary>
        /// 查询方案名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string SchemaName { get; set; }
        
        /// <summary>
        /// Where语句部分。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string WhereClause { get; set; }
        
        /// <summary>
        /// 查询方案描述。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// 是否是默认查询方案。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsDefault { get; set; }

        /// <summary>
        /// 创建日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateTime { get; set; }


        #endregion
    }
}
