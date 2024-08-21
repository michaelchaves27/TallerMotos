using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IServiceReservas _serviceReservas;
        private readonly IServiceSucursales _serviceSucursales;
        private readonly IServiceDetalleFactura _serviceDetalleFactura;

        public HomeController(ILogger<HomeController> logger, IServiceReservas serviceReservas, IServiceSucursales serviceSucursales, IServiceDetalleFactura serviceDetalleFactura)
        {
            _logger = logger;
            _serviceReservas = serviceReservas;
            _serviceSucursales = serviceSucursales;
            _serviceDetalleFactura = serviceDetalleFactura;
        }

        public IActionResult Index23()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Index()
        {
            string etiquetas = "";
            string valores = "";
            decimal total = 0M;

            var sucursales = await _serviceSucursales.ListAsync();

            if (sucursales == null)
            {
                ViewBag.Message = $"No hay sucursales.";
                return View();
            }

            var lista = await _serviceReservas.ListAsync();

            if (lista.Count == 0)
            {
                ViewBag.Message = $"No hay reservas ";
                return View();
            }

            // Diccionario para almacenar la cantidad de reservas por sucursal
            Dictionary<int, int> reservasPorSucursal = new Dictionary<int, int>();

            // Recorrer la lista de reservas
            foreach (var reserva in lista)
            {
                if (reservasPorSucursal.ContainsKey(reserva.IDSucursal))
                {
                    reservasPorSucursal[reserva.IDSucursal]++;
                }
                else
                {
                    reservasPorSucursal[reserva.IDSucursal] = 1;
                }
            }

            // Generar las etiquetas y valores para el gráfico
            foreach (var sucursal in sucursales)
            {
                if (reservasPorSucursal.ContainsKey(sucursal.ID))
                {
                    etiquetas += sucursal.Nombre.ToString() + ",";
                    valores += reservasPorSucursal[sucursal.ID] + ",";
                    total += reservasPorSucursal[sucursal.ID]; 
                }
            }

            // Quitar última coma
            if (!string.IsNullOrEmpty(etiquetas))
            {
                etiquetas = etiquetas.Substring(0, etiquetas.Length - 1);
                valores = valores.Substring(0, valores.Length - 1);
            }

            //top productos
            var detalleFacturas = await _serviceDetalleFactura.ListaDetalle(); // Simula o reemplaza con tu método para obtener la lista

            // Agrupar por nombre de producto y sumar las cantidades
            var topProductos = detalleFacturas
                .GroupBy(df => df.Nombre)
                .Select(g => new ProductoVendido
                {
                    Nombre = g.Key,
                    TotalVendido = g.Sum(df => Convert.ToInt16(df.Cantidad))
                })
                .OrderByDescending(p => p.TotalVendido) // Ordenar por la cantidad total vendida
                .Take(3) // Tomar los 3 primeros
                .ToList();

            // Pasar la información a la vista
            ViewBag.TopProductos = topProductos;

            ViewBag.listaSucursales = sucursales;

            ViewBag.Etiquetas = etiquetas;
            ViewBag.Valores = valores;
            ViewBag.Total = total;

            return View();
        }
    }
}
