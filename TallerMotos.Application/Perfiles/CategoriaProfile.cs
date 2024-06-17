using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMotos.Application.DTO;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Perfiles
{
	public class CategoriaProfile : Profile
	{
		public CategoriaProfile()
		{
			CreateMap<CategoriaDTO, Categoria>().ReverseMap();
		}
	}
}
