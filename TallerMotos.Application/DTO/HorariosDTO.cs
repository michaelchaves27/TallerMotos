using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.DTO
{
    public record HorariosDTO
    {
        [Display(Name = "ID")]
        [ValidateNever]
        public int ID { get; set; }

        [Display(Name = "IDSucursal")]
        [ValidateNever]
        public int IDSucursal { get; set; }

        [Display(Name = "Día")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Dia { get; set; } = null!;

        [Display(Name = "Hora")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Hora { get; set; } = null!;

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Estado { get; set; } = null!;

        //[Display(Name = "Reservas")]
        //[ValidateNever]
        //public ICollection<ReservasDTO> Reservas { get; set; } = null!;
        
        [Display(Name = "Sucursal")]
        [ValidateNever]
        public virtual Sucursales IdsucursalesNavigation { get; set; } = null!;

    }
}
