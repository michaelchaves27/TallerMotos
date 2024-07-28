using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
    public interface IServiceRol
    {
        Task<ICollection<RolDTO>> ListAsync();
        Task<RolDTO> FindByIdAsync(int id);
    }
}
