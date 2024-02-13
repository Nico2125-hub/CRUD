using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Menu.Profiles
{
    public class Menu : Profile
    {
		public Menu()
		{
            CreateMap<Menu, MenuDto>();
            CreateMap<Menu, MenuSmallDto>();
            CreateMap<Menu, MenuSimpleDto>();
            CreateMap<Menu, MenuMediumDto>();

            CreateMap<Menu, MenuSaveDto>().ReverseMap();
		}
	}
}

