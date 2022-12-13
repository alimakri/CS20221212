using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Soap;

namespace DemoNullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? i = null;
            List<Personne> p = new List<Personne> { new Personne { Nom = "Ali" }, new Personne { Nom = "Pierre" } };

             // Serialization
            IFormatter formatter1 = new SoapFormatter();
            Stream stream1 = new FileStream("personnes.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter1.Serialize(stream1, p);
            stream1.Close();

            // Déserialization
            IFormatter formatter2 = new SoapFormatter();
            Stream stream2 = new FileStream("personnes.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            Personne obj = (Personne)formatter2.Deserialize(stream2);
            stream2.Close();
        }
    }
    [Serializable]
    class Personne { public string Nom; }
}
