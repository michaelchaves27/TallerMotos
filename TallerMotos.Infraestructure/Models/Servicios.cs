using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class Servicios
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Precio { get; set; }

    public string? Tiempo { get; set; }

    public string? Cilindrada { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
