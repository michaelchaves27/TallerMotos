namespace TallerMotos.Infraestructure.Models;

public partial class EncargadoSucursal
{
    public int IDUsuario { get; set; }

    public int IDSucursal { get; set; }

    public virtual Sucursales IdsucursalNavigation { get; set; } = null!;

    public virtual Usuarios IdusuarioNavigation { get; set; } = null!;
}
