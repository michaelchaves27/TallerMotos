using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class Facturas
{
    public int ID { get; set; }

    public int IDUsuario { get; set; }

    public int IDSucursal { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Estado { get; set; }

    public string? SubTotal { get; set; }

    public string? Impuesto { get; set; }

    public string? Total { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();

    public virtual Sucursales IDSucursalNavigation { get; set; } = null!;

    public virtual Usuarios IDUsuarioNavigation { get; set; } = null!;
}
