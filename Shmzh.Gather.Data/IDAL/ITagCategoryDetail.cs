using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    public interface ITagCategoryDetail
    {
        /// <summary>
        /// ���ָ����ָ������ϵ��
        /// </summary>
        /// <param name="obj">ָ����ָ������ϵʵ�塣</param>
        /// <returns>bool</returns>
        bool Insert(TagCategoryDetailInfo obj);

        /// <summary>
        /// ɾ��ָ����ָ������ϵʵ�塣
        /// </summary>
        /// <param name="obj">ָ����ָ������ϵʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(TagCategoryDetailInfo obj);

        /// <summary>
        /// ��ȡ����ָ����ָ������ϵ�弯�ϡ�
        /// </summary>
        /// <returns>ָ����ָ������ϵ�弯�ϡ�</returns>
        List<TagCategoryDetailInfo> GetAll();

        /// <summary>
        /// ����ָ�����Id��ȡָ����ָ������ϵ�弯�ϡ�
        /// </summary>
        /// <param name="categoryId">ָ�����Id��</param>
        /// <returns>ָ����ָ������ϵ�弯�ϡ�</returns>
        List<TagCategoryDetailInfo> GetByCategoryId(int categoryId);

    }
}