using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
namespace Shmzh.Monitor.Data.Service
{
    class FloatingBlockItem:IDAL.IFloatingBlockItem
    {
        #region Implementation of IFloatingBlockItem

        /// <summary>
        /// 获取所有FloatingBlockItemInfo.
        /// </summary>
        /// <returns>所有FloatingBlockItemInfo.</returns>
        public List<FloatingBlockItemInfo> GetAll()
        {
            var objs = new FloatingBlockItemService.FloatingBlockItem().GetAll();
            var obj1s = new List<FloatingBlockItemInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new FloatingBlockItemInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据方案项指标Id获取方案信息。
        /// </summary>
        /// <param name="blockItemId">方案关联项Id。</param>
        /// <returns>方案关联项信息实体。</returns>
        public FloatingBlockItemInfo GetById(int blockItemId)
        {
            var obj = new FloatingBlockItemService.FloatingBlockItem().GetById(blockItemId);
            FloatingBlockItemInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new FloatingBlockItemInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据曲线方案项Id获取曲线方案关联项集合。
        /// </summary>
        /// <param name="blockId">曲线方案Id。</param>
        /// <returns>曲线指标集合。</returns>
        public List<FloatingBlockItemInfo> GetByBlockId(int blockId)
        {
            var objs = new FloatingBlockItemService.FloatingBlockItem().GetByBlockId(blockId);
            var obj1s = new List<FloatingBlockItemInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new FloatingBlockItemInfo();
                CopyHelper.Copy(obj,obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据曲线方案关联项Id进行删除。
        /// </summary>
        /// <param name="rTagId">曲线方案关联项Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int rTagId)
        {
            return new FloatingBlockItemService.FloatingBlockItem().Delete(rTagId);
        }

        /// <summary>
        /// 删除曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Delete(FloatingBlockItemInfo blockItemInfo)
        {
            return Delete(blockItemInfo.BlockItemId);
        }

        /// <summary>
        /// 添加曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Insert(FloatingBlockItemInfo blockItemInfo)
        {
            var obj = new FloatingBlockItemService.FloatingBlockItemInfo();
            CopyHelper.Copy(blockItemInfo, obj);
            return new FloatingBlockItemService.FloatingBlockItem().Insert(obj);
        }

        public Boolean InsertWithTrans(SqlTransaction trans, FloatingBlockItemInfo blockItemInfo)
        {
            return DataProvider.FloatingBlockItemProvider.InsertWithTrans(trans, blockItemInfo);
        }

        /// <summary>
        /// 修改曲线方案关联项。
        /// </summary>
        /// <param name="blockItemInfo">曲线方案关联项对象。</param>
        /// <returns>bool</returns>
        public bool Update(FloatingBlockItemInfo blockItemInfo)
        {
            var obj = new FloatingBlockItemService.FloatingBlockItemInfo();
            CopyHelper.Copy(blockItemInfo, obj);
            return new FloatingBlockItemService.FloatingBlockItem().Update(obj);
        }

        /// <summary>
        /// 浮动窗口项移动。
        /// </summary>
        /// <param name="blockItemId">指标项Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public bool Move(int blockItemId, byte opType)
        {
            return new FloatingBlockItemService.FloatingBlockItem().Move(blockItemId, opType);
        }

        #endregion
    }
}
