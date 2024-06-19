using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;


namespace TallerMotos.Web.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IServiceFacturas _serviceFactura;
        public FacturaController(IServiceFacturas serviceFactura)
        {
            _serviceFactura = serviceFactura;
        }
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceFactura.ListAsync();
            ViewData["Title"] = "Index";
            return View(collection);
        }
        public IActionResult ErrorHandler(string messageJson)
        {
            var errorMessages = JsonConvert.
                DeserializeObject<ErrorMiddlewareViewModel>(messageJson);
            ViewBag.ErrorMessages = errorMessages;
            return View("ErrorHandler");
        }
    }
}
