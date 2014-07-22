using System;
using System.Collections.Generic;
using System.Data;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.Bases
{
    public abstract class ProjectExtProvider: IDAL.IProjectExt
    {
        #region Protected Method
        protected ProjectExtInfo ConvertToObject(IDataReader dr)
        {
            var obj = new ProjectExtInfo()
            {
                ProjectId = dr.GetInt32(0),
                IsHidden = dr.GetBoolean(1),
            };
            return obj;
        }
        #endregion

        #region Implementation of IProjectExt

        /// <summary>
        /// 添加项目扩展属性.
        /// </summary>
        /// <param name="obj">项目扩展属性</param>
        /// <returns>bool</returns>
        public abstract bool Insert(ProjectExtInfo obj);

        /// <summary>
        /// 更改项目扩展属性.
        /// </summary>
        /// <param name="obj">项目扩展属性.</param>
        /// <returns>bool</returns>
        public abstract bool Update(ProjectExtInfo obj);

        /// <summary>
        /// 删除项目扩展属性.
        /// </summary>
        /// <param name="obj">项目扩展属性对象.,</param>
        /// <returns>bool</returns>
        public bool Delete(ProjectExtInfo obj)
        {
            return this.Delete(obj.ProjectId);
        }

        /// <summary>
        /// 删除项目扩展属性.
        /// </summary>
        /// <param name="projectId">项目Id.</param>
        /// <returns>bool</returns>
        public abstract bool Delete(int projectId);

        /// <summary>
        /// 获取所有项目扩展属性.
        /// </summary>
        /// <returns>项目扩展属性集合.</returns>
        public abstract List<ProjectExtInfo> GetAll();

        /// <summary>
        /// 根据项目Id获取项目扩展属性.
        /// </summary>
        /// <param name="projectId">项目Id.</param>
        /// <returns>项目扩展属性.</returns>
        public abstract ProjectExtInfo GetByProjectId(int projectId);

        #endregion
    }
}
