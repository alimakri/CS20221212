using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outils
{
    public class Voiture
    {
    }
    public class Personne : IDisposable
    {
        public string Nom;
        public DateTime DateNaissance;
        public override string ToString()
        {
            return Nom;
        }
        public int CalculAge()
        {
            return 0;
        }

        public void Dispose()
        {
           
        }
        ~Personne()
        {

        }
    }
    public class Employe : Personne { }
}
