using System;
using System.Configuration;
using System.Runtime.InteropServices;

/**
 * LayoutKind.Automatic：为了提高效率允许运行态对类型成员重新排序
 * 注意：永远不要使用这个选项来调用不受管辖的动态链接库函数。
 * LayoutKind.Explicit：对每个域按照FieldOffset属性对类型成员排序
 * LayoutKind.Sequential：对出现在受管辖类型定义地方的不受管辖内存中的类型成员进行排序。
 */
namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 定义CPU的信息结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CpuInfo
    {
        /// <summary>
        /// OEM ID
        /// </summary>
        public uint dwOemId;
        /// <summary>
        /// 页面大小
        /// </summary>
        public uint dwPageSize;
        public uint lpMinimumApplicationAddress;
        public uint lpMaximumApplicationAddress;
        public uint dwActiveProcessorMask;
        /// <summary>
        /// CPU个数
        /// </summary>
        public uint dwNumberOfProcessors;
        /// <summary>
        /// CPU类型
        /// </summary>
        public uint dwProcessorType;
        public uint dwAllocationGranularity;
        /// <summary>
        /// CPU等级
        /// </summary>
        public uint dwProcessorLevel;
        public uint dwProcessorRevision;
    }
}