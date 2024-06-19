using System.ComponentModel.DataAnnotations;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.DTO
{
    public record ReservasDTO
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "IDServicio")]
        public int IDServicio { get; set; }

        [Display(Name = "Servicio")]
        public virtual Servicios IdservicioNavigation { get; set; } = null!;

        [Display(Name = "IDSucursal")]
        public int IDSucursal { get; set; }

        [Display(Name = "Sucursal")]
        public virtual Sucursales IdsucursalNavigation { get; set; } = null!;

        [Display(Name = "IDUsuario")]
        public int IDUsuario { get; set; }

        [Display(Name = "Usuario")]
        public virtual Usuarios IdusuarioNavigation { get; set; } = null!;

        [Display(Name = "Fecha")]
        public DateOnly Fecha { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; } = null!;

    }
}
