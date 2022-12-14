using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natif
{
    internal class Program
    {
        private static DataSet Ds = new DataSet();
        private static SqlDataAdapter Da = new SqlDataAdapter();

        static void Main(string[] args)
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2019;Integrated Security=True";
            cnx.Open();

            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnx;
            cmd.CommandText = "GetTopN";
            cmd.Parameters.Add(new SqlParameter("data", @"<personnes><personne id=""1""/><personne id=""13""/><personne id=""26""/></personnes>"));
            // select BusinessEntityID, FirstName, LastName from Person.Person where BusinessEntityID < 10
            /*
             *ALTER PROC [dbo].[GetTopN](@data xml)
                AS
                select 
	                T.N.value('@id[1]', 'int') id,
	                T.N.value('ville[1]', 'nvarchar(MAX)') City
                into #t
                from 
	                @data.nodes('personnes/personne') as T(N)

                select BusinessEntityID, FirstName, LastName from Person.Person 
                where BusinessEntityID in (select id from #t)
                GO
             */

            //ModifModeConnecte(cnx, 1);
            ModeConnecte(cmd);

            //ModeDeconnecte(cmd);
            //ModifModeDeconnecte(1);

            Console.ReadLine();
        }

        private static void ModifModeDeconnecte( int id)
        {
            var sanchez = Ds.Tables[0].AsEnumerable().Where(x => x.Field<int>("BusinessEntityId") == id).FirstOrDefault();
            sanchez["FirstName"] = "Pierre";
            Da.Update(Ds);
        }

        private static void ModifModeConnecte(SqlConnection cnx, int id)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnx;
            cmd.CommandText = $"update Person.Person set FirstName='Pablo' where BusinessEntityID={id}";
            cmd.ExecuteNonQuery();
        }

        private static void ModeDeconnecte(SqlCommand cmd)
        {
            SqlCommandBuilder bd = new SqlCommandBuilder(Da);
            Da.SelectCommand = cmd;
            Da.Fill(Ds);
            foreach (DataRow row in Ds.Tables[0].Rows)
            {
                Console.WriteLine("{0} : {1} {2}", row["BusinessEntityID"], row["FirstName"], row["LastName"]);
            }
        }

        private static void ModeConnecte(SqlCommand cmd)
        {
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine("{0} : {1} {2}", rd["BusinessEntityID"], rd["FirstName"], rd["LastName"]);
            }
            rd.Close();

        }
    }
}
