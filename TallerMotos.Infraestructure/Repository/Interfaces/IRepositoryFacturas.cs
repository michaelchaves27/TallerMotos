using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryFacturas
    {
        Task<ICollection<Facturas>> ListAsync();
        Task<Facturas> FindByIdAsync(int id);
    }
}
