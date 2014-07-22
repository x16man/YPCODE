using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 类别信息实体。
    /// </summary>
    [Serializable]
    public class CategoryItemInfo
    {
        #region Property
        /// <summary>
        /// 类别条目Id。
        /// </summary>
        [Bindable(true)]
        public int ItemId { get; set; }

        /// <summary>
        /// 类别Id。
        /// </summary>
        [Bindable(true)]
        public int CategoryId { get; set; }

        /// <summary>
        /// 类别条目Title。
        /// </summary>
        [Bindable(true)]
        public string Title { get; set; }
       
        /// <summary>
        /// 更新时间(秒)。
        /// </summary>
        [Bindable(true)]
        public int UpdateTime { get; set; }

        /// <summary>
        /// 条目要使用的类。
        /// </summary>
        [Bindable(true)]
        public String ClassName { get; set; }

        /// <summary>
        /// 对应的配置文件或方案名。
        /// </summary>
        [Bindable(true)]
        public String ConfigFile { get; set; }

        /// <summary>
        /// 编码。
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 排序号。
        /// </summary>
        public int SerialNumber { get; set; }
        #endregion

        #region CTOR
        public CategoryItemInfo()
        {
            this.Title = "";
            this.UpdateTime = 0;
            this.ClassName = "";
            this.ConfigFile = "";
        }
        #endregion

//        public override string ToString()
//        {
//            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
//                @"{6}:
//- SchemaId: {0}
//- Name: {1}
//- IsValid: {2}
//- Layout: {3}
//- Remark:{4}
//- DataType:{5}
//",
//                this.SchemaId,
//                this.Name,
//                this.IsValid,
//                this.Layout,
//                this.Remark,
//                this.DataType,
//                this.GetType());
//        }
    }

}
