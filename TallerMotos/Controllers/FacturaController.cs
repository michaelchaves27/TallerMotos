﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Web.Models;
using X.PagedList;
using JsonSerializer = System.Text.Json.JsonSerializer;



namespace TallerMotos.Web.Controllers
{
    [Authorize]
    public class FacturaController : Controller
    {
        private readonly IServiceFacturas _serviceFactura;
        private readonly IServiceProductos _serviceProductos;
        private readonly IServiceSucursales _serviceSucursales;
        private readonly IServiceServicios _serviceServicios;
        private readonly IServiceUsuarios _serviceUsuarios;
        public FacturaController(IServiceFacturas serviceFactura, IServiceProductos serviceProductos, IServiceSucursales serviceSucursales, IServiceServicios serviceServicios, IServiceUsuarios serviceUsuarios)
        {
            _serviceFactura = serviceFactura;
            _serviceProductos = serviceProductos;
            _serviceSucursales = serviceSucursales;
            _serviceServicios = serviceServicios;
            _serviceUsuarios = serviceUsuarios;
        }
        public async Task<IActionResult> Index(int? page, DateOnly? fecha)
        {
            var collection = await _serviceFactura.ListAsync();
            ViewBag.ListaUsuarios = await _serviceUsuarios.ListAsync();

            if (fecha.HasValue)
            {
                collection = collection.Where(f => f.Fecha == fecha.Value).ToList();
                ViewData["fecha"] = fecha.Value.ToString("yyyy-MM-dd");
            }

            ViewData["Title"] = "Index";
            return View(collection.ToPagedList(page ?? 1, 5));
        }
        public IActionResult ErrorHandler(string messageJson)
        {
            var errorMessages = JsonConvert.
                DeserializeObject<ErrorMiddlewareViewModel>(messageJson);
            ViewBag.ErrorMessages = errorMessages;
            return View("ErrorHandler");
        }
        public async Task<ActionResult> Create()
        {
            // var ListaCategorias = await _serviceCategoria.ListAsync();
            // ViewBag.ListaCategorias = new MultiSelectList(ListaCategorias, "IdCategoria", "Nombre");
            ViewBag.ListaProductos = await _serviceProductos.ListAsync();
            ViewBag.ListaSucursales = await _serviceSucursales.ListAsync();
            ViewBag.ListaServicios = await _serviceServicios.ListAsync();
            ViewBag.ListaUsuarios = await _serviceUsuarios.ListAsync();
            ViewBag.ListaEstados = new List<string> { "Proforma", "Cancelada", "Pendiente", "Anulada" };
            //Número de factura siguiente posible
            var nextReceiptNumber = await _serviceFactura.GetNextNumberOrden();
            ViewBag.CurrentReceipt = nextReceiptNumber;
            TempData["CartShopping"] = null;
            TempData.Keep();

            return View();
        }

        //[Authorize(Roles = "Administrador,Encargado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FacturaDTO dto)
        {

            string json;

            var cliente = await _serviceUsuarios.FindByIdAsync(dto.IDUsuario);

            if (cliente == null)
            {
                TempData.Keep();
                return BadRequest("Cliente No existe");
            }

            if (ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }
            json = (string)TempData["CartShopping"]!;

            if (string.IsNullOrEmpty(json))
            {
                return BadRequest("No hay datos por facturar");
            }
            var lista = System.Text.Json.JsonSerializer.Deserialize<List<DetalleFacturaDTO>>(json!)!;
            //Agregar datos faltantes a la orden
            dto.ID = 0;
            //dto.IDUsuario = 2;
            //dto.IDSucursal = 3;
            //dto.Estado = "Proforma";
            dto.Fecha = DateOnly.Parse(DateTime.Today.ToString("dd-MM-yyyy"));
            dto.DetalleFactura = lista;
            dto.Total = "" + dto.DetalleFactura.Sum(p => Convert.ToDecimal(p.Total));
            dto.Impuesto = "" + dto.DetalleFactura.Sum(p => Convert.ToDecimal(p.Impuesto));
            dto.SubTotal = "" + dto.DetalleFactura.Sum(p => Convert.ToDecimal(p.SubTotal));

            await _serviceFactura.AddAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddProducto(int id, int cantidad)
        {

            DetalleFacturaDTO detalle = new DetalleFacturaDTO();
            List<DetalleFacturaDTO> lista = new List<DetalleFacturaDTO>();
            string json = "";

            var Producto = await _serviceProductos.FindByIdAsync(id);
            DetalleFacturaDTO item = new DetalleFacturaDTO();
            //Cantidad de item a guardar
            detalle.Cantidad = "" + cantidad;
            if (TempData["CartShopping"] != null)
            {
                json = (string)TempData["CartShopping"]!;
                lista = JsonSerializer.Deserialize<List<DetalleFacturaDTO>>(json!)!;
                //Buscar si existe el Libro en la compra
                item = lista.FirstOrDefault(o => int.Parse(o.Codigo) == id);
                if (item != null)
                {
                    detalle.Cantidad = "" + (int.Parse(detalle.Cantidad) + cantidad);

                }
            }
            // Validar que la cantidad en stock sea suficiente a la solicitada
            //if (detalle.Cantidad > Producto.Cantidad)
            //{
            //    return BadRequest("No hay inventario suficiente!");
            //}

            if (item != null && item.Cantidad != null)
            {
                //Actualizar cantidad de libro existente
                item.Cantidad = "" + (int.Parse(item.Cantidad) + cantidad);
                item.SubTotal = "" + int.Parse(item.Cantidad) * Convert.ToDecimal(Producto.Precio);
            }
            else
            {
                detalle.IDFactura = 0;
                detalle.Total = "0";
                detalle.Impuesto = "0";
                detalle.Codigo = "" + Producto.ID;
                detalle.Nombre = Producto.Nombre;
                detalle.Cantidad = "" + cantidad;
                detalle.Precio = Producto.Precio;
                var precio = Convert.ToDecimal(Producto.Precio);
                var cant = cantidad;
                var sub = (precio * cant);
                //Falta impuesto
                detalle.SubTotal = "" + sub; //""+(int.Parse(detalle.Precio) * int.Parse(detalle.Cantidad));
                detalle.Impuesto = "" + (Convert.ToDecimal(detalle.SubTotal) * Convert.ToDecimal(0.13));
                detalle.Total = "" + (Convert.ToDecimal(detalle.Impuesto) + Convert.ToDecimal(detalle.SubTotal));
                //Agregar al carrito de compras
                lista.Add(detalle);
            }
            json = JsonSerializer.Serialize(lista);
            TempData["CartShopping"] = json;




            TempData.Keep();
            return PartialView("_DetailFactura", lista);
        }

        public async Task<IActionResult> AddServicio(int id)
        {
            // Inicializar el objeto y lista
            DetalleFacturaDTO detalle = new DetalleFacturaDTO();
            List<DetalleFacturaDTO> lista = new List<DetalleFacturaDTO>();
            string json = "";

            // Obtener el servicio basado en el ID
            var Servicios = await _serviceServicios.FindByIdAsync(id);

            // Verificar si hay un carrito de compras en TempData
            if (TempData["CartShopping"] != null)
            {
                json = (string)TempData["CartShopping"];
                lista = JsonSerializer.Deserialize<List<DetalleFacturaDTO>>(json) ?? new List<DetalleFacturaDTO>();

                // Buscar el item en la lista
                var item = lista.FirstOrDefault(o => int.Parse(o.Codigo) == id);

                if (item != null)
                {
                    // Actualizar cantidad y subtotal si el servicio ya está en la lista
                    item.Cantidad = "" + (Convert.ToInt32(item.Cantidad) + 1); // Suponiendo cantidad 1
                    item.SubTotal = "" + (Convert.ToDecimal(item.Cantidad) * Convert.ToDecimal(Servicios.Precio));
                }
                else
                {
                    // Agregar nuevo servicio a la lista
                    detalle.IDFactura = 0;
                    detalle.Total = "0";
                    detalle.Impuesto = "0";
                    detalle.Codigo = "" + Servicios.ID;
                    detalle.Nombre = Servicios.Nombre;
                    detalle.Precio = Servicios.Precio;

                    // Suponiendo cantidad 1
                    var precio = Convert.ToDecimal(Servicios.Precio);
                    var cant = 1;
                    var sub = precio * cant;

                    detalle.SubTotal = "" + sub;
                    detalle.Impuesto = "" + (sub * 0.13m); // Asumiendo impuesto del 13%
                    detalle.Total = "" + (Convert.ToDecimal(detalle.Impuesto) + sub);

                    // Agregar al carrito de compras
                    lista.Add(detalle);
                }
            }
            else
            {
                // Si no hay carrito de compras, inicializar con un nuevo carrito
                detalle.IDFactura = 0;
                detalle.Total = "0";
                detalle.Impuesto = "0";
                detalle.Codigo = "" + Servicios.ID;
                detalle.Nombre = Servicios.Nombre;
                detalle.Precio = Servicios.Precio;

                var precio = Convert.ToDecimal(Servicios.Precio);
                var cant = 1;
                var sub = precio * cant;

                detalle.SubTotal = "" + sub;
                detalle.Impuesto = "" + (sub * 0.13m); // Asumiendo impuesto del 13%
                detalle.Total = "" + (Convert.ToDecimal(detalle.Impuesto) + sub);

                lista.Add(detalle);
            }

            // Serializar y almacenar el carrito en TempData
            json = JsonSerializer.Serialize(lista);
            TempData["CartShopping"] = json;
            TempData.Keep();

            // Retornar la vista parcial actualizada
            return PartialView("_DetailFactura", lista);
        }


        public IActionResult GetDetailFactura()
        {
            List<DetalleFacturaDTO> lista = new List<DetalleFacturaDTO>();
            string json = "";
            json = (string)TempData["CartShopping"]!;
            lista = JsonSerializer.Deserialize<List<DetalleFacturaDTO>>(json!)!;

            json = JsonSerializer.Serialize(lista);
            TempData["CartShopping"] = json;
            TempData.Keep();

            return PartialView("_DetailFactura", lista);
        }

        public IActionResult DeleteProducto(int codigo)
        {
            DetalleFacturaDTO DetalleFacturaDTO = new DetalleFacturaDTO();
            List<DetalleFacturaDTO> lista = new List<DetalleFacturaDTO>();
            string json = "";

            if (TempData["CartShopping"] != null)
            {
                json = (string)TempData["CartShopping"]!;
                lista = JsonSerializer.Deserialize<List<DetalleFacturaDTO>>(json!)!;
                //Eliminar de la lista segun el identificador
                int idx = lista.FindIndex(p => p.Codigo == codigo.ToString());
                lista.RemoveAt(idx);
                json = JsonSerializer.Serialize(lista);
                TempData["CartShopping"] = json;
            }

            TempData.Keep();

            return PartialView("_DetailFactura", lista);

        }
    }
}
