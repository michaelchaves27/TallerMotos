using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
    public interface IServiceServicios
    {
        Task<ICollection<ServiciosDTO>> ListAsync();
        Task<ServiciosDTO> FindByIdAsync(int id);
    }
}
