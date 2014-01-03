using System;
using System.ComponentModel;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 时间特征实体类。
    /// </summary>
    [Serializable]
    public class DateMsInfo
    {
        #region Property
        /// <summary>
        /// 时间特征Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Id { get; set; }
        
        /// <summary>
        /// 时间特征名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 基键。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string BaseKey { get; set; }

        /// <summary>
        /// 序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short SerialNo { get; set; }

        /// <summary>
        /// 数目
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Count { get; set; }

        /// <summary>
        /// 开始索引号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short StartIndex { get; set; }

        /// <summary>
        /// 结束索引号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short EndIndex { get; set; }
        #endregion

        /// <summary>
        /// 报表分类实体的构造函数。
        /// </summary>
        public DateMsInfo()
        {}

        
    }
}
