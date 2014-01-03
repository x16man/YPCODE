using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 组的数据访问接口。
    /// </summary>
    public interface ICompany
    {
        /// <summary>
        /// 添加公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        bool Insert(CompanyInfo companyInfo);
        /// <summary>
        /// 修改公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        bool Update(CompanyInfo companyInfo);
        /// <summary>
        /// 删除公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        bool Delete(CompanyInfo companyInfo);
        /// <summary>
        /// 删除公司。
        /// </summary>
        /// <param name="coCode">公司编号。</param>
        /// <returns>bool</returns>
        bool Delete(string coCode);
        /// <summary>
        /// 判断公司编号是否已经存在。
        /// </summary>
        /// <param name="coCode">公司编号。</param>
        /// <returns>bool</returns>
        bool IsExistCode(string coCode);
        /// <summary>
        /// 是否已经存在组名称。
        /// </summary>
        /// <param name="coCnName">公司名称。</param>
        /// <returns>bool</returns>
        bool IsExistName(string coCnName);
        /// <summary>
        /// 获取所有公司。
        /// </summary>
        /// <returns>公司集合。</returns>
        ListBase<CompanyInfo> GetAll();
        /// <summary>
        /// 获取所有有效的公司。
        /// </summary>
        /// <returns>公司集合。</returns>
        ListBase<CompanyInfo> GetAllAvalible();
        /// <summary>
        /// 根据公司编号获取公司。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>公司实体。</returns>
        CompanyInfo GetByCode(string companyCode);
        /// <summary>
        /// 获取默认的公司。
        /// </summary>
        /// <returns>公司信息。</returns>
        CompanyInfo GetDefault();
        
    }
}
