using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 指标实体类,该类为采集服务时使用。
    /// </summary>
    [Serializable]
    public class TagInfo
    {
        #region Property
        /// <summary>
        /// 指标Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagId { get; set; }
        
        /// <summary>
        /// 指标名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagName { get; set; }

        /// <summary>
        /// 小数点保留位数。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short DigNum { get; set; }

        /// <summary>
        /// 单位。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Unit { get; set; }

        /// <summary>
        /// 指标类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagType { get; set; }

        /// <summary>
        /// 小时前的计算方式。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Calc_Type_Before_Hour { get; set; }

        /// <summary>
        /// 小时后的计算方式。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Calc_Type_After_Hour { get; set; }

        /// <summary>
        /// 是否进行秒到分钟的转换。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool SecondToMinute { get; set; }

        /// <summary>
        /// 是否进行分钟到5分钟/15分钟的转换。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool MinuteToMin5 { get; set; }

        /// <summary>
        /// 是否进行分钟到小时的转换。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool MinuteToHour { get; set; }

        /// <summary>
        /// 是否进行小时到日的转换。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool HourToDay { get; set; }

        /// <summary>
        /// 是否进行日到月的转换。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool DayToMonth { get; set; }

        /// <summary>
        /// 是否进行月到年的转换。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool MonthToYear { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// 计算公式。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Func { get; set; }

        /// <summary>
        /// 开关量指标关联的设备编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DevCode { get; set; }

        /// <summary>
        /// 最小有效值。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public double MinValue { get; set; }

        /// <summary>
        /// 最大有效值。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public double MaxValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DesignCD { get; set; }

        /// <summary>
        /// 指标地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Address { get; set; }

        /// <summary>
        /// 修正参数A。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public double ParaA { get; set; }

        /// <summary>
        /// 修正参数B。
        /// </summary>
        public double ParaB { get; set; }

        /// <summary>
        /// 修正参数C。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public double ParaC { get; set; }

        /// <summary>
        /// 采集时候的最大有效值。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public double MaxGatherValue { get; set; }

        /// <summary>
        /// 采集时候的最小有效值。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public double MinGatherValue { get; set; }

        /// <summary>
        /// 采集类型。0：不采集；1：OPC；2：IMPACC DDE；3：PCDDE。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Action { get; set; }
        
        /// <summary>
        /// 当前指标所属的DdeClient。
        /// </summary>
        public object Client { get; set; }
        /// <summary>
        /// DdeClient Advise Event's Value;
        /// </summary>
        public double AdviseValue { get; set; }

        /// <summary>
        /// 原始值。
        /// </summary>
        public double Value0 { get; set; }
        /// <summary>
        /// 修正值。
        /// </summary>
        public double Value1 { get; set; }
        /// <summary>
        /// 上次的原始值。
        /// </summary>
        public double LastValue { get; set; }
        /// <summary>
        /// 最近一次中断的值。
        /// </summary>
        public double BreakValue { get; set; }

        public double DefaultValue
        {
            get { return 0d; }
        }
        #endregion

        /// <summary>
        /// 指标信息实体的构造函数。
        /// </summary>
        public TagInfo()
        {}
    }
}
