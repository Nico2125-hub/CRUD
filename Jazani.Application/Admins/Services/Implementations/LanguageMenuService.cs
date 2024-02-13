using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Application.Admins.Dtos.LanguageMenu;
using DomainLanguageMenu = Jazani.Domain.Admins.Models.LanguageMenu;

using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Admins.Dtos.LanguageMenu.Profiles;
using System.Security.AccessControl;

namespace Jazani.Application.Admins.Services.Implementations
{
	public class LanguageMenuService : ILanguageMenuService
    {
        private readonly ILanguageMenuRepository _languageMenuRepository;
        private readonly IMapper _mapper;

        public LanguageMenuService(ILanguageMenuRepository languageMenuRepository, IMapper mapper)
        {
            _languageMenuRepository = languageMenuRepository; 
            _mapper = mapper;
        }


        public async Task<LanguageMenuSimpleDto> CreateAsync(LanguageMenuSaveDto saveDto)
        {
            DomainLanguageMenu languageMenu = _mapper.Map<DomainLanguageMenu>(saveDto);
            languageMenu.RegistrationDate = DateTime.Now;
            languageMenu.State = true;

            DomainLanguageMenu languageMenuSaved = await _languageMenuRepository.SaveAsync(languageMenu);

            LanguageMenuSimpleDto languageMenuDto = _mapper.Map<LanguageMenuSimpleDto>(languageMenuSaved);

            return languageMenuDto;
        }

      

        public async Task<LanguageMenuSimpleDto> DisabledAsync(int id)
        {
            Domain.Admins.Models.LanguageMenu? languageMenu = await _languageMenuRepository.FindByIdAsync(id);

            if (languageMenu is null)
            {
                throw LanguageMenuNotFound(id);
            }

            languageMenu.State = false;


            Domain.Admins.Models.LanguageMenu languageMenuSaved = await _languageMenuRepository.SaveAsync(languageMenu);

            LanguageMenuSimpleDto languageMenuDto = _mapper.Map<LanguageMenuSimpleDto>(languageMenuSaved);

            return languageMenuDto;
        }


        public async Task<LanguageMenuSimpleDto> EditAsync(int id, LanguageMenuSaveDto saveDto)
        {
            Domain.Admins.Models.LanguageMenu? languageMenu = await _languageMenuRepository.FindByIdAsync(id);

            if (languageMenu is null)
            {
                throw LanguageMenuNotFound(id);
            }

            _mapper.Map(saveDto, languageMenu); // Corrección aquí

            Domain.Admins.Models.LanguageMenu languageMenuSaved = await _languageMenuRepository.SaveAsync(languageMenu);

            LanguageMenuSimpleDto languageMenuTypeDto = _mapper.Map<LanguageMenuSimpleDto>(languageMenuSaved);

            return languageMenuTypeDto;
        }

        public async Task<IReadOnlyList<LanguageMenuSmallDto>> FindAllAsync()
        {
            IReadOnlyList<Domain.Admins.Models.LanguageMenu> languageMenu = await _languageMenuRepository
                .FindAllAsync(predicate: x => x.State == true);

            IReadOnlyList<LanguageMenuSmallDto> languageMenuDto = _mapper.Map<IReadOnlyList<LanguageMenuSmallDto>>(languageMenu);

            return languageMenuDto;
        }

        public async Task<LanguageMenuDto> FindByIdAsync(int id)
        {
            Domain.Admins.Models.LanguageMenu? languageMenu = await _languageMenuRepository.FindByIdAsync(id);

            if (languageMenu is null)
            {
                throw LanguageMenuNotFound(id);
            }

            LanguageMenuDto languageMenuDto = _mapper.Map<LanguageMenuDto>(languageMenu);

            return languageMenuDto;
        }


        private NotFoundCoreException LanguageMenuNotFound(int id)
        {
            return new NotFoundCoreException("No se encontro un registro de Tipo de Area para el id: " + id);
        }
    }
}

