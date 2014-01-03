using System;
using System.Diagnostics;

namespace Shmzh.Components.Util
{
    /// <summary>
    /// 用于输出某一执行过程的花费时间。
    /// </summary>
    public class StopwatchWriter : IDisposable
    {
        readonly Stopwatch _stopwatch = new Stopwatch();
        readonly string _text;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="text">描述文本。</param>
        public StopwatchWriter(string text)
        {
            _text = text + " - ";
            _stopwatch.Start();
        }
        /// <summary>
        /// 资源释放方法。
        /// </summary>
        public void Dispose()
        {
            _stopwatch.Stop();
            Trace.WriteLine("StopWatch: " + _text + _stopwatch.ElapsedMilliseconds);
        }
    }
}
