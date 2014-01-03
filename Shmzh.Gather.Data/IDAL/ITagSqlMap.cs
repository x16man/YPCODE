using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Gather.Data.Model;
using Shmzh.Components.SystemComponent;
namespace Shmzh.Gather.Data.IDAL
{
    /// <summary>
    /// 本地指标与第三方采集系统的指标对应关系数据访问接口。
    /// </summary>
    public interface ITagSqlMap
    {
        bool Insert(TagSqlMapInfo obj);

        bool Update(TagSqlMapInfo obj);

        bool Delete(TagSqlMapInfo obj);

        bool Delete(string tagId);

        List<TagSqlMapInfo> GetAll();

        List<TagSqlMapInfo> GetByContent(string content);

        TagSqlMapInfo GetByTagId(string tagId);

    }
}
