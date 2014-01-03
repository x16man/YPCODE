using System.Data.Common;
using Shmzh.Components.SystemComponent.Model;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 东兰工作流用户分类数据接口。
    /// </summary>
    public interface ITB_UserCat
    {
        /// <summary>
        /// 添加用户分类。
        /// </summary>
        /// <param name="obj">用户实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Insert(TB_UserCatInfo obj, DbTransaction trans);
        /// <summary>
        /// 修改用户分类。
        /// </summary>
        /// <param name="obj">用户实体。</param>
        /// <param name="trans">事务对象</param>
        /// <returns>bool</returns>
        bool Update(TB_UserCatInfo obj, DbTransaction trans);
        /// <summary>
        /// 删除用户分类实体。
        /// </summary>
         /// <param name="obj">用户分类实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Delete(TB_UserCatInfo obj, DbTransaction trans);
        /// <summary>
        /// 删除用户分类实体。
        /// </summary>
        /// <param name="id">用户分类Id。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Delete(int id, DbTransaction trans);

        /// <summary>
        /// 根据用户分类名称获取用户分类信息。
        /// </summary>
        /// <param name="userCatName">用户分类名称。</param>
        /// <returns>用户分类实体。</returns>
        TB_UserCatInfo GetByUserCatName(string userCatName);
    }
}
