using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost serviceHost = new ServiceHost(typeof(FlyClass), new Uri("http://192.168.193.1:8733/WCFLearn/MyWcf/"));

            serviceHost.AddServiceEndpoint(typeof(IFlyService), new BasicHttpBinding(), string.Empty);

            serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true, HttpsGetEnabled = true });
            serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = false;
            
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            
            serviceHost.Open();
            
            Console.WriteLine("wcf running....");
            Console.ReadKey();
        }
    }
}
