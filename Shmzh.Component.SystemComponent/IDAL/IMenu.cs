using System.Collections.Generic;
using System.Data;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 菜单的数据访问接口。
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// 添加菜单项。
        /// </summary>
        /// <param name="menuInfo">菜单实体。</param>
        /// <returns>bool</returns>
        bool Insert(MenuInfo menuInfo);
        /// <summary>
        /// 修改菜单项。
        /// </summary>
        /// <param name="menuInfo">菜单实体。</param>
        /// <returns>bool</returns>
        bool Update(MenuInfo menuInfo);
        /// <summary>
        /// 删除菜单项。
        /// </summary>
        /// <param name="menuInfo">菜单项实体。</param>
        /// <returns>bool</returns>
        bool Delete(MenuInfo menuInfo);
        /// <summary>
        /// 删除菜单项。
        /// </summary>
        /// <param name="id">菜单项ID。</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 转移菜单项。
        /// </summary>
        /// <param name="id">菜单项ID。</param>
        /// <param name="newParentId">新的父节点Id。</param>
        /// <returns>bool</returns>
        bool MoveTo(int id, int newParentId);
        /// <summary>
        /// 判断是否存在指定菜单类型的菜单项。
        /// </summary>
        /// <param name="typeId">菜单类型Id。</param>
        /// <returns>bool</returns>
        bool IsExistsByType(int typeId);
        /// <summary>
        /// 获取所有的菜单项。
        /// </summary>
        /// <returns>DataSet</returns>
        DataSet GetAllMenu();
        /// <summary>
        /// 获取所有的菜单。
        /// </summary>
        /// <returns>菜单集合。</returns>
        //IList<MenuInfo> GetAll();
        /// <summary>
        /// 获取所有有效的菜单项。
        /// </summary>
        /// <returns>DataSet</returns>
        DataSet GetAllAvalibleMenu();
        /// <summary>
        /// 获取所有有效的菜单。
        /// </summary>
        /// <returns>菜单集合。</returns>
        //IList<MenuInfo> GetAllAvalible();
        /// <summary>
        /// 根据产品Id获取所有的菜单项。
        /// </summary>
        /// <param name="productId">产品ID。</param>
        /// <returns>DataSet</returns>
        DataSet GetAllMenuByProductId(int productId);
        /// <summary>
        /// 根据产品编号获取所有的菜单。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>菜单集合。</returns>
        //IList<MenuInfo> GetAllByProductCode(int productCode);
        /// <summary>
        /// 根据产品ID获取所有有效的菜单项。
        /// </summary>
        /// <param name="productId">产品Id。</param>
        /// <returns>DataSet</returns>
        DataSet GetAllAvalibleMenuByProductId(int productId);
        /// <summary>
        /// 根据产品编号获取所有的有效的菜单。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>菜单集合。</returns>
        IList<MenuInfo> GetAllAvalibleByProductCode(int productCode);
        /// <summary>
        /// 获取所有的子菜单项。
        /// </summary>
        /// <param name="parentId">上级菜单Id。</param>
        /// <returns>DataSet</returns>
        DataSet GetAllMenuByParentId(int parentId);
        /// <summary>
        /// 根据上级菜单ID获取所有的子菜单项。
        /// </summary>
        /// <param name="parentId">上级菜单Id。</param>
        /// <returns>菜单集合。</returns>
        //IList<MenuInfo> GetAllByParentId(int parentId);
        /// <summary>
        /// 获取所有的有效的子菜单项。
        /// </summary>
        /// <param name="parentId">上级菜单Id。</param>
        /// <returns>DataSet</returns>
        DataSet GetAllAvalibleMenuByParentId(int parentId);
        /// <summary>
        /// 根据上级菜单ID获取所有有效的子菜单项。
        /// </summary>
        /// <param name="parentId">上级菜单Id。</param>
        /// <returns>菜单集合。</returns>
        //IList<MenuInfo> GetAllAvalibleByParentId(int parentId);
        /// <summary>
        /// 根据Id获取菜单项。
        /// </summary>
        /// <param name="id">菜单项ID。</param>
        /// <returns>DataSet</returns>
        DataSet GetMenuById(int id);
        /// <summary>
        /// 根据菜单ID获取菜单。
        /// </summary>
        /// <param name="id">菜单Id。</param>
        /// <returns>菜单实体。</returns>
        //MenuInfo GetById(int id);
    }
}
