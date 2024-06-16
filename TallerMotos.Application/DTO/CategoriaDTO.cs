using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMotos.Application.DTO
{
	public record CategoriaDTO
	{
		public int ID { get; set; }

		public string Nombre { get; set; } = null!;
	}
}
