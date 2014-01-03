using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.InteropServices;
using Shmzh.Components.SystemComponent;
namespace SystemManagement
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SystemInfo systemInfo = new SystemInfo();
                Response.Write("操作系统：" + systemInfo.GetOperationSystemInName() + "<br>");
                Response.Write("CPU编号：" + systemInfo.GetCpuId() + "<br>");
                Response.Write("硬盘编号：" + systemInfo.GetMainHardDiskId() + "<br>");
                Response.Write("Windows目录所在位置：" + systemInfo.GetSysDirectory() + "<br>");
                Response.Write("系统目录所在位置：" + systemInfo.GetWinDirectory() + "<br>");
                MemoryInfo memoryInfo = systemInfo.GetMemoryInfo();
                CpuInfo cpuInfo = systemInfo.GetCpuInfo();
                Response.Write("dwActiveProcessorMask" + cpuInfo.dwActiveProcessorMask + "<br>");
                Response.Write("dwAllocationGranularity" + cpuInfo.dwAllocationGranularity + "<br>");
                Response.Write("CPU个数：" + cpuInfo.dwNumberOfProcessors + "<br>");
                Response.Write("OEM ID：" + cpuInfo.dwOemId + "<br>");
                Response.Write("页面大小" + cpuInfo.dwPageSize + "<br>");
                Response.Write("CPU等级" + cpuInfo.dwProcessorLevel + "<br>");
                Response.Write("dwProcessorRevision" + cpuInfo.dwProcessorRevision + "<br>");
                Response.Write("CPU类型" + cpuInfo.dwProcessorType + "<br>");
                Response.Write("lpMaximumApplicationAddress" + cpuInfo.lpMaximumApplicationAddress + "<br>");
                Response.Write("lpMinimumApplicationAddress" + cpuInfo.lpMinimumApplicationAddress + "<br>");
                Response.Write("CPU类型：" + cpuInfo.dwProcessorType + "<br>");
                Response.Write("可用交换文件大小：" + memoryInfo.dwAvailPageFile + "<br>");
                Response.Write("可用物理内存大小：" + memoryInfo.dwAvailPhys + "<br>");
                Response.Write("可用虚拟内存大小" + memoryInfo.dwAvailVirtual + "<br>");
                Response.Write("操作系统位数：" + memoryInfo.dwLength + "<br>");
                Response.Write("已经使用内存大小：" + memoryInfo.dwMemoryLoad + "<br>");
                Response.Write("交换文件总大小：" + memoryInfo.dwTotalPageFile + "<br>");
                Response.Write("总物理内存大小：" + memoryInfo.dwTotalPhys + "<br>");
                Response.Write("总虚拟内存大小：" + memoryInfo.dwTotalVirtual + "<br>");
            }
        }
    }
}