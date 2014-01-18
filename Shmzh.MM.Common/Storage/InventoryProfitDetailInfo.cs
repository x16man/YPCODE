using System.ComponentModel;
using Shmzh.MM.Common;

namespace Shmzh.MM.Common.Storage
{
    public class InventoryProfitDetailInfo:IFormDetail
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
        /// �ֿ���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string StoCode { get; set; }

        /// <summary>
        /// �ֿ����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string StoName { get; set; }

        /// <summary>
        /// ��λId��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ConCode { get; set; }

        /// <summary>
        /// ��λ���ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ConName { get; set; }

        /// <summary>
        /// ���Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal StkId { get; set; }

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