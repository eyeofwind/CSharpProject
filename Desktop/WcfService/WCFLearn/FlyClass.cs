using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLearn
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class FlyClass : IFlyService
    {
        public void Fly(string sMsg)
        {
            Console.WriteLine("wcf recive msg: {0} ,time :{1}",sMsg,DateTime.Now);
        }
    }
}
