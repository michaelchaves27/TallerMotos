using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
	public interface IServiceProductos
	{
		Task<ICollection<ProductosDTO>> ListAsync();

		Task<ProductosDTO> FindByIdAsync(int id);
		Task<int> AddAsync(ProductosDTO dto, string[] selectedCategorias);

		Task UpdateAsync(int id, ProductosDTO dto, string[] selectedCategorias);

		//Task<ICollection<ProductosDTO>> GetProductosByCategoria(int IdCategoria);
		Task<ICollection<ProductosDTO>> FindByNameAsync(string nombre);

		Task DeleteAsync(int id);
	}
}
