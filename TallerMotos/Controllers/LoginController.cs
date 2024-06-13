using Microsoft.AspNetCore.Mvc;
using TallerMotos.Web.Models;

namespace TallerMotos.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (login == null)
            {
                return View("Error");
            }
            if (login.User.Equals("admin") && login.Password.Equals("123456"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Error en el acceso";
                return View("index");
            }

        }
    }
}
