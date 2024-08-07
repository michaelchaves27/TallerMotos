using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TallerMotos.Infraestructure.Data;

namespace TallerMotos.Web
{
    public class TareaHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;

        public TareaHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Configuración del timer para ejecutar el método IncrementarPrecioServicios
            _timer = new Timer(IncrementarPrecioServicios, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void IncrementarPrecioServicios(object state)
        {
            // Crear un alcance de servicio para obtener el TallerMotosContext
            using (var scope = _serviceProvider.CreateScope())
            {
                // Obtener una instancia del TallerMotosContext desde el alcance de servicio
                var dbContext = scope.ServiceProvider.GetRequiredService<TallerMotosContext>();

                // Obtener todos los Servicios desde la base de datos
                var Servicios = dbContext.Servicios.ToList();
                foreach (var Servicio in Servicios)
                {
                    // Convertir el precio actual desde string a double
                    if (double.TryParse(Servicio.Precio, out double currentPrecio))
                    {
                        // Incrementar el precio en un 1 colon
                        currentPrecio += 1;

                        // Convertir el nuevo valor del precio de double a string
                        Servicio.Precio = currentPrecio.ToString();
                    }
                    else
                    {
                        // Si el valor actual del precio no es un número válido, manejar el error
                        Console.WriteLine("Valor del precio no es válido: " + Servicio.Precio);
                    }
                }

                // Guardar los cambios en la base de datos
                dbContext.SaveChanges();
            }

            // Mostrar el valor actualizado del precio en la consola
            Console.WriteLine("Precios de los Servicios actualizados.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
