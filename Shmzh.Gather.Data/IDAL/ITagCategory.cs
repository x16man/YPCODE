using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.IDAL
{
    /// <summary>
    /// ָ���������ݷ��ʽӿڡ�
    /// </summary>
    public interface ITagCategory
    {
        /// <summary>
        /// ���ָ����ࡣ
        /// </summary>
        /// <param name="obj">ָ�����ʵ�塣</param>
        /// <returns>ָ�����Id��</returns>
        int Insert(TagCategoryInfo obj);

        /// <summary>
        /// ����ָ����ࡣ
        /// </summary>
        /// <param name="obj">ָ�����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Update(TagCategoryInfo obj);

        /// <summary>
        /// ɾ��ָ����ࡣ
        /// </summary>
        /// <param name="obj">ָ�����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(TagCategoryInfo obj);

        /// <summary>
        /// ɾ��ָ����ࡣ
        /// </summary>
        /// <param name="id">ָ�����Id��</param>
        /// <returns>bool</returns>
        bool Delete(int id);

        /// <summary>
        /// ��ȡ���е�ָ����ࡣ
        /// </summary>
        /// <returns>ָ�����ļ��ϡ�</returns>
        List<TagCategoryInfo> GetAll();

        /// <summary>
        /// �����ϼ�����Id��ȡָ����ࡣ
        /// </summary>
        /// <param name="parentId">�ϼ�����Id��</param>
        /// <returns>ָ�����ļ��ϡ�</returns>
        List<TagCategoryInfo> GetByParentId(int parentId);

        /// <summary>
        /// ����ָ�����Id��ȡָ����ࡣ
        /// </summary>
        /// <param name="id">ָ�����Id��</param>
        /// <returns>ָ�����ʵ�塣</returns>
        TagCategoryInfo GetById(int id);

    }
}