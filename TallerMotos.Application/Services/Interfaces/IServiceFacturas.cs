using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
    public interface IServiceFacturas
    {
        Task<ICollection<FacturaDTO>> ListAsync();
        Task<FacturaDTO> FindByIdAsync(int id);
    }

}
