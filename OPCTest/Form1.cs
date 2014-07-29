using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using RsiOPCAuto;
using OPCAutomation;
using Timer=System.Timers.Timer;

namespace OPCTest
{
    public partial class Form1 : Form
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private RsiOPCAuto.OPCServer MyOPCServer;
        private RsiOPCAuto.OPCGroup MyOPCGroup;
        private OPCAutomation.OPCServer KEPOPCServer;
        private OPCAutomation.OPCGroup KEPOPCGroup;

        private int _Count;
        private System.Timers.Timer MyTimer = new System.Timers.Timer();
        #endregion


        #region Property
        /// <summary>
        /// OPC Server 的IP地址。
        /// </summary>
        public string NodeIP
        {
            get { return this.textBox_NodeIP.Text; }
        }

        public string KEP_NodeIP
        {
            get { return this.txtKEPNodeIP.Text; }
        }
        /// <summary>
        /// OPC Server 应用程序ID。
        /// </summary>
        public string ProgID
        {
            get { return this.textBox_ProgID.Text; }
        }

        public string KEP_ProgID
        {
            get { return this.txtKEPProgID.Text; }
        }
        /// <summary>
        /// OPC Group.
        /// </summary>
        public string OPCGroup
        {
            get { return this.textBox_OPCGroup.Text; }
        }

        public string KEP_OPCGroup
        {
            get { return this.txtKEPOPCGroup.Text; }
        }
        public string Address
        {
            get { return this.textBox_Address.Text; }
        }

        public string KEP_Address
        {
            get { return this.txtKEPAddress.Text; }
        }
        #endregion

        #region private method
        /// <summary>
        /// 加载配置。
        /// </summary>
        private void LoadConfig()
        {
            this.textBox_NodeIP.Text = ConfigurationManager.AppSettings["NodeIP"];
            this.textBox_OPCGroup.Text = ConfigurationManager.AppSettings["OPCGroup"];
            this.textBox_ProgID.Text = ConfigurationManager.AppSettings["ProgID"];
            this.textBox_Address.Text = ConfigurationManager.AppSettings["Topic"];

            this.txtKEPNodeIP.Text = ConfigurationManager.AppSettings["KEP_NodeIP"];
            this.txtKEPProgID.Text = ConfigurationManager.AppSettings["KEP_ProgID"];
            this.txtKEPOPCGroup.Text = ConfigurationManager.AppSettings["KEP_OPCGroup"];
            this.txtKEPAddress.Text = ConfigurationManager.AppSettings["KEP_Address"];
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
            this.button_Disconnect.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadConfig();
            this.MyOPCServer = new RsiOPCAuto.OPCServer();
            this.KEPOPCServer = new OPCAutomation.OPCServer();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                this.MyOPCServer.Connect(this.ProgID, this.NodeIP);
                MessageBox.Show("Connected.");
                this.button_Connect.Enabled = false;
                this.button_Disconnect.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect Failed.");
                Logger.Error(ex.Message,ex);
                return;
            }

            try
            {
                MyOPCGroup = this.MyOPCServer.OPCGroups.Add(this.OPCGroup);
                MyOPCGroup.IsActive = true;
                MyOPCGroup.IsSubscribed = true;
                MyOPCGroup.UpdateRate = 1000;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);                
            }

            
            //for(var i=0;i<50;i++)
            //{
            //    var address = string.Format("[{0}]NN[{1}]", this.Topic, i);
            //    try
            //    {
            //        if(this.MyOPCGroup.OPCItems.Item(address) == null)
            //        {
            //            //
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        this.MyOPCGroup.OPCItems.AddItem(address, 1);
            //    }
            //}
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            this.MyOPCServer.Disconnect();
            this.button_Connect.Enabled = true;
            this.button_Disconnect.Enabled = false;
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            Logger.Debug(this.Address);
            try
            {
                
                if(this.MyOPCGroup.OPCItems.Item(this.Address) == null)
                {
                    try
                    {
                        this.MyOPCGroup.OPCItems.AddItem(this.Address, 1);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message,ex);
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    this.MyOPCGroup.OPCItems.AddItem(this.Address, 1);
                }
                catch (Exception exx)
                {
                    Logger.Error(exx.Message,exx);
                    MessageBox.Show(exx.Message);
                }
                Logger.Error(ex.Message,ex);
            }
            var opcItem = this.MyOPCGroup.OPCItems.Item(this.Address);
            if(opcItem == null)
            {
                MessageBox.Show("OPCItem is Null");
            }
            else
            {
                var obj = opcItem.Value;
    
                if(obj == null)
                {
                    MessageBox.Show("return value is null.");
                }
                else
                {
                    this.textBox_ReadValue.Text = obj.ToString();
                }
            }
        }

        private void button_Write_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.MyOPCGroup.OPCItems.Item(this.Address) == null)
                {
                    try
                    {
                        this.MyOPCGroup.OPCItems.AddItem(this.Address, 1);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    this.MyOPCGroup.OPCItems.AddItem(this.Address, 1);
                }
                catch (Exception exx)
                {
                    Logger.Error(exx.Message,ex);
                    MessageBox.Show(exx.Message);
                    return;
                }
                Logger.Error(ex.Message,ex);
            }
            var opcItem = this.MyOPCGroup.OPCItems.Item(this.Address);
            if (opcItem == null)
            {
                MessageBox.Show("OPCItem is Null");
            }
            else
            {
                try
                {
                    opcItem.Write(this.textBox_WriteValue.Text);
                    MessageBox.Show("Write ok");
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message,ex);
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void button_BatchWrite_Click(object sender, EventArgs e)
        {
            
            this.MyTimer.Interval = 1000;
            this.MyTimer.Elapsed += new System.Timers.ElapsedEventHandler(MyTimer_Elapsed);
            this.MyTimer.Enabled = true;
        }

        void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //if(this._Count < 3000)
            //{
            //    for (var m = 0; m < this.MyOPCGroup.OPCItems.Count;m++ )
            //    {
            //        this.MyOPCGroup.OPCItems.Item(string.Format("[{0}]NN[{1}]",this.Topic,m)).Write(_Count);
            //    }
            //    this._Count++;
            //}
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            this.MyTimer.Enabled = false;
        }

        private void btnKEPConnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.KEPOPCServer.Connect(this.KEP_ProgID, this.KEP_NodeIP);
                MessageBox.Show("KEP OPC Server Connnected");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                MessageBox.Show("KEP OPC Server Connect failed");
            }
        }

        


    }
}
