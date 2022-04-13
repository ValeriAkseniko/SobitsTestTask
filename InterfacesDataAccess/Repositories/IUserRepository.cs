using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfacesDataAccess.Repositories
{
    public interface IUserRepository : IDisposable
    {

        public Task<List<User>> GetListAsync();

        public Task CreateAsync(User user);

        public Task<User> GetAsync(Guid id);

        public Task RemoveAsync(Guid id);

        public Task<User> GetByNameAsync(string name);

        public Task<List<UserByPurchase>> GetListByPurchaseId(Guid purchaseId);
    }
}
