namespace HRRobot.CustomControls
{
    partial class EditText
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
            this.txtwithbtn = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.panelButton = new System.Windows.Forms.Panel();
            this.txt = new System.Windows.Forms.TextBox();
            this.num = new System.Windows.Forms.NumericUpDown();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num)).BeginInit();
            this.SuspendLayout();
            // 
            // txtwithbtn
            // 
            this.txtwithbtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtwithbtn.Location = new System.Drawing.Point(0, 0);
            this.txtwithbtn.Name = "txtwithbtn";
            this.txtwithbtn.Size = new System.Drawing.Size(114, 21);
            this.txtwithbtn.TabIndex = 0;
            // 
            // btn
            // 
            this.btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn.Location = new System.Drawing.Point(114, 0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(34, 21);
            this.btn.TabIndex = 1;
            this.btn.Text = "...";
            this.btn.UseVisualStyleBackColor = true;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.txtwithbtn);
            this.panelButton.Controls.Add(this.btn);
            this.panelButton.Location = new System.Drawing.Point(23, 122);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(148, 21);
            this.panelButton.TabIndex = 2;
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(23, 46);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(148, 21);
            this.txt.TabIndex = 0;
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(23, 81);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(148, 21);
            this.num.TabIndex = 4;
            // 
            // EditText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt);
            this.Controls.Add(this.num);
            this.Controls.Add(this.panelButton);
            this.Name = "EditText";
            this.Size = new System.Drawing.Size(231, 175);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtwithbtn;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.NumericUpDown num;
    }
}
