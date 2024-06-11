using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class Facturas
{
    public int Id { get; set; }

    public int Idusuario { get; set; }

    public int Idsucursal { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Estado { get; set; }

    public string? SubTotal { get; set; }

    public string? Impuesto { get; set; }

    public string? Total { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();

    public virtual Sucursales IdsucursalNavigation { get; set; } = null!;

    public virtual Usuarios IdusuarioNavigation { get; set; } = null!;
}
