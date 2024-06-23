using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;

namespace TallerMotos.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IServiceUsuarios _serviceUsuarios;
        public UsuariosController(IServiceUsuarios serviceUsuarios)
        {
            _serviceUsuarios = serviceUsuarios;
        }
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceUsuarios.ListAsync();
            ViewData["Title"] = "Index";
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
                var @object = await _serviceUsuarios.FindByIdAsync(id.Value);
                if (@object == null)
                {
                    throw new Exception("Usuarios no existente");
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
