using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
    public class DetalleFacturaProfile : Profile
    {
        public DetalleFacturaProfile()
        {
            CreateMap<DetalleFacturaDTO, DetalleFactura>().ReverseMap();
        }
    }
}
