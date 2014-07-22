using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Gadget
{
    public class TagImageInfo : ImageInfo
    {
        private Double _value = 0.0;

        public TagImageInfo()
        {
            
        }

        /// <summary>
        /// 数据类型。可选值：Second/Min/Min15/Hour/Day/Month/Year.
        /// </summary>
        public String DataType { get; set; }
        public String TagId { get; set; }
        /// <summary>
        /// 指标对应值。
        /// </summary>
        public Double Value
        {
            get { return _value; }
            set
            {
                if(_value == value) return;
                _value = value;
                OnValueChanged();
            }
        }

        public String BorderColorExp { private get; set; }
        public String SrcExp { private get; set; }
       
        protected override void OnValueChanged()
        {
            Src = Utils.IsExp(SrcExp) ? Utils.CalcExpString(SrcExp, Value) : SrcExp;

            if (Utils.IsExp(BorderColorExp))
            {
                BorderColor = StringUtil.StringToColor(Utils.CalcExpString(BorderColorExp, Value), Color.Black);
            }
            else
            {
                BorderColor = StringUtil.StringToColor(BorderColorExp, Color.Transparent);
            }
        }
    }
}
