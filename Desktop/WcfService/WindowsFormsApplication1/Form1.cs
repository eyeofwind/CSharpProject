using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender , EventArgs e)
        {
            ServiceReference1.IUser user = new ServiceReference1.UserClient(
                new System.ServiceModel.InstanceContext(new CallBack())
                );

            user.AddNums(5 , 9);
        }

    }

    public class CallBack : ServiceReference1.IUserCallback
    {
        public void Calculate(int result)
        {
            MessageBox.Show(result.ToString());
            System.IO.File.WriteAllText(@"F:\1.txt" , result.ToString(),Encoding.UTF8);
        }
    }
}
