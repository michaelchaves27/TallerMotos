using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;

namespace TallerMotos.Web.Controllers
{
    public class DetalleFacturaController : Controller
    {
        private readonly IServiceDetalleFactura _serviceDetalleFactura;
        public DetalleFacturaController(IServiceDetalleFactura serviceDetalleFactura)
        {
            _serviceDetalleFactura = serviceDetalleFactura;
        }
        public async Task<IActionResult> IndexDetalle(int id)
        {
            var collection = await _serviceDetalleFactura.ListAsync(id);
            ViewData["Title"] = "IndexDetalle";
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
