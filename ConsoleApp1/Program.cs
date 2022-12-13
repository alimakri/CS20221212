using System;
using System.Collections.Generic;
using Outils;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Polymorphisme1();
            //Polymorphisme2();
            Polymorphisme3();

            Console.ReadLine();
        }

        private static void Polymorphisme3()
        {
            var a1 = new AutoB();
            var m1 = new MotoB();
            a1.Rouler();
            var saisie = Console.ReadLine();
            IVehicule v;
            if (saisie == "A") v = a1; else v = m1;
            v.Rouler();
        }
        private static void Polymorphisme2()
        {
            AutoA a1 = new AutoA();
            a1.Rouler();

            VehiculeA v;
            v = a1;
            v.Rouler();
        }
        private static void Polymorphisme1()
        {
            Auto a1 = new Auto();
            a1.Rouler();
            Moto m1 = new Moto();
            m1.Rouler();

            Vehicule v;
            v = m1;
            v.Rouler();
        }
    }
    #region Poly1
    public class Vehicule
    {
        public virtual void Rouler() { Console.WriteLine("Le vehicule roule"); }
    }
    public class Auto : Vehicule
    {
        public override void Rouler() { Console.WriteLine("L'auto roule"); }
    }
    public class Moto : Vehicule
    {
        public override void Rouler() { Console.WriteLine("La moto roule"); }
    }
    #endregion

    #region Poly2
    public abstract class VehiculeA
    {
        public abstract void Rouler();
    }
    public class AutoA : VehiculeA
    {
        public override void Rouler() { Console.WriteLine("L'auto roule"); }
    }
    #endregion

    #region poly3
    interface IVehicule
    {
        void Rouler();
    }
    interface IHabitation
    {
        string SeRechauffer();
    }
    public class AutoB : IVehicule, IHabitation
    {
        public void Rouler() { Console.WriteLine("L'auto roule (interface)"); }

        public string SeRechauffer()
        {
            return null;
        }
    }
    public class MotoB : IVehicule
    {
        public void Rouler() { Console.WriteLine("La moto roule (interface)"); } 
    }
    public class Personne
    {
        public void Hello() { }
    }
    public class Employe : Personne
    {
        public new void Hello() { }
    }
    #endregion
}