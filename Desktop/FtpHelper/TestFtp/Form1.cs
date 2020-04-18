using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFtp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            btnUpLoad.Click += BtnUpLoad_Click;
        }

        private void BtnUpLoad_Click(object sender , EventArgs e)
        {
            string aaa = @"C:\Users\Administrator\Desktop"; //\yubaolee-OpenAuth.Net-4.0.zip";
            string sdele = @"新建文本文档.txt";
            FTPHelper.Instance.Download(aaa , sdele , 1);
            FTPHelper.Instance.Delete(sdele);
        }
    }
}
