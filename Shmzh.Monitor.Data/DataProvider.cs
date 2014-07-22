using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text.RegularExpressions;
using Shmzh.Monitor.Data.IDAL;
using Shmzh.Monitor.Entity;
using Ciloci.Flee;

namespace Shmzh.Monitor.Data
{
    public class DataProvider
    {
        #region Field

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string MONITOR_DAL_NAMESPACE = ConfigurationManager.AppSettings["Shmzh.Monitor.DAL.NameSpace"];
        private static readonly string MONITOR_SCHEMA_DAL_NAMESPACE = ConfigurationManager.AppSettings["Shmzh.Monitor.Schema.DAL.NameSpace"];

        //private static readonly Assembly assembly = Assembly.LoadFrom(MONITOR_DAL_ASSEMBLY);
        //private static readonly Assembly schemaAssembly = Assembly.LoadFrom(MONITOR_SCHEMA_DAL_ASSEMBLY);

        //private static readonly  Assembly assembly = 
        private static Regex myRegex = new Regex(@"\[[0-9|A-Z|a-z|-]*\]");
        private static Regex devRegex = new Regex(@"\{[0-9|A-Z|a-z|-]*\}");
        #endregion

        #region Property
        public static ITagSecond TagSecondProvider
        {
            get { return CreateTagSecondProvider(); }
        }
        /// <summary>
        /// 分钟表的数据访问对象.
        /// </summary>
        public static ITagMinute TagMinuteProvider
        {
            get { return CreateTagMinuteProvider(); }
        }
        /// <summary>
        /// 15分钟表的数据访问对象.
        /// </summary>
        public static ITagMin15 TagMin15Provider
        {
            get { return CreateTagMin15Provider(); }
        }
        /// <summary>
        /// 小时表的数据访问对象.
        /// </summary>
        public static ITagHour TagHourProvider
        {
            get { return CreateTagHourProvider(); }
        }
        /// <summary>
        /// 天表的数据访问对象.
        /// </summary>
        public static ITagDay TagDayProvider
        {
            get { return CreateTagDayProvider(); }
        }
        /// <summary>
        /// 月表的数据访问对象.
        /// </summary>
        public static ITagMonth TagMonthProvider
        {
            get { return CreateTagMonthProvider(); }
        }
        /// <summary>
        /// 年表的数据访问对象.
        /// </summary>
        public static ITagYear TagYearProvider
        {
            get { return CreateTagYearProvider(); }
        }
        /// <summary>
        /// 指标的数据访问对象。
        /// </summary>
        public static ITag TagProvider
        {
            get { return CreateTagProvider(); }
        }
        public static ITagGather TagGatherProvider
        { 
            get { return CreateTagGatherProvider(); }
        }
        /// <summary>
        /// 设备运行状态的数据访问对象。
        /// </summary>
        public static IRunStatus RunStatusProvider
        {
            get { return CreateRunStatusProvider(); }
        }
        /// <summary>
        /// 图表方案的数据访问对象。
        /// </summary>
        public static IGraphSchema GraphSchemaProvider
        {
            get { return CreateGraphSchemaProvider(); }
        }
        /// <summary>
        /// 图表方案项的数据访问对象。
        /// </summary>
        public static IGraphSchemaItem GraphSchemaItemProvider
        {
            get { return CreateGraphSchemaItemProvider(); }
        }
        /// <summary>
        /// 图表方案项指标的数据访问对象。
        /// </summary>
        public static IGraphSchemaTag GraphSchemaTagProvider
        {
            get { return CreateGraphSchemaTagProvider(); }
        }
        /// <summary>
        /// 曲线方案关联项的数据访问对象。
        /// </summary>
        public static IGraphSchemaRTag GraphSchemaRTagProvider
        {
            get { return CreateGraphSchemaRTagProvider(); }
        }
        /// <summary>
        /// 曲线方案关联项指标的数据访问对象。
        /// </summary>
        public static IGraphSchemaTab GraphSchemaTabProvider
        {
            get { return CreateGraphSchemaTabProvider(); }
        }

        public static IObjType ObjTypeProvider
        {
            get{return CreateObjTypeProvider();}
        }
        public static IMonitorObj MonitorObjProvider
        {
            get { return CreateMonitorObjProvider(); }
        }
        public static IObjTypeAttr ObjTypeAttrProvider
        {
            get { return CreateObjTypeAttrProvider(); }
        }
        public static IFloatingBlock FloatingBlockProvider
        {
            get { return CreateFloatingBlockProvider(); }
        }
        public static IFloatingBlockItem FloatingBlockItemProvider
        {
            get { return CreateFloatingBlockItemProvider(); }
        }
        public static ICategory CategoryProvider
        {
            get { return CreateCategoryProvider(); }
        }
        public static ICategoryItem CategoryItemProvider
        {
            get { return CreateCategoryItemProvider(); }
        }
        public static ITagCategory TagCategoryProvider
        {
            get { return CreateTagCategoryProvider(); }
        }
        public static ITagCategoryDetail TagCategoryDetailProvider
        {
            get { return CreateTagCategoryDetailProvider(); }
        }
        #endregion

        #region private method
        private static ITagSecond CreateTagSecondProvider()
        {
            var className = string.Format("{0}.TagSecond", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (ITagSecond)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建分钟表的数据访问对象。
        /// </summary>
        /// <returns>分钟表的数据访问对象。</returns>
        private static ITagMinute CreateTagMinuteProvider()
        {
            var className = string.Format("{0}.TagMinute", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);
            var obj = (ITagMinute)Activator.CreateInstance(classType);
            //Logger.Info(obj);
            return obj;
        }
        /// <summary>
        /// 创建15分钟表的数据访问对象。
        /// </summary>
        /// <returns>15分钟表的数据访问对象。</returns>
        private static ITagMin15 CreateTagMin15Provider()
        {
            var className = string.Format("{0}.TagMin15", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);
            
            return (ITagMin15)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建小时表的数据访问对象。
        /// </summary>
        /// <returns>小时表的数据访问对象。</returns>
        private static ITagHour CreateTagHourProvider()
        {
            var className = string.Format("{0}.TagHour", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);
            
            return (ITagHour)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建天表的数据访问对象。
        /// </summary>
        /// <returns>天表的数据访问对象。</returns>
        private static ITagDay CreateTagDayProvider()
        {
            var className = string.Format("{0}.TagDay", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);
            var obj = Activator.CreateInstance(classType);
            return (ITagDay)obj;
        }
        /// <summary>
        /// 创建月表的数据访问对象。
        /// </summary>
        /// <returns>月表的数据访问对象。</returns>
        private static ITagMonth CreateTagMonthProvider()
        {
            var className = string.Format("{0}.TagMonth", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);
            return (ITagMonth)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建年表的数据访问对象。
        /// </summary>
        /// <returns>年表的数据访问对象。</returns>
        private static ITagYear CreateTagYearProvider()
        {
            var className = string.Format("{0}.TagYear", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);
            
            return (ITagYear)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建指标的数据访问对象。
        /// </summary>
        /// <returns>指标的数据访问对象。</returns>
        private static ITag CreateTagProvider()
        {
            var className = string.Format("{0}.Tag", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);
            return (ITag)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建Gather指标的数据访问对象。
        /// </summary>
        /// <returns>指标的数据访问对象。</returns>
        private static ITagGather CreateTagGatherProvider()
        {
            var className = string.Format("{0}.TagGather", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);
            return (ITagGather)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建设备运行状态的数据访问对象。
        /// </summary>
        /// <returns>设备运行状态的数据访问对象。</returns>
        private static IRunStatus CreateRunStatusProvider()
        {
            var className = string.Format("{0}.RunStatus", MONITOR_DAL_NAMESPACE);
            var classType = Type.GetType(className);
            
            return (IRunStatus) Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建图表方案的数据访问对象。
        /// </summary>
        /// <returns>图表方案的数据访问对象。</returns>
        private static IGraphSchema CreateGraphSchemaProvider()
        {
            var className = string.Format("{0}.GraphSchema", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IGraphSchema)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建图表方案项的数据访问对象。
        /// </summary>
        /// <returns>图表方案项的数据访问对象。</returns>
        private static IGraphSchemaItem CreateGraphSchemaItemProvider()
        {
            var className = string.Format("{0}.GraphSchemaItem", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IGraphSchemaItem)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建图表方案项指标的数据访问对象。
        /// </summary>
        /// <returns>图表方案项指标的数据访问对象。</returns>
        private static IGraphSchemaTag CreateGraphSchemaTagProvider()
        {
            var className = string.Format("{0}.GraphSchemaTag", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IGraphSchemaTag)Activator.CreateInstance(classType);
        }
        private static IGraphSchemaTab CreateGraphSchemaTabProvider()
        {
            var className = string.Format("{0}.GraphSchemaTab", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IGraphSchemaTab)Activator.CreateInstance(classType);
        }
        private static IGraphSchemaRTag CreateGraphSchemaRTagProvider()
        {
            var className = string.Format("{0}.GraphSchemaRTag", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IGraphSchemaRTag)Activator.CreateInstance(classType);
        }
        private static IObjType CreateObjTypeProvider()
        {
            var className = string.Format("{0}.ObjType", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IObjType)Activator.CreateInstance(classType);   
        }
        private static IMonitorObj CreateMonitorObjProvider()
        {
            var className = string.Format("{0}.MonitorObj", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IMonitorObj)Activator.CreateInstance(classType);
        }
        private static IObjTypeAttr CreateObjTypeAttrProvider()
        {
            var className = string.Format("{0}.ObjTypeAttr", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IObjTypeAttr)Activator.CreateInstance(classType);
        }
        private static IFloatingBlock CreateFloatingBlockProvider()
        {
            var className = string.Format("{0}.FloatingBlock", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IFloatingBlock)Activator.CreateInstance(classType);
        }
        private static IFloatingBlockItem CreateFloatingBlockItemProvider()
        {
            var className = string.Format("{0}.FloatingBlockItem", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (IFloatingBlockItem)Activator.CreateInstance(classType);
        }
        private static ICategory CreateCategoryProvider()
        {
            var className = String.Format("{0}.Category", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (ICategory)Activator.CreateInstance(classType);
        }
        private static ICategoryItem CreateCategoryItemProvider()
        {
            var className = String.Format("{0}.CategoryItem", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (ICategoryItem)Activator.CreateInstance(classType);
        }
        private static ITagCategory CreateTagCategoryProvider()
        {
            var className = String.Format("{0}.TagCategory", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (ITagCategory)Activator.CreateInstance(classType);
        }
        private static ITagCategoryDetail CreateTagCategoryDetailProvider()
        {
            var className = String.Format("{0}.TagCategoryDetail", MONITOR_SCHEMA_DAL_NAMESPACE);
            var classType = Type.GetType(className);

            return (ITagCategoryDetail)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 将指标表达式中出现的指标转换成一个唯一的指标数组。
        /// </summary>
        /// <param name="tagExression">指标表达式。</param>
        /// <returns>指标数组（唯一性）。</returns>
        private static string DistinctTag(string tagExression)
        {
            var mc = myRegex.Matches(tagExression);
            var tags = new List<string>();
            var retString = string.Empty;
            for (var i = 0; i < mc.Count; i++)
            {
                var temp = mc[i].ToString().Replace("[", string.Empty).Replace("]", string.Empty);
                if (!tags.Contains(temp))
                {
                    tags.Add(temp);
                    retString += string.Format(",{0}", temp);
                }
            }
            return retString.Substring(1);
        }

        /// <summary>
        /// 将设备表达式中出现的设备转换成一个唯一的设备数组。
        /// </summary>
        /// <param name="devExression">设备表达式。</param>
        /// <returns>设备数组（唯一性）。</returns>
        private static string DistinctDevCode(string devExression)
        {
            var mc = devRegex.Matches(devExression);
            var tags = new List<string>();
            var retString = string.Empty;
            for (var i = 0; i < mc.Count; i++)
            {
                var temp = mc[i].ToString().Replace("{", string.Empty).Replace("}", string.Empty);
                if (!tags.Contains(temp))
                {
                    tags.Add(temp);
                    retString += string.Format(",{0}",temp);
                }
            }
            return retString.Substring(1);
        }
        
        #endregion

        #region Public Method
        /// <summary>
        /// 根据指标Id和指定的数据类型（分钟、15分钟、小时、天、月、年）来获取指标最新的数据。
        /// </summary>
        /// <param name="tagExpression">指标Id。</param>
        /// <param name="dataType">数据类型（分钟、15分钟、小时、天、月、年）</param>
        /// <returns>当前值。</returns>
        public static double GetCurrentValue(string tagExpression, DataType dataType)
        {
            var isExpression = false;
            var isDev = false;
            if (tagExpression.Contains("{") && tagExpression.Contains("}"))
            {
                if (!tagExpression.StartsWith("{") || !tagExpression.EndsWith("}") ||
                    tagExpression.Substring(1).Contains("{"))
                {
                    isExpression = true;
                }
                isDev = true;
            }
            else if (tagExpression.Contains("[") && tagExpression.Contains("]"))
            {
                if (!tagExpression.StartsWith("[") || !tagExpression.EndsWith("]") ||
                    tagExpression.Substring(1).Contains("["))
                {
                    isExpression = true;
                }
                isDev = false;
            }
            else //常量值或常量表达式。
            {
                IGenericExpression<double> MyExpression;
                var MyContext = new ExpressionContext();
                MyContext.Imports.AddType(typeof(System.Math));
                MyExpression = MyContext.CompileGeneric<double>(tagExpression.Trim());
                var retValue = MyExpression.Evaluate();
                return retValue;
            }

            #region 单个指标
            if (!isExpression)//单个指标。
            {
                var retValue = double.MinValue;
                if (!isDev)
                {
                    tagExpression = tagExpression.Replace("[", string.Empty).Replace("]", string.Empty);

                    var beginDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    var endDate = DateTime.Today.AddDays(1);
                    switch (tagExpression)
                    {
                        case "WQ_3TAG":
                            return TagProvider.Get3TagEligibleRate(beginDate, endDate)*100.00;
                        case "WQ_4TAG":
                            return TagProvider.Get4TagEligibleRate(beginDate, endDate)*100.00;
                        case "WQ_7TAG":
                            return TagProvider.Get7TagEligibleRate(beginDate, endDate)*100.00;
                    }

                    switch (dataType)
                    {
                        case DataType.Second:
                            var secondObj = TagSecondProvider.Get_Latest_By_TagId(tagExpression);
                            if (secondObj != null) 
                                retValue = secondObj.I_Value_1;
                            //else
                                //Logger.Error(string.Format("{0} secondObj is null.",tagExpression));
                            break;
                        case DataType.Minute:
                            var minuteObj = TagMinuteProvider.Get_Latest_By_TagId(tagExpression);
                            if (minuteObj != null) 
                                retValue = minuteObj.I_Value_Man;
                            //else
                                //Logger.Error(string.Format("{0} minuteObj is null.", tagExpression));
                            break;
                        case DataType.Min15:
                            var min15Obj = TagMin15Provider.Get_Latest_By_TagId(tagExpression);
                            if (min15Obj != null) 
                                retValue = min15Obj.I_Value_Man;
                            //else
                                //Logger.Error(string.Format("{0} min15Obj is null.", tagExpression));
                            break;
                        case DataType.Hour:
                            var hourObj = TagHourProvider.Get_Latest_By_TagId(tagExpression);
                            if (hourObj != null)
                                retValue = hourObj.I_Value_Man;
                            else
                                //Logger.Error(string.Format("{0} hourObj is null.", tagExpression));
                                retValue = 0;
                            break;
                        case DataType.Day:
                            var dayObj = TagDayProvider.Get_Latest_By_TagId(tagExpression);
                            if (dayObj != null) 
                                retValue = dayObj.I_Value_Man;
                            //else
                                //Logger.Error(string.Format("{0} dayObj is null.", tagExpression));
                            break;
                        case DataType.Month:
                            var monthObj = TagMonthProvider.Get_Latest_By_TagId(tagExpression);
                            if (monthObj != null) 
                                retValue = monthObj.I_Value_Man;
                            //else
                                //Logger.Error(string.Format("{0} monthObj is null.", tagExpression));
                            break;
                        case DataType.Year:
                            var yearObj = TagYearProvider.Get_Latest_By_TagId(tagExpression);
                            if (yearObj != null) 
                                retValue = yearObj.I_Value_Man;
                            //else
                                //Logger.Error(string.Format("{0} yearObj is null.", tagExpression));
                            break;
                    }
                }
                else
                {
                    tagExpression = tagExpression.Replace("{", string.Empty).Replace("}", string.Empty);
                    var obj = DataProvider.RunStatusProvider.Get_Current_By_DevCode(tagExpression);
                    retValue = obj == null ? 0D : obj.Status;
                }
                return retValue;
            }
            #endregion
            #region 表达式
            else//表达式。
            {
                if (!isDev)
                {
                    var s = DistinctTag(tagExpression);
                    var ss = s.Split(',');
                    var v = new double[ss.Length];
                    IGenericExpression<double> MyExpression;
                    var MyContext = new ExpressionContext();
                    MyContext.Imports.AddType(typeof (System.Math));

                    for (int i = 0; i < ss.Length; i++)
                    {
                        tagExpression = tagExpression.Replace(string.Format("[{0}]", ss[i]), string.Format("x{0}", i));
                        MyContext.Variables.DefineVariable(string.Format("x{0}", i), typeof (double));
                    }
                    MyExpression = MyContext.CompileGeneric<double>(tagExpression);

                    switch (dataType)
                    {
                        case DataType.Second:
                            var secondObjs = TagSecondProvider.Get_Latest_By_TagIds(s);
                            if (secondObjs.Count > 0)//如果秒数据对象个数大于0。
                            {
                                for (var i = 0; i < ss.Length; i++)
                                {
                                    var obj = secondObjs.Find(o=>o.I_Tag_Id.Equals(ss[i]));
                                    if (obj == null)
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = 0.0D;
                                    }
                                    else
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = obj.I_Value_1;
                                    }
                                }                                
                                var retValue = MyExpression.Evaluate();
                                return retValue;
                            }
                            return 0;
                        case DataType.Minute:
                            var minuteObjs = TagMinuteProvider.Get_Latest_By_TagIds(s);
                            if (minuteObjs.Count > 0)//如果数据对象个数大于0。
                            {
                                for (var i = 0; i < ss.Length; i++)
                                {
                                    var obj = minuteObjs.Find(o => o.I_Tag_Id.Equals(ss[i]));
                                    if (obj == null)
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = 0.0D;
                                    }
                                    else
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = obj.I_Value_Man;
                                    }
                                }
                                var retValue = MyExpression.Evaluate();
                                return retValue;
                            }
                            return 0;
                        case DataType.Min15:
                            var min15Objs = TagMin15Provider.Get_Latest_By_TagIds(s);
                            if (min15Objs.Count > 0)//如果数据对象个数大于0。
                            {
                                for (var i = 0; i < ss.Length; i++)
                                {
                                    var obj = min15Objs.Find(o => o.I_Tag_Id.Equals(ss[i]));
                                    if (obj == null)
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = 0.0D;
                                    }
                                    else
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = obj.I_Value_Man;
                                    }
                                }
                                var retValue = MyExpression.Evaluate();
                                return retValue;
                            }
                            return 0;
                        case DataType.Hour:
                            var hourObjs = TagHourProvider.Get_Latest_By_TagIds(s);
                            if (hourObjs.Count > 0)//如果数据对象个数大于0。
                            {
                                for (var i = 0; i < ss.Length; i++)
                                {
                                    var obj = hourObjs.Find(o => o.I_Tag_Id.Equals(ss[i]));
                                    if (obj == null)
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = 0.0D;
                                    }
                                    else
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = obj.I_Value_Man;
                                    }
                                }
                                var retValue = MyExpression.Evaluate();
                                return retValue;
                            }
                            return 0;
                        case DataType.Day:
                            var dayObjs = TagDayProvider.Get_Latest_By_TagIds(s);
                            if (dayObjs.Count > 0)//如果数据对象个数大于0。
                            {
                                for (var i = 0; i < ss.Length; i++)
                                {
                                    var obj = dayObjs.Find(o => o.I_Tag_Id.Equals(ss[i]));
                                    if (obj == null)
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = 0.0D;
                                    }
                                    else
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = obj.I_Value_Man;
                                    }
                                }
                                var retValue = MyExpression.Evaluate();
                                return retValue;
                            }
                            return 0;
                        case DataType.Month:
                            var monthObjs = TagMonthProvider.Get_Latest_By_TagIds(s);
                            if (monthObjs.Count > 0)//如果数据对象个数大于0。
                            {
                                for (var i = 0; i < ss.Length; i++)
                                {
                                    var obj = monthObjs.Find(o => o.I_Tag_Id.Equals(ss[i]));
                                    if (obj == null)
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = 0.0D;
                                    }
                                    else
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = obj.I_Value_Man;
                                    }
                                }
                                var retValue = MyExpression.Evaluate();
                                return retValue;
                            }
                            return 0;
                        case DataType.Year:
                            var yearObjs = TagYearProvider.Get_Latest_By_TagIds(s);
                            if (yearObjs.Count > 0)//如果数据对象个数大于0。
                            {
                                for (var i = 0; i < ss.Length; i++)
                                {
                                    var obj = yearObjs.Find(o => o.I_Tag_Id.Equals(ss[i]));
                                    if (obj == null)
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = 0.0D;
                                    }
                                    else
                                    {
                                        MyContext.Variables[string.Format("x{0}", i)] = obj.I_Value_Man;
                                    }
                                }
                                var retValue = MyExpression.Evaluate();
                                return retValue;
                            }
                            return 0;
                    }
                }
                else
                {
                    var s = DistinctDevCode(tagExpression);
                    var ss = s.Split(',');
                    var v = new double[ss.Length];
                    IGenericExpression<double> MyExpression;
                    var MyContext = new ExpressionContext();
                    MyContext.Imports.AddType(typeof(System.Math));

                    for (int i = 0; i < ss.Length; i++)
                    {
                        tagExpression = tagExpression.Replace(String.Concat("{", ss[i], "}"), string.Format("x{0}", i));
                        MyContext.Variables.DefineVariable(string.Format("x{0}", i), typeof(double));
                    }
                    MyExpression = MyContext.CompileGeneric<double>(tagExpression);
                    //-------取值-------
                    var runStatusList = RunStatusProvider.Get_Current_By_DevCodes(s);
                    if (runStatusList.Count > 0)//如果数据对象个数大于0。
                    {
                        for (var i = 0; i < ss.Length; i++)
                        {
                            var obj = runStatusList.Find(o => o.Dev_Code.Equals(ss[i]));
                            if (obj == null)
                            {
                                MyContext.Variables[string.Format("x{0}", i)] = 0.0D;
                            }
                            else
                            {
                                MyContext.Variables[string.Format("x{0}", i)] = (double)obj.Status;
                            }
                        }
                        var retValue = MyExpression.Evaluate();
                        return retValue;
                    }
                }
                return 0;
            }
            #endregion
        }

        /// <summary>
        /// 根据指标Id和指定的数据类型（分钟、15分钟、小时、天、月、年）来获取指标最新的数据。
        /// </summary>
        /// <param name="tagExpression">指标Id。</param>
        /// <param name="strDataType">数据类型（分钟、15分钟、小时、天、月、年）</param>
        /// <returns>当前值。</returns>
        public static double GetCurrentValue(String tagExpression, String strDataType)
        {
            var retValue = Double.MinValue;
            var dataType = DataType.Minute;
            switch (strDataType)
            {
                case "Second":
                    dataType = DataType.Second;
                    break;
                case "Min":
                    dataType = DataType.Minute;
                    break;
                case "Min15":
                    dataType = DataType.Min15;
                    break;
                case "Hour":
                    dataType = DataType.Hour;
                    break;
                case "Day":
                    dataType = DataType.Day;
                    break;
                case "Month":
                    dataType = DataType.Month;
                    break;
                case "Year":
                    dataType = DataType.Year;
                    break;
            }
            try
            {
                retValue = DataProvider.GetCurrentValue(tagExpression, dataType);
                ////测试
                //if (strDataType == "Second" && retValue == 0)
                //{
                //    Logger.Info(String.Format("结束取值::TagExpression: {0}, DataType: {1}, 值为: {2}", tagExpression, strDataType, retValue));
                //}

                if(Double.IsNaN(retValue))
                {
                    retValue = 0.0D;
                    Logger.Warn(String.Format("非数字值::TagExpression: {0}, DataType: {1}", tagExpression, strDataType));
                }
            }
            catch(Exception ex)
            {
                Logger.Error(String.Format("Exception:{1}{0}", ex.Message, strDataType));
                Logger.Error(String.Format("取值错误::TagExpression: {0},DataType: {1}", tagExpression, strDataType));
            }
            return retValue;
        }
        
        #endregion
    }
}
