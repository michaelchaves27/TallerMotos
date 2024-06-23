using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceUsuarios : IServiceUsuarios
    {
        private readonly IRepositoryUsuarios _repository;
        private readonly IMapper _mapper;
        public ServiceUsuarios(IRepositoryUsuarios repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UsuariosDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<UsuariosDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<UsuariosDTO>> ListAsync()
        {

            var list = await _repository.ListAsync();

            var collection = _mapper.Map<ICollection<UsuariosDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
