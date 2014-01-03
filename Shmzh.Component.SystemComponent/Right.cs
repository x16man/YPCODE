////-----------------------------------------------------------------------
//// <copyright file="Right.cs" company="Shmzh Technology">
////     Copyright (c) Shmzh Technology. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//namespace Shmzh.Components.SystemComponent
//{
//    using System;
//    using System.Collections;
//    using System.Data;

//    /// <summary>
//    /// Right的数据访问层。
//    /// </summary>
//    [Serializable]
//    public class Right
//    {
//        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        public Right()
//        {
//        }
//        /// <summary>
//        /// 绑定角色权限
//        /// </summary>
//        /// <param name="role">角色编号</param>
//        /// <param name="rightlist">权限编号串</param>
//        /// <returns>bool</returns>
//        public bool AddRight(int role, string rightlist)
//        {
//            return (new RightDA()).AddRoleRight(role, rightlist);
//        }
//        /// <summary>
//        /// 根据指定的产品编号返回权限信息实体.
//        /// </summary>
//        /// <param name="productCode">产品编号</param>
//        /// <returns>DataSet</returns>
//        /// <remarks>如果指定的产品编号为0则表示返回所有有效的权限信息.</remarks>
//        [Obsolete("此方法重复", false)]
//        public DataSet GetByProductCode(int productCode)
//        {
//            string sqlStatement = string.Format(@"Select    a.RightCode as RightCode,
//                                                            a.RightName as RightName,
//                                                            a.Isvalid as Isvalid,
//                                                            a.Remark as Remark,
//                                                            a.ProductCode as ProductCode,
//                                                            b.productName as productName,
//                                                            a.RightCatCode as RightCatCode 
//                                                  From      mySystemRights as a,
//                                                            mySystemProducts as b 
//                                                  Where     a.ProductCode<>1 and 
//                                                            a.ProductCode=b.ProductCode and  
//                                                            a.ProductCode ={0}", productCode);
//            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
//        }
//        /// <summary>
//        /// 根据权限编号返回权限实体.
//        /// </summary>
//        /// <param name="rightCode">权限编号</param>
//        /// <returns>RightInfo</returns>
//        /// <remarks>如果没有对应产品则返回null.</remarks>
//        public RightInfo GetByCode(int rightCode)
//        {
//            var obj = new RightInfo { CheckRight = false };
//            var sqlStatement = string.Format("Select * From mySystemRights Where RightCode = {0}", rightCode);
//            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement);
//            if (dr.HasRows)
//            {
//                dr.Read();
//                obj.RightCode = int.Parse(dr["RightCode"].ToString());
//                obj.RightName = dr["RightName"].ToString();
//                obj.IsValid = dr["IsValid"].ToString();
//                obj.Remark = dr["Remark"].ToString();
//                obj.ProductCode = int.Parse(dr["ProductCode"].ToString());
//                obj.RightCatCode = dr["RightCatCode"].ToString();
//                obj.CheckRight = true;
//            }
//            dr.Close();
//            return obj;
//        }
//        /// <summary>
//        /// 权限码是否属于此产品中的 
//        /// </summary>
//        /// <param name="productCode">产品编号</param>
//        /// <param name="rightCode">权限码编号</param>
//        /// <returns>true存在  false表示不存在</returns>
//        /// <remarks>此方法应该在执行Insert方法时采用。</remarks>
//        public bool IsExistCode(int productCode, int rightCode)
//        {
//            string sqlStatement = string.Format("Select Count(*) From mySystemRights Where RightCode={0} And ProductCode={1}", rightCode, productCode);
//            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
//            return int.Parse(oRet.ToString()) == 0 ? false : true;
//        }
//        /// <summary>
//        /// 是否名称已经使用
//        /// </summary>
//        /// <param name="name">权限名称。</param>
//        /// <param name="productCode">产品编号。</param>
//        /// <returns>bool</returns>
//        public bool IsExistName(string name, string productCode)
//        {
//            string sqlStatement = string.Format("Select Count(*) From  mySystemRights Where RightName='{0}' AND Productcode={1}", name, productCode);
//            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
//            return int.Parse(oRet.ToString()) == 0 ? false : true;
//        }
//        /// <summary>
//        /// 是否已经存在权限名称，在相同的名称下。
//        /// </summary>
//        /// <param name="code">权限编号。</param>
//        /// <param name="name">权限名称。</param>
//        /// <param name="productCode">产品编号。</param>
//        /// <returns>bool类型：存在返回True，否则返回False。</returns>
//        public bool IsExistName(string code, string name, string productCode)
//        {
//            string sqlStatement = string.Format("Select Count(*) From  mySystemRights Where RightCode<>'{0}' And RightName='{1}' AND Productcode={2}", code, name, productCode);
//            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
//            return int.Parse(oRet.ToString()) == 0 ? false : true;
//        }
//        /// <summary>
//        /// 增加一权限
//        /// </summary>
//        /// <param name="thisRightInfo">权限信息实体.</param>
//        /// <returns>bool</returns>
//        public bool Add(RightInfo thisRightInfo)
//        {
//            var retValue = true;
//            var sqlStatement = string.Format("Insert Into mySystemRights Values ({0},'{1}','{2}','{3}',{4},'{5}')",
//                thisRightInfo.RightCode,
//                thisRightInfo.RightName,
//                thisRightInfo.IsValid,
//                thisRightInfo.Remark,
//                thisRightInfo.ProductCode,
//                thisRightInfo.RightCatCode);
//            try
//            {
//                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement);
//            }
//            catch
//            {
//                retValue = false;
//            }
//            return retValue;
//        }
//        /// <summary>
//        /// 更改权限
//        /// </summary>
//        /// <param name="thisRightInfo">权限实体</param>
//        /// <returns>bool</returns>
//        public bool Update(RightInfo thisRightInfo)
//        {
//            var retValue = true;
//            var sqlStatement = string.Format("Update mySystemRights Set RightCode={5},RightName='{0}',IsValid='{1}',Remark='{2}',ProductCode={3},RightCatCode='{4}' Where RightCode={6}",

//                thisRightInfo.RightName,
//                thisRightInfo.IsValid,
//                thisRightInfo.Remark,
//                thisRightInfo.ProductCode,
//                thisRightInfo.RightCatCode,
//                thisRightInfo.RightCode,
//                thisRightInfo.OldRightCode);
//            try
//            {
//                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement);
//            }
//            catch
//            {
//                retValue = false;
//            }
//            return retValue;
//        }
//        /// <summary>
//        /// 删除权限信息实体.
//        /// </summary>
//        /// <param name="thisRightInfo">权限信息实体.</param>
//        /// <returns>bool</returns>
//        public bool Delete(RightInfo thisRightInfo)
//        {
//            bool retValue = true;
//            if (this.IsHaveRightRoleCode(thisRightInfo.RightCode))
//            {
//                retValue = false;
//            }
//            else
//            {
//                string sqlStatement = string.Format("Delete From  mySystemRights Where RightCode={0}", thisRightInfo.RightCode);
//                try
//                {
//                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement);
//                }
//                catch
//                {
//                    retValue = false;
//                }
//            }
//            return retValue;
//        }
//        /// <summary>
//        /// 是否有组用到此权限
//        /// </summary>
//        /// <param name="iRightCode">权限编码</param>
//        /// <returns>bool</returns>
//        public bool IsHaveRightRoleCode(int iRightCode)
//        {
//            var sqlStatement = string.Format("select RoleCode From  mySystemRoleRights Where RightCode={0}", iRightCode);

//            try
//            {
//                if (SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement).Tables[0].Rows.Count > 0)
//                    return true;
//            }
//            catch (Exception ex)
//            {
//                Logger.Error(ex.Message);
//                return true;
//            }
//            return false;
//        }
//        /// <summary>
//        /// 删除权限
//        /// </summary>
//        /// <param name="rightCode">权限代码</param>
//        /// <returns>bool</returns>
//        public bool DeleteRight(int rightCode)
//        {
//            var retValue = true;

//            if (this.IsHaveRightRoleCode(rightCode))
//            {
//                retValue = false;
//            }
//            else
//            {
//                var sqlStatement = string.Format("Delete From  mySystemRights Where RightCode={0}", rightCode);

//                try
//                {
//                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, sqlStatement);
//                }
//                catch
//                {
//                    retValue = false;
//                }
//            }
//            return retValue;
//        }
//        /// <summary>
//        /// 根据产品编号获取所有的权限项。
//        /// </summary>
//        /// <param name="productCode">产品编号。</param>
//        /// <returns>ArrayList</returns>
//        public ArrayList GetAllByProduct(int productCode)
//        {
//            var right = new ArrayList();
//            var ds = new RightDA().GetAllByProductCode(productCode);
//            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//            {
//                foreach (DataRow oRow in ds.Tables[0].Rows)
//                {
//                    var obj = new RightInfo
//                                  {
//                                      RightCode = int.Parse(oRow["RightCode"].ToString()),
//                                      RightName = oRow["RightName"].ToString(),
//                                      RightCatCode = oRow["RightCatCode"].ToString()
//                                  };
//                    right.Add(obj);
//                }
//            }
//            return right;
//        }
//        /// <summary>
//        /// 根据产品编号获取所有有效的权限项。
//        /// </summary>
//        /// <param name="productCode">产品编号。</param>
//        /// <returns>ArrayList</returns>
//        public ArrayList GetAllAvalibleByProduct(int productCode)
//        {
//            var right = new ArrayList();
//            var ds = new RightDA().GetAllAvalibleByProductCode(productCode);
//            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//            {
//                foreach (DataRow oRow in ds.Tables[0].Rows)
//                {
//                    var obj = new RightInfo
//                                  {
//                                      RightCode = int.Parse(oRow["RightCode"].ToString()),
//                                      RightName = oRow["RightName"].ToString(),
//                                      RightCatCode = oRow["RightCatCode"].ToString()
//                                  };
//                    right.Add(obj);
//                }
//            }
//            return right;
//        }
//        /// <summary>
//        /// 根据产品编号和权限分类获取所有的权限项。
//        /// </summary>
//        /// <param name="productCode">产品编号。</param>
//        /// <param name="rightCat">权限分类。</param>
//        /// <returns>ArrayList</returns>
//        public ArrayList GetAllByRightCat(int productCode, string rightCat)
//        {
//            var right = new ArrayList();
//            var ds = new RightDA().GetAllByRightCat(productCode, rightCat);
//            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//            {
//                foreach (DataRow oRow in ds.Tables[0].Rows)
//                {
//                    var obj = new RightInfo
//                                  {
//                                      RightCode = int.Parse(oRow["RightCode"].ToString()),
//                                      RightName = oRow["RightName"].ToString(),
//                                      RightCatCode = oRow["RightCatCode"].ToString()
//                                  };
//                    right.Add(obj);
//                }
//            }
//            return right;
//        }
//        /// <summary>
//        /// 根据产品编号和权限分类获取所有有效的权限项。
//        /// </summary>
//        /// <param name="productCode">产品编号。</param>
//        /// <param name="rightCat">权限分类。</param>
//        /// <returns>ArrayList</returns>
//        public ArrayList GetAllAvalibleByRightCat(int productCode, string rightCat)
//        {
//            var right = new ArrayList();
//            var ds = new RightDA().GetAllAvalibleByRightCat(productCode, rightCat);
//            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//            {
//                foreach (DataRow oRow in ds.Tables[0].Rows)
//                {
//                    var obj = new RightInfo
//                                  {
//                                      RightCode = int.Parse(oRow["RightCode"].ToString()),
//                                      RightName = oRow["RightName"].ToString(),
//                                      RightCatCode = oRow["RightCatCode"].ToString()
//                                  };
//                    right.Add(obj);
//                }
//            }
//            return right;
//        }
//        /// <summary>
//        /// 得到所有的权限
//        /// </summary>
//        /// <param name="productcode">产品编号</param>
//        /// <param name="catcode">分类编号。</param>
//        /// <param name="bistrue">标志位。</param>
//        /// <returns>ArrayList</returns>
//        [Obsolete("此方法名不恰当，已作废", false)]
//        public ArrayList GetAllRight(int productcode, string catcode, bool bistrue)
//        {
//            var right = new ArrayList();
//            var ds = new RightDA().GetCatRights(productcode, catcode, bistrue);

//            if (ds != null)
//            {
//                for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
//                {
//                    var objRightInfo = new RightInfo
//                                           {
//                                               RightCode = int.Parse(ds.Tables[0].Rows[i]["RightCode"].ToString()),
//                                               RightName = ds.Tables[0].Rows[i]["RightName"].ToString(),
//                                               RightCatCode = ds.Tables[0].Rows[i]["RightCatCode"].ToString()
//                                           };

//                    right.Add(objRightInfo);
//                }
//            }
//            return right;
//        }
//        /// <summary>
//        /// 根据角色得到权限
//        /// </summary>
//        /// <param name="roleCode">角色编号。</param>
//        /// <returns>ArrayList</returns>
//        [Obsolete("此方名不恰当，已作废", false)]
//        public ArrayList GetAllRightByRole(int roleCode)
//        {
//            var right = new ArrayList();
//            var ds = new RightDA().GetAllRightsByRole(roleCode);
//            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//            {
//                foreach (DataRow oRow in ds.Tables[0].Rows)
//                {
//                    var obj = new RoleRightInfo
//                                  {
//                                      RightCode = short.Parse(oRow["RightCode"].ToString()),
//                                      RoleCode = short.Parse(oRow["RoleCode"].ToString())
//                                  };
//                    right.Add(obj);
//                }
//            }
//            return right;
//        }
//        /// <summary>
//        /// 根据角色得到权限。
//        /// </summary>
//        /// <param name="roleCode">角色编号。</param>
//        /// <returns>ArrayList。</returns>
//        public ArrayList GetAllByRoleCode(int roleCode)
//        {
//            var right = new ArrayList();
//            var ds = new RightDA().GetAllRightsByRole(roleCode);
//            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//            {
//                foreach (DataRow oRow in ds.Tables[0].Rows)
//                {
//                    var obj = new RoleRightInfo
//                                  {
//                                      RightCode = short.Parse(oRow["RightCode"].ToString()),
//                                      RoleCode = short.Parse(oRow["RoleCode"].ToString())
//                                  };
//                    right.Add(obj);
//                }
//            }
//            return right;
//        }
//    }
//}
