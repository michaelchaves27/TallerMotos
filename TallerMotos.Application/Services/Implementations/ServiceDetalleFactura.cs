using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Repository.Interfaces;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceDetalleFactura : IServiceDetalleFactura
    {
        private readonly IRepositoryDetalleFactura _repository;
        private readonly IMapper _mapper;
        public ServiceDetalleFactura(IRepositoryDetalleFactura repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DetalleFacturaDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<DetalleFacturaDTO>(@object);
            return objectMapped;
        }
        public async Task<ICollection<DetalleFacturaDTO>> ListAsync(int id)
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync(id);
            // Map List<Autor> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<DetalleFacturaDTO>>(list);
            // Return lista
            return collection;
        }

        public async Task<ICollection<DetalleFacturaDTO>> ListaDetalle()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListaDetalle();
            // Map List<Autor> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<DetalleFacturaDTO>>(list);
            // Return lista
            return collection;
        }


       
    }
}
