using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.Util;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class TagSecond :IDAL.ITagSecond
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_SELECT_LATEST_BY_TAGID = @"
Select  top 1 I_Cycle_Id,I_Tag_Id,I_Value_0,Round(I_Value_1,dbo.GetDigNum(I_Tag_Id)) as I_Value_1 
From    {0} 
Where   I_Tag_Id = '{1}' 
Order By I_Cycle_ID Desc";

//        private const string SQL_SELECT_LATEST_BY_TAGIDS =
//            @"
//Select  A.I_Cycle_Id,A.I_Tag_Id,A.I_Value_0,Round(A.I_Value_1,dbo.GetDigNum(A.I_Tag_Id)) as I_Value_1 
//From    {0} As A
//Where   A.I_Tag_Id In ({1}) And 
//        A.I_Cycle_Id  = (Select Max(I_Cycle_Id) - 5 From {0})";

        private const string SQL_SELECT_LATEST_ALL = @"
DECLARE @max_Cycle_Id INT
SELECT @max_Cycle_Id = MAX(I_Cycle_Id) From {0}

Select 	a.I_Cycle_Id,a.I_Tag_ID,a.I_Value_0,
	Round(A.I_Value_1,dbo.GetDigNum(A.I_Tag_Id)) as I_Value_1 
from 	{0} a 
Where I_Cycle_Id In (@max_Cycle_Id,@max_Cycle_Id-1)	
";

        private const string SQL_SELECT_LATEST_SECOND_TABLE = @"
Select Replace(Convert(char(10),GetDate(),120),'-','') ";
        #endregion


        #region ITagSecond 成员

        public Shmzh.Monitor.Entity.TagSecondInfo Get_Latest_By_TagId(string tagId)
        {
            TagSecondInfo obj = null;
            var tableName = GetLatestSecondTableName();
            if (!string.IsNullOrEmpty(tableName))
            {
                var sqlStatement = string.Format(SQL_SELECT_LATEST_BY_TAGID, tableName, tagId);
                SqlDataReader dr = null;
                using (var conn = new SqlConnection(ConnectionString.Produce))
                {
                    try
                    {

                        dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlStatement);
                        while (dr.Read())
                        {
                            obj = ConvertToTagSecondInfo(dr);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(string.Format("{0}:{1}", tagId, ex.Message));
                    }
                    finally
                    {
                        if (dr != null) dr.Close();
                    }
                }
            }
            return obj;
        }

        //public List<Shmzh.Monitor.Entity.TagSecondInfo> Get_Latest_By_TagIds(string tagIds)
        //{
        //    var objs = new List<TagSecondInfo>();

        //    var tableName = GetLatestSecondTableName();
        //    if (!string.IsNullOrEmpty(tableName))
        //    {
        //        var sqlStatement = string.Format(SQL_SELECT_LATEST_BY_TAGIDS, tableName, StringUtil.WrapSingleQuotes(tagIds));
        //        Logger.Info(sqlStatement);
        //        SqlDataReader dr = null;

        //        using (var conn = new SqlConnection(ConnectionString.Produce))
        //        {
        //            try
        //            {
        //                dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlStatement);
        //                while (dr.Read())
        //                {
        //                    objs.Add(ConvertToTagSecondInfo(dr));
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(string.Format("{0}:{1}", tagIds, ex.Message));
        //            }
        //            finally
        //            {
        //                if (dr != null) dr.Close();
        //            }
        //        }
        //    }
        //    return objs;
        //}

        public List<Shmzh.Monitor.Entity.TagSecondInfo> Get_Latest_By_TagIds(string tagIds)
        {
            var objs = new List<TagSecondInfo>();

            var tableName = GetLatestSecondTableName();

            tagIds = StringUtil.WrapSingleQuotes(tagIds);
            String[] arrTagIds = tagIds.Split(',');

            String strSQL = @"
Select A.I_Cycle_Id,A.I_Tag_Id,A.I_Value_0,Round(A.I_Value_1,dbo.GetDigNum(A.I_Tag_Id)) as I_Value_1 
From {0} As A
INNER JOIN ({1}) B ON A.I_Tag_Id = B.I_Tag_Id AND A.I_Cycle_Id = B.I_Cycle_Id";

            if (!string.IsNullOrEmpty(tableName))
            {
                String tempSql = "";
                for (var i = 0; i < arrTagIds.Length; i++)
                {
                    if (tempSql.Length > 0) tempSql += " UNION ";
                    tempSql += String.Format(@"SELECT {0} AS [I_Tag_Id], MAX([I_Cycle_Id]) AS [I_Cycle_Id] FROM {1} WHERE [I_Tag_Id] = {0}", arrTagIds[i], tableName);
                }

                var sqlStatement = string.Format(strSQL, tableName, tempSql);
                //Logger.Info(sqlStatement);
                SqlDataReader dr = null;

                using (var conn = new SqlConnection(ConnectionString.Produce))
                {
                    try
                    {
                        dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlStatement);
                        while (dr.Read())
                        {
                            objs.Add(ConvertToTagSecondInfo(dr));
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.Error(string.Format("{0}:{1}", sqlStatement, ex.Message));
                        Logger.Error(string.Format("{0}:{1}", tagIds, ex.Message));
                    }
                    finally
                    {
                        if (dr != null) dr.Close();
                    }
                }
            }
            return objs;
        }

        /// <summary>
        /// 获取所有指标的最新秒数据。
        /// </summary>
        /// <returns>秒数据集合。一个指标对应一条记录。</returns>
        public List<TagSecondInfo> Get_Latest_All()
        {
            var objs = new List<TagSecondInfo>();

            var tableName = GetLatestSecondTableName();
            if (!string.IsNullOrEmpty(tableName))
            {
                var sqlStatement = string.Format(SQL_SELECT_LATEST_ALL, tableName);
                Logger.Debug(sqlStatement);
                SqlDataReader dr = null;

                using (var conn = new SqlConnection(ConnectionString.Produce))
                {
                    try
                    {
                        dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlStatement);
                        while (dr.Read())
                        {
                            objs.Add(ConvertToTagSecondInfo(dr));
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                    }
                    finally
                    {
                        if (dr != null) dr.Close();
                    }
                }
            }
            return objs;
        }

        #endregion

        #region Private Method
        /// <summary>
        /// 将DataRow转换为分钟数据实体。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>分钟数据实体。</returns>
        private static TagSecondInfo ConvertToTagSecondInfo(IDataRecord dr)
        {
            var obj = new TagSecondInfo
            {
                I_Cycle_Id = int.Parse(dr["I_Cycle_Id"].ToString()),
                I_Tag_Id = dr["I_Tag_Id"].ToString(),
                I_Value_0 = double.Parse(dr["I_Value_0"].ToString()),
                I_Value_1 = double.Parse(dr["I_Value_1"].ToString()),
            };
            return obj;
        }
        /// <summary>
        /// 获取最新的分钟表名称。
        /// </summary>
        /// <returns></returns>
        private static string GetLatestSecondTableName()
        {
            var tableName = string.Empty;
            var dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_LATEST_SECOND_TABLE);
            while (dr.Read())
            {
                tableName = dr.GetString(0);
                break;
            }
            dr.Close();
            return string.Format("T_Tag_S{0}", tableName);
        }
        #endregion
    }
}
