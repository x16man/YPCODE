using System.Collections.Generic;
using System.Web.Services;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// ObjType 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ObjType : System.Web.Services.WebService,IObjType
    {

        
        #region Implementation of IObjType

        /// <summary>
        /// 根据Id获取监控对象类型.
        /// </summary>
        /// <param name="id">监控对象类型Id.</param>
        /// <returns>监控对象类型对象.</returns>
        [WebMethod]
        public ObjTypeInfo GetById(int id)
        {
            return DataProvider.ObjTypeProvider.GetById(id);
        }

        /// <summary>
        /// 获取所有的监控对象类型对象.
        /// </summary>
        /// <returns>所有的监控对象类型对象.</returns>
        [WebMethod]
        public List<ObjTypeInfo> GetAll()
        {
            return DataProvider.ObjTypeProvider.GetAll();
        }

        /// <summary>
        /// 根据上级Id获取监控对象类型对象集合.
        /// </summary>
        /// <param name="parentId">上级Id.</param>
        /// <returns>监控对象类型对象集合.</returns>
        [WebMethod]
        public List<ObjTypeInfo> GetByParentId(int parentId)
        {
            return DataProvider.ObjTypeProvider.GetByParentId(parentId);
        }

        /// <summary>
        /// 删除监控对象类型对象.
        /// </summary>
        /// <param name="id">监控对象类型对象Id.</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int id)
        {
            return DataProvider.ObjTypeProvider.Delete(id);
        }

        /// <summary>
        /// 删除监控对象类型对象
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        public bool Delete(ObjTypeInfo objTypeInfo)
        {
            return DataProvider.ObjTypeProvider.Delete(objTypeInfo);
        }

        /// <summary>
        /// 添加监控对象类型对象.
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        [WebMethod]
        public int Insert(ObjTypeInfo objTypeInfo)
        {
            return DataProvider.ObjTypeProvider.Insert(objTypeInfo);
        }

        /// <summary>
        /// 更新监控对象类型对象.
        /// </summary>
        /// <param name="objTypeInfo">监控对象类型对象</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(ObjTypeInfo objTypeInfo)
        {
            return DataProvider.ObjTypeProvider.Update(objTypeInfo);
        }

        #endregion
    }
}
