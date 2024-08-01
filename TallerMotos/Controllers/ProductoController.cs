using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Implementations;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;
using X.PagedList;

namespace TallerMotos.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IServiceProductos _serviceProductos;
        private readonly IServiceCategoria _serviceCategoria;

        // Asegúrate de que solo tienes un constructor
        public ProductosController(IServiceProductos serviceProductos, IServiceCategoria serviceCategoria)
        {
            _serviceProductos = serviceProductos;
            _serviceCategoria = serviceCategoria;
        }

        // Métodos del controlador
        // [HttpGet]
        public async Task<ActionResult> Index()
        {
            var collection = await _serviceProductos.ListAsync();
            return View(collection);
        }

        [Authorize(Roles = "Administrador,Encargado")]
        public async Task<ActionResult> TablaProductos(int? page)
        {
            var collection = await _serviceProductos.ListAsync();
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
                var @object = await _serviceProductos.FindByIdAsync(id.Value);
                if (@object == null)
                {
                    throw new Exception("Producto no existente");
                }
                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IActionResult GetProductoByID(int filtro)
        {

            var collections = _serviceProductos.FindByIdAsync(filtro).GetAwaiter().GetResult();

            return Json(collections);
        }
        public IActionResult ErrorHandler(string messageJson)
        {
            var errorMessages = JsonConvert.
                DeserializeObject<ErrorMiddlewareViewModel>(messageJson);
            ViewBag.ErrorMessages = errorMessages;
            return View("ErrorHandler");
        }

        //[Authorize(Roles = "Administrador,Encargado")]
        // [HttpGet]
        public async Task<ActionResult> Create()
        {
            // var ListaCategorias = await _serviceCategoria.ListAsync();
            // ViewBag.ListaCategorias = new MultiSelectList(ListaCategorias, "IdCategoria", "Nombre");
            ViewBag.ListaCategorias = await _serviceCategoria.ListAsync();
            return View();
        }

        //[Authorize(Roles = "Administrador,Encargado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductosDTO dto)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            await _serviceProductos.AddAsync(dto);
            return RedirectToAction("TablaProductos");
        }

        //[Authorize(Roles = "Administrador,Encargado")]
        // [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productosDTO = await _serviceProductos.FindByIdAsync(id);
            if (productosDTO == null)
            {
                return NotFound();
            }
            ViewBag.ListaCategorias = await _serviceCategoria.ListAsync();
            // //Lista de Categorias- relacion muchos a muchos
            // var categorias = await _serviceCategoria.ListAsync();
            // //Valores a seleccionar de las categorias
            // var catSelected = await _serviceCategoria.FindByIdAsync(productosDTO.IDCategoria);
            // //DropdownList

            // ViewBag.ListaCategorias = await _serviceCategoria.ListAsync();
            // ViewBag.ListaCategorias = new MultiSelectList(
            // items: categorias,
            //dataValueField: nameof(CategoriaDTO.ID),
            //dataTextField: nameof(CategoriaDTO.Nombre),
            //selectedValues: catSelected.Nombre
            // );
            return View(productosDTO);
        }

        //[Authorize(Roles = "Administrador,Encargado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductosDTO dto)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            await _serviceProductos.UpdateAsync(dto);
            return RedirectToAction("TablaProductos");
        }


        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Delete(int id)
        {
            var @object = await _serviceProductos.FindByIdAsync(id);
            return View(@object);
        }

        [Authorize(Roles = "Administrador")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            await _serviceProductos.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
