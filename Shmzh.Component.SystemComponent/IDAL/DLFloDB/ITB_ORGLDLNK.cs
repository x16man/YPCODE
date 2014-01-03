using System.Collections.Generic;
using Shmzh.Components.SystemComponent.Model;

namespace Shmzh.Components.SystemComponent.IDAL
{
    public interface ITB_ORGLDLNK
    {
        /// <summary>
        /// 根据领导类型Id获取部门领导记录集合。
        /// </summary>
        /// <param name="leadTypeId">领导类型Id。</param>
        /// <returns>部门领导记录集合。</returns>
        List<TB_ORGLDLNKInfo> GetByLeadTypeId(int leadTypeId);
    }
}