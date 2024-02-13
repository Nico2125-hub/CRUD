using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.LanguageMenu.Profiles
{
	public class LanguageMenu : Profile
	{
		public LanguageMenu()
		{
			CreateMap<LanguageMenu, LanguageMenuDto>();
			CreateMap<LanguageMenu, LanguageMenuSmallDto>();
			CreateMap<LanguageMenu, LanguageMenuSimpleDto>();

			CreateMap<LanguageMenu, LanguageMenuSaveDto>().ReverseMap();
		}
	}
}

