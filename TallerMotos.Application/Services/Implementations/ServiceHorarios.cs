using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceHorarios : IServiceHorarios
    {
        private readonly IRepositoryHorarios _repository;
        private readonly IMapper _mapper;
        
        public ServiceHorarios(IRepositoryHorarios repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<HorariosDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<HorariosDTO>>(list);
            return collection;
        }
        public async Task<HorariosDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<HorariosDTO>(@object);
            return objectMapped;
        }
        public async Task<int> AddAsync(HorariosDTO dto)
        {
            var objectMapped = _mapper.Map<Horarios>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task UpdateAsync(int id, HorariosDTO dto)
        {
            var @object = await _repository.FindByIdAsync(id);
            var entity = _mapper.Map(dto, @object!);

            await _repository.UpdateAsync(entity);
        }

        public async Task<HorariosDTO> GetByIdAsync(int id)
        {
            var Horarios = await _repository.FindByIdAsync(id);
            return _mapper.Map<HorariosDTO>(Horarios);
        }



    }
}
