using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaCentrale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new Centrale();
            c.Refroidir();
            Console.ReadLine();
        }
    }
    struct PompeArgs
    {
        public int Temperature;
        public int Pression;
    }
    delegate bool PompeDelegue(PompeArgs args);
    class Centrale
    {
        //private ArrayList ListePompe = new ArrayList();
        //private List<PompeDelegue> ListeDelegue = new List<PompeDelegue>();
        event PompeDelegue FaitChaud;
        public Centrale()
        {
            var p1 = new PompeHydraulique();
            var p2 = new PompeHydraulique();
            var p3 = new PompeElectrique();
            var p4 = new PompeManuelle();

            var d1 = new PompeDelegue(x  =>
            {
                Console.WriteLine("La pompe hydraulique et enclenchée avec une température de " + x.Temperature);
                return true;
            });
            var d2 = new PompeDelegue(p2.Refroidir);
            var d3 = new PompeDelegue(p3.Refroidir);
            var d4 = new PompeDelegue(p4.Refroidir);

            //ListePompe.Add(p1);
            //ListePompe.Add(p2);
            //ListePompe.Add(p3);
            //ListePompe.Add(p4);

            //ListeDelegue.Add(d1);
            //ListeDelegue.Add(d2);
            //ListeDelegue.Add(d3);
            //ListeDelegue.Add(d4);

            FaitChaud += d1;
            FaitChaud += d2;
            FaitChaud += d3;
            FaitChaud += d4;
        }
        public void Refroidir()
        {
            //foreach(var p in ListePompe)
            //{
            //    if (p is PompeHydraulique) ((PompeHydraulique)p).Refroidir();
            //    else if (p is PompeElectrique) ((PompeElectrique)p).Refroidir();
            //    else throw new Exception("Pompe non repertoriée");
            //}

            //foreach (var d in ListeDelegue)
            //{
            //    PompeArgs args;
            //    args.Temperature = 3000;
            //    args.Pression = 500;
            //    d.Invoke(args);
            //}

            PompeArgs args;
            args.Temperature = 3000;
            args.Pression = 500;
            FaitChaud(args);
        }

    }
    class PompeHydraulique
    {
        public bool Refroidir(PompeArgs args)
        {
            Console.WriteLine("La pompe hydaulique et enclenchée");
            return true;
        }
    }
    class PompeElectrique
    {
        public bool Refroidir(PompeArgs args)
        {
            Console.WriteLine("La pompe electrique et enclenchée");
            return true;
        }
    }
    class PompeManuelle
    {
        public bool Refroidir(PompeArgs args)
        {
            Console.WriteLine("La pompe manuelle et enclenchée");
            return true;
        }
    }
}
