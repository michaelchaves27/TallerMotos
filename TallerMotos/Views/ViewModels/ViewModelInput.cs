using System.ComponentModel.DataAnnotations;

namespace TallerMotos.Web.ViewModels
{
    public class ViewModelInput
    {

        [Display(Name = "Producto")]
        public int Codigo { get; set; }

        [Display(Name = "Cantidad")]
        [Range(0, 999999999, ErrorMessage = "Cantidad mínimo es {0}")]
        public int Cantidad { get; set; }
        [Range(0, 999999999, ErrorMessage = "Precio mínimo es {0}")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        [Display(Name = "Tiempo")]
        [Range(0, 999999999, ErrorMessage = "Tiempo mínimo es {0}")]
        public int Tiempo { get; set; }
    }
}
