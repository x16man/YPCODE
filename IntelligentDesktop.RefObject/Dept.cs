using System;
using System.Collections.Generic;
using System.Data.Common;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;

namespace IntelligentDesktop.RefObject
{
    /// <summary>
    /// 组织机构的SQL Server的数据访问层。
    /// </summary>
    [Serializable]
    public class Dept : MarshalByRefObject, IDept
    {
        private static IDept dal;
        static Dept()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.DeptProvider;
        }

        #region IDept 成员

        public bool Insert(DeptInfo deptInfo)
        {
            return dal.Insert(deptInfo);
        }

        public bool Insert(DeptInfo deptInfo, DbTransaction trans)
        {
            return dal.Insert(deptInfo, trans);
        }

        public bool Update(DeptInfo deptInfo)
        {
            return dal.Update(deptInfo);
        }

        public bool Update(DeptInfo deptInfo, DbTransaction trans)
        {
            return dal.Update(deptInfo, trans);
        }

        public bool Delete(DeptInfo deptInfo)
        {
            return dal.Delete(deptInfo);
        }

        public bool Delete(DeptInfo deptInfo, DbTransaction trans)
        {
            return dal.Delete(deptInfo, trans);
        }

        public bool Delete(string companyCode, string deptCode)
        {
            return dal.Delete(companyCode, deptCode);
        }

        public bool Disable(string companyCode, string deptCode)
        {
            return dal.Disable(companyCode, deptCode);
        }

        public bool Disable(string companyCode, string deptCode, DbTransaction trans)
        {
            return dal.Disable(companyCode, deptCode, trans);
        }

        public bool Enable(string companyCode, string deptCode)
        {
            return dal.Enable(companyCode, deptCode);
        }

        public bool Enable(string companyCode, string deptCode, DbTransaction trans)
        {
            return dal.Enable(companyCode, deptCode, trans);
        }

        public bool IsExistDeptCode(string companyCode, string deptCode)
        {
            return dal.IsExistDeptCode(companyCode, deptCode);
        }

        public bool IsExistDeptName(string companyCode, string deptName)
        {
            return dal.IsExistDeptName(companyCode, deptName);
        }

        public bool HasChildDept(string companyCode, string deptCode)
        {
            return dal.HasChildDept(companyCode, deptCode); 
        }

        public bool HasUser(string companyCode, string deptCode)
        {
            return dal.HasUser(companyCode, deptCode);
        }

        public IList<DeptInfo> GetAllByCompanyCode(string companyCode)
        {
            return dal.GetAllByCompanyCode(companyCode);
 
        }

        public IList<DeptInfo> GetAllAvalibleCompanyCode(string companyCode)
        {
            return dal.GetAllAvalibleCompanyCode(companyCode);
        }

        public DeptInfo GetByCompanyCodeAndDeptCode(string companyCode, string deptCode)
        {
            return dal.GetByCompanyCodeAndDeptCode(companyCode, deptCode);
        }

        public DeptInfo GetParentDeptByCode(string deptCode)
        {
            return dal.GetParentDeptByCode(deptCode);
        }

        public IList<DeptInfo> GetByCompanyAndManager(string companyCode, string manager)
        {
            return dal.GetByCompanyAndManager(companyCode, manager);
        }
        
        #endregion
    }
}
