using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    delegate void CompteurDelegate();
    internal class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Compteur { Nom = "C1", Min = 1, Max = 10, Couleur = ConsoleColor.Cyan, Pause = 2000 };
            var c2 = new Compteur { Nom = "C2", Min = 1, Max = 100, Couleur = ConsoleColor.Green, Pause = 200 };

            var d1 = new CompteurDelegate(c1.Compter);
            var d2 = new CompteurDelegate(c2.Compter);

            d1.BeginInvoke(new AsyncCallback(Retour), "Compteur 1");

            d2.Invoke();
            Console.WriteLine("Fini");

            Console.ReadLine();
        }
        static void Retour(IAsyncResult result)
        {
            var s = result.AsyncState.ToString();
            Console.WriteLine("Fini " + s);
        }
    }
    class Compteur
    {
        public string Nom;
        public int Min;
        public int Max;
        public int Pause;
        public ConsoleColor Couleur = ConsoleColor.White;
        public void Compter()
        {
            for (int i = Min; i <= Max; i++)
            {
                Console.ForegroundColor = Couleur;
                Thread.Sleep(Pause);
                Console.WriteLine(Nom + " " + i);
            }
        }
    }
}
