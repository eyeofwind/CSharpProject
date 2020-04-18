using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace WCFLearn
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IFlyService
    {
        [MyOperationBehavior(Length =3)]
        [OperationContract(IsOneWay = true)]
        void Fly(string sMsg);
    }


    public class MyOperationBehaviorAttribute :Attribute ,IOperationBehavior
    {
        public int Length { get; set; }
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(new MyParaInspector(Length));
        }

        public void Validate(OperationDescription operationDescription)
        {
            
        }
    }

    public class MyParaInspector : IParameterInspector
    {
        private int _milength = 0;

        public MyParaInspector(int iLength)
        {
            _milength = iLength;
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            foreach (var item in inputs)
            {
                if (item.ToString().Length>_milength)
                {
                    throw new Exception("");
                }
            }
            return null;
        }
    }
}
