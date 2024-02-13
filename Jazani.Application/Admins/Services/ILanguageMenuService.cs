using Jazani.Application.Admins.Dtos.LanguageMenu;


namespace Jazani.Application.Admins.Services
{
	public interface ILanguageMenuService
	{
		Task<IReadOnlyList<LanguageMenuSmallDto>> FindAllAsync();

		Task<LanguageMenuDto> FindByIdAsync(int id);

		Task<LanguageMenuSimpleDto> CreateAsync(LanguageMenuSaveDto saveDto);

		Task<LanguageMenuSimpleDto> EditAsync(int id, LanguageMenuSaveDto saveDto);

		Task<LanguageMenuSimpleDto> DisabledAsync(int id);
    }
}

