using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 图表信息实体。
    /// </summary>
    [Serializable]
    public class FloatingBlockItemInfo
    {
        #region Property

        public int BlockItemId { get; set; }

        public int BlockId { get; set; }

        public String Label { get; set; }

        public String Unit { get; set; }

        public String TagExp { get; set; }

        public String DataType { get; set; }

        public int BorderColor { get; set; }

        public float ValueFontSize { get; set; }

        public String ValueFontFamily { get; set; }

        public int ValueForeColor { get; set; }

        public float UnitFontSize { get; set; }

        public String UnitFontFamily { get; set; }

        public int UnitForeColor { get; set; }

        public int SerialNumber { get; set; }

        #endregion

        #region CTOR
        public FloatingBlockItemInfo()
        {
            this.DataType = "Day";

            this.Label = "";
            this.Unit = "";
            this.UnitFontFamily = "宋体";
            this.UnitFontSize = 12F;

            this.ValueFontSize = 12F;
            this.ValueFontFamily = "宋体";           
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
