using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Web.Models;
using X.PagedList;

namespace TallerMotos.Web.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IServiceReservas _serviceReservas;
        private readonly IServiceSucursales _serviceSucursales;
        private readonly IServiceServicios _serviceServicios;
        private readonly IServiceUsuarios _serviceUsuarios;
        private readonly IServiceHorarios _serviceHorarios;

        public ReservasController(IServiceReservas serviceReservas, IServiceSucursales serviceSucursales, IServiceServicios serviceServicios, IServiceUsuarios serviceUsuarios, IServiceHorarios serviceHorarios)
        {
            _serviceReservas = serviceReservas;
            _serviceSucursales = serviceSucursales;
            _serviceServicios = serviceServicios;
            _serviceUsuarios = serviceUsuarios;
            _serviceHorarios = serviceHorarios;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var collection = await _serviceReservas.ListAsync();
        //    ViewData["Title"] = "Index";
        //    return View(collection);
        //}


        public async Task<IActionResult> Index(int id, string diaSeleccionado, int? page)
        {
            // Obtén las reservas por sucursal
            var collection = await _serviceReservas.ListBySucursalAsync(id);

            // Filtra por día si se ha seleccionado uno
            if (!string.IsNullOrEmpty(diaSeleccionado))
            {
                collection = collection.Where(r => r.Dia == diaSeleccionado).ToList();
            }

            // Guarda el id de la sucursal en ViewData
            ViewData["SucursalId"] = id;
            // Guarda los días de la semana en ViewBag para el combo box
            ViewBag.DiasDeLaSemana = new List<string> { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };

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
                var reserva = await _serviceReservas.FindByIdAsync(id.Value);
                if (reserva == null)
                {
                    throw new Exception("Reservas no existente");
                }
                ViewData["SucursalId"] = reserva.IDSucursal;
                return View(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult> DetailsProforma(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                var reserva = await _serviceReservas.FindByIdAsync(id.Value);
                if (reserva == null)
                {
                    throw new Exception("Reservas no existente");
                }
                ViewData["SucursalId"] = reserva.IDSucursal;
                return View(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[HttpGet]
        public async Task<IActionResult> Create(int idsucursal)
        {
            var usuarios = await _serviceUsuarios.ListAsync();
            var usuariosDTO = usuarios.Select(u => new UsuariosDTO
            {
                ID = u.ID,
                Nombre = u.Nombre,
                Correo = u.Correo
            }).ToList();

            var servicios = await _serviceServicios.ListAsync();
            var serviciosDTO = servicios.Select(s => new ServiciosDTO
            {
                ID = s.ID,
                Nombre = s.Nombre,
                Tiempo = s.Tiempo
            }).ToList();

            // Obtener la sucursal por ID
            var sucursal = await _serviceSucursales.FindByIdAsync(idsucursal);

            // Pasar los datos necesarios al ViewBag
            ViewBag.ListaUsuarios = usuariosDTO;
            ViewBag.UsuariosJson = JsonConvert.SerializeObject(usuariosDTO);

            ViewBag.ListaServicios = serviciosDTO;
            ViewBag.ServiciosJson = JsonConvert.SerializeObject(serviciosDTO);

            // Pasar la sucursal al ViewBag
            ViewBag.ListaSucursales = sucursal;

            // Pasar el ID de la sucursal a ViewData para la redirección
            ViewData["SucursalId"] = idsucursal;

            // Obtener los días disponibles para la sucursal
            var diasDisponibles = await _serviceHorarios.GetDiasDisponiblesAsync(idsucursal);
            ViewBag.DiasDisponibles = new SelectList(diasDisponibles);

            ViewBag.ListaEstados = new List<SelectListItem>
            {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Confirmada", Text = "Confirmada" },
                new SelectListItem { Value = "Completada", Text = "Completada" },
                new SelectListItem { Value = "Cancelada", Text = "Cancelada" },
                new SelectListItem { Value = "Reprogramada", Text = "Reprogramada" },
                new SelectListItem { Value = "Proforma", Text = "Proforma" }
            };

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservasDTO dto)
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
                ViewBag.ListaSucursales = await _serviceSucursales.FindByIdAsync(dto.IDSucursal);

                return View();
            }
            //Crear 
            await _serviceReservas.AddAsync(dto);
            return RedirectToAction("Index", new { idSucursal = dto.IDSucursal });
        }

        [HttpGet]
        public IActionResult GetHorasDisponibles(string dia)
        {
            if (string.IsNullOrEmpty(dia))
            {
                return Json(new { horas = new List<string>() });
            }

            var horas = _serviceHorarios.GetHorasDisponibles(dia);

            return Json(new { horas });
        }



        //[HttpGet]
        //public async Task<JsonResult> GetServicioTiempo(int id)
        //{
        //    var servicio = await _serviceServicios.GetByIdAsync(id);
        //    if (servicio != null)
        //    {
        //        return Json(new { tiempo = servicio.Tiempo });
        //    }
        //    return Json(new { tiempo = "" });
        //}

        public IActionResult ErrorHandler(string messageJson)
        {
            var errorMessages = JsonConvert.
                DeserializeObject<ErrorMiddlewareViewModel>(messageJson);
            ViewBag.ErrorMessages = errorMessages;
            return View("ErrorHandler");
        }
    }
}
