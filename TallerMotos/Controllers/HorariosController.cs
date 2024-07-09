using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;
using X.PagedList;

namespace TallerMotos.Web.Controllers
{
    public class HorariosController : Controller
    {
        private readonly IServiceHorarios _serviceHorarios;
        private readonly IServiceSucursales _serviceSucursales;

        public HorariosController(IServiceHorarios serviceHorarios, IServiceSucursales serviceSucursales)
        {
            _serviceHorarios = serviceHorarios;
            _serviceSucursales = serviceSucursales;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var collection = await _serviceHorarios.ListAsync();
        //    ViewData["Title"] = "Index";
        //    return View(collection);
        //}

        public async Task<ActionResult> Index(int? page)
        {
            var collection = await _serviceHorarios.ListAsync();
            //Cantidad de elementos por página
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
                var @object = await _serviceHorarios.FindByIdAsync(id.Value);
                if (@object == null)
                {
                    throw new Exception("Horarios no existente");
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


        //[HttpGet]
        public async Task<ActionResult> Create()
        {
            //var sucursales = await _serviceSucursales.ListAsync();
            ViewBag.ListaSucursales = await _serviceSucursales.ListAsync(); //new SelectList(sucursales, "ID", "Nombre");

            ViewBag.DiasDeLaSemana = new SelectList(new List<string>
            {
                "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"
            });
            return View();
        }



        // POST: HorariosController/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HorariosDTO dto)
        {
            //Validación del formulario 
            if (!ModelState.IsValid)
            {
                //var sucursales = await _serviceSucursales.ListAsync();
                //ViewBag.ListaSucursales = new SelectList(sucursales, "ID", "Nombre");
                // Lee del ModelState todos los errores que 
                // vienen para el lado del server 
                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                ViewBag.DiasDeLaSemana = new SelectList(new List<string>
                {
                    "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"
                });                
                
                return View();
            }
            //Crear 
            await _serviceHorarios.AddAsync(dto);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ListaSucursales = await _serviceSucursales.ListAsync();

            var HorariosDTO = await _serviceHorarios.GetByIdAsync(id);

            if (HorariosDTO == null)
            {
                return NotFound();
            }
            ViewBag.DiasDeLaSemana = new SelectList(new List<string>
            {
                "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"
            });
            return View(HorariosDTO);
        }

        // POST: HorariosController/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, HorariosDTO dto)
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
                await _serviceHorarios.UpdateAsync(id, dto);
                return RedirectToAction("Index");
            }
        }

    }
}
