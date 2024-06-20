using Microsoft.AspNetCore.Mvc;

namespace TallerMotos.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
