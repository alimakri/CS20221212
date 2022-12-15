using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFContrat;

namespace WCFClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "Bonjour tout le monde";
            
            Console.WriteLine("En attente...");
            Console.ReadLine();

            //var canal = new ChannelFactory<IService1>(new NetTcpBinding(), "net.tcp://localhost:1234/ServiceMajuscule");
            var canal = new ChannelFactory<IService1>("principal");
            var service = canal.CreateChannel();

            //IService1 service = new Service1();

            string resultat = service.Majuscule(s);
            Console.WriteLine(resultat);

            Console.ReadLine();
            // netsh http add urlacl url=http://+:1234/ user=makri
        }
    }
}
