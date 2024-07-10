using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Implementations;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;
using X.PagedList;

namespace TallerMotos.Web.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly IServiceSucursales _serviceSucursales;
        private readonly IServiceUsuarios _serviceUsuarios;

        public SucursalesController(IServiceSucursales serviceSucursales, IServiceUsuarios serviceUsuarios)
        {
            _serviceSucursales = serviceSucursales;
            _serviceUsuarios = serviceUsuarios;
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
                    return RedirectToAction("Index");
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


        //[HttpGet]
        public async Task<IActionResult> Create()
        {
            var usuarios = await _serviceUsuarios.ListAsync();
            ViewBag.ListaUsuarios = new MultiSelectList(
            items: usuarios,
            dataValueField: nameof(UsuariosDTO.ID),
            dataTextField: nameof(UsuariosDTO.Nombre)
            );
            return View();
        }



        // POST: SucursalesController/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SucursalesDTO dto, string[] selectedUsuarios)
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
            await _serviceSucursales.AddAsync(dto, selectedUsuarios);
            return RedirectToAction("TablaSucursales");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sucursalesDTO = await _serviceSucursales.GetByIdAsync(id);
            if (sucursalesDTO == null)
            {
                return NotFound();
            }
            //Lista de Categorias- relacion muchos a muchos
            var usuarios = await _serviceUsuarios.ListAsync();
            //Valores a seleccionar de las categorias
            var usuSelected = sucursalesDTO.Usuarios.Select(x => x.ID.ToString()).ToList();
            //DropdownList
            ViewBag.ListaUsuarios = new MultiSelectList(
            items: usuarios,
           dataValueField: nameof(UsuariosDTO.ID),
           dataTextField: nameof(UsuariosDTO.Nombre),
           selectedValues: usuSelected
            );
            return View(sucursalesDTO);
        }

        // POST: SucursalesController/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SucursalesDTO dto, string[] selectedUsuarios)
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
                await _serviceSucursales.UpdateAsync(id, dto, selectedUsuarios);
                return RedirectToAction("TablaSucursales");
            }
        }

    }
}
