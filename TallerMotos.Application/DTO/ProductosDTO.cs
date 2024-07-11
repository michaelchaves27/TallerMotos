using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.DTO
{
    public record ProductosDTO
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Categoria")]
        public int IDCategoria { get; set; }

        //[Display(Name = "Categorías")]
        //[ValidateNever]
        //public virtual List<CategoriaDTO> IDCategoria { get; set; } = null!;

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Descripcion { get; set; } = null!;

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [RegularExpression(@"^[0-9]*(\.[0-9]+)?$", ErrorMessage = "El {0} solo puede contener números y un punto decimal.")]
        public string Precio { get; set; } = null!;

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Marca { get; set; } = null!;

        [Display(Name = "Calificación")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        [RegularExpression(@"^[0-9]*(\.[0-9]+)?$", ErrorMessage = "El {0} solo puede contener números y un punto decimal.")]
        public string Calificacion { get; set; } = null!;

        [Display(Name = "CategoriaD")]
        [ValidateNever]
        public virtual Categoria IdcategoriaNavigation { get; set; } = null!;


        [Display(Name = "Categorias")]
        [ValidateNever]
        public virtual List<Categoria> Categorias { get; set; } = null!;

    }
}
