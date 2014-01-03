// <copyright file="OnlineStatus.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 模板记录实体。
    /// </summary>
    [Serializable]
    public class TemplateInfo
    {
        #region Constructor
        ///<summary>
        /// 默认构造函数。
        ///</summary>
        public TemplateInfo()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">模板ID。</param>
        /// <param name="productCode">产品ID。</param>
        /// <param name="code">模板编号。</param>
        /// <param name="name">模板名称。</param>
        /// <param name="content">模板内容。</param>
        /// <param name="remark">模板备注。</param>
        public TemplateInfo(int id,short productCode, string code, string name, string content, string remark)
        {
            this.ID = id;
            this.ProductCode = productCode;
            this.Code = code;
            this.Name = name;
            this.Content = content;
            this.Remark = remark;
        }
        
        #endregion

        #region Property
        /// <summary>
        /// 模板ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ID { get; set; }
        /// <summary>
        /// 产品ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }
        /// <summary>
        /// 模板编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }
        /// <summary>
        /// 模板名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// IP地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Content { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        #endregion
    }
}
