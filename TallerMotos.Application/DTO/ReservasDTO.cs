using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.DTO
{
    public record ReservasDTO
    {
        [Display(Name = "ID")]
        [ValidateNever]
        public int ID { get; set; }

        [Display(Name = "IDServicio")]
        [ValidateNever]
        public int IDServicio { get; set; }

        [Display(Name = "Servicio")]
        [ValidateNever]
        public virtual Servicios IdservicioNavigation { get; set; } = null!;

        [Display(Name = "IDSucursal")]
        [ValidateNever]
        public int IDSucursal { get; set; }

        [Display(Name = "Sucursal")]
        [ValidateNever]
        public virtual Sucursales IdsucursalNavigation { get; set; } = null!;

        [Display(Name = "IDUsuario")]
        [ValidateNever]
        public int IDUsuario { get; set; }

        [Display(Name = "Usuario")]
        [ValidateNever]
        public virtual Usuarios IdusuarioNavigation { get; set; } = null!;

        //[Display(Name = "Fecha")]
        //public DateOnly Fecha { get; set; }

        [Display(Name = "Día")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Dia { get; set; } = null!;

        [Display(Name = "Hora")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Hora { get; set; } = null!;

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Estado { get; set; } = null!;

    }
}
