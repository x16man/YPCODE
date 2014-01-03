using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Components.SystemComponent
{
    [Serializable]
    public class TB_SYNInfo
    {

        #region Property

        public string CD { get; set; }

        public DateTime Value { get; set; }

        public string SPEC { get; set; }

        #endregion

        #region CTOR
        public TB_SYNInfo(){ }
        #endregion

        
    }
}
