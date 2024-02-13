using System;
namespace Jazani.Application.Admins.Dtos.Menu
{
	public class MenuSaveDto
	{
        public int LanguageMenuId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}

