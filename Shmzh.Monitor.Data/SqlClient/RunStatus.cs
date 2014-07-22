using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.Util;
using Shmzh.Monitor.Entity;


namespace Shmzh.Monitor.Data.SqlClient
{
    public class RunStatus : IDAL.IRunStatus
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_SELECT_CURRENT_BY_DEVCODE = @"
Select  Top 1 PKID,Dev_Code,Status,Begin_Time,End_Time,Operator,I_Tag_ID,Remark 
From    D_Run_Status 
Where   Dev_Code = @Dev_Code And
        End_Time Is Null           
Order   By Begin_Time Desc";
        private const String SQL_SELECT_CURRENT_BY_DEVCODES = @"
Select  PKID,Dev_Code,Status,Begin_Time,End_Time,Operator,I_Tag_ID,Remark 
From    D_Run_Status 
Where   Dev_Code IN ({0}) And End_Time Is Null";

        private const string SQL_SELECT_CURRENT_ALL = @"
Select  PKID,Dev_Code,Status,Begin_Time,End_Time,Operator,I_Tag_ID,Remark 
From    D_Run_Status 
Where   Dev_Code is not null And
	Dev_Code <> '' And
        End_Time Is Null";
        
        #endregion

        #region IRunStatus 成员

        /// <summary>
        /// 根据指标Id获取设备的当前运行状态。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>设备的当前运行状态实体。</returns>
        public RunStatusInfo Get_Current_By_TagId(string tagId)
        {
            var tagInfo = DataProvider.TagProvider.GetById(tagId);
            return tagInfo == null ? null : Get_Current_By_DevCode(tagInfo.Dev_Code);
        }

        /// <summary>
        /// 根据设备编号获取设备的当前的运行状态。
        /// </summary>
        /// <param name="devCode">设备编号。</param>
        /// <returns>设备的当前运行状态实体。</returns>
        public RunStatusInfo Get_Current_By_DevCode(string devCode)
        {
            var parms = new[] { new SqlParameter("@Dev_Code", SqlDbType.VarChar, 20) { Value = devCode }, };
            RunStatusInfo obj = null;
            if (!string.IsNullOrEmpty(devCode))
            {
                SqlDataReader dr = null;
                try
                {
                    dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text,
                                                 SQL_SELECT_CURRENT_BY_DEVCODE, parms);
                    while (dr.Read())
                    {
                        obj = ConvertToRunStatusInfo(dr);
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
            }
            return obj;
        }

        /// <summary>
        /// 根据设备编号获取多个设备的当前的运行状态。
        /// </summary>
        /// <param name="devCodes">设备编号字符串(逗号分隔)。</param>
        /// <returns>多个设备的当前的运行状态集合。</returns>
        public List<RunStatusInfo> Get_Current_By_DevCodes(string devCodes)
        {
            var sqlStatement = string.Format(SQL_SELECT_CURRENT_BY_DEVCODES, StringUtil.WrapSingleQuotes(devCodes));
            var objs = new List<RunStatusInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, sqlStatement);
                while (dr.Read())
                {
                    objs.Add(ConvertToRunStatusInfo(dr));
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
        /// 获取所有设备的当前运行状态。
        /// </summary>
        /// <returns>设备的当前运行状态集合。</returns>
        public List<RunStatusInfo> Get_Current_All()
        {
            //var sqlStatement = SQL_SELECT_CURRENT_ALL;
            var objs = new List<RunStatusInfo>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString.Produce, CommandType.Text, SQL_SELECT_CURRENT_ALL);
                while (dr.Read())
                {
                    objs.Add(ConvertToRunStatusInfo(dr));
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
        #endregion

        #region Private Method
        /// <summary>
        /// 将DataRow转换为RunStatusInfo对象。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>RunStatusInfo对象。</returns>
        private static RunStatusInfo ConvertToRunStatusInfo(IDataRecord dr)
        {
            var obj = new RunStatusInfo
            {
                PKID = decimal.Parse(dr["PKID"].ToString()),
                Dev_Code = dr["Dev_Code"]==DBNull.Value?string.Empty:dr["Dev_Code"].ToString(),
                Status = dr["Status"] == DBNull.Value?int.MaxValue:int.Parse(dr["Status"].ToString()),
                Begin_Time = DateTime.Parse(dr["Begin_Time"].ToString()),
                End_Time = dr["End_Time"] ==DBNull.Value?DateTime.MinValue:DateTime.Parse(dr["End_Time"].ToString()),
                Operator = dr["Operator"] == DBNull.Value?string.Empty:dr["Operator"].ToString(),
                I_Tag_ID = dr["I_Tag_Id"] == DBNull.Value?string.Empty:dr["I_Tag_Id"].ToString(),
                Remark = dr["Remark"] == DBNull.Value?string.Empty:dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion
    }
}
