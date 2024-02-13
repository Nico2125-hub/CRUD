using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
	public class MenuRepository: CrudRepository<Menu,int>, IMenuRepository
	{
		private readonly ApplicationDbContext _dbContext;


        public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

        public async override Task<Menu?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Menu>()
                .AsQueryable()
                .Include(t => t.LanguageMenus)
                .FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}

