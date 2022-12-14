using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new FifaContext();
            var france = new Equipe { Nation = "France" };
            var maroc = new Equipe { Nation = "Maroc" };
            var matchCeSoir = new Match { Local = france, Visiteur = maroc };

            context.Equipes.Add(france);
            context.Equipes.Add(maroc);
            context.Matchs.Add(matchCeSoir);
            context.SaveChanges();
        }
    }
    class FifaContext : DbContext
    {
        public FifaContext() : base("name=FifaDb") { }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Match> Matchs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
    class Equipe
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nation { get; set; }
        public int NPoints { get; set; }
        public ICollection<Match> Matchs { get; set; }
    }
    class Match
    {
        public int Id { get; set; }
        public Equipe Local { get; set; }
        public Equipe Visiteur { get; set; }
        public int ScoreLocal { get; set; }
        public int ScoreVisiteur { get; set; }
    }
}
