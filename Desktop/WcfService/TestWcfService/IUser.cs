using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestWcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUser”。
    [ServiceContract(SessionMode = SessionMode.Required,
        CallbackContract = typeof(IServiceDuplexCallback))]//获取双工协定时回调的协定的类型
    public interface IUser
    {
        [OperationContract(IsOneWay = true)]
        void AddNums(int x, int y);
    }

    public interface IServiceDuplexCallback  //CallbackContract回调客户端方法
    {
        [OperationContract(IsOneWay = true)]
        void Calculate(int result);

    }
}
