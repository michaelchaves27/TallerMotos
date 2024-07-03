using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
    public interface IServiceSucursales
    {
        Task<ICollection<SucursalesDTO>> ListAsync();
        Task<SucursalesDTO> FindByIdAsync(int id);
        Task<int> AddAsync(SucursalesDTO dto);
    }
}
