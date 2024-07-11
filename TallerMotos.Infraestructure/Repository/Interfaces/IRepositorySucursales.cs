using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositorySucursales
    {
        Task<ICollection<Sucursales>> ListAsync();
        Task<Sucursales> FindByIdAsync(int id);
        Task<int> AddAsync(string[] selectedUsuarios, Sucursales entity);//se cambia de lugar
        Task UpdateAsync(string[] selectedUsuarios, Sucursales entity);//se cambia de lugar
    }
}
