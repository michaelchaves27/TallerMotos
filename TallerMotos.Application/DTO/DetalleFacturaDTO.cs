using System.ComponentModel.DataAnnotations;
using TallerMotos.Infraestructure.Models;

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
        //[Required(ErrorMessage = "{0} es un dato requerido")]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "El {0} solo puede contener números.")]
        public string Cantidad { get; set; } = null!;

        [Display(Name = "Precio")]
        public string Precio { get; set; } = null!;

        [Display(Name = "Impuesto")]
        public string Impuesto { get; set; } = null!;

        [Display(Name = "SubTotal")]
        public string SubTotal { get; set; } = null!;

        [Display(Name = "Total")]
        public string Total { get; set; } = null!;

        public virtual Facturas IdfacturaNavigation { get; set; } = null!;
    }
}
