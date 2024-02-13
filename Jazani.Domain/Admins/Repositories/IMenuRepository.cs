using Jazani.Domain.Admins.Models;
using Jazani.Domain.Cores.Repositories;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IMenuRepository : ICrudRepository<Menu, int>
    {
    }
}

