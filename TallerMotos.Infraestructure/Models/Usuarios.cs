﻿namespace TallerMotos.Infraestructure.Models;

public partial class Usuarios
{
    public int ID { get; set; }

    public int IDRol { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Contrasenna { get; set; }

    public virtual ICollection<Facturas> Facturas { get; set; } = new List<Facturas>();

    public virtual Rol IdrolNavigation { get; set; } = null!;

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual ICollection<Sucursales> Sucursales { get; set; } = new List<Sucursales>();
    public virtual ICollection<EncargadoSucursal> EncargadoSucursales { get; set; } = new List<EncargadoSucursal>();//agega

}
