using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    public interface ITag
    {
        /// <summary>
        /// 根据指标Id获取指标信息实体。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>指标信息实体。</returns>
        TagInfo GetByTagId(string tagId);

        /// <summary>
        /// 获取所有的指标信息实体集合。
        /// </summary>
        /// <returns>指标信息实体集合</returns>
        IList<TagInfo> GetAll();

        /// <summary>
        /// 根据指标采集类型来获取指标实体集合。
        /// </summary>
        /// <param name="action">采集类型。</param>
        /// <returns>指标集合。</returns>
        IList<TagInfo> GetByAction(short action);
    }
}
