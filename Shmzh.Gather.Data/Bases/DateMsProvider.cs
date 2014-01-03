using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Gather.Data.IDAL;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    /// <summary>
    /// 时间特征的抽象数据访问对象。
    /// </summary>
    public abstract class DateMsProvider :IDateMs
    {
        #region Implementation of IDateMs

        /// <summary>
        /// 添加时间特征。
        /// </summary>
        /// <param name="obj">时间特征实体。</param>
        /// <returns>bool</returns>
        public abstract bool Insert(DateMsInfo obj);

        /// <summary>
        /// 更改时间特征。
        /// </summary>
        /// <param name="obj">时间特征实体。</param>
        /// <returns>bool</returns>
        public abstract bool Update(DateMsInfo obj);

        /// <summary>
        /// 根据Id删除时间特征。
        /// </summary>
        /// <param name="id">时间特征Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(string id);

        /// <summary>
        /// 删除时间特征。
        /// </summary>
        /// <param name="obj">时间特征。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(DateMsInfo obj);

        /// <summary>
        /// 获取所有的时间特征。
        /// </summary>
        /// <returns>时间特征集合</returns>
        public abstract List<DateMsInfo> GetAll();

        /// <summary>
        /// 根据Id获取时间特征。
        /// </summary>
        /// <param name="id">时间特征Id。</param>
        /// <returns>时间特征</returns>
        public abstract DateMsInfo GetById(string id);

        #endregion
    }
}
