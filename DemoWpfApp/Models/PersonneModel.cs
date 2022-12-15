using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoWpfApp.Metier;

namespace DemoWpfApp.Models
{
    public class PersonneModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }
        public string Photo { get; set; }
    }
    public class PersonnesModel : List<PersonneModel>
    {
        public PersonnesModel()
        {
            var personnesMetier = new PersonnesMetier();
            // Travail du DTO
            personnesMetier.ForEach(x => Add(new PersonneModel
            {
                Id = x.Id,
                Nom = x.Nom,
                Ville = x.Ville,
                Photo = x.Photo
            }));
        }
    }
}
