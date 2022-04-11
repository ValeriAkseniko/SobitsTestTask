using Entities;
using System;
using System.Threading.Tasks;

namespace InterfacesDataAccess.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task CreateUser(User user);

        Task<User> GetAsync(string userName);

        Task RemoveUser(string userName);
    }
}
