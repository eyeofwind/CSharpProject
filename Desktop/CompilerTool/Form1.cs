using System;
using System.Text;
using System.Windows.Forms;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Net;
using System.IO;
using System.Web.Services.Description;
using Microsoft.CSharp;
using System.Diagnostics;
using System.Configuration;

namespace DownWebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
            SaveConfig();
        }

        //测试数据
        private string aFile = @"F:\TestCompilerFromCS\test1.cs";
        private string bFile = @"F:\TestCompilerFromCS\test2.cs";

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            btnDownLoad.Click += (s , e) =>
            {
                GenerateDLL();
            };

            #region [combox]

            cboComplierType.DropDownStyle = ComboBoxStyle.DropDownList;

            cboComplierType.Items.AddRange(Enum.GetNames(typeof(CompilerType)));
            cboComplierType.SelectedIndex = 0;
            cboComplierType.SelectedIndexChanged += (s , e) =>
            {
           
            };
            #endregion

            btnChooseCS.Click += BtnChooseCS_Click;
        }

        private void BtnChooseCS_Click(object sender , EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "C#代码文件|*.cs";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sFileName = ofd.FileName;
                }
            }
        }

      

        private void ControlVisiable(bool bShow)
        {
            txtUrlWithWsdl.Visible = bShow;
        }

        /// <summary>
        /// 下载Soap
        /// </summary>
        /// <returns>wsdl描述</returns>
        private ServiceDescriptionImporter DownLoadSoap()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (Stream sm = client.OpenRead(txtUrlWithWsdl.Text.Trim()))
                    {
                        ServiceDescription sd = new ServiceDescription();
                        ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                        sdi.AddServiceDescription(sd , "" , "");

                        return sdi;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CodeCompileUnit GenerateCSharpFile()
        {
            //编译工作单元
            CodeCompileUnit ccu = new CodeCompileUnit();
            //命名空间
            CodeNamespace cn = new CodeNamespace("TestWebService");

            ccu.Namespaces.Add(cn);

            ServiceDescriptionImporter sdi = DownLoadSoap();

            sdi.Import(cn , ccu);

            return ccu;
        }

       /// <summary>
       /// 生成DLL
       /// </summary>
        private void GenerateDLL()
        {
            //C#编译驱动
            CSharpCodeProvider ccp = new CSharpCodeProvider();
            //设定编译参数
            CompilerParameters paras = new CompilerParameters();
            //是否生成exe文件
            paras.GenerateExecutable = false;
            //是否生成并注入内存
            paras.GenerateInMemory = false;
            //文件编译后输出地址
            paras.OutputAssembly = Path.Combine(txtPath.Text , txtFileName.Text.Trim() + lblExtention.Text);

            

            CompilerResults cr = null;
            if ((CompilerType)(Enum.Parse(typeof(CompilerType) , cboComplierType.SelectedItem.ToString())) 
                ==CompilerType.WSDL文件)
            {
            
                CodeCompileUnit ccu = GenerateCSharpFile();

                paras.ReferencedAssemblies.Add("System.dll");
                paras.ReferencedAssemblies.Add("System.XML.dll");
                paras.ReferencedAssemblies.Add("System.Web.Services.dll");
                paras.ReferencedAssemblies.Add("System.Data.dll");

                //编译代理类
                cr = ccp.CompileAssemblyFromDom(paras , ccu);
            }
            else
            {
                //通过代码文件编译
                //查找文件的using,添加到编译参数
                //paras.ReferencedAssemblies.Add("System.Data.dll");
                //文件数组参数目前使用测试数据
                cr = ccp.CompileAssemblyFromFile(paras,new string[] { aFile,bFile });
            }
            
                if (cr.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }
            Process.Start(txtPath.Text , txtFileName.Text.Trim());
        }


        private void SaveConfig()
        {
            Configuration cfg = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap()
            {
                ExeConfigFilename = Path.Combine(Application.StartupPath , "Content.config")
            } , ConfigurationUserLevel.None);
            if (cfg.AppSettings.Settings["T1"]==null)
            {
                cfg.AppSettings.Settings.Add("T1" , "cehshi");
            }
            cfg.Save();
        }

        public enum CompilerType
        {
            WSDL文件=0,
            CShap代码文件=1
        }

     
    }
}
