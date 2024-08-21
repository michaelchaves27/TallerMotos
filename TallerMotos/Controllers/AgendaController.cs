using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerMotos.Application.Services.Interfaces;

namespace TallerMotos.Web.Controllers
{
    public class AgendaController : Controller
    {
        private readonly IServiceReservas _serviceReservas;
        private static readonly Dictionary<string, DayOfWeek> DiasEnEspanol = new Dictionary<string, DayOfWeek>
{
    { "Lunes", DayOfWeek.Monday },
    { "Martes", DayOfWeek.Tuesday },
    { "Miércoles", DayOfWeek.Wednesday },
    { "Jueves", DayOfWeek.Thursday },
    { "Viernes", DayOfWeek.Friday },
    { "Sábado", DayOfWeek.Saturday },
    { "Domingo", DayOfWeek.Sunday }
};

        public AgendaController(IServiceReservas serviceReservas)
        {
            _serviceReservas = serviceReservas;
        }

        public async Task<IActionResult> Index()
        {
            var reservas = await _serviceReservas.ListAsync(); // Obtener reservas del servicio



            var eventos = reservas.Select(r =>
            {
                TimeSpan hora;
                if (!TimeSpan.TryParse(r.Hora, out hora))
                {
                    // Manejo de error si el valor de la hora no es válido
                    hora = TimeSpan.Zero; // o asigna un valor por defecto adecuado
                }

                return new
                {
                    title = r.IdusuarioNavigation.Nombre + "-" + r.Estado, // Mostrar el estado como título del evento

                    // Convertir el string de la hora a un TimeSpan o DateTime
                    start = ObtenerFechaHora(r.Dia, hora),  // Combina día y hora en formato ISO
                    end = ObtenerFechaHora(r.Dia, hora.Add(TimeSpan.FromHours(1))), // Duración de una hora

                    description = r.Estado, // Descripción del evento
                    backgroundColor = ObtenerColorEstado(r.Estado) // Cambiar color según estado
                };
            }).ToList();

            ViewBag.Eventos = Newtonsoft.Json.JsonConvert.SerializeObject(eventos);

            return View();
        }

        private string ObtenerFechaHora(string dia, TimeSpan hora)
        {
            if (string.IsNullOrEmpty(dia))
            {
                throw new ArgumentException("El día no puede ser nulo o vacío.");
            }

            DateTime now = DateTime.Now;
            if (DiasEnEspanol.TryGetValue(dia, out DayOfWeek diaDeLaSemana))
            {
                int diasDiferencia = (int)diaDeLaSemana - (int)now.DayOfWeek;
                if (diasDiferencia < 0)
                {
                    diasDiferencia += 7; // Ajustar para que siempre se obtenga el próximo día de la semana
                }
                DateTime fecha = now.AddDays(diasDiferencia).Date + hora;

                return fecha.ToString("yyyy-MM-ddTHH:mm:ss");
            }
            else
            {
                throw new ArgumentException($"El día {dia} no es válido.");
            }
        }

        private string ObtenerColorEstado(string estado)
        {
            switch (estado)
            {
                case "Confirmada": return "green";
                case "Pendiente": return "orange";
                case "Cancelada": return "red";
                default: return "blue";
            }
        }
    }
}
