using System.Collections.Generic;
using System.Threading.Tasks;
using GP.IdentityServer.Infrastructure.EF.Models;

namespace GP.IdentityServer.Infrastructure.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> Get(string id);
        Task<IEnumerable<User>> Users();
        Task<User> GetByUserName(string username);
        Task<User> Add(User user);
        Task<IEnumerable<User>> GetUsers();
        Task Delete(string id);
        Task DeleteByUserName(string username);
        Task Update(User user);
    }
}
