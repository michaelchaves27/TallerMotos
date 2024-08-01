using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Models;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceFacturas : IServiceFacturas
    {
        private readonly IRepositoryFacturas _repository;
        private readonly IMapper _mapper;
        public ServiceFacturas(IRepositoryFacturas repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<FacturaDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<FacturaDTO>(@object);
            return objectMapped;
        }
        public async Task<ICollection<FacturaDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync();
            // Map List<Autor> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<FacturaDTO>>(list);
            // Return lista
            return collection;
        }
        public async Task<int> AddAsync(FacturaDTO dto)
        {
            var objectMapped = _mapper.Map<Facturas>(dto);
            return await _repository.AddAsync(objectMapped);
        }
        public async Task<int> GetNextNumberOrden()
        {
            int nextReceipt = await _repository.GetNextNumberOrden();
            return nextReceipt + 1;
        }
    }
}
