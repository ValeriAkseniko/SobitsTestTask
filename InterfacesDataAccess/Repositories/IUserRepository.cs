using Entities;
using System;
using System.Threading.Tasks;

namespace InterfacesDataAccess.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task CreateAsync(User user);

        Task<User> GetAsync(string userName);

        Task RemoveAsync(string userName);
    }
}
