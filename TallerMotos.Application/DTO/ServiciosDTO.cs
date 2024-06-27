using System.ComponentModel.DataAnnotations;

namespace TallerMotos.Application.DTO
{
    public record ServiciosDTO
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = null!;

        [Display(Name = "Precio")]
        public string Precio { get; set; } = null!;

        [Display(Name = "Tiempo")]
        public string Tiempo { get; set; } = null!;

        [Display(Name = "Cilindrada")]
        public string Cilindrada { get; set; } = null!;

        [Display(Name = "Reservas")]
        public ICollection<ReservasDTO> Reservas { get; set; } = null!;

    }
}
