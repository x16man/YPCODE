using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Web;
using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// Dept 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Dept : System.Web.Services.WebService//,IDept
    {
        #region Implementation of IDept

        /// <summary>
        /// 添加部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Insert(DeptInfo deptInfo)
        {
            return DataProvider.DeptProvider.Insert(deptInfo);
        }

        /// <summary>
        /// 添加部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(DeptInfo deptInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(DeptInfo deptInfo)
        {
            return DataProvider.DeptProvider.Update(deptInfo);
        }

        /// <summary>
        /// 修改部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool。</returns>
        public bool Update(DeptInfo deptInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        public bool Delete(DeptInfo deptInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对虾昂。</param>
        /// <returns>bool。</returns>
        public bool Delete(DeptInfo deptInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(string companyCode, string deptCode)
        {
            return DataProvider.DeptProvider.Delete(companyCode, deptCode);
        }

        /// <summary>
        /// 部门失效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Disable(string companyCode, string deptCode)
        {
            return DataProvider.DeptProvider.Disable(companyCode, deptCode);
        }

        /// <summary>
        /// 部门失效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Disable(string companyCode, string deptCode, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 部门有效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Enable(string companyCode, string deptCode)
        {
            return DataProvider.DeptProvider.Enable(companyCode, deptCode);
        }

        /// <summary>
        /// 部门起效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门代码。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Enable(string companyCode, string deptCode, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 是否已经存在部门编号。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool IsExistDeptCode(string companyCode, string deptCode)
        {
            return DataProvider.DeptProvider.IsExistDeptCode(companyCode, deptCode);
        }

        /// <summary>
        /// 是否已经存在部门名称
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptName">部门名称。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool IsExistDeptName(string companyCode, string deptName)
        {
            return DataProvider.DeptProvider.IsExistDeptName(companyCode, deptName);
        }

        /// <summary>
        /// 判断是否有子部门。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool HasChildDept(string companyCode, string deptCode)
        {
            return DataProvider.DeptProvider.HasChildDept(companyCode, deptCode);
        }

        /// <summary>
        /// 判断是否有用户。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool HasUser(string companyCode, string deptCode)
        {
            return DataProvider.DeptProvider.HasUser(companyCode, deptCode);
        }

        /// <summary>
        /// 获取所有部门。
        /// </summary>
        /// <returns>部门集合。</returns>
        [WebMethod]
        public List<DeptInfo> GetAllByCompanyCode(string companyCode)
        {
            return DataProvider.DeptProvider.GetAllByCompanyCode(companyCode) as List<DeptInfo>;
        }

        /// <summary>
        /// 获取所有有效的部门。
        /// </summary>
        /// <returns>部门集合。</returns>
        [WebMethod]
        public List<DeptInfo> GetAllAvalibleCompanyCode(string companyCode)
        {
            return DataProvider.DeptProvider.GetAllAvalibleCompanyCode(companyCode) as List<DeptInfo>;
        }

        /// <summary>
        /// 根据公司编号和部门主管获取部门列表。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="manager">部门主管。</param>
        /// <returns>部门列表。</returns>
        [WebMethod]
        public List<DeptInfo> GetByCompanyAndManager(string companyCode, string manager)
        {
            return DataProvider.DeptProvider.GetByCompanyAndManager(companyCode, manager) as List<DeptInfo>;
        }

        /// <summary>
        /// 根据部门编号获取部门。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门实体。</returns>
        [WebMethod]
        public DeptInfo GetByCompanyCodeAndDeptCode(string companyCode, string deptCode)
        {
            return DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(companyCode, deptCode);
        }

        /// <summary>
        /// 根据部门编号获取上级部门。
        /// </summary>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门实体。</returns>
        [WebMethod ]
        public DeptInfo GetParentDeptByCode(string deptCode)
        {
            return DataProvider.DeptProvider.GetParentDeptByCode(deptCode);
        }

        #endregion
    }
}
