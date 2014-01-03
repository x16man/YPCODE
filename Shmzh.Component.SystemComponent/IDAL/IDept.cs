using System.Collections.Generic;
using System.Data.Common;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 部门的数据访问接口。
    /// </summary>
    public interface IDept
    {
        /// <summary>
        /// 添加部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        bool Insert(DeptInfo deptInfo);

        /// <summary>
        /// 添加部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Insert(DeptInfo deptInfo, DbTransaction trans);

        /// <summary>
        /// 修改部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        bool Update(DeptInfo deptInfo);
        /// <summary>
        /// 修改部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool。</returns>
        bool Update(DeptInfo deptInfo, DbTransaction trans);
        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        bool Delete(DeptInfo deptInfo);

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对虾昂。</param>
        /// <returns>bool。</returns>
        bool Delete(DeptInfo deptInfo, DbTransaction trans);
        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        bool Delete(string companyCode, string deptCode);
        /// <summary>
        /// 部门失效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        bool Disable(string companyCode, string deptCode);

        /// <summary>
        /// 部门失效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Disable(string companyCode, string deptCode, DbTransaction trans);
        /// <summary>
        /// 部门有效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        bool Enable(string companyCode, string deptCode);
        /// <summary>
        /// 部门起效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门代码。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        bool Enable(string companyCode, string deptCode, DbTransaction trans);
        /// <summary>
        /// 是否已经存在部门编号。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        bool IsExistDeptCode(string companyCode, string deptCode);
        /// <summary>
        /// 是否已经存在部门名称
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptName">部门名称。</param>
        /// <returns>bool</returns>
        bool IsExistDeptName(string companyCode, string deptName);
        /// <summary>
        /// 判断是否有子部门。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        bool HasChildDept(string companyCode, string deptCode);
        /// <summary>
        /// 判断是否有用户。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        bool HasUser(string companyCode, string deptCode);
        /// <summary>
        /// 获取所有部门。
        /// </summary>
        /// <returns>部门集合。</returns>
        IList<DeptInfo> GetAllByCompanyCode(string companyCode);
        /// <summary>
        /// 获取所有有效的部门。
        /// </summary>
        /// <returns>部门集合。</returns>
        IList<DeptInfo> GetAllAvalibleCompanyCode(string companyCode);
        /// <summary>
        /// 根据公司编号和部门主管获取部门列表。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="manager">部门主管。</param>
        /// <returns>部门列表。</returns>
        IList<DeptInfo> GetByCompanyAndManager(string companyCode, string manager);
        /// <summary>
        /// 根据部门编号获取部门。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门实体。</returns>
        DeptInfo GetByCompanyCodeAndDeptCode(string companyCode, string deptCode);
        /// <summary>
        /// 根据部门编号获取上级部门。
        /// </summary>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门实体。</returns>
        DeptInfo GetParentDeptByCode(string deptCode);
        

    }
}
