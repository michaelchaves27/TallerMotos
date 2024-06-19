using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
    public class FacturaProfile : Profile
    {
        public FacturaProfile()
        {
            CreateMap<FacturaDTO, Facturas>().ReverseMap();
        }
    }
}
