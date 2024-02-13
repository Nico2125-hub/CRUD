using Jazani.Application.Admins.Dtos.LanguageMenu;

namespace Jazani.Application.Admins.Dtos.Menu;

public class MenuMediumDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    // Relations
    public virtual LanguageMenuSmallDto? AreaType { get; set; }
}