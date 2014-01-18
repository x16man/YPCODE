//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	/// <summary>
	/// DeptData 是部门表的数据实体层，负责创建一个DEPT的数据集。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PPRNData : DataSet
	{
		//数据输入检验报错信息。
		public const string NO_OBJECT = "没有供应商/客户数据对象！";
		public const string NO_ROW = "没有供应商/客户数据行！";
		public const string CODE_LABEL = "编号";
		public const string CNNAME_LABEL = "中文名称";
		public const string ENNAME_LABEL = "英文名称";
		public const string TYPE_LABEL = "类别";
		public const string STATUS_LABEL = "状态";
		public const string APPROVE_LABEL = " 已核准";
		public const string CURRENCY_LABEL = "货币代码";
		public const string PAYSTYLE_LABEL = "付款方式";
		public const string TEL_LABEL = "电话";
		public const string FAX_LABEL = "传真";
		public const string EMAIL_LABEL = "E-MAIL";
		public const string LINKMAN_LABEL = "联系人";
		public const string LINKTEL_LABEL = "联系人电话";
		public const string LINKMAIL_LABEL = "联系人E-MAIL";
		public const string ACCLINK_LABEL = "会计联系人";
		public const string ACCLINKTEL_LABEL = "会计联系人电话";
		public const string ADDRESS_LABEL = "地址";
		public const string ZIP_LABEL = "邮编";
		public const string LICENCE_LABEL = "营业执照号";
		public const string REGMONEY_LABEL = "注册资金";
		public const string TURNOVER_LABEL = "年营业额";
		public const string DEPUTY_LABEL = "法人代表";
		public const string BANK_LABEL = "开户银行";
		public const string ACCOUNT_LABEL = "账户";
		public const string TAXNO_LABEL = "税务登记号";
		public const string COUNTRY_LABEL = "国家";
		public const string STATE_LABEL = "省";
		public const string CITY_LABEL = "城市";
		public const string PURCHASEACC_LABEL = "采购账户";
		public const string APACC_LABEL = "应付账户";
		public const string REMARK_LABEL = "备注";
		
		//唯一性检验报错信息。
		public const string CODE_NOT_UNIQUE = "供应商/客户编号不唯一！";
		public const string CNNAME_NOT_UNIQUE = "供应商/客户中文名称不唯一！";
		public const string ENNAME_NOT_UNIQUE = "供应商/客户英文名称不唯一！";
		public const string OTA_NOT_UNIQUE = "系统已经有一个OTA类型供应商！";
		//存储过程执行情况反馈信息。
		public const string QUERY_FAILED = "检索供应商/客户数据失败！";
		public const string ADD_FAILED = "添加供应商/客户数据失败！";
		public const string ADD_SUCCESSED = "添加供应商/客户数据成功！";
		public const string UPDATE_FAILED = "更改供应商/客户数据失败！";
		public const string UPDATE_SUCCESSED = "更改供应商/客户数据成功！";
		public const string DELETE_FAILED = "删除供应商/客户数据失败！";
		public const string DELETE_SUCCESSED = "删除供应商/客户数据成功！";
		//表结构。
		public const string PPRN_TABLE = "PPRN";//供应商/客户表名.
		public const string OLDCODE_FIELD = "OLDCODE";//供应商/客户旧编号。
		public const string CODE_FIELD = "CODE";//供应商/客户编号。
		public const string CNNAME_FIELD = "CNNAME";//供应商/客户中文名称。
		public const string ENNAME_FIELD = "ENNAME";//供应商/客户英文名称。
		public const string TYPE_FIELD = "TYPE";//供应商/客户类别。
		public const string STATUS_FIELD = "STATUS";//供应商/客户状态。
		public const string APPROVE_FIELD = "APPROVE";//供应商/客户 已核准。
		public const string CURRENCY_FIELD = "CURRENCY";//供应商/客户 货币代码。
		public const string PAYSTYLE_FIELD = "PAYSTYLE";//供应商/客户 付款类型。
		public const string TEL_FIELD = "TEL";//供应商/客户 电话。
		public const string FAX_FIELD = "FAX";//供应商/客户 传真。
        public const string EMAIL_FIELD = "EMAIL";//供应商/客户 EMAIL。
		public const string LINKMAN_FIELD = "LINKMAN";//供应商/客户 联系人。
		public const string LINKTEL_FIELD = "LINKTEL";//供应商/客户 联系人电话。
		public const string LINKMAIL_FIELD = "LINKMAIL";//供应商/客户 联系人EMAIL。
		public const string ACCLINK_FIELD = "ACCLINK";//供应商/客户 会计联系人。
		public const string ACCLINKTEL_FIELD = "ACCLINKTEL";//供应商/客户 会计联系人电话。
		public const string ADDRESS_FIELD = "ADDRESS";//供应商/客户 地址。
		public const string ZIP_FIELD = "ZIP";//供应商/客户 邮编。
		public const string LICENCE_FIELD = "LICENCE";//供应商/客户 营业执照号码。
		public const string REGMONEY_FIELD = "REGMONEY";//供应商/客户 注册资金。
		public const string TURNOVER_FIELD = "TURNOVER";//供应商/客户 年营业额。
		public const string DEPUTY_FIELD = "DEPUTY";//供应商/客户 法人代表。
		public const string BANK_FIELD = "BANK";//供应商/客户 开户银行。
		public const string ACCOUNT_FIELD = "ACCOUNT";////供应商/客户 账户。
		public const string TAXNO_FIELD = "TAXNO";//供应商/客户 税务登记号。
		public const string COUNTRY_FIELD = "COUNTRY";//供应商/客户 国家。
		public const string STATE_FIELD = "STATE";//供应商/客户 省。
		public const string CITY_FIELD = "CITY";//供应商/客户 城市。
		public const string PURCHASEACC_FIELD = "PURCHASEACC";//供应商/客户 采购账户。
		public const string APACC_FIELD = "APACC";//供应商/客户 应付账户。
		public const string REMARK_FIELD = "REMARK";//供应商/客户 备注。
		public const string CatCode_Field = "CatCode";//供应商分类
		public const string CatName_Field = "CatName";//供应商分类名称 
		/// <summary>
		/// DeptData类的构造函数，new一个DeptData类的时候，就创建一个数据集。
		/// </summary>
		public PPRNData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private PPRNData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 创建与数据库中DEPT表对应的一个DataTable。
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　DEPT 表．
			DataTable table   = new DataTable(PPRN_TABLE);
			//添加字段。
			table.Columns.Add(OLDCODE_FIELD, typeof(System.String));
			table.Columns.Add(CODE_FIELD, typeof(System.String));
			table.Columns.Add(CNNAME_FIELD, typeof(System.String));
			table.Columns.Add(ENNAME_FIELD, typeof(System.String));
			table.Columns.Add(TYPE_FIELD, typeof(System.String));
			table.Columns.Add(STATUS_FIELD, typeof(System.String));
			table.Columns.Add(APPROVE_FIELD, typeof(System.String));
			table.Columns.Add(CURRENCY_FIELD, typeof(System.String));
			table.Columns.Add(PAYSTYLE_FIELD, typeof(System.String));
			table.Columns.Add(TEL_FIELD, typeof(System.String));
			table.Columns.Add(FAX_FIELD, typeof(System.String));
			table.Columns.Add(EMAIL_FIELD, typeof(System.String));
			table.Columns.Add(LINKMAN_FIELD, typeof(System.String));
			table.Columns.Add(LINKTEL_FIELD, typeof(System.String));
			table.Columns.Add(LINKMAIL_FIELD, typeof(System.String));
			table.Columns.Add(ACCLINK_FIELD, typeof(System.String));
			table.Columns.Add(ACCLINKTEL_FIELD, typeof(System.String));
			table.Columns.Add(ADDRESS_FIELD, typeof(System.String));
			table.Columns.Add(ZIP_FIELD, typeof(System.String));
			table.Columns.Add(LICENCE_FIELD, typeof(System.String));
			table.Columns.Add(REGMONEY_FIELD, typeof(System.String));
			table.Columns.Add(TURNOVER_FIELD, typeof(System.String));
			table.Columns.Add(DEPUTY_FIELD, typeof(System.String));
			table.Columns.Add(BANK_FIELD, typeof(System.String));
			table.Columns.Add(ACCOUNT_FIELD, typeof(System.String));
			table.Columns.Add(TAXNO_FIELD, typeof(System.String));
			table.Columns.Add(COUNTRY_FIELD, typeof(System.String));
			table.Columns.Add(STATE_FIELD, typeof(System.String));
			table.Columns.Add(CITY_FIELD, typeof(System.String));
			table.Columns.Add(PURCHASEACC_FIELD, typeof(System.String));
			table.Columns.Add(APACC_FIELD, typeof(System.String));
			table.Columns.Add(REMARK_FIELD, typeof(System.String));
			table.Columns.Add(CatCode_Field, typeof(System.Int32));
			table.Columns.Add(CatName_Field, typeof(System.String));
			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
	}
}
