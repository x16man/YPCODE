using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class TagCategory : IDAL.ITagCategory
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region IGraphScheme 成员

        public List<TagCategoryInfo> GetAll()
        {
            const string strSql = @"SELECT [CategoryId],[CategoryName],[ParentId],[SerialNumber] FROM [T_Tag_Category] ORDER BY [ParentId],[SerialNumber]";
            var objs = new List<TagCategoryInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, strSql);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagCategoryInfo(dr));
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

        public List<TagCategoryInfo> GetByParentId(int parentId)
        {
            const string strSql = @"SELECT [CategoryId],[CategoryName],[ParentId],[SerialNumber] FROM [T_Tag_Category] WHERE [ParentId] = @ParentId
ORDER BY [ParentId],[SerialNumber]";
            var parms = new[] { new SqlParameter("@ParentId", SqlDbType.Int) { Value = parentId } };
            var objs = new List<TagCategoryInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, strSql, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagCategoryInfo(dr));
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

        public TagCategoryInfo GetById(Int32 categoryId)
        {
            const string sqlStatement = @"SELECT [CategoryId],[CategoryName],[ParentId],[SerialNumber] FROM [T_Tag_Category] ORDER BY [ParentId],[SerialNumber] WHERE [CategoryId] = @CategoryId";
            var parms = new[] { new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId } };
            TagCategoryInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    obj = ConvertToTagCategoryInfo(dr);
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

        public Boolean Delete(Int32 categoryId)
        {
            const string sqlStatement = @"DECLARE @ParentId int, @SerialNumber int
SELECT @ParentId = [ParentId], @SerialNumber = [SerialNumber] FROM [T_Tag_Category] WHERE [CategoryId] = @CategoryId
UPDATE [T_Tag_Category] SET [SerialNumber] = [SerialNumber] - 1 WHERE [ParentId] = @ParentId AND [SerialNumber] > @SerialNumber
DELETE FROM [T_Tag_Category] WHERE [CategoryId] = @CategoryId";
            var parms = new[] { new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId } };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public int Insert(TagCategoryInfo entity)
        {
            const string sqlStatement = @"DECLARE @SerialNumber INT SET @SerialNumber = (SELECT ISNULL(MAX([SerialNumber]),0) + 1 FROM [T_Tag_Category] WHERE [ParentId] = @ParentId)
INSERT INTO [T_Tag_Category] ([CategoryName],[ParentId],[SerialNumber])
      VALUES (@CategoryName,@ParentId,@SerialNumber) SET @CategoryId = SCOPE_IDENTITY()";
            var parms = new[] { 
                new SqlParameter("@CategoryId",SqlDbType.Int){Direction=ParameterDirection.Output},
                new SqlParameter("@CategoryName", SqlDbType.NVarChar, 50) { Value = entity.CategoryName },
                new SqlParameter("@ParentId", SqlDbType.Int) { Value = entity.ParentId },
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                entity.CategoryId = (int)parms[0].Value;
                return entity.CategoryId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        public Boolean Update(TagCategoryInfo entity)
        {
            const string sqlStatement = @"UPDATE [T_Tag_Category] SET [CategoryName]=@CategoryName,[ParentId]=@ParentId,[SerialNumber]=@SerialNumber
                WHERE [CategoryId] = @CategoryId";
            var parms = new[] { 
                new SqlParameter("@CategoryName", SqlDbType.NVarChar, 50) { Value = entity.CategoryName },
                new SqlParameter("@ParentId", SqlDbType.Int) { Value = entity.ParentId },
                new SqlParameter("@SerialNumber", SqlDbType.Int) { Value = entity.SerialNumber },
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = entity.CategoryId }, 
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 上移或下移。
        /// </summary>
        /// <param name="categoryId">要移动的指标类别Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public bool MoveUpDown(Int32 categoryId, byte opType)
        {
            var sqlStatement = "DECLARE @SerialNumber INT, @ParentId INT SELECT @SerialNumber = [SerialNumber], @ParentId = [ParentId] FROM [T_Tag_Category] WHERE [CategoryId] = @CategoryId";
            if (opType == 0)
            { 
                sqlStatement += @" IF EXISTS (SELECT 1 FROM T_Tag_Category WHERE [ParentId] = @ParentId AND [SerialNumber] = @SerialNumber - 1)
BEGIN
    UPDATE [T_Tag_Category] SET [SerialNumber] = @SerialNumber WHERE [ParentId] = @ParentId AND [SerialNumber] = @SerialNumber - 1
    UPDATE [T_Tag_Category] SET [SerialNumber] = [SerialNumber] - 1 WHERE [CategoryId] = @CategoryId
END";
            }
            else if (opType == 1)
            {
                sqlStatement += @" IF EXISTS (SELECT 1 FROM T_Tag_Category WHERE [ParentId] = @ParentId AND [SerialNumber] = @SerialNumber + 1)
BEGIN
    UPDATE [T_Tag_Category] SET [SerialNumber] = @SerialNumber WHERE [ParentId] = @ParentId AND [SerialNumber] = @SerialNumber + 1
    UPDATE [T_Tag_Category] SET [SerialNumber] = [SerialNumber] + 1 WHERE [CategoryId] = @CategoryId
END";
            }
            else
            {
                return false;
            }
            var parms = new[] {
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId }, 
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 移动某指标类别到另一个类别下。
        /// </summary>
        /// <param name="moveCategoryId">要移动的指标类别Id。</param>
        /// <param name="targetCategoryId">作为父类别的类别Id。</param>
        /// <returns></returns>
        public bool Move(int moveCategoryId, int targetCategoryId)
        {
            const string sqlStatement = @"DECLARE @SerialNumber INT, @ParentId INT SELECT @ParentId = [ParentId], @SerialNumber = [SerialNumber] FROM [T_Tag_Category] WHERE [CategoryId] = @CategoryId
UPDATE [T_Tag_Category] SET [ParentId] = @TargetCategoryId, [SerialNumber] = (SELECT ISNULL(MAX([SerialNumber]),0) + 1 FROM [T_Tag_Category] WHERE [ParentId] = @TargetCategoryId) WHERE [CategoryId] = @CategoryId
UPDATE [T_Tag_Category] SET [SerialNumber] = [SerialNumber] - 1 WHERE [ParentId] = @ParentId AND [SerialNumber] > @SerialNumber";
            var parms = new[] {
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = moveCategoryId }, 
                new SqlParameter("@TargetCategoryId", SqlDbType.Int) { Value = targetCategoryId }, 
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
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
        /// 将IDataRecord转换为TagCategoryInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>TagCategoryInfo对象。</returns>
        static TagCategoryInfo ConvertToTagCategoryInfo(IDataRecord dr)
        {
            var obj = new TagCategoryInfo
                          {
                              CategoryId = Convert.ToInt32(dr["CategoryId"]),
                              CategoryName = dr["CategoryName"].ToString(),   
                              ParentId = Convert.ToInt32(dr["ParentId"]),
                              SerialNumber = Convert.ToInt32(dr["SerialNumber"]),
                          };
            return obj;
        }
        #endregion

    }
}
