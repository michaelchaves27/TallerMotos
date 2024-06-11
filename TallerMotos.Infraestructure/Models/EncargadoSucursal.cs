using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class EncargadoSucursal
{
    public int Idusuario { get; set; }

    public int Idsucursal { get; set; }

    public virtual Servicios IdsucursalNavigation { get; set; } = null!;

    public virtual Usuarios IdusuarioNavigation { get; set; } = null!;
}
