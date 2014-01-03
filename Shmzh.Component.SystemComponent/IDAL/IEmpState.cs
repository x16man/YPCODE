using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 员工状态的数据访问接口。
    /// </summary>
    public interface IEmpState
    {
        /// <summary>
        /// 添加员工状态。
        /// </summary>
        /// <param name="empStateInfo">员工状态实体。</param>
        /// <returns>bool</returns>
        bool Insert(EmpStateInfo empStateInfo);
        /// <summary>
        /// 修改员工状态。
        /// </summary>
        /// <param name="empStateInfo">员工状态实体。</param>
        /// <returns>bool</returns>
        bool Update(EmpStateInfo empStateInfo);
        /// <summary>
        /// 删除员工状态。
        /// </summary>
        /// <param name="empStateInfo">员工状态实体。</param>
        /// <returns>bool</returns>
        bool Delete(EmpStateInfo empStateInfo);
        /// <summary>
        /// 删除员工状态。
        /// </summary>
        /// <param name="code">员工状态代码。</param>
        /// <returns>bool</returns>
        bool Delete(string code);
        /// <summary>
        /// 是否已经存在员工状态编号。
        /// </summary>
        /// <param name="code">员工状态代码。</param>
        /// <returns>bool</returns>
        bool IsExistCode(string code);
        /// <summary>
        /// 是否已经存在员工状态名称
        /// </summary>
        /// <param name="description">员工状态名称。</param>
        /// <returns>bool</returns>
        bool IsExistDescription(string description);
        /// <summary>
        /// 获取所有员工状态。
        /// </summary>
        /// <returns>ArrayList。</returns>
        IList<EmpStateInfo> GetAll();
        /// <summary>
        /// 获取所有有效的员工状态。
        /// </summary>
        /// <returns>员工状态集合。</returns>
        IList<EmpStateInfo> GetAllAvalible();
        /// <summary>
        /// 根据员工状态编号获取员工状态。
        /// </summary>
        /// <param name="code">员工状态代码。</param>
        /// <returns>员工状态实体。</returns>
        EmpStateInfo GetByCode(string code);
        

    }
}
