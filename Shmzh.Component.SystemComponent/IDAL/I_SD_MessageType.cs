using System;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 消息记录的数据访问接口。
    /// </summary>
    public interface I_SD_MessageType
    {
        /// <summary>
        /// 添加消息记录。
        /// </summary>
        /// <param name="messageTypeInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        bool Insert( SD_MessageTypeInfo messageTypeInfo);
        
        /// <summary>
        /// 修改消息记录实体。
        /// </summary>
        /// <param name="messageTypeInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        bool Update( SD_MessageTypeInfo messageTypeInfo);
        
        /// <summary>
        /// 删除消息类型。
        /// </summary>
        /// <param name="messageTypeInfo">消息类型实体。</param>
        /// <returns>bool</returns>
        bool Delete( SD_MessageTypeInfo messageTypeInfo);

        /// <summary>
        /// 获取所有的消息类型。
        /// </summary>
        /// <returns>消息类型集合。</returns>
        IList<SD_MessageTypeInfo> GetALL();

        /// <summary>
        /// 根据ID获取消息类型。
        /// </summary>
        /// <param name="id">消息类型ID。</param>
        /// <returns>消息类型实体。</returns>
        SD_MessageTypeInfo GetById(string id);

        /// <summary>
        /// 消息类型排序号调整。
        /// </summary>
        /// <param name="id">消息类型Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        Boolean Move(String id, Byte opType);

        /// <summary>
        /// 验证消息类型是否允许删除。
        /// </summary>
        /// <param name="typeId">消息类型Id。</param>
        /// <returns>bool</returns>
        Boolean IsAllowDelete(String typeId);
    }
}
