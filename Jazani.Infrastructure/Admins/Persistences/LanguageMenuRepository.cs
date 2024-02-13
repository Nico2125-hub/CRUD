using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class LanguageMenuRepository : CrudRepository<LanguageMenu, int>, ILanguageMenuRepository
    {

        public LanguageMenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}

