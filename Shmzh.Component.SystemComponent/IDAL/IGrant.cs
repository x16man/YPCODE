using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 组的数据访问接口。
    /// </summary>
    public interface IGrant
    {
        /// <summary>
        /// 添加授权记录。
        /// </summary>
        /// <param name="grantInfo">授权记录实体。</param>
        /// <returns>bool</returns>
        bool Insert(GrantInfo grantInfo);
        /// <summary>
        /// 修改授权记录。
        /// </summary>
        /// <param name="grantInfo">授权记录实体。</param>
        /// <returns>bool</returns>
        bool Update(GrantInfo grantInfo);
        /// <summary>
        /// 删除授权记录。
        /// </summary>
        /// <param name="grantInfo">授权记录实体。</param>
        /// <returns>bool</returns>
        bool Delete(GrantInfo grantInfo);
        /// <summary>
        /// 删除授权记录。
        /// </summary>
        /// <param name="id">授权记录PKID。</param>
        /// <returns>bool</returns>
        bool Delete(long id);
        
        /// <summary>
        /// 根据授权人获取当前有效的授权记录。
        /// </summary>
        /// <param name="grantor">授权人用户名。</param>
        /// <returns>授权记录集合。</returns>
        IList<GrantInfo> GetAllAvalibleByGrantor(string grantor);
        /// <summary>
        /// 根据被授权人获取当前有效的授权记录。
        /// </summary>
        /// <param name="Embracer">被授权人用户名。</param>
        /// <returns>授权记录集合。</returns>
        IList<GrantInfo> GetAllAvalibleByEmbracer(string Embracer);
        /// <summary>
        /// 根据Id获取授权记录实体。
        /// </summary>
        /// <param name="id">授权记录Id。</param>
        /// <returns>授权记录实体。</returns>
        GrantInfo GetById(long id);
        

    }
}
