using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace Shmzh.Monitor.Gadget
{
    public static class ConfigImages
    {
        private static readonly Dictionary<String, Image> _allImage = new Dictionary<String, Image>();

        public static void Add(String key, Image value)
        {
            key = key.ToLower();
            if (!_allImage.ContainsKey(key))
            {
                _allImage.Add(key, value);
            }
        }

        /// <summary>
        /// 如果存在 key 图片，返回 key 图片； 不存在 key 图片，返回 error 图片。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Image GetByKey(String key)
        {
            if (String.IsNullOrEmpty(key)) return Properties.Resources.error;
            key = key.ToLower();
            return _allImage.ContainsKey(key) ? _allImage[key] : Properties.Resources.error;
        }
        
        public static Boolean ContainsKey(String key)
        {
            return _allImage.ContainsKey(key.ToLower());
        }

        public static void Clear()
        {
            _allImage.Clear();
        }

        #region 载入全部的配置图片。
        private static Int32 preLen;
        /// <summary>
        /// 载入全部的配置图片。
        /// </summary>
        public static void LoadAllImages()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images");
            preLen = path.Length + 1;
            var dirInfo = new DirectoryInfo(path);
            LoadImages( dirInfo, "png");
            LoadImages(dirInfo, "gif");
            LoadImages(dirInfo, "jpg");
            LoadImages(dirInfo, "jpeg");
            LoadImages(dirInfo, "emf");
        }

        private static void LoadImages(DirectoryInfo dirInfo, string extenderName)
        {
            var files = dirInfo.GetFiles(string.Format("*.{0}", extenderName), SearchOption.AllDirectories);
            foreach (var fileInfo in files)
            {
                var img = Image.FromFile(fileInfo.FullName);
                var key = fileInfo.FullName.Substring(preLen);
                Add(key.ToLower(), img);
            }
        }
        #endregion
    }
}
