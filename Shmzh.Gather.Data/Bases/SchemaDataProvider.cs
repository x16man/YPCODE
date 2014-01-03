using System;
using Shmzh.Gather.Data.IDAL;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    public abstract class SchemaDataProvider:ISchemaData
    {
        #region Implementation of ISchemaData

        /// <summary>
        /// 根据指定的报表模板和日期以及是否能够修改选项获取报表的数据内容
        /// </summary>
        /// <param name="id">报表模板Id。</param>
        /// <param name="currentDate">报表日期。</param>
        /// <param name="canModify">是否能够修改。</param>
        /// <param name="isZipped">报表内容是否需要Gzip压缩。</param>
        /// <returns>报表数据对象.</returns>
        public abstract SchemaDataInfo GetSchemaData(string id, DateTime currentDate, bool canModify);

        /// <summary>
        /// 保存报表数据。
        /// </summary>
        /// <param name="obj">报表数据对象。</param>
        /// <returns>bool</returns>
        public abstract bool SaveSchemaData(SchemaDataInfo obj);

        /// <summary>
        /// 确认报表数据.
        /// </summary>
        /// <param name="obj">报表数据对象.</param>
        /// <returns>bool</returns>
        public abstract bool SureSchemaData(SchemaDataInfo obj);

        /// <summary>
        /// 取消确认报表数据.
        /// </summary>
        /// <param name="obj">报表数据对象.</param>
        /// <returns>bool</returns>
        public abstract bool CancelSchemaData(SchemaDataInfo obj);

        #endregion
    }
}
