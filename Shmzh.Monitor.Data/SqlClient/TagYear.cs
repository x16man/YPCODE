using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
using Shmzh.Components.SystemComponent;
namespace Shmzh.Monitor.Data.SqlClient
{
    public class TagYear :IDAL.ITagYear
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_SELECT_BY_TAGID_CYCLEID = @"
Select I_Cycle_Id,I_Tag_Id,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) as I_Value_Man,Max_Value,Min_Value,Begin_Value,End_Value From T_Tag_Year Where I_Tag_Id = @I_Tag_Id And I_Cycle_Id >=@BeginCycleId And I_Cycle_Id <=@EndCycleId";
        private const string SQL_SELECT_BY_TAGIDS_CYCLEID = @"
Select I_Cycle_Id,I_Tag_Id,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) as I_Value_Man,Max_Value,Min_Value,Begin_Value,End_Value From T_Tag_Year Where I_Tag_Id In ({0}) And I_Cycle_Id >=@BeginCycleId And I_Cycle_Id <=@EndCycleId";
        private const string SQL_SELECT_LATEST_BY_TAGID = @"
Select Top 1 I_Cycle_Id,I_Tag_Id,I_Value_Org,Round(I_Value_Man,dbo.GetDigNum(I_Tag_Id)) as I_Value_Man,Max_Value,Min_Value,Begin_Value,End_Value From T_Tag_Year Where I_Tag_Id = @I_Tag_Id Order By I_Cycle_Id Desc";
        private const string SQL_SELECT_LATEST_BY_TAGIDS = @"
Select  A.I_Cycle_Id,A.I_Tag_Id,A.I_Value_Org,Round(A.I_Value_Man,dbo.GetDigNum(A.I_Tag_Id)) as I_Value_Man,A.Max_Value,A.Min_Value,A.Begin_Value,A.End_Value
From    T_Tag_Year A ,
        (Select I_Tag_Id,Max(I_Cycle_Id) As I_Cycle_Id From T_Tag_Year Where I_Tag_Id In ({0}) Group By I_Tag_Id) As B 
Where   A.I_Tag_Id = B.I_Tag_Id And 
        A.I_Cycle_Id = B.I_Cycle_Id";
        private const string SQL_SELECT_LATEST_ALL = @"
Select  A.I_Cycle_Id,A.I_Tag_Id,A.I_Value_Org,Round(A.I_Value_Man,dbo.GetDigNum(A.I_Tag_Id)) as I_Value_Man,A.Max_Value,A.Min_Value,A.Begin_Value,A.End_Value
From    T_Tag_Year A ,
        (Select I_Tag_Id,Max(I_Cycle_Id) As I_Cycle_Id From T_Tag_Year Where I_Cycle_ID < @I_Cycle_Id Group By I_Tag_Id) As B 
Where   A.I_Tag_Id = B.I_Tag_Id And 
        A.I_Cycle_Id = B.I_Cycle_Id";

        #endregion

        #region ITagYear 成员

        public List<TagYearInfo> Get_By_TagId_CycleId(string tagId, int beginCycleId, int endCycleId)
        {
            var parms = new[]
                            {
                                new SqlParameter("@I_Tag_Id", SqlDbType.VarChar, 8) {Value = tagId},
                                new SqlParameter("@BeginCycleId", SqlDbType.Int) {Value = beginCycleId},
                                new SqlParameter("@EndCycleId", SqlDbType.Int){Value = endCycleId},
                            };
            var objs = new List<TagYearInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_BY_TAGID_CYCLEID,
                                                     parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagYearInfo(dr));
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

        public List<TagYearInfo> Get_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return this.Get_By_TagId_CycleId(tagId, Gather.DateTime2YearCycleId(beginTime),
                                             Gather.DateTime2YearCycleId(endTime));
        }

        public List<TagYearInfo> Get_By_TagIds_CycleId(string tagIds, int beginCycleId, int endCycleId)
        {
            var sqlStatement = string.Format(SQL_SELECT_BY_TAGIDS_CYCLEID, StringUtil.WrapSingleQuotes(tagIds));
            var parms = new[]
                            {
                                new SqlParameter("@BeginCycleId", SqlDbType.Int) {Value = beginCycleId},
                                new SqlParameter("@EndCycleId", SqlDbType.Int){Value = endCycleId},
                            };
            var objs = new List<TagYearInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement,
                                                     parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagYearInfo(dr));
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

        public List<TagYearInfo> Get_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return this.Get_By_TagIds_CycleId(tagIds, Gather.DateTime2YearCycleId(beginTime),
                                              Gather.DateTime2YearCycleId(endTime));
        }

        public TagYearInfo Get_Latest_By_TagId(string tagId)
        {
            var parms = new[]
                            {
                                new SqlParameter("@I_Tag_Id", SqlDbType.VarChar, 8) {Value = tagId},
                            };
            TagYearInfo obj = null;
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_LATEST_BY_TAGID,
                                                     parms);
                while (dr.Read())
                {
                    obj = ConvertToTagYearInfo(dr);
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

        public List<TagYearInfo> Get_Latest_By_TagIds(string tagIds)
        {
            var sqlStatement = string.Format(SQL_SELECT_LATEST_BY_TAGIDS, StringUtil.WrapSingleQuotes(tagIds));
            var objs = new List<TagYearInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagYearInfo(dr));
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
        /// 获取最新的年数据。
        /// </summary>
        /// <returns>年表数据集合。</returns>
        public List<TagYearInfo> Get_Latest_All()
        {
            var sqlStatement = SQL_SELECT_LATEST_ALL;
            var parms = new[]
                            {
                                new SqlParameter("@I_Cycle_Id", SqlDbType.Int){Value = Gather.DateTime2MonthCycleId(DataProvider.TagProvider.GetDate())},
                            };
            var objs = new List<TagYearInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagYearInfo(dr));
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
        private static TagYearInfo ConvertToTagYearInfo(IDataRecord dr)
        {
            var obj = new TagYearInfo
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
