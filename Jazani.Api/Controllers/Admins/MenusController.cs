using Jazani.Api.Exceptions;
using Jazani.Application.Admins.Dtos.Menu;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IEnumerable<MenuSmallDto>> Get()
        {
            return await _menuService.FindAllAsync();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MenuDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MenuDto>>> Get(int id)
        {
            var response = await _menuService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MenuSimpleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MenuSimpleDto>>> Post([FromBody] MenuSaveDto saveDto)
        {
            var response = await _menuService.CreateAsync(saveDto);

            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MenuSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<NotFound, BadRequest, Ok<MenuSimpleDto>>> Put(int id, [FromBody] MenuSaveDto saveDto)
        {
            var response = await _menuService.EditAsync(id, saveDto);

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MenuSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MenuSimpleDto>>> Delete(int id)
        {
            var response = await _menuService.DisabledAsync(id);

            return TypedResults.Ok(response);
        }
    }
}

