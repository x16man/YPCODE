using System;

namespace Shmzh.Web.UI.Controls
{

    /// <summary>
    /// Event handler which submits a clicked toolbar item.
    /// </summary>
    /// <param name="item">The ToolbarItem that triggered the event.</param>
    public delegate void ItemEventHandler(ToolbarItem item);
    /// <summary>
    /// 查询引擎查询事件。
    /// </summary>
    /// <param name="sender">触发查询引擎的控件对象。</param>
    /// <param name="e">事件参数。</param>
    public delegate void SEQueryEventHandler(object sender, EventArgs e, string sqlStatement);
    /// <summary>
    /// 查询引擎保存事件。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void SESaveEventHandler(object sender, EventArgs e, string sqlStatement);
}
