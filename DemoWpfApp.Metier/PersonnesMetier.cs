using System.Net;
using Newtonsoft.Json;

namespace DemoWpfApp.Metier
{
    public class PersonneMetier
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }
        public string Photo { get; set; }
    }

    public class PersonnesMetier : List<PersonneMetier>
    {
        public PersonnesMetier()
        {
            var ClientRest = new WebClient();
            var url = "http://localhost:5278/api/wpfdata";
            var data = ClientRest.DownloadString(url);
            var liste = JsonConvert.DeserializeObject<List<PersonneMetier>>(data);
            liste.ForEach(x => Add(new PersonneMetier
            {
                Id = x.Id,
                Nom = x.Nom,
                Ville = x.Ville,
                Photo = x.Photo
            }));

            //var repo = new Repository();
            //// Travail du DTO
            //repo.GetPersonnes().ForEach(x => Add(new PersonneMetier
            //{
            //    Id = x.Id,
            //    Nom = x.Nom,
            //    Ville = x.Ville,
            //    Photo = x.Photo
            //}));
        }
    }
}
