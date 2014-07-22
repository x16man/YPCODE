using System;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;

namespace IntelligentDesktop.RefObject
{
    /// <summary>
    /// 公司信息的SQL Server 的数据访问对象。
    /// </summary>
    [Serializable]
    public class Company : MarshalByRefObject, ICompany
    {
        private static ICompany dal;
        static Company()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.CompanyProvider;
        }
        #region ICompany 成员

        public bool Insert(CompanyInfo companyInfo)
        {
            return dal.Insert(companyInfo);
        }

        public bool Update(CompanyInfo companyInfo)
        {
            return dal.Update(companyInfo);
        }

        public bool Delete(CompanyInfo companyInfo)
        {
            return dal.Delete(companyInfo);
        }

        public bool Delete(String coCode)
        {
            return dal.Delete(coCode);
        }

        public bool IsExistCode(String coCode)
        {
            return dal.IsExistCode(coCode);
        }

        public bool IsExistName(string coCnName)
        {
            return dal.IsExistName(coCnName);
        }

        public ListBase<CompanyInfo> GetAll()
        {
            return dal.GetAll();
        }

        public ListBase<CompanyInfo> GetAllAvalible()
        {
            return dal.GetAllAvalible();
        }

        public CompanyInfo GetByCode(string companyCode)
        {
            return dal.GetByCode(companyCode);
        }

        public CompanyInfo GetDefault()
        {
            return dal.GetDefault();
        }
        #endregion
    }
}
