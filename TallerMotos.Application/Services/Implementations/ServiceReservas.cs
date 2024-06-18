using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceReservas : IServiceReservas
    {
        private readonly IRepositoryReservas _repository;
        private readonly IMapper _mapper;
        public ServiceReservas(IRepositoryReservas repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReservasDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<ReservasDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<ReservasDTO>> ListAsync()
        {
           
            var list = await _repository.ListAsync();
            
            var collection = _mapper.Map<ICollection<ReservasDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
