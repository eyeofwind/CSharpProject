namespace HRRobot.CustomControls
{
    partial class CircularWithNum
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
            this.Circular = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Circular
            // 
            this.Circular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Circular.Location = new System.Drawing.Point(0, 0);
            this.Circular.Name = "Circular";
            this.Circular.Size = new System.Drawing.Size(161, 150);
            this.Circular.TabIndex = 0;
            // 
            // CircularWithNum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Circular);
            this.Name = "CircularWithNum";
            this.Size = new System.Drawing.Size(161, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Circular;
    }
}
