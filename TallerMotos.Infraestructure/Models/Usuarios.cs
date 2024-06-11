using System;
using System.Collections.Generic;

namespace TallerMotos.Infraestructure.Models;

public partial class Usuarios
{
    public int Id { get; set; }

    public int Idrol { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public byte[]? Contrasenna { get; set; }

    public virtual ICollection<Facturas> Facturas { get; set; } = new List<Facturas>();

    public virtual Rol IdrolNavigation { get; set; } = null!;

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
