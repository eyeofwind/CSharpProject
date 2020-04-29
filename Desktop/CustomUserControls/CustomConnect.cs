using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRRobot.CustomControls
{
    public partial class CustomConnect : UserControl
    {
        private double _iUnit = 0;
        private int _iHeight = 0;
        private int _iWidth = 0;
        private int _iValue = 0;

        private Bitmap bmp;

        private Graphics g;

        public CustomConnect()
        {
            InitializeComponent();

            _iWidth = this.Width;
            _iHeight = this.Height;

            _iUnit = _iWidth / 100.0;

            bmp = new Bitmap(_iWidth, _iHeight);

            g = Graphics.FromImage(bmp);
            g.Clear(Color.Gray);

            CusPicToPb.Image = bmp;
        }

        /// <summary>
        /// 前进到
        /// </summary>
        /// <param name="Value"></param>
        public async Task SetForwardToValue(int Value)
        {
            await Task.Factory.StartNew(new Action(() =>
           {
               while (Value > _iValue)
               {
                   CusPicToPb.Invoke(new Action(() =>
                   {
                       g = Graphics.FromImage(bmp);

                       g.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(0, 0, (int)(_iValue * _iUnit), _iHeight));

                       CusPicToPb.Image = bmp;
                   }));

                   _iValue++;
               }
               if (Value == 100)
               {
                   CusPicToPb.Invoke(new Action(() =>
                   {
                       g = Graphics.FromImage(bmp);

                       g.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(0, 0, this.Width, this.Height));

                       CusPicToPb.Image = bmp;
                   }));
               }
           }));
        }

        /// <summary>
        /// 后退到
        /// </summary>
        /// <param name="Value"></param>
        public async Task SetBackToValue(int Value)
        {
            await Task.Factory.StartNew(new Action(() =>
             {
                 while (Value < _iValue)
                 {
                     CusPicToPb.Invoke(new Action(() =>
                     {
                         g = Graphics.FromImage(bmp);

                         g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle((int)((_iValue) * _iUnit), 0, (int)_iUnit, _iHeight));

                         CusPicToPb.Image = bmp;
                     }));

                     _iValue--;
                 }
                 if (Value == 0)
                 {
                     CusPicToPb.Invoke(new Action(() =>
                     {
                         g = Graphics.FromImage(bmp);

                         g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, CusPicToPb.Width, CusPicToPb.Height));

                         CusPicToPb.Image = bmp;
                     }));
                 }
             }));
        }
    }
}