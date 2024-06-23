using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
    public class SucursalesProfile : Profile
    {
        public SucursalesProfile()
        {
            CreateMap<SucursalesDTO, Sucursales>().ReverseMap();

            CreateMap<SucursalesDTO, Sucursales>()
           .ForMember(dest => dest.ID, orig => orig.MapFrom(o => o.ID))
           .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
           .ForMember(dest => dest.Descripcion, orig => orig.MapFrom(o => o.Descripcion))
           .ForMember(dest => dest.Telefono, orig => orig.MapFrom(o => o.Telefono))
           .ForMember(dest => dest.Direccion, orig => orig.MapFrom(o => o.Direccion))
           .ForMember(dest => dest.Correo, orig => orig.MapFrom(o => o.Correo))
           .ForMember(dest => dest.Reservas, opt => opt.MapFrom(src => src.Reservas));
        }
    }
}
