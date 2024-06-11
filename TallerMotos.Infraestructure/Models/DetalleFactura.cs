using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class DetalleFactura
{
    public int Id { get; set; }

    public int Idfactura { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public string? Cantidad { get; set; }

    public string? Precio { get; set; }

    public string? Impuesto { get; set; }

    public string? SubTotal { get; set; }

    public string? Total { get; set; }

    public string? Estado { get; set; }

    public virtual Facturas IdfacturaNavigation { get; set; } = null!;
}
