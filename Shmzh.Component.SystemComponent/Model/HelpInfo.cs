// <copyright file="HelpInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System.Data;
    /// <summary>
    /// ����ʵ��
    /// </summary>
    public class HelpInfo
    {
        /// <summary>
        /// ���
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// �ϼ����
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public int Serial { get; set; }

        /// <summary>
        /// �Ƿ��к���
        /// </summary>
        public string HasChild { get; set; }

        /// <summary>
        /// ������Ϣ��
        /// </summary>
        public HelpInfo()
        {
            this.HasChild = "N";
        }
    }
}