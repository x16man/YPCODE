using System;
using System.Collections.Generic;
using System.Text;
using ZedGraph;

namespace Shmzh.Monitor.Forms
{
    /// <summary>
    /// 用于存储各个指标的指标值列表。
    /// </summary>
    public class PointListCollection<T>
    {
        private List<KeyPointList> _myList = new List<KeyPointList>();
        
        /// <summary>
        /// 根据关键字检索单个T.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T this[String key]
        {
            get
            {
                var obj = _myList.Find(o => o.Key.Equals(key));
                return obj == null ? default(T) : obj.PointList;
            }
            set
            {
                var obj = _myList.Find(o => o.Key.Equals(key));
                obj.PointList = value;
                obj.IsEmpty = false;
            }
        }

        /// <summary>
        /// 根据关键字检索单个T.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T this[Int32 key]
        {
            get
            {
                return this[key.ToString()];
            }
            set
            {
                this[key.ToString()] = value;
            }
        }

        /// <summary>
        /// 获取所有的 T.
        /// </summary>
        public List<T> Items
        {
            get
            {
                var list = new List<T>();
                foreach (KeyPointList myStruct in _myList)
                {
                    list.Add(myStruct.PointList);
                }
                return list;
            }
        }

        

        public void Add(Int32 key)
        {            
            Add(key.ToString());
        }

        public void Add(String key)
        {
            if (!Contains(key))
            {
                _myList.Add(new KeyPointList { Key = key, PointList = default(T) });
            }
        }

        /// <summary>
        /// 检测集合中是否包含指定Key的KeyPointList实例。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Boolean Contains(Object key)
        {
            String strKey = key.ToString();
            foreach (var obj in _myList)
            {
                if (obj.Key.Equals(strKey))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 根据Key获取单个KeyPointList实例。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public KeyPointList Get(Object key)
        {
            String strKey = key.ToString();
            foreach (var obj in _myList)
            {
                if (obj.Key.Equals(strKey))
                {
                    return obj;
                }
            }
            return null;
        }
                        
        public void Set(String key, T pointPairList)
        {
            this[key] = pointPairList;
        }

        public void Set(Int32 key, T pointPairList)
        {
            this[key.ToString()] = pointPairList;
        }        

        /// <summary>
        /// 清空所有项中的T,保留Key。
        /// </summary>
        public void Clear()
        {
            foreach (KeyPointList myStruct in _myList)
            {                
                var obj = (myStruct.PointList as IPointListEdit);
                if (obj != null) obj.Clear();
                myStruct.IsEmpty = true;
            }
        }

        /// <summary>
        /// KeyPointList, 由一个Key 和一个 Point 集合 T 组成。
        /// </summary>
        public class KeyPointList
        {
            private Boolean _isEmpty = false;
            /// <summary>
            /// 关键字。
            /// </summary>
            public String Key { get; set; }
            /// <summary>
            /// Point 集合。
            /// </summary>
            public T PointList { get; set; }
            /// <summary>
            /// 获取或设置KeyPointList是否为没有赋值时的空状态。
            /// </summary>
            public Boolean IsEmpty
            {
                get { return _isEmpty; }
                set { _isEmpty = value; }
            }
        }
    }
}
