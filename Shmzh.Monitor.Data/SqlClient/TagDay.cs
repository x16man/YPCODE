using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class TagDay : IDAL.ITagDay
    {
        #region Field
        private static  int BEGINHOUR = int.Parse(ConfigurationManager.AppSettings["BeginHour"]);
        private static  int ENDHOUR = int.Parse(ConfigurationManager.AppSettings["EndHour"]);
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_SELECT_BY_TAGID_CYCLEID = @"
Select  I_Cycle_Id,
        I_Tag_Id,
        I_Value_Org,
        Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) As I_Value_Man,
        Max_Value,
        Min_Value,
        Begin_Value,
        End_Value 
From    T_Tag_Day 
Where   I_Tag_Id = @I_Tag_Id And 
        I_Cycle_Id >= @BeginCycleId And 
        I_Cycle_Id <= @EndCycleID 
Order By I_Cycle_ID";

        private const string SQL_SELECT_BY_TAGIDS_CYCLEID = @"
Select  I_Cycle_Id,
        I_Tag_Id,
        I_Value_Org,
        Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) As I_Value_Man,
        Max_Value,
        Min_Value,
        Begin_Value,
        End_Value 
From    T_Tag_Day 
Where   I_Tag_Id In ({0}) And 
        I_Cycle_Id >= @BeginCycleId And 
        I_Cycle_Id <= @EndCycleID 
Order By I_Cycle_ID ";
        private const string SQL_SELECT_OLHC_BY_TAGID_CYCLEID = @"
Select  I_Cycle_Id,I_Tag_Id,
        I_Value_Org,
        Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) As I_Value_Man,
        Max_Value,
        Min_Value,
        dbo.GetHourValue(I_Tag_Id,I_Cycle_Id,{0}) as Begin_Value,
        dbo.GetHourValue(I_Tag_Id,I_Cycle_Id,{1}) As End_Value 
From    T_Tag_Day 
Where   I_Tag_Id = @I_Tag_Id And 
        I_Cycle_Id >= @BeginCycleId And 
        I_Cycle_Id <= @EndCycleID 
Order By I_Cycle_ID";
        private const string SQL_SELECT_OLHC_BY_TAGIDS_CYCLEID = @"
Select  I_Cycle_Id,I_Tag_Id,
        I_Value_Org,
        Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) As I_Value_Man,
        Max_Value,
        Min_Value,
        dbo.GetHourValue(I_Tag_Id,I_Cycle_Id,{1}) as Begin_Value,
        dbo.GetHourValue(I_Tag_Id,I_Cycle_Id,{2}) As End_Value 
From    T_Tag_Day 
Where   I_Tag_Id In ({0}) And 
        I_Cycle_Id >= @BeginCycleId And 
        I_Cycle_Id <= @EndCycleID 
Order By I_Cycle_ID ";
        private const string SQL_SELECT_LATEST_BY_TAGID = @"
Select Top 1 I_Cycle_Id,
        I_Tag_Id,
        I_Value_Org,
        Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) As I_Value_Man,
        Max_Value,
        Min_Value,
        Begin_Value,
        End_Value 
From T_Tag_Day Where I_Tag_Id = @I_Tag_Id And I_Cycle_Id <= @I_Cycle_ID Order By I_Cycle_Id Desc";

        private const string SQL_SELECT_LATEST_BY_TAGIDS = @"
Select  A.I_Cycle_Id,
        A.I_Tag_Id,
        A.I_Value_Org,
        Round(A.I_Value_Man,dbo.GetDigNum(A.I_Tag_Id)) As I_Value_Man,
        A.Max_Value,
        A.Min_Value,
        A.Begin_Value,
        A.End_Value 
From    T_Tag_Day A,
        (Select I_Tag_Id,Max(I_Cycle_Id) As I_Cycle_Id From T_Tag_Day Where I_Tag_Id In ({0}) And I_Cycle_Id < =@I_Cycle_Id Group By I_Tag_Id) As B 
Where   A.I_Tag_Id = B.I_Tag_Id And 
        A.I_Cycle_Id = B.I_Cycle_Id";

        private const string SQL_SELECT_LATEST_ALL = @"
Select  A.I_Cycle_Id,
        A.I_Tag_Id,
        A.I_Value_Org,
        Round(A.I_Value_Man,dbo.GetDigNum(A.I_Tag_Id)) As I_Value_Man,
        A.Max_Value,
        A.Min_Value,
        A.Begin_Value,
        A.End_Value 
From    T_Tag_Day A,
        (Select I_Tag_Id,Max(I_Cycle_Id) As I_Cycle_Id From T_Tag_Day Where I_Cycle_ID < =@I_Cycle_Id Group By I_Tag_Id) As B 
Where   A.I_Tag_Id = B.I_Tag_Id And 
        A.I_Cycle_Id = B.I_Cycle_Id";

        #endregion

        #region ITagDay 成员

        /// <summary>
        /// 根据指定的指标Id、开始时间Id、结束时间Id来获取天表的数据集合。
        /// </summary>
        /// <param name="tagId">指标id.</param>
        /// <param name="beginCycleId">开始时间Id.</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合。</returns>
        public List<TagDayInfo> Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            SqlDataReader dr = null;
            var objs = new List<TagDayInfo>();
            var parms = new[]
                            {
                                new SqlParameter("@I_Tag_Id", SqlDbType.VarChar, 8) {Value = tagId},
                                new SqlParameter("@BeginCycleId", SqlDbType.Int) {Value = beginCycleId},
                                new SqlParameter("@EndCycleId", SqlDbType.Int){Value = endCycleId},
                            };
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_BY_TAGID_CYCLEID,
                                                     parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagDayInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("{0}:{1}", tagId, ex.Message));
            }
            finally
            {
                if(dr != null) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合。</returns>
        public List<TagDayInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return this.Get_By_TagId_CycleId(tagId, Gather.DateTime2DayCycleId(beginTime),
                                             Gather.DateTime2DayCycleId(endTime));
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合。</returns>
        public List<TagDayInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            SqlDataReader dr = null;
            var objs = new List<TagDayInfo>();
            var sqlStatement = string.Format(SQL_SELECT_BY_TAGIDS_CYCLEID, StringUtil.WrapSingleQuotes(tagIds));
            var parms = new[]
                            {
                                new SqlParameter("@BeginCycleId", SqlDbType.Int) {Value = beginCycleId},
                                new SqlParameter("@EndCycleId", SqlDbType.Int) {Value = endCycleId},
                            };
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagDayInfo(dr));
                }
            }
            catch ( Exception ex)
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
        /// 根据指定的指标Id串、开始时间、结束时间来获取天表的数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表数据集合。</returns>
        public List<TagDayInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return this.Get_By_TagIds_CycleId(tagIds, Gather.DateTime2DayCycleId(beginTime),
                                              Gather.DateTime2DayCycleId(endTime));
        }

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合</returns>
        public List<TagDayInfo> Get_OLHC_By_Tag_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            SqlDataReader dr = null;
            var objs = new List<TagDayInfo>();
            var parms = new[]
                            {
                                new SqlParameter("@I_Tag_Id", SqlDbType.VarChar, 8) {Value = tagId},
                                new SqlParameter("@BeginCycleId", SqlDbType.Int) {Value = beginCycleId},
                                new SqlParameter("@EndCycleId", SqlDbType.Int){Value = endCycleId},
                            };
            var sqlStatement = string.Format(SQL_SELECT_OLHC_BY_TAGID_CYCLEID, BEGINHOUR, ENDHOUR);
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagDayInfo(dr));
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

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合</returns>
        public List<TagDayInfo> Get_OLHC_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return this.Get_OLHC_By_Tag_CycleId(tagId, Gather.DateTime2DayCycleId(beginTime),
                                             Gather.DateTime2DayCycleId(endTime));
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagIds">指标Id串</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <returns>天表的数据集合。</returns>
        public List<TagDayInfo> Get_OLHC_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            SqlDataReader dr = null;
            var objs = new List<TagDayInfo>();
            var sqlStatement = string.Format(SQL_SELECT_OLHC_BY_TAGIDS_CYCLEID, StringUtil.WrapSingleQuotes(tagIds), BEGINHOUR, ENDHOUR);
            var parms = new[]
                            {
                                new SqlParameter("@BeginCycleId", SqlDbType.Int) {Value = beginCycleId},
                                new SqlParameter("@EndCycleId", SqlDbType.Int) {Value = endCycleId},
                            };
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagDayInfo(dr));
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
        /// 根据指定的指标Id串、开始时间Id、结束时间Id来获取天表的数据集合。开始值、结束值是指定时间点的值。
        /// </summary>
        /// <param name="tagIds">指标Id串</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合。</returns>
        public List<TagDayInfo> Get_OLHC_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return this.Get_OLHC_By_TagIds_CycleId(tagIds, Gather.DateTime2DayCycleId(beginTime),
                                                   Gather.DateTime2DayCycleId(endTime));
        }

        /// <summary>
        /// 根据指标Id获取最新的天表数据。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>最新的天表数据。</returns>
        public TagDayInfo Get_Latest_By_TagId(string tagId)
        {
            SqlDataReader dr = null;
            var parms = new[] {
                new SqlParameter("@I_Tag_Id", SqlDbType.VarChar, 8) {Value = tagId},
                new SqlParameter("@I_Cycle_Id", SqlDbType.Int){Value = Gather.DateTime2DayCycleId(DataProvider.TagProvider.GetDate())}
            };
            TagDayInfo obj = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_LATEST_BY_TAGID,
                                                 parms);
                while (dr.Read())
                {
                    obj = ConvertToTagDayInfo(dr);
                    break;
                }
            }
            catch(Exception ex)
            {
                Logger.Error(string.Format("{0}:{1}", tagId, ex.Message));
            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return obj;
        }

        /// <summary>
        /// 根据指标Id串获取最新的天表数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。</param>
        /// <returns>天表数据集合。</returns>
        public List<TagDayInfo> Get_Latest_By_TagIds(string tagIds)
        {
            SqlDataReader dr = null;
            var sqlStatement = string.Format(SQL_SELECT_LATEST_BY_TAGIDS, StringUtil.WrapSingleQuotes(tagIds));
            var parms = new[] {
                new SqlParameter("@I_Cycle_Id", SqlDbType.Int){Value = Gather.DateTime2DayCycleId(DataProvider.TagProvider.GetDate())}
            };
            var objs = new List<TagDayInfo>();

            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement,parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagDayInfo(dr));
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
        /// 获取最新的日表数据。
        /// </summary>
        /// <returns>日表数据集合。</returns>
        public List<TagDayInfo> Get_Latest_All()
        {
            SqlDataReader dr = null;
            var sqlStatement = string.Format(SQL_SELECT_LATEST_ALL);
            var objs = new List<TagDayInfo>();
            var parms = new[]
                            {
                                new SqlParameter("@I_Cycle_Id", SqlDbType.Int){Value = Gather.DateTime2DayCycleId(DataProvider.TagProvider.GetDate())},
                            };
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagDayInfo(dr));
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

        /// <summary>
        /// 气温、水量与指标关系查询。
        /// </summary>
        /// <param name="tagIds">指标Id串（逗号分隔）。不包含当日最高气温指标、当日最低气温指标和总出厂水量指标。</param>
        /// <param name="beginCycleId">开始时间Id。</param>
        /// <param name="endCycleId">结束时间Id。</param>
        /// <param name="temperatureTagHigh">当日最高气温指标。</param>
        /// <param name="temperatureTagLow">当日最低气温指标。</param>
        /// <param name="waterTag">总出厂水量指标。</param>
        /// <param name="beginTemperature">最低气温。</param>
        /// <param name="endTemperature">最高气温。</param>
        /// <param name="beginWater">最小水量。</param>
        /// <param name="endWater">最大水量。</param>
        /// <returns>天表的数据集合</returns>
        public List<TagDayInfo> TagAndTemperatureAnalyze(String tagIds, String temperatureTagHigh, String temperatureTagLow,
            String waterTag, int beginCycleId, int endCycleId, double beginWater, double endWater,
            double beginTemperature, double endTemperature)
        {
            if (String.IsNullOrEmpty(tagIds))
                tagIds = "";
            else
                tagIds += ",";
            tagIds += String.Format("{0},{1},{2}", temperatureTagHigh, temperatureTagLow, waterTag);
            
            String sqlStatement = @"SELECT T.[I_CYCLE_ID], I_Tag_Id, I_Value_Org,
        Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) As I_Value_Man,
        Max_Value, Min_Value, Begin_Value, End_Value From [T_Tag_Day] T
INNER JOIN
(
    SELECT A.[I_CYCLE_ID] FROM 
    (
        SELECT [I_CYCLE_ID] FROM [T_TAG_DAY] 
        WHERE [I_TAG_ID] = @WaterTag AND [I_VALUE_MAN] BETWEEN @BeginWater AND @EndWater
    ) A INNER JOIN 
    (
        --最低
        SELECT [I_CYCLE_ID] FROM [T_TAG_DAY] A
        WHERE [I_TAG_ID] = @TemperatureTagLow AND [I_VALUE_MAN] BETWEEN @BeginTemperature AND @EndTemperature
        UNION
        --最高气温
        SELECT [I_CYCLE_ID] FROM [T_TAG_DAY] A
        WHERE [I_TAG_ID] = @TemperatureTagHigh AND [I_VALUE_MAN] BETWEEN @BeginTemperature AND @EndTemperature
    ) B ON A.[I_CYCLE_ID] = B.[I_CYCLE_ID]
) C ON T.[I_CYCLE_ID] = C.[I_CYCLE_ID]
WHERE T.[I_CYCLE_ID] BETWEEN @BeginCycleId AND @EndCycleId AND T.[I_Tag_Id] IN ({0})
ORDER BY T.[I_CYCLE_ID], [I_TAG_ID]
";
            sqlStatement = String.Format(sqlStatement, StringUtil.WrapSingleQuotes(tagIds));
            SqlDataReader dr = null;
            var objs = new List<TagDayInfo>();
            var parms = new[]
                            {
                                new SqlParameter("@BeginCycleId", SqlDbType.Int) {Value = beginCycleId},
                                new SqlParameter("@EndCycleId", SqlDbType.Int){Value = endCycleId},
                                new SqlParameter("@TemperatureTagHigh", SqlDbType.VarChar, 8) {Value = temperatureTagHigh},
                                new SqlParameter("@TemperatureTagLow", SqlDbType.VarChar, 8) {Value = temperatureTagLow},
                                new SqlParameter("@BeginTemperature", SqlDbType.Float){Value = beginTemperature},
                                new SqlParameter("@EndTemperature", SqlDbType.Float){Value = endTemperature},
                                new SqlParameter("@WaterTag", SqlDbType.VarChar, 8) {Value = waterTag},
                                new SqlParameter("@BeginWater", SqlDbType.Float){Value = beginWater},
                                new SqlParameter("@EndWater", SqlDbType.Float){Value = endWater},
                            };
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagDayInfo(dr));
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

        #endregion

        #region CTOR
        public TagDay()
        {}
        #endregion

        #region Private Method
        private static TagDayInfo ConvertToTagDayInfo(IDataRecord dr)
        {
            var obj = new TagDayInfo
                          {
                              I_Cycle_Id = int.Parse(dr["I_Cycle_Id"].ToString()),
                              I_Tag_Id = dr["I_Tag_Id"].ToString(),
                              I_Value_Org = double.Parse(dr["I_Value_Org"].ToString()),
                              I_Value_Man = double.Parse(dr["I_Value_Man"].ToString()),
                              Max_Value =
                                  (dr["Max_Value"] == DBNull.Value
                                       ? double.MaxValue
                                       : double.Parse(dr["Max_Value"].ToString())),
                              Min_Value =
                                  (dr["Min_Value"] == DBNull.Value
                                       ? double.MinValue
                                       : double.Parse(dr["Min_Value"].ToString())),
                              Begin_Value =
                                  (dr["Begin_Value"] == DBNull.Value
                                       ? double.MinValue
                                       : double.Parse(dr["Begin_Value"].ToString())),
                              End_Value =
                                  (dr["End_Value"] == DBNull.Value
                                       ? double.MaxValue
                                       : double.Parse(dr["End_Value"].ToString())),

                          };
            return obj;
        }
        #endregion
    }
}
