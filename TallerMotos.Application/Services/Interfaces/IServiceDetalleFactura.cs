using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
    public interface IServiceDetalleFactura
    {
        //Task<ICollection<DetalleFacturaDTO>> ListAsync();
        Task<ICollection<DetalleFacturaDTO>> ListAsync(int id);
        Task<DetalleFacturaDTO> FindByIdAsync(int id);

    }
}
