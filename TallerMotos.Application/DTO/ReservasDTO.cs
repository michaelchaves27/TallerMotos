using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMotos.Application.DTO
{
    public record ReservasDTO
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "IDServicio")]
        public int IDServicio { get; set; }
        [Display(Name = "IDSucursal")]
        public int IDSucursal { get; set; }
        [Display(Name = "IDUsuario")]
        public int IDUsuario { get; set; }
        [Display(Name = "Fecha")]
        public DateOnly Fecha { get; set; }
        [Display(Name = "Estado")]
        public string Estado { get; set; } = null!;
       
    }
}
