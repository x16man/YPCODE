using System.Collections.Generic;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
namespace Shmzh.Monitor.Data.Service
{
    public class RunStatus :IRunStatus
    {
        #region IRunStatus 成员

        public RunStatusInfo Get_Current_By_TagId(string tagId)
        {
            var obj =  new RunStatusService.RunStatus().Get_Current_By_TagId(tagId);
            var obj1 = new RunStatusInfo();
            CopyHelper.Copy(obj, obj1);
            return obj1;
        }

        #endregion

        #region IRunStatus 成员


        public RunStatusInfo Get_Current_By_DevCode(string devCode)
        {
            var obj = new RunStatusService.RunStatus().Get_Current_By_DevCode(devCode);
            RunStatusInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new RunStatusInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }
        
        public List<RunStatusInfo> Get_Current_By_DevCodes(string devCodes)
        {
            var objs = new RunStatusService.RunStatus().Get_Current_By_DevCodes(devCodes);
            var obj1s = new List<RunStatusInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new RunStatusInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 获取所有设备的当前运行状态。
        /// </summary>
        /// <returns>设备的当前运行状态集合。</returns>
        public List<RunStatusInfo> Get_Current_All()
        {
            var objs = new RunStatusService.RunStatus().Get_Current_All();
            var obj1s = new List<RunStatusInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new RunStatusInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        #endregion
    }
}
