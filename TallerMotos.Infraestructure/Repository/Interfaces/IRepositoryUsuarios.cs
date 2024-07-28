using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryUsuarios
    {
        Task<ICollection<Usuarios>> ListAsync();
        Task<Usuarios> FindByIdAsync(int id);
        Task<Usuarios> LoginAsync(string id, string password);
        Task<string> AddAsync(Usuarios entity);
        Task UpdateAsync(Usuarios entity);
    }
}
