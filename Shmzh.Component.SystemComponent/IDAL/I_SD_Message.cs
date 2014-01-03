using System;
using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 消息记录的数据访问接口。
    /// </summary>
    public interface I_SD_Message
    {
        /// <summary>
        /// 添加消息记录。
        /// </summary>
        /// <param name="messageInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        bool Insert( SD_MessageInfo messageInfo);
        /// <summary>
        /// 修改消息记录实体。
        /// </summary>
        /// <param name="messageInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        bool Update( SD_MessageInfo messageInfo);
        /// <summary>
        /// 删除消息记录实体。
        /// </summary>
        /// <param name="messageInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        bool Delete( SD_MessageInfo messageInfo);

        /// <summary>
        /// 获取所有的消息记录实体。
        /// </summary>
        /// <returns></returns>
        IList<SD_MessageInfo> GetALL();

        /// <summary>
        /// 根据处理人获取消息记录集合。
        /// </summary>
        /// <param name="HandlerUserName">处理人用户名。</param>
        /// <returns>消息记录集合。</returns>
        IList<SD_MessageInfo> GetByHandler(string HandlerUserName);
        
        /// <summary>
        /// 根据处理人和消息状态获取消息记录集合。
        /// </summary>
        /// <param name="HandlerUserName">处理人用户名。</param>
        /// <param name="status">状态</param>
        /// <returns>消息记录集合。</returns>
        IList<SD_MessageInfo> GetByHandlerAndStatus(string HandlerUserName, short status);
        
        /// <summary>
        /// 根据处理人和消息类型获取消息记录集合。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <param name="typeId">消息类型ID。</param>
        /// <returns>消息记录集合。</returns>
        IList<SD_MessageInfo> GetByHandlerAndType(string handlerUserName, string typeId);
        
        /// <summary>
        /// 根据处理人和消息状态和消息类型获取消息记录集合。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <param name="status">消息状态。</param>
        /// <param name="typeId">消息类型。</param>
        /// <returns>消息记录集合。</returns>
        IList<SD_MessageInfo> GetByHandlerAndStatusAndType(string handlerUserName, short status, string typeId);

        /// <summary>
        /// 根据发送人用户名和发送时间获取消息记录集合。
        /// </summary>
        /// <param name="referUserName">发送人用户名。</param>
        /// <param name="createTime">发送时间。</param>
        /// <returns>消息记录集合。</returns>
        IList<SD_MessageInfo> GetByReferAndCreateTime(string referUserName, DateTime createTime);
        
        /// <summary>
        /// 根据Where条件语句字符串来获取消息记录集合。
        /// </summary>
        /// <param name="whereClause">where条件字符串。</param>
        /// <returns>消息记录集合。</returns>
        IList<SD_MessageInfo> GetByWhereClause(string whereClause);

        /// <summary>
        /// 根据WhereClause语句来获取发送消息记录的集合。
        /// </summary>
        /// <param name="whereClause">SQL的Where条件语句。</param>
        /// <returns>消息记录集合。</returns>
        IList<SD_MessageInfo> GetSendMsgByWhereClause(string whereClause);

        /// <summary>
        /// 根据处理人获取未读的分组统计的消息个数。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <returns>消息类型记录集合。</returns>
        IList<SD_MessageTypeInfo> GetNoReadMsgGroupsByHandler(String handlerUserName);

        /// <summary>
        /// 据接收人获取最后收取和读取消息的时间。
        /// </summary>
        /// <param name="handlerUserName">接收人用户名</param>
        /// <param name="strIPAddress">IP地址。</param>
        /// <returns></returns>
        SDTransferInfo GetLastMsgInfoByHandler(String handlerUserName, String strIPAddress);

        /// <summary>
        /// 据接收人用户名将消息状态设置为已接收（已提示）。
        /// </summary>
        /// <param name="handlerUserName">接收人用户名</param>
        /// <returns></returns>
        Boolean SetStatusToReceivedByHandler(String handlerUserName);

        /// <summary>
        /// 据接消息ID将消息状态设置为已读。
        /// </summary>
        /// <param name="id">消息ID。</param>
        /// <returns></returns>
        Boolean SetStatusToReadById(long id);

        /// <summary>
        /// 根据ID获取消息记录。
        /// </summary>
        /// <param name="id">消息记录ID。</param>
        /// <returns>消息记录实体。</returns>
        SD_MessageInfo GetById(long id);

        /// <summary>
        /// 从数据库中获取当前时间。
        /// </summary>
        /// <returns>当前时间。</returns>
        DateTime GetCurrentTimeFromDB();

    }
}
