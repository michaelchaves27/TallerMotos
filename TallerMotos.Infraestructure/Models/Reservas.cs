using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class Reservas
{
    public int Id { get; set; }

    public int Idservicio { get; set; }

    public int Idsucursal { get; set; }

    public int Idusuario { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Estado { get; set; }

    public virtual Servicios IdservicioNavigation { get; set; } = null!;

    public virtual Sucursales IdsucursalNavigation { get; set; } = null!;

    public virtual Usuarios IdusuarioNavigation { get; set; } = null!;
}
