using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestFtp
{
    public class FTPHelper
    {
        private static string ftpURI { get; set; }
        private static string ftpUserID { get; set; }
        private static string ftpServerIP { get; set; }
        private static string ftpPassword { get; set; }
        private static string ftpRemotePath { get; set; }

        private static FTPHelper _mInstance = null;

        public static FTPHelper Instance
        {
            get
            {
                if (_mInstance == null)
                {
                    string sFtpJson = Properties.Resources.FtpJson;
                    ftpURI = Newtonsoft.Json.Linq.JObject.Parse(sFtpJson).Value<string>("FtpUri");
                    ftpUserID = Newtonsoft.Json.Linq.JObject.Parse(sFtpJson).Value<string>("FtpUser");
                    ftpPassword = Newtonsoft.Json.Linq.JObject.Parse(sFtpJson).Value<string>("FtpPwd");
                    _mInstance = new FTPHelper(ftpURI , string.Empty , ftpUserID , ftpPassword);
                }
                return _mInstance;
            }
        }

        /// <summary>  
        /// 连接FTP服务器
        /// </summary>  
        /// <param name="FtpServerIP">FTP连接地址</param>  
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>  
        /// <param name="FtpUserID">用户名</param>  
        /// <param name="FtpPassword">密码</param>  
        private FTPHelper(string FtpServerIP , string FtpRemotePath , string FtpUserID , string FtpPassword)
        {
            ftpServerIP = FtpServerIP;
            ftpRemotePath = FtpRemotePath;
            ftpUserID = FtpUserID;
            ftpPassword = FtpPassword;
            ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        }


        private FtpWebRequest GetRequest(string sUri)
        {
            try
            {
                FtpWebRequest Ftp = (FtpWebRequest)WebRequest.Create(new Uri(sUri));
                Ftp.Credentials = new NetworkCredential(ftpUserID , ftpPassword);
                Ftp.KeepAlive = false;
                Ftp.Timeout = 1000 * 60;
                Ftp.UseBinary = true;

                return Ftp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="filename"></param>
        public void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            FtpWebRequest reqFTP = GetRequest(ftpURI + fileInf.Name);

            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.ContentLength = fileInf.Length;

            int iBuffLength = 1024 * 1024;
            byte[] arrBytes = new byte[iBuffLength];
            using (FileStream fs = fileInf.OpenRead())
            {
                using (Stream srm = reqFTP.GetRequestStream())
                {
                    int iContentLength = 0;
                    while (true)
                    {
                        iContentLength = fs.Read(arrBytes , 0 , iBuffLength);
                        srm.Write(arrBytes , 0 , iContentLength);
                        if (iContentLength == 0)
                        {
                            break;
                        }
                    }
                    srm.Close();
                    fs.Close();
                }
            }
        }


        /// <summary>
              /// 下载
              /// </summary>
              /// <param name="filePath">下载文件保存的路径</param>
              /// <param name="fileName">文件名</param>
              /// <param name="usePassive">1，主动  0被动</param>
        public void Download(string filePath , string fileName , int usePassive)
        {
            try
            {
                FileStream outputStream = new FileStream(filePath + "\\" + fileName , FileMode.Create);
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + fileName));
                reqFTP.Credentials = new NetworkCredential(ftpUserID , ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                if (usePassive == 1)
                {
                    reqFTP.UsePassive = true;
                }
                else
                {
                    reqFTP.UsePassive = false;
                }
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                int bufferSize = 1024*1024;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer , 0 , bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer , 0 , readCount);
                    readCount = ftpStream.Read(buffer , 0 , bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>  
        /// 删除文件  
        /// </summary>  
        public void Delete(string fileName)
        {
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + fileName));
                reqFTP.Credentials = new NetworkCredential(ftpUserID , ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                reqFTP.KeepAlive = false;
                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                      
                response.Close();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>  
        /// 获取当前目录下明细(包含文件和文件夹)  
        /// </summary>  
        public string[] GetFilesDetailList()
        {
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                ftp.Credentials = new NetworkCredential(ftpUserID , ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n") , 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>  
        /// 获取FTP文件列表(包括文件夹)
        /// </summary>   
        public List<string> GetAllList(string url)
        {
            List<string> list = new List<string>();
            if (string.IsNullOrEmpty(url))
            {
                url = ftpURI;
            }
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(new Uri(url));
            req.Credentials = new NetworkCredential(ftpUserID , ftpPassword);
            req.Method = WebRequestMethods.Ftp.ListDirectory;
            req.UseBinary = true;
            req.UsePassive = true;
            try
            {
                using (FtpWebResponse res = (FtpWebResponse)req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        string s = sr.ReadToEnd();
                        s = s.Substring(0 , s.Length - 2);
                        string[] a = Regex.Split(s , @"\r\n" , RegexOptions.IgnoreCase);
                        list.AddRange(a);

                        sr.Close();
                        res.Close();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        /// <summary>  
        /// 获取当前目录下文件列表(不包括文件夹)  
        /// </summary>  
        public string[] GetFileList(string url)
        {
            StringBuilder result = new StringBuilder();
            if (string.IsNullOrEmpty(url))
            {
                url = ftpURI;
            }
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID , ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.IndexOf("<DIR>") == -1)
                    {
                        result.Append(Regex.Match(line , @"[\S]+ [\S]+" , RegexOptions.IgnoreCase).Value.Split(' ')[1]);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n') , 1);
                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return result.ToString().Split('\n');
        }


        /// <summary>  
        /// 判断当前目录下指定的文件是否存在  
        /// </summary>  
        /// <param name="RemoteFileName">远程文件名</param>  
        public bool FileExist(string RemoteFileName)
        {
            string[] fileList = GetFileList("*.*");
            foreach (string str in fileList)
            {
                if (str.Trim() == RemoteFileName.Trim())
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>  
        /// 创建文件夹  
        /// </summary>   
        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID , ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            { }
        }


        /// <summary>  
        /// 获取指定文件大小  
        /// </summary>  
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID , ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            { }
            return fileSize;
        }


        /// <summary>  
        /// 更改文件名  
        /// </summary> 
        public void ReName(string currentFilename , string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID , ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            { }
        }


        /// <summary>  
        /// 移动文件  
        /// </summary>  
        public void MovieFile(string currentFilename , string newDirectory)
        {
            ReName(currentFilename , newDirectory);
        }


        /// <summary>  
        /// 切换当前目录  
        /// </summary>  
        /// <param name="IsRoot">true:绝对路径 false:相对路径</param>   
        public void GotoDirectory(string DirectoryName , bool IsRoot)
        {
            if (IsRoot)
            {
                ftpRemotePath = DirectoryName;
            }
            else
            {
                ftpRemotePath += DirectoryName + "/";
            }
            ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        }
    }


}
