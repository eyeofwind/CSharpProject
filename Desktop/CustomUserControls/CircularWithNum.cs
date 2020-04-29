using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HRRobot.CustomControls
{
    public partial class CircularWithNum : UserControl
    {
        public CircularWithNum()
        {
            InitializeComponent();

            Circular.Paint += Circular_Paint;
        }

        [Browsable(true)]
        [Category("自定义属性"), Description("中心字体")]
        public string CustomTest
        {
            get { return fontInfo.Test; }
            set
            {
                fontInfo.Test = value;
                WriteTestInMiddle(fontInfo.Test, "Arial", 10, Color.White, FontStyle.Bold);
            }
        }

        [Browsable(true)]
        [Category("自定义属性"), Description("圆颜色")]
        public Color CustomCircularColor
        {
            get { return circularInfo.Color; }
            set
            {
                circularInfo.Color = value;

                SetCircularColor(value);

                if (!string.IsNullOrEmpty(fontInfo.Test))
                {
                    WriteTestInMiddle(fontInfo.Test, fontInfo.Family, fontInfo.Size, fontInfo.Color, fontInfo.style);
                }

                if (ProgressBar != null)
                {
                    ProgressBar.Invoke(new Action(() =>
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            ProgressBar.Value += 1;
                        }
                    }));
                    ProgressBar = null;
                }
            }
        }

        [Browsable(true)]
        [Category("自定义属性"), Description("进度条")]
        public ProgressBar ProgressBar { get; set; }

        private CircularInfo circularInfo;
        private FontInfo fontInfo;

        [Browsable(true)]
        [Category("自定义属性"), Description("中心字体颜色")]
        public Color CustomTextColor
        {
            get
            {
                return fontInfo.Color;
            }
            set { fontInfo.Color = value; }
        }

        private void Circular_Paint(object sender, PaintEventArgs e)
        {
            SetCircularColor(circularInfo.Color);
            if (!string.IsNullOrEmpty(CustomTest))
            {
                WriteTestInMiddle(CustomTest, "Arial", 10, CustomTextColor);
            }
        }

        /// <summary>
        /// 设置圆的颜色
        /// </summary>
        /// <param name="color">颜色</param>
        public void SetCircularColor(Color color)
        {
            using (Graphics g = Circular.CreateGraphics())
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.FillEllipse(new SolidBrush(color), Circular.ClientRectangle);
            }
            CircularInfo circularInfo = new CircularInfo();
            circularInfo.Color = color;
        }

        /// <summary>
        /// 将文本画在控件中心
        /// </summary>
        /// <param name="Test">显示文字</param>
        /// <param name="Family">字体</param>
        /// <param name="size">字体大小</param>
        /// <param name="color">字体颜色</param>
        /// <param name="style">字体类型</param>
        public void WriteTestInMiddle(string Test, string Family, float size, Color color, FontStyle style = FontStyle.Bold)
        {
            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            Font f = new Font(Family, size, style);

            Graphics g = Circular.CreateGraphics();
            g.DrawString(Test, f, new SolidBrush(color), Circular.ClientRectangle, sf);

            FontInfo info = new FontInfo();
            info.Test = Test;
            info.Family = Family;
            info.Size = size;
            info.Color = color;
            info.style = style;

            fontInfo = info;
        }

        /// <summary>
        /// 圆信息
        /// </summary>
        private struct CircularInfo
        {
            public Color Color;
        }

        /// <summary>
        /// 字体信息
        /// </summary>
        private struct FontInfo
        {
            public string Test;
            public string Family;
            public float Size;
            public Color Color;
            public FontStyle style;
        }
    }
}