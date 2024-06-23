using TallerMotos.Application.DTO;

namespace TallerMotos.Application.Services.Interfaces
{
    public interface IServiceUsuarios
    {
        Task<ICollection<UsuariosDTO>> ListAsync();
        Task<UsuariosDTO> FindByIdAsync(int id);
    }
}
