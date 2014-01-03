using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Shmzh.Gather.Data.Model
{
    /// <summary>
    /// 本地指标与第三方采集系统中指标的对应关系类。
    /// </summary>
    public class TagSqlMapInfo
    {
        #region property
        /// <summary>
        /// 本地的指标ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagId { get; set; }

        /// <summary>
        /// 指标名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Unit { get; set; }

        /// <summary>
        /// 保留小数点位数。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short DigNum { get; set; }

        /// <summary>
        /// 本地指标类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagType { get; set; }

        /// <summary>
        /// 第三方指标的单元名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagUnitName { get; set; }
        /// <summary>
        /// 第三方的指标的数据名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagSqlName { get; set; }

        /// <summary>
        /// 第三方的指标类型：1：模拟量，2：数字量，3：开关量
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagSqlType { get; set; }

        /// <summary>
        /// 指标位置。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TagLocation { get; set; }
        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool Enabled { get; set; }

        #endregion

        public override bool Equals(object obj)
        {
            //var target = obj as TagSqlMapInfo;
            //if (target == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return this.TagId.Equals(target.TagId) &&
            //        this.TagSqlName.Equals(target.TagSqlName) &&
            //        this.TagSqlType.Equals(target.TagSqlType) &&
            //        this.TagLocation.Equals(target.TagLocation) &&
            //        this.Enabled.Equals(target.Enabled);
            //}
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}",this.TagId,this.TagSqlName,this.TagSqlType,this.TagLocation,this.Enabled).GetHashCode();
        }
    }
}
