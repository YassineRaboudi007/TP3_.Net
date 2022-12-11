using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using TP3.Models;

namespace TP3_YASSINE.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonalInfo _peopleRepo;

        public PersonController(IPersonalInfo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }
        // GET: PersonController
        public ActionResult Index()
        {
            List<Person> people = _peopleRepo.GetAllPersons();
            return View(people);
        }

        public ActionResult all()
        {
            List<Person> people = _peopleRepo.GetAllPersons();
            return View(people);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            Person? person = _peopleRepo.GetPersonById(id);

            if (person.Id == null)
            {
                Console.WriteLine("empty if",person.Id);
                ViewBag.Message = "Error";
            }

            return View(person);
        }

        [HttpGet]
        public ActionResult search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult search(string name,string country)
        {
            Console.WriteLine("name"+ name);
            Console.WriteLine("country" + country);
            Person p = _peopleRepo.GetPersonIdByNameAndCountry(name, country);
            Console.WriteLine("country" + p.Id);

            Person person = _peopleRepo.GetPersonById(0);
            return Redirect($"/Person/{p.Id}");

        }
    }
}
