using Domain.User;
using Entities;
using InterfacesDataAccess.Repositories;
using InterfacesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPurchaseRepository purchaseRepository;

        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository)
        {
            this.userRepository = userRepository;
            this.purchaseRepository = purchaseRepository;
        }

        public async Task CreateUserAsync(UserCreateRequest userRequest)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = userRequest.Name,
                Balance = userRequest.Balance
            };
            await userRepository.CreateAsync(user);
        }

        public void Dispose()
        {
            userRepository.Dispose();
        }

        public async Task<UserView> GetUserAsync(Guid id)
        {
            var entityDb = await userRepository.GetAsync(id);
            return new UserView
            {
                Id = entityDb.Id,
                Name = entityDb.Name,
                Balance = entityDb.Balance
            };
        }

        public async Task<List<UserView>> GetListUserAsync()
        {
            var users = await userRepository.GetListAsync();
            return users.Select(x => new UserView
            {
                Id = x.Id,
                Name = x.Name,
                Balance = x.Balance
            }).ToList();
        }

        public async Task RemoveUserAsync(Guid id)
        {
            var purchaseByBuyer = await purchaseRepository.GetListByBuyerAsync(id);
            foreach (var item in purchaseByBuyer)
            {
                await purchaseRepository.RemoveAsync(item.Id);
            }
            await userRepository.RemoveAsync(id);
        }

        public async Task UpdateUserAsync(UserUpdateRequest userUpdateRequest)
        {
            var user = new User
            {
                Id = userUpdateRequest.Id,
                Name = userUpdateRequest.Name,
                Balance = userUpdateRequest.Balance,
            };

            await userRepository.UpdateAsync(user);
        }

        public async Task UpdateUserByPurchase(UserByPurchaseUpdateRequest userByPurchaseUpdateRequest)
        {
            var user = new UserByPurchase
            {
                Id = userByPurchaseUpdateRequest.Id,
                Status = userByPurchaseUpdateRequest.Status,
                Debt = userByPurchaseUpdateRequest.Debt,
                PurchaseId = userByPurchaseUpdateRequest.PurchaseId,
                UserId = userByPurchaseUpdateRequest.UserId,
                UserName = userByPurchaseUpdateRequest.UserName
            };

            await userRepository.UpdateByPurchaseAsync(user);
        }
    }
}
