using Domain.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfacesServices
{
    public interface IUserService : IDisposable
    {
        public Task CreateUserAsync(UserCreateRequest user);

        public Task RemoveUserAsync(Guid id);

        public Task<List<UserView>> GetListUserAsync();

        public Task<UserView> GetUserAsync(Guid id);

        public Task UpdateUserAsync(UserUpdateRequest userUpdateRequest);

        public Task UpdateUserByPurchase(UserByPurchaseUpdateRequest userByPurchaseUpdateRequest);
    }
}
