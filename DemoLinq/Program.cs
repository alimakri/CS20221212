using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var entiers = new List<int>() { 52, 6, 9, 8, 47, 24, 25 };
            var impairs = entiers.Where(x => x % 2 == 1);
            var grandsImpairs = impairs.Where(x => x > 10);

            var pairs = from x in entiers where x % 2 == 0 select x;

            var liste = new List<Personne>
            {
                new Personne {Id=1, Name="Arlette", City = "Annecy"},
                new Personne {Id=2, Name="Braun", City = "Bern"},
                new Personne {Id=3, Name="Charlotte", City = "Annecy"},
            };
            var ps = liste.FirstOrDefault(x => x.City == "Annecy");

            IEqualityComparer<Ville> comparer = new ComparerVille();
            var villes = liste
                .Select(x => new Ville { Name = x.City })
                .Distinct<Ville>(comparer)
                .OrderBy(x => x.Name)
                .ToArray();
        }
    }
    class ComparerVille : IEqualityComparer<Ville>
    {
        public bool Equals(Ville x, Ville y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Ville obj)
        {
            return base.GetHashCode();
        }
    }
    class Personne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
    class Ville
    {
        public string Name;
        public override string ToString()
        {
            return Name;
        }
    }
}
