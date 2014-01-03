using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 查询引擎控件的数据接口。
    /// </summary>
    public interface ISEControl
    {
        /// <summary>
        /// 添加控件。
        /// </summary>
        /// <param name="obj">控件实体。</param>
        /// <returns>bool</returns>
        bool Insert(SEControlInfo obj);
        /// <summary>
        /// 修改控件。
        /// </summary>
        /// <param name="obj">控件实体。</param>
        /// <returns>bool</returns>
        bool Update(SEControlInfo obj);
        /// <summary>
        /// 删除控件。
        /// </summary>
        /// <param name="obj">控件实体。</param>
        /// <returns>bool</returns>
        bool Delete(SEControlInfo obj);
        /// <summary>
        /// 删除控件。
        /// </summary>
        /// <param name="id">控件Id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 根据查询模块Id获取所有控件集合。
        /// </summary>
        /// <param name="moduleId">查询模块id。</param>
        /// <returns>控件集合。</returns>
        IList<SEControlInfo> GetAllByModuleId(string moduleId);
        /// <summary>
        /// 根据查询模块Id获取所有有效控件集合。
        /// </summary>
        /// <param name="moduleId">查询模块id。</param>
        /// <returns>控件集合。</returns>
        IList<SEControlInfo> GetAllAvalibleByModuleId(string moduleId);
        /// <summary>
        /// 根据控件Id获取控件。
        /// </summary>
        /// <param name="id">控件id。</param>
        /// <returns>控件实体。</returns>
        SEControlInfo GetById(int id);
    }
}