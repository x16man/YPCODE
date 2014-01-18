using System;
using System.ComponentModel;

namespace Shmzh.MM.Common
{
    /// <summary>
    /// ���ӿڡ�
    /// </summary>
    public interface IForm
    {
        /// <summary>
        /// ������ˮ�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        int EntryNo { get; set; }

        /// <summary>
        /// ���ݱ�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string EntryCode { get; set; }

        /// <summary>
        /// �������ͱ�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        short DocCode { get; set; }

        /// <summary>
        /// �����������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string DocName { get; set; }

        /// <summary>
        /// �����ĵ���š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string DocNo { get; set; }

        /// <summary>
        /// �������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime EntryDate { get; set; }

        /// <summary>
        /// ����״̬��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string EntryState { get; set; }

        /// <summary>
        /// �ύ���ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime PresentDate { get; set; }

        /// <summary>
        /// �������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime CancelDate { get; set; }

        /// <summary>
        /// �����ܽ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        decimal SubTotal { get; set; }

        /// <summary>
        /// �Ƶ��˱�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorCode { get; set; }

        /// <summary>
        /// �Ƶ������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorName { get; set; }

        /// <summary>
        /// �Ƶ��˵�¼����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorLoginId { get; set; }

        /// <summary>
        /// �Ƶ����ű�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorDept { get; set; }

        /// <summary>
        /// �Ƶ��������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuthorDeptName { get; set; }

        /// <summary>
        /// һ������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Audit1 { get; set; }

        /// <summary>
        /// һ�������ˡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Assessor1 { get; set; }

        /// <summary>
        /// һ���������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime AuditDate1 { get; set; }

        /// <summary>
        /// һ�����������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuditSuggest1 { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Audit2 { get; set; }

        /// <summary>
        /// ���������ˡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Assessor2 { get; set; }

        /// <summary>
        /// �����������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime AuditDate2 { get; set; }

        /// <summary>
        /// �������������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuditSuggest2 { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Audit3 { get; set; }

        /// <summary>
        /// ���������ˡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Assessor3 { get; set; }

        /// <summary>
        /// �����������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        DateTime AuditDate3 { get; set; }

        /// <summary>
        /// �������������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string AuditSuggest3 { get; set; }
        
        /// <summary>
        /// ��ע��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        string Remark { get; set; } 
    }
}