using System.Collections.Generic;
using System.Web.Services;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
namespace Shmzh.Monitor.DataService
{
    /// <summary>
    /// ObjTypeAttr 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ObjTypeAttr : System.Web.Services.WebService,IObjTypeAttr
    {
        #region Implementation of IObjTypeAttr

        /// <summary>
        /// 根据方案Id获取设备分类属性实体。
        /// </summary>
        /// <param name="id">设备分类属性Id。</param>
        /// <returns>设备分类属性实体。</returns>
        [WebMethod]
        public ObjTypeAttrInfo GetById(int id)
        {
            return DataProvider.ObjTypeAttrProvider.GetById(id);
        }

        /// <summary>
        /// 根据设备分类Id获取设备分类属性集合。
        /// </summary>
        /// <param name="typeId">设备分类Id。</param>
        /// <returns>设备分类属性集合。</returns>
        [WebMethod]
        public List<ObjTypeAttrInfo> GetByTypeId(int typeId)
        {
            return DataProvider.ObjTypeAttrProvider.GetByTypeId(typeId);
        }

        /// <summary>
        /// 根据设备分类属性Id来删除设备分类属性。
        /// </summary>
        /// <param name="id">设备分类属性Id。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Delete(int id)
        {
            return DataProvider.ObjTypeAttrProvider.Delete(id);
        }

        /// <summary>
        /// 删除设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        public bool Delete(ObjTypeAttrInfo objTypeAttrInfo)
        {
            return DataProvider.ObjTypeAttrProvider.Delete(objTypeAttrInfo);
        }

        /// <summary>
        /// 添加设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>int</returns>
        [WebMethod]
        public int Insert(ObjTypeAttrInfo objTypeAttrInfo)
        {
            return DataProvider.ObjTypeAttrProvider.Insert(objTypeAttrInfo);
        }

        /// <summary>
        /// 修改设备分类属性实体。
        /// </summary>
        /// <param name="objTypeAttrInfo">设备分类属性实体。</param>
        /// <returns>bool</returns>
        [WebMethod]
        public bool Update(ObjTypeAttrInfo objTypeAttrInfo)
        {
            return DataProvider.ObjTypeAttrProvider.Update(objTypeAttrInfo);
        }

        #endregion
    }
}
