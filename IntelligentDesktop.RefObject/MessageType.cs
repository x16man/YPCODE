namespace IntelligentDesktop.RefObject
{
    using System;
    using System.Collections.Generic;
    using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.IDAL;
    /// <summary>
    /// 消息类型的SQLServer数据访问类。
    /// </summary>
    [Serializable]
    public class MessageType : MarshalByRefObject, I_SD_MessageType
    {
        private static I_SD_MessageType dal;
        static MessageType()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.SD_MessageTypeProvider;
        }

        #region I_SD_MessageType 成员
        /// <summary>
        /// 添加消息记录。
        /// </summary>
        /// <param name="messageTypeInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Insert(SD_MessageTypeInfo messageTypeInfo)
        {
            return dal.Insert(messageTypeInfo);
        }

        /// <summary>
        /// 修改消息记录实体。
        /// </summary>
        /// <param name="messageTypeInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Update(SD_MessageTypeInfo messageTypeInfo)
        {
            return dal.Update(messageTypeInfo);
        }
        
         /// <summary>
        /// 删除消息类型。
        /// </summary>
        /// <param name="messageTypeInfo">消息类型实体。</param>
        /// <returns>bool</returns>
        public bool Delete(SD_MessageTypeInfo messageTypeInfo)
        {
            return dal.Delete(messageTypeInfo);
        }

        /// <summary>
        /// 获取所有的消息类型。
        /// </summary>
        /// <returns>消息类型集合。</returns>
        public IList<SD_MessageTypeInfo> GetALL()
        {
            return dal.GetALL();
        }
       
        /// <summary>
        /// 根据ID获取消息类型。
        /// </summary>
        /// <param name="id">消息类型ID。</param>
        /// <returns>消息类型实体。</returns>
        public SD_MessageTypeInfo GetById(string id)
        {
            return dal.GetById(id);
        }
       
         /// <summary>
        /// 消息类型排序号调整。
        /// </summary>
        /// <param name="id">消息类型Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public Boolean Move(String id, Byte opType)
        {
            return dal.Move(id, opType);
        }
        
        /// <summary>
        /// 验证消息类型是否允许删除。
        /// </summary>
        /// <param name="typeId">消息类型Id。</param>
        /// <returns>bool</returns>
        public Boolean IsAllowDelete(String typeId)
        {
            return dal.IsAllowDelete(typeId);
        }
        #endregion
    }
}
