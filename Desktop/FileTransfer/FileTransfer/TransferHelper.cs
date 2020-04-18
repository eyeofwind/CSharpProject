using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.ComponentModel;
using System.Windows.Forms;

namespace FileTransfer
{
    public class TransferHelper
    {
        public void loopFiles(string sFolderSrc , string sFolderTg , Action<string> atWriteLog)
        {
            try
            {
                string sFolderSrcName = Path.GetFileName(sFolderSrc);

                string sNewFolder = Path.Combine(sFolderTg , sFolderSrcName);
                if (!Directory.Exists(sNewFolder))
                {
                    Directory.CreateDirectory(sNewFolder);
                }

                string[] arrAllFiles = Directory.GetFileSystemEntries(sFolderSrc);

                foreach (string filePath in arrAllFiles)
                {
                    string sFileName = Path.GetFileName(filePath);
                    string sNewPath = Path.Combine(sNewFolder , sFileName);
                    if (!Directory.Exists(filePath))
                    {
                        File.Copy(filePath , sNewPath);
                        atWriteLog("已复制到:" + sNewPath);
                    }
                    else
                    {
                        loopFiles(filePath , sNewFolder , atWriteLog);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private void ShowErr(Exception ex)
        {
            MessageBox.Show(ex.Message , "错误提示" , MessageBoxButtons.OK , MessageBoxIcon.Error);
        }

    }

}
