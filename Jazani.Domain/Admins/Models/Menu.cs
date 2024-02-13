
    namespace Jazani.Domain.Admins.Models
    {
        public class Menu
        {
            public int Id { get; set; }
            public int LanguageMenuId { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
            public DateTime RegistrationDate { get; set; } 
            public bool State { get; set; }

            // Relaciones
            public virtual LanguageMenu LanguageMenus { get; set; }
        }
    }

