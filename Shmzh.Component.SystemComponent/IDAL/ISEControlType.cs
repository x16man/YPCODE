using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 查询引擎控件类型的数据接口。
    /// </summary>
    public interface ISEControlType
    {
        /// <summary>
        /// 添加控件类型。
        /// </summary>
        /// <param name="obj">控件类型实体。</param>
        /// <returns>bool</returns>
        bool Insert(SEControlTypeInfo obj);
        /// <summary>
        /// 修改控件类型。
        /// </summary>
        /// <param name="obj">控件类型实体。</param>
        /// <returns>bool</returns>
        bool Update(SEControlTypeInfo obj);
        /// <summary>
        /// 删除控件类型实体。
        /// </summary>
        /// <param name="obj">控件类型实体。</param>
        /// <returns>bool</returns>
        bool Delete(SEControlTypeInfo obj);
        /// <summary>
        /// 删除控件类型实体。
        /// </summary>
        /// <param name="id">控件类型实体id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 获取所有的控件类型。
        /// </summary>
        /// <returns>控件类型集合。</returns>
        IList<SEControlTypeInfo> GetAll();
        /// <summary>
        /// 根据Id获取控件类型。
        /// </summary>
        /// <param name="id">控件类型id。</param>
        /// <returns>控件类型实体。</returns>
        SEControlTypeInfo GetById(int id);
        /// <summary>
        /// 判断id是否已经存在。
        /// </summary>
        /// <param name="id">id。</param>
        /// <returns>bool</returns>
        bool IsExist(int id);
        /// <summary>
        /// 判断名称是否已经存在。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsExist(string name);
    }
}