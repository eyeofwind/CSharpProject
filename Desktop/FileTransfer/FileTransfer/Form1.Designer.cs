namespace FileTransfer
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Source = new System.Windows.Forms.Button();
            this.Target = new System.Windows.Forms.Button();
            this.txtDetail = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(98, 12);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(272, 21);
            this.txtSource.TabIndex = 0;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(98, 39);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(272, 21);
            this.txtTarget.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "源路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "目标路径";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(143, 255);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(231, 255);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // Source
            // 
            this.Source.Location = new System.Drawing.Point(376, 10);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(36, 23);
            this.Source.TabIndex = 5;
            this.Source.Text = "...";
            this.Source.UseVisualStyleBackColor = true;
            // 
            // Target
            // 
            this.Target.Location = new System.Drawing.Point(376, 37);
            this.Target.Name = "Target";
            this.Target.Size = new System.Drawing.Size(36, 23);
            this.Target.TabIndex = 5;
            this.Target.Text = "...";
            this.Target.UseVisualStyleBackColor = true;
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(29, 81);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(382, 168);
            this.txtDetail.TabIndex = 6;
            this.txtDetail.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 290);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.Target);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button Source;
        private System.Windows.Forms.Button Target;
        private System.Windows.Forms.RichTextBox txtDetail;
    }
}

