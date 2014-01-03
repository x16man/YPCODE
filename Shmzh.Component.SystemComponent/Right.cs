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
//    /// Right�����ݷ��ʲ㡣
//    /// </summary>
//    [Serializable]
//    public class Right
//    {
//        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

//        /// <summary>
//        /// ���캯��
//        /// </summary>
//        public Right()
//        {
//        }
//        /// <summary>
//        /// �󶨽�ɫȨ��
//        /// </summary>
//        /// <param name="role">��ɫ���</param>
//        /// <param name="rightlist">Ȩ�ޱ�Ŵ�</param>
//        /// <returns>bool</returns>
//        public bool AddRight(int role, string rightlist)
//        {
//            return (new RightDA()).AddRoleRight(role, rightlist);
//        }
//        /// <summary>
//        /// ����ָ���Ĳ�Ʒ��ŷ���Ȩ����Ϣʵ��.
//        /// </summary>
//        /// <param name="productCode">��Ʒ���</param>
//        /// <returns>DataSet</returns>
//        /// <remarks>���ָ���Ĳ�Ʒ���Ϊ0���ʾ����������Ч��Ȩ����Ϣ.</remarks>
//        [Obsolete("�˷����ظ�", false)]
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
//        /// ����Ȩ�ޱ�ŷ���Ȩ��ʵ��.
//        /// </summary>
//        /// <param name="rightCode">Ȩ�ޱ��</param>
//        /// <returns>RightInfo</returns>
//        /// <remarks>���û�ж�Ӧ��Ʒ�򷵻�null.</remarks>
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
//        /// Ȩ�����Ƿ����ڴ˲�Ʒ�е� 
//        /// </summary>
//        /// <param name="productCode">��Ʒ���</param>
//        /// <param name="rightCode">Ȩ������</param>
//        /// <returns>true����  false��ʾ������</returns>
//        /// <remarks>�˷���Ӧ����ִ��Insert����ʱ���á�</remarks>
//        public bool IsExistCode(int productCode, int rightCode)
//        {
//            string sqlStatement = string.Format("Select Count(*) From mySystemRights Where RightCode={0} And ProductCode={1}", rightCode, productCode);
//            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
//            return int.Parse(oRet.ToString()) == 0 ? false : true;
//        }
//        /// <summary>
//        /// �Ƿ������Ѿ�ʹ��
//        /// </summary>
//        /// <param name="name">Ȩ�����ơ�</param>
//        /// <param name="productCode">��Ʒ��š�</param>
//        /// <returns>bool</returns>
//        public bool IsExistName(string name, string productCode)
//        {
//            string sqlStatement = string.Format("Select Count(*) From  mySystemRights Where RightName='{0}' AND Productcode={1}", name, productCode);
//            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
//            return int.Parse(oRet.ToString()) == 0 ? false : true;
//        }
//        /// <summary>
//        /// �Ƿ��Ѿ�����Ȩ�����ƣ�����ͬ�������¡�
//        /// </summary>
//        /// <param name="code">Ȩ�ޱ�š�</param>
//        /// <param name="name">Ȩ�����ơ�</param>
//        /// <param name="productCode">��Ʒ��š�</param>
//        /// <returns>bool���ͣ����ڷ���True�����򷵻�False��</returns>
//        public bool IsExistName(string code, string name, string productCode)
//        {
//            string sqlStatement = string.Format("Select Count(*) From  mySystemRights Where RightCode<>'{0}' And RightName='{1}' AND Productcode={2}", code, name, productCode);
//            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
//            return int.Parse(oRet.ToString()) == 0 ? false : true;
//        }
//        /// <summary>
//        /// ����һȨ��
//        /// </summary>
//        /// <param name="thisRightInfo">Ȩ����Ϣʵ��.</param>
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
//        /// ����Ȩ��
//        /// </summary>
//        /// <param name="thisRightInfo">Ȩ��ʵ��</param>
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
//        /// ɾ��Ȩ����Ϣʵ��.
//        /// </summary>
//        /// <param name="thisRightInfo">Ȩ����Ϣʵ��.</param>
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
//        /// �Ƿ������õ���Ȩ��
//        /// </summary>
//        /// <param name="iRightCode">Ȩ�ޱ���</param>
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
//        /// ɾ��Ȩ��
//        /// </summary>
//        /// <param name="rightCode">Ȩ�޴���</param>
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
//        /// ���ݲ�Ʒ��Ż�ȡ���е�Ȩ���
//        /// </summary>
//        /// <param name="productCode">��Ʒ��š�</param>
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
//        /// ���ݲ�Ʒ��Ż�ȡ������Ч��Ȩ���
//        /// </summary>
//        /// <param name="productCode">��Ʒ��š�</param>
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
//        /// ���ݲ�Ʒ��ź�Ȩ�޷����ȡ���е�Ȩ���
//        /// </summary>
//        /// <param name="productCode">��Ʒ��š�</param>
//        /// <param name="rightCat">Ȩ�޷��ࡣ</param>
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
//        /// ���ݲ�Ʒ��ź�Ȩ�޷����ȡ������Ч��Ȩ���
//        /// </summary>
//        /// <param name="productCode">��Ʒ��š�</param>
//        /// <param name="rightCat">Ȩ�޷��ࡣ</param>
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
//        /// �õ����е�Ȩ��
//        /// </summary>
//        /// <param name="productcode">��Ʒ���</param>
//        /// <param name="catcode">�����š�</param>
//        /// <param name="bistrue">��־λ��</param>
//        /// <returns>ArrayList</returns>
//        [Obsolete("�˷�������ǡ����������", false)]
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
//        /// ���ݽ�ɫ�õ�Ȩ��
//        /// </summary>
//        /// <param name="roleCode">��ɫ��š�</param>
//        /// <returns>ArrayList</returns>
//        [Obsolete("�˷�����ǡ����������", false)]
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
//        /// ���ݽ�ɫ�õ�Ȩ�ޡ�
//        /// </summary>
//        /// <param name="roleCode">��ɫ��š�</param>
//        /// <returns>ArrayList��</returns>
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
