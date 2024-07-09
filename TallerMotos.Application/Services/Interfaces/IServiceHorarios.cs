using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
    public interface IServiceHorarios
    {
        Task<ICollection<HorariosDTO>> ListAsync();
        Task<HorariosDTO> FindByIdAsync(int id);
        Task<int> AddAsync(HorariosDTO dto);
        Task UpdateAsync(int id, HorariosDTO dto);
        Task<HorariosDTO> GetByIdAsync(int id);
    }
}
