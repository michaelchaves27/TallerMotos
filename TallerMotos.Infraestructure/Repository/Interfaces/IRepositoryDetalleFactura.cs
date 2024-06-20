using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryDetalleFactura
    {
        Task<DetalleFactura> FindByIdAsync(int id);
        Task<ICollection<DetalleFactura>> ListAsync(int id);
    }
}
