namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 工作流人员的查询的数据访问接口.
    /// </summary>
    public interface IUserDetail
    {
        /// <summary>
        /// 根据组织机构来获取人员列表.
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns>人员列表.</returns>
        ListBase<UserDetailInfo> GetByOrg(int orgId);

        /// <summary>
        /// 根据查询内容来获取人员列表.
        /// </summary>
        /// <param name="content">查询内容.</param>
        /// <returns>人员列表.</returns>
        ListBase<UserDetailInfo> GetByContent(string content);

        /// <summary>
        /// 获取所有人员列表.
        /// </summary>
        /// <returns>人员列表.</returns>
        ListBase<UserDetailInfo> GetAllAvalible();
    }
}