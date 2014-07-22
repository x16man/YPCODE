using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class TagHour :IDAL.ITagHour
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_SELECT_BY_TAGID_CYCLEID = @"
Declare @current_cycle_id int, @TmpEndCycleId int
Set @current_cycle_id = dbo.DateTime2HourCycleId(getdate())
SELECT @TmpEndCycleId = CASE WHEN @EndCycleId > @current_cycle_id THEN @current_cycle_id ELSE @EndCycleId END

Select I_Cycle_Id,I_Tag_Id,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) As I_Value_Man,Max_Value,Min_Value,Upper_Seconds,Lower_Seconds,Begin_Value,End_Value 
From T_Tag_Hour Where I_Tag_Id = @I_Tag_Id And I_Cycle_Id>=@BeginCycleId And I_Cycle_Id <=@TmpEndCycleId";
        private const string SQL_SELECT_BY_TAGIDS_CYCLEID = @"
Declare @current_cycle_id int, @TmpEndCycleId int
Set @current_cycle_id = dbo.DateTime2HourCycleId(getdate())
SELECT @TmpEndCycleId = CASE WHEN @EndCycleId > @current_cycle_id THEN @current_cycle_id ELSE @EndCycleId END

Select I_Cycle_Id,I_Tag_Id,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) As I_Value_Man,Max_Value,Min_Value,Upper_Seconds,Lower_Seconds,Begin_Value,End_Value 
From T_Tag_Hour Where I_Tag_Id In ({0}) And  I_Cycle_Id>=@BeginCycleId And I_Cycle_Id <=@TmpEndCycleId";
        private const string SQL_SELECT_LATEST_BY_TAGID = @"Select Top 1 I_Cycle_Id,I_Tag_Id,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) As I_Value_Man,Max_Value,Min_Value,Upper_Seconds,Lower_Seconds,Begin_Value,End_Value From T_Tag_Hour Where I_Tag_Id =@I_Tag_Id And I_Cycle_Id>= (@I_CycleId-1) And I_Cycle_Id <=@I_Cycle_Id Order By I_Cycle_Id Desc";
        private const string SQL_SELECT_LATEST_BY_TAGIDS = @"
Select  A.I_Cycle_Id,A.I_Tag_Id,A.I_Value_Org,Round(A.I_Value_Man,dbo.GetDigNum(A.I_Tag_Id)) As I_Value_Man,A.Max_Value,A.Min_Value,A.Upper_Seconds,A.Lower_Seconds,A.Begin_Value,A.End_Value
From    T_Tag_Hour A,
        (Select I_Tag_Id,Max(I_Cycle_Id) As I_Cycle_Id From T_Tag_Hour Where I_Tag_Id In ({0}) And I_Cycle_id>= @I_Cycle_Id -1 And I_Cycle_Id <= @I_Cycle_Id Group By I_Tag_Id) As B 
Where   A.I_Tag_Id = B.I_Tag_Id And 
        A.I_Cycle_Id = B.I_Cycle_Id";
        private const string SQL_SELECT_LATEST_ALL = @"
Declare @current_cycle_id int
Set @current_cycle_id = dbo.DateTime2HourCycleId(getdate())
Declare @max_Cycle_Id int
Select @max_Cycle_Id = max(I_Cycle_Id) From t_tag_hour where i_cycle_id<=@current_cycle_id

Select  A.I_Cycle_Id,A.I_Tag_Id,A.I_Value_Org,Round(A.I_Value_Man,dbo.GetDigNum(A.I_Tag_Id)) As I_Value_Man,
        A.Max_Value,A.Min_Value,A.Upper_Seconds,A.Lower_Seconds,A.Begin_Value,A.End_Value
From 	(Select * from t_tag_hour Where i_cycle_Id in ( @max_Cycle_Id,@max_Cycle_Id-1)) as a,
	(Select i_tag_id,max(i_cycle_id) as i_cycle_id from t_tag_hour Where i_cycle_Id in ( @max_Cycle_Id,@max_Cycle_Id-1) group by i_tag_id) as b
Where A.i_tag_id = B.i_Tag_id And
	A.i_cycle_id = B.i_cycle_id";
        #endregion

        #region ITagHour 成员

        public List<TagHourInfo> Get_BY_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            SqlDataReader dr = null;
            var objs = new List<TagHourInfo>();
            var parms = new[]
                            {
                                new SqlParameter("@I_Tag_Id", SqlDbType.VarChar, 8) {Value = tagId},
                                new SqlParameter("@BeginCycleId", SqlDbType.Int) {Value = beginCycleId},
                                new SqlParameter("@EndCycleId", SqlDbType.Int) {Value = endCycleId}
                            };
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_BY_TAGID_CYCLEID,
                                                     parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagHourInfo(dr));
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
            return objs;
        }

        public List<TagHourInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return this.Get_BY_TagId_CycleId(tagId, Gather.DateTime2HourCycleId(beginTime),
                                             Gather.DateTime2HourCycleId(endTime));
        }

        public List<TagHourInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            SqlDataReader dr = null;
            var objs = new List<TagHourInfo>();
            var sqlStatement = string.Format(SQL_SELECT_BY_TAGIDS_CYCLEID, StringUtil.WrapSingleQuotes(tagIds));
            var parms = new[]
                            {
                                new SqlParameter("@BeginCycleId", SqlDbType.Int) {Value = beginCycleId},
                                new SqlParameter("@EndCycleId", SqlDbType.Int) {Value = endCycleId}
                            };

            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement,
                                                     parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagHourInfo(dr));
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
            return objs;
        }

        public List<TagHourInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return this.Get_By_TagIds_CycleId(tagIds, Gather.DateTime2HourCycleId(beginTime),
                                              Gather.DateTime2HourCycleId(endTime));
        }

        public TagHourInfo Get_Latest_By_TagId(string tagId)
        {
            SqlDataReader dr = null;
            TagHourInfo obj = null;
            var parms = new[]
                            {
                                new SqlParameter("@I_Tag_Id", SqlDbType.VarChar, 8) {Value = tagId},
                                new SqlParameter("@I_Cycle_Id", SqlDbType.Int){Value = Gather.DateTime2HourCycleId(DataProvider.TagProvider.GetDate())},
                            };

            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_LATEST_BY_TAGID,parms);
                Logger.Debug(string.Format("{0},{1},{2}",SQL_SELECT_LATEST_BY_TAGID,parms[0].Value,parms[1].Value));
                while (dr.Read())
                {
                    obj = ConvertToTagHourInfo(dr);
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
            return obj;
        }

        public List<TagHourInfo> Get_Latest_By_TagIds(string tagIds)
        {
            var sqlStatement = string.Format(SQL_SELECT_LATEST_BY_TAGIDS, StringUtil.WrapSingleQuotes(tagIds));
            var parms = new[]
                            {
                                new SqlParameter("@I_Cycle_Id", SqlDbType.Int){Value = Gather.DateTime2HourCycleId(DataProvider.TagProvider.GetDate())},
                            };
            var objs = new List<TagHourInfo>();
            SqlDataReader dr = null;
            try
            {
                Logger.Debug(sqlStatement+"/r/n"+parms[0].Value.ToString());
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement,parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagHourInfo(dr));
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
            return objs;
        }

        /// <summary>
        /// 获取所有最新的小时表数据。
        /// </summary>
        /// <returns>最新的小时表数据。</returns>
        public List<TagHourInfo> Get_Latest_All()
        {
            var sqlStatement = SQL_SELECT_LATEST_ALL;
            var parms = new[]
                            {
                                new SqlParameter("@I_Cycle_Id", SqlDbType.Int){Value = Gather.DateTime2HourCycleId(DataProvider.TagProvider.GetDate())},
                            };
            var objs = new List<TagHourInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagHourInfo(dr));
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
            return objs;
        }

        #endregion

        #region Private Method
        /// <summary>
        /// 将DataRow转换为小时数据实体。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>小时数据实体。</returns>
        private static TagHourInfo ConvertToTagHourInfo(IDataRecord dr)
        {
            var obj = new TagHourInfo
                          {
                              I_Cycle_Id = int.Parse(dr["I_Cycle_Id"].ToString()),
                              I_Tag_Id = dr["I_Tag_Id"].ToString(),
                              I_Value_Org = double.Parse(dr["I_Value_Org"].ToString()),
                              I_Value_Man = double.Parse(dr["I_Value_Man"].ToString()),
                              Max_Value =
                                  (dr["Max_Value"] == DBNull.Value
                                       ? double.MaxValue
                                       : double.Parse(dr["Max_Value"].ToString())),
                              Min_Value = (dr["Min_Value"]==DBNull.Value?double.MinValue:double.Parse(dr["Min_Value"].ToString())),
                              Upper_Seconds = (dr["Upper_Seconds"] == DBNull.Value?double.MaxValue:double.Parse(dr["Upper_Seconds"].ToString())),
                              Lower_Seconds = (dr["Lower_Seconds"] == DBNull.Value?double.MinValue:double.Parse(dr["Lower_Seconds"].ToString())),
                              Begin_Value = (dr["Begin_Value"]==DBNull.Value?double.MinValue:double.Parse(dr["Begin_Value"].ToString())),
                              End_Value = (dr["End_Value"]==DBNull.Value?double.MaxValue:double.Parse(dr["End_Value"].ToString())),

                          };
            return obj;
        }
        
        #endregion
    }
}
