using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Display(Name = "Nombre Producto")]
		public string Nombre { get; set; } = null!;

		[Display(Name = "Descripción")]
		public string Descripcion { get; set; } = null!;

		[Display(Name = "Precio")]
		public string Precio { get; set; } = null!;

		[Display(Name = "Marca")]
		public string Marca { get; set; } = null!;

		[Display(Name = "Calificación")]
		public string Calificacion { get; set; } = null!;
	}
}
