using System.ComponentModel.DataAnnotations;

namespace TallerMotos.Application.DTO
{
    public record SucursalesDTO
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = null!;

        [Display(Name = "Telefono")]
        public string Telefono { get; set; } = null!;

        [Display(Name = "Direccion")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "Correo")]
        public string Correo { get; set; } = null!;

        [Display(Name = "Reservas")]
        public ICollection<ReservasDTO> Reservas { get; set; }

    }
}
