using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
	public interface IServiceCategoria
	{
		Task<ICollection<CategoriaDTO>> ListAsync();
		Task<CategoriaDTO> FindByIdAsync(int id);
	}
}
