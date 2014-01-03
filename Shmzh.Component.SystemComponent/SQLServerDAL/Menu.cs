//-----------------------------------------------------------------------
// <copyright file="MenuDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

	/// <summary>
	/// �˵������ݷ��ʲ㡣
	/// </summary>
	public class Menu : IDAL.IMenu
	{
        #region Field

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT_MENU = "Insert Into mySystemMenu(fName,fTitle,fProductID,fRightCode,fParentID,fOrder,fLevel,fUrlType,fUrl,fImage,fCSSClass,fIsEnable,fHasSubMenu,fType,fRemark,fCheckCode,fObjType) Values (@Name,@Title,@ProductId,@RightCode,@ParentID,@Order,@Level,@UrlType,@Url,@ImageUrl,@CssClass,@IsEnable,@HasSubMenu,@Type,@Remark,@CheckCode,@ObjType) SET @Id = SCOPE_IDENTITY()";
        private const string SQL_UPDATE_MENU = "Update mySystemMenu Set fName=@Name,fTitle = @Title, fProductId = @ProductId, fRightCode = @RightCode, fParentId = @ParentId, fOrder = @Order, fLevel = @Level, fUrlType = @UrlType, fUrl = @Url, fImage = @ImageUrl, fCssClass = @CssClass, fIsEnable = @IsEnable,  fHasSubMenu = @HasSubMenu, fType = @Type, fRemark = @Remark, fCheckCode = @CheckCode, fObjType = @ObjType Where fID = @Id";
        private const string SQL_MOVE_MENU = "Update mySystemMenu Set fParentId = @ParentId ,fLevel=(select top 1 flevel+1 from mySystemMenu Where fID=@ParentId) Where fID=@Id";
        private const string SQL_DELETE_MENU = "Delete From mySystemMenu Where fId = @Id";
	    private const string SQL_SELECT_ALL_MENU = "Select * From mySystemMenu";
	    private const string SQL_SELECT_ALLAVALIBLE_MENU = "Select * From mySystemMenu Where fIsEnable = 1 Order By fOrder";
	    private const string SQL_SELECT_ALL_BY_PRODUCTCODE = "Select * From mySystemMenu Where fProductID = @ProductCode Order By fOrder";
	    private const string SQL_SELECT_ALLAVALIBLE_BY_PRODUCTCODE = "Select * From mySystemMenu Where fProductID = @ProductCode And fIsEnable = 1 Order By fOrder";
	    private const string SQL_SELECT_ALL_BY_PARENTID = "Select * From mySystemMenu Where fParentId=@ParentID Order By fOrder";
        private const string SQL_SELECT_ALLAVALIBLE_BY_PARENTID = "Select * From mySystemMenu Where fParentId=@ParentID And fIsEnable = 1 Order By fOrder";
	    private const string SQL_SELECT_BY_ID = "Select * From mySystemMenu Where fID = @Id";
	    private const string SQL_SELECT_COUNT_BY_TYPE = "Select Count(*) From mySystemMenu Where fType = @Type";
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
	    private const string PARM_CHECKCODE = "@CheckCode";
	    private const string PARM_OBJTYPE = "@ObjType";
        #endregion

		/// <summary>
		/// ���캯����
		/// </summary>
		public Menu()
		{
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
			return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text,SQL_SELECT_ALL_MENU);
		}
		/// <summary>
		/// ��ȡ������Ч�Ĳ˵��
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetAllAvalibleMenu()
		{
			return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text, SQL_SELECT_ALLAVALIBLE_MENU);
		}
		/// <summary>
		/// ����ָ����ƷID��ȡ���еĲ˵��
		/// </summary>
		/// <param name="productId">��ƷID��</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllMenuByProductId(int productId)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fProductId={0} Order By fOrder",productId);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text,sqlStatement);
		}
		/// <summary>
		/// ����ָ����ƷID��ȡ������Ч�Ĳ˵��
		/// </summary>
		/// <param name="productId">��ƷID��</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllAvalibleMenuByProductId(int productId)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fIsEnable=1 And fProductId={0} Order By fOrder",productId);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text,sqlStatement);
		}

	    /// <summary>
	    /// ���ݲ�Ʒ��Ż�ȡ���е���Ч�Ĳ˵���
	    /// </summary>
	    /// <param name="productCode">��Ʒ��š�</param>
	    /// <returns>�˵����ϡ�</returns>
	    public IList<MenuInfo> GetAllAvalibleByProductCode(int productCode)
	    {
            var sqlStatement = string.Format("Select * From mySystemMenu Where fIsEnable=1 And fProductId={0} Order By fOrder", productCode);
	        var objs = new List<MenuInfo>();
	        var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement);
	        while (dr.Read())
	        {
	            objs.Add(ConvertToMenuInfo(dr));
	        }
            dr.Close();
	        return objs;
	    }

	    /// <summary>
		/// ������һ���˵�ID��ȡ�����Ӳ˵��
		/// </summary>
		/// <param name="parentId">��һ���˵���ID��</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllMenuByParentId(int parentId)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fParentId={0} Order By fOrder",parentId);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text ,sqlStatement);
		}
		/// <summary>
		/// ������һ���˵�ID��ȡ������Ч���Ӳ˵��
		/// </summary>
		/// <param name="parentId">��һ���˵���ID��</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllAvalibleMenuByParentId(int parentId)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fIsEnable = 1 And fParentId={0} Order By fOrder",parentId);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.Text ,sqlStatement);
		}
		/// <summary>
		/// ���ݲ˵���Id��ȡ�˵��
		/// </summary>
		/// <param name="id">�˵���Id</param>
		/// <returns>DataSet</returns>
		public DataSet GetMenuById(int id)
		{
			var sqlStatement = string.Format("Select * From mySystemMenu Where fId = {0}",id);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text, sqlStatement);
		}
		
	    /// <summary>
        /// ���Ӳ˵��
        /// </summary>
        /// <param name="menuInfo">�˵���ʵ�塣</param>
        /// <returns>bool</returns>
		public bool Insert(MenuInfo menuInfo)
		{
		    var parms = GetMenuParameters();
	        parms[0].Value = 0;
		    parms[1].Value = menuInfo.Name;
		    parms[2].Value = menuInfo.Title;
		    parms[3].Value = menuInfo.ProductID;
		    parms[4].Value = menuInfo.RightCode;
		    parms[5].Value = menuInfo.ParentID;
		    parms[6].Value = menuInfo.Order;
		    parms[7].Value = menuInfo.Level;
		    parms[8].Value = menuInfo.URLType;
		    parms[9].Value = string.IsNullOrEmpty(menuInfo.URL)?(object)DBNull.Value:menuInfo.URL;
		    parms[10].Value = string.IsNullOrEmpty(menuInfo.ImageURL)?(object)DBNull.Value:menuInfo.ImageURL;
	        parms[11].Value = string.IsNullOrEmpty(menuInfo.CSSClass) ? (object) DBNull.Value : menuInfo.CSSClass;
		    parms[12].Value = menuInfo.IsEnable;
		    parms[13].Value = menuInfo.HasSubMenu;
		    parms[14].Value = menuInfo.Type;
		    parms[15].Value = string.IsNullOrEmpty(menuInfo.Remark)?(object)DBNull.Value:menuInfo.Remark;
	        parms[16].Value = string.IsNullOrEmpty(menuInfo.CheckCode) ? (object) DBNull.Value : menuInfo.CheckCode;
	        parms[17].Value = string.IsNullOrEmpty(menuInfo.ObjType) ? (object) DBNull.Value : menuInfo.ObjType;
		    try
		    {
		        SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_MENU, parms);
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
        /// �޸Ĳ˵���.
        /// </summary>
        /// <param name="menuInfo">�˵���ʵ�塣</param>
        /// <returns>bool</returns>
        public bool Update(MenuInfo menuInfo)
        {
            var parms = GetMenuParameters();
            parms[0].Value = menuInfo.ID;
            parms[1].Value = menuInfo.Name;
            parms[2].Value = menuInfo.Title;
            parms[3].Value = menuInfo.ProductID;
            parms[4].Value = menuInfo.RightCode;
            parms[5].Value = menuInfo.ParentID;
            parms[6].Value = menuInfo.Order;
            parms[7].Value = menuInfo.Level;
            parms[8].Value = menuInfo.URLType;
            parms[9].Value = menuInfo.URL;
            parms[10].Value = string.IsNullOrEmpty(menuInfo.ImageURL)?(object)DBNull.Value:menuInfo.ImageURL;
            parms[11].Value = string.IsNullOrEmpty(menuInfo.CSSClass)?(object)DBNull.Value:menuInfo.CSSClass;
            parms[12].Value = menuInfo.IsEnable;
            parms[13].Value = menuInfo.HasSubMenu;
            parms[14].Value = menuInfo.Type;
            parms[15].Value = string.IsNullOrEmpty(menuInfo.Remark)?(object)DBNull.Value:menuInfo.Remark;
            parms[16].Value = string.IsNullOrEmpty(menuInfo.CheckCode) ? (object)DBNull.Value : menuInfo.CheckCode;
            parms[17].Value = string.IsNullOrEmpty(menuInfo.ObjType) ? (object)DBNull.Value : menuInfo.ObjType;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_MENU, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// ɾ���˵�ʵ�塣
        /// </summary>
        /// <param name="menuInfo">�˵�ʵ�����</param>
        /// <returns>bool</returns>
        public bool Delete(MenuInfo menuInfo)
        {
            var parms = GetMenuParameters();
            parms[0].Value = menuInfo.ID;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_MENU, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// ɾ���˵��
        /// </summary>
        /// <param name="id">�˵���ID��</param>
        /// <returns>�������͡�</returns>
        public bool Delete(int id)
        {
            var parms = GetMenuParameters();
            parms[0].Value = id;
            
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_MENU, parms);
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// ת�Ʋ˵��
        /// </summary>
        /// <param name="id">�˵���ID��</param>
        /// <param name="newParentId">�µĸ��ڵ�Id��</param>
        /// <returns>bool</returns>
        public bool MoveTo(int id,int newParentId)
        {
            var sqlStatement = string.Format(@"Update mySystemMenu Set fParentId = {0} ,fLevel=(select top 1 flevel+1 from mySystemMenu Where fID={0}) Where fID={1}", newParentId, id);
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// �ж��Ƿ����ָ���˵����͵Ĳ˵��
        /// </summary>
        /// <param name="typeId">�˵�����Id��</param>
        /// <returns>bool</returns>
        public bool IsExistsByType(int typeId)
        {
            var parms = new[] { new SqlParameter("@Type", SqlDbType.Int) { Value = typeId } };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_TYPE,
                                              parms);
            return (int)obj == 0 ? false : true;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// ��ȡInsert��Update����Ĳ������顣
        /// </summary>
        /// <returns>Sql�������顣</returns>
        private static SqlParameter[] GetMenuParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_UPDATE_MENU);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter(PARM_ID, SqlDbType.Int){Direction = ParameterDirection.InputOutput},
                                new SqlParameter(PARM_NAME, SqlDbType.NVarChar, 255),
                                new SqlParameter(PARM_TITLE, SqlDbType.NVarChar, 20),
                                new SqlParameter(PARM_PRODUCTID, SqlDbType.Int),
                                new SqlParameter(PARM_RIGHTCODE,SqlDbType.Int), 
                                new SqlParameter(PARM_PARENTID,SqlDbType.Int), 
                                new SqlParameter(PARM_ORDER,SqlDbType.Int), 
                                new SqlParameter(PARM_LEVEL,SqlDbType.Int), 
                                new SqlParameter(PARM_URLTYPE, SqlDbType.Int), 
                                new SqlParameter(PARM_URL,SqlDbType.NVarChar,255),
                                new SqlParameter(PARM_IMAGE, SqlDbType.NVarChar,255),
                                new SqlParameter(PARM_CSSCLASS,SqlDbType.NVarChar,255), 
                                new SqlParameter(PARM_ISENABLE ,SqlDbType.Int),
                                new SqlParameter(PARM_HASSUBMENU,SqlDbType.Int),
                                new SqlParameter(PARM_TYPE,SqlDbType.Int),
                                new SqlParameter(PARM_REMARK,SqlDbType.Text), 
                                new SqlParameter(PARM_CHECKCODE, SqlDbType.NVarChar,50),
                                new SqlParameter(PARM_OBJTYPE, SqlDbType.NChar,1), 
                            };
                
                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_UPDATE_MENU, parms);
            }
            return parms;
        }

        private static MenuInfo ConvertToMenuInfo(IDataRecord dr)
        {
            var obj = new MenuInfo();
            obj.ID = (int)dr["fID"];
            obj.Name = (string)dr["fName"];
            obj.Title = (string) dr["fTitle"];
            obj.ProductID = (int)dr["fProductID"];
            obj.RightCode = (int) dr["fRightCode"];
            obj.ParentID = (int) dr["fParentID"];
            obj.Order = (int) dr["fOrder"];
            obj.Level = (int) dr["fLevel"];
            obj.URLType = (int) dr["fURLType"];
            obj.URL = (string) dr["fURL"];
            obj.ImageURL = dr["fImage"] == DBNull.Value ? string.Empty : (string) dr["fImage"];
            obj.CSSClass = dr["fCSSClass"] == DBNull.Value ? string.Empty : (string) dr["fCSSClass"];
            obj.IsEnable = (int) dr["fIsEnable"];
            obj.HasSubMenu = (int) dr["fHasSubMenu"];
            obj.Type = (int) dr["fType"];
            obj.Remark = dr["fRemark"] == DBNull.Value ? string.Empty : (string) dr["fRemark"];
            obj.CheckCode = dr["fCheckCode"] == DBNull.Value ? string.Empty : (string) dr["fCheckCode"];
            obj.ObjType = dr["fObjType"] == DBNull.Value ? string.Empty : (string) dr["fObjType"];
            return obj;
        }
        #endregion

        #region IMenu ��Ա

	    

        #endregion
    }
}
