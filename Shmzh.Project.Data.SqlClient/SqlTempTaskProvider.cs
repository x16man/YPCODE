using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Shmzh.Project.Data.Bases;
using Shmzh.Project.Entity;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Project.Data.SqlClient
{
    public class SqlTempTaskProvider : TempTaskProvider
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        
        #region Property

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
        /// </summary>
        /// <value>The name of the provider invariant.</value>
        public string ProviderInvariantName { get; set; }

        #endregion

        #region CTOR
        /// <summary>
        /// Creates a new <see cref="SqlTempTaskProvider"/> instance.
        /// </summary>
        public SqlTempTaskProvider()
        {
        }
        /// <summary>
        /// Creates a new <see cref="SqlTempTaskProvider"/> instance.
        /// Uses connection string to connect to datasource.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public SqlTempTaskProvider(string connectionString, string providerInvariantName)
        {
            this.ConnectionString = connectionString;
            this.ProviderInvariantName = providerInvariantName;
        }
        #endregion

        /// <summary>
        /// 最近24小时任务。
        /// </summary>
        /// <param name="projectType">项目类型，例如""或"类型1,类型2"或"类型1"</param>
        /// <param name="fState">项目状态，例如""或"不通过,已确认,未完成,已完成"或"未完成"</param>
        /// <returns></returns>
        public override List<TempTaskInfo> GetDayTask(String projectType, String fState)
        {
            String otherCondition = "";
            if (!String.IsNullOrEmpty(projectType))
            {
                projectType = String.Concat("'", projectType, "'");
                projectType = projectType.Replace(",", "','");
                projectType = String.Format("[fType] IN ({0})", projectType);
                otherCondition += " AND " + projectType;
            }
            if (!String.IsNullOrEmpty(fState))
            {
                fState = String.Concat("'", fState, "'");
                fState = fState.Replace(",", "','");
                fState = String.Format("[fState] IN ({0})", fState);
                otherCondition += " AND " + fState;
            }
            return GetTask(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), otherCondition);
        }

        /// <summary>
        /// 最近1周未完成任务。
        /// </summary>
        /// <param name="projectType">项目类型，例如""或"类型1,类型2"或"类型1"</param>
        /// <param name="fState">项目状态，例如""或"不通过,已确认,未完成,已完成"或"未完成"</param>
        /// <returns></returns>
        public override List<TempTaskInfo> GetWeekTask(String projectType, String fState)
        {
            String otherCondition = ""; //"fCompletePercent <> '100' AND (fState = '未完成' Or fState = '不通过')";
            if (!String.IsNullOrEmpty(projectType))
            {
                projectType = String.Concat("'", projectType, "'");
                projectType = projectType.Replace(",", "','");
                projectType = String.Format("[fType] IN ({0})", projectType);
                otherCondition += " AND " + projectType;
            }
            if (!String.IsNullOrEmpty(fState))
            {
                fState = String.Concat("'", fState, "'");
                fState = fState.Replace(",", "','");
                fState = String.Format("[fState] IN ({0})", fState);
                otherCondition += " AND " + fState;
            }
            return GetTask(DateTime.Now, DateTime.Now.AddDays(7), otherCondition);
        }

        /// <summary>
        /// 根据查询条件获取任务。
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="otherCondition">其他条件</param>
        /// <returns>任务集合</returns>
        public override List<TempTaskInfo> GetTask(DateTime startTime, DateTime endTime, String otherCondition)
        {
            var  sqlStatement = @"SELECT [fID],[fName],[fType],[fPriority],[fState],[fPlanStartDate],[fPlanFinishDate],
                  [fPlanWorkTimeLimit],[fRealStartDate],[fRealFinishDate],[fRealWorkTimeLimit],
                  [fCompletePercent],[fPrincipal],[fMaster],[fExaminant],[fMemo],[fCreateTime]
              FROM [tTempTask] WHERE [fPlanFinishDate] BETWEEN @StartTime AND @EndTime";
            if (!String.IsNullOrEmpty(otherCondition))
                sqlStatement = String.Concat(sqlStatement, otherCondition);
            sqlStatement = String.Concat(sqlStatement, " ORDER BY [fPlanFinishDate]");
            var parms = new[] {
                    new SqlParameter("@StartTime", SqlDbType.DateTime) {Value = startTime},
                    new SqlParameter("@EndTime", SqlDbType.DateTime) {Value = endTime}
                };
            var objs = new List<TempTaskInfo>();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, sqlStatement, parms))
                {
                    while ((dr.Read()))
                    {
                        objs.Add(ConvertToObject(dr));
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }

            return objs;  
        }
    }
}
