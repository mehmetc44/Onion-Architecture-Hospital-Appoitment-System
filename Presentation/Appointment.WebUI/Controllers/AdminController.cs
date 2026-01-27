using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        [HttpGet("/admin/dashboard")]
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet("/admin/hospitals")]
        public ActionResult Hospitals()
        {
            return View();
        }

    }
}
