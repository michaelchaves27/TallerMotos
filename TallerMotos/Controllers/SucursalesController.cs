using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TallerMotos.Application.Services.Implementations;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;
using X.PagedList;

namespace TallerMotos.Web.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly IServiceSucursales _serviceSucursales;
        public SucursalesController(IServiceSucursales serviceSucursales)
        {
            _serviceSucursales = serviceSucursales;
        }
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceSucursales.ListAsync();
            ViewData["Title"] = "Index";
            return View(collection);
        }

        public async Task<ActionResult> TablaSucursales(int? page)
        {
            var collection = await _serviceSucursales.ListAsync();
            //Cantidad de elementos por página
            return View(collection.ToPagedList(page ?? 1, 5));
        }

        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }
                var @object = await _serviceSucursales.FindByIdAsync(id.Value);
                if (@object == null)
                {
                    throw new Exception("Sucursales no existente");
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
