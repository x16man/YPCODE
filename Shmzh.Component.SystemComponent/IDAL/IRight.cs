using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 权限分组的数据访问接口。
    /// </summary>
    public interface IRight
    {
        /// <summary>
        /// 添加权限。
        /// </summary>
        /// <param name="rightInfo">权限实体。</param>
        /// <returns>bool</returns>
        bool Insert(RightInfo rightInfo);
        /// <summary>
        /// 修改权限。
        /// </summary>
        /// <param name="rightInfo">权限实体。</param>
        /// <returns>bool</returns>
        bool Update(RightInfo rightInfo);
        /// <summary>
        /// 删除权限。
        /// </summary>
        /// <param name="rightInfo">权限实体。</param>
        /// <returns>bool</returns>
        bool Delete(RightInfo rightInfo);
        /// <summary>
        /// 删除权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>bool</returns>
        bool Delete(short rightCode);
        /// <summary>
        /// 判断是否已经存在权限编号。
        /// </summary>
        /// <param name="rightCode">权限编号</param>
        /// <returns></returns>
        bool IsExist(short rightCode);
        /// <summary>
        /// 判断权限码是否已被使用。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <returns></returns>
        bool IsUsing(short rightCode);
        /// <summary>
        /// 获取所有权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限集合。</returns>
        IList<RightInfo> GetAllByProductCode(short productCode);
        /// <summary>
        /// 获取所有有效的权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限集合。</returns>
        IList<RightInfo> GetAllAvalibleByProductCode(short productCode);
        /// <summary>
        /// 根据权限分类获取所有权限集合。
        /// </summary>
        /// <param name="rightCatCode">权限分类编号。</param>
        /// <returns>权限集合。</returns>
        IList<RightInfo> GetAllByRightCatCode(string rightCatCode);
        /// <summary>
        /// 根据权限分类获取所有有效的权限集合。
        /// </summary>
        /// <param name="rightCatCode">权限分类编号。</param>
        /// <returns>权限集合。</returns>
        IList<RightInfo> GetAllAvalibleByRightCatCode(string rightCatCode);
        /// <summary>
        /// 根据产品编号获取所有没有设置权限分类的权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限集合。</returns>
        IList<RightInfo> GetAllOtherByProductCode(short productCode);
        /// <summary>
        /// 根据产品编号获取所有有效的没有设置权限分类的权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限集合。</returns>
        IList<RightInfo> GetAllAvalibleOtherByProductCode(short productCode);
        /// <summary>
        /// 根据组编号获取权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>权限实体。</returns>
        RightInfo GetByCode(short rightCode);
        

    }
}
