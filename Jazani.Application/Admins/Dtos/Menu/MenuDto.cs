using Jazani.Application.Admins.Dtos.LanguageMenu;

namespace Jazani.Application.Admins.Dtos.Menu
{
	public class MenuDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        // Relations
        public virtual LanguageMenuSmallDto? languageMenu { get; set; }
    }
}

