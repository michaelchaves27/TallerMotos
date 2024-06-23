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


        }
    }
}
