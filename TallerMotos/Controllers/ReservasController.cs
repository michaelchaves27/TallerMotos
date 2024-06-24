using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;

namespace TallerMotos.Web.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IServiceReservas _serviceReservas;
        private readonly IServiceSucursales _serviceSucursales;
        public ReservasController(IServiceReservas serviceReservas, IServiceSucursales serviceSucursales)
        {
            _serviceReservas = serviceReservas;
            _serviceSucursales = serviceSucursales;

        }
        //public async Task<IActionResult> Index()
        //{
        //    var collection = await _serviceReservas.ListAsync();
        //    ViewData["Title"] = "Index";
        //    return View(collection);
        //}

        public async Task<IActionResult> Index(int? idSucursal)
        {
            var sucursales = await _serviceSucursales.ListAsync();
            ViewBag.Sucursales = sucursales;
            ICollection<ReservasDTO> collection;

            if (idSucursal.HasValue)
            {
                collection = await _serviceReservas.ListBySucursalAsync(idSucursal.Value);
            }
            else
            {
                collection = await _serviceReservas.ListAsync();
            }

            ViewData["Title"] = "Index";
            ViewData["SucursalId"] = idSucursal;

            return View(collection);
        }


        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }
                var @object = await _serviceReservas.FindByIdAsync(id.Value);
                if (@object == null)
                {
                    throw new Exception("Reservas no existente");
                }
                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
