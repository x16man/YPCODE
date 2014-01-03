using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class Dept:IDept
    {
        #region Implementation of IDept

        /// <summary>
        /// 添加部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        public bool Insert(DeptInfo deptInfo)
        {
            var obj = new DeptService.DeptInfo();
            CopyHelper.Copy(deptInfo,obj);
            return new DeptService.Dept().Insert(obj);
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
        public bool Update(DeptInfo deptInfo)
        {
            var obj = new DeptService.DeptInfo();
            CopyHelper.Copy(deptInfo, obj);
            return new DeptService.Dept().Update(obj);
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
            return this.Delete(deptInfo.DeptCo, deptInfo.DeptCode);
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
        public bool Delete(string companyCode, string deptCode)
        {
            return new DeptService.Dept().Delete(companyCode, deptCode);
        }

        /// <summary>
        /// 部门失效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        public bool Disable(string companyCode, string deptCode)
        {
            return new DeptService.Dept().Disable(companyCode, deptCode);
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
        public bool Enable(string companyCode, string deptCode)
        {
            return new DeptService.Dept().Enable(companyCode, deptCode);
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
        public bool IsExistDeptCode(string companyCode, string deptCode)
        {
            return new DeptService.Dept().IsExistDeptCode(companyCode, deptCode);
        }

        /// <summary>
        /// 是否已经存在部门名称
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptName">部门名称。</param>
        /// <returns>bool</returns>
        public bool IsExistDeptName(string companyCode, string deptName)
        {
            return new DeptService.Dept().IsExistDeptName(companyCode, deptName);
        }

        /// <summary>
        /// 判断是否有子部门。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        public bool HasChildDept(string companyCode, string deptCode)
        {
            return new DeptService.Dept().HasChildDept(companyCode, deptCode);
        }

        /// <summary>
        /// 判断是否有用户。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        public bool HasUser(string companyCode, string deptCode)
        {
            return new DeptService.Dept().HasUser(companyCode, deptCode);
        }

        /// <summary>
        /// 获取所有部门。
        /// </summary>
        /// <returns>部门集合。</returns>
        public IList<DeptInfo> GetAllByCompanyCode(string companyCode)
        {
            var objs = new DeptService.Dept().GetAllByCompanyCode(companyCode);
            var obj1s = new List<DeptInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new DeptInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取所有有效的部门。
        /// </summary>
        /// <returns>部门集合。</returns>
        public IList<DeptInfo> GetAllAvalibleCompanyCode(string companyCode)
        {
            var objs = new DeptService.Dept().GetAllAvalibleCompanyCode(companyCode);
            var obj1s = new List<DeptInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new DeptInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号和部门主管获取部门列表。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="manager">部门主管。</param>
        /// <returns>部门列表。</returns>
        public IList<DeptInfo> GetByCompanyAndManager(string companyCode, string manager)
        {
            var objs = new DeptService.Dept().GetByCompanyAndManager(companyCode,manager);
            var obj1s = new List<DeptInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new DeptInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据部门编号获取部门。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门实体。</returns>
        public DeptInfo GetByCompanyCodeAndDeptCode(string companyCode, string deptCode)
        {
            var obj = new DeptService.Dept().GetByCompanyCodeAndDeptCode(companyCode,deptCode);
            if (obj != null)
            {
                var obj1 = new DeptInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        /// <summary>
        /// 根据部门编号获取上级部门。
        /// </summary>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门实体。</returns>
        public DeptInfo GetParentDeptByCode(string deptCode)
        {
            var obj = new DeptService.Dept().GetParentDeptByCode(deptCode);
            if (obj != null)
            {
                var obj1 = new DeptInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        #endregion
    }
}
