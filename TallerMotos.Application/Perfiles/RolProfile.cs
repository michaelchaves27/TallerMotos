using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<RolDTO, Rol>().ReverseMap();

            CreateMap<RolDTO, Rol>()
           .ForMember(dest => dest.ID, orig => orig.MapFrom(o => o.ID))
           .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre));

        }
    }
}
