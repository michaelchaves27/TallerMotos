namespace TallerMotos.Infraestructure.Models;

public partial class Rol
{
    public int ID { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
