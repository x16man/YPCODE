using System;
using System.Collections.Generic;
using System.Data;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.Bases
{
    public abstract class TempTaskProvider: IDAL.ITempTask
    {
        #region Protected Method
        protected TempTaskInfo ConvertToObject(IDataReader dr)
        {
            var obj = new TempTaskInfo();
            obj.Id = Convert.ToInt32(dr["fID"]);
            obj.Name = dr["fName"] == DBNull.Value ? String.Empty : dr["fName"].ToString();
            obj.Type = dr["fType"] == DBNull.Value ? String.Empty : dr["fType"].ToString();
            obj.Priority = dr["fPriority"] == DBNull.Value ? String.Empty : dr["fPriority"].ToString();
            obj.State = dr["fState"] == DBNull.Value ? String.Empty : dr["fState"].ToString();
            obj.PlanStartDate = dr["fPlanStartDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["fPlanStartDate"]);
            obj.PlanFinishDate = dr["fPlanFinishDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["fPlanFinishDate"]);
            obj.PlanWorkTimeLimit = dr["fPlanWorkTimeLimit"] == DBNull.Value ? String.Empty : dr["fPlanWorkTimeLimit"].ToString();
            obj.RealStartDate = dr["fRealStartDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["fRealStartDate"]);
            obj.RealFinishDate = dr["fRealFinishDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["fRealFinishDate"]);
            obj.RealWorkTimeLimit = dr["fRealWorkTimeLimit"] == DBNull.Value ? String.Empty : dr["fRealWorkTimeLimit"].ToString();
            obj.CompletePercent = dr["fCompletePercent"] == DBNull.Value ? String.Empty : dr["fCompletePercent"].ToString();
            obj.Principal = dr["fPrincipal"] == DBNull.Value ? String.Empty : dr["fPrincipal"].ToString();
            obj.Master = dr["fMaster"] == DBNull.Value ? String.Empty : dr["fMaster"].ToString();
            obj.Examinant = dr["fExaminant"] == DBNull.Value ? String.Empty : dr["fExaminant"].ToString();
            obj.Memo = dr["fMemo"] == DBNull.Value ? String.Empty : dr["fMemo"].ToString();
            obj.CreateTime = dr["fCreateTime"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["fCreateTime"]);
            return obj;
        }
        #endregion

        #region Implementation of ITempTask

        /// <summary>
        /// 最近24小时任务。
        /// </summary>
        /// <param name="projectType">项目类型，例如""或"类型1,类型2"或"类型1"</param>
        /// <param name="fState">项目状态，例如""或"不通过,已确认,未完成,已完成"或"未完成"</param>
        /// <returns>任务集合</returns>
        public abstract List<TempTaskInfo> GetDayTask(string projectType, string fState);

        /// <summary>
        /// 最近1周未完成任务。
        /// </summary>
        /// <param name="projectType">项目类型，例如""或"类型1,类型2"或"类型1"</param>
        /// <param name="fState">项目状态，例如""或"不通过,已确认,未完成,已完成"或"未完成"</param>
        /// <returns>任务集合</returns>
        public abstract List<TempTaskInfo> GetWeekTask(string projectType, string fState);

        /// <summary>
        /// 根据查询条件获取任务。
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="otherCondition">其他条件</param>
        /// <returns>任务集合</returns>
        public abstract List<TempTaskInfo> GetTask(DateTime startTime, DateTime endTime, string otherCondition);

        #endregion
    }
}
