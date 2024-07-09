using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryHorarios
    {
        Task<ICollection<Horarios>> ListAsync();
        Task<Horarios> FindByIdAsync(int id);
        Task<int> AddAsync(Horarios entity);
        Task UpdateAsync(Horarios entity);
    }
}
