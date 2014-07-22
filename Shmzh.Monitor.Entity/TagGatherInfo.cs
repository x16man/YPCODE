using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Entity
{
    [Serializable]
    public class TagGatherInfo
    {
        #region Property

        public String I_TAG_ID { get; set; }
        public String I_DESIGN_CD { get; set; }
        public String I_ADDRESS { get; set; }
        public double I_PARA_A { get; set; }
        public double I_PARA_B { get; set; }
        public double I_PARA_C { get; set; }
        public double I_MAX { get; set; }
        public double I_MIN { get; set; }
        public Int16 I_ACTION { get; set; }

        #endregion

        #region CTOR
        public TagGatherInfo()
        {
        }
        #endregion

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
                @"{9}:
- I_TAG_ID: {0}
- I_DESIGN_CD: {1}
- I_ADDRESS: {2}
- I_PARA_A: {3}
- I_PARA_B:{4}
- I_PARA_C:{5}
- I_MAX:{6}
- I_MIN:{7}
- I_ACTION:{8}
",
                this.I_TAG_ID,
                this.I_DESIGN_CD,
                this.I_ADDRESS,
                this.I_PARA_A,
                this.I_PARA_B,
                this.I_PARA_C,
                this.I_MAX,
                this.I_MIN,
                this.I_ACTION,                
                this.GetType());
        }
    }
}
