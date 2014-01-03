using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Model;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class Company:ICompany
    {
        #region Implementation of ICompany

        /// <summary>
        /// 添加公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        public bool Insert(CompanyInfo companyInfo)
        {
            var obj = new CompanyService.CompanyInfo();
            CopyHelper.Copy(companyInfo,obj);
            return new CompanyService.Company().Insert(obj);
        }

        /// <summary>
        /// 修改公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        public bool Update(CompanyInfo companyInfo)
        {
            var obj = new CompanyService.CompanyInfo();
            CopyHelper.Copy(companyInfo, obj);
            return new CompanyService.Company().Update(obj);
        }

        /// <summary>
        /// 删除公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        public bool Delete(CompanyInfo companyInfo)
        {
            return new CompanyService.Company().Delete(companyInfo.CoCode);
        }

        /// <summary>
        /// 删除公司。
        /// </summary>
        /// <param name="coCode">公司编号。</param>
        /// <returns>bool</returns>
        public bool Delete(string coCode)
        {
            return new CompanyService.Company().Delete(coCode);
        }

        /// <summary>
        /// 判断公司编号是否已经存在。
        /// </summary>
        /// <param name="coCode">公司编号。</param>
        /// <returns>bool</returns>
        public bool IsExistCode(string coCode)
        {
            return new CompanyService.Company().IsExistCode(coCode);
        }

        /// <summary>
        /// 是否已经存在组名称。
        /// </summary>
        /// <param name="coCnName">公司名称。</param>
        /// <returns>bool</returns>
        public bool IsExistName(string coCnName)
        {
            return new CompanyService.Company().IsExistName(coCnName);
        }

        /// <summary>
        /// 获取所有公司。
        /// </summary>
        /// <returns>公司集合。</returns>
        public ListBase<CompanyInfo> GetAll()
        {
            var objs = new CompanyService.Company().GetAll();
            var obj1s = new ListBase<CompanyInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new CompanyInfo();
                CopyHelper.Copy(obj,obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取所有有效的公司。
        /// </summary>
        /// <returns>公司集合。</returns>
        public ListBase<CompanyInfo> GetAllAvalible()
        {
            var objs = new CompanyService.Company().GetAllAvalible();
            var obj1s = new ListBase<CompanyInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new CompanyInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据公司编号获取公司。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>公司实体。</returns>
        public CompanyInfo GetByCode(string companyCode)
        {
            var obj = new CompanyService.Company().GetByCode(companyCode);
            if(obj != null)
            {
                var obj1 = new CompanyInfo();
                CopyHelper.Copy(obj,obj1);
                return obj1;
            }
            return null;
        }

        /// <summary>
        /// 获取默认的公司。
        /// </summary>
        /// <returns>公司信息。</returns>
        public CompanyInfo GetDefault()
        {
            var obj = new CompanyService.Company().GetDefault();
            if (obj != null)
            {
                var obj1 = new CompanyInfo();
                CopyHelper.Copy(obj, obj1);
                return obj1;
            }
            return null;
        }

        #endregion
    }
}
