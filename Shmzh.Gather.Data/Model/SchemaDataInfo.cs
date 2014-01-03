using System;
using System.ComponentModel;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 报表实体类。
    /// </summary>
    [Serializable]
    public class SchemaDataInfo
    {
        #region Property
        /// <summary>
        /// 报表Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Id { get; set; }

        /// <summary>
        /// 报表日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ReportDate { get; set; }

        /// <summary>
        /// 新的报表XML内容。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string NewXmlData { get; set; }

        /// <summary>
        /// 旧的报表XML内容。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OldXmlData { get; set; }

        /// <summary>
        /// 报表操作的用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserCode { get; set; }

        /// <summary>
        /// 报表操作的用户姓名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserName { get; set; }

        /// <summary>
        /// 报表操作的客户端Ip地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserIp { get; set; }

        /// <summary>
        /// 报表内容是否
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool IsZipped { get; set; }
        #endregion

        /// <summary>
        /// 报表实体的构造函数。
        /// </summary>
        public SchemaDataInfo()
        {}
    }

}
