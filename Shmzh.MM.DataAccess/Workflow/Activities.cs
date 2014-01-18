using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.MM.Common.Workflow;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess.Workflow
{
    public class Activities
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region private method
        private ActivityInfo ConvertToActivityInfo(IDataRecord dr)
        {
            return new ActivityInfo
            {
                Act_Id = (int)dr["ACT_ID"],
                Proc_Id = (int)dr["PROC_ID"],
                Act_Name = dr["ACT_NAME"].ToString(),
                Act_Url = dr["ACT_URL"].ToString(),
                Task_Name = dr["Task_Name"]==DBNull.Value?string.Empty:dr["Task_Name"].ToString(),
                Time_Allowed = dr["TIME_ALLOWED"]==DBNull.Value?DateTime.MinValue:(DateTime)dr["TIME_ALLOWED"],
                Rule_Applied = dr["RULE_APPLIED"] == DBNull.Value ? string.Empty : dr["RULE_APPLIED"].ToString(),
                Ex_Pre_Rul_Func = dr["EX_PRE_RUL_FUNC"] == DBNull.Value ? 0 : (int)dr["EX_PRE_RUL_FUNC"],
                Ex_Post_Rul_Func = dr["EX_POST_RULE_FUNC"]==DBNull.Value?0:(int)dr["EX_POST_RULE_FUNC"],
                Act_Type = dr["ACT_TYPE"].ToString(),
                OR_Merge_Flag = dr["OR_MERGE_FLAG"]==DBNull.Value?string.Empty:dr["OR_MERGE_FLAG"].ToString(),
                Num_Votes_Needed = dr["NUM_VOTES_NEEDED"]==DBNull.Value?string.Empty:dr["NUM_VOTES_NEEDED"].ToString(),
                Auto_Executive = dr["AUTO_EXECUTIVE"]==DBNull.Value?0:(int)dr["AUTO_EXECUTIVE"],
                ACT_DESC = dr["ACT_DESC"]==DBNull.Value?string.Empty:dr["ACT_DESC"].ToString(),
            };
        }
        #endregion

        #region Method
        public bool Insert(ActivityInfo obj)
        {
            var sqlStatement = "Insert Into Activity Values (@ACT_ID,@PROC_ID,@ACT_NAME,@ACT_URL,@Task_Name,@Time_Allowed,@Rule_Applied,@Ex_Pre_Rul_Func,@Ex_Post_Rule_Func,@Act_Type,@OR_MERGE_FLAG,@NUM_VOTES_NEEDED,@AUTO_EXECUTIVE,@ACT_DESC)";
            var parms = new[]
                            {
                                new SqlParameter("@ACT_ID", SqlDbType.Int) {Value = obj.Act_Id,},
                                new SqlParameter("@PROC_ID",SqlDbType.Int){Value = obj.Proc_Id},
                                new SqlParameter("@ACT_NAME",SqlDbType.NVarChar,30){Value = obj.Act_Name},
                                new SqlParameter("@ACT_URL",SqlDbType.NVarChar,255){Value = obj.Act_Url},
                                new SqlParameter("@Task_Name",SqlDbType.NVarChar,255){Value = obj.Task_Name},
                                new SqlParameter("@Time_Allowed",SqlDbType.DateTime){Value = obj.Time_Allowed==DateTime.MinValue?DBNull.Value:(object)obj.Time_Allowed},
                                new SqlParameter("@Rule_Applied",SqlDbType.NVarChar,30){Value =string.IsNullOrEmpty(obj.Rule_Applied)?DBNull.Value:(object)obj.Rule_Applied},
                                new SqlParameter("@Ex_Pre_Rul_Func",SqlDbType.Int){Value =obj.Ex_Pre_Rul_Func==0?DBNull.Value:(object)obj.Ex_Pre_Rul_Func},
                                new SqlParameter("@Ex_Post_Rule_Func",SqlDbType.Int){Value = obj.Ex_Post_Rul_Func==0?DBNull.Value:(object)obj.Ex_Post_Rul_Func},
                                new SqlParameter("@Act_Type",SqlDbType.NVarChar,30){Value = string.IsNullOrEmpty(obj.Act_Type)?DBNull.Value:(object)obj.Act_Type},
                                new SqlParameter("@OR_MERGE_FLAG",SqlDbType.Char,1){Value = string.IsNullOrEmpty(obj.OR_Merge_Flag)?DBNull.Value:(object)obj.OR_Merge_Flag},
                                new SqlParameter("@NUM_VOTES_NEEDED",SqlDbType.Char,1){Value = string.IsNullOrEmpty(obj.Num_Votes_Needed)?DBNull.Value:(object)obj.Num_Votes_Needed},
                                new SqlParameter("@AUTO_EXECUTIVE",SqlDbType.Int){Value = obj.Auto_Executive==0?DBNull.Value:(object)obj.Auto_Executive},
                                new SqlParameter("@ACT_DESC",SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(obj.ACT_DESC)?DBNull.Value:(object)obj.ACT_DESC},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        public bool Update(ActivityInfo obj)
        {
            var sqlStatement = @"
Update Activity 
Set Proc_ID = @PROC_ID
,   ACT_NAME=@ACT_NAME
,   ACT_URL = @ACT_URL
,   Task_Name = @Task_Name
,   TIME_ALLOWED = @Time_Allowed
,   RULE_APPLIED = @Rule_Applied
,   EX_PRE_RUL_FUNC = @Ex_Pre_Rul_Func
,   EX_POST_RULE_FUNC = @Ex_Post_Rule_Func
,   ACT_TYPE = @Act_Type
,   OR_MERGE_FLAG = @OR_MERGE_FLAG
,   NUM_VOTES_NEEDED = @NUM_VOTES_NEEDED
,   AUTO_EXECUTIVE = @AUTO_EXECUTIVE
,   ACT_DESC = @ACT_DESC
Where ACT_ID = @ACT_ID";
            var parms = new[]
                            {
                                new SqlParameter("@ACT_ID", SqlDbType.Int) {Value = obj.Act_Id,},
                                new SqlParameter("@PROC_ID",SqlDbType.Int){Value = obj.Proc_Id},
                                new SqlParameter("@ACT_NAME",SqlDbType.NVarChar,30){Value = obj.Act_Name},
                                new SqlParameter("@ACT_URL",SqlDbType.NVarChar,255){Value = obj.Act_Url},
                                new SqlParameter("@Task_Name",SqlDbType.NVarChar,255){Value = obj.Task_Name},
                                new SqlParameter("@Time_Allowed",SqlDbType.DateTime){Value = obj.Time_Allowed==DateTime.MinValue?DBNull.Value:(object)obj.Time_Allowed},
                                new SqlParameter("@Rule_Applied",SqlDbType.NVarChar,30){Value =string.IsNullOrEmpty(obj.Rule_Applied)?DBNull.Value:(object)obj.Rule_Applied},
                                new SqlParameter("@Ex_Pre_Rul_Func",SqlDbType.Int){Value =obj.Ex_Pre_Rul_Func==0?DBNull.Value:(object)obj.Ex_Pre_Rul_Func},
                                new SqlParameter("@Ex_Post_Rule_Func",SqlDbType.Int){Value = obj.Ex_Post_Rul_Func==0?DBNull.Value:(object)obj.Ex_Post_Rul_Func},
                                new SqlParameter("@Act_Type",SqlDbType.NVarChar,30){Value = string.IsNullOrEmpty(obj.Act_Type)?DBNull.Value:(object)obj.Act_Type},
                                new SqlParameter("@OR_MERGE_FLAG",SqlDbType.Char,1){Value = string.IsNullOrEmpty(obj.OR_Merge_Flag)?DBNull.Value:(object)obj.OR_Merge_Flag},
                                new SqlParameter("@NUM_VOTES_NEEDED",SqlDbType.Char,1){Value = string.IsNullOrEmpty(obj.Num_Votes_Needed)?DBNull.Value:(object)obj.Num_Votes_Needed},
                                new SqlParameter("@AUTO_EXECUTIVE",SqlDbType.Int){Value = obj.Auto_Executive==0?DBNull.Value:(object)obj.Auto_Executive},
                                new SqlParameter("@ACT_DESC",SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(obj.ACT_DESC)?DBNull.Value:(object)obj.ACT_DESC},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        public bool Delete(ActivityInfo obj)
        {
            return Delete(obj.Act_Id);
        }
        public bool Delete(int actId)
        {
            var sqlStatement = "Delete From Activity Where Act_Id = @ACT_ID";
            var parms = new[] {new SqlParameter("@ACT_ID", SqlDbType.Int) {Value = actId}};
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        public List<ActivityInfo> GetAll()
        {
            var sqlStatement = "Select * From Activity";
            var objs = new List<ActivityInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToActivityInfo(dr));
            }
            dr.Close();
            return objs;
        }
        public List<ActivityInfo> GetByProcId(int procId)
        {
            var sqlStatement = "Select * From Activity Where Proc_Id = @PROC_ID";
            var parms = new[] {new SqlParameter("@PROC_ID", SqlDbType.Int) {Value = procId}};
            var objs = new List<ActivityInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement,parms);
            while (dr.Read())
            {
                objs.Add(ConvertToActivityInfo(dr));
            }
            dr.Close();
            return objs;
            
        }

        public ActivityInfo GetById(int actId)
        {
            var sqlStatement = "Select * From Activity Where Act_Id = @ACT_ID";
            var parms = new[] {new SqlParameter("@ACT_ID", SqlDbType.Int) {Value = actId}};
            ActivityInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToActivityInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }
        #endregion
    }
}
