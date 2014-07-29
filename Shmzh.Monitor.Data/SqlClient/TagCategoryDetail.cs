using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class TagCategoryDetail : IDAL.ITagCategoryDetail
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region IGraphScheme 成员        
        public List<TagCategoryDetailInfo> GetByCategoryId(int categoryId)
        {
            const string strSql = @"SELECT [CategoryId],[TagId] FROM [T_Tag_CategoryDetail] WHERE [CategoryId] = @CategoryId";
            var parms = new[] { new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId } };
            var objs = new List<TagCategoryDetailInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, strSql, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagCategoryDetailInfo(dr));
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

        public List<TagInfo> GetTagsByCategoryId(int categoryId)
        {
            const string strSql = @"SELECT A.[CategoryId], [I_TAG_ID],[I_TAG_NAME],[I_DIG_NUM],[I_UNIT],[I_TAG_TYPE],
      [CALC_TYPE_BEFORE_HOUR],[CALC_TYPE_AFTER_HOUR],[SECOND_TO_MINUTE],
      [MINUTE_TO_MIN5],[MINUTE_TO_HOUR],[HOUR_TO_DAY],[DAY_TO_MONTH],
      [MONTH_TO_YEAR],[REMARK],[FUNC],[DEV_CODE],[MAX_VALUE],
      [MIN_VALUE],[IsBackUp] FROM [T_Tag_CategoryDetail] A
INNER JOIN [T_Tag_Ms] B ON A.[TagId] = B.[I_TAG_ID]
WHERE A.[CategoryId] = @CategoryId";
            var parms = new[] { new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId } };
            var objs = new List<TagInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, strSql, parms);
                while (dr.Read())
                {
                    objs.Add(Tag.ConvertToTagInfo(dr));
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
        /// 添加重设指定类别所包含的指标。
        /// </summary>
        /// <param name="categoryId">指标类别Id。</param>
        /// <param name="tagIds">所包含指标的Id数组。</param>
        /// <returns>bool</returns>
        public Boolean Reset(int categoryId, String[] tagIds)
        {
            var sqlStatement = @"DELETE FROM [T_Tag_CategoryDetail] WHERE [CategoryId] = @CategoryId";
            var parms = new[] { 
                new SqlParameter("@CategoryId",SqlDbType.Int){ Value = categoryId },
            };
            var conn = new SqlConnection(ConnectionString.Produce);
            conn.Open();
            var trans = conn.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlStatement, parms);
                foreach (String tagId in tagIds)
                {
                    sqlStatement = @"INSERT INTO [T_Tag_CategoryDetail] ([CategoryId],[TagId]) VALUES (@CategoryId, @TagId)";
                    parms = new[] { 
                        new SqlParameter("@CategoryId",SqlDbType.Int){ Value = categoryId },
                        new SqlParameter("@TagId",SqlDbType.VarChar, 8){ Value = tagId },
                    };
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlStatement, parms);
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Logger.Error(ex.Message);
                return false;
            }
            finally 
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion
        
        #region private method
        /// <summary>
        /// 将IDataRecord转换为TagCategoryDetailInfo对象。
        /// </summary>
        /// <param name="dr">IDataRecord对象。</param>
        /// <returns>TagCategoryDetailInfo对象。</returns>
        static TagCategoryDetailInfo ConvertToTagCategoryDetailInfo(IDataRecord dr)
        {
            var obj = new TagCategoryDetailInfo
                          {
                              CategoryId = Convert.ToInt32(dr["CategoryId"]),
                              TagId = dr["TagId"].ToString(),
                          };
            return obj;
        }
        #endregion

    }
}
