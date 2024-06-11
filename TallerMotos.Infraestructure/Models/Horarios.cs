using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class Horarios
{
    public int Id { get; set; }

    public int Idsucursal { get; set; }

    public string? Dia { get; set; }

    public string? Hora { get; set; }

    public string? Estado { get; set; }

    public virtual Sucursales IdsucursalNavigation { get; set; } = null!;
}
