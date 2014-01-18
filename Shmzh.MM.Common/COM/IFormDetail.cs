using System.ComponentModel;

namespace Shmzh.MM.Common
{
    /// <summary>
    /// ����ϸ�ӿڡ�
    /// </summary>
    public interface IFormDetail
    {
        /// <summary>
        /// ������ˮ�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        int EntryNo { get; set; }

        /// <summary>
        /// ������ϸ˳��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        short SerialNo { get; set; }

        /// <summary>
        /// ���ϱ�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string ItemCode { get; set; }

        /// <summary>
        /// �������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string ItemName { get; set; }

        /// <summary>
        /// ����ͺš�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string ItemSpec { get; set; }

        /// <summary>
        /// ��λ
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        short ItemUnit { get; set; }

        /// <summary>
        /// ��λ���ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string ItemUnitName { get; set; }

        /// <summary>
        /// ���ۡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        decimal ItemPrice { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        decimal ItemNum { get; set; }

        /// <summary>
        /// ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        decimal ItemMoney { get; set; }
        
        /// <summary>
        /// ��ע��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Remark { get; set; }
    }
}