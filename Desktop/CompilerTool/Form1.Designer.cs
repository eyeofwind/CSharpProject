namespace DownWebService
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
            this.txtUrlWithWsdl = new System.Windows.Forms.TextBox();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnChooseFilePath = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExtention = new System.Windows.Forms.Label();
            this.cboComplierType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChooseCS = new System.Windows.Forms.Button();
            this.txtCSharpFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtUrlWithWsdl
            // 
            this.txtUrlWithWsdl.Location = new System.Drawing.Point(123, 103);
            this.txtUrlWithWsdl.Name = "txtUrlWithWsdl";
            this.txtUrlWithWsdl.Size = new System.Drawing.Size(241, 21);
            this.txtUrlWithWsdl.TabIndex = 1;
            this.txtUrlWithWsdl.Text = "http://localhost:88/WebService1.asmx?wsdl";
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(180, 286);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(75, 23);
            this.btnDownLoad.TabIndex = 2;
            this.btnDownLoad.Text = "下载";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(87, 172);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(123, 21);
            this.txtPath.TabIndex = 3;
            this.txtPath.Text = "F:\\";
            // 
            // btnChooseFilePath
            // 
            this.btnChooseFilePath.Location = new System.Drawing.Point(224, 172);
            this.btnChooseFilePath.Name = "btnChooseFilePath";
            this.btnChooseFilePath.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFilePath.TabIndex = 4;
            this.btnChooseFilePath.Text = "选择路径";
            this.btnChooseFilePath.UseVisualStyleBackColor = true;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(87, 211);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(123, 21);
            this.txtFileName.TabIndex = 5;
            this.txtFileName.Text = "Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "存放地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "文件名";
            // 
            // lblExtention
            // 
            this.lblExtention.AutoSize = true;
            this.lblExtention.Location = new System.Drawing.Point(216, 220);
            this.lblExtention.Name = "lblExtention";
            this.lblExtention.Size = new System.Drawing.Size(29, 12);
            this.lblExtention.TabIndex = 8;
            this.lblExtention.Text = ".DLL";
            // 
            // cboComplierType
            // 
            this.cboComplierType.FormattingEnabled = true;
            this.cboComplierType.Location = new System.Drawing.Point(87, 19);
            this.cboComplierType.Name = "cboComplierType";
            this.cboComplierType.Size = new System.Drawing.Size(121, 20);
            this.cboComplierType.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "编译类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "WebService地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "代码文件";
            // 
            // btnChooseCS
            // 
            this.btnChooseCS.Location = new System.Drawing.Point(229, 57);
            this.btnChooseCS.Name = "btnChooseCS";
            this.btnChooseCS.Size = new System.Drawing.Size(75, 23);
            this.btnChooseCS.TabIndex = 13;
            this.btnChooseCS.Text = "选择路径";
            this.btnChooseCS.UseVisualStyleBackColor = true;
            // 
            // txtCSharpFile
            // 
            this.txtCSharpFile.Location = new System.Drawing.Point(87, 57);
            this.txtCSharpFile.Name = "txtCSharpFile";
            this.txtCSharpFile.Size = new System.Drawing.Size(123, 21);
            this.txtCSharpFile.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 321);
            this.Controls.Add(this.txtCSharpFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnChooseCS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboComplierType);
            this.Controls.Add(this.lblExtention);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnChooseFilePath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.txtUrlWithWsdl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUrlWithWsdl;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnChooseFilePath;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExtention;
        private System.Windows.Forms.ComboBox cboComplierType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChooseCS;
        private System.Windows.Forms.TextBox txtCSharpFile;
    }
}

