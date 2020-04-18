using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoStart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AutoStart()
        {
            //获取程序启动执行文件
            string sStartPath = Application.ExecutablePath;
            //获取注册表Current_user行            注册表用win+r regedit 打开
            using (RegistryKey user = Registry.CurrentUser)
            {
                //打开程序自动运行目录
                using (RegistryKey run = user.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
                {
                    //添加自定义项和程序启动执行文件路径. 可以简单参数,如: 路径地址 -参数
                    run.SetValue("TestProg", sStartPath);
                    //释放
                    user.Close();
                }
            }
        }
    }
}
