using Amirmohammad_Asadpour_HW08_Maktab71.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Amirmohammad_Asadpour_HW08_Maktab71.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Person> personList = new List<Person>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            if (personList.Count == 0)
            {
            personList.Add(new Person(123, "Ali"));
            personList.Add(new Person(345, "Hasan"));
            personList.Add(new Person(678, "Reza"));
            personList.Add(new Person(901, "Amir"));
            personList.Add(new Person(234, "Ahmad"));
            }
        }

        public IActionResult Index()
        {
            return View(personList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View("Contact");
        }

        public IActionResult DeleteItem(int id)
        {
            personList.Remove(personList.Find(p => p.Id == id));
            return View("Index", personList);
        }
        
        public IActionResult EditItem(int id)
        {
            return View("Edit", personList.Find(p => p.Id == id));
        }
        
        public IActionResult SubmitEditedItem(int id, string name)
        {
            Person editedPerson = personList.Find(p => p.Id == id);
            if (editedPerson != null)
            {
                editedPerson.Name = name;
            }
            return View("Index", personList);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}