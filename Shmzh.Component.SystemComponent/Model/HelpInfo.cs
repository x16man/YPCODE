// <copyright file="HelpInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System.Data;
    /// <summary>
    /// 帮助实体
    /// </summary>
    public class HelpInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 上级编号
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int Serial { get; set; }

        /// <summary>
        /// 是否有孩子
        /// </summary>
        public string HasChild { get; set; }

        /// <summary>
        /// 帮助信息。
        /// </summary>
        public HelpInfo()
        {
            this.HasChild = "N";
        }
    }
}