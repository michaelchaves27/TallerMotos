using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceServicios : IServiceServicios
    {
        private readonly IRepositoryServicios _repository;
        private readonly IMapper _mapper;
        public ServiceServicios(IRepositoryServicios repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiciosDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<ServiciosDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<ServiciosDTO>> ListAsync()
        {

            var list = await _repository.ListAsync();

            var collection = _mapper.Map<ICollection<ServiciosDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
