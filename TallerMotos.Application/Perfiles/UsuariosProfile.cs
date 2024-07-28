using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<UsuariosDTO, Usuarios>().ReverseMap();

            CreateMap<UsuariosDTO, Usuarios>()
           .ForMember(dest => dest.ID, orig => orig.MapFrom(o => o.ID))
           // .ForMember(dest => dest.IDCategoria, orig => orig.MapFrom(o => o.IDCategoria))
           .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
           .ForMember(dest => dest.Telefono, orig => orig.MapFrom(o => o.Telefono))
           .ForMember(dest => dest.Correo, orig => orig.MapFrom(o => o.Correo))
           .ForMember(dest => dest.Direccion, orig => orig.MapFrom(o => o.Direccion))
           .ForMember(dest => dest.Contrasenna, orig => orig.MapFrom(o => o.Contrasenna))
           .ForMember(dest => dest.IdrolNavigation, orig => orig.MapFrom(o => o.IdrolNavigation));
        }
    }
}
