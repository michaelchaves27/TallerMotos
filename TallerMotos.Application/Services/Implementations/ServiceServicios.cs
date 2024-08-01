using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Models;
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

        public async Task<int> AddAsync(ServiciosDTO dto)
        {
            var objectMapped = _mapper.Map<Servicios>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task UpdateAsync(int id, ServiciosDTO dto)
        {
            var @object = await _repository.FindByIdAsync(id);
            var entity = _mapper.Map(dto, @object!);

            await _repository.UpdateAsync(entity);
        }

        public async Task<ServiciosDTO> GetByIdAsync(int id)
        {
            var servicios = await _repository.FindByIdAsync(id);
            return _mapper.Map<ServiciosDTO>(servicios);
        }
        //public async Task<ServiciosDTO> GetByIdAsync(int id)
        //{
        //    var servicio = await _repository.FindByIdAsync(id);
        //    if (servicio == null)
        //    {
        //        return null;
        //    }

        //    return new ServiciosDTO
        //    {
        //        ID = servicio.ID,
        //        Nombre = servicio.Nombre,
        //        Tiempo = servicio.Tiempo
        //    };
        //}
    }
}
