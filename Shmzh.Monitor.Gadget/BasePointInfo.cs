using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Gadget
{
    /// <summary>
    /// 基准点对象。
    /// </summary>
    /// <remarks>
    /// 用于其他对象作为一个参考点，方便移动位置。
    /// </remarks>
    public class BasePointInfo:BaseInfo
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Boolean isInitialized = false;
        #endregion

        #region Property
        /// <summary>
        /// 基准点的名称，以便其他对象进行引用。
        /// </summary>
        public string Name { get; set; }
        #endregion
    }
}
