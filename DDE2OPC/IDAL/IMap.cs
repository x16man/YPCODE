using System;
using System.Collections.Generic;
using System.Text;
using DDE2OPC.Model;

namespace DDE2OPC.IDAL
{
    /// <summary>
    /// DDE与OPC的映射关系的数据访问接口。
    /// </summary>
    public interface IMap
    {
        /// <summary>
        /// 添加DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="obj">DDE与OPC的映射关系实体。</param>
        /// <returns>bool</returns>
        bool Insert(MapInfo obj);
        /// <summary>
        /// 更改DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="obj">DDE与OPC的映射关系实体。</param>
        /// <returns>bool</returns>
        bool Update(MapInfo obj);
        /// <summary>
        /// 删除DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="obj">DDE与OPC的映射关系实体。</param>
        /// <returns>bool</returns>
        bool Delete(MapInfo obj);
        /// <summary>
        /// 删除DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="id">DDE与OPC的映射关系实体Id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 获取所有DDE与OPC的映射关系实体。
        /// </summary>
        /// <returns>DDE与OPC的映射关系实体集合。</returns>
        IList<MapInfo> GetAll();
        /// <summary>
        /// 根据Id获取DDE与OPC的映射关系实体。
        /// </summary>
        /// <param name="id">DDE与OPC的映射关系实体Id。</param>
        /// <returns>DDE与OPC的映射关系实体。</returns>
        MapInfo GetById(int id);
    }
}
