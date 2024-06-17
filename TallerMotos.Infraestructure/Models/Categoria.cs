using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class Categoria
{
    public int ID { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
