using System;
using System.ComponentModel;

namespace Shmzh.Gather.Data.Model
{
    [Serializable]
    public class AnalogInfo
    {
        #region Property
        /// <summary>
        /// 指标Id
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagId { get; set; }
        /// <summary>
        /// 单元名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UnitName { get; set; }

        /// <summary>
        /// 值名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ValueName { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public float Value { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime Time { get; set; } 
        
        #endregion

        public AnalogInfo()
        {
        }
    }
}
