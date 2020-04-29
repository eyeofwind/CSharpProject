using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRRobot.CustomControls
{
    public partial class EditText : UserControl
    {
        public EditText()
        {
            InitializeComponent();

            //强制宽度/长度
            this.MaximumSize = new Size(250, 21);
            this.MinimumSize = new Size(148, 21);
            //出事大小
            this.Size = new Size(148, 21);

            //Button模式事件
            this.btn.Click += btn_Click;


            //默认显示Button模式
            panelButton.Location = Location;
            txt.Location = Location;
            num.Location = Location;

            panelButton.BringToFront();


            //样式
            btn.Dock = DockStyle.Right;
            txtwithbtn.Dock = DockStyle.Fill;
            panelButton.Dock = DockStyle.Fill;
            txt.Dock = DockStyle.Fill;
            num.Dock = DockStyle.Fill;


            txtwithbtn.TextChanged += txt_TextChanged;
            txt.TextChanged += txt_TextChanged;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
   
        }

        /// <summary>
        /// button模式下的按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            EditBtnClick?.Invoke(sender, e);
        }

        /// <summary>
        /// 默认显示模式
        /// </summary>
        private ShowType _meshowType = EditText.ShowType.Button;

        /// <summary>
        /// 按钮被点击
        /// </summary>
        public event EventHandler EditBtnClick;

        /// <summary>
        /// 显示的样式
        /// </summary>
        public ShowType CtrlShowType
        {
            get => _meshowType;
            set
            {
                _meshowType = value;
                switch (_meshowType)
                {
                    case ShowType.Text:
                        txt.BringToFront();
                        txt.Visible = true;
                        panelButton.Visible = false; txtwithbtn.ResetText();
                        num.Visible = false; num.ResetText();
                        break;
                    case ShowType.Button:
                        panelButton.BringToFront();
                        panelButton.Visible = true;
                        txtwithbtn.ReadOnly = true;
                        txt.Visible = false; txt.ResetText();
                        num.Visible = false; num.ResetText();
                        break;
                    case ShowType.Number:
                        num.BringToFront();
                        num.Visible = true;
                        panelButton.Visible = false; txtwithbtn.ResetText();
                        txt.Visible = false; txt.ResetText();
                        break;
                    default:
                        break;
                }
            }
        }

        public bool Modified
        {
            get
            {
                switch (_meshowType)
                {
                    case ShowType.Text:
                        return txt.Modified;
                    case ShowType.Button:
                        return txtwithbtn.Modified;
                    case ShowType.Number:
                        return true;
                }
                return false;
            }
            set
            {
                switch (_meshowType)
                {
                    case ShowType.Text:
                        txt.Modified = value;
                        break;
                    case ShowType.Button:
                        txtwithbtn.Modified = value;
                        break;
                    case ShowType.Number:
                        break;
                }
            }
        }

        public override string Text
        {
            get
            {
                switch (_meshowType)
                {
                    case ShowType.Text:
                        return txt.Text;
                    case ShowType.Button:
                        return txtwithbtn.Text;
                    case ShowType.Number:
                        return num.Value.ToString();
                }
                return string.Empty;
            }
            set
            {
                switch (_meshowType)
                {
                    case ShowType.Text:
                        txt.Text = value;
                        this.Modified = txt.Modified;
                        break;
                    case ShowType.Button:
                        txtwithbtn.Text = value;
                        this.Modified = txtwithbtn.Modified;
                        break;
                    case ShowType.Number:
                        num.Value = Convert.ToDecimal(value);
                        break;
                }
            }
        }



        public enum ShowType
        {
            Text = 0,
            Button = 1,
            Number = 2
        }
    }
}
