using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
    public class ProductosProfile : Profile
    {
        public ProductosProfile()
        {
            CreateMap<ProductosDTO, Productos>().ReverseMap();

            CreateMap<ProductosDTO, Productos>()
           .ForMember(dest => dest.ID, orig => orig.MapFrom(o => o.ID))
           // .ForMember(dest => dest.IDCategoria, orig => orig.MapFrom(o => o.IDCategoria))
           .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
           .ForMember(dest => dest.Descripcion, orig => orig.MapFrom(o => o.Descripcion))
           .ForMember(dest => dest.Precio, orig => orig.MapFrom(o => o.Precio))
           .ForMember(dest => dest.Marca, orig => orig.MapFrom(o => o.Marca))
           .ForMember(dest => dest.Calificacion, orig => orig.MapFrom(o => o.Calificacion));

        }
    }
}
