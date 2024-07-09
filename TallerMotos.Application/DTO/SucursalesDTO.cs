using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.DTO
{
    public record SucursalesDTO
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

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "El {0} solo puede contener números.")]
        public string Telefono { get; set; } = null!;

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [EmailAddress(ErrorMessage = "Debe tener un formato de correo @gmail.com/@hotmail.com")]
        public string Correo { get; set; } = null!;

        [Display(Name = "Reservas")]
        [ValidateNever]
        public ICollection<ReservasDTO> Reservas { get; set; } = null!;
        public virtual List<Horarios> Horarios { get; set; } = new List<Horarios>();

    }
}
