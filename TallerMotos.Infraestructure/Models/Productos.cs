using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class Productos
{
    public int Id { get; set; }

    public int Idcategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Precio { get; set; }

    public string? Marca { get; set; }

    public string? Calificacion { get; set; }

    public virtual Categoria IdcategoriaNavigation { get; set; } = null!;
}
