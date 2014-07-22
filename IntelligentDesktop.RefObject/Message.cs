using System;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;
namespace IntelligentDesktop.RefObject
{
    /// <summary>
    /// 消息的SQLServer数据访问对象。
    /// </summary>
    [Serializable]
    public class Message : MarshalByRefObject, I_SD_Message
    {   
        private static I_SD_Message dal;
        static Message()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.SD_MessaageProvider;
        }

        #region I_SD_Message 成员

        /// <summary>
        /// 添加消息记录。
        /// </summary>
        /// <param name="messageInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Insert(SD_MessageInfo messageInfo)
        {
            return dal.Insert(messageInfo);
        }

         /// <summary>
        /// 修改消息记录。
        /// </summary>
        /// <param name="messageInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Update(SD_MessageInfo messageInfo)
        {
            return dal.Update(messageInfo);
        }
        
        /// <summary>
        /// 删除消息记录实体。
        /// </summary>
        /// <param name="messageInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Delete(SD_MessageInfo messageInfo)
        {
            return dal.Delete(messageInfo);
        }
        
        /// <summary>
        /// 获取所有消息记录集合。
        /// </summary>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetALL()
        {
            return dal.GetALL();
        }
        
        /// <summary>
        /// 根据处理人用户名获取消息记录集合。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByHandler(string handlerUserName)
        {
            return dal.GetByHandler(handlerUserName);
        }
       
        /// <summary>
        /// 根据处理人用户名和消息记录状态获取消息记录集合。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <param name="status">消息记录状态。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByHandlerAndStatus(string handlerUserName, short status)
        {
            return dal.GetByHandlerAndStatus(handlerUserName, status);
        }
       
        /// <summary>
        /// 根据处理人用户名和消息类型获取消息记录集合。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <param name="typeId">消息类型Id。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByHandlerAndType(string handlerUserName, string typeId)
        {
            return dal.GetByHandlerAndType(handlerUserName, typeId);
        }

        public IList<SD_MessageInfo> GetByHandlerAndStatusAndType(string handlerUserName, short status, string typeId)
        {
            return dal.GetByHandlerAndStatusAndType(handlerUserName, status, typeId);
        }

        /// <summary>
        /// 根据发送人用户名和发送时间获取消息记录集合。
        /// </summary>
        /// <param name="referUserName">发送人用户名。</param>
        /// <param name="createTime">发送时间。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByReferAndCreateTime(string referUserName, DateTime createTime)
        {
            return dal.GetByReferAndCreateTime(referUserName, createTime);
        }

        /// <summary>
        /// 根据WhereClause语句来获取消息记录的集合。
        /// </summary>
        /// <param name="whereClause">SQL的Where条件语句。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByWhereClause(string whereClause)
        {
            return dal.GetByWhereClause(whereClause);
        }
        
       
        /// <summary>
        /// 根据WhereClause语句来获取发送消息记录的集合。
        /// </summary>
        /// <param name="whereClause">SQL的Where条件语句。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetSendMsgByWhereClause(string whereClause)
        {
            return dal.GetSendMsgByWhereClause(whereClause);
        }

        /// <summary>
        /// 根据处理人获取未读的分组统计的消息个数。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <returns>消息类型记录集合。</returns>
        public IList<SD_MessageTypeInfo> GetNoReadMsgGroupsByHandler(String handlerUserName)
        {
            return dal.GetNoReadMsgGroupsByHandler(handlerUserName);
        }

        /// <summary>
        /// 据接收人获取最后收取和读取消息的时间。
        /// </summary>
        /// <param name="handlerUserName">接收人用户名</param>
        /// <param name="strIPAddress">IP地址。</param>
        /// <returns></returns>
        public SDTransferInfo GetLastMsgInfoByHandler(String handlerUserName, String strIPAddress)
        {
            return dal.GetLastMsgInfoByHandler(handlerUserName, strIPAddress);
        }
        
         /// <summary>
        /// 据接收人用户名将消息状态设置为已接收（已提示）。
        /// </summary>
        /// <param name="handlerUserName">接收人用户名</param>
        /// <returns></returns>
        public Boolean SetStatusToReceivedByHandler(String handlerUserName)
        {
            return dal.SetStatusToReceivedByHandler(handlerUserName);
        }
       
        /// <summary>
        /// 据接消息ID将消息状态设置为已读。
        /// </summary>
        /// <param name="id">消息ID。</param>
        /// <returns></returns>
        public Boolean SetStatusToReadById(long id)
        {
            return dal.SetStatusToReadById(id);
        }

        public SD_MessageInfo GetById(long id)
        {
            return dal.GetById(id);
        }
              
        /// <summary>
        /// 从数据库中获取当前时间。
        /// </summary>
        /// <returns>当前时间。</returns>
        public DateTime GetCurrentTimeFromDB()
        {
            return dal.GetCurrentTimeFromDB();
        }

        #endregion

    }
}
