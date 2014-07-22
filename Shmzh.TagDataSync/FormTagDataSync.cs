using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shmzh.Components.SystemComponent;

namespace Shmzh.TagDataSync
{
    public partial class FormTagDataSync : Form
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Property

        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Gather"].ConnectionString; }
        }
        #endregion
        public FormTagDataSync()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var beginDate = this.dateTimePicker1.Value.Date;
            var endDate = this.dateTimePicker2.Value.Date;

            var tags = this.textBox1.Text.Split(",".ToCharArray());
            while (beginDate <= endDate)
            {
                for (var i = 0; i < tags.Length; i++)
                {
                    var sqlStatement = string.Format("Select I_Action From T_Tag_Gather Where I_Tag_Id='{0}'", tags[i]);
                    var obj = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sqlStatement);
                    if (obj != null)
                    {
                        var action = int.Parse(obj.ToString());
                        int hour;
                        for (hour = 0; hour < 24; hour++)
                        {
                            var cycleTime = beginDate.AddHours(hour);
                            sqlStatement = string.Format(@"
                                            Delete From T_Tag_Hour Where i_tag_id = '{0}' And I_cycle_id = dbo.DateTime2HourCycleId('{1}')
                                            Insert  Into T_Tag_Hour (I_Tag_id,I_Cycle_Id,I_Value_Org,I_Value_Man)
                                            Select  B.I_Tag_Id
                                            ,       dbo.DateTime2HourCycleId(A.[时间])
                                            ,       B.I_PARA_A*A.[值]+B.I_PARA_B,B.I_PARA_A*A.[值]+B.I_PARA_B
                                            From    LINK_3rd.[int].dbo.{3}{2} As A,T_Tag_Gather B
                                            Where   A.[单元名称] = B.I_DESIGN_CD And
                                                    A.[数据名称] = B.I_ADDRESS And
                                                    A.[时间] = '{1}' And
                                                    B.[I_ACTION] = {4} And
                                                    B.I_Tag_Id = '{0}'
                                            ", tags[i], cycleTime, beginDate.ToString("yyyyMMdd"),action==4?"Analog":action==5?"Digital":"Energy",action);
                            Logger.Debug(sqlStatement);
                            SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement);

                        }
                        
                    }
                }
                beginDate = beginDate.AddDays(1);
            }
            MessageBox.Show("Completed!");
        }
    }
}
