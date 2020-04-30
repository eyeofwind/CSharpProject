using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverrideProgressBar
{
    [Browsable(false)]
    public class OverridePb : ProgressBar
    {
        public OverridePb()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //calc rectangle szie
            Rectangle bounds = new Rectangle(0, 0, base.Width, base.Height);
            bounds.Height -= 4;
            bounds.Width = ((int)(bounds.Width * (((double)base.Value) / ((double)base.Maximum)))) - 4;

            //Override color
            e.Graphics.FillRectangle(new SolidBrush(Color.Orange), 2, 2, bounds.Width, bounds.Height);
        }
    }

    /*How To Use
        OverridePb bar = new OverridePb();
            bar.Parent = Progress; //ProgressBar Control
            bar.Minimum = 0;
            bar.Maximum = 100;
            bar.Width = Progress.Width;
            bar.Height = Progress.Height;
            bar.BackColor = Color.Gray;
     */
}
