using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Globalization;
using System.ServiceModel.Description;

namespace RestfulServer {
    class Program {
        static void Main(string[] args) {
            WebHttpBinding binding;

            binding = new WebHttpBinding();
            binding.MaxBufferPoolSize = 524288000;
            binding.MaxReceivedMessageSize = 655360000;
            binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;


            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
            binding.OpenTimeout = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = new TimeSpan(0, 10, 0);
            string url = string.Format(CultureInfo.CurrentCulture, "http://{0}:{1}/{2}", "127.0.0.1", "8023", "Restful");
            RestfulService service = new RestfulService();
            ServiceHost host = new ServiceHost(service, new Uri(url));


            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IRestfulService), binding, url);
            WebHttpBehaviorEx httpBehavior = new WebHttpBehaviorEx();
            endpoint.Behaviors.Add(httpBehavior);

            try {
                host.Open();
                Console.WriteLine("Restful server start...");
                Console.ReadKey();
            } catch (AddressAlreadyInUseException) {
            }
        }
    }
}
