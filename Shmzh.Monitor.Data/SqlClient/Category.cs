using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class Category : IDAL.ICategory
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region ICategory 成员

        /// <summary>
        /// 获取所有类别信息实体集合。
        /// </summary>
        /// <returns>所有类别信息实体集合。</returns>
        public List<CategoryInfo> GetAll()
        {
            const string sqlStatement = @"SELECT [CategoryId],[CategoryName],[Remark],[RightCode],[IsPublic],[SerialNumber]
                        FROM [Category] ORDER BY [SerialNumber]";
            var objs = new List<CategoryInfo>();
            SqlDataReader dr = null;
            try
            {
                //Logger.Info(ConnectionString.Monitor);
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement);
                while (dr.Read())
                {
                    objs.Add(ConvertToCategoryInfo(dr));
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
        /// 根据类别Id获取类别信息实体。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>类别信息实体。</returns>
        public CategoryInfo GetById(Int32 categoryId)
        {
            const string sqlStatement = @"SELECT [CategoryId],[CategoryName],[Remark],[RightCode],[IsPublic],[SerialNumber]
                                        FROM [Category] WHERE [CategoryId] = @CategoryId";
            var parms = new[] { new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId } };
            CategoryInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToCategoryInfo(dr);
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
        /// 根据类别Id进行删除。
        /// </summary>
        /// <param name="categoryId">类别Id。</param>
        /// <returns>bool</returns>
        public Boolean Delete(Int32 categoryId)
        {
            const string sqlStatement = @"DELETE FROM [CategoryItem] WHERE [CategoryId] = @CategoryId
                                        UPDATE [Category] SET [SerialNumber] = [SerialNumber] - 1 WHERE [SerialNumber] > (SELECT [SerialNumber] FROM [Category] WHERE [CategoryId] = @CategoryId)
                                        DELETE FROM [Category] WHERE [CategoryId] = @CategoryId";
            var parms = new[] { new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId } };
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

        /// <summary>
        /// 添加类别信息实体。
        /// </summary>
        /// <param name="entity">类别信息实体对象。</param>
        /// <returns>int</returns>
        public int Insert(CategoryInfo entity)
        {
            const string sqlStatement = @"DECLARE @SerialNumber int SELECT @SerialNumber = ISNULL(MAX([SerialNumber]),0) + 1 FROM [Category]
                            INSERT INTO [Category] ([CategoryName],[Remark],[RightCode],[IsPublic],[SerialNumber])
                            VALUES (@CategoryName,@Remark,@RightCode,@IsPublic,@SerialNumber) SET @CategoryId = SCOPE_IDENTITY()";
            var parms = new[] { 
                new SqlParameter("@CategoryId",SqlDbType.Int){Direction=ParameterDirection.Output},
                new SqlParameter("@CategoryName", SqlDbType.NVarChar, 50) { Value = entity.CategoryName },
                new SqlParameter("@Remark", SqlDbType.NVarChar, 200) { Value = entity.Remark },
                new SqlParameter("@RightCode", SqlDbType.SmallInt) { Value = entity.RightCode },
                new SqlParameter("@IsPublic", SqlDbType.Bit) { Value = entity.IsPublic },
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.Text, sqlStatement, parms);
                entity.CategoryId = (int)parms[0].Value;
                return entity.CategoryId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 修改类别信息实体。
        /// </summary>
        /// <param name="entity">类别信息实体对象。</param>
        /// <returns>bool</returns>
        public Boolean Update(CategoryInfo entity)
        {
            const string sqlStatement = @"UPDATE [Category] SET [CategoryName] = @CategoryName,[Remark] = @Remark,[RightCode]=@RightCode, [IsPublic] = @IsPublic
                WHERE [CategoryId] = @CategoryId";
            var parms = new[] { 
                new SqlParameter("@CategoryName", SqlDbType.NVarChar, 50) { Value = entity.CategoryName },
                new SqlParameter("@Remark", SqlDbType.NVarChar, 200) { Value = entity.Remark },
                new SqlParameter("@RightCode", SqlDbType.SmallInt) { Value = entity.RightCode },
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = entity.CategoryId },    
                new SqlParameter("@IsPublic", SqlDbType.Bit) { Value = entity.IsPublic },
            };
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

        /// <summary>
        /// 方案分类移动。
        /// </summary>
        /// <param name="categoryId">CategoryId。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public Boolean Move(Int32 categoryId, Byte opType)
        {
            var parms = new[] { 
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId },
                new SqlParameter("@OpType", SqlDbType.TinyInt) { Value = opType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Monitor, CommandType.StoredProcedure, "Category_Move", parms);
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
        /// 将IDataRecord转换为CategoryInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>CategoryInfo对象。</returns>
        static CategoryInfo ConvertToCategoryInfo(IDataRecord dr)
        {
            var obj = new CategoryInfo
                          {
                              CategoryId = Convert.ToInt32(dr["CategoryId"]),
                              CategoryName = dr["CategoryName"].ToString(),
                              Remark = (dr["Remark"] == DBNull.Value ? String.Empty : dr["Remark"].ToString()),
                              RightCode = Convert.ToInt16(dr["RightCode"]),
                              IsPublic = Convert.ToBoolean(dr["IsPublic"]),
                              SerialNumber = Convert.ToInt32(dr["SerialNumber"]),
                          };
            return obj;
        }
        #endregion

    }
}
