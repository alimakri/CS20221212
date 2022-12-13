using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var b = new Bateau();
            b.Hello();
            b.AfficheDev();
        }
    }
    [DevelopperPar("Ali MAKRI")]
    class Bateau
    {
        [Obsolete("Ne pas utiliser")]
        public void Hello() { }

        public void AfficheDev()
        {
            DevelopperParAttribute att = (DevelopperParAttribute)Attribute.GetCustomAttribute(typeof(Bateau), typeof(DevelopperParAttribute));
            Console.WriteLine(att.Dev);
        }
    }
    class DevelopperParAttribute : Attribute
    {
        public string Dev { get; set; }
        public DevelopperParAttribute(string nom)
        {
            Dev = nom;
        }
    }
}
