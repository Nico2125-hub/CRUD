using FluentValidation;

namespace Jazani.Application.Admins.Dtos.LanguageMenu.Validators
{
    public class LanguageMenuValidator : AbstractValidator<LanguageMenuSaveDto>
    {
        public LanguageMenuValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo name es requerido")
                .NotEmpty().WithMessage("El campo name no debe ser vacio")
                .Length(3, 50).WithMessage("El campo name debe tener entre 3 y 50 caracteres");

            RuleFor(x => x.Description)
                .MaximumLength(100).WithMessage("El campo description como maximo debe tener 100 caracteres");
        }
    }
}

