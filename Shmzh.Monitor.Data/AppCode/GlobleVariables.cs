using System.Collections.Generic;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Data
{
    /// <summary>
    /// �ṩ����ȫ�ַ��ʵ����ݶ���.
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
        /// ��ط������༯��.
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
        /// �����¼�ط������.
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
        /// ��ض��󼯺�.
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
        /// ��ط�������.
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
        /// ˢ�¼�ط������༯��.
        /// </summary>
        public static void RefreshCategoryList()
        {
            _categoryList = DataProvider.CategoryProvider.GetAll();
        }
        /// <summary>
        /// ˢ�·����¼�ط������.
        /// </summary>
        public static void RefreshCategoryItemList()
        {
            _categoryItemList = DataProvider.CategoryItemProvider.GetAll();
        }
        /// <summary>
        /// ˢ�¼�ض����б�.
        /// </summary>
        public static void RefreshMonitorObjList()
        {
            _monitorObjList = DataProvider.MonitorObjProvider.GetAll();
        }
        /// <summary>
        /// ˢ�¼�ط����б�.
        /// </summary>
        public static void RefreshGraphSchemaList()
        {
            _graphSchemaList = DataProvider.GraphSchemaProvider.GetAll();
        }
        /// <summary>
        /// ˢ��GraphSchemaItemList.
        /// </summary>
        public static void RefreshGraphSchemaItemList()
        {
            _graphSchemaItemList = DataProvider.GraphSchemaItemProvider.GetAll();
        }
        /// <summary>
        /// ˢ��GraphSchemaTagList.
        /// </summary>
        public static void RefreshGraphSchemaTagList()
        {
            _graphSchemaTagList = DataProvider.GraphSchemaTagProvider.GetAll();
        }
        #endregion

    }
}