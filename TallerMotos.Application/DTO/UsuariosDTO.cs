using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.DTO
{
    public record UsuariosDTO
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "IDRol")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public int IDRol { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo Nombre solo puede contener letras.")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Teléfono")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo Teléfono solo puede contener números.")]
        public string Telefono { get; set; } = null!;

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [EmailAddress(ErrorMessage = "El campo {0} debe tener un formato de correo electrónico válido.")]
        public string Correo { get; set; } = null!;

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public DateOnly FechaNacimiento { get; set; }


        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "El campo Contraseña debe tener al menos 6 caracteres.")]
        public string Contrasenna { get; set; } = null!;

        [Display(Name = "Rol")]
        [ValidateNever]
        public virtual Rol IdrolNavigation { get; set; } = null!;
    }
}
