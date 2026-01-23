using Microsoft.AspNetCore.Mvc;

namespace Appointment.WebUI.Controllers
{
    public class AuthController : Controller
    {
        // GET: AuthController
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet("/register")]
        public ActionResult Register()
        {
            return View();
        }

    }
}
