using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class CategoryItem : IDAL.ICategoryItem
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region ICategoryItem 成员

        /// <summary>
        /// 获取所有分类监控方案.
        /// </summary>
        /// <returns>所有分类监控方案.</returns>
        public List<CategoryItemInfo> GetAll()
        {
            const string sqlStatement = @"SELECT [ItemId],[CategoryId],[Title],[UpdateTime],[ClassName],[ConfigFile],[Code], [SerialNumber] FROM [CategoryItem] ";
            var objs = new List<CategoryItemInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
                while (dr.Read())
                {
                    objs.Add(ConvertToCategoryItemInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 获取由XML文件配置的方案。
        /// </summary>
        /// <returns></returns>
        public List<CategoryItemInfo> GetXmlItemInfo()
        {
            const string sqlStatement = @"SELECT [ItemId],[CategoryId],[Title],[UpdateTime],[ClassName],[ConfigFile],[Code], [SerialNumber]
                                FROM [CategoryItem] WHERE [ConfigFile] LIKE '%.xml' ORDER BY [SerialNumber]";
            var objs = new List<CategoryItemInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
                while (dr.Read())
                {
                    objs.Add(ConvertToCategoryItemInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 获取所有类别条目信息实体集合。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>所有类别条目信息实体集合。</returns>
        public List<CategoryItemInfo> GetByCategoryId(int categoryId)
        {
            const string sqlStatement = @"SELECT [ItemId],[CategoryId],[Title],[UpdateTime],[ClassName],[ConfigFile],[Code], [SerialNumber]
                            FROM [CategoryItem] WHERE [CategoryId] = @CategoryId ORDER BY [SerialNumber]";
            var parms = new[] { new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId } };
            var objs = new List<CategoryItemInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToCategoryItemInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 一个方案可能分到多个分类。
        /// </summary>
        /// <param name="configFile">配置文件名或曲线方案名。</param>
        /// <returns></returns>
        public List<CategoryItemInfo> GetByConfigFile(String configFile)
        {
            const string sqlStatement = @"SELECT [ItemId],[CategoryId],[Title],[UpdateTime],[ClassName],[ConfigFile],[Code], [SerialNumber]
                            FROM [CategoryItem] WHERE [ConfigFile] = @ConfigFile ORDER BY [SerialNumber]";
            var parms = new SqlParameter("@ConfigFile", SqlDbType.NVarChar, 50) { Value = configFile };
            var objs = new List<CategoryItemInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToCategoryItemInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 根据类别条目Id获取类别信息实体。
        /// </summary>
        /// <param name="itemId">类别条目Id。</param>
        /// <returns>类别条目信息实体。</returns>
        public CategoryItemInfo GetById(Int32 itemId)
        {
            const string sqlStatement = @"SELECT [ItemId],[CategoryId],[Title],[UpdateTime],[ClassName],[ConfigFile],[Code], [SerialNumber]
                                            FROM [CategoryItem] WHERE [ItemId] = @ItemId";
            var parms = new[] { new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemId } };
            CategoryItemInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToCategoryItemInfo(dr);
                    break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            } 
            finally
            {
                if (dr != null) dr.Close();
            }
            return obj;
        }

        /// <summary>
        /// 根据类别条目编号获取类别信息实体。
        /// </summary>
        /// <param name="code">类别条目编号。</param>
        /// <returns>类别条目信息实体。</returns>
        public CategoryItemInfo GetByCode(String code)
        {
            if (String.IsNullOrEmpty(code))
                return null;
            const string sqlStatement = @"SELECT [ItemId],[CategoryId],[Title],[UpdateTime],[ClassName],[ConfigFile],[Code], [SerialNumber]
                                        FROM [CategoryItem] WHERE [Code] = @Code";
            var parms = new[] { new SqlParameter("@Code", SqlDbType.NVarChar, 30) { Value = code } };
            CategoryItemInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToCategoryItemInfo(dr);
                    break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return obj;
        }

        /// <summary>
        /// 根据类别条目Id进行删除。
        /// </summary>
        /// <param name="itemId">类别条目Id。</param>
        /// <returns>bool</returns>
        public Boolean Delete(Int32 itemId)
        {
            const string sqlStatement = @"UPDATE A SET [SerialNumber] = A.[SerialNumber] - 1 FROM [CategoryItem] A
                                INNER JOIN [CategoryItem] B ON A.[CategoryId] = B.[CategoryId] AND A.[SerialNumber] > B.[SerialNumber]
                                WHERE B.[ItemId] = @ItemId
                                DELETE FROM [CategoryItem] WHERE [ItemId] = @ItemId";
            var parms = new[] { new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemId } };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public int Insert(CategoryItemInfo entity)
        {
            const string sqlStatement = @"DECLARE @SerialNumber int SELECT @SerialNumber = ISNULL(MAX([SerialNumber]),0) + 1 FROM [CategoryItem] WHERE [CategoryId] = @CategoryId
                                INSERT INTO [CategoryItem]([CategoryId],[Title],[UpdateTime],[ClassName],[ConfigFile],[Code],[SerialNumber])
                                VALUES (@CategoryId, @Title, @UpdateTime, @ClassName, @ConfigFile,@Code,@SerialNumber) SET @ItemId = SCOPE_IDENTITY()";
            var parms = new[] { 
                new SqlParameter("@ItemId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = entity.CategoryId },
                new SqlParameter("@Title", SqlDbType.NVarChar, 100) { Value = entity.Title },
                new SqlParameter("@UpdateTime", SqlDbType.Int) { Value = entity.UpdateTime },
                new SqlParameter("@ClassName", SqlDbType.NVarChar, 100) { Value = entity.ClassName },
                new SqlParameter("@ConfigFile", SqlDbType.NVarChar, 50) { Value = entity.ConfigFile },
                new SqlParameter("@Code", SqlDbType.NVarChar, 30) { Value = String.IsNullOrEmpty(entity.Code) ? (object)DBNull.Value : entity.Code },
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                entity.ItemId = Convert.ToInt32(parms[0].Value);
                return entity.ItemId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 修改类别条目信息实体。
        /// </summary>
        /// <param name="entity">类别条目信息实体对象。</param>
        /// <returns>bool</returns>
        public bool Update(CategoryItemInfo entity)
        {
            return this.Update(null, entity);
        }

        /// <summary>
        /// 修改类别条目信息实体
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="entity">类别条目信息实体对象</param>
        /// <returns>bool</returns>
        public Boolean Update(SqlTransaction trans, CategoryItemInfo entity)
        {
            const string sqlStatement = @"UPDATE [CategoryItem] SET [CategoryId]=@CategoryId,[Title]=@Title,[UpdateTime]=@UpdateTime,[ClassName]=@ClassName,[ConfigFile]=@ConfigFile,[Code]=@Code
                WHERE [ItemId] = @ItemId";
            var parms = new[] { 
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = entity.CategoryId },
                new SqlParameter("@Title", SqlDbType.NVarChar, 100) { Value = entity.Title },
                new SqlParameter("@UpdateTime", SqlDbType.Int) { Value = entity.UpdateTime },
                new SqlParameter("@ClassName", SqlDbType.NVarChar, 100) { Value = entity.ClassName },
                new SqlParameter("@ConfigFile", SqlDbType.NVarChar, 50) { Value = entity.ConfigFile },
                new SqlParameter("@ItemId", SqlDbType.Int) { Value = entity.ItemId },
                new SqlParameter("@Code", SqlDbType.NVarChar, 30) { Value = String.IsNullOrEmpty(entity.Code) ? (object)DBNull.Value : entity.Code },
            };
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                else
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 方案分类条目移动。
        /// </summary>
        /// <param name="itemId">ItemId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public Boolean Move(Int32 itemId, Byte opType)
        {
            var parms = new[] { 
                new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemId },
                new SqlParameter("@OpType", SqlDbType.TinyInt) { Value = opType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.StoredProcedure, "CategoryItem_Move", parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        #endregion
        
        #region private method
        /// <summary>
        /// 将IDataRecord转换为CategoryItemInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>CategoryItemInfo对象。</returns>
        static CategoryItemInfo ConvertToCategoryItemInfo(IDataRecord dr)
        {
            var obj = new CategoryItemInfo
                          {
                              ItemId = Convert.ToInt32(dr["ItemId"]),
                              CategoryId = Convert.ToInt32(dr["CategoryId"]),
                              Title = dr["Title"].ToString(),
                              UpdateTime = Convert.ToInt32(dr["UpdateTime"]),
                              ClassName = (dr["ClassName"] == DBNull.Value ? String.Empty : dr["ClassName"].ToString()),
                              ConfigFile = (dr["ConfigFile"] == DBNull.Value ? String.Empty : dr["ConfigFile"].ToString()),
                              Code = (dr["Code"] == DBNull.Value ? String.Empty : dr["Code"].ToString()),
                              SerialNumber = Convert.ToInt32(dr["SerialNumber"]),
                          };
            return obj;
        }
        #endregion

    }
}
