namespace HRRobot.CustomControls
{
    partial class CustomConnect
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CusPicToPb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CusPicToPb)).BeginInit();
            this.SuspendLayout();
            // 
            // CusPicToPb
            // 
            this.CusPicToPb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CusPicToPb.Location = new System.Drawing.Point(0, 0);
            this.CusPicToPb.Name = "CusPicToPb";
            this.CusPicToPb.Size = new System.Drawing.Size(303, 25);
            this.CusPicToPb.TabIndex = 0;
            this.CusPicToPb.TabStop = false;
            // 
            // CustomProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CusPicToPb);
            this.Name = "CustomProgressBar";
            this.Size = new System.Drawing.Size(303, 25);
            ((System.ComponentModel.ISupportInitialize)(this.CusPicToPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CusPicToPb;
    }
}
