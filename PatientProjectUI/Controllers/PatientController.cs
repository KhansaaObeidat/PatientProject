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
       
           public IActionResult EditPatient()
           {



               return View();

           }  public IActionResult DeletePatient()
           {
               return View();

           }
         
    }
}
