using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
    public class ServiciosProfile : Profile
    {
        public ServiciosProfile()
        {
            CreateMap<ServiciosDTO, Servicios>().ReverseMap();

            CreateMap<ServiciosDTO, Servicios>()
           .ForMember(dest => dest.ID, orig => orig.MapFrom(o => o.ID))
           .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
           .ForMember(dest => dest.Descripcion, orig => orig.MapFrom(o => o.Descripcion))
           .ForMember(dest => dest.Precio, orig => orig.MapFrom(o => o.Precio))
           .ForMember(dest => dest.Tiempo, orig => orig.MapFrom(o => o.Tiempo))
           .ForMember(dest => dest.Cilindrada, orig => orig.MapFrom(o => o.Cilindrada))
           .ForMember(dest => dest.Reservas, opt => opt.MapFrom(src => src.Reservas));
        }
    }
}
