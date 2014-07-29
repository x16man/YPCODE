using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace Shmzh.Windows.Forms
{
    public class MzhCheckBoxCollection : CollectionBase
    {
       

        public MzhCheckBoxCollection()
        {
            IList pIList = base.List;
        }


        public CheckBox this[int index]
        {
            get
            {
                return (CheckBox)List[index];
            }
        }

        public CheckBox Add(CheckBox obj)
        {
            base.List.Add(obj);
            return obj;
        }

        public void Remove(CheckBox obj) 
        { 
            base.List.Remove(obj); 
        } 
        
    
    }

    public class MzhCheckBoxList
    {
        private MzhCheckBoxCollection objCbc = new MzhCheckBoxCollection();

        public event System.EventHandler CheckedChanged;

        /*
        /// <summary> 
        /// 新增一个CheckBox到控件 
        /// </summary> 
        /// <returns></returns> 
        public CheckBox NewCheckBox()
        {
            lab.Visible = false;
            CheckBox cb = new CheckBox();
            cb.Name = GetName();
            cb.Text = cb.Name;
            // cb.Size=new Size(120,24); 
            cb.Checked = false;
            cb.Visible = true;
            cb.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);//定义CheckedChanged事件,来捕捉它的事件 
            int y = 0;
            y = objCbc.Count * 24 + objCbc.Count * 8 + 12;//形成CheckBox的纵坐标 
            cb.Location = new Point(12, y);
            objCbc.Add(cb);

            this.Controls.Add(cb);//添加CheckBox到控件 

            int x = GetMaxWidth();//得到已经添加的CheckBox中的最大的宽度 

            if (cb.Width > x)//如果现在添加的CheckBox的最大宽度大于已经添加的最大宽度,替换调x 
            {
                x = cb.Width + 24;
            }

            this.Size = new Size(x, y + 12 + 24);//根据添加的CheckBox改变控件的大小 

            return cb;
        }


        /// <summary> 
        /// 判断是否是阿拉伯数字 
        /// </summary> 
        /// <param name="strCompare"></param> 
        /// <returns></returns> 
        private bool IsNumber(string strCompare)
        {
            string strWord = "0123456789";
            foreach (char chr in strWord)
            {
                if (strCompare == chr.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(sender, new EventArgs());
        }

        /// <summary> 
        /// 得到已经添加CheckBox中的最大宽度 
        /// </summary> 
        /// <returns></returns> 
        private int GetMaxWidth()
        {
            int maxWidth = 0;
            if (objCbc.Count > 0)
            {
                for (int i = 0; i < objCbc.Count; i++)
                {
                    CheckBox cb = (CheckBox)objCbc[i];
                    if (cb.Width > maxWidth)
                    {
                        maxWidth = cb.Width;
                    }
                }
            }
            return maxWidth;
        }

        /// <summary> 
        /// 自动形成新添加CheckBox的名称 
        /// </summary> 
        /// <returns></returns> 
        private string GetName()
        {
            if (objCbc.Count > 0)
            {
                ArrayList list = new ArrayList();
                for (int i = 0; i < objCbc.Count; i++)
                {
                    if (objCbc[i].Name.Trim().Length == 9)
                    {
                        string str = objCbc[i].Name.Trim();
                        if (str.Substring(0, 8).ToLower() == "checkbox" && IsNumber(str.Substring(str.Length - 1, 1)))
                        {
                            list.Add(str.Substring(str.Length - 1, 1));
                        }
                    }
                }
                if (list.Count > 0)
                {
                    return "checkBox" + Convert.ToString(int.Parse(list[list.Count - 1].ToString().Trim()) + 1);
                }
            }

            return "checkBox1";
        }*/
    }
}
