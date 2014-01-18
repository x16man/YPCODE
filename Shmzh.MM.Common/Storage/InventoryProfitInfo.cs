using System;
using System.ComponentModel;
using Shmzh.MM.Common;

namespace Shmzh.MM.Common.Storage
{
    public class InventoryProfitInfo:IForm
    {
        #region Implementation of IForm

        /// <summary>
        /// ������ˮ�š�
        /// </summary>
        public int EntryNo { get; set; }

        /// <summary>
        /// ���ݱ�š�
        /// </summary>
        public string EntryCode { get; set; }

        /// <summary>
        /// �������ͱ�š�
        /// </summary>
        public short DocCode { get; set; }

        /// <summary>
        /// �����������ơ�
        /// </summary>
        public string DocName { get; set; }

        /// <summary>
        /// �����ĵ���š�
        /// </summary>
        public string DocNo { get; set; }

        /// <summary>
        /// �������ڡ�
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// ����״̬��
        /// </summary>
        public string EntryState { get; set; }

        /// <summary>
        /// �ύ���ڡ�
        /// </summary>
        public DateTime PresentDate { get; set; }

        /// <summary>
        /// �������ڡ�
        /// </summary>
        public DateTime CancelDate { get; set; }

        /// <summary>
        /// �����ܽ�
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// �Ƶ��˱�š�
        /// </summary>
        public string AuthorCode { get; set; }

        /// <summary>
        /// �Ƶ������ơ�
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// �Ƶ��˵�¼����
        /// </summary>
        public string AuthorLoginId { get; set; }

        /// <summary>
        /// �Ƶ����ű�š�
        /// </summary>
        public string AuthorDept { get; set; }

        /// <summary>
        /// �Ƶ��������ơ�
        /// </summary>
        public string AuthorDeptName { get; set; }

        /// <summary>
        /// һ������
        /// </summary>
        public string Audit1 { get; set; }

        /// <summary>
        /// һ�������ˡ�
        /// </summary>
        public string Assessor1 { get; set; }

        /// <summary>
        /// һ���������ڡ�
        /// </summary>
        public DateTime AuditDate1 { get; set; }

        /// <summary>
        /// һ�����������
        /// </summary>
        public string AuditSuggest1 { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Audit2 { get; set; }

        /// <summary>
        /// ���������ˡ�
        /// </summary>
        public string Assessor2 { get; set; }

        /// <summary>
        /// �����������ڡ�
        /// </summary>
        public DateTime AuditDate2 { get; set; }

        /// <summary>
        /// �������������
        /// </summary>
        public string AuditSuggest2 { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Audit3 { get; set; }

        /// <summary>
        /// ���������ˡ�
        /// </summary>
        public string Assessor3 { get; set; }

        /// <summary>
        /// �����������ڡ�
        /// </summary>
        public DateTime AuditDate3 { get; set; }

        /// <summary>
        /// �������������
        /// </summary>
        public string AuditSuggest3 { get; set; }

        /// <summary>
        /// ��ע��
        /// </summary>
        public string Remark { get; set; }

        #endregion

        #region Property

        /// <summary>
        /// �ֿ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string StoCode { get; set; }

        /// <summary>
        /// �ֿ����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string StoName { get; set; }

        /// <summary>
        /// �����˱�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AcceptCode { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AcceptName { get; set; }

        /// <summary>
        /// �������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime AcceptDate { get; set; }

        /// <summary>
        /// ���ֵ�������Ӧ�����ֵ��ݺš�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ParentEntryNo { get; set; }
        #endregion
    }
}