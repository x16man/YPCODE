// <copyright file="Grant.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;

	/// <summary>
	/// 授权的摘要说明。
	/// </summary>
    public class Grant
    {
        #region constractor
        /// <summary>
        /// 构造函数
        /// 支持Remoting和Web Service,不能省略构造函数
        /// </summary>
        public Grant()
        {
            this.LoginIsValid = true;
            this.IsValid = true;
            this.InvalidTime = new DateTime(1900, 01, 01);
            this.IsLeaf = true;
            this.EmbracerDept = String.Empty;
            this.EmbracerName = String.Empty;
            this.Embracer = String.Empty;
            this.GrantorDept = String.Empty;
            this.GrantorName = String.Empty;
            this.Grantor = String.Empty;
            this.PKID = -1;
        }

	    #endregion

        #region property

	    /// <summary>
	    /// 识别码
	    /// </summary>
	    public long PKID { get; set; }

	    /// <summary>
	    /// 授权者
	    /// </summary>
	    public string Grantor { get; set; }

	    /// <summary>
	    /// 授权人姓名
	    /// </summary>
	    public string GrantorName { get; set; }

	    /// <summary>
	    /// 授权人部门
	    /// </summary>
	    public string GrantorDept { get; set; }

	    /// <summary>
	    /// 接受者
	    /// </summary>
	    public string Embracer { get; set; }

	    /// <summary>
	    /// 接受者姓名
	    /// </summary>
	    public string EmbracerName { get; set; }

	    /// <summary>
	    /// 接受者部门
	    /// </summary>
	    public string EmbracerDept { get; set; }

	    /// <summary>
	    /// 是否是叶子节点
	    /// </summary>
	    public bool IsLeaf { get; set; }

	    /// <summary>
	    /// 创建日期
	    /// </summary>
	    public DateTime CreateTime { get; set; }

	    /// <summary>
	    /// 无效时间
	    /// </summary>
	    public DateTime InvalidTime { get; set; }

	    /// <summary>
	    /// 是否无效
	    /// </summary>
	    public bool IsValid { get; set; }

	    /// <summary>
	    /// 生效时间
	    /// </summary>
	    public DateTime EffectTime { get; set; }

	    /// <summary>
	    /// 是否登录后无效
	    /// </summary>
	    public bool LoginIsValid { get; set; }

	    /// <summary>
	    /// 授权原因
	    /// </summary>
	    public string Reason { get; set; }

	    #endregion

        #region public methods
        /// <summary>
        /// 增加
        /// </summary>
        /// <returns>主键值</returns>
        public bool Add()
        {
            return new GrantDA().SaveGrants(this);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>是否更新成功</returns>
        public bool Update()
        {
            return false;
        }
		/// <summary>
		/// 设定授权的有效性
		/// </summary>
		/// <param name="pkid">PKID</param>
		/// <param name="isvalid">是否有效</param>
		/// <returns>bool</returns>
        public bool SetEffective(long pkid,bool isvalid)
        {
            return new GrantDA().SetIsValid(pkid,isvalid);
        }

        /// <summary>
        /// 根据PKID得到授权信息
        /// </summary>
        /// <param name="pkid">pkid</param>
        public void Get(long pkid)
        {
            var objGrantDA = new GrantDA();
            var ds = objGrantDA.GetGrantsByPKID(pkid);

            if (ds == null) return;

            var dr = ds.Tables[0].Rows[0];

            this.PKID = long.Parse(dr["PKID"].ToString());
            this.Embracer = dr["Embracer"].ToString();
            this.EmbracerName = dr["EmbracerName"].ToString();
            this.EmbracerDept = dr["EmbracerDept"].ToString();
            this.Grantor = dr["Grantor"].ToString();
            this.GrantorName = dr["GrantorName"].ToString();
            this.GrantorDept = dr["GrantorDept"].ToString();
            this.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
            this.EffectTime = DateTime.Parse(dr["EffectTime"].ToString());
            if (dr["InvalidTime"] != DBNull.Value)
                this.InvalidTime = DateTime.Parse(dr["InvalidTime"].ToString());
            this.IsLeaf = bool.Parse(dr["IsLeaf"].ToString());
            this.IsValid = bool.Parse(dr["IsValid"].ToString());
            this.LoginIsValid = bool.Parse(dr["LoginIsValid"].ToString());
            this.Reason = dr["Reason"].ToString();
        }
        #endregion
	}

    /// <summary>
    /// 授权集合
    /// </summary>
    public class Grants : System.Collections.CollectionBase
    {
        #region constractor
        /// <summary>
        /// 构造函数
        /// 支持Remoting和Web Service,不能省略构造函数
        /// </summary>
        public Grants()
        {}
        #endregion

        #region Collection 部分
        /// <summary>
        /// 建立索引
        /// </summary>
        /// <param name="index">索引号</param>
        public Grant this[int index]
        {
            get
            {
                return (Grant)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }

        /// <summary>
        /// 增加一项
        /// </summary>
        /// <param name="item">授权记录实体。</param>
        public void Add(Grant item)
        {
            List.Add(item);
        }

        /// <summary>
        /// 删除一项
        /// </summary>
        /// <param name="index">索引号</param>
        public void Remove(int index)
        {
            if (index < this.Count - 1 && index > 0)
            {
                List.RemoveAt(index);
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// 得到所有的授权者
        /// </summary>
        /// <param name="embracer">授权人登录名。</param>
        public void GetGrantsByEmbracer(string embracer)
        {
            var objGrantDA = new GrantDA();

            var ds = objGrantDA.GetGrantsByEmbracer(embracer);

            if (ds == null) return;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var grant = new Grant
                                {
                                    PKID = long.Parse(dr["PKID"].ToString()),
                                    Embracer = dr["Embracer"].ToString(),
                                    EmbracerName = dr["EmbracerName"].ToString(),
                                    EmbracerDept = dr["EmbracerDept"].ToString(),
                                    Grantor = dr["Grantor"].ToString(),
                                    GrantorName = dr["GrantorName"].ToString(),
                                    GrantorDept = dr["GrantorDept"].ToString(),
                                    CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),
                                    EffectTime = DateTime.Parse(dr["EffectTime"].ToString()),
                                    IsLeaf = bool.Parse(dr["IsLeaf"].ToString()),
                                    IsValid = bool.Parse(dr["IsValid"].ToString()),
                                    LoginIsValid = bool.Parse(dr["LoginIsValid"].ToString()),
                                    Reason = dr["Reason"].ToString()
                                };

                if (dr["InvalidTime"] != DBNull.Value) 
                    grant.InvalidTime = DateTime.Parse(dr["InvalidTime"].ToString());
                this.Add(grant);
            }
        }

        /// <summary>
        /// 得到所有的接受者
        /// </summary>
        /// <param name="grantor">授予者登录名。</param>
        public void GetEmbracersByGrantor(string grantor)
        {
            var objGrantDA = new GrantDA();

            var ds = objGrantDA.GetGrantsByGrantor(grantor);

            if (ds == null) return;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var grant = new Grant
                                {
                                    PKID = long.Parse(dr["PKID"].ToString()),
                                    Embracer = dr["Embracer"].ToString(),
                                    EmbracerName = dr["EmbracerName"].ToString(),
                                    EmbracerDept = dr["EmbracerDept"].ToString(),
                                    Grantor = dr["Grantor"].ToString(),
                                    GrantorName = dr["GrantorName"].ToString(),
                                    GrantorDept = dr["GrantorDept"].ToString(),
                                    CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),
                                    EffectTime = DateTime.Parse(dr["EffectTime"].ToString()),
                                    IsLeaf = bool.Parse(dr["IsLeaf"].ToString()),
                                    IsValid = bool.Parse(dr["IsValid"].ToString()),
                                    LoginIsValid = bool.Parse(dr["LoginIsValid"].ToString()),
                                    Reason = dr["Reason"].ToString()
                                };

                if (dr["InvalidTime"] != DBNull.Value)
                    grant.InvalidTime = DateTime.Parse(dr["InvalidTime"].ToString());
                this.Add(grant);
            }
        }
        #endregion
    }
   }
