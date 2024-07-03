using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceSucursales : IServiceSucursales
    {
        private readonly IRepositorySucursales _repository;
        private readonly IMapper _mapper;
        public ServiceSucursales(IRepositorySucursales repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<SucursalesDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<SucursalesDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<SucursalesDTO>> ListAsync()
        {

            var list = await _repository.ListAsync();

            var collection = _mapper.Map<ICollection<SucursalesDTO>>(list);
            // Return lista
            return collection;
        }

        public async Task<int> AddAsync(SucursalesDTO dto)
        {
            var objectMapped = _mapper.Map<Sucursales>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task UpdateAsync(int id, SucursalesDTO dto)
        {
            var @object = await _repository.FindByIdAsync(id);
            var entity = _mapper.Map(dto, @object!);

            await _repository.UpdateAsync(entity);
        }

        public async Task<SucursalesDTO> GetByIdAsync(int id)
        {
            var sucursales = await _repository.FindByIdAsync(id);
            return _mapper.Map<SucursalesDTO>(sucursales);
        }



    }
}
