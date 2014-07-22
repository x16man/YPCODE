using System;
using System.Collections.Generic;
using System.Text;

namespace Shmzh.Monitor.Main.Uninst
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String sysroot = System.Environment.SystemDirectory;
                System.Diagnostics.Process.Start(System.IO.Path.Combine(sysroot, "msiexec.exe"), "/x {A7E916D0-B56F-4AC5-AFDF-DB4B723ABCB6}");
            }
            catch { }
        }
    }
}
