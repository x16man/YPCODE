using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.MM.Common
{
    /// <summary>
    /// 状态表实体类。
    /// </summary>
    public class ESTUInfo
    {
        #region Property
        /// <summary>
        /// 状态代码。
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 状态名称。
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 状态描述。
        /// </summary>
        public string Remark { get; set; }
        #endregion

        #region CTOR
        public ESTUInfo()
        {
        }
        #endregion
    }
}
