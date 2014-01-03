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
    /// 定义内存的信息结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public uint dwLength;
        /// <summary>
        /// 已经使用的内存
        /// </summary>
        public uint dwMemoryLoad;
        /// <summary>
        /// 总物理内存大小
        /// </summary>
        public uint dwTotalPhys;
        /// <summary>
        /// 可用物理内存大小
        /// </summary>
        public uint dwAvailPhys;
        /// <summary>
        /// 交换文件总大小
        /// </summary>
        public uint dwTotalPageFile;
        /// <summary>
        /// 可用交换文件大小
        /// </summary>
        public uint dwAvailPageFile;
        /// <summary>
        /// 总虚拟内存大小
        /// </summary>
        public uint dwTotalVirtual;
        /// <summary>
        /// 可用虚拟内存大小
        /// </summary>
        public uint dwAvailVirtual;
    }
}