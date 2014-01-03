using System;
using System.Configuration;
using System.Collections.Generic;
using Shmzh.Components.Util;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.Components.SystemComponent
{
    /// <summary>
    /// 授权类。
    /// </summary>
    public class Authorization
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
        private List<UserInfo> _users;
        #endregion

        #region Property
        /// <summary>
        /// 授权key值。
        /// </summary>
        private string LicenseKey { get; set; }
        /// <summary>
        /// 产品编号。
        /// </summary>
        private string ProductCode {
            get { return ConfigurationManager.AppSettings["ProductId"]; }
        }
        /// <summary>
        /// 使用单位信息。
        /// </summary>
        private CompanyInfo Company
        {
            get; set;
        }
        /// <summary>
        /// 有效的用户列表。
        /// </summary>
        private List<UserInfo> Users
        {
            get
            {
                if(_users == null)
                {
                    _users = DataProvider.UserProvider.GetAllAvalibleByCompany(this.Company.CoCode) as List<UserInfo>;
                }
                return _users;
            }
        }
        /// <summary>
        /// 系统中有效的用户的数目。
        /// </summary>
        private int AvalibleUserCount
        {
            get { return this.Users.Count; }
        }
        /// <summary>
        /// 授权状态。-5：公司名称不符。-4:产品编号不符。-3:授权人数不够。-2:非法授权。-1:没有公司信息。0:超出试用期限。1:正式授权。2：试用。
        /// </summary>
        public int LicenseStatus
        {
            get
            {
                string s;
                try
                {
                    s = Cryptography.RSADescryptBySpecifyPublicKey(this.LicenseKey);
                }
                catch (Exception)
                {
                    return -2;//非法授权。                    
                }
                
                var a = s.Split('|');

                
                var ce = this.Company;
                
                if(ce == null)
                {
                    return -1;  //没有公司信息。  
                }

                if(a.Length>4)//带试用期限。
                {
                    var d = DateTime.Parse(a[1]);
                    
                    if (DateTime.Today <= d)//在试用期限内。
                    {
                        this.LeftTrailDays = d.Subtract(DateTime.Today).Days;
                        if (ce.CoName == a[0])//授权的公司名称符合。
                        {
                            if (this.ProductCode == a[2])//授权信息中产品编号与当前产品一致。
                            {
                                if ( a[3] == "0" || this.AvalibleUserCount<=int.Parse(a[3]))//没有用户限制或用户数在授权范围内。
                                {
                                    return 2;//可以试用。
                                }
                                else
                                {
                                    return -3;//超出授权人数。
                                }
                            }
                            else
                            {
                                return -4;//产品编号不符，非法授权。
                            }
                        }
                        else//公司名称不匹配。
                        {
                            return -5;
                        }
                    }
                    else//超出试用期。
                    {
                        return 0;
                    }
                }
                else//永久使用。
                {
                    //Logger.Info("永久使用");
                    //Logger.Info(a);
                    if(ce.CoName == a[0])//授权的公司名称不符。
                    {
                        //Logger.Info(a[1]);
                        if (this.ProductCode == a[1])//授权信息中产品编号与当前产品一致。
                        {
                            if (a[2] == "0" || this.AvalibleUserCount <= int.Parse(a[2]))//没有用户限制或用户数在授权范围内。
                            {
                                //Logger.Info("正式授权");
                                return 1;//正式授权。
                            }
                            else
                            {
                                //Logger.Info("-3");
                                return -3;//超出授权人数。
                            }
                        }
                        else
                        {
                            //Logger.Info(string.Format("{0},-4",this.ProductCode));
                            return -4;//产品编号不符，非法授权。
                        }
                    }
                    else
                    {
                        //Logger.Info("-5");
                        return -5;
                    }
                }
            }
        }
        /// <summary>
        /// 使用剩余天数。
        /// </summary>
        public int LeftTrailDays { get; set; }
        #endregion

        
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="licenseKey">注册码。</param>
        /// <param name="companyInfo">默认单位。</param>
        public Authorization(string licenseKey, CompanyInfo companyInfo)
        {
            this.LicenseKey = licenseKey;
            this.Company = companyInfo;
        }

        
    }
}
