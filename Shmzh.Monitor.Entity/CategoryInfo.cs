using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Shmzh.Monitor.Entity
{
    /// <summary>
    /// 类别信息实体。
    /// </summary>
    [Serializable]
    public class CategoryInfo
    {
        private List<CategoryItemInfo> itemList;

        #region Property
        /// <summary>
        /// 类别Id。
        /// </summary>
        [Bindable(true)]
        public int CategoryId { get; set; }

        /// <summary>
        /// 类别名称。
        /// </summary>
        [Bindable(true)]
        public string CategoryName { get; set; }
       
        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(true)]
        public String Remark { get; set; }

        /// <summary>
        /// 类别对应的权限码。
        /// </summary>
        [Bindable(true)]
        public Int16 RightCode { get; set; }

        /// <summary>
        /// 类别列表。
        /// </summary>
        public List<CategoryItemInfo> ItemList
        {
            get
            {
                if (itemList == null)
                    itemList = new List<CategoryItemInfo>();
                return itemList;
            }
            set { itemList = value; }
        }

        /// <summary>
        /// false:仅Administrator可见，true:所有有权限的人可见。
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// 排序号。
        /// </summary>
        public int SerialNumber { get; set; }
        #endregion

        #region CTOR
        public CategoryInfo()
        {
            this.CategoryName = "";
            this.Remark = "";
            this.RightCode = 0;
            this.IsPublic = true;
        }
        #endregion

//        public override string ToString()
//        {
//            return string.Format(System.Globalization.CultureInfo.InvariantCulture,
//                @"{6}:
//- SchemaId: {0}
//- Name: {1}
//- IsValid: {2}
//- Layout: {3}
//- Remark:{4}
//- DataType:{5}
//",
//                this.SchemaId,
//                this.Name,
//                this.IsValid,
//                this.Layout,
//                this.Remark,
//                this.DataType,
//                this.GetType());
//        }
    }

}
