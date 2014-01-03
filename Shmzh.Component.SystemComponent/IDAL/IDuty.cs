using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 职务的数据访问接口。
    /// </summary>
    public interface IDuty
    {
        /// <summary>
        /// 添加职务。
        /// </summary>
        /// <param name="dutyInfo">职务实体。</param>
        /// <returns>bool</returns>
        bool Insert(DutyInfo dutyInfo);
        /// <summary>
        /// 修改职务。
        /// </summary>
        /// <param name="dutyInfo">职务实体。</param>
        /// <returns>bool</returns>
        bool Update(DutyInfo dutyInfo);
        /// <summary>
        /// 删除职务。
        /// </summary>
        /// <param name="dutyInfo">职务实体。</param>
        /// <returns>bool</returns>
        bool Delete(DutyInfo dutyInfo);
        /// <summary>
        /// 删除职务。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="dutyCode">职务编号。</param>
        /// <returns>bool</returns>
        bool Delete(string companyCode, string dutyCode);
        /// <summary>
        /// 是否已经存在职务编号。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="dutyCode">职务编号。</param>
        /// <returns>bool</returns>
        bool IsExistDutyCode(string companyCode, string dutyCode);
        /// <summary>
        /// 是否已经存在职务名称
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="dutyName">职务名称。</param>
        /// <returns>bool</returns>
        bool IsExistDutyName(string companyCode, string dutyName);
        /// <summary>
        /// 获取所有职务。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>ArrayList。</returns>
        IList<DutyInfo> GetAllByCompanyCode(string companyCode);
        /// <summary>
        /// 获取所有有效的职务。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>职务集合。</returns>
        IList<DutyInfo> GetAllAvalibleByCompanyCode(string companyCode);
        /// <summary>
        /// 根据职务编号获取职务。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="dutyCode">职务编号。</param>
        /// <returns>职务实体。</returns>
        DutyInfo GetByCompanyCodeAndDutyCode(string companyCode, string dutyCode);
        

    }
}
