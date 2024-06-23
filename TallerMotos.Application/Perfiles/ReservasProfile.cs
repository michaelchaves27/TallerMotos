using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
    public class ReservasProfile : Profile
    {
        public ReservasProfile()
        {
            CreateMap<ReservasDTO, Reservas>().ReverseMap();

            CreateMap<ReservasDTO, Reservas>()
           .ForMember(dest => dest.ID, orig => orig.MapFrom(o => o.ID))
           // .ForMember(dest => dest.IDCategoria, orig => orig.MapFrom(o => o.IDCategoria))
           .ForMember(dest => dest.IDServicio, orig => orig.MapFrom(o => o.IDServicio))
           .ForMember(dest => dest.IdservicioNavigation, orig => orig.MapFrom(o => o.IdservicioNavigation))
           .ForMember(dest => dest.IdsucursalNavigation, orig => orig.MapFrom(o => o.IdsucursalNavigation))
           .ForMember(dest => dest.IdusuarioNavigation, orig => orig.MapFrom(o => o.IdusuarioNavigation))
           .ForMember(dest => dest.Fecha, orig => orig.MapFrom(o => o.Fecha))
           .ForMember(dest => dest.Estado, orig => orig.MapFrom(o => o.Estado));
        }
    }
}
