using System.ComponentModel.DataAnnotations;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.DTO
{
    public record FacturaDTO
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "Fecha")]
        public DateOnly Fecha { get; set; }
        [Display(Name = "IDUsuario")]
        public int IDUsuario { get; set; }
        [Display(Name = "IDSucursal")]
        public int IDSucursal { get; set; }
        [Display(Name = "Estado")]
        public string Estado { get; set; } = null!;
        [Display(Name = "Total")]
        public string Total { get; set; } = null!;

        [Display(Name = "Usuario")]
        public virtual Usuarios IdusuarioNavigation { get; set; } = null!;
        [Display(Name = "Sucursal")]
        public virtual Sucursales IdsucursalNavigation { get; set; } = null!;
    }
}
