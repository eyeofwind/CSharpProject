using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterHotKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button btn = new Button()
            {
                Text = "按钮"
            };
            btn.Click += Btn_Click;
            Button btn2 = new Button()
            {
                Text = "按钮delete"
            };
            btn.Click += Btn_Click;
            btn2.Click += Btn2_Click;
            btn2.ClientSize = new Size(500 , 500);
            this.Controls.Add(btn);
            this.Controls.Add(btn2);
        }

        private void Btn2_Click(object sender , EventArgs e)
        {
            AppHotKey.Unregkey(Handle , Space);
        }

        private void Btn_Click(object sender , EventArgs e)
        {
            AppHotKey.RegKey(this.Handle , Space , AppHotKey.KeyModifiers.Alt , Keys.Z);
        }

        const int WM_HOTKEY = 0x312;
        const int WM_CREATE = 0x1;
        const int WM_DESTROY = 0x2;

        readonly int Space = (int) AppHotKey.GlobalAddAtom(Guid.NewGuid().ToString()); //0x3254; //唯一ID才对

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if( m.Msg==WM_HOTKEY )
            {
                if( m.WParam.ToInt32()==Space )
                {
                    if( this.Visible )
                    {
                        this.Hide();
                    }
                    else
                    {
                        Visible = true;
                    }
                }
            }
            
            switch( m.Msg )
            {
                case WM_CREATE:
                    //AppHotKey.RegKey(this.Handle , Space , AppHotKey.KeyModifiers.Alt , Keys.Z);
                    break;
                case WM_DESTROY:
                    AppHotKey.Unregkey(this.Handle , Space);
                    break;
                default:
                    break;
            }
        }
    }
}
