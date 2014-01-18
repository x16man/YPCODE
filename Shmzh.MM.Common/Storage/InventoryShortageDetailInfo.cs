using System.ComponentModel;
using Shmzh.MM.Common;

namespace Shmzh.MM.Common.Storage
{
    public class InventoryShortageDetailInfo:IFormDetail
    {
        #region Implementation of IFormDetail

        /// <summary>
        /// ������ˮ�š�
        /// </summary>
        public int EntryNo { get; set; }

        /// <summary>
        /// ������ϸ˳��š�
        /// </summary>
        public short SerialNo { get; set; }

        /// <summary>
        /// ���ϱ�š�
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// �������ơ�
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// ����ͺš�
        /// </summary>
        public string ItemSpec { get; set; }

        /// <summary>
        /// ��λ
        /// </summary>
        public short ItemUnit { get; set; }

        /// <summary>
        /// ��λ���ơ�
        /// </summary>
        public string ItemUnitName { get; set; }

        /// <summary>
        /// ���ۡ�
        /// </summary>
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public decimal ItemNum { get; set; }

        /// <summary>
        /// ��
        /// </summary>
        public decimal ItemMoney { get; set; }

        /// <summary>
        /// ��ע��
        /// </summary>
        public string Remark { get; set; }

        #endregion

        #region Property
        /// <summary>
        /// ��ǰ��档
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal CurrentStockNum { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal CarryingAmount { get; set; }

        /// <summary>
        /// �̵�������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal InventoryAmount { get; set; }
        #endregion
    }
}