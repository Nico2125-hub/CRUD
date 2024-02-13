using AutoMapper;
using Jazani.Application.Admins.Dtos.Menu;

using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuService> _logger;

        public MenuService(IMenuRepository menuRepository, IMapper mapper, ILogger<MenuService> logger)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MenuSimpleDto> CreateAsync(MenuSaveDto saveDto)
        {
            var menu = _mapper.Map<Menu>(saveDto);

            menu.RegistrationDate = DateTime.Now;
            menu.State = true;

            await _menuRepository.SaveAsync(menu);


            return _mapper.Map<MenuSimpleDto>(menu);
        }

        public IMapper Get_mapper()
        {
            return _mapper;
        }

      

        public async Task<MenuSimpleDto> DisabledAsync(int id)
        {
            var menu = await _menuRepository.FindByIdAsync(id);

            if (menu is null)
            {
                // hacer algo
            }

            menu.State = false;

            await _menuRepository.SaveAsync(menu);

            return _mapper.Map<MenuSimpleDto>(menu);
        }

        public async Task<IReadOnlyList<MenuSmallDto>> FindAllAsync()
        {
            var menus = await _menuRepository.FindAllAsync(predicate: x => x.State == true);
            return _mapper.Map<IReadOnlyList<MenuSmallDto>>(menus);
        }


        public async Task<MenuDto> FindByIdAsync(int id)
        {
            var menu = await _menuRepository.FindByIdAsync(id);

            _logger.LogInformation("menu:" + menu?.Id);

            if (menu is null)
            {
                // hacer algo
                _logger.LogWarning("[MenuService] - [FindByIdAsync]: No se encontro un registro de Menu para el id: " + id);
            }

            return _mapper.Map<MenuDto>(menu);
        }

        public async Task<MenuSimpleDto> EditAsync(int id, MenuSaveDto saveDto)
        {
            try
            {
                // Buscar el menú por su ID
                var menu = await _menuRepository.FindByIdAsync(id);

                // Verificar si el menú existe
                if (menu == null)
                {
                    throw new Exception("Menu not found"); // O lanza una excepción específica
                }

                // Actualizar los datos del menú con los proporcionados en saveDto
                menu.Name = saveDto.Name;
                menu.Description = saveDto.Description;

                // Guardar los cambios en el menú
                await _menuRepository.SaveAsync(menu);

                // Mapear el menú actualizado a un DTO y devolverlo
                var updatedMenuDto = _mapper.Map<MenuSimpleDto>(menu);
                return updatedMenuDto;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y registrarla si es necesario
                // También podrías lanzar una excepción personalizada si lo prefieres
                throw new Exception("Error editing menu", ex);
            }
        }

    }
}

