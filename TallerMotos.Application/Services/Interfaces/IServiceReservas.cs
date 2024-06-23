using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
    public interface IServiceReservas
    {
        Task<ICollection<ReservasDTO>> ListAsync();
        Task<ReservasDTO> FindByIdAsync(int id);
    }
}
