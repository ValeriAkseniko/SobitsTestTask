using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfacesDataAccess.Repositories
{
    public interface IUserRepository : IDisposable
    {

        public Task<List<User>> GetListAsync();

        Task CreateAsync(User user);

        Task<User> GetAsync(string userName);

        Task RemoveAsync(string userName);
    }
}
