using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [Display(Name = "Estado")]
        public string Estado { get; set; } = null!;
        [Display(Name = "Total")]
        public string Total { get; set; } = null!;


       // public virtual List<DetalleFacturas> Detalle { get; set; } = new List<DetalleFacturas>();
    }
}
