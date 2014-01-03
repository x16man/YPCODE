using System;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    public interface ISchemaData
    {
        /// <summary>
        /// 根据指定的报表模板和日期以及是否能够修改选项获取报表的数据内容
        /// </summary>
        /// <param name="id">报表模板Id。</param>
        /// <param name="currentDate">报表日期。</param>
        /// <param name="canModify">是否能够修改。</param>
        /// <returns>报表数据对象.</returns>
        SchemaDataInfo GetSchemaData(string id, DateTime currentDate, bool canModify);

        /// <summary>
        /// 保存报表数据。
        /// </summary>
        /// <param name="obj">报表数据对象。</param>
        /// <returns>bool</returns>
        bool SaveSchemaData(SchemaDataInfo obj);

        /// <summary>
        /// 确认报表数据.
        /// </summary>
        /// <param name="obj">报表数据对象.</param>
        /// <returns>bool</returns>
        bool SureSchemaData(SchemaDataInfo obj);

        /// <summary>
        /// 取消确认报表数据.
        /// </summary>
        /// <param name="obj">报表数据对象.</param>
        /// <returns>bool</returns>
        bool CancelSchemaData(SchemaDataInfo obj);
    }
}
