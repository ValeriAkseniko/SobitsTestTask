using Domain.User;
using Entities;
using System;
using System.Threading.Tasks;

namespace InterfacesServices
{
    public interface IUserService : IDisposable
    {
        public Task CreateUserAsync(User user);

        public Task RemoveUserAsync(string userName);

        public Task<UserView> GetUserAsync(string userName);
    }
}
