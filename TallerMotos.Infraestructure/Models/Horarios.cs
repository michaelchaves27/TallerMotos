namespace TallerMotos.Infraestructure.Models;

public partial class Horarios
{
    public int ID { get; set; }

    public int IDSucursal { get; set; }

    public string? Dia { get; set; }

    public string? Hora { get; set; }

    public string? Estado { get; set; }

    public virtual Sucursales IdsucursalesNavigation { get; set; } = null!;
}
