using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoRestFull
{
    internal class Program
    {
        private static WebClient ClientRest = new WebClient();
        static void Main(string[] args)
        {
            var url = "https://restcountries.com/v3.1/all";
            var data = ClientRest.DownloadString(url);
            var liste = JsonConvert.DeserializeObject<List<Pays>>(data);

            var paysC = liste.Where(p => p.Capital !=null && p.Capital.Length > 1);
            foreach(var p in paysC)
            {
                Console.WriteLine(p.Name.Common);
            }

            Console.ReadLine();
        }
    }
    class Pays
    {
        public NamePart Name;
        public string[] Capital;
    }
    class NamePart
    {
        public string Common;
    }
}
