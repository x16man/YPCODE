using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 菜单类型的数据访问接口。
    /// </summary>
    public interface IMenuType
    {
        /// <summary>
        /// 添加菜单类型。
        /// </summary>
        /// <param name="menuTypeInfo">菜单类型实体。</param>
        /// <returns>bool</returns>
        bool Insert(MenuTypeInfo menuTypeInfo);
        /// <summary>
        /// 修改菜单类型。
        /// </summary>
        /// <param name="menuTypeInfo">菜单类型实体。</param>
        /// <returns>bool</returns>
        bool Update(MenuTypeInfo menuTypeInfo);
        /// <summary>
        /// 删除菜单类型。
        /// </summary>
        /// <param name="menuTypeInfo">菜单类型实体。</param>
        /// <returns>bool</returns>
        bool Delete(MenuTypeInfo menuTypeInfo);
        /// <summary>
        /// 删除菜单类型。
        /// </summary>
        /// <param name="id">菜单类型编号。</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 判断ID是否已经存在。
        /// </summary>
        /// <param name="id">菜单类型Id。</param>
        /// <returns>bool</returns>
        bool IsExist(int id);
        /// <summary>
        /// 是否已经存在菜单类型名称。
        /// </summary>
        /// <param name="name">菜单类型名称。</param>
        /// <returns>bool</returns>
        bool IsExist(string name);
        /// <summary>
        /// 获取所有菜单类型。
        /// </summary>
        /// <returns>菜单类型集合。</returns>
        IList<MenuTypeInfo> GetAll();
        /// <summary>
        /// 获取所有框架所使用的菜单类型。
        /// </summary>
        /// <returns>菜单类型集合。</returns>
        IList<MenuTypeInfo> GetALLUsedByFrameWork();
        /// <summary>
        /// 根据菜单类型编号获取菜单类型。
        /// </summary>
        /// <param name="id">菜单类型Id。</param>
        /// <returns>菜单类型</returns>
        MenuTypeInfo GetById(int id);
        

    }
}
