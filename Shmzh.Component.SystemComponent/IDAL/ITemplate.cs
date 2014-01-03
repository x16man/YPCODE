using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 模板对象的数据访问接口。
    /// </summary>
    public interface ITemplate
    {
        /// <summary>
        /// 添加模板记录。
        /// </summary>
        /// <param name="templateInfo">模板记录实体。</param>
        /// <returns>bool</returns>
        bool Insert(TemplateInfo templateInfo);

        /// <summary>
        /// 修改模板记录。
        /// </summary>
        /// <param name="templateInfo">模板记录实体。</param>
        /// <returns>bool</returns>
        bool Update(TemplateInfo templateInfo);

        /// <summary>
        /// 删除模板记录。
        /// </summary>
        /// <param name="templateInfo">模板记录实体。</param>
        /// <returns>bool</returns>
        bool Delete(TemplateInfo templateInfo);
        
        /// <summary>
        /// 删除模板记录。
        /// </summary>
        /// <param name="id">模板Id。</param>
        /// <returns>bool</returns>
        bool Delete(int id);

        /// <summary>
        /// 获取所有模板记录。
        /// </summary>
        /// <returns>模板记录集合。</returns>
        IList<TemplateInfo> GetAll();

        /// <summary>
        /// 根据产品ID获取模板记录集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>模板记录集合。</returns>
        IList<TemplateInfo> GetByProductCode(short productCode);
        
        /// <summary>
        /// 根据模板ID获取模板记录实体。
        /// </summary>
        /// <param name="id">模板ID。</param>
        /// <returns>模板记录实体。</returns>
        TemplateInfo GetById(int id);

        /// <summary>
        /// 根据模板编号获取模板记录实体。
        /// </summary>
        /// <param name="code">模板编号。</param>
        /// <returns>模板记录实体。</returns>
        TemplateInfo GetByCode(string code);

        /// <summary>
        /// 判断模板编号是否已经存在。
        /// </summary>
        /// <param name="code">模板编号。</param>
        /// <returns>bool</returns>
        bool IsExist(string code);
        
    }
}
