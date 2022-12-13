using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodeExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder( "Bonjour tout le monde");
            var n = s.NombreDeMots();
        }

    }
    public static class Outils
    {
        public static int NombreDeMots(this string x)
        {
            return x.Split(' ').Length;
        }
        public static int NombreDeMots(this StringBuilder x)
        {
            return NombreDeMots(x.ToString());
        }

    }
}
