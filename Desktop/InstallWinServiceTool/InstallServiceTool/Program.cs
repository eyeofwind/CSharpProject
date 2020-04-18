using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Collections;
using System.Configuration;

namespace AutoOpenProg
{
    class Program
    {
        static void Main(string[] args)
        {
            string sVal = GetConfig();
            if (string.IsNullOrEmpty(sVal))
            {
                Console.WriteLine("服务名称不能为空,请将服务放在程序运行目录,并且在服务配置.config配置好相应的值!");
                Console.ReadKey();
                return;
            }
            else {
                _mServiceName = sVal;
                _msPath= System.IO.Path.Combine(Environment.CurrentDirectory, sVal+".exe");
            }


            string sMsg = @"
1-安装服务
2-卸载服务
3-开始服务
4-停止服务
0-退出";

            string sInput = string.Empty;
            int iInput = -1;
            while (true)
            {
                Console.WriteLine(sMsg);
                sInput = Console.ReadLine();
                try
                {
                    iInput = int.Parse(sInput);
                    switch (iInput)
                    {
                        case 1:
                            SetupService();
                            break;
                        case 2:
                            RemoveService();
                            break;
                        case 3:
                            StartService();
                            break;
                        case 4:
                            StopService();
                            break;
                        case 0:
                            break;
                            
                        default:
                            Console.WriteLine("输入有误\r\n");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("输入有误\r\n");
                }
                if (iInput==0)
                {
                    break;
                }
                continue;
            }
        }

        private static  string _msPath = System.IO.Path.Combine(Environment.CurrentDirectory,"TestService.exe");
        private static string _mServiceName = "TestService";

        private static string GetConfig()
        {
            try
            {
                Configuration cfg = ConfigurationManager.OpenMappedExeConfiguration(
         new ExeConfigurationFileMap()
         {
             ExeConfigFilename = System.IO.Path.Combine(Environment.CurrentDirectory, "服务配置.config")
         }, ConfigurationUserLevel.None);
                string sVal = string.Empty;
                if (cfg.AppSettings.Settings["ServiceName"] == null)
                {
                    cfg.AppSettings.Settings.Add("ServiceName", string.Empty);

                }
                else
                {
                    sVal = cfg.AppSettings.Settings["ServiceName"].Value;
                }

                cfg.Save();
                return sVal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }


        private static void SetupService()
        {
            try
            {
                if (IsExists(_mServiceName))
                {
                    Console.WriteLine("service by "+_mServiceName+ " is already exists,do not install again\r\n");
                    return;
                }

                using (AssemblyInstaller  assemblyInstaller  =new AssemblyInstaller())
                {
                    assemblyInstaller.UseNewContext = true;
                    assemblyInstaller.Path = _msPath;
                    IDictionary savedstate = new Hashtable();
                    assemblyInstaller.Install(savedstate);
                    assemblyInstaller.Commit(savedstate);
                    Console.WriteLine("服务安装完成\r\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveService()
        {
            try
            {
                if (!IsExists(_mServiceName))
                {
                    Console.WriteLine("service by " + _mServiceName + " is not exists,can not remove\r\n");
                    return;
                }

                using (AssemblyInstaller assemblyInstaller = new AssemblyInstaller())
                {
                    assemblyInstaller.UseNewContext = true;
                    assemblyInstaller.Path = _msPath;
                    assemblyInstaller.Uninstall(null);
                    Console.WriteLine("服务卸载完成\r\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void StartService()
        {
            try
            {
                if (!IsExists(_mServiceName))
                {
                    Console.WriteLine("service by " + _mServiceName + " is not exists,can not start\r\n");
                    return;
                }


                using (ServiceController controller =new ServiceController(_mServiceName))
                {
                    if (controller.Status != ServiceControllerStatus.Running
                        || controller.Status != ServiceControllerStatus.StartPending)
                    {
                        controller.Start();
                        Console.WriteLine("服务启动完成\r\n");
                    }
                    else {
                        Console.WriteLine("服务正在运行中....无需启动\r\n");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void StopService()
        {
            try
            {
                if (!IsExists(_mServiceName))
                {
                    Console.WriteLine("service by " + _mServiceName + " is not exists,can not stop\r\n");
                    return;
                }


                using (ServiceController controller =new ServiceController(_mServiceName))
                {
                    if (controller.Status != ServiceControllerStatus.Stopped
                        || controller.Status != ServiceControllerStatus.StopPending)
                    {
                        controller.Stop();
                        Console.WriteLine("服务停止完成\r\n");
                    }
                    else {
                        Console.WriteLine("服务已经停止...无需再次停止\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool IsExists(string sServiceName)
        {
            try
            {
                ServiceController[] serviceControllers = ServiceController.GetServices();
                return serviceControllers.Any(s => string.Compare(s.ServiceName, sServiceName) == 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
