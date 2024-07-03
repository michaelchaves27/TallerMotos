using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TallerMotos.Application.DTO
{
    public record ServiciosDTO
    {
        [Display(Name = "ID")]
        [ValidateNever]
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Descripcion { get; set; } = null!;

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Precio { get; set; } = null!;

        [Display(Name = "Tiempo")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Tiempo { get; set; } = null!;

        [Display(Name = "Cilindrada")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Cilindrada { get; set; } = null!;

        [Display(Name = "Reservas")]
        [ValidateNever]
        public ICollection<ReservasDTO> Reservas { get; set; } = null!;

    }
}
