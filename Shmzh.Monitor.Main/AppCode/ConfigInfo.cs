using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Main
{
    public class ConfigInfo
    {
        List<ItemInfo> configList;

        /// <summary>
        /// 程序集文件。
        /// </summary>
        public String AssemblyFile { get; set; }

        /// <summary>
        /// 配置项列表。
        /// </summary>
        public List<ItemInfo> ConfigList
        {
            get 
            {
                if(configList == null)
                    configList = new List<ItemInfo>();
                return configList;
            }
            set
            {
                configList = value;
            }
        }

        public class ItemInfo
        {
            /// <summary>
            /// 是否可见。
            /// </summary>
            public Boolean Visible { get; set; }

            /// <summary>
            /// 名称。
            /// </summary>
            public String ClassName { get; set; }

            /// <summary>
            /// 配置文件或方案名称。
            /// </summary>
            public String ConfigFile { get; set; }

            /// <summary>
            /// 标题。
            /// </summary>
            public String Title { get; set; }

            /// <summary>
            /// 停留时间，以秒为单位。
            /// </summary>
            public Int32 ShowTime { get; set; }

            /// <summary>
            /// 刷新数据时间，以秒为单位。
            /// </summary>
            public Int32 UpdateTime { get; set; }
        }
    }
}
