using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace FileTransfer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Init();
        }

        /// <summary>
        /// 程序运行根目录下的配置文件
        /// </summary>
        private string _msAppCfg = Path.Combine(Application.StartupPath , "FilePath.config");

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;

                txtSource.ReadOnly = true;
                txtTarget.ReadOnly = true;
                txtDetail.ReadOnly = true;

                btnOK.Click += BtnOK_Click;

                btnClose.Click += (o , s) =>
                {
                    bool bResult = CheckModified();
                    if (bResult)
                    {
                        if (ShowQues("路径内容发生变更,是否继续保存?")== DialogResult.Yes)
                        {
                            if (CheckPath())
                            {
                                SaveCfg();
                            }
                            else
                            {
                                return;
                            }                        
                        }
                    }
                    this.Close();
                };
          
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button)
                    {
                        Button btn = ctrl as Button;
                        if (btn.Name.Contains("btn"))
                        {
                            continue;
                        }
                        btn.Click += ChooseFoler;
                    }
                }

                PreLoad();

                Source.Focus();
                ActiveControl = Source;

            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        BackgroundWorker _mtransfer = null;

        private void BtnOK_Click(object sender , EventArgs e)
        {
            try
            {
                txtDetail.Text = string.Empty;
                SaveCfg();

                if (_mtransfer != null && _mtransfer.IsBusy)
                {
                    _mtransfer = null;
                }

                _mtransfer = new BackgroundWorker();
                _mtransfer.WorkerSupportsCancellation = true;

                _mtransfer.DoWork += (o , eve) =>
                {
                    TransferHelper transfer = new TransferHelper();
                    transfer.loopFiles(txtSource.Text , txtTarget.Text, WriteLog);
                };

                _mtransfer.RunWorkerCompleted += (o , eve) =>
                {
                    txtDetail.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + " 完成复制!\r\n";
                    txtDetail.SelectionStart = txtDetail.MaxLength;
                };

                _mtransfer.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private void WriteLog(string sMsg)
        {
            try
            {
                this.Invoke( new Action(()=>
                {
                    txtDetail.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + "  " + sMsg + "\r\n";
                    txtDetail.SelectionStart = txtDetail.MaxLength;
                    txtDetail.ScrollToCaret();
                }));

            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        /// <summary>
        /// 初始化路径配置
        /// </summary>
        private void PreLoad()
        {
            try
            {
                Configuration Cfg = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap()
                {
                    ExeConfigFilename = _msAppCfg
                } , ConfigurationUserLevel.None);

                if (Cfg.AppSettings.Settings.AllKeys.Contains(txtSource.Name))
                {
                    txtSource.Text= Cfg.AppSettings.Settings[txtSource.Name].Value ;
                }

                if (Cfg.AppSettings.Settings.AllKeys.Contains(txtTarget.Name))
                {
                    txtTarget.Text = Cfg.AppSettings.Settings[txtTarget.Name].Value ;
                }

            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

    
        /// <summary>
        /// 选择文件夹
        /// </summary>
        /// <param name="txtBox"></param>
        private void ChooseFoler(object sender , EventArgs e)
        {
            try
            {
                FolderBrowserDialog ofd = new FolderBrowserDialog();

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sTxtName = "txt" + (sender as Button).Name;
                    (this.Controls[sTxtName] as TextBox).Text = ofd.SelectedPath;
                    (this.Controls[sTxtName] as TextBox).Modified = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检查路径是否合法
        /// </summary>
        /// <returns></returns>
        private bool CheckPath()
        {
            try
            {
                List<string> lstPathName = new List<string>();

                if (!Directory.Exists(txtSource.Text.Trim()) && !string.IsNullOrEmpty(txtSource.Text.Trim()))
                {
                    lstPathName.Add("源路径");
                }

                if (!Directory.Exists(txtTarget.Text.Trim()) && !string.IsNullOrEmpty(txtTarget.Text.Trim()))
                {
                    lstPathName.Add("目标路径");
                }

                if (lstPathName.Count>0)
                {
                    ShowInfo(string.Join(",",lstPathName)+" 不存在,请检查!");
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                ShowErr(ex);
                return false;
            }
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        private void SaveCfg()
        {
            try
            {
                Configuration Cfg = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap()
                {
                    ExeConfigFilename = _msAppCfg
                } , ConfigurationUserLevel.None);

                if (Cfg.AppSettings.Settings.AllKeys.Contains(txtSource.Name))
                {
                    Cfg.AppSettings.Settings[txtSource.Name].Value = txtSource.Text.Trim();
                }
                else
                {
                    Cfg.AppSettings.Settings.Add(txtSource.Name , txtSource.Text.Trim());
                }

                if (Cfg.AppSettings.Settings.AllKeys.Contains(txtTarget.Name))
                {
                    Cfg.AppSettings.Settings[txtTarget.Name].Value = txtTarget.Text.Trim();
                }
                else
                {
                    Cfg.AppSettings.Settings.Add(txtTarget.Name , txtTarget.Text.Trim());
                }

                Cfg.Save();               
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        /// <summary>
        /// 检查路径txt是否改变
        /// </summary>
        /// <returns>返回是否</returns>
        private bool CheckModified()
        {
            try
            {
                if (txtSource.Modified)
                {
                    return true;
                }
                if (txtTarget.Modified)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                ShowErr(ex);
                return false;
            }
        }

        #region 信息提醒

        /// <summary>
        /// 错误提示
        /// </summary>
        /// <param name="ex">异常</param>
        private void ShowErr(Exception ex)
        {
            try
            {
                MessageBox.Show(ex.Message , "错误提示" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                throw ex;
            }
        }

        private void ShowInfo(string sMsg)
        {
            try
            {
                MessageBox.Show(sMsg , "信息提示" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               ShowErr(ex);
            }
        }

        private DialogResult ShowQues(string sMsg)
        {
            try
            {
             return   MessageBox.Show(sMsg , "信息提示" , MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                ShowErr(ex);
                return DialogResult.No;
            }
        }

        #endregion
    }
}
