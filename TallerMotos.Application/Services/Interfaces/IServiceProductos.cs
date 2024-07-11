using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
    public interface IServiceProductos
    {
        Task<ICollection<ProductosDTO>> ListAsync();

        Task<ProductosDTO> FindByIdAsync(int id);
        Task<int> AddAsync(ProductosDTO dto);

        Task UpdateAsync(ProductosDTO dto);

        //Task<ICollection<ProductosDTO>> GetProductosByCategoria(int IdCategoria);
        Task<ICollection<ProductosDTO>> FindByNameAsync(string nombre);

        Task DeleteAsync(int id);
    }
}
