using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
    public class HorariosProfile : Profile
    {
        public HorariosProfile()
        {
            CreateMap<HorariosDTO, Horarios>().ReverseMap();

            CreateMap<HorariosDTO, Horarios>()
           .ForMember(dest => dest.ID, orig => orig.MapFrom(o => o.ID))
           .ForMember(dest => dest.IDSucursal, orig => orig.MapFrom(o => o.IDSucursal))
           .ForMember(dest => dest.Dia, orig => orig.MapFrom(o => o.Dia))
           .ForMember(dest => dest.Hora, orig => orig.MapFrom(o => o.Hora))
           .ForMember(dest => dest.Estado, orig => orig.MapFrom(o => o.Estado))
           .ForMember(dest => dest.IdsucursalesNavigation, orig => orig.MapFrom(o => o.IdsucursalesNavigation));
        }
    }
}
