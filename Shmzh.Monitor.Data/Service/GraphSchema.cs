using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;
using GraphSchemaRTagInfo = Shmzh.Monitor.Data.GraphSchemaTabService.GraphSchemaRTagInfo;

namespace Shmzh.Monitor.Data.Service
{
    class GraphSchema :IDAL.IGraphSchema
    {
        #region private method
        private GraphSchemaService.GraphSchemaInfo ConvertToWebServiceObject(GraphSchemaInfo obj)
        {
            var obj1 = new GraphSchemaService.GraphSchemaInfo();

            CopyHelper.Copy(obj,obj1);
            //obj1.DataType = obj.DataType;
            //obj1.InnerPaneGap = obj.InnerPaneGap;
            //obj1.IsValid = obj.IsValid;
            //obj1.Name = obj.Name;
            //obj1.Layout = obj.Layout;
            //obj1.LegendFontFamily = obj.LegendFontFamily;
            //obj1.LegendFontSize = obj.LegendFontSize;
            //obj1.LegendIsHStack = obj.LegendIsHStack;
            //obj1.LegendIsShowSymbols = obj.LegendIsShowSymbols;
            //obj1.LegendPosition = obj.LegendPosition;
            //obj1.LegendVisible = obj.LegendVisible;
            //obj1.Margin = obj.Margin;
            //obj1.ReferLoginName = obj.ReferLoginName;
            //obj1.ReferOpTime = obj.ReferOpTime;
            //obj1.Remark = obj.Remark;
            //obj1.SchemaId = obj.SchemaId;
            //obj1.TabWidth = obj.TabWidth;
            //obj1.Title = obj.Title;
            //obj1.TitleFontFamily = obj.TitleFontFamily;
            //obj1.TitleFontSize = obj.TitleFontSize;
            //obj1.TitleVisible = obj.TitleVisible;
            if (obj.ItemList.Count > 0)
            {
                obj1.ItemList = new GraphSchemaService.GraphSchemaItemInfo[obj.ItemList.Count];
                for(var i=0;i<obj.ItemList.Count;i++)
                {
                    obj1.ItemList[i] = ConvertToWebServiceObject(obj.ItemList[i]);
                }
            }
            if(obj.FloatingBlockInfos.Count > 0)
            {
                obj1.FloatingBlockInfos = new GraphSchemaService.FloatingBlockInfo[obj.FloatingBlockInfos.Count];
                for(var i=0;i<obj.FloatingBlockInfos.Count;i++)
                {
                    obj1.FloatingBlockInfos[i] = ConvertToWebServiceObject(obj.FloatingBlockInfos[i]);
                }
            }
            if(obj.GraphSchemaTabInfos.Count > 0)
            {
                obj1.GraphSchemaTabInfos = new GraphSchemaService.GraphSchemaTabInfo[obj.GraphSchemaTabInfos.Count];
                for (var i = 0; i < obj.GraphSchemaTabInfos.Count; i++)
                {
                    obj1.GraphSchemaTabInfos[i] = ConvertToWebServiceObject(obj.GraphSchemaTabInfos[i]);
                }
            }
            return obj1;
        }
        private GraphSchemaService.GraphSchemaItemInfo ConvertToWebServiceObject(GraphSchemaItemInfo obj)
        {
            var obj1 = new GraphSchemaService.GraphSchemaItemInfo();
            CopyHelper.Copy(obj,obj1);
            //obj1.ItemId = obj.ItemId;
            //obj1.LegendFontFamily = obj.LegendFontFamily;
            //obj1.LegendFontSize = obj.LegendFontSize;
            //obj1.LegendIsHStack = obj.LegendIsHStack;
            //obj1.LegendIsShowSymbols = obj.LegendIsShowSymbols;
            //obj1.LegendPosition = obj.LegendPosition;
            //obj1.LegendVisible = obj.LegendVisible;
            //obj1.MinSpaceL = obj.MinSpaceL;
            //obj1.MinSpaceR = obj.MinSpaceR;
            //obj1.SchemaId = obj.SchemaId;
            //obj1.SerialNumber = obj.SerialNumber;
            //obj1.Title = obj.Title;
            //obj1.TitleFontFamily = obj.TitleFontFamily;
            //obj1.TitleFontSize = obj.TitleFontSize;
            //obj1.TitleVisible = obj.TitleVisible;
            //obj1.XAxis = obj.XAxis;
            //obj1.XScaleFontFamily = obj.XScaleFontFamily;
            //obj1.XScaleFontSize = obj.XScaleFontSize;
            //obj1.XScaleFormat = obj.XScaleFormat;
            //obj1.XScaleVisible = obj.XScaleVisible;
            //obj1.XTitleFontFamily = obj.XTitleFontFamily;
            //obj1.XTitleFontSize = obj.XTitleFontSize;
            //obj1.XTitleVisible = obj.XTitleVisible;
            //obj1.YAxis = obj.YAxis;
            //obj1.YScaleFontFaminly = obj.YScaleFontFaminly;
            //obj1.YScaleFontSize = obj.YScaleFontSize;
            //obj1.YScaleFormat = obj.YScaleFormat;
            //obj1.YScaleVisible = obj.YScaleVisible;
            //obj1.YTitleFontFamily = obj.YTitleFontFamily;
            //obj1.YTitleFontSize = obj.YTitleFontSize;
            //obj1.YTitleVisible = obj.YTitleVisible;
            if(obj.TagList.Count > 0)
            {
                obj1.TagList = new GraphSchemaService.GraphSchemaTagInfo[obj.TagList.Count];
                for(var i=0;i<obj.TagList.Count;i++)
                {
                    var tag = new GraphSchemaService.GraphSchemaTagInfo();
                    CopyHelper.Copy(obj.TagList[i], tag);
                    obj1.TagList[i] = tag;
                 }
            }
            return obj1;
        }
        private GraphSchemaService.FloatingBlockInfo ConvertToWebServiceObject(FloatingBlockInfo obj)
        {
            var obj1 = new GraphSchemaService.FloatingBlockInfo();
            CopyHelper.Copy(obj,obj1);
            if(obj.ItemList.Count > 0)
            {
                obj1.ItemList = new GraphSchemaService.FloatingBlockItemInfo[obj.ItemList.Count];
                for(var i=0;i<obj.ItemList.Count;i++)
                {
                    var item = new GraphSchemaService.FloatingBlockItemInfo();
                    CopyHelper.Copy(obj.ItemList[i],item);
                    obj1.ItemList[i] = item;
                }
            }
            return obj1;
        }
        private GraphSchemaService.GraphSchemaTabInfo ConvertToWebServiceObject(GraphSchemaTabInfo obj)
        {
            var obj1 = new GraphSchemaService.GraphSchemaTabInfo();
            CopyHelper.Copy(obj,obj1);
            if(obj.RTagList.Count>0)
            {
                obj1.RTagList = new GraphSchemaService.GraphSchemaRTagInfo[obj.RTagList.Count];
                for(var i=0;i<obj.RTagList.Count;i++)
                {
                    var rtag = new GraphSchemaService.GraphSchemaRTagInfo();
                    CopyHelper.Copy(obj.RTagList[i], rtag);
                    obj1.RTagList[i] = rtag;
                }
            }
            return obj1;
        }
        
        #endregion

        #region Implementation of IGraphSchema

        /// <summary>
        /// 根据方案Id获取方案信息。
        /// </summary>
        /// <param name="schemaId">方案Id。</param>
        /// <returns>方案信息实体。</returns>
        public GraphSchemaInfo GetById(int schemaId)
        {
            var da = new GraphSchemaService.GraphSchema();
            var obj = da.GetById(schemaId);
            GraphSchemaInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new GraphSchemaInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 根据方案名称获取方案信息。
        /// </summary>
        /// <param name="name">方案名称。</param>
        /// <returns>方案信息实体。</returns>
        public GraphSchemaInfo GetByName(string name)
        {
            var da = new GraphSchemaService.GraphSchema();
            var obj = da.GetByName(name);
            GraphSchemaInfo obj1 = null;
            if(obj != null)
            {
                obj1 = new GraphSchemaInfo();
                CopyHelper.Copy(obj, obj1);
            }
            return obj1;
        }

        /// <summary>
        /// 获取所有的曲线方案。
        /// </summary>
        /// <returns>曲线方案集合。</returns>
        public List<GraphSchemaInfo> GetAll()
        {
            var objs = new GraphSchemaService.GraphSchema().GetAll();
            var obj1s = new List<GraphSchemaInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new GraphSchemaInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            
            return obj1s;
        }

        /// <summary>
        /// 根据方案Id获取所属的全部方案。
        /// </summary>
        /// <param name="categoryId">方案类别Id。</param>
        /// <returns></returns>
        public List<GraphSchemaInfo> GetByCategoryId(int categoryId)
        {
            var objs = new GraphSchemaService.GraphSchema().GetByCategoryId(categoryId);
            var obj1s = new List<GraphSchemaInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GraphSchemaInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }

            return obj1s;
        }

        /// <summary>
        /// 获取未分类的方案。当loginName 为 null 或 "" 时取全部未分类的方案。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <returns></returns>
        public List<GraphSchemaInfo> GetNoCategorySchema(String loginName)
        {
            var objs = new GraphSchemaService.GraphSchema().GetNoCategorySchema(loginName);
            var obj1s = new List<GraphSchemaInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new GraphSchemaInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }

            return obj1s;
        }

        /// <summary>
        /// 根据曲线方案Id来删除曲线方案。
        /// </summary>
        /// <param name="schemaId">曲线方案Id。</param>
        /// <returns>bool</returns>
        public bool Delete(int schemaId)
        {
            return new GraphSchemaService.GraphSchema().Delete(schemaId);
        }

        /// <summary>
        /// 删除曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GraphSchemaInfo graphSchemaInfo)
        {
            return Delete(graphSchemaInfo.SchemaId);
        }

        /// <summary>
        /// 添加曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        public int Insert(GraphSchemaInfo graphSchemaInfo)
        {
            var obj = new GraphSchemaService.GraphSchemaInfo();
            CopyHelper.Copy(graphSchemaInfo, obj);
            
            return new GraphSchemaService.GraphSchema().Insert(obj);
        }

        public int InsertWithTrans(SqlTransaction trans, GraphSchemaInfo graphSchemaInfo)
        {
            
            return DataProvider.GraphSchemaProvider.InsertWithTrans(trans, graphSchemaInfo);
        }

        /// <summary>
        /// 修改曲线方案对象。
        /// </summary>
        /// <param name="graphSchemaInfo">曲线方案对象。</param>
        /// <returns>bool</returns>
        public bool Update(GraphSchemaInfo graphSchemaInfo)
        {
            var obj = new GraphSchemaService.GraphSchemaInfo();
            CopyHelper.Copy(graphSchemaInfo, obj);
            return new GraphSchemaService.GraphSchema().Update(obj);
        }

        /// <summary>
        /// 更新创建或修改人。
        /// </summary>
        /// <param name="schemaId">方案Id。</param>
        /// <param name="referLoginName">登录名。</param>
        /// <returns></returns>
        public bool UpdateLoginName(int schemaId, string referLoginName)
        {
            return new GraphSchemaService.GraphSchema().UpdateLoginName(schemaId, referLoginName);
        }

        /// <summary>
        /// 深层次保存曲线方案对象.
        /// </summary>
        /// <param name="obj">曲线方案对象.</param>
        /// <returns>bool</returns>
        public bool DeepSave(GraphSchemaInfo obj)
        {
            var obj1 = ConvertToWebServiceObject(obj);
            return new GraphSchemaService.GraphSchema().DeepSave(obj1);
        }
        #endregion
    }
}
