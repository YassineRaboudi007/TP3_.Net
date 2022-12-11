using System.Data.SQLite;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace TP3.Models
{
    public class Personal_Info : IPersonalInfo
    {

        private string _connString;

        public Personal_Info(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("SQLite");
            ShowData();
        }

        public SQLiteConnection openConnection()
        {
            SQLiteConnection sqlConn = new SQLiteConnection(_connString);

            try
            {
                sqlConn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sqlConn;

        }

        public void ShowData()
        {
            SQLiteConnection conn = openConnection();
            if (conn.State == ConnectionState.Closed) return;

            SQLiteCommand SQLiteCommand = conn.CreateCommand();
            SQLiteCommand.CommandText = "SELECT * FROM personal_info";
            SQLiteDataReader sqlite_datareader = SQLiteCommand.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                object Id = (int)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("Id"));
                object first_name = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("first_name"));
                object last_name = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("last_name"));
                object email = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("email"));
                /*
                 * Some Error with time format
                 * object date_birth = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("date_birth"));
                */
                object image = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("image"));
                object country = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("country"));
                Console.WriteLine($"Id {Id} Firts Name {first_name} Last Name {last_name} Email {email} Img {image}" +
                    $"Country {country}");
            }

            conn.Close();

        }

        public List<Person> GetAllPersons()
        {
            SQLiteConnection conn = openConnection();
            if (conn.State == ConnectionState.Closed) return null;

            SQLiteCommand SQLiteCommand = conn.CreateCommand();
            SQLiteCommand.CommandText = "SELECT * FROM personal_info";
            SQLiteDataReader sqlite_datareader = SQLiteCommand.ExecuteReader();
            List<Person> people = new List<Person>() ;

            while (sqlite_datareader.Read())
            {
                Person person = new Person();
                person.Id = (int)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("Id"));

                person.First_Name = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("first_name"));
                person.Last_Name = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("last_name"));
                person.Email = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("email"));
                /*
                 * Some Error with time format
                 * object date_birth = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("date_birth"));
                */
                person.Image = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("image"));
                person.Country= (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("country"));
                people.Add(person);

            }

            conn.Close();
            return people;

        }

        public Person GetPersonById(int ID)
        {
            SQLiteConnection conn = openConnection();
            if (conn.State == ConnectionState.Closed) return null;

            SQLiteCommand SQLiteCommand = conn.CreateCommand();
            SQLiteCommand.CommandText = "SELECT * FROM personal_info where ID = ($ID)";
            SQLiteCommand.Parameters.AddWithValue("$ID", ID);

            SQLiteDataReader sqlite_datareader = SQLiteCommand.ExecuteReader();
            Person person = new Person();

            while (sqlite_datareader.Read())
            {
                person.Id = (int)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("Id"));
                person.First_Name = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("first_name"));
                person.Last_Name = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("last_name"));
                person.Email = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("email"));
                /*
                 * Some Error with time format
                 * object date_birth = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("date_birth"));
                */
                Console.WriteLine("sqlite_datareader", (int)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("Id")));

                person.Image = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("image"));
                person.Country = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("country"));
            }

            conn.Close();
            return person;
        }

        public Person? GetPersonIdByNameAndCountry(string name,string country)
        {
            SQLiteConnection conn = openConnection();
            if (conn.State == ConnectionState.Closed) return null;

            SQLiteCommand SQLiteCommand = conn.CreateCommand();
            SQLiteCommand.CommandText = "SELECT * FROM personal_info where first_name = ($name) and country = ($country)";
            SQLiteCommand.Parameters.AddWithValue("$name", name);
            SQLiteCommand.Parameters.AddWithValue("$country", country);

            SQLiteDataReader sqlite_datareader = SQLiteCommand.ExecuteReader();
            Person person = new Person();

            while (sqlite_datareader.Read())
            {
                person.Id = (int)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("Id"));
                person.First_Name = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("first_name"));
                person.Last_Name = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("last_name"));
                person.Email = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("email"));
                /*
                 * Some Error with time format
                 * object date_birth = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("date_birth"));
                */
                Console.WriteLine("sqlite_datareader", (int)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("Id")));

                person.Image = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("image"));
                person.Country = (string)sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("country"));
            }


            conn.Close();
            return person;

        }


    }
}
