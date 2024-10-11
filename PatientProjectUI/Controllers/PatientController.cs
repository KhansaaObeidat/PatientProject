using Microsoft.AspNetCore.Mvc;
using PatientProjectUI.Models.Dto;

namespace PatientProjectUI.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(AddPationtDto addPatient)
        {
            return View();
        }
    }
}
