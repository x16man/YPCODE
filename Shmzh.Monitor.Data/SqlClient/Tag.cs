using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Data.SqlClient
{
    public class Tag : IDAL.ITag
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_SELECT_BY_TAGID = @"Select I_Tag_Id,I_Tag_Name,I_Dig_Num,I_Unit,I_Tag_Type,Calc_Type_Before_Hour,Calc_Type_After_Hour,Second_To_Minute,Minute_To_Min5,Minute_To_Hour,Hour_To_Day,Day_To_Month,Month_To_Year,Remark,Func,Dev_Code,Max_Value,Min_Value From T_Tag_Ms Where I_Tag_Id=@I_Tag_Id";

        private const string SQL_SELECT_ALL = @"Select I_Tag_Id,I_Tag_Name,I_Dig_Num,I_Unit,I_Tag_Type,Calc_Type_Before_Hour,Calc_Type_After_Hour,Second_To_Minute,Minute_To_Min5,Minute_To_Hour,Hour_To_Day,Day_To_Month,Month_To_Year,Remark,Func,Dev_Code,Max_Value,Min_Value From T_Tag_Ms";

        private const string SQL_SELECT_BY_TYPE_TAGID_TAGNAME = @"Select I_Tag_Id,I_Tag_Name,I_Dig_Num,I_Unit,I_Tag_Type,Calc_Type_Before_Hour,Calc_Type_After_Hour,Second_To_Minute,Minute_To_Min5,Minute_To_Hour,Hour_To_Day,Day_To_Month,Month_To_Year,Remark,Func,Dev_Code,Max_Value,Min_Value From T_Tag_Ms Where I_Tag_Type Like ''+@TagType+'%' And I_Tag_Id Like ''+@TagId+'%' And I_Tag_Name like '%'+@TagName+'%'";

        private const string SQL_SELECT_3TAG = "Select dbo.WQ_Get3TagEligibleRate('{0}','{1}')";

        private const string SQL_SELECT_4TAG = "Select dbo.WQ_Get4TagEligibleRate('{0}','{1}')";

        private const string SQL_SELECT_7TAG = "Select dbo.WQ_Get7TagEligibleRate('{0}','{1}')";
        #endregion

        #region ITag 成员
        
        public TagInfo GetById(string tagId)
        {
            SqlDataReader dr = null;
            var parms = new[] {new SqlParameter("@I_Tag_Id", SqlDbType.VarChar, 8) {Value = tagId},};
            TagInfo obj = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_BY_TAGID, parms);
                while (dr.Read())
                {
                    obj = ConvertToTagInfo(dr);
                    break;
                }
            }
            catch(Exception ex)
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
        /// 获取所有指标。
        /// </summary>
        /// <returns>指标列表。</returns>
        public List<TagInfo> GetAll()
        {
            SqlDataReader dr = null;
            var objs = new List<TagInfo>();
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_ALL);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagInfo(dr));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
            finally
            {
                if(dr!=null) dr.Close();
            }
            return objs;
        }

        /// <summary>
        /// 根据输入字符进行快速查询。
        /// </summary>
        /// <param name="strCondition">查询条件。</param>
        /// <returns>指标集合。</returns>
        public List<TagInfo> QuickSearch(string strCondition)
        {
            string sqlStatement = @"Select I_Tag_Id,I_Tag_Name,I_Dig_Num,I_Unit,I_Tag_Type,Calc_Type_Before_Hour,Calc_Type_After_Hour,Second_To_Minute,Minute_To_Min5,Minute_To_Hour,Hour_To_Day,Day_To_Month,Month_To_Year,Remark,Func,Dev_Code,Max_Value,Min_Value From T_Tag_Ms ";

            if (!String.IsNullOrEmpty(strCondition))
            {
                sqlStatement += String.Format(" WHERE [I_Tag_Id] LIKE '%{0}%' OR [I_Tag_Name] LIKE '%{0}%'", strCondition.Replace("'", "''"));
            }
            SqlDataReader dr = null;
            var objs = new List<TagInfo>();
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagInfo(dr));
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
        /// 根据指标类型、指标Id、指标名称获取指标列表。
        /// </summary>
        /// <param name="tagType">指标类型</param>
        /// <param name="tagId">指标Id</param>
        /// <param name="tagName">指标名称</param>
        /// <returns>指标集合。</returns>
        public List<TagInfo> GetByType_TagId_TagName(string tagType, string tagId, string tagName)
        {
            SqlDataReader dr = null;
            var objs = new List<TagInfo>();
            var parms = new[]
                            {
                                new SqlParameter("@TagType", SqlDbType.VarChar, 3) {Value = tagType}, 
                                new SqlParameter("@TagId", SqlDbType.VarChar, 8) {Value = tagId},
                                new SqlParameter("@TagName", SqlDbType.VarChar,180){Value = tagName},
                            };
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text,SQL_SELECT_BY_TYPE_TAGID_TAGNAME,parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagInfo(dr));
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
        /// 获取服务器时间。
        /// </summary>
        /// <returns>服务器时间。</returns>
        public DateTime GetDate()
        {
            var obj = SqlHelper.ExecuteScalar(ConnectionString.Produce, CommandType.Text, "Select GetDate()");
            if(obj == null)
            {
                return DateTime.Now;
            }
            else
            {
                return (DateTime) obj;
            }
        }

        public double Get3TagEligibleRate(DateTime beginDate, DateTime endDate)
        {
            var sqlStatement = string.Format(SQL_SELECT_3TAG, beginDate.ToShortDateString(), endDate.ToShortDateString());
            try
            {
                var obj = SqlHelper.ExecuteScalar(ConnectionString.Produce, CommandType.Text, sqlStatement);
                if (obj == null)
                    return 0;
                else
                {
                    try
                    {
                        var retValue = double.Parse(obj.ToString());
                        return retValue;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        return 0;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                return double.MinValue;
            }
        }

        public double Get4TagEligibleRate(DateTime beginDate, DateTime endDate)
        {
            var sqlStatement = string.Format(SQL_SELECT_4TAG, beginDate.ToShortDateString(), endDate.ToShortDateString());
            try
            {
                var obj = SqlHelper.ExecuteScalar(ConnectionString.Produce, CommandType.Text, sqlStatement);
                if (obj == null)
                    return 0;
                else
                {
                    try
                    {
                        var retValue = double.Parse(obj.ToString());
                        return retValue;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        return 0;
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0.0;
            }
        }

        public double Get7TagEligibleRate(DateTime beginDate, DateTime endDate)
        {
            var sqlStatement = string.Format(SQL_SELECT_7TAG, beginDate.ToShortDateString(), endDate.ToShortDateString());
            try
            {
                var obj = SqlHelper.ExecuteScalar(ConnectionString.Produce, CommandType.Text, sqlStatement);
                if (obj == null)
                    return 0;
                else
                {
                    try
                    {
                        var retValue = double.Parse(obj.ToString());
                        return retValue;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
            
        }

        
        #endregion

        #region Private Method
        /// <summary>
        /// 将DataRow转换为TagInfo对象。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>指标对象。</returns>
        internal static TagInfo ConvertToTagInfo(IDataRecord dr)
        {
            var obj = new TagInfo
                          {
                              I_Tag_Id = dr["I_Tag_Id"].ToString(),
                              I_Tag_Name = dr["I_Tag_Name"]==DBNull.Value?string.Empty:dr["I_Tag_Name"].ToString(),
                              I_Dig_Num = dr["I_Dig_Num"] == DBNull.Value?int.MaxValue:int.Parse(dr["I_Dig_Num"].ToString()),
                              I_Unit = dr["I_Unit"]==DBNull.Value?string.Empty:dr["I_Unit"].ToString(),
                              I_Tag_Type = dr["I_Tag_Type"] == DBNull.Value?string.Empty:dr["I_Tag_Type"].ToString(),
                              Calc_Type_Before_Hour = dr["Calc_Type_Before_Hour"] == DBNull.Value ? int.MaxValue : int.Parse(dr["Calc_Type_Before_Hour"].ToString()),
                              Calc_Type_After_Hour = dr["Calc_Type_After_Hour"] == DBNull.Value ? int.MaxValue : int.Parse(dr["Calc_Type_After_Hour"].ToString()),
                              Second_To_Minute = dr["Second_To_Minute"] == DBNull.Value ? false : (bool)dr["Second_To_Minute"],
                              Minute_To_Min5 = dr["Minute_To_Min5"] == DBNull.Value ? false : (bool)dr["Minute_To_Min5"],
                              Minute_To_Hour = dr["Minute_To_Hour"] == DBNull.Value ? false : (bool)dr["Minute_To_Hour"],
                              Hour_To_Day = dr["Hour_To_Day"] == DBNull.Value ? false : (bool)dr["Hour_To_Day"],
                              Day_To_Month = dr["Day_To_Month"] == DBNull.Value ? false : (bool)dr["Day_To_Month"],
                              Month_To_Year = dr["Month_To_Year"] == DBNull.Value ? false : (bool)dr["Month_To_Year"],
                              Remark = dr["Remark"] == DBNull.Value ?string.Empty:dr["Remark"].ToString(),
                              Func = dr["Func"] == DBNull.Value?string.Empty:dr["Func"].ToString(),
                              Dev_Code = dr["Dev_Code"] == DBNull.Value?string.Empty:dr["Dev_Code"].ToString(),
                              Max_Value = dr["Max_Value"] == DBNull.Value?double.MaxValue:double.Parse(dr["Max_Value"].ToString()),
                              Min_Value = dr["Min_Value"] == DBNull.Value?double.MinValue:double.Parse(dr["Min_Value"].ToString()),

                          };
            return obj;
        }
        #endregion
    }
}
