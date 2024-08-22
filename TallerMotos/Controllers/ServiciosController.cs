using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;
using X.PagedList;

namespace TallerMotos.Web.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly IServiceServicios _serviceServicios;
        public ServiciosController(IServiceServicios serviceServicios)
        {
            _serviceServicios = serviceServicios;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            var collection = await _serviceServicios.ListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                collection = collection.Where(s => s.Nombre.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewData["Title"] = "Index";
            return View(collection.ToPagedList(page ?? 1, 5));
        }


        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var @object = await _serviceServicios.FindByIdAsync(id.Value);
                if (@object == null)
                {
                    throw new Exception("Servicios no existente");
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

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Create()
        {
            // Lista de cilindrajes disponibles
            var cilindrajes = new List<SelectListItem>
            {
                new SelectListItem { Value = "125cc", Text = "125cc" },
                new SelectListItem { Value = "250cc", Text = "250cc" },
                new SelectListItem { Value = "500cc", Text = "500cc" },
                new SelectListItem { Value = "Todas", Text = "Todas" }
            };

            ViewBag.Cilindrajes = new SelectList(cilindrajes, "Value", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ServiciosDTO dto)
        {
            //Validación del formulario
            if (!ModelState.IsValid)
            {
                // Lee del ModelState todos los errores que
                // vienen para el lado del server
                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }
            //Crear
            await _serviceServicios.AddAsync(dto);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrador")]
        // Método GET para Editar
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ServiciosDto = await _serviceServicios.GetByIdAsync(id);
            if (ServiciosDto == null)
            {
                return NotFound();
            }

            // Lista de cilindrajes disponibles
            var cilindrajes = new List<SelectListItem>
            {
                new SelectListItem { Value = "125cc", Text = "125cc" },
                new SelectListItem { Value = "250cc", Text = "250cc" },
                new SelectListItem { Value = "500cc", Text = "500cc" },
                new SelectListItem { Value = "Todas", Text = "Todas" }
            };

            ViewBag.Cilindrajes = new SelectList(cilindrajes, "Value", "Text");

            return View(ServiciosDto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ServiciosDTO dto)
        {
            if (!ModelState.IsValid)
            {
                // Lee del ModelState todos los errores que 
                // vienen para el lado del server 
                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }
            else
            {
                //Actualizar 
                await _serviceServicios.UpdateAsync(id, dto);
                return RedirectToAction("Index");
            }
        }
    }
}
