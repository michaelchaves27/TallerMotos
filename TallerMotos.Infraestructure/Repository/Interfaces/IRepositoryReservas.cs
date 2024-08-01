using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryReservas
    {
        Task<ICollection<Reservas>> ListAsync();
        Task<Reservas> FindByIdAsync(int id);
        Task<ICollection<Reservas>> ListBySucursalAsync(int idSucursal);
        Task<int> AddAsync(Reservas entity);
    }
}
