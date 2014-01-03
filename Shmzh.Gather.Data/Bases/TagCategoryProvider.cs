using System;
using System.Collections.Generic;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.Bases
{
    /// <summary>
    /// ָ�����ĳ������ݷ����ࡣ
    /// </summary>
    public abstract class TagCategoryProvider:IDAL.ITagCategory
    {
        #region Implementation of ITagCategory

        /// <summary>
        /// ���ָ����ࡣ
        /// </summary>
        /// <param name="obj">ָ�����ʵ�塣</param>
        /// <returns>ָ�����Id��</returns>
        public abstract int Insert(TagCategoryInfo obj);

        /// <summary>
        /// ����ָ����ࡣ
        /// </summary>
        /// <param name="obj">ָ�����ʵ�塣</param>
        /// <returns>bool</returns>
        public abstract bool Update(TagCategoryInfo obj);

        /// <summary>
        /// ɾ��ָ����ࡣ
        /// </summary>
        /// <param name="obj">ָ�����ʵ�塣</param>
        /// <returns>bool</returns>
        public abstract bool Delete(TagCategoryInfo obj);

        /// <summary>
        /// ɾ��ָ����ࡣ
        /// </summary>
        /// <param name="id">ָ�����Id��</param>
        /// <returns>bool</returns>
        public abstract bool Delete(int id);

        /// <summary>
        /// ��ȡ���е�ָ����ࡣ
        /// </summary>
        /// <returns>ָ�����ļ��ϡ�</returns>
        public abstract List<TagCategoryInfo> GetAll();

        /// <summary>
        /// �����ϼ�����Id��ȡָ����ࡣ
        /// </summary>
        /// <param name="parentId">�ϼ�����Id��</param>
        /// <returns>ָ�����ļ��ϡ�</returns>
        public abstract List<TagCategoryInfo> GetByParentId(int parentId);

        /// <summary>
        /// ����ָ�����Id��ȡָ����ࡣ
        /// </summary>
        /// <param name="id">ָ�����Id��</param>
        /// <returns>ָ�����ʵ�塣</returns>
        public abstract TagCategoryInfo GetById(int id);

        #endregion
    }
}