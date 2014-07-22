using System.Collections.Generic;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Data
{
    /// <summary>
    /// 提供可以全局访问的数据对象.
    /// </summary>
    public sealed class GlobleVariables
    {
        #region Field
        private static readonly object SyncRoot = new object();
        private static List<CategoryInfo> _categoryList = null;
        private static List<CategoryItemInfo> _categoryItemList = null;
        private static List<MonitorObjInfo> _monitorObjList = null;
        private static List<GraphSchemaInfo> _graphSchemaList = null;
        private static List<GraphSchemaItemInfo> _graphSchemaItemList = null;
        private static List<GraphSchemaTagInfo> _graphSchemaTagList = null;
        #endregion

        #region Property

        /// <summary>
        /// 监控方案分类集合.
        /// </summary>
        public static List<CategoryInfo> CategoryList
        {
            get
            {
                if(_categoryList == null)
                {
                    lock(SyncRoot)
                    {
                        if(_categoryList == null)
                        {
                            RefreshCategoryList();
                        }
                    }
                }
                return _categoryList;
            }
        }
        /// <summary>
        /// 分类下监控方案项集合.
        /// </summary>
        public static List<CategoryItemInfo> CategoryItemList
        {
            get
            {
                if(_categoryItemList == null)
                {
                    lock (SyncRoot)
                    {
                        if(_categoryItemList == null)
                        {
                            RefreshCategoryItemList();
                        }
                    }
                }
                return _categoryItemList;
            }
        }
        /// <summary>
        /// 监控对象集合.
        /// </summary>
        public static List<MonitorObjInfo> MonitorObjList
        {
            get
            {
                if(_monitorObjList == null)
                {
                    lock (SyncRoot)
                    {
                        if(_monitorObjList == null)
                        {
                            RefreshMonitorObjList();
                        }
                    }
                }
                return _monitorObjList;
            }
        }
        /// <summary>
        /// 监控方案集合.
        /// </summary>
        public static List<GraphSchemaInfo> GraphSchemaList
        {
            get
            {
                if(_graphSchemaList == null)
                {
                    lock (SyncRoot)
                    {
                        if(_graphSchemaList == null)
                        {
                            RefreshGraphSchemaList();
                        }
                    }
                }
                return _graphSchemaList;
            }
        }
        /// <summary>
        /// GraphSchemaItemList.
        /// </summary>
        public static List<GraphSchemaItemInfo> GraphSchemaItemList
        {
            get
            {
                if(_graphSchemaItemList == null)
                {
                    lock (SyncRoot)
                    {
                        if(_graphSchemaItemList==null)
                        {
                            RefreshGraphSchemaItemList();
                        }
                    }
                }
                return _graphSchemaItemList;
            }
        }
        /// <summary>
        /// GraphSchemaTagList
        /// </summary>
        public static List<GraphSchemaTagInfo> GraphSchemaTagList
        {
            get
            {
                if(_graphSchemaTagList == null)
                {
                    lock (SyncRoot)
                    {
                        if(_graphSchemaTagList == null)
                        {
                            RefreshGraphSchemaTagList();
                        }
                    }
                }
                return _graphSchemaTagList;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 刷新监控方案分类集合.
        /// </summary>
        public static void RefreshCategoryList()
        {
            _categoryList = DataProvider.CategoryProvider.GetAll();
        }
        /// <summary>
        /// 刷新分类下监控方案项集合.
        /// </summary>
        public static void RefreshCategoryItemList()
        {
            _categoryItemList = DataProvider.CategoryItemProvider.GetAll();
        }
        /// <summary>
        /// 刷新监控对象列表.
        /// </summary>
        public static void RefreshMonitorObjList()
        {
            _monitorObjList = DataProvider.MonitorObjProvider.GetAll();
        }
        /// <summary>
        /// 刷新监控方案列表.
        /// </summary>
        public static void RefreshGraphSchemaList()
        {
            _graphSchemaList = DataProvider.GraphSchemaProvider.GetAll();
        }
        /// <summary>
        /// 刷新GraphSchemaItemList.
        /// </summary>
        public static void RefreshGraphSchemaItemList()
        {
            _graphSchemaItemList = DataProvider.GraphSchemaItemProvider.GetAll();
        }
        /// <summary>
        /// 刷新GraphSchemaTagList.
        /// </summary>
        public static void RefreshGraphSchemaTagList()
        {
            _graphSchemaTagList = DataProvider.GraphSchemaTagProvider.GetAll();
        }
        #endregion

    }
}