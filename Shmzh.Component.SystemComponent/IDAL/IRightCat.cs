using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 权限分组的数据访问接口。
    /// </summary>
    public interface IRightCat
    {
        /// <summary>
        /// 添加权限分组。
        /// </summary>
        /// <param name="rightCatInfo">权限分组实体。</param>
        /// <returns>bool</returns>
        bool Insert(RightCatInfo rightCatInfo);
        /// <summary>
        /// 修改权限分组。
        /// </summary>
        /// <param name="rightCatInfo">权限分组实体。</param>
        /// <returns>bool</returns>
        bool Update(RightCatInfo rightCatInfo);
        /// <summary>
        /// 删除权限分组。
        /// </summary>
        /// <param name="rightCatInfo">权限分组实体。</param>
        /// <returns>bool</returns>
        bool Delete(RightCatInfo rightCatInfo);
        /// <summary>
        /// 删除权限分组。
        /// </summary>
        /// <param name="code">权限分组编号。</param>
        /// <returns>bool</returns>
        bool Delete(string code);
        /// <summary>
        /// 判断是否已经存在权限分组编号。
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool IsExist(string code);
        /// <summary>
        /// 判断在同一个产品下是否已经存在权限分组名称。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">权限分组名称。</param>
        /// <returns>bool</returns>
        bool IsExist(short productCode,string name);
        /// <summary>
        /// 是否有子分类。
        /// </summary>
        /// <param name="code">权限分类编号。</param>
        /// <returns>bool</returns>
        bool HasChildren(string code);
        /// <summary>
        /// 获取所有权限分组。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限分组集合。</returns>
        IList<RightCatInfo> GetAllByProductCode(short productCode);
        /// <summary>
        /// 获取所有有效的权限分组。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限分组集合。</returns>
        IList<RightCatInfo> GetAllAvalibleByProductCode(short productCode);
        /// <summary>
        /// 根据组编号获取权限分组。
        /// </summary>
        /// <param name="code">权限分组编号。</param>
        /// <returns>权限分组集合。</returns>
        RightCatInfo GetByCode(string code);
        

    }
}
