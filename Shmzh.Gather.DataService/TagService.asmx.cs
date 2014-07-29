using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;

namespace Shmzh.Gather.DataService
{
    /// <summary>
    /// 提供给市北公司的数据接口。
    /// </summary>
    [WebService(Namespace = "http://www.ypwater.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)] 
    public class TagService : System.Web.Services.WebService
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取小时数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>小时数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取小时数据集合。")]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://www.ypwater.com/GetHourData_By_TagId_DateTime", RequestNamespace = "http://www.ypwater.com/", ResponseNamespace = "http://www.ypwater.com/")]
        public List<TagHourInfo> GetHourData_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagHourProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime);
        }
        /// <summary>
        /// 根据指定的指标Id、时间点来获取单个指标在指定小时点数据.
        /// </summary>
        /// <param name="tagId">指标Id</param>
        /// <param name="time">指定的小时时间点。</param>
        /// <returns>TagHourInfo</returns>
        [WebMethod(Description = "根据指定的指标Id、时间点来获取单个指标在指定小时点数据对象")]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://www.ypwater.com/Get1HourData_By_TagId_DateTime", RequestNamespace = "http://www.ypwater.com/", ResponseNamespace = "http://www.ypwater.com/")]
        public TagHourInfo Get1HourData_By_TagId_DateTime(string tagId, DateTime time)
        {
            var objs = DataProvider.TagHourProvider.Get_By_TagId_DateTime(tagId, time, time);
            return objs.Count > 0 ? objs[0] : null;
        }
        /// <summary>
        /// 根据指定的指标Id、时间点来获取单个指标在指定小时点数据对象的修正值。
        /// </summary>
        /// <param name="tagId">指标Id</param>
        /// <param name="time">指定的时间点字符串。</param>
        /// <returns>指标的数据修正值。</returns>
        [WebMethod(Description = "根据指定的指标Id、时间点来获取单个指标在指定小时点数据对象的修正值。")]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://www.ypwater.com/GetHourValue_By_TagId_DateTime", RequestNamespace = "http://www.ypwater.com/", ResponseNamespace = "http://www.ypwater.com/")] 
        public string GetHourValue_By_TagId_DateTime(string tagId, string time)
        {
            var obj = this.Get1HourData_By_TagId_DateTime(tagId, DateTime.Parse(time));
            return obj != null ? obj.I_Value_Man.ToString() : double.MinValue.ToString();
        }

        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取小时数据集合。
        /// </summary>
        /// <param name="tagIds">指标数据集合。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>小时数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id串、开始时间、结束时间来获取小时数据集合。")]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://www.ypwater.com/GetHourData_By_TagIds_DateTime", RequestNamespace = "http://www.ypwater.com/", ResponseNamespace = "http://www.ypwater.com/")]
        public List<TagHourInfo> GetHourData_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagHourProvider.Get_By_TagIds_DateTime(tagIds, beginTime, endTime);
        }


        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表的数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取天表的数据集合。")]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://www.ypwater.com/GetDayData_By_TagId_DateTime", RequestNamespace = "http://www.ypwater.com/", ResponseNamespace = "http://www.ypwater.com/")]
        public List<TagDayInfo> GetDayData_By_TagId_DateTime(string tagId, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagDayProvider.Get_By_TagId_DateTime(tagId, beginTime, endTime);
        }
        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据对象。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="time">指定时间点。</param>
        /// <returns>TagDayInfo。</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取天表的数据对象。")]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://www.ypwater.com/Get1DayData_By_TagId_DateTime", RequestNamespace = "http://www.ypwater.com/", ResponseNamespace = "http://www.ypwater.com/")]
        public TagDayInfo Get1DayData_By_TagId_DateTime(string tagId, DateTime time)
        {
            var objs = this.GetDayData_By_TagId_DateTime(tagId, time, time);
            return objs.Count > 0 ? objs[0] : null;
        }
        /// <summary>
        /// 根据指定的指标Id、开始时间、结束时间来获取天表的数据对象的修正值。
        /// </summary>
        /// <param name="tagId">指标Id。</param>
        /// <param name="time">指定时间点。</param>
        /// <returns>double</returns>
        [WebMethod(Description = "根据指定的指标Id、开始时间、结束时间来获取天表的数据对象的修正值。")]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://www.ypwater.com/GetDayValue_By_TagId_DataTime", RequestNamespace = "http://www.ypwater.com/", ResponseNamespace = "http://www.ypwater.com/")]
        public string GetDayValue_By_TagId_DataTime(string tagId, string time)
        {
            var obj = this.Get1DayData_By_TagId_DateTime(tagId, DateTime.Parse(time));
            return obj == null ? double.MinValue.ToString() : obj.I_Value_Man.ToString();
        }
        /// <summary>
        /// 根据指定的指标Id串、开始时间、结束时间来获取天表的数据集合。
        /// </summary>
        /// <param name="tagIds">指标Id串。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>天表数据集合。</returns>
        [WebMethod(Description = "根据指定的指标Id串、开始时间、结束时间来获取天表的数据集合。")]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://www.ypwater.com/GetDayData_By_TagIds_DateTime", RequestNamespace = "http://www.ypwater.com/", ResponseNamespace = "http://www.ypwater.com/")]
        public List<TagDayInfo> GetDayData_By_TagIds_DateTime(string tagIds, DateTime beginTime, DateTime endTime)
        {
            return DataProvider.TagDayProvider.Get_By_TagIds_DateTime(tagIds, beginTime, endTime);
        }
    }
}
