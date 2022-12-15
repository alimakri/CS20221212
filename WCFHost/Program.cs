using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFContrat;
using WCFService;

namespace WCFHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host1 = new ServiceHost(typeof(Service1));
            //host1.AddServiceEndpoint(
            //    typeof(IService1),
            //    new NetTcpBinding(),
            //    "net.tcp://localhost:1234/ServiceMajuscule"
            //    );
            host1.Open();
            Console.WriteLine("Le service est prêt");
            Console.ReadLine();
            host1.Close();

        }
    }
}
