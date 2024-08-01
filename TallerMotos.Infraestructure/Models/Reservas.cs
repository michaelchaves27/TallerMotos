namespace TallerMotos.Infraestructure.Models;

public partial class Reservas
{
    public int ID { get; set; }

    public int? IDServicio { get; set; }

    public int? IDSucursal { get; set; }

    public int? IDUsuario { get; set; }

    //public DateOnly? Fecha { get; set; }
    public string? Dia { get; set; }
    public string? Hora { get; set; }
    public string? Estado { get; set; }

    public virtual Servicios IdservicioNavigation { get; set; } = null!;

    public virtual Sucursales IdsucursalNavigation { get; set; } = null!;

    public virtual Usuarios IdusuarioNavigation { get; set; } = null!;
}
