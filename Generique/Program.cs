using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new ActiviteSportive<Foot>();
            var balle=a.TypeBalle();
            Console.WriteLine(balle);
            Console.ReadLine();
        }
    }
    class ActiviteSportive<T> where T : SportAvecBalle, new()
    {
        public string TypeBalle()
        {
            var f = new T();
            return f.TypeBalle();
        }
    }
    public class Foot : SportAvecBalle
    {
        public override string TypeBalle() { return "Ballon"; }
    }
    public class Rugby : SportAvecBalle
    {
        public override string TypeBalle() { return "Oval"; }
    }
    public class SportAvecBalle
    {
        public virtual string TypeBalle() { return "?"; }
    }
    public class Natation
    {
    }
}
