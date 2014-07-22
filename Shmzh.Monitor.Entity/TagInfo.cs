using System;
using System.ComponentModel;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 指标信息实体。
    /// </summary>
    [Serializable]
    public class TagInfo
    {
        #region Property
        /// <summary>
        /// 指标Id。
        /// </summary>
        [Bindable(true)]
        public string I_Tag_Id { get; set; }
        /// <summary>
        /// 指标名称。
        /// </summary>
        [Bindable(true)]
        public string I_Tag_Name { get; set; }
        /// <summary>
        /// 小时点保留位数。
        /// </summary>
        [Bindable(true)]
        public int I_Dig_Num { get; set; }
        /// <summary>
        /// 单位。
        /// </summary>
        [Bindable(true)]
        public string I_Unit { get; set; }
        /// <summary>
        /// 指标类型。
        /// </summary>
        [Bindable(true)]
        public string I_Tag_Type { get; set; }
        /// <summary>
        /// 小时前指标计算类型。
        /// </summary>
        [Bindable(true)]
        public int Calc_Type_Before_Hour { get; set; }
        /// <summary>
        /// 小时候指标计算类型。
        /// </summary>
        [Bindable(true)]
        public int Calc_Type_After_Hour { get; set; }
        /// <summary>
        /// 是否需要秒到分钟转换。
        /// </summary>
        [Bindable(true)]
        public bool Second_To_Minute { get; set; }
        /// <summary>
        /// 是否需要分钟转换到15分钟（原来是5分钟）。
        /// </summary>
        [Bindable(true)]
        public bool Minute_To_Min5 { get; set; }
        /// <summary>
        /// 是否需要分钟转换到小时。
        /// </summary>
        [Bindable(true)]
        public bool Minute_To_Hour { get; set; }
        /// <summary>
        /// 是否需要小时转换到天。
        /// </summary>
        [Bindable(true)]
        public bool Hour_To_Day { get; set; }
        /// <summary>
        /// 是否需要天转换到月。
        /// </summary>
        [Bindable(true)]
        public bool Day_To_Month { get; set; }
        /// <summary>
        /// 是否需要月转换到年。
        /// </summary>
        [Bindable(true)]
        public bool Month_To_Year { get; set; }
        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(true)]
        public string Remark { get; set; }
        /// <summary>
        /// 合成指标的计算公式。
        /// </summary>
        [Bindable(true)]
        public string Func { get; set; }
        /// <summary>
        /// 设备编号。
        /// </summary>
        [Bindable(true)]
        public string Dev_Code { get; set; }
        /// <summary>
        /// 最大值。
        /// </summary>
        [Bindable(true)]
        public double Max_Value { get; set; }
        /// <summary>
        /// 最小值。
        /// </summary>
        [Bindable(true)]
        public double Min_Value { get; set; }
        #endregion

        #region CTOR
        public TagInfo()
        {
        }
        #endregion

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                @"{18}:
- I_Tag_Id: {0}
- I_Tag_Name: {1}
- I_Dig_Num: {2}
- I_Unit: {3}
- I_Tag_Type:{4}
- Calc_Type_Before_Hour:{5}
- Calc_Type_After_Hour:{6}
- Second_To_Minute:{7}
- Minute_To_Min5:{8}
- Minute_To_Hour:{9}
- Hour_To_Day:{10}
- Day_To_Month:{11}
- Month_To_Year:{12}
- Remark: {13}
- Func: {14}
- Deve_Code: {15}
- Max_Value: {16}
- Min_Value: {17}
",
                this.I_Tag_Id,
                this.I_Tag_Name,
                this.I_Dig_Num,
                this.I_Unit,
                this.I_Tag_Type,
                this.Calc_Type_Before_Hour,
                this.Calc_Type_After_Hour,
                this.Second_To_Minute,
                this.Minute_To_Min5,
                this.Minute_To_Hour,
                this.Hour_To_Day,
                this.Day_To_Month,
                this.Month_To_Year,
                this.Remark ?? string.Empty,
                this.Func?? string .Empty,
                this.Dev_Code?? string.Empty,
                this.Max_Value,
                this.Min_Value,
                this.GetType());
        }
    }

}
