using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 部门类型的数据访问接口。
    /// </summary>
    public interface IOrgType
    {
        /// <summary>
        /// 添加部门类型。
        /// </summary>
        /// <param name="orgTypeInfo">部门类型实体。</param>
        /// <returns>bool</returns>
        bool Insert(OrgTypeInfo orgTypeInfo);
        /// <summary>
        /// 添加部门类型。
        /// </summary>
        /// <param name="orgTypeInfo">部门类型实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Insert(OrgTypeInfo orgTypeInfo, DbTransaction trans);
        /// <summary>
        /// 修改部门类型。
        /// </summary>
        /// <param name="orgTypeInfo">部门类型实体。</param>
        /// <returns>bool</returns>
        bool Update(OrgTypeInfo orgTypeInfo);
        /// <summary>
        /// 修改部门类型。
        /// </summary>
        /// <param name="orgTypeInfo">部门类型实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Update(OrgTypeInfo orgTypeInfo, DbTransaction trans);
        
        /// <summary>
        /// 删除部门类型。
        /// </summary>
        /// <param name="orgTypeInfo">部门类型实体。</param>
        /// <returns>bool</returns>
        bool Delete(OrgTypeInfo orgTypeInfo);
        /// <summary>
        /// 删除部门类型。
        /// </summary>
        /// <param name="orgTypeInfo">部门类型实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Delete(OrgTypeInfo orgTypeInfo,DbTransaction trans);
        /// <summary>
        /// 删除部门类型。
        /// </summary>
        /// <param name="code">代码。</param>
        /// <returns>bool</returns>
        bool Delete(string code);
        /// <summary>
        /// 删除部门类型。
        /// </summary>
        /// <param name="code">代码。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Delete(string code,DbTransaction trans);
        /// <summary>
        /// 是否已经存在部门类型编号。
        /// </summary>
        /// <param name="code">部门类型编号。</param>
        /// <returns>bool</returns>
        bool IsExistCode(string code);

        /// <summary>
        /// 是否已经存在部门类型名称
        /// </summary>
        /// <param name="name">部门类型名称。</param>
        /// <returns>bool</returns>
        bool IsExistName(string name);
        /// <summary>
        /// 是否已经被使用。
        /// </summary>
        /// <param name="code">部门类型编号。</param>
        /// <returns>bool</returns>
        bool IsUsed(string code);
        /// <summary>
        /// 获取所有部门类型。
        /// </summary>
        /// <returns>部门类型集合。</returns>
        IList<OrgTypeInfo> GetAll();

        /// <summary>
        /// 获取所有有效的部门类型。
        /// </summary>
        /// <returns>部门类型集合。</returns>
        IList<OrgTypeInfo> GetAllAvalible();

        /// <summary>
        /// 根据部门类型编号获取部门类型。
        /// </summary>
        /// <param name="code">部门类型编号。</param>
        /// <returns>部门类型实体。</returns>
        OrgTypeInfo GetByCode(string code);
        

    }
}
