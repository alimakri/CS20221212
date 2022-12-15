using System.Data;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace WebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WpfData : ControllerBase
    {
        public string Get()
        {
            var list = new List<PersonneDonnees>();
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2019;Integrated Security=True;Encrypt=false";
            cnx.Open();

            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT Person.Person.BusinessEntityID, Person.Person.FirstName, Person.Person.LastName, Person.Address.City
                                FROM Person.Address INNER JOIN
                                     Person.BusinessEntityAddress ON Person.Address.AddressID = Person.BusinessEntityAddress.AddressID INNER JOIN
                                     Person.BusinessEntity ON Person.BusinessEntityAddress.BusinessEntityID = Person.BusinessEntity.BusinessEntityID INNER JOIN
                                     Person.Person ON Person.BusinessEntity.BusinessEntityID = Person.Person.BusinessEntityID";
            cmd.Connection = cnx;
            
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new PersonneDonnees
                {
                    Id = (int)rd["BusinessEntityID"],
                    Nom = rd["FirstName"].ToString(),
                    Ville = rd["City"].ToString()
                });
            }
            rd.Close();
            var json = JsonConvert.SerializeObject(list);
            return json;

            //return @"[
            //         {""id"":1,""nom"":""Albert"",""ville"":""Annecy""},
            //         {""id"":2,""nom"":""Bernard"",""ville"":""Paris""},
            //         {""id"":3,""nom"":""Camille"",""ville"":""Caen""}
            //         ]";
        }
    }
    class PersonneDonnees
    {
        public int Id;
        public string? Nom;
        public string? Ville;
    }
}
