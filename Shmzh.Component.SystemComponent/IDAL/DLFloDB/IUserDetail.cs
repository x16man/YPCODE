namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// ��������Ա�Ĳ�ѯ�����ݷ��ʽӿ�.
    /// </summary>
    public interface IUserDetail
    {
        /// <summary>
        /// ������֯��������ȡ��Ա�б�.
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns>��Ա�б�.</returns>
        ListBase<UserDetailInfo> GetByOrg(int orgId);

        /// <summary>
        /// ���ݲ�ѯ��������ȡ��Ա�б�.
        /// </summary>
        /// <param name="content">��ѯ����.</param>
        /// <returns>��Ա�б�.</returns>
        ListBase<UserDetailInfo> GetByContent(string content);

        /// <summary>
        /// ��ȡ������Ա�б�.
        /// </summary>
        /// <returns>��Ա�б�.</returns>
        ListBase<UserDetailInfo> GetAllAvalible();
    }
}