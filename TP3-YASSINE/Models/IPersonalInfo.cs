using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Data.SQLite;

namespace TP3.Models
{
    public interface IPersonalInfo
    {
        public SQLiteConnection openConnection();
        public List<Person> GetAllPersons();
        public Person? GetPersonById(int ID);
        public Person GetPersonIdByNameAndCountry(string name,string country);
        

    }
}
