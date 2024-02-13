using Jazani.Api.Exceptions;
using Jazani.Application.Admins.Dtos.LanguageMenu;
using Jazani.Application.Admins.Services;
using Jazani.Application.Admins.Services.Implementations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageMenusController : ControllerBase
    {
        private readonly ILanguageMenuService _languageMenuService;

        public LanguageMenusController(ILanguageMenuService languageMenuService)
        {
            _languageMenuService = languageMenuService;
        }



        [HttpGet]
        public async Task<IEnumerable<LanguageMenuSmallDto>> Get()
        {
            return await _languageMenuService.FindAllAsync();
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageMenuDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<LanguageMenuDto>>> Get(int id)
        {
            var response = await _languageMenuService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LanguageMenuSimpleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<LanguageMenuSimpleDto>>> Post([FromBody] LanguageMenuSaveDto saveDto)
        {
            var response = await _languageMenuService.CreateAsync(saveDto);

            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageMenuSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<NotFound, BadRequest, Ok<LanguageMenuSimpleDto>>> Put(int id, [FromBody] LanguageMenuSaveDto saveDto)
        {
            var response = await _languageMenuService.EditAsync(id, saveDto);

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageMenuSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<LanguageMenuSimpleDto>>> Delete(int id)
        {
            var response = await _languageMenuService.DisabledAsync(id);

            return TypedResults.Ok(response);
        }

    }
}

