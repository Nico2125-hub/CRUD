using AutoMapper;
using Jazani.Application.Admins.Dtos.Menu;

namespace Jazani.Application.Admins.Services
{
	public interface IMenuService
	{
        Task<IReadOnlyList<MenuSmallDto>> FindAllAsync();

        Task<MenuDto> FindByIdAsync(int id);

        Task<MenuSimpleDto> CreateAsync(MenuSaveDto saveDto);

        Task<MenuSimpleDto> EditAsync(int id, MenuSaveDto saveDto);

        Task<MenuSimpleDto> DisabledAsync(int id);
        IMapper Get_mapper();

    }
}

