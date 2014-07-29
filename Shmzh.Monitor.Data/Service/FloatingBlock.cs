using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Data.Service
{
    class FloatingBlock:IDAL.IFloatingBlock
    {
        #region Implementation of IFloatingBlock

        /// <summary>
        /// 获取所有浮动窗口.
        /// </summary>
        /// <returns>所有浮动窗口.</returns>
        public List<FloatingBlockInfo> GetAll()
        {
            var objs = new FloatingBlockService.FloatingBlock().GetAll();
            var obj1s = new List<FloatingBlockInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new FloatingBlockInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="blockId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        public FloatingBlockInfo GetById(int blockId)
        {
            var obj = new FloatingBlockService.FloatingBlock().GetById(blockId);

            FloatingBlockInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new FloatingBlockInfo();
                CopyHelper.Copy(obj, obj1);
            }

            return obj1;
        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        public List<FloatingBlockInfo> GetBySchemaId(int schemaId)
        {
            var objs = new FloatingBlockService.FloatingBlock().GetBySchemaId(schemaId);
            var obj1s = new List<FloatingBlockInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new FloatingBlockInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="blockId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int blockId)
        {
            return new FloatingBlockService.FloatingBlock().Delete(blockId);
        }

        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Delete(FloatingBlockInfo blockInfo)
        {
            return Delete(blockInfo.BlockId);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>int</returns>
        public int Insert(FloatingBlockInfo blockInfo)
        {
            var obj = new FloatingBlockService.FloatingBlockInfo();
            CopyHelper.Copy(blockInfo, obj);
            
            return new FloatingBlockService.FloatingBlock().Insert(obj);
        }

        public int InsertWithTrans(SqlTransaction trans, FloatingBlockInfo blockInfo)
        {
            
            return DataProvider.FloatingBlockProvider.InsertWithTrans(trans, blockInfo);
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="blockInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Update(FloatingBlockInfo blockInfo)
        {
            var obj = new FloatingBlockService.FloatingBlockInfo();
            CopyHelper.Copy(blockInfo, obj);
            return new FloatingBlockService.FloatingBlock().Update(obj);
        }

        #endregion
    }
}
