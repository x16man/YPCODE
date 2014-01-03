using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 查询引擎的控件的数据类型数据接口。
    /// </summary>
    public interface ISEDataType
    {
        /// <summary>
        /// 添加数据类型。
        /// </summary>
        /// <param name="obj">数据类型实体。</param>
        /// <returns>bool</returns>
        bool Insert(SEDataTypeInfo obj);
        /// <summary>
        /// 修改数据类型。
        /// </summary>
        /// <param name="obj">数据类型实体。</param>
        /// <returns>bool</returns>
        bool Update(SEDataTypeInfo obj);
        /// <summary>
        /// 删除数据类型。
        /// </summary>
        /// <param name="obj">数据类型实体。</param>
        /// <returns>bool</returns>
        bool Delete(SEDataTypeInfo obj);
        /// <summary>
        /// 删除数据类型。
        /// </summary>
        /// <param name="id">数据类型Id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 获取所有数据类型集合。
        /// </summary>
        /// <returns>数据类型集合。</returns>
        IList<SEDataTypeInfo> GetAll();
        /// <summary>
        /// 根据id获取数据类型。
        /// </summary>
        /// <param name="id">数据类型Id</param>
        /// <returns>数据类型实体。</returns>
        SEDataTypeInfo GetById(int id);
        /// <summary>
        /// 判断ID是否已经存在。
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        bool IsExist(int id);
        /// <summary>
        /// 判断名称是否已经存在。
        /// </summary>
        /// <param name="name">名称。</param>
        /// <returns>bool</returns>
        bool IsExist(string name);
    }
}