using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 产品的数据访问接口。
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// 添加产品。
        /// </summary>
        /// <param name="productInfo">产品实体。</param>
        /// <returns>bool</returns>
        bool Insert(ProductInfo productInfo);
        /// <summary>
        /// 修改产品。
        /// </summary>
        /// <param name="productInfo">产品实体。</param>
        /// <returns>bool</returns>
        bool Update(ProductInfo productInfo);
        /// <summary>
        /// 删除产品。
        /// </summary>
        /// <param name="productInfo">产品实体。</param>
        /// <returns>bool</returns>
        bool Delete(ProductInfo productInfo);
        /// <summary>
        /// 删除产品。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        bool Delete(short productCode);

        /// <summary>
        /// 注册产品。
        /// </summary>
        /// <param name="productInfo">产品实体。</param>
        /// <returns>bool</returns>
        bool Register(ProductInfo productInfo);
        /// <summary>
        /// 判断产品编号是否已经存在。
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        bool IsExist(short productCode);
        /// <summary>
        /// 是否已经存在产品名称。
        /// </summary>
        /// <param name="productName">产品名称。</param>
        /// <returns>bool</returns>
        bool IsExist(string productName);
        /// <summary>
        /// 获取所有产品。
        /// </summary>
        /// <returns>ArrayList。</returns>
        IList<ProductInfo> GetAll();
        /// <summary>
        /// 获取所有有效的产品。
        /// </summary>
        /// <returns></returns>
        IList<ProductInfo> GetAllAvalible();
        /// <summary>
        /// 根据产品编号获取产品。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>ArrayList</returns>
        ProductInfo GetByCode(short productCode);
        

    }
}
