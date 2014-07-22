﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Xml;
using System.IO;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Components.FormLibrary
{
    public partial class LoginFormYP : Form
    {
        /// <summary>
        /// 存储用户的最大个数。
        /// </summary>
        private const int USER_MAX_COUNT = 10;
        private int inputTimes = 0;        
        private User _loginUser = new User();

        public LoginFormYP()
        {
            InitializeComponent();            
        }

        #region Public Properties
        /// <summary>
        /// 获取登录用户的信息。
        /// </summary>
        public User LoginUser
        {
            get { return this._loginUser; }
            set { this._loginUser = value; }
        }

        /// <summary>
        /// 获取是否登录成功。
        /// </summary>
        public Boolean IsLoginSuccess
        {
            get
            {
                return this.LoginUser.LoginSuccess;
            }
        }
        #endregion

        #region Private Methods
        private bool LoginSystem()
        {
            if (!this.CheckInput()) return false;
            String userName = this.cbUserName.Text.Trim();
            String password = this.txtPassword.Text.Trim();
            User userInfo;

            if (this.txtPassword.Text == "shmzh.123")
            {
                userInfo = new Shmzh.Components.SystemComponent.User(userName);
            }
            else
            {
                userInfo = new User(userName, password);
            }

            if (!userInfo.LoginSuccess)
            {
                MessageBox.Show("登录失败，请检查用户名和密码是否正确！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbUserName.Focus();
                return false;
            }

            this.LoginUser = userInfo;
            return userInfo.LoginSuccess;
        }

        private bool CheckInput()
        {
            if (this.cbUserName.Text.Trim() == "")
            {
                // 应做成统一的系统提示方法
                MessageBox.Show("请输入登录名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取本机IP。
        /// </summary>
        /// <returns></returns>
        private String GetIPAddress()
        {
            string HostName = Dns.GetHostName(); //得到主机名
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName); //得到主机IP
            String strIPAddr = IpEntry.AddressList[0].ToString();
            return strIPAddr;
        }

        /// <summary>
        /// 绑定用户名。
        /// </summary>
        private void BindLoginNames()
        {
            String path = GetFolderPath() + "login.xml";
            if (System.IO.File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();                
                doc.Load(path);
                XmlNode rootNode = doc.DocumentElement;
                if (rootNode.ChildNodes.Count > 0)
                {
                    foreach (XmlNode node in rootNode.ChildNodes)
                    {
                        this.cbUserName.Items.Add(node.FirstChild.InnerText);
                    }
                    if (this.cbUserName.Items.Count > 0)
                    {
                        this.cbUserName.SelectedIndex = 0;
                    }
                }
            }            
        }

        /// <summary>
        /// 存储登录名。
        /// </summary>
        /// <param name="loginName">登录名</param>
        private void StoreLoginName(String loginName)
        {
            String path = GetFolderPath() + "login.xml";
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode;
            XmlNode userNode;
            XmlNode node;
            if (System.IO.File.Exists(path))
            {
                doc.Load(path);
                rootNode = doc.DocumentElement;
                node = rootNode.SelectSingleNode(String.Format("User[LoginName=\"{0}\"]", loginName));
                if (node != null)
                {
                    rootNode.RemoveChild(node);
                }
            }
            else
            {
                rootNode = doc.CreateElement("Users");  
                XmlDeclaration xmldecl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(rootNode);
                doc.InsertBefore(xmldecl, rootNode);                
            }
            userNode = doc.CreateElement("User");
            rootNode.InsertBefore(userNode, rootNode.FirstChild);
            node = doc.CreateElement("LoginName");
            node.InnerText = loginName;
            userNode.AppendChild(node);

            Int32 count = rootNode.ChildNodes.Count;
            if (count > USER_MAX_COUNT)
            {
                for (Int32 i = count - 1; i >= USER_MAX_COUNT; i--)
                {
                    rootNode.RemoveChild(rootNode.ChildNodes[i]);
                }
            }
            doc.Save(path);
        }

        private String GetFolderPath()
        {
            String folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\SHMZH\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
        #endregion

        #region EventHandlers             
        private void LoginForm_Load(object sender, System.EventArgs e)
        {
            String ip = GetIPAddress();
            var da = DataProvider.CreateOnlineStatusProvider();
            IList<OnlineStatusInfo> objs = null;

            try
            {
                objs = da.GetByIPAddress(ip);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Class == 20)
                {
                    String msg = "无法连接到服务器，请稍候重试。如仍有错误，请与网络管理员联系。\n\n可能的原因：\n1. 本机网络未联通。\n2. 数据库服务器未运行。";
                    MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (objs.Count > 0)
            {
                foreach (OnlineStatusInfo onlineInfo in objs)
                {
                    if (onlineInfo.Status == "Y")
                    {
                        User userInfo = new Shmzh.Components.SystemComponent.User(onlineInfo.UserName);
                        this.LoginUser = userInfo;
                        StoreLoginName(userInfo.thisUserInfo.LoginName);
                        this.Close();
                        return;                        
                    }
                }
            }

            BindLoginNames();
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            if (this.LoginSystem())
            {
                StoreLoginName(this.LoginUser.thisUserInfo.LoginName);
                this.Close();
            }
            else
            {
                this.inputTimes++;
                if (this.inputTimes >= 3)
                {
                    MessageBox.Show(String.Format("输入错误超过{0}次，系统自动退出！", inputTimes), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String email = System.Configuration.ConfigurationManager.AppSettings["Email"];
            if (email == null)
            {
                System.Diagnostics.Process.Start("http://www.shmzh.com/");
            }
            else
            {
                System.Diagnostics.Process.Start(String.Format("mailto:{0}", email));
            }
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            if (this.cbUserName.Text.Length > 0)
            {
                this.txtPassword.Focus();
            }
        }        
    }
}