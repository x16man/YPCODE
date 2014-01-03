using System.Collections;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 配置信息的数据访问接口。
    /// </summary>
    public interface ISetting
    {
        /// <summary>
        /// 添加配置信息。
        /// </summary>
        /// <param name="settingInfo">配置信息实体。</param>
        /// <returns>bool</returns>
        bool Insert(SettingInfo settingInfo);
        /// <summary>
        /// 修改配置信息。
        /// </summary>
        /// <param name="settingInfo">配置信息实体。</param>
        /// <returns>bool</returns>
        bool Update(SettingInfo settingInfo);
        /// <summary>
        /// 删除配置信息。
        /// </summary>
        /// <param name="settingInfo">配置信息实体。</param>
        /// <returns>bool</returns>
        bool Delete(SettingInfo settingInfo);
        /// <summary>
        /// 删除配置信息。
        /// </summary>
        /// <param name="key">配置信息编号。</param>
        /// <returns>bool</returns>
        bool Delete(string key);
        /// <summary>
        /// 是否已经存在配置信息名称。
        /// </summary>
        /// <param name="key">配置信息的键。</param>
        /// <returns>bool</returns>
        bool IsExist(string key);
        /// <summary>
        /// 获取所有配置信息。
        /// </summary>
        /// <returns>配置信息集合。</returns>
        IList<SettingInfo> GetAll();
        /// <summary>
        /// 根据分类获取配置信息。
        /// </summary>
        /// <param name="category">分类名称。</param>
        /// <returns>配置信息集合。</returns>
        IList<SettingInfo> GetByCategory(string category);
        /// <summary>
        /// 根据配置信息编号获取配置信息。
        /// </summary>
        /// <param name="key">配置信息编号。</param>
        /// <returns>配置信息。</returns>
        SettingInfo GetByKey(string key);
        

    }
}
