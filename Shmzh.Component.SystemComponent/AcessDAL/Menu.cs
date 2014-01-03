//-----------------------------------------------------------------------
// <copyright file="MenuDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    using System;
    using System.Data;
    using System.Data.OleDb;

	/// <summary>
	/// 菜单的数据访问层。
	/// </summary>
	public class Menu : IDAL.IMenu
	{
        #region Field

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT_MENU = "Insert Into mySystemMenu([fName],[fTitle],[fProductID],[fRightCode],[fParentID],[fOrder],[fLevel],[fUrlType],[fUrl],[fImage],[fCSSClass],[fIsEnable],[fHasSubMenu],[fType],[fRemark]) Values (@Name,@Title,@ProductId,@RightCode,@ParentID,@Order,@Level,@UrlType,@Url,@ImageUrl,@CssClass,@IsEnable,@HasSubMenu,@Type,@Remark) ";
        private const string SQL_UPDATE_MENU = "Update mySystemMenu Set [fName]=@Name,[fTitle] = @Title, [fProductId] = @ProductId, [fRightCode] = @RightCode, [fParentId] = @ParentId, [fOrder] = @Order, [fLevel] = @Level, [fUrlType] = @UrlType, [fUrl] = @Url, [fImage] = @ImageUrl, [fCssClass] = @CssClass, [fIsEnable] = @IsEnable,  [fHasSubMenu] = @HasSubMenu, [fType] = @Type, [fRemark] = @Remark Where [fID] = @Id";
        private const string SQL_MOVE_MENU = "Update mySystemMenu Set [fParentId] = @ParentId ,[fLevel]=(select top 1 [flevel]+1 from mySystemMenu Where [fID]=@ParentId) Where [fID]=@Id";
        private const string SQL_DELETE_MENU = "Delete From mySystemMenu Where [fId] = @Id";
	    private const string SQL_SELECT_ALL_MENU = "Select * From mySystemMenu";
	    private const string SQL_SELECT_ALLAVALIBLE_MENU = "Select * From mySystemMenu Where [fIsEnable] = 1 Order By [fOrder]";
	    private const string SQL_SELECT_ALL_BY_PRODUCTCODE = "Select * From mySystemMenu Where fProductID = @ProductCode Order By [fOrder]";
	    private const string SQL_SELECT_ALLAVALIBLE_BY_PRODUCTCODE = "Select * From mySystemMenu Where [fProductID] = @ProductCode And [fIsEnable] = 1 Order By [fOrder]";
	    private const string SQL_SELECT_ALL_BY_PARENTID = "Select * From mySystemMenu Where [fParentId]=@ParentID Order By [fOrder]";
        private const string SQL_SELECT_ALLAVALIBLE_BY_PARENTID = "Select * From mySystemMenu Where [fParentId]=@ParentID And [fIsEnable] = 1 Order By [fOrder]";
	    private const string SQL_SELECT_BY_ID = "Select * From mySystemMenu Where [fID] = @Id";
	    private const string SQL_SELECT_COUNT_BY_TYPE = "Select Count(*) From mySystemMenu Where [fType] = @Type";
        private const string PARM_ID = "@Id";
        private const string PARM_NAME = "@Name";
        private const string PARM_TITLE = "@Title";
        private const string PARM_PRODUCTID = "@ProductId";
        private const string PARM_RIGHTCODE = "@RightCode";
        private const string PARM_PARENTID = "@ParentId";
        private const string PARM_ORDER = "@Order"; 
        private const string PARM_LEVEL = "@Level";
        private const string PARM_URLTYPE = "@UrlType";
        private const string PARM_URL = "@Url";
        private const string PARM_IMAGE = "@ImageUrl";
        private const string PARM_CSSCLASS = "@CssClass";
        private const string PARM_ISENABLE = "@IsEnable";
        private const string PARM_HASSUBMENU = "@HasSubMenu";
        private const string PARM_TYPE = "@Type";
        private const string PARM_REMARK = "@Remark";
        #endregion

		/// <summary>
		/// 构造函数。
		/// </summary>
		public Menu()
		{
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
			return AccessHelper.ExecuteDataset(ConnectionString.PubData,SQL_SELECT_ALL_MENU);
		}
		/// <summary>
		/// 获取所有有效的菜单项。
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetAllAvalibleMenu()
		{
			return AccessHelper.ExecuteDataset(ConnectionString.PubData, SQL_SELECT_ALLAVALIBLE_MENU);
		}
		/// <summary>
		/// 根据指定产品ID获取所有的菜单项。
		/// </summary>
		/// <param name="productId">产品ID。</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllMenuByProductId(int productId)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fProductId={0} Order By fOrder",productId);
			return AccessHelper.ExecuteDataset(ConnectionString.PubData,sqlStatement);
		}
		/// <summary>
		/// 根据指定产品ID获取所有有效的菜单项。
		/// </summary>
		/// <param name="productId">产品ID。</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllAvalibleMenuByProductId(int productId)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fIsEnable=1 And fProductId={0} Order By fOrder",productId);
			return AccessHelper.ExecuteDataset(ConnectionString.PubData,sqlStatement);
		}

	    /// <summary>
	    /// 根据产品编号获取所有的有效的菜单。
	    /// </summary>
	    /// <param name="productCode">产品编号。</param>
	    /// <returns>菜单集合。</returns>
	    public IList<MenuInfo> GetAllAvalibleByProductCode(int productCode)
	    {
	        throw new System.NotImplementedException();
	    }

	    /// <summary>
		/// 根据上一级菜单ID获取所有子菜单项。
		/// </summary>
		/// <param name="parentId">上一级菜单项ID。</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllMenuByParentId(int parentId)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fParentId={0} Order By fOrder",parentId);
			return AccessHelper.ExecuteDataset(ConnectionString.PubData ,sqlStatement);
		}
		/// <summary>
		/// 根据上一级菜单ID获取所有有效的子菜单项。
		/// </summary>
		/// <param name="parentId">上一级菜单项ID。</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllAvalibleMenuByParentId(int parentId)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fIsEnable = 1 And fParentId={0} Order By fOrder",parentId);
			return AccessHelper.ExecuteDataset(ConnectionString.PubData ,sqlStatement);
		}
		/// <summary>
		/// 根据菜单项Id获取菜单项。
		/// </summary>
		/// <param name="id">菜单项Id</param>
		/// <returns>DataSet</returns>
		public DataSet GetMenuById(int id)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fId = {0}",id);
			return AccessHelper.ExecuteDataset(ConnectionString.PubData, sqlStatement);
		}
		
	    /// <summary>
        /// 增加菜单项。
        /// </summary>
        /// <param name="menuInfo">菜单项实体。</param>
        /// <returns>bool</returns>
		public bool Insert(MenuInfo menuInfo)
		{
		    var parms = GetMenuParameters();
	        parms[0].Value = menuInfo.Name;
		    parms[1].Value = menuInfo.Title;
		    parms[2].Value = menuInfo.ProductID;
		    parms[3].Value = menuInfo.RightCode;
		    parms[4].Value = menuInfo.ParentID;
		    parms[5].Value = menuInfo.Order;
		    parms[6].Value = menuInfo.Level;
		    parms[7].Value = menuInfo.URLType;
		    parms[8].Value = string.IsNullOrEmpty(menuInfo.URL)?(object)DBNull.Value:menuInfo.URL;
		    parms[9].Value = string.IsNullOrEmpty(menuInfo.ImageURL)?(object)DBNull.Value:menuInfo.ImageURL;
	        parms[10].Value = string.IsNullOrEmpty(menuInfo.CSSClass) ? (object) DBNull.Value : menuInfo.CSSClass;
		    parms[11].Value = menuInfo.IsEnable;
		    parms[12].Value = menuInfo.HasSubMenu;
		    parms[13].Value = menuInfo.Type;
		    parms[14].Value = string.IsNullOrEmpty(menuInfo.Remark)?(object)DBNull.Value:menuInfo.Remark;

		    try
		    {
		        AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_INSERT_MENU, parms);
		        menuInfo.ID = (int)parms[0].Value;
		        return true;
		    }
		    catch (Exception ex)
		    {
		        Logger.Error(ex.Message);
		        return false;
		    }
		}
	    /// <summary>
        /// 修改菜单项.
        /// </summary>
        /// <param name="menuInfo">菜单项实体。</param>
        /// <returns>bool</returns>
        public bool Update(MenuInfo menuInfo)
        {
            var parms = new[]
                            {
                                 new OleDbParameter(PARM_NAME, OleDbType.VarChar, 255),
                                new OleDbParameter(PARM_TITLE, OleDbType.VarChar, 20),
                                new OleDbParameter(PARM_PRODUCTID, OleDbType.Integer),
                                new OleDbParameter(PARM_RIGHTCODE,OleDbType.Integer), 
                                new OleDbParameter(PARM_PARENTID,OleDbType.Integer), 
                                new OleDbParameter(PARM_ORDER,OleDbType.Integer), 
                                new OleDbParameter(PARM_LEVEL,OleDbType.Integer), 
                                new OleDbParameter(PARM_URLTYPE, OleDbType.Integer), 
                                new OleDbParameter(PARM_URL,OleDbType.VarChar,255),
                                new OleDbParameter(PARM_IMAGE, OleDbType.VarChar,255),
                                new OleDbParameter(PARM_CSSCLASS,OleDbType.VarChar,255), 
                                new OleDbParameter(PARM_ISENABLE ,OleDbType.Integer),
                                new OleDbParameter(PARM_HASSUBMENU,OleDbType.Integer),
                                new OleDbParameter(PARM_TYPE,OleDbType.Integer),
                                new OleDbParameter(PARM_REMARK,OleDbType.LongVarChar), 
                                new OleDbParameter(PARM_ID, OleDbType.Integer),
                               
                            };
           
            parms[0].Value = menuInfo.Name;
            parms[1].Value = menuInfo.Title;
            parms[2].Value = menuInfo.ProductID;
            parms[3].Value = menuInfo.RightCode;
            parms[4].Value = menuInfo.ParentID;
            parms[5].Value = menuInfo.Order;
            parms[6].Value = menuInfo.Level;
            parms[7].Value = menuInfo.URLType;
            parms[8].Value = menuInfo.URL;
            parms[9].Value = string.IsNullOrEmpty(menuInfo.ImageURL)?(object)DBNull.Value:menuInfo.ImageURL;
            parms[10].Value = string.IsNullOrEmpty(menuInfo.CSSClass)?(object)DBNull.Value:menuInfo.CSSClass;
            parms[11].Value = menuInfo.IsEnable;
            parms[12].Value = menuInfo.HasSubMenu;
            parms[13].Value = menuInfo.Type;
            parms[14].Value = string.IsNullOrEmpty(menuInfo.Remark)?(object)DBNull.Value:menuInfo.Remark;
            parms[15].Value = menuInfo.ID;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_UPDATE_MENU, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除菜单实体。
        /// </summary>
        /// <param name="menuInfo">菜单实体对象。</param>
        /// <returns>bool</returns>
        public bool Delete(MenuInfo menuInfo)
        {
            //var parms = GetMenuParameters();
            //parms[0].Value = menuInfo.ID;
            var parms = new[] {new OleDbParameter("@Id", OleDbType.Integer) {Value = menuInfo.ID},};
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_DELETE_MENU, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 删除菜单项。
        /// </summary>
        /// <param name="id">菜单项ID。</param>
        /// <returns>布尔类型。</returns>
        public bool Delete(int id)
        {
            //var parms = GetMenuParameters();
            //parms[0].Value = id;
            var parms = new[] { new OleDbParameter("@Id", OleDbType.Integer) { Value = id }, };
            
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_DELETE_MENU, parms);
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 转移菜单项。
        /// </summary>
        /// <param name="id">菜单项ID。</param>
        /// <param name="newParentId">新的父节点Id。</param>
        /// <returns>bool</returns>
        public bool MoveTo(int id,int newParentId)
        {
            var sqlStatement = string.Format(@"Update mySystemMenu Set fParentId = {0} ,fLevel=(select top 1 flevel+1 from mySystemMenu Where fID={0}) Where fID={1}", newParentId, id);
            Logger.Info(sqlStatement);
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  sqlStatement);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 获取Insert和Update命令的参数数组。
        /// </summary>
        /// <returns>Sql参数数组。</returns>
        private static OleDbParameter[] GetMenuParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_MENU);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter(PARM_NAME, OleDbType.VarChar, 255),
                                new OleDbParameter(PARM_TITLE, OleDbType.VarChar, 20),
                                new OleDbParameter(PARM_PRODUCTID, OleDbType.Integer),
                                new OleDbParameter(PARM_RIGHTCODE,OleDbType.Integer), 
                                new OleDbParameter(PARM_PARENTID,OleDbType.Integer), 
                                new OleDbParameter(PARM_ORDER,OleDbType.Integer), 
                                new OleDbParameter(PARM_LEVEL,OleDbType.Integer), 
                                new OleDbParameter(PARM_URLTYPE, OleDbType.Integer), 
                                new OleDbParameter(PARM_URL,OleDbType.VarChar,255),
                                new OleDbParameter(PARM_IMAGE, OleDbType.VarChar,255),
                                new OleDbParameter(PARM_CSSCLASS,OleDbType.VarChar,255), 
                                new OleDbParameter(PARM_ISENABLE ,OleDbType.Integer),
                                new OleDbParameter(PARM_HASSUBMENU,OleDbType.Integer),
                                new OleDbParameter(PARM_TYPE,OleDbType.Integer),
                                new OleDbParameter(PARM_REMARK,OleDbType.LongVarChar), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_MENU, parms);
            }
            return parms;
        }

        private static OleDbParameter[] GetMenuUpdateParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_UPDATE_MENU);
            if (parms == null)
            {
                parms = new[]
                            {
                                 new OleDbParameter(PARM_NAME, OleDbType.VarChar, 255),
                                new OleDbParameter(PARM_TITLE, OleDbType.VarChar, 20),
                                new OleDbParameter(PARM_PRODUCTID, OleDbType.Integer),
                                new OleDbParameter(PARM_RIGHTCODE,OleDbType.Integer), 
                                new OleDbParameter(PARM_PARENTID,OleDbType.Integer), 
                                new OleDbParameter(PARM_ORDER,OleDbType.Integer), 
                                new OleDbParameter(PARM_LEVEL,OleDbType.Integer), 
                                new OleDbParameter(PARM_URLTYPE, OleDbType.Integer), 
                                new OleDbParameter(PARM_URL,OleDbType.VarChar,255),
                                new OleDbParameter(PARM_IMAGE, OleDbType.VarChar,255),
                                new OleDbParameter(PARM_CSSCLASS,OleDbType.VarChar,255), 
                                new OleDbParameter(PARM_ISENABLE ,OleDbType.Integer),
                                new OleDbParameter(PARM_HASSUBMENU,OleDbType.Integer),
                                new OleDbParameter(PARM_TYPE,OleDbType.Integer),
                                new OleDbParameter(PARM_REMARK,OleDbType.LongVarChar), 
                                new OleDbParameter(PARM_ID, OleDbType.Integer){Direction = ParameterDirection.InputOutput},
                               
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_UPDATE_MENU, parms);
            }
            return parms;
        }
        #endregion

        #region IMenu 成员

	    /// <summary>
	    /// 判断是否存在指定菜单类型的菜单项。
	    /// </summary>
	    /// <param name="typeId">菜单类型Id。</param>
	    /// <returns>bool</returns>
	    public bool IsExistsByType(int typeId)
        {
            var parms = new[] { new OleDbParameter("@Type", OleDbType.Integer) { Value = typeId } };
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,  SQL_SELECT_COUNT_BY_TYPE,
                                              parms);
            return (int) obj == 0 ? false : true;
        }

        #endregion
    }
}
