using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    class TB_SYSLDTP:IDAL.ITB_SYSLDTP
    {
        #region Field
        private const string FloDBName = "FloDBName";

        #endregion

        #region method
        private TB_SYSLDTPInfo ConvertToObject(IDataReader dr)
        {
            var obj = new TB_SYSLDTPInfo();
            obj.TypeId = int.Parse(dr["TypeId"].ToString());
            obj.TypeName = dr["TypeName"].ToString();
            obj.ClassOrder = int.Parse(dr["ClassOrder"].ToString());
            obj.Enable = bool.Parse(dr["Enable"].ToString());
            return obj;
        }
        #endregion
        /// <summary>
        /// 获取所有的领导类型记录。
        /// </summary>
        /// <returns>领导类型记录集合。</returns>
        public List<TB_SYSLDTPInfo> GetAll()
        {
            var sqlStatement = string.Format("Select * From {0}.dbo.TB_SYSLDTP", ConfigurationManager.AppSettings[FloDBName]);
            var objs = new ListBase<TB_SYSLDTPInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有有效的领导类型记录。
        /// </summary>
        /// <returns>领导类型记录集合。</returns>
        public List<TB_SYSLDTPInfo> GetAllAvalible()
        {
            var sqlStatement = string.Format("Select * From {0}.dbo.TB_SYSLDTP Where Enable = 1", ConfigurationManager.AppSettings[FloDBName]);
            var objs = new ListBase<TB_SYSLDTPInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }
    }
}
