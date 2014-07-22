using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;


namespace Shmzh.Monitor.Forms
{
    public class UpdateDataRTag : UpdateBase
    {
        private List<GridViewRTagList> _gvRtList;
        private List<GraphSchemaRTagInfo> _rTagDataSource;
        
        public UpdateDataRTag(List<GridViewRTagList> gvRtList)
        {
            _gvRtList = gvRtList;
        }
        
        /// <summary>
        /// 将 RTag 集合以 threadObjCount 个为一组进行拆分，每一组建一个线程进行取值。
        /// </summary>
        public void DoWork()
        {
            if (_gvRtList == null || _gvRtList.Count == 0) return;
            if (!Shmzh.Components.Util.Internet.IsConnected()) return;

            //Thread thread;
            Int32 count = threadObjCount;
            foreach (GridViewRTagList gvRtList in _gvRtList)
            {
                _rTagDataSource = gvRtList.RTagList;
                if (_rTagDataSource.Count > 0)
                {
                    for (int i = 0; i < _rTagDataSource.Count; i += threadObjCount)
                    {
                        count = _rTagDataSource.Count > threadObjCount + i
                                          ? threadObjCount
                                          : _rTagDataSource.Count - i;
                        this.IncreaseRunThreads();;

                        //thread = new Thread(this.UpdateRTagList) { IsBackground = true };
                        //thread.Start(new GridViewRTagList() { GridView = gvRtList.GridView, RTagList = _rTagDataSource.GetRange(i, count) });

                        ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdateRTagList),
                            new GridViewRTagList() { GridView = gvRtList.GridView, RTagList = _rTagDataSource.GetRange(i, count) });
                    }
                }
            }
        }

        #region Update RTag

        /// <summary>
        /// 本类中，单个线程运行该方法时使用。
        /// </summary>
        /// <param name="oRTagList"></param>
        private void UpdateRTagList(object oRTagList)
        {
            if (oRTagList is GridViewRTagList)
                this.UpdateRTags(oRTagList as GridViewRTagList);
        }

        private void UpdateRTags(GridViewRTagList gvRtList)
        {
            var list = gvRtList.RTagList;
            for (int i = 0; i < list.Count; i++)
            {
                GraphSchemaRTagInfo rTagInfo = list[i];
                if (this.IsStopped)
                {
                    this.DecreaseRunThreads();
                    return;
                }
                if (!String.IsNullOrEmpty(rTagInfo.TagId))
                {
                    var oldValue = rTagInfo.TagValue;
                    try
                    {
                        rTagInfo.TagValue = DataProvider.GetCurrentValue(rTagInfo.TagId, rTagInfo.DataType);
                    }
                    catch
                    {
                        rTagInfo.TagValue = 0.0d;
                    }

                    if (!oldValue.Equals(rTagInfo.TagValue))
                    {
                        if (gvRtList.GridView.Created)
                            gvRtList.GridView.InvalidateCell(1, i);
                        //gvRtList.GridView.InvalidateRow(i);
                    }
                }
            }
            this.DecreaseRunThreads();
            //System.Diagnostics.Debug.WriteLine(DateTime.Now + " 正在执行...");
        }
        #endregion
        
        public class  GridViewRTagList
        {
            public DataGridView GridView { get; set; }
            public List<GraphSchemaRTagInfo> RTagList { get; set; }
        }
    }
}
