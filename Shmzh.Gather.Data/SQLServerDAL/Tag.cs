using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Gather.Data.Model;
using Shmzh.Components.SystemComponent;
using System.Configuration;
namespace Shmzh.Gather.Data.SQLServerDAL
{
    class Tag :IDAL.ITag
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string connString;
        #endregion

        #region CTOR
        public Tag()
        {
            this.connString = ConfigurationManager.ConnectionStrings["Shmzh.Gather.Data.ConnectionString"].ConnectionString;
        }
        #endregion

        #region Implementation of ITag

        /// <summary>
        /// 根据指标Id获取指标信息实体。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <returns>指标信息实体。</returns>
        public TagInfo GetByTagId(string tagId)
        {
            var parms = new[] {new SqlParameter("@I_Tag_Id", SqlDbType.VarChar, 8) {Value = tagId}};
            var sqlStatement =
                @"Select A.I_Tag_Id,A.I_Tag_Name,A.I_Dig_Num,A.I_Unit,A.I_Tag_Type,A.Calc_Type_Before_Hour,A.Calc_Type_After_Hour,
                        A.Second_To_Minute,A.Minute_To_Min5,A.Minute_To_Hour,A.Hour_To_Day,A.Day_To_Month,A.Month_To_Year,A.Remark,A.Func,
                        A.Dev_Code,A.Max_Value,A.Min_Value,B.I_Design_CD,B.I_Address,B.I_PARA_A,B.I_PARA_B,B.I_PARA_C,B.I_Max,
                        B.I_Min,B.I_Action
                 From   T_Tag_MS A Left Outer Join T_Tag_Gather B
                 On     A.I_Tag_Id = B.I_Tag_Id 
                 Where  A.I_Tag_Id = @I_Tag_Id";
            TagInfo obj = null;
            try
            {
                var dr = SqlHelper.ExecuteReader(this.connString, CommandType.Text, sqlStatement, parms);
            
                while (dr.Read())
                {
                    obj = ConvertToTagInfo(dr);
                    break;
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
            return obj;
        }

        /// <summary>
        /// 获取所有的指标信息实体集合。
        /// </summary>
        /// <returns>指标信息实体集合</returns>
        public IList<TagInfo> GetAll()
        {
            var sqlStatement =
                @"Select A.I_Tag_Id,A.I_Tag_Name,A.I_Dig_Num,A.I_Unit,A.I_Tag_Type,A.Calc_Type_Before_Hour,A.Calc_Type_After_Hour,
                        A.Second_To_Minute,A.Minute_To_Min5,A.Minute_To_Hour,A.Hour_To_Day,A.Day_To_Month,A.Month_To_Year,A.Remark,A.Func,
                        A.Dev_Code,A.Max_Value,A.Min_Value,B.I_Design_CD,B.I_Address,B.I_PARA_A,B.I_PARA_B,B.I_PARA_C,B.I_Max,
                        B.I_Min,B.I_Action
                 From   T_Tag_MS A Left Outer Join T_Tag_Gather B
                 On     A.I_Tag_ID = B.I_Tag_ID ";
            var objs = new List<TagInfo>();
            try
            {
                var dr = SqlHelper.ExecuteReader(this.connString, CommandType.Text, sqlStatement);

                while (dr.Read())
                {
                    objs.Add(ConvertToTagInfo(dr));
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
            return objs;
        }

        /// <summary>
        /// 根据指标采集类型来获取指标实体集合。
        /// </summary>
        /// <param name="action">采集类型。</param>
        /// <returns>指标集合。</returns>
        public IList<TagInfo> GetByAction(short action)
        {
            var parms = new[] {new SqlParameter("@Action", SqlDbType.SmallInt) {Value = action}};
            var sqlStatement =
                 @"Select A.I_Tag_Id,A.I_Tag_Name,A.I_Dig_Num,A.I_Unit,A.I_Tag_Type,A.Calc_Type_Before_Hour,A.Calc_Type_After_Hour,
                        A.Second_To_Minute,A.Minute_To_Min5,A.Minute_To_Hour,A.Hour_To_Day,A.Day_To_Month,A.Month_To_Year,
                        A.Remark,A.Func,A.Dev_Code,A.Max_Value,A.Min_Value,B.I_Design_CD,B.I_Address,B.I_PARA_A,B.I_PARA_B,B.I_PARA_C,
                        B.I_Max,B.I_Min,B.I_Action
                 From   T_Tag_MS A Right Outer Join T_Tag_Gather B
                 On     A.I_Tag_ID = B.I_Tag_ID 
                 Where  B.I_Action = @Action";
            var objs = new List<TagInfo>();
            try
            {
                var dr = SqlHelper.ExecuteReader(this.connString, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToTagInfo(dr));
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
            return objs;
        }

        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到指标实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>指标实体。</returns>
        private static TagInfo ConvertToTagInfo(IDataRecord dr)
        {
            var obj = new TagInfo();
            obj.TagId = dr["I_Tag_Id"] == DBNull.Value  ? string.Empty : dr["I_Tag_Id"].ToString();
            obj.TagName = dr["I_Tag_Name"] == DBNull.Value ? string.Empty : dr["I_Tag_Name"].ToString();
            obj.DigNum = dr["I_Dig_Num"] == DBNull.Value ? (short)0 : short.Parse(dr["I_Dig_Num"].ToString());
            obj.Unit = dr["I_Unit"] == DBNull.Value ? string.Empty : dr["I_Unit"].ToString();
            obj.TagType = dr["I_Tag_Type"] == DBNull.Value ? string.Empty : dr["I_Tag_Type"].ToString();
            obj.Calc_Type_Before_Hour = dr["Calc_Type_Before_Hour"] == DBNull.Value ? (short) 0 : short.Parse(dr["Calc_Type_Before_Hour"].ToString());
            obj.Calc_Type_After_Hour = dr["Calc_Type_After_Hour"] == DBNull.Value ? (short) 0 : short.Parse(dr["Calc_Type_After_Hour"].ToString());
            obj.SecondToMinute = dr["Second_To_Minute"] == DBNull.Value ? false : (bool) dr["Second_To_Minute"];
            obj.MinuteToMin5 = dr["Minute_To_Min5"] == DBNull.Value ? false : (bool) dr["Minute_To_Min5"];
            obj.MinuteToHour = dr["Minute_To_Hour"] == DBNull.Value ? false : (bool) dr["Minute_To_Hour"];
            obj.HourToDay = dr["Hour_To_Day"] == DBNull.Value ? false : (bool) dr["Hour_To_Day"];
            obj.DayToMonth = dr["Day_To_Month"] == DBNull.Value ? false : (bool) dr["Day_To_Month"];
            obj.MonthToYear = dr["Month_To_Year"] == DBNull.Value ? false : (bool) dr["Month_To_Year"];
            obj.Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString();
            obj.Func = dr["Func"] == DBNull.Value ? string.Empty : dr["Func"].ToString();
            obj.DevCode = dr["Dev_Code"] == DBNull.Value ? string.Empty : dr["Dev_Code"].ToString();
            obj.MaxValue = dr["Max_Value"] == DBNull.Value ? double.MaxValue : (double) dr["Max_Value"];
            obj.MinValue = dr["Min_Value"] == DBNull.Value ? double.MinValue : (double) dr["Min_Value"];
            obj.DesignCD = dr["I_Design_CD"] == DBNull.Value ? string.Empty : dr["I_Design_CD"].ToString();
            obj.Address = dr["I_Address"] == DBNull.Value ? string.Empty : dr["I_Address"].ToString();
            obj.ParaA = dr["I_Para_A"] == DBNull.Value ? 1 : (double)dr["I_Para_A"];
            obj.ParaB = dr["I_Para_B"] == DBNull.Value ? 0 : (double)dr["I_Para_B"];
            obj.ParaC = dr["I_Para_C"] == DBNull.Value ? 1 : (double)dr["I_Para_C"];
            obj.MaxGatherValue = dr["I_Max"] == DBNull.Value ? double.MaxValue : (double) dr["I_Max"];
            obj.MinGatherValue = dr["I_Min"] == DBNull.Value ? double.MinValue : (double) dr["I_Min"];
            obj.Action = dr["I_Action"] == DBNull.Value ? (short) 0 : (short) dr["I_Action"];
            return obj;
        }
        #endregion
    }
}
