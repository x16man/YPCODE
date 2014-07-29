using System;
using System.Data;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;

namespace IntelligentDesktop.RefObject
{
    
	/// <summary>
	/// �˵������ݷ��ʲ㡣
	/// </summary>
    [Serializable]
	public class Menu : MarshalByRefObject, IMenu
	{
        private static IMenu dal;
        static Menu()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.MenuProvider;
        }

        #region IMenu��Ա
        /// <summary>
		/// ��ȡ���еĲ˵��
		/// </summary>
		/// <returns>DataSet</returns>
		/// <remarks>��������ʵ����Ϊ������</remarks>
        [Obsolete("�÷����Ѿ��޸ģ���ȡ���еĲ˵���,���ڳ�������е���������!", false)]
        public DataSet GetAllMenu()
        {
            return dal.GetAllMenu();
        }

        /// <summary>
		/// ��ȡ������Ч�Ĳ˵��
		/// </summary>
		/// <returns>DataSet</returns>
        public DataSet GetAllAvalibleMenu()
        {
            return dal.GetAllAvalibleMenu();
        }

        /// <summary>
		/// ����ָ����ƷID��ȡ���еĲ˵��
		/// </summary>
		/// <param name="productId">��ƷID��</param>
		/// <returns>DataSet</returns>
        public DataSet GetAllMenuByProductId(int productId)
        {
            return dal.GetAllMenuByProductId(productId);
        }
        
        /// <summary>
		/// ����ָ����ƷID��ȡ������Ч�Ĳ˵��
		/// </summary>
		/// <param name="productId">��ƷID��</param>
		/// <returns>DataSet</returns>
        public DataSet GetAllAvalibleMenuByProductId(int productId)
        {
            return dal.GetAllAvalibleMenuByProductId(productId);
        }

        /// <summary>
        /// ���ݲ�Ʒ��Ż�ȡ���е���Ч�Ĳ˵���
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <returns>�˵����ϡ�</returns>
        public IList<MenuInfo> GetAllAvalibleByProductCode(int productCode)
        {
            return dal.GetAllAvalibleByProductCode(productCode);
        }
		
        /// <summary>
		/// ������һ���˵�ID��ȡ�����Ӳ˵��
		/// </summary>
		/// <param name="parentId">��һ���˵���ID��</param>
		/// <returns>DataSet</returns>
        public DataSet GetAllMenuByParentId(int parentId)
        {
            return dal.GetAllMenuByParentId(parentId);
        }
		
        /// <summary>
		/// ������һ���˵�ID��ȡ������Ч���Ӳ˵��
		/// </summary>
		/// <param name="parentId">��һ���˵���ID��</param>
		/// <returns>DataSet</returns>
        public DataSet GetAllAvalibleMenuByParentId(int parentId)
        {
            return dal.GetAllAvalibleMenuByParentId(parentId);
        }
		
        /// <summary>
		/// ���ݲ˵���Id��ȡ�˵��
		/// </summary>
		/// <param name="id">�˵���Id</param>
		/// <returns>DataSet</returns>
        public DataSet GetMenuById(int id)
        {
            return dal.GetAllAvalibleMenuByParentId(id);
        }
		
         /// <summary>
        /// ���Ӳ˵��
        /// </summary>
        /// <param name="menuInfo">�˵���ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Insert(MenuInfo menuInfo)
        {
            return dal.Insert(menuInfo);
        }
		
        /// <summary>
        /// �޸Ĳ˵���.
        /// </summary>
        /// <param name="menuInfo">�˵���ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Update(MenuInfo menuInfo)
        {
            return dal.Update(menuInfo);
        }
		
        /// <summary>
        /// ɾ���˵�ʵ�塣
        /// </summary>
        /// <param name="menuInfo">�˵�ʵ�����</param>
        /// <returns>bool</returns>
        public bool Delete(MenuInfo menuInfo)
        {
            return dal.Delete(menuInfo);
        }

        /// <summary>
        /// ɾ���˵��
        /// </summary>
        /// <param name="id">�˵���ID��</param>
        /// <returns>�������͡�</returns>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
	   
        /// <summary>
        /// ת�Ʋ˵��
        /// </summary>
        /// <param name="id">�˵���ID��</param>
        /// <param name="newParentId">�µĸ��ڵ�Id��</param>
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
