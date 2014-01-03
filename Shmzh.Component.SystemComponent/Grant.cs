// <copyright file="Grant.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;

	/// <summary>
	/// ��Ȩ��ժҪ˵����
	/// </summary>
    public class Grant
    {
        #region constractor
        /// <summary>
        /// ���캯��
        /// ֧��Remoting��Web Service,����ʡ�Թ��캯��
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
	    /// ʶ����
	    /// </summary>
	    public long PKID { get; set; }

	    /// <summary>
	    /// ��Ȩ��
	    /// </summary>
	    public string Grantor { get; set; }

	    /// <summary>
	    /// ��Ȩ������
	    /// </summary>
	    public string GrantorName { get; set; }

	    /// <summary>
	    /// ��Ȩ�˲���
	    /// </summary>
	    public string GrantorDept { get; set; }

	    /// <summary>
	    /// ������
	    /// </summary>
	    public string Embracer { get; set; }

	    /// <summary>
	    /// ����������
	    /// </summary>
	    public string EmbracerName { get; set; }

	    /// <summary>
	    /// �����߲���
	    /// </summary>
	    public string EmbracerDept { get; set; }

	    /// <summary>
	    /// �Ƿ���Ҷ�ӽڵ�
	    /// </summary>
	    public bool IsLeaf { get; set; }

	    /// <summary>
	    /// ��������
	    /// </summary>
	    public DateTime CreateTime { get; set; }

	    /// <summary>
	    /// ��Чʱ��
	    /// </summary>
	    public DateTime InvalidTime { get; set; }

	    /// <summary>
	    /// �Ƿ���Ч
	    /// </summary>
	    public bool IsValid { get; set; }

	    /// <summary>
	    /// ��Чʱ��
	    /// </summary>
	    public DateTime EffectTime { get; set; }

	    /// <summary>
	    /// �Ƿ��¼����Ч
	    /// </summary>
	    public bool LoginIsValid { get; set; }

	    /// <summary>
	    /// ��Ȩԭ��
	    /// </summary>
	    public string Reason { get; set; }

	    #endregion

        #region public methods
        /// <summary>
        /// ����
        /// </summary>
        /// <returns>����ֵ</returns>
        public bool Add()
        {
            return new GrantDA().SaveGrants(this);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>�Ƿ���³ɹ�</returns>
        public bool Update()
        {
            return false;
        }
		/// <summary>
		/// �趨��Ȩ����Ч��
		/// </summary>
		/// <param name="pkid">PKID</param>
		/// <param name="isvalid">�Ƿ���Ч</param>
		/// <returns>bool</returns>
        public bool SetEffective(long pkid,bool isvalid)
        {
            return new GrantDA().SetIsValid(pkid,isvalid);
        }

        /// <summary>
        /// ����PKID�õ���Ȩ��Ϣ
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
    /// ��Ȩ����
    /// </summary>
    public class Grants : System.Collections.CollectionBase
    {
        #region constractor
        /// <summary>
        /// ���캯��
        /// ֧��Remoting��Web Service,����ʡ�Թ��캯��
        /// </summary>
        public Grants()
        {}
        #endregion

        #region Collection ����
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="index">������</param>
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
        /// ����һ��
        /// </summary>
        /// <param name="item">��Ȩ��¼ʵ�塣</param>
        public void Add(Grant item)
        {
            List.Add(item);
        }

        /// <summary>
        /// ɾ��һ��
        /// </summary>
        /// <param name="index">������</param>
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
        /// �õ����е���Ȩ��
        /// </summary>
        /// <param name="embracer">��Ȩ�˵�¼����</param>
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
        /// �õ����еĽ�����
        /// </summary>
        /// <param name="grantor">�����ߵ�¼����</param>
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
