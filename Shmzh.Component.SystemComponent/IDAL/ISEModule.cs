using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 查询模块的数据访问接口。
    /// </summary>
    public interface ISEModule
    {
        /// <summary>
        /// 添加查询模块。
        /// </summary>
        /// <param name="moduleInfo">查询模块实体。</param>
        /// <returns>bool</returns>
        bool Insert(SEModuleInfo moduleInfo);
        /// <summary>
        /// 修改查询模块。
        /// </summary>
        /// <param name="moduleInfo">查询模块实体。</param>
        /// <returns>bool</returns>
        bool Update(SEModuleInfo moduleInfo);
        /// <summary>
        /// 删除查询模块。
        /// </summary>
        /// <param name="moduleInfo">查询模块实体。</param>
        /// <returns>bool</returns>
        bool Delete(SEModuleInfo moduleInfo);
        /// <summary>
        /// 删除查询模块。
        /// </summary>
        /// <param name="id">查询模块id。</param>
        /// <returns>bool</returns>
        bool Delete(string id);
        /// <summary>
        /// 是否已经存在查询模块名称。
        /// </summary>
        /// <param name="id">查询模块名称。</param>
        /// <returns>bool</returns>
        bool IsExist(string id);
        /// <summary>
        /// 获取所有查询模块。
        /// </summary>
        /// <returns>查询模块集合。</returns>
        IList<SEModuleInfo> GetAll();
        /// <summary>
        /// 根据产品获取查询模块集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>查询模块集合。</returns>
        IList<SEModuleInfo> GetByProduct(short productCode);
        /// <summary>
        /// 根据查询模块id获取查询模块。
        /// </summary>
        /// <param name="id">查询模块id。</param>
        /// <returns>查询模块。</returns>
        SEModuleInfo GetById(string id);
        

    }
}
