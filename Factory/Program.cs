using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var liste = new Personnes();
            liste.Add(new Personne { Nom = "Albert", Ville = "Annecy" });
            liste.Add(new Personne { Nom = "Brenda", Ville = "Bordeau" });
            var p = liste[0];
            foreach (var personne in liste)
            {
                Console.WriteLine(personne);
            }
        }
    }
    class Personne
    {
        public string Nom;
        public string Ville;
        public override string ToString()
        {
            return $"{Nom} - {Ville}";
        }
    }
    class Personnes : IEnumerable<Personne>
    {
        private List<Personne> ListePrivee = new List<Personne>();

        internal void Add(Personne p)
        {
            ListePrivee.Add(p);
        }

        public IEnumerator<Personne> GetEnumerator()
        {
            return new PersonneEnumerator(ListePrivee);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonneEnumerator(ListePrivee);
        }

        public Personne this[int index]
        {
            get
            {
                return ListePrivee[index];
            }
        }

    }
    class PersonneEnumerator : IEnumerator<Personne>
    {
        private List<Personne> ListeInterne;
        private int Index = -1;
        public PersonneEnumerator(List<Personne> liste)
        {
            ListeInterne = liste;
        }

        public Personne Current => ListeInterne[Index];

        object IEnumerator.Current => ListeInterne[Index];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            Index++;
            return Index < ListeInterne.Count;
        }

        public void Reset()
        {
            Index = -1;
        }
    }


}
