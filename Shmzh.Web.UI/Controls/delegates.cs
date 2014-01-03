using System;

namespace Shmzh.Web.UI.Controls
{

    /// <summary>
    /// Event handler which submits a clicked toolbar item.
    /// </summary>
    /// <param name="item">The ToolbarItem that triggered the event.</param>
    public delegate void ItemEventHandler(ToolbarItem item);
    /// <summary>
    /// ��ѯ�����ѯ�¼���
    /// </summary>
    /// <param name="sender">������ѯ����Ŀؼ�����</param>
    /// <param name="e">�¼�������</param>
    public delegate void SEQueryEventHandler(object sender, EventArgs e, string sqlStatement);
    /// <summary>
    /// ��ѯ���汣���¼���
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void SESaveEventHandler(object sender, EventArgs e, string sqlStatement);
}
