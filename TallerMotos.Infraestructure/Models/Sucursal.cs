using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class Sucursal
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Horarios> Horarios { get; set; } = new List<Horarios>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
