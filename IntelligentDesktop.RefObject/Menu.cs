using System;
using System.Data;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;

namespace IntelligentDesktop.RefObject
{
    
	/// <summary>
	/// 菜单的数据访问层。
	/// </summary>
    [Serializable]
	public class Menu : MarshalByRefObject, IMenu
	{
        private static IMenu dal;
        static Menu()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.MenuProvider;
        }

        #region IMenu成员
        /// <summary>
		/// 获取所有的菜单项。
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>方法名和实际行为不符。</remarks>
        [Obsolete("该方法已经修改，获取所有的菜单项,请在程序调用中的作出调整!", false)]
        public DataSet GetAllMenu()
        {
            return dal.GetAllMenu();
        }

        /// <summary>
		/// 获取所有有效的菜单项。
		/// </summary>
		/// <returns>DataSet</returns>
        public DataSet GetAllAvalibleMenu()
        {
            return dal.GetAllAvalibleMenu();
        }

        /// <summary>
		/// 根据指定产品ID获取所有的菜单项。
		/// </summary>
		/// <param name="productId">产品ID。</param>
		/// <returns>DataSet</returns>
        public DataSet GetAllMenuByProductId(int productId)
        {
            return dal.GetAllMenuByProductId(productId);
        }
        
        /// <summary>
		/// 根据指定产品ID获取所有有效的菜单项。
		/// </summary>
		/// <param name="productId">产品ID。</param>
		/// <returns>DataSet</returns>
        public DataSet GetAllAvalibleMenuByProductId(int productId)
        {
            return dal.GetAllAvalibleMenuByProductId(productId);
        }

        /// <summary>
        /// 根据产品编号获取所有的有效的菜单。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>菜单集合。</returns>
        public IList<MenuInfo> GetAllAvalibleByProductCode(int productCode)
        {
            return dal.GetAllAvalibleByProductCode(productCode);
        }
		
        /// <summary>
		/// 根据上一级菜单ID获取所有子菜单项。
		/// </summary>
		/// <param name="parentId">上一级菜单项ID。</param>
		/// <returns>DataSet</returns>
        public DataSet GetAllMenuByParentId(int parentId)
        {
            return dal.GetAllMenuByParentId(parentId);
        }
		
        /// <summary>
		/// 根据上一级菜单ID获取所有有效的子菜单项。
		/// </summary>
		/// <param name="parentId">上一级菜单项ID。</param>
		/// <returns>DataSet</returns>
        public DataSet GetAllAvalibleMenuByParentId(int parentId)
        {
            return dal.GetAllAvalibleMenuByParentId(parentId);
        }
		
        /// <summary>
		/// 根据菜单项Id获取菜单项。
		/// </summary>
		/// <param name="id">菜单项Id</param>
		/// <returns>DataSet</returns>
        public DataSet GetMenuById(int id)
        {
            return dal.GetAllAvalibleMenuByParentId(id);
        }
		
         /// <summary>
        /// 增加菜单项。
        /// </summary>
        /// <param name="menuInfo">菜单项实体。</param>
        /// <returns>bool</returns>
        public bool Insert(MenuInfo menuInfo)
        {
            return dal.Insert(menuInfo);
        }
		
        /// <summary>
        /// 修改菜单项.
        /// </summary>
        /// <param name="menuInfo">菜单项实体。</param>
        /// <returns>bool</returns>
        public bool Update(MenuInfo menuInfo)
        {
            return dal.Update(menuInfo);
        }
		
        /// <summary>
        /// 删除菜单实体。
        /// </summary>
        /// <param name="menuInfo">菜单实体对象。</param>
        /// <returns>bool</returns>
        public bool Delete(MenuInfo menuInfo)
        {
            return dal.Delete(menuInfo);
        }

        /// <summary>
        /// 删除菜单项。
        /// </summary>
        /// <param name="id">菜单项ID。</param>
        /// <returns>布尔类型。</returns>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
	   
        /// <summary>
        /// 转移菜单项。
        /// </summary>
        /// <param name="id">菜单项ID。</param>
        /// <param name="newParentId">新的父节点Id。</param>
        /// <returns>bool</returns>
        public bool MoveTo(int id, int newParentId)
        {
            return dal.MoveTo(id, newParentId);
        }

        public bool IsExistsByType(int typeId)
        {
            return dal.IsExistsByType(typeId);
        }
              
        #endregion



       
    }
}
