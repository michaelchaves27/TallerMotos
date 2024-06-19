using Microsoft.AspNetCore.Mvc;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;

//using X.PagedList;
namespace TallerMotos.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IServiceProductos _serviceProductos;
        // private readonly IServiceAutor _serviceAutor;
        //private readonly IServiceCategoria _serviceCategoria;
        public ProductosController(IServiceProductos serviceProductos)//, 
                                                                      //IServiceCategoria serviceCategoria)
        {
            _serviceProductos = serviceProductos;
            //  _serviceAutor = serviceAutor;
            //  _serviceCategoria = serviceCategoria;
        }
        // GET: ProductosController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var collection = await _serviceProductos.ListAsync();

            return View(collection);
        }
        /*public async Task<ActionResult> IndexAdmin(int? page)
        {
            var collection = await _serviceProductos.ListAsync();
            //Cantidad de elementos por página
            return View(collection.ToPagedList(page ?? 1, 5));
        }*/
        // GET: ProductosController/Details/5
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
                    throw new Exception("Productos no existente");
                }
                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // GET: ProductosController/Create
        /* public async Task<ActionResult> Create()
         {
             //Lista de Autores
            // ViewBag.ListAutor = await _serviceAutor.ListAsync();
             //Lista de Categorias- relacion muchos a muchos
             var categorias = await _serviceCategoria.ListAsync();
          //   ViewBag.ListCategorias = new MultiSelectList(
           //  items: categorias,
           // dataValueField: nameof(CategoriaDTO.IdCategoria),
            dataTextField: nameof(CategoriaDTO.Nombre)
             );
             //ViewBag.ListCategorias = new MultiSelectList(
             // categorias,
             // "IdCategoria",
             // "Nombre"
             // );
             return View();
         }*/
        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductosDTO dto, IFormFile imageFile, string[]
       selectedCategorias)
        {
            //Gestión de imagen
            MemoryStream target = new MemoryStream();

            // Cuando es Insert Image viene en null porque se pasa diferente
            /* if (dto.Imagen == null)
             {
                 if (imageFile != null)
                 {
                     imageFile.OpenReadStream().CopyTo(target);
                     dto.Imagen = target.ToArray();
                     //Quitar la validación de la imagen
                     ModelState.Remove("Imagen");
                 }
             }*/
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
            await _serviceProductos.AddAsync(dto, selectedCategorias);
            return RedirectToAction("IndexAdmin");
        }
        // GET: ProductosController/Edit/5
        /*  public async Task<ActionResult> Edit(int id)
          {
            //  var @object = await _serviceProductos.FindByIdAsync(id);
              //Lista de Autores
           //   ViewBag.ListAutor = await _serviceAutor.ListAsync();
              //Lista de Categorias- relacion muchos a muchos
             // var categorias = await _serviceCategoria.ListAsync();
              //Valores a seleccionar de las categorias
             // var catSelected = @object.IdCategoria.Select(x => x.IdCategoria.ToString()).ToList();
              //DropdownList
            //  ViewBag.ListCategorias = new MultiSelectList(
            //  items: categorias,
           //  dataValueField: nameof(CategoriaDTO.IdCategoria),
           //  dataTextField: nameof(CategoriaDTO.Nombre),
          //   selectedValues: catSelected
              );
              return View(@object);
          }*/
        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductosDTO dto, string[]
       selectedCategorias)
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
                await _serviceProductos.UpdateAsync(id, dto, selectedCategorias);
                return RedirectToAction("IndexAdmin");
            }
        }
        // GET: ProductosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var @object = await _serviceProductos.FindByIdAsync(id);
            return View(@object);
        }
        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            await _serviceProductos.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}