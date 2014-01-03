using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// 系统管理中Company的WebService接口.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/",Description = "系统管理中Company的WebService接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Company : System.Web.Services.WebService,ICompany
    {
        #region Implementation of ICompany

        /// <summary>
        /// 添加公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "添加公司")]
        public bool Insert(CompanyInfo companyInfo)
        {
            return DataProvider.CompanyProvider.Insert(companyInfo);
        }

        /// <summary>
        /// 修改公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "修改公司")]
        public bool Update(CompanyInfo companyInfo)
        {
            return DataProvider.CompanyProvider.Update(companyInfo);
        }

        /// <summary>
        /// 删除公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        public bool Delete(CompanyInfo companyInfo)
        {
            return DataProvider.CompanyProvider.Delete(companyInfo);
        }

        /// <summary>
        /// 删除公司。
        /// </summary>
        /// <param name="coCode">公司编号。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "删除公司")]
        public bool Delete(string coCode)
        {
            return DataProvider.CompanyProvider.Delete(coCode);
        }

        /// <summary>
        /// 判断公司编号是否已经存在。
        /// </summary>
        /// <param name="coCode">公司编号。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "判断公司编号是否已经存在")]
        public bool IsExistCode(string coCode)
        {
            return DataProvider.CompanyProvider.IsExistCode(coCode);
        }

        /// <summary>
        /// 是否已经存在组名称。
        /// </summary>
        /// <param name="coCnName">公司名称。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "是否已经存在组名称")]
        public bool IsExistName(string coCnName)
        {
            return DataProvider.CompanyProvider.IsExistName(coCnName);
        }

        /// <summary>
        /// 获取所有公司。
        /// </summary>
        /// <returns>公司集合。</returns>
        [WebMethod(Description = "获取所有公司")]
        public ListBase<CompanyInfo> GetAll()
        {
            return DataProvider.CompanyProvider.GetAll();
        }

        /// <summary>
        /// 获取所有有效的公司。
        /// </summary>
        /// <returns>公司集合。</returns>
        [WebMethod(Description = "获取所有有效的公司")]
        public ListBase<CompanyInfo> GetAllAvalible()
        {
            return DataProvider.CompanyProvider.GetAllAvalible();
        }

        /// <summary>
        /// 根据公司编号获取公司。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>公司实体。</returns>
        [WebMethod(Description = "根据公司编号获取公司")]
        public CompanyInfo GetByCode(string companyCode)
        {
            return DataProvider.CompanyProvider.GetByCode(companyCode);
        }

        /// <summary>
        /// 获取默认的公司。
        /// </summary>
        /// <returns>公司信息。</returns>
        [WebMethod(Description = "获取默认的公司")]
        public CompanyInfo GetDefault()
        {
            return DataProvider.CompanyProvider.GetDefault();
        }

        #endregion
    }
}
