using System.Data.Common;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 组与用户关系的数据访问接口。
    /// </summary>
    public interface IGroupUser
    {
        /// <summary>
        /// 添加组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户。</param>
        /// <returns>bool</returns>
        bool Insert(GroupUserInfo groupUserInfo);
        /// <summary>
        /// 添加组用户。
        /// </summary>
        /// <param name="obj">组用户实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Insert(GroupUserInfo obj, DbTransaction trans);
        /// <summary>
        /// 批量添加组用户。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <returns>bool</returns>
        bool Insert(short groupCode, string userNames);
        
        /// <summary>
        /// 删除组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户。</param>
        /// <returns>bool</returns>
        bool Delete(GroupUserInfo groupUserInfo);

        /// <summary>
        /// 删除组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Delete(GroupUserInfo groupUserInfo, DbTransaction trans);

        /// <summary>
        ///  根据指定的用户名来删除组和用户的关系记录。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <returns>bool</returns>
        bool Delete(string userCode);

        /// <summary>
        /// 根据指定的用户名来删除组和用户的关系记录。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Delete(string userCode, DbTransaction trans);

        /// <summary>
        /// 获取所有的组用户集合.
        /// </summary>
        /// <returns>组用户集合.</returns>
        IList<GroupUserInfo> GetAll();

        /// <summary>
        /// 根据组编号来获取组用户集合。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组用户集合。</returns>
        IList<GroupUserInfo> GetByGroupCode(short groupCode);

        /// <summary>
        /// 根据用户名获取组用户集合。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <returns>组用户集合。</returns>
        IList<GroupUserInfo> GetByUserCode(string userCode);
    }
}
