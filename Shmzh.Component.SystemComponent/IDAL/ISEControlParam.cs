using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 查询引擎控件类型的数据接口。
    /// </summary>
    public interface ISEControlParam
    {
        /// <summary>
        /// 添加控件参数。
        /// </summary>
        /// <param name="obj">控件参数实体。</param>
        /// <returns>bool</returns>
        bool Insert(SEControlParamInfo obj);
        /// <summary>
        /// 修改控件参数。
        /// </summary>
        /// <param name="obj">控件参数实体。</param>
        /// <returns>bool</returns>
        bool Update(SEControlParamInfo obj);
        /// <summary>
        /// 删除控件参数实体。
        /// </summary>
        /// <param name="obj">控件参数实体。</param>
        /// <returns>bool</returns>
        bool Delete(SEControlParamInfo obj);
        /// <summary>
        /// 删除控件参数实体。
        /// </summary>
        /// <param name="id">控件参数实体id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 获取所有的控件参数。
        /// </summary>
        /// <returns>控件参数集合。</returns>
        IList<SEControlParamInfo> GetByControlId(int controlId);
        /// <summary>
        /// 根据Id获取控件参数。
        /// </summary>
        /// <param name="id">控件参数id。</param>
        /// <returns>控件参数实体。</returns>
        SEControlParamInfo GetById(int id);
        
    }
}