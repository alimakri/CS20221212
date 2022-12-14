using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeleEntite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AdvContext();

            var produits = context.Products
                .Where(x => x.ProductSubcategory.ProductCategory.Name == "Bikes")
                .Select(x => new Produit
                {
                    Nom = x.Name,
                    Cat = x.ProductSubcategory.ProductCategory.Name,
                    SousCat = x.ProductSubcategory.Name
                });

            foreach (var p in produits)
            {
                Console.WriteLine(p.Nom + " | " + p.SousCat + " | " + p.Cat);
            }

            // Modif
            var velo = context.Products.FirstOrDefault(x => x.ProductID == 895);
            if (velo != null)
            {
                velo.Name = velo.Name.Replace("Blue", "Red");

                context.Products.Remove(velo);
                try
                {
                    context.SaveChanges();
                }
                catch(Exception ex)
                {

                }
            }

            Console.ReadLine();
        }
    }
    class Produit
    {
        public string Nom;
        public string Cat;
        public string SousCat;

    }
}
