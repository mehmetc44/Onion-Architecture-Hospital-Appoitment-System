using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Appointment.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Appointment()
        {
            return View();
        }
        public IActionResult CreateAppointment()
        {
            return View();
        }


    }
}
