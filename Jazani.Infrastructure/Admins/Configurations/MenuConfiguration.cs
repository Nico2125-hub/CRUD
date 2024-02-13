using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Cores.Converters;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("menu", "adm");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.LanguageMenuId).HasColumnName("languagemenuid");
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            // Relations
            builder.HasOne(a => a.LanguageMenus) // Entidad/Model Area
                .WithMany(at => at.Menus)   // Entida/Model AreaType
                .HasForeignKey(a => a.LanguageMenuId);
        }
    }
}

