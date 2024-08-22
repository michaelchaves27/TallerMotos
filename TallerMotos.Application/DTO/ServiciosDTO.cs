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
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo Nombre solo puede contener letras.")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Descripcion { get; set; } = null!;

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "El {0} solo puede contener números.")]
        public string Precio { get; set; } = null!;

        [Display(Name = "Tiempo")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "El {0} solo puede contener números.")]
        public string Tiempo { get; set; } = null!;

        [Display(Name = "Cilindrada")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Cilindrada { get; set; } = null!;

        [Display(Name = "Reservas")]
        [ValidateNever]
        public ICollection<ReservasDTO> Reservas { get; set; } = null!;

    }
}
