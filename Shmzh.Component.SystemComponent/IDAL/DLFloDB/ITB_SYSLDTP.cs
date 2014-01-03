using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Components.SystemComponent.IDAL
{
    public interface ITB_SYSLDTP
    {
        /// <summary>
        /// 获取所有的领导类型记录。
        /// </summary>
        /// <returns>领导类型记录集合。</returns>
        List<TB_SYSLDTPInfo> GetAll();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<TB_SYSLDTPInfo> GetAllAvalible();
    }
}
