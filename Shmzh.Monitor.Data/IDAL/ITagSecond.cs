using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.Data.IDAL
{
    public interface ITagSecond
    {
        /// <summary>
        /// 根据Id获取最新的秒表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>秒数据实体。</returns>
        TagSecondInfo Get_Latest_By_TagId(string tagId);

        /// <summary>
        /// 根据指标Id串来获取最新的秒表数据。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>秒数据集合。一个指标对应一条记录。</returns>
        List<TagSecondInfo> Get_Latest_By_TagIds(string tagIds);

        /// <summary>
        /// 获取所有指标的最新秒数据。
        /// </summary>
        /// <returns>秒数据集合。一个指标对应一条记录。</returns>
        List<TagSecondInfo> Get_Latest_All();
    }
}
