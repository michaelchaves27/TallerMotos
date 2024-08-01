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
        public int IDRol { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Telefono")]
        public string Telefono { get; set; } = null!;

        [Display(Name = "Correo")]
        public string Correo { get; set; } = null!;

        [Display(Name = "Direccion")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "FechaNacimiento")]
        public DateOnly FechaNacimiento { get; set; }


        [Display(Name = "Contrasenna")]
        public string Contrasenna { get; set; } = null!;

        [Display(Name = "Rol")]
        [ValidateNever]
        public virtual Rol IdrolNavigation { get; set; } = null!;
    }
}
