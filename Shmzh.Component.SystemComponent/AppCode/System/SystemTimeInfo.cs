using System;
using System.Configuration;
using System.Runtime.InteropServices;
namespace Shmzh.Components.SystemComponent
{
    /**
     * LayoutKind.Automatic：为了提高效率允许运行态对类型成员重新排序
     * 注意：永远不要使用这个选项来调用不受管辖的动态链接库函数。
     * LayoutKind.Explicit：对每个域按照FieldOffset属性对类型成员排序
     * LayoutKind.Sequential：对出现在受管辖类型定义地方的不受管辖内存中的类型成员进行排序。
     */
    /// <summary>
    /// 定义系统时间的信息结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTimeInfo
    {
        /// <summary>
        /// 年
        /// </summary>
        public ushort wYear;
        /// <summary>
        /// 月
        /// </summary>
        public ushort wMonth;
        /// <summary>
        /// 星期
        /// </summary>
        public ushort wDayOfWeek;
        /// <summary>
        /// 天
        /// </summary>
        public ushort wDay;
        /// <summary>
        /// 小时
        /// </summary>
        public ushort wHour;
        /// <summary>
        /// 分钟
        /// </summary>
        public ushort wMinute;
        /// <summary>
        /// 秒
        /// </summary>
        public ushort wSecond;
        /// <summary>
        /// 毫秒
        /// </summary>
        public ushort wMilliseconds;
    }
}