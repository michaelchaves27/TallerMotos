using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMotos.Application.DTO
{
    public record DetalleFacturaDTO
    {

        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "IDFactura")]
        public int IDFactura { get; set; }

        [Display(Name = "Codigo")]
        public string Codigo { get; set; } = null!;

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Cantidad")]
        public string Cantidad { get; set; } = null!;

        [Display(Name = "Precio")]
        public string Precio { get; set; } = null!;

        [Display(Name = "Impuesto")]
        public string Impuesto { get; set; } = null!;

        [Display(Name = "SubTotal")]
        public string SubTotal { get; set; } = null!;

        [Display(Name = "Total")]
        public string Total { get; set; } = null!;
        /*
        [Display(Name = "Estado")]
        public string Estado { get; set; } = null!;*/
    }
}
