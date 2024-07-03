namespace TallerMotos.Infraestructure.Models;

public partial class Servicios
{
    public int ID { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Precio { get; set; } = null!;

    public string Tiempo { get; set; } = null!;

    public string Cilindrada { get; set; } = null!;

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
