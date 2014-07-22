using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
using log4net;
namespace Shmzh.Monitor.Data.SqlClient
{ 
    public class TagMinute :IDAL.ITagMinute
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private const string SQL_SELECT_BY_TAGID_CYCLEID = @"
Select I_Cycle_Id,I_Tag_Id,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) as I_Value_Man,Max_Value,Min_Value,Upper_Seconds,Lower_Seconds From {0} Where I_Tag_Id='{1}' And I_Cycle_ID >={2} And I_Cycle_ID<={3}";

        private const string SQL_SELECT_BY_TAGIDS_CYCLEID = @"
Select I_Cycle_Id,I_Tag_Id,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) as I_Value_Man,Max_Value,Min_Value,Upper_Seconds,Lower_Seconds  From {0} Where I_Tag_Id in ({1}) And I_Cycle_ID >={2} And I_Cycle_ID<={3}";
        
        private const string SQL_SELECT_LATEST_BY_TAGID = @"
Select top 1 I_Cycle_Id,I_Tag_Id,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) as I_Value_Man,Max_Value,Min_Value,Upper_Seconds,Lower_Seconds  From {0} Where I_Tag_Id = '{1}' Order By I_Cycle_ID Desc";

        private const string SQL_SELECT_LATEST_BY_TAGIDS = @"
Select A.I_Cycle_Id,A.I_Tag_Id,A.I_Value_Org,Round(A.I_Value_Man,dbo.GetDigNum(A.I_Tag_Id)) as I_Value_Man,A.Max_Value,A.Min_Value,A.Upper_Seconds,A.Lower_Seconds  From {0} As A,(Select I_Tag_Id,Max(I_Cycle_ID) as I_Cycle_ID From {0} Where I_Tag_Id In ({1}) Group By I_Tag_Id) As B Where A.I_Tag_Id = B.I_Tag_Id And A.I_Cycle_ID = B.I_Cycle_Id";

        private const string SQL_SELECT_LATEST_ALL = @"
Declare @max_Cycle_Id int
Select  @max_Cycle_Id = max(I_Cycle_Id) From {0}
Select 	I_Cycle_Id,I_Tag_ID,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) as I_Value_Man ,Max_Value,Min_Value,Upper_Seconds,Lower_Seconds
From    {0} 
Where   i_cycle_Id in ( @max_Cycle_Id-1,@max_Cycle_Id)
";
        private const string SQL_SELECT_LATEST_MINUTE_TABLE = @"
Select Replace(Convert(char(10),GetDate(),120),'-','') ";

        #endregion

        #region ITagMinute 成员

        public List<TagMinuteInfo> Get_By_Date_TagId_CycleId(DateTime date, string tagId, int beginCycleId, int endCycleId)
        {
            var objs = new List<TagMinuteInfo>();
            var tableName = string.Format("T_Tag_M{0}", date.ToString("yyyyMMdd"));
            var sqlStatement = string.Format(SQL_SELECT_BY_TAGID_CYCLEID, tableName, tagId, beginCycleId, endCycleId);
            SqlDataReader dr = null;
            using (var conn = new SqlConnection(ConnectionString.Produce))
            {
                try
                {
                    dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlStatement);
                    while (dr.Read())
                    {
                        objs.Add(ConvertToTagMinuteInfo(dr));
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
            return objs;
        }

        public List<TagMinuteInfo> Get_By_Date_TagId_DateTime(DateTime date, string tagId, DateTime beginTime, DateTime endTime)
        {
            return this.Get_By_Date_TagId_CycleId(date, tagId, Gather.DateTime2MinuteCycleId(beginTime),
                                                  Gather.DateTime2MinuteCycleId(endTime));
        }

        public List<TagMinuteInfo> Get_By_Date_TagIds_CycleId(DateTime date, string tagIds, int beginCycleId, int endCycleId)
        {
            var objs = new List<TagMinuteInfo>();

            var tableName = string.Format("T_Tag_M{0}", date.ToString("yyyyMMdd"));
            
            var sqlStatement = string.Format(SQL_SELECT_BY_TAGIDS_CYCLEID, tableName, StringUtil.WrapSingleQuotes(tagIds), beginCycleId, endCycleId);
            SqlDataReader dr = null;
            using (var conn = new SqlConnection(ConnectionString.Produce))
            {
                try
                {
                    dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlStatement);
                    while (dr.Read())
                    {
                        objs.Add(ConvertToTagMinuteInfo(dr));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("{0}:{1}", tagIds, ex.Message));
                }
                finally
                {
                    if (dr != null) dr.Close();
                }
            }
            return objs;
        }

        public List<TagMinuteInfo> Get_By_Date_TagIds_DateTime(DateTime date, string tagIds, DateTime beginTime, DateTime endTime)
        {
            return this.Get_By_Date_TagIds_CycleId(date, tagIds, Gather.DateTime2MinuteCycleId(beginTime),
                                                   Gather.DateTime2MinuteCycleId(endTime));
        }

        public TagMinuteInfo Get_Latest_By_TagId(string tagId)
        {
            TagMinuteInfo obj = null;
            var tableName = GetLatestMinuteTableName();
            if(!string.IsNullOrEmpty(tableName))
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
                            obj = ConvertToTagMinuteInfo(dr);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                    }
                    finally
                    {
                        if(dr != null ) dr.Close();
                    }
                }
            }
            return obj;
        }

        public List<TagMinuteInfo> Get_Latest_By_TagIds(string tagIds)
        {
            var objs = new List<TagMinuteInfo>();
            try
            {
                var tableName = GetLatestMinuteTableName();
                if (!string.IsNullOrEmpty(tableName))
                {
                    var sqlStatement = string.Format(SQL_SELECT_LATEST_BY_TAGIDS, tableName,StringUtil.WrapSingleQuotes(tagIds) );
                    SqlDataReader dr = null;
                    using (var conn = new SqlConnection(ConnectionString.Produce))
                    {
                        try
                        {
                            dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlStatement);
                            while (dr.Read())
                            {
                                objs.Add(ConvertToTagMinuteInfo(dr));
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(string.Format("{0}:{1}", tagIds, ex.Message));
                        }
                        finally
                        {
                            if (dr != null) dr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            
            return objs;
        }

        /// <summary>
        /// 获取所有最新的分钟数据。
        /// </summary>
        /// <returns>分钟数据集合。一个指标对应一条记录。</returns>
        public List<TagMinuteInfo> Get_Latest_All()
        {
            var objs = new List<TagMinuteInfo>();
            try
            {
                var tableName = GetLatestMinuteTableName();
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
                                objs.Add(ConvertToTagMinuteInfo(dr));
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
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
        private static TagMinuteInfo ConvertToTagMinuteInfo(IDataRecord dr)
        {
            var obj = new TagMinuteInfo
                          {
                              I_Cycle_Id = int.Parse(dr["I_Cycle_Id"].ToString()),
                              I_Tag_Id = dr["I_Tag_Id"].ToString(),
                              I_Value_Org = double.Parse(dr["I_Value_Org"].ToString()),
                              I_Value_Man = double.Parse(dr["I_Value_Man"].ToString()),
                              Max_Value = dr["Max_Value"]==DBNull.Value?double.MaxValue:double.Parse(dr["Max_Value"].ToString()),
                              Min_Value = dr["Min_Value"]==DBNull.Value?double.MinValue:double.Parse(dr["Min_Value"].ToString()),
                              Upper_Seconds = dr["Upper_Seconds"]==DBNull.Value?int.MaxValue:int.Parse(dr["Upper_Second"].ToString()),
                              Lower_Seconds = dr["Lower_Seconds"]==DBNull.Value?int.MinValue:int.Parse(dr["Lower_Seconds"].ToString()),
                          };
            return obj;
        }
        /// <summary>
        /// 获取最新的分钟表名称。
        /// </summary>
        /// <returns></returns>
        private static string GetLatestMinuteTableName()
        {
            var tableName = string.Empty;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_LATEST_MINUTE_TABLE);
                while (dr.Read())
                {
                    tableName = dr.GetString(0);
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
            return string.Format("T_Tag_M{0}", tableName);
        }
        #endregion
    }
}
