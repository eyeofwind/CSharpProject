using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRRobot.CustomControls
{
    public class ToolTipWithPicture : ToolTip
    {
        /// <summary>
        /// 自定义控件,用于在tooltip中显示图片
        /// </summary>
        public ToolTipWithPicture()
        {
            //必须设置该值为true才会调用draw事件
            this.OwnerDraw = true;

            this.IsBalloon = false;
            this.ToolTipIcon = ToolTipIcon.None;
            this.Popup += CustomToolTip_Popup;
            this.Draw += CustomToolTip_Draw;
        }

        /// <summary>
        /// 显示的图片
        /// </summary>
        private Image _showImage;

        /// <summary>
        /// 展示大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomToolTip_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = this._showImage.Size;
        }

        /// <summary>
        /// 自定义显示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            if (this._showImage == null)
            {
                throw new Exception("图片不能为空!");
            }
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            FrameDimension fd = new FrameDimension(this._showImage.FrameDimensionsList[0]);

            //帧数
            int iCount = this._showImage.GetFrameCount(fd);
            //帧数为1即为图片
            if (iCount == 1)
            {
                e.Graphics.DrawImage(this._showImage, e.Bounds);
                return;
            }

            while (true)
            {
                for (int i = 0; i < iCount; i++)
                {
                    //选择当前帧画面
                    this._showImage.SelectActiveFrame(fd, i);
                    //Tool
                    e.Graphics.DrawImage(this._showImage, e.Bounds);
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
        }

        /// <summary>
        /// 绑定控件显示的图片
        /// </summary>
        /// <param name="ctrl">控件</param>
        /// <param name="image">图片</param>
        public void Binding(Control ctrl, Image image)
        {
            this._showImage = image;
            base.SetToolTip(ctrl, "ligyMade20200424");
        }
    }
}
