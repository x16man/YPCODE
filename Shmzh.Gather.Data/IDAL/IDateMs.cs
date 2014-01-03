using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    /// <summary>
    /// 时间特征的数据访问接口。
    /// </summary>
    public interface IDateMs
    {
        /// <summary>
        /// 添加时间特征。
        /// </summary>
        /// <param name="obj">时间特征实体。</param>
        /// <returns>bool</returns>
        bool Insert(DateMsInfo obj);

        /// <summary>
        /// 更改时间特征。
        /// </summary>
        /// <param name="obj">时间特征实体。</param>
        /// <returns>bool</returns>
        bool Update(DateMsInfo obj);

        /// <summary>
        /// 根据Id删除时间特征。
        /// </summary>
        /// <param name="id">时间特征Id。</param>
        /// <returns>bool</returns>
        bool Delete(string id);

        /// <summary>
        /// 删除时间特征。
        /// </summary>
        /// <param name="obj">时间特征。</param>
        /// <returns>bool</returns>
        bool Delete(DateMsInfo obj);
        
        /// <summary>
        /// 获取所有的时间特征。
        /// </summary>
        /// <returns>时间特征集合</returns>
        List<DateMsInfo> GetAll();

        /// <summary>
        /// 根据Id获取时间特征。
        /// </summary>
        /// <param name="id">时间特征Id。</param>
        /// <returns>时间特征</returns>
        DateMsInfo GetById(string id);
        
    }
}
