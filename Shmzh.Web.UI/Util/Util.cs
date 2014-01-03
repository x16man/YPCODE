using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Shmzh.Web.UI
{
    /// <summary>
    /// Implements various utility functions.
    /// 
    /// Copyright (c) 2008 Shmzh Corporation.
    /// </summary>
    internal static class Util 
    {
        // The "_mkdir" function is used by the "CreateDirectory" method.
        [DllImport("msvcrt.dll", SetLastError = true)]
        private static extern int _mkdir(string path);

        /// <summary>
        /// 确保字符串是否以分号结尾。
        /// </summary>
        /// <param name="value">字符串。</param>
        /// <returns>以分号结尾的字符串。</returns>
        internal static string EnsureEndWithSemiColon(string value)
        {
            if (value != null)
            {
                int length = value.Length;
                if (length > 0 && value[length - 1] != ';')
                {
                    return (value + ";");
                }
            }
            return value;
        }
        /// <summary>
        /// 合并两段脚本。
        /// </summary>
        /// <param name="firstScript">第一段脚本。</param>
        /// <param name="secondScript">第二本脚本。</param>
        /// <returns>合并后的脚本。</returns>
        internal static string MergeScript(string firstScript, string secondScript)
        {
            if (!String.IsNullOrEmpty(firstScript))
            {
                //
                return firstScript + secondScript;
            }
            else
            {
                if (secondScript.TrimStart().StartsWith("javascript:", StringComparison.Ordinal))
                {
                    return secondScript;
                }
                return "javascript:" + secondScript;
            }
        }

        /// <summary>
        /// This method should provide safe substitude for Directory.CreateDirectory().
        /// </summary>
        /// <param name="path">The directory path to be created.</param>
        /// <returns>A <see cref="System.IO.DirectoryInfo"/> object for the created directory.</returns>
        /// <remarks>
        ///		<para>
        ///		This method creates all the directory structure if needed.
        ///		</para>
        ///		<para>
        ///		The System.IO.Directory.CreateDirectory() method has a bug that gives an
        ///		error when trying to create a directory and the user has no rights defined
        ///		in one of its parent directories. The CreateDirectory() should be a good 
        ///		replacement to solve this problem.
        ///		</para>
        /// </remarks>
        public static DirectoryInfo CreateDirectory(string path)
        {
            // Create the directory info object for that dir (normalized to its absolute representation).
            var oDir = new DirectoryInfo(Path.GetFullPath(path));

            try
            {
                // Try to create the directory by using standard .Net features. (#415)
                if (!oDir.Exists)
                    oDir.Create();

                return oDir;
            }
            catch
            {
                CreateDirectoryUsingDll(oDir);

                return new DirectoryInfo(path);
            }
        }

        private static void CreateDirectoryUsingDll(DirectoryInfo dir)
        {
            // On some occasion, the DirectoryInfo.Create() function will 
            // throw an error due to a bug in the .Net Framework design. For
            // example, it may happen that the user has no permissions to
            // list entries in a lower level in the directory path, and the
            // Create() call will simply fail.
            // To workaround it, we use mkdir directly.

            var oDirsToCreate = new ArrayList();

            // Check the entire path structure to find directories that must be created.
            while (dir != null && !dir.Exists)
            {
                oDirsToCreate.Add(dir.FullName);
                dir = dir.Parent;
            }

            // "dir == null" means that the check arrives in the root and it doesn't exist too.
            if (dir == null)
                throw (new System.IO.DirectoryNotFoundException("Directory \"" + oDirsToCreate[oDirsToCreate.Count - 1] + "\" not found."));

            // Create all directories that must be created (from bottom to top).
            for (var i = oDirsToCreate.Count - 1; i >= 0; i--)
            {
                var sPath = (string)oDirsToCreate[i];
                var iReturn = _mkdir(sPath);

                if (iReturn != 0)
                    throw new ApplicationException("Error calling [msvcrt.dll]:_wmkdir(" + sPath + "), error code: " + iReturn);
            }
        }

        public static bool ArrayContains(Array array, object value, System.Collections.IComparer comparer)
        {
            foreach (var item in array)
            {
                if (comparer.Compare(item, value) == 0)
                    return true;
            }
            return false;
        }

        public static string ReadTextFile(string filePath)
        {
            var _Reader = new StreamReader(filePath);
            var data = _Reader.ReadToEnd();
            _Reader.Close();

            return data;
        }
        ///<summary>
        /// Hash an input string and return the hash as
        /// a 32 character hexadecimal string.
        /// </summary>
        public static string GetMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            var md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
